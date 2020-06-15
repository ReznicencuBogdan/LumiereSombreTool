' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="Settings.Designer.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************--

Option Strict On
Option Explicit On


Namespace My

    ''' <summary>
    ''' Class MySettings. This class cannot be inherited.
    ''' Implements the <see cref="System.Configuration.ApplicationSettingsBase" />
    ''' </summary>
    ''' <seealso cref="System.Configuration.ApplicationSettingsBase" />
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0"),
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

        ''' <summary>
        ''' The default instance
        ''' </summary>
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()), MySettings)

#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
        ''' <summary>
        ''' The added handler
        ''' </summary>
        Private Shared addedHandler As Boolean

        ''' <summary>
        ''' The added handler lock object
        ''' </summary>
        Private Shared addedHandlerLockObject As New Object

        ''' <summary>
        ''' Automatics the save settings.
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
            If My.Application.SaveMySettingsOnExit Then
                My.Settings.Save()
            End If
        End Sub
#End If
#End Region

        ''' <summary>
        ''' Gets the default.
        ''' </summary>
        ''' <value>The default.</value>
        Public Shared ReadOnly Property [Default]() As MySettings
            Get

#If _MyType = "WindowsForms" Then
                If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property

        ''' <summary>
        ''' Gets the server client management2003 connection string.
        ''' </summary>
        ''' <value>The server client management2003 connection string.</value>
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),
         Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ServerClientManageme" &
            "nt2003.mdb")>
        Public ReadOnly Property ServerClientManagement2003ConnectionString() As String
            Get
                Return CType(Me("ServerClientManagement2003ConnectionString"), String)
            End Get
        End Property
    End Class
End Namespace

Namespace My

    ''' <summary>
    ''' Class MySettingsProperty.
    ''' </summary>
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>
    Friend Module MySettingsProperty

        ''' <summary>
        ''' Gets the settings.
        ''' </summary>
        ''' <value>The settings.</value>
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>
        Friend ReadOnly Property Settings() As Global.LumiereServer.My.MySettings
            Get
                Return Global.LumiereServer.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
