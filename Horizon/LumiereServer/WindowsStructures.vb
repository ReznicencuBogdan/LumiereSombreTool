' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="WindowsStructures.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Text

''' <summary>
''' Class WindowsStructures.
''' </summary>
Public Module WindowsStructures

    ''' <summary>
    ''' The sz of win32 find dataa
    ''' </summary>
    Public Const szOfWin32FindDataa As Integer = 320

    ''' <summary>
    ''' Struct FILETIME
    ''' </summary>
    Public Structure FILETIME
        ''' <summary>
        ''' The dw low date time
        ''' </summary>
        Dim dwLowDateTime As Long
        ''' <summary>
        ''' The dw high date time
        ''' </summary>
        Dim dwHighDateTime As Long
    End Structure

    ''' <summary>
    ''' Struct WIN32_FIND_DATAA
    ''' </summary>
    Public Structure WIN32_FIND_DATAA
        ''' <summary>
        ''' The dw file attributes
        ''' </summary>
        Dim dwFileAttributes As UInt32
        ''' <summary>
        ''' The ft creation time
        ''' </summary>
        Dim ftCreationTime As FILETIME
        ''' <summary>
        ''' The ft last access time
        ''' </summary>
        Dim ftLastAccessTime As FILETIME
        ''' <summary>
        ''' The ft last write time
        ''' </summary>
        Dim ftLastWriteTime As FILETIME
        ''' <summary>
        ''' The n file size high
        ''' </summary>
        Dim nFileSizeHigh As UInt32
        ''' <summary>
        ''' The n file size low
        ''' </summary>
        Dim nFileSizeLow As UInt32
        ''' <summary>
        ''' The dw reserved0
        ''' </summary>
        Dim dwReserved0 As UInt32
        ''' <summary>
        ''' The dw reserved1
        ''' </summary>
        Dim dwReserved1 As UInt32
        ''' <summary>
        ''' The c file name
        ''' </summary>
        Dim cFileName As String          ' 260 bytes no padding
        ''' <summary>
        ''' The c alternate file name
        ''' </summary>
        Dim cAlternateFileName As String ' 14 bytes no padding
        '+ 2 byte padding
    End Structure


    ''' <summary>
    ''' Converts the stream to win32 find data.
    ''' </summary>
    ''' <param name="buf">The buf.</param>
    ''' <param name="offset">The offset.</param>
    ''' <returns>WIN32_FIND_DATAA.</returns>
    Public Function convertStreamToWin32FindData(ByRef buf() As Byte, ByVal offset As ULong) As WIN32_FIND_DATAA
        Dim FindData As WIN32_FIND_DATAA

        FindData.dwFileAttributes = BitConverter.ToUInt32(buf, offset)
        FindData.ftCreationTime.dwLowDateTime = BitConverter.ToUInt32(buf, offset + 4)
        FindData.ftCreationTime.dwHighDateTime = BitConverter.ToUInt32(buf, offset + 8)
        FindData.ftLastAccessTime.dwLowDateTime = BitConverter.ToUInt32(buf, offset + 12)
        FindData.ftLastAccessTime.dwHighDateTime = BitConverter.ToUInt32(buf, offset + 16)
        FindData.ftLastWriteTime.dwLowDateTime = BitConverter.ToUInt32(buf, offset + 20)
        FindData.ftLastWriteTime.dwHighDateTime = BitConverter.ToUInt32(buf, offset + 24)
        FindData.nFileSizeHigh = BitConverter.ToUInt32(buf, offset + 28)
        FindData.nFileSizeLow = BitConverter.ToUInt32(buf, offset + 32)
        FindData.dwReserved0 = BitConverter.ToUInt32(buf, offset + 36)
        FindData.dwReserved1 = BitConverter.ToUInt32(buf, offset + 40)

        FindData.cFileName = Encoding.ASCII.GetString(buf, offset + 44, 260)
        SafeString(FindData.cFileName)

        FindData.cAlternateFileName = Encoding.ASCII.GetString(buf, offset + 44 + 260, 14)
        SafeString(FindData.cAlternateFileName)

        Return FindData
    End Function


    ''' <summary>
    ''' Formats the size of the file.
    ''' </summary>
    ''' <param name="lngFileSize">Size of the LNG file.</param>
    ''' <returns>System.String.</returns>
    Public Function FormatFileSize(ByVal lngFileSize As Long) As String
        Dim qnt As Integer = 0
        Dim sufx As String = ""
        Dim out As Single = lngFileSize

        Do Until Int(out) < 1000
            qnt = qnt + 1
            out = out / 1024
        Loop

        out = Math.Round(out, 0)

        Select Case qnt
            Case 0
                sufx = "b"
            Case 1
                sufx = "kb"
            Case 2
                sufx = "mb"
            Case 3
                sufx = "gb"
            Case 4
                sufx = "tb"
        End Select

        Return Convert.ToString(out) & " " & sufx
    End Function

    ''' <summary>
    ''' Files the time to date.
    ''' </summary>
    ''' <param name="fTime">The f time.</param>
    ''' <returns>System.DateTime.</returns>
    Private Function FileTimeToDate(ByRef fTime As FILETIME) As Date
        Return Date.FromFileTime(fTime.dwHighDateTime << 32 Or fTime.dwLowDateTime)
    End Function
    ''' <summary>
    ''' Files the time to string.
    ''' </summary>
    ''' <param name="fTime">The f time.</param>
    ''' <returns>System.String.</returns>
    Public Function FileTimeToString(ByRef fTime As FILETIME) As String
        Return FileTimeToDate(fTime).Minute.ToString + ":" + FileTimeToDate(fTime).Hour.ToString + ":" + FileTimeToDate(fTime).Second.ToString + "   " +
           FileTimeToDate(fTime).Day.ToString + "/" + FileTimeToDate(fTime).Month.ToString + "/" + FileTimeToDate(fTime).Year.ToString
    End Function
End Module
