' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="MPacketModule.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Text.RegularExpressions

''' <summary>
''' The com_packet structure and the Helpers.
''' </summary>
Public Module MPacketModule
    ''' <summary>
    ''' The magic start
    ''' </summary>
    Public Const MAGIC_START As UInt64 = &HA45A2D9F&
    ''' <summary>
    ''' The argument size
    ''' </summary>
    Public Const ARGUMENT_SIZE As Int32 = 1024
    ''' <summary>
    ''' The size of packet
    ''' </summary>
    Public Const szOfPacket As UInt64 = 1308

    ''' <summary>
    ''' The packet PWS
    ''' </summary>
    Private PACKET_PWS As Integer = &H41

    ''' <summary>
    ''' Struct com_packet
    ''' </summary>
    Public Structure com_packet
        ''' <summary>
        ''' A magic start. For padding and shifting issues.
        ''' </summary>
        Dim magicStart As UInt64 ' 0-7
        ''' <summary>
        ''' The packet size
        ''' </summary>
        Dim packetSize As UInt64 ' 8-15
        ''' <summary>
        ''' The data type
        ''' </summary>
        Dim dataType As UInt32   ' 16-19
        ''' <summary>
        ''' The arguments
        ''' </summary>
        Dim arguments As String  ' 20-1043
        ''' <summary>
        ''' The checksum of the packet
        ''' </summary>
        Dim checksum As UInt64   ' 1044-1051
        ''' <summary>
        ''' The token associated to this packet.
        ''' </summary>
        Dim token As String      ' 1052-1307

        ''' <summary>
        ''' Gets the packet parameter values.
        ''' </summary>
        ''' <param name="param">The parameter.</param>
        ''' <returns>System.String.</returns>
        Public Function getPacketParamValue(ByVal param As String) As String
            Dim regex As Regex = New Regex("-" + param + " ""(.*?)""")
            Dim match As Match = regex.Match(arguments)

            If match.Success Then
                Return match.Groups(1).Value
            Else Return ""
            End If
        End Function
    End Structure

    ''' <summary>
    ''' Creates a packet parameter.
    ''' </summary>
    ''' <param name="param">The parameter.</param>
    ''' <param name="value">The value.</param>
    ''' <returns>System.String.</returns>
    Public Function createPacketParam(ByVal param As String, ByVal value As String) As String
        Return " -" + param + " """ + value + """"
    End Function



    ''' <summary>
    ''' Converts the packet to a byte stream.
    ''' </summary>
    ''' <param name="ccmPacket">The CCM packet.</param>
    ''' <returns>System.Byte().</returns>
    Public Function convertPacketToStream(ByRef ccmPacket As com_packet) As Byte()
        Dim stream(szOfPacket) As Byte
        ZeroMemory(stream)

        BitConverter.GetBytes(ccmPacket.magicStart).CopyTo(stream, 0)
        BitConverter.GetBytes(ccmPacket.packetSize).CopyTo(stream, 8)
        BitConverter.GetBytes(ccmPacket.dataType).CopyTo(stream, 16)
        Text.Encoding.ASCII.GetBytes(ccmPacket.arguments).CopyTo(stream, 20)
        BitConverter.GetBytes(ccmPacket.checksum).CopyTo(stream, 1044)
        Text.Encoding.ASCII.GetBytes(ccmPacket.token).CopyTo(stream, 1052)

        Return stream
    End Function

    ''' <summary>
    ''' Gets the packet from stream.
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    ''' <returns>com_packet.</returns>
    Public Function getPacketFromStream(ByRef buffer() As Byte) As com_packet
        Dim ccmPacket As com_packet

        ccmPacket.magicStart = BitConverter.ToUInt64(buffer, 0)
        ccmPacket.packetSize = BitConverter.ToUInt64(buffer, 8)
        ccmPacket.dataType = BitConverter.ToUInt32(buffer, 16)
        ccmPacket.arguments = Text.Encoding.ASCII.GetString(buffer, 20, ARGUMENT_SIZE)
        ccmPacket.checksum = BitConverter.ToUInt64(buffer, 1044)
        ccmPacket.token = Text.Encoding.ASCII.GetString(buffer, 1052, 256)

        SafeString(ccmPacket.arguments)
        SafeString(ccmPacket.token)

        Return ccmPacket
    End Function



    ''' <summary>
    ''' Computes the checksum of the packet.
    ''' </summary>
    ''' <param name="ccmPacket">The CCM packet.</param>
    ''' <returns>UInt64.</returns>
    Public Function computeChecksum(ByVal ccmPacket As com_packet) As UInt64
        Dim mComputedChecksum As UInt64 = 0

        mComputedChecksum += ccmPacket.packetSize
        mComputedChecksum = mComputedChecksum Xor &H7F12A071

        mComputedChecksum += ccmPacket.dataType
        mComputedChecksum = mComputedChecksum Xor &H7F12A071

        Dim nullChar As Integer = ccmPacket.arguments.IndexOf(vbNullChar)
        Dim size As Integer = IIf(nullChar = -1 Or nullChar = 0, ccmPacket.arguments.Length - 1, nullChar - 1)


        For argItterator As Int32 = 0 To size Step 1
            mComputedChecksum += Convert.ToByte(ccmPacket.arguments(argItterator))
            mComputedChecksum = mComputedChecksum Xor &H7F12A071
        Next


        Return mComputedChecksum
    End Function


    ''' <summary>
    ''' Xorize packet.
    ''' </summary>
    ''' <param name="bufferedPacket">The buffered packet.</param>
    Public Sub xor_ize_packet(ByVal bufferedPacket() As Byte)
        xor_ize_stream(bufferedPacket, szOfPacket, PACKET_PWS)
    End Sub

    ''' <summary>
    ''' Xors the ize stream.
    ''' </summary>
    ''' <param name="bufferedPacket">The buffered packet.</param>
    ''' <param name="size">The size.</param>
    ''' <param name="pws">The PWS.</param>
    Public Sub xor_ize_stream(ByVal bufferedPacket() As Byte, ByVal size As UInt32, ByVal pws As Integer)
        For bItterator As UInt32 = 0 To size Step 1
            bufferedPacket(bItterator) = bufferedPacket(bItterator) Xor BitConverter.GetBytes(pws)(0)
        Next
    End Sub



End Module
