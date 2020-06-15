' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="WindowRegNewValue.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' Class WindowRegNewValue.
''' Implements the <see cref="System.Windows.Forms.Form" />
''' </summary>
''' <seealso cref="System.Windows.Forms.Form" />
Public Class WindowRegNewValue

    ''' <summary>
    ''' Gets the name of the reg value.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function get_reg_value_name() As String
        Return txtValName.Text
    End Function

    ''' <summary>
    ''' Gets the type of the reg.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function get_reg_type() As String
        Dim data As String = cmbValType.Text

        Return data.Split("-")(1).Replace(" ", "")
    End Function


    ''' <summary>
    ''' Gets the reg value data.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function get_reg_value_data() As String
        Return txtValueData.Text
    End Function
End Class