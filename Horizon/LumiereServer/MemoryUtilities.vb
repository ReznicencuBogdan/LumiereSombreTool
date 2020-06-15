' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="MemoryUtilities.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Text.RegularExpressions

''' <summary>
''' Memory utilities.
''' </summary>
Public Module MemoryUtilities

    ''' <summary>
    ''' Illegal pattern chars
    ''' </summary>
    Private illegalPatternsChars As Regex = New Regex("[;,\t\r\n%&]")

    ''' <summary>
    ''' Checks for path traversal.
    ''' </summary>
    ''' <param name="path">The path.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Function hackedPathTraversal(ByVal path As String) As Boolean

        '''' Ussualy slow for large test cases. Not our case though
        Dim cleanPath As String = illegalPatternsChars.Replace(path, "")

        If Not cleanPath = path Then Return True

        '''' UNICODE CHECK
        '    cleanPath = New String(path.Where(Function(c) Convert.ToInt32(c) <= SByte.MaxValue).ToArray())
        '    If Not cleanPath = path Then Return True

        cleanPath = path.Replace("..", "")

        If Not cleanPath = path Then Return True

        Return False
    End Function


    ''' <summary>
    ''' Enum informationcode
    ''' </summary>
    Public Enum informationcode
        ''' <summary>
        ''' The error
        ''' </summary>
        [error] = 1
        ''' <summary>
        ''' The normal
        ''' </summary>
        normal = 2
        ''' <summary>
        ''' The warning
        ''' </summary>
        warning = 3
    End Enum

    ''' <summary>
    ''' Zeroes the memory.
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    Public Sub ZeroMemory(ByRef buffer() As Byte)

        For i As Int32 = 0 To buffer.Count - 1 Step 1
            buffer(i) = 0
        Next

    End Sub

    ''' <summary>
    ''' Safes the string. Stops at the null char. Conversion between c string and .net string
    ''' </summary>
    ''' <param name="str">The string.</param>
    Public Sub SafeString(ByRef str As String)
        Dim nullChrPos As Integer = str.IndexOf(vbNullChar)
        If Not nullChrPos = -1 Then str = str.Substring(0, nullChrPos)
    End Sub

    ''' <summary>
    ''' Strips the unicode characters from string.
    ''' </summary>
    ''' <param name="inputValue">The input value.</param>
    Public Sub StripUnicodeCharactersFromString(ByRef inputValue As String)
        inputValue = New String(inputValue.Where(Function(c) Convert.ToInt32(c) <= SByte.MaxValue).ToArray())
    End Sub

End Module
