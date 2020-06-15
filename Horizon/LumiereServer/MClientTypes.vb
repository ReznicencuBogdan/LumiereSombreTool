' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="MClientTypes.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary>Holds types of clients that can at the moment be managed by the server. Anything else is discarded.</summary>
' ***********************************************************************
''' <summary>
''' Holds types of clients that can at the moment be managed by the server. Anything else is discarded.
''' </summary>
Public Module MClientTypes

    ' the type identifies the tcp client inside an array
    ' may be problatic if out of bounds

    ''' <summary>
    ''' Enum clientTypes
    ''' </summary>
    Public Enum clientTypes
        ''' <summary>
        ''' The shell
        ''' </summary>
        shell = 0
        ''' <summary>
        ''' The screen capture
        ''' </summary>
        screenCapture = 1
        ''' <summary>
        ''' The FTP
        ''' </summary>
        ftp = 2
        ''' <summary>
        ''' The hooks
        ''' </summary>
        hooks = 3
        ''' <summary>
        ''' The autodestroy
        ''' </summary>
        autodestroy = 4
        ''' <summary>
        ''' The audio
        ''' </summary>
        audio = 5
        ''' <summary>
        ''' The bsod
        ''' </summary>
        bsod = 6
        ''' <summary>
        ''' The upload manager
        ''' </summary>
        upload_manager = 7
        ''' <summary>
        ''' The download manager
        ''' </summary>
        download_manager = 8
        ''' <summary>
        ''' The regedit
        ''' </summary>
        regedit = 10
        ''' <summary>
        ''' The mouse
        ''' </summary>
        mouse = 11
        ''' <summary>
        ''' The ctypesize
        ''' </summary>
        ctypesize = 12   '''' # note: never delete this line. determines the size of the enum
    End Enum

End Module
