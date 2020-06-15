' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="Application.Designer.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************--

Option Strict On
Option Explicit On


Namespace My

    'NOTE: This file is auto-generated; do not modify it directly.  To make changes,
    ' or if you encounter build errors in this file, go to the Project Designer
    ' (go to Project Properties or double-click the My Project node in
    ' Solution Explorer), and make changes on the Application tab.
    '
    ''' <summary>
    ''' Class MyApplication.
    ''' Implements the <see cref="Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase" />
    ''' </summary>
    ''' <seealso cref="Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase" />
    Partial Friend Class MyApplication

        ''' <summary>
        ''' Initializes a new instance of the <see cref="MyApplication"/> class.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = True
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub

        ''' <summary>
        ''' Called when [create main form].
        ''' </summary>
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.LumiereServer.LumiereServer
        End Sub
    End Class
End Namespace
