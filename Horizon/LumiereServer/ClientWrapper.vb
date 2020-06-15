' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="ClientWrapper.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.ComponentModel

''' <summary>
''' Class ClientWrapper. Holds multiple subclient/submodules that identify a online
''' component that belongs to one client. So one client on the server is actually a 
''' list of real clients.
''' Implements the <see cref="System.ComponentModel.INotifyPropertyChanged" />
''' </summary>
''' <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
Public Class ClientWrapper
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' The general user descriptor. Common to all subclients.
    ''' </summary>
    Private generalUsrDescriptor As userdescriptor = Nothing
    ''' <summary>
    ''' The wrapper unique identifier
    ''' </summary>
    Private wrapperSystemId As String

    ''' <summary>
    ''' The list of ClientInstances
    ''' </summary>
    Public clientHolder(clientTypes.ctypesize - 1) As ClientInstance
    ''' <summary>
    ''' The UI on destroy callback.
    ''' </summary>
    Public uiOnDestroy As Func(Of ClientWrapper, ClientInstance, Boolean)
    ''' <summary>
    ''' The on empty wrapper callback. What happens when there will no longer be clients in a wrapper.
    ''' </summary>
    Public onEmptyWrapper As Func(Of ClientWrapper, Boolean)

    ''' <summary>
    ''' The size of the wrapper.
    ''' </summary>
    Public size As Integer = 0
    ''' <summary>
    ''' The ip of the wrapper.
    ''' </summary>
    Public ip As String
    ''' <summary>
    ''' Tells whether this wrapper is ready for UI communication.
    ''' </summary>
    Public isUIConnected As Boolean = False


#Region "Tcp_Client___Setters_Methods"

    ''' <summary>
    ''' Sets the on empty wrapper callback.
    ''' </summary>
    ''' <param name="onempt">The callback.</param>
    Public Sub set_on_empty_wrapper(ByVal onempt As Func(Of ClientWrapper, Boolean))
        onEmptyWrapper = onempt
    End Sub

    ''' <summary>
    ''' Sets the on destroy callback.
    ''' </summary>
    ''' <param name="ondestr">The callback.</param>
    Public Sub set_on_destroy(ByVal ondestr As Func(Of ClientWrapper, ClientInstance, Boolean))
        '''' Called every time from some client from this wrapper gets destroyed 
        '''' The UI will handle the event first

        uiOnDestroy = ondestr
    End Sub

    ''' <summary>
    ''' Adds a new client to this wrapper.
    ''' </summary>
    ''' <param name="client">The client.</param>
    ''' <param name="onrecv">The onrecv callback asociated to client.</param>
    Public Sub set_new_client(ByVal client As ClientInstance, ByVal onrecv As Func(Of ClientInstance, com_packet, Boolean))

        Dim index As Integer = client.get_client_type()

        If Not clientHolder(index) Is Nothing Then
            clientHolder(index).destroy()
            clientHolder(index) = Nothing
            size -= 1
        End If

        size += 1
        clientHolder(index) = client
        clientHolder(index).set_parrent_wrapper(Me)
        clientHolder(index).set_on_receive(onrecv)
        clientHolder(index).set_on_destroy(AddressOf original_on_client_destroy)
    End Sub

    ''' <summary>
    ''' Sets some wrapper information.
    ''' </summary>
    ''' <param name="client">The client.</param>
    Public Sub set_wrapper_information(ByRef client As ClientInstance)
        wrapperSystemId = client.get_system_id()
        generalUsrDescriptor = client.get_user_descriptor()

        ip = client.ip
    End Sub

#End Region




