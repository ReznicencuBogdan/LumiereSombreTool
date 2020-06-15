' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="WindowByteViewer.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports Be.Windows.Forms

''' <summary>
''' Class WindowByteViewer.
''' Implements the <see cref="System.Windows.Forms.Form" />
''' </summary>
''' <seealso cref="System.Windows.Forms.Form" />
Public Class WindowByteViewer
    ''' <summary>
    ''' The bytebuffer
    ''' </summary>
    Dim bytebuffer As DynamicByteProvider = New DynamicByteProvider({0})

    ''' <summary>
    ''' Sets the reg value path.
    ''' </summary>
    ''' <param name="rPath">The r path.</param>
    Public Sub set_reg_value_path(ByVal rPath As String)
        lblRegPath.Text = rPath
    End Sub

    ''' <summary>
    ''' Sets the hexadecimal editor data.
    ''' </summary>
    ''' <param name="data">The data.</param>
    Public Sub set_hex_editor_data(ByVal data As String)
        bytebuffer.DeleteBytes(0, bytebuffer.Length)

        bytebuffer.InsertBytes(0, System.Text.Encoding.ASCII.GetBytes(data))

        hexview.ByteProvider = bytebuffer
    End Sub

    ''' <summary>
    ''' Gets the bytes.
    ''' </summary>
    ''' <returns>System.Byte().</returns>
    Public Function get_bytes() As Byte()
        Dim nbytes(bytebuffer.Length) As Byte

        bytebuffer.Bytes().CopyTo(nbytes)

        Return nbytes
    End Function

End Class