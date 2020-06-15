' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="MPacketUserDescriptor.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Text.RegularExpressions

''' <summary>
''' The UserDescriptor class and the Helpers.
''' </summary>
Public Module MPacketUserDescriptor
    ''' <summary>
    ''' The size of user descriptor
    ''' </summary>
    Public Const szOfUserDescriptor As Int32 = 6187
    ''' <summary>
    ''' The uid key table. The id will be generated from these.
    ''' </summary>
    Private Const uidKeyTable As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ()_"

    ''' <summary>
    ''' The illegal patterns chars.
    ''' </summary>
    Private illegalPatternsChars As Regex = New Regex("[;,\t\r\n \.\.\/\\%&]")

    ''' <summary>
    ''' Holds user data.
    ''' </summary>
    Public Class userdescriptor
        ' Note: On right hand side you can see the offsets calculated manually for each entry. Not a fun work.

        ''' <summary>
        ''' The unique identifier
        ''' </summary>
        Public unique_id As String          ' 20    0-19
        ''' <summary>
        ''' The user name
        ''' </summary>
        Public user_name As String          ' 512   20-531
        ''' <summary>
        ''' The pc description
        ''' </summary>
        Public pc_description As String     ' 1024  532-1555
        ''' <summary>
        ''' The custom name
        ''' </summary>
        Public custom_name As String        ' 512   1556-2067
        ''' <summary>
        ''' The version
        ''' </summary>
        Public version As UShort            ' 2     2068-2069
        ''' <summary>
        ''' The os version
        ''' </summary>
        Public os_version As Byte           ' 1     2070-2070
        ''' <summary>
        ''' The os time
        ''' </summary>
        Public os_time As String            ' 16    2071-2086
        ''' <summary>
        ''' The extra data
        ''' </summary>
        Public extra_data As String         ' 4096  2087-6182
        ''' <summary>
        ''' The client type
        ''' </summary>
        Public client_type As Integer       ' 4     6183-6186
    End Class

    ''' <summary>
    ''' Gets the user descriptor from stream.
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    ''' <returns>userdescriptor.</returns>
    Public Function getUserDescriptorFromStream(ByRef buffer() As Byte) As userdescriptor
        Dim streamedUser As New userdescriptor

        streamedUser.unique_id = Text.Encoding.ASCII.GetString(buffer, 0, 20)
        streamedUser.user_name = Text.Encoding.ASCII.GetString(buffer, 20, 512)
        streamedUser.pc_description = Text.Encoding.ASCII.GetString(buffer, 532, 1024)
        streamedUser.custom_name = Text.Encoding.ASCII.GetString(buffer, 1556, 512)
        streamedUser.version = BitConverter.ToUInt16(buffer, 2068)
        streamedUser.os_version = buffer(2070)
        streamedUser.os_time = Text.Encoding.ASCII.GetString(buffer, 2071, 16)
        streamedUser.extra_data = Text.Encoding.ASCII.GetString(buffer, 2087, 4096)
        streamedUser.client_type = BitConverter.ToInt32(buffer, 6183)

        SafeString(streamedUser.unique_id)
        SafeString(streamedUser.user_name)
        SafeString(streamedUser.pc_description)
        SafeString(streamedUser.custom_name)
        SafeString(streamedUser.extra_data)


        '''' The code that follows is used in order to escape treaversal path issues
        '''' That is because the name is used in the construction of the path
        streamedUser.user_name = illegalPatternsChars.Replace(streamedUser.user_name, "")

        Return streamedUser
    End Function

    ''' <summary>
    ''' Converts the user descriptor to stream.
    ''' </summary>
    ''' <param name="userdata">The userdata.</param>
    ''' <returns>System.Byte().</returns>
    Public Function convertUserDescriptorToStream(ByRef userdata As userdescriptor) As Byte()
        Dim stream(szOfUserDescriptor + 2) As Byte
        ZeroMemory(stream)

        If Not userdata.unique_id Is Nothing Then Text.Encoding.ASCII.GetBytes(userdata.unique_id).CopyTo(stream, 0)
        If Not userdata.user_name Is Nothing Then Text.Encoding.ASCII.GetBytes(userdata.user_name).CopyTo(stream, 20)
        If Not userdata.pc_description Is Nothing Then Text.Encoding.ASCII.GetBytes(userdata.pc_description).CopyTo(stream, 532)
        If Not userdata.custom_name Is Nothing Then Text.Encoding.ASCII.GetBytes(userdata.custom_name).CopyTo(stream, 1556)

        BitConverter.GetBytes(userdata.version).CopyTo(stream, 2068)
        stream(2070) = userdata.os_version

        If Not userdata.os_time Is Nothing Then Text.Encoding.ASCII.GetBytes(userdata.os_time).CopyTo(stream, 2071)
        If Not userdata.extra_data Is Nothing Then Text.Encoding.ASCII.GetBytes(userdata.extra_data).CopyTo(stream, 2087)
        If Not userdata.client_type = Nothing Then BitConverter.GetBytes(userdata.client_type).CopyTo(stream, 6183)

        Return stream
    End Function

    ''' <summary>
    ''' Generates the random uid.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function generateRandomUID() As String
        Dim rnd As New Random
        Dim suid As String = ""

        For i As Integer = 0 To 19 Step 1
            suid += Convert.ToChar(uidKeyTable(rnd.Next(0, uidKeyTable.Length)))
        Next

        Return suid
    End Function

End Module