#Region "Tcp_Client___Wrapper_Integrity_Methods"

    ''' <summary>
    ''' First callback to be called on client destruction.
    ''' </summary>
    ''' <param name="clientWrapper">The client wrapper.</param>
    ''' <param name="client">The client instance.</param>
    ''' <returns>true</returns>
    Private Function original_on_client_destroy(ByVal clientWrapper As ClientWrapper, ByVal client As ClientInstance) As Boolean
        '''' first handle the destruction on the UI
        '''' and afterwards here on this wrapper

        clientWrapper.size -= 1
        clientWrapper.clientHolder(client.get_client_type()) = Nothing
        clientWrapper.uiOnDestroy(clientWrapper, client)

        If clientWrapper.size = 0 Then clientWrapper.onEmptyWrapper(clientWrapper)

        Return True
    End Function

    ''' <summary>
    ''' Destroys every client in the wrapper.
    ''' </summary>
    Public Sub destroy_every_client()
        For i As Integer = 0 To clientHolder.Length() - 1 Step 1
            Dim temp As ClientInstance = clientHolder(i)

            If temp IsNot Nothing Then temp.destroy()
        Next
    End Sub

    ''' <summary>
    ''' Starts the every client component.
    ''' </summary>
    Public Sub start_every_client_component()
        For i As Integer = 0 To clientHolder.Length() - 1 Step 1
            If Not clientHolder(i) Is Nothing Then clientHolder(i).start_client_component()
        Next
    End Sub

    ''' <summary>
    ''' Pings the every client component.
    ''' </summary>
    Public Sub ping_every_client_component()

        For i As Integer = 0 To clientHolder.Length() - 1 Step 1
            If Not clientHolder(i) Is Nothing Then
                If Not clientHolder(i).ping_protocol() Then
                    clientHolder(i).destroy()
                End If
            End If
        Next

    End Sub

#End Region




#Region "Tcp_Client___Getters_Methods"

    ''' <summary>
    ''' Gets one active client.
    ''' </summary>
    ''' <returns>ClientInstance.</returns>
    Public Function get_one_active_client() As ClientInstance

        For i As Integer = 0 To clientHolder.Length() - 1 Step 1
            Dim client As ClientInstance = CType(clientHolder(i), ClientInstance)

            If Not client Is Nothing Then Return client
        Next

        Return Nothing
    End Function

    ''' <summary>
    ''' Gets a client component by type. There can only be one and only one client of a type.
    ''' </summary>
    ''' <param name="clienttypeindex">The clienttypeindex.</param>
    ''' <returns>ClientInstance.</returns>
    Public Function get_client_component_by_type(ByVal clienttypeindex As Integer) As ClientInstance

        Return clientHolder(clienttypeindex)

    End Function

    ''' <summary>
    ''' Gets the user descriptor.
    ''' </summary>
    ''' <returns>userdescriptor.</returns>
    Public Function get_user_descriptor() As userdescriptor
        Return generalUsrDescriptor
    End Function

    ''' <summary>
    ''' Gets the system identifier.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function get_system_id() As String
        Return wrapperSystemId
    End Function

    ''' <summary>
    ''' Equality operator between wrapper.
    ''' </summary>
    ''' <param name="wrapper1">The wrapper to compare against.</param>
    ''' <returns><c>true</c> if identical, <c>false</c> otherwise.</returns>
    Public Function get_same_as(ByVal wrapper1 As ClientWrapper) As Boolean
        If wrapper1 Is Nothing Then Return False

        Return get_system_id().Equals(wrapper1.get_system_id())
    End Function

    ''' <summary>
    ''' Tells if a client of a type exists
    ''' </summary>
    ''' <param name="index">The index.</param>
    ''' <returns><c>true</c> if exists, <c>false</c> otherwise.</returns>
    Public Function get_client_exists(ByVal index As Integer) As Boolean

        If clientHolder(index) Is Nothing Then Return False

        Return True
    End Function

#End Region



    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>A <see cref="System.String" /> that represents this instance.</returns>
    Public Overrides Function ToString() As String
        Return " " + get_system_id()
    End Function

    ''' <summary>
    ''' Destructor
    ''' </summary>
    Protected Overrides Sub Finalize()
        '''' this method doesn't handle individual destruction
        '''' here I just make sure that object are set to null
        Debug.Print("Entered wrapper destructor!")

        isUIConnected = False
        destroy_every_client()
        Debug.Print("Exited wrapper destructor!")
    End Sub


    ''' <summary>
    ''' A class that safely locks a inner object for inter thread communication.
    ''' </summary>
    ''' <typeparam name="T">The object that is to be guarded.</typeparam>
    Public Class SafeObjectHandler(Of T)
        Dim internal_subject As T, lock As New Object

        ''' <summary>
        ''' Gets or sets the value.
        ''' </summary>
        ''' <value>The value.</value>
        Public Property value As T
            Get
                SyncLock lock
                    Return internal_subject
                End SyncLock
            End Get

            Set(value As T)
                SyncLock lock
                    internal_subject = value
                End SyncLock
            End Set
        End Property

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SafeObjectHandler{T}"/> class.
        ''' </summary>
        ''' <param name="subject">The subject.</param>
        Public Sub New(ByRef subject As T)
            internal_subject = subject
        End Sub
    End Class
End Class
