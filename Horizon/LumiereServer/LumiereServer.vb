' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-15-2020
' ***********************************************************************
' <copyright file="LumiereServer.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary>Main class of the program</summary>
' ***********************************************************************
Imports System.ComponentModel

Imports System.Threading
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Collections.Concurrent


''' <summary>
''' Class LumiereServer.
''' Implements the <see cref="System.Windows.Forms.Form" />
''' </summary>
''' <seealso cref="System.Windows.Forms.Form" />
Public Class LumiereServer
    '''' Define important variables for the server
    ''' <summary>
    ''' The TCP listener.
    ''' </summary>
    Private TcpListener As TcpListener
    ''' <summary>
    ''' A event driven collection of client wrappers.
    ''' </summary>
    Private ClientCollectionSource As New ClientCollectionSource_
    ''' <summary>
    ''' A selected client wrapper
    ''' </summary>
    Private selectedClientWrapper As ClientWrapper
    ''' <summary>
    ''' A thread safe selected client wrapper
    ''' </summary>
    Private safeSelectedClientWrapper As New SafeObjectHandler(Of ClientWrapper)(selectedClientWrapper)

    '''' String which holds an empty string placeholder
    ''' <summary>
    ''' The empty information string.
    ''' </summary>
    Private Const emptystr As String = "───────────────────"

    ''' <summary>
    ''' String which holds switch values for the available clients
    ''' </summary>
    Private Const cmp_on As String = "on"
    ''' <summary>
    ''' The CMP off
    ''' </summary>
    Private Const cmp_off As String = "off"

    '''' Strings used in the communications with the ftp client
    ''' <summary>
    ''' Folder
    ''' </summary>
    Private Const Folder As String = "Folder"
    ''' <summary>
    ''' File
    ''' </summary>
    Private Const File As String = "File"
    ''' <summary>
    ''' Home
    ''' </summary>
    Private Const Home As String = "\"

    ''' <summary>
    ''' String which holds the real content of the command to be sent
    ''' </summary>
    Private cmdPromptText As String = ""

    ''' <summary>
    ''' The database of users. Creates a unique connection.
    ''' </summary>
    Private databaseOfUsers As New DatabaseUsers()

    ''' <summary>
    ''' Window where the video stream frames will be drawn on.
    ''' </summary>
    Private WithEvents videoFrm As WindowVideo = WindowVideo    ' Default form

    ''' <summary>
    ''' Holds a video frame.
    ''' </summary>
    Private videoData As FrameData = Nothing


    ''' <summary>
    ''' Handles the new clients that want to connect
    ''' </summary>
    Private threadMainUIListener As Thread

    ''' <summary>
    ''' Handles the authentification procedure for each client in a queue
    ''' </summary>
    Private threadMainAuthentificatePreProcessor As Thread

    ''' <summary>
    ''' Holds clients that need to pass authenitification.
    ''' </summary>
    Private clientPendingAuthentificationConqurentQueue As New ConcurrentQueue(Of ClientInstance)



#Region "RegionMarker_MainEntryPointMethods"

    ''' <summary>
    ''' Handles the Load event of the LumiereServer control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub LumiereServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '''' Initiate the hidden panel
        hiddenPanel.Left = panelInfoHolder.Left
        hiddenPanel.Top = panelInfoHolder.Top
        hiddenPanel.Width = panelInfoHolder.Width
        hiddenPanel.Height = panelInfoHolder.Height

        clientList.Width = hiddenPanel.Width
        clientList.Height = hiddenPanel.Height

        '''' Initiate the lsitbindingsource
        listbindingsource.DataSource = ClientCollectionSource
        clientList.DataSource = listbindingsource
        clientList.SelectedIndex = -1

        '''' Initialize the regedit view UI
        regedit_initialize()

        '''' Initialize the Listener thread
        threadMainUIListener = New Thread(New ParameterizedThreadStart(AddressOf threadMainUIListenerFunc)) With {
            .Name = "ListeningThread",
            .IsBackground = True
        }
        threadMainUIListener.Start()

        '''' Initialize the Authenitificating thread
        threadMainAuthentificatePreProcessor = New Thread(New ParameterizedThreadStart(AddressOf threadMainAuthentificatePostProcessorFunc)) With {
            .Name = "AuthentificatingThread",
            .IsBackground = True
        }
        threadMainAuthentificatePreProcessor.Start()
    End Sub


    ''' <summary>
    ''' Actions to perform on client connection
    ''' </summary>
    ''' <param name="client">Instance of the connection</param>
    Private Sub doOnClientInitiation(ByVal client As ClientInstance)
        Dim sPacket As com_packet

        Select Case client.get_client_type()
            Case clientTypes.shell
                ftpUrl.Text = Home
                client.send_header(dataTypes.shell, 0, " " + vbCrLf, sPacket)

            Case clientTypes.ftp
                ftpView.Items.Clear()
                client.send_header(dataTypes.enum_drives, 0, "", sPacket)

            Case clientTypes.regedit
                ' regedit_initialize()
        End Select
    End Sub

    ''' <summary>
    ''' Event captured on server close-down.
    ''' Clear allocated resources. Close conenctions gracefully.
    ''' </summary>
    ''' <param name="sender">Sender object</param>
    ''' <param name="e">Cancelation Token</param>
    Private Sub LumiereServer_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            TcpListener.Stop()
        Catch ex As Exception

        End Try

        SyncLock listbindingsource
            '' Use this reversed-index loop because "destroy" command also alters the listbinding ( a collection cannot be modified in a for-each)
            For i As Integer = listbindingsource.List.Count - 1 To 0 Step -1
                Dim clientWrapper As ClientWrapper = listbindingsource.Item(i)

                If clientWrapper Is Nothing Then
                    listbindingsource.RemoveAt(i)
                    Continue For
                End If

                clientWrapper.destroy_every_client()
            Next
        End SyncLock
    End Sub

#End Region



#Region "RegionMarker_ClientCallbacks"

    ''' <summary>
    ''' When a client wrapper becomes empty. No other client connected.
    ''' </summary>
    ''' <param name="clientWrapper">The client wrapper.</param>
    ''' <returns>true</returns>
    Private Function onEmptyWrapperCallback(ByVal clientWrapper As ClientWrapper) As Boolean
        SyncLock listbindingsource

            ' Remove client from UI interface
            If clientList.InvokeRequired Then
                clientList.Invoke(Sub() listbindingsource.Remove(clientWrapper))
            Else
                listbindingsource.Remove(clientWrapper)
            End If

        End SyncLock


        If safeSelectedClientWrapper.value Is Nothing Or clientWrapper.get_same_as(safeSelectedClientWrapper.value) Then
            resetInformationPanel()
            safeSelectedClientWrapper.value = Nothing
        Else
            'doThreadSafeObjectLinkedAction(clientList, Function()
            '                                               Dim nowSelectedClient As ClientWrapper = safeSelectedClientWrapper.value

            '                                               If nowSelectedClient IsNot Nothing Then
            '                                                   linkDataToInformationPanel(nowSelectedClient)
            '                                               End If

            '                                               Return True
            '                                           End Function)
        End If


        Return True
    End Function

    ''' <summary>
    ''' On client destruction. Cancel operations if any. Show UI updates.
    ''' </summary>
    ''' <param name="clientWrapper">The client wrapper.</param>
    ''' <param name="client">The client.</param>
    ''' <returns>true.</returns>
    Private Function clientDestroyedCallback(ByVal clientWrapper As ClientWrapper, ByVal client As ClientInstance) As Boolean
        '
        '''' In case there was something allocated by a kind of client then
        '''' here I have the oprtunity of destroying those resources.

        Select Case client.get_client_type()
            Case clientTypes.upload_manager
                uploadBackgroundWorker.CancelAsync()
            Case clientTypes.regedit
                If clientWrapper.isUIConnected Then regedit_initialize()
            Case clientTypes.screenCapture
                ' LiveComponent.Hide()
        End Select

        If clientWrapper.isUIConnected Then linkDataToInformationPanel(clientWrapper)

        debugMessage("Client " + client.get_to_string() + " has been disonnected!", informationcode.warning)

        Return True
    End Function

    ''' <summary>
    ''' Handles the SelectedIndexChanged event of the clientList control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub clientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clientList.SelectedIndexChanged

    End Sub
    ''' <summary>
    ''' Handles the MouseClick event of the clientList control.
    ''' On event triggered means that I selected a new client from the list,
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub clientList_MouseClick(sender As Object, e As MouseEventArgs) Handles clientList.MouseClick
        Dim nowSelectedClient As ClientWrapper = clientList.SelectedItem

        ' Do some safe checks. If null or same wrapper selected.
        If nowSelectedClient Is Nothing Then Exit Sub
        If nowSelectedClient.get_same_as(safeSelectedClientWrapper.value) Then Exit Sub

        Dim tempSelectedClient As ClientWrapper = safeSelectedClientWrapper.value
        safeSelectedClientWrapper.value = nowSelectedClient

        If tempSelectedClient IsNot Nothing Then
            SyncLock tempSelectedClient
                tempSelectedClient.isUIConnected = False
                tempSelectedClient.destroy_every_client()
            End SyncLock
        End If

        nowSelectedClient.isUIConnected = True
        nowSelectedClient.start_every_client_component()

        ' Show data related to the newly selected client.
        linkDataToInformationPanel(nowSelectedClient)

        For Each innerClient As ClientInstance In nowSelectedClient.clientHolder
            If innerClient Is Nothing Then Continue For

            ' Do some default action for each type of client. i.e for a ftp client show the drives. 
            doOnClientInitiation(innerClient)
        Next

        ' Now that a client has been selected hide the client list window.
        hiddenPanel.Visible = False
    End Sub

    ''' <summary>
    ''' Handles the MouseLeave event of the clientList control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub clientList_MouseLeave(sender As Object, e As EventArgs) Handles clientList.MouseLeave
        hiddenPanel.Visible = False
    End Sub

#End Region



#Region "RegionMarker_ShellActionHandlers"

    ''' <summary>
    ''' Handles the KeyPress event of the cmd control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
    Private Sub cmd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmd.KeyPress
        Dim sPacket As com_packet

        If e.KeyChar = ChrW(Keys.Enter) Then
            If cmdPromptText = "cls" Then
                cmd.Text = ""
                cmdPromptText = ""
                Exit Sub
            End If

            '''' Do some conversion from object to array type
            Dim shellBuffer(512) As Char
            Dim shellBufferB() As Byte

            '''' Transforming the string array to a normal byte array
            cmdPromptText.ToCharArray.CopyTo(shellBuffer, 0)

            shellBuffer(cmdPromptText.Length) = Chr(10)

            shellBufferB = System.Text.Encoding.ASCII.GetBytes(shellBuffer)

            '''' Add this command to history only if it isn't empty
            If Not cmdPromptText.Replace(" ", "").Equals("") Then cmdHistoryList.Items.Add("   " + cmdPromptText)

            cmdPromptText = ""

            If shellBuffer(0) = "0" Then
                '''' Code for sending commands to all 

                shellBufferB = System.Text.Encoding.ASCII.GetBytes(shellBuffer, 1, shellBuffer.Count - 1)
                SyncLock listbindingsource
                    For Each wrapper As ClientWrapper In listbindingsource
                        Dim clientShell As ClientInstance = wrapper.get_client_component_by_type(clientTypes.shell)

                        If Not clientShell Is Nothing Then clientShell.send_header(dataTypes.shell, 0, System.Text.Encoding.ASCII.GetString(shellBufferB, 0, shellBufferB.Count), sPacket)
                    Next
                End SyncLock

            Else
                '''' Code for sending commands to the client 
                Dim clientShell As ClientInstance = get_client(clientTypes.shell)

                If Not clientShell Is Nothing Then clientShell.send_header(dataTypes.shell, 0, System.Text.Encoding.ASCII.GetString(shellBufferB, 0, shellBufferB.Count), sPacket)


            End If
        ElseIf e.KeyChar = Chr(24) Then
            '''' Code used to abort a recent command

            cmdPromptText = ""

            '''' Code for sending commands to the client

            Dim clientShell As ClientInstance = get_client(clientTypes.shell)

            If Not clientShell Is Nothing Then clientShell.send_header(dataTypes.abort, 0, sPacket)

        ElseIf e.KeyChar = ChrW(Keys.Back) Then ' backspace

            If cmdPromptText.Length = 0 Or cmd.Text.Length = 0 Then Exit Sub

            cmdPromptText = cmdPromptText.Substring(0, cmdPromptText.Length - 1)
        Else

            cmdPromptText += e.KeyChar

        End If

        cmd.SelectionStart = cmd.Text.Length
        cmd.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Handles the KeyDown event of the cmd control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
    Private Sub cmd_KeyDown(sender As Object, e As KeyEventArgs) Handles cmd.KeyDown
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            If cmdPromptText.Length = 0 Or cmd.Text.Length = 0 Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the shellBtnCancel control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub shellBtnCancel_Click(sender As Object, e As EventArgs) Handles shellBtnCancel.Click
        Dim sPacket As com_packet
        Dim client As ClientInstance = get_client(clientTypes.shell)

        If client Is Nothing Then Exit Sub

        If Not client.send_header(dataTypes.flags_cancel_operation, 0, sPacket) Then Exit Sub
    End Sub

    ''' <summary>
    ''' Handles the SelectedIndexChanged event of the cmdHistoryList control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub cmdHistoryList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmdHistoryList.SelectedIndexChanged

        Dim recomputedTextOffset As Integer = cmd.Text.Length - cmdPromptText.Length

        If recomputedTextOffset > 0 Then
            cmd.Text = cmd.Text.Remove(cmd.Text.Length - cmdPromptText.Length, cmdPromptText.Length)
        End If

        cmdPromptText = cmdHistoryList.SelectedItem.ToString().Remove(0, 3)

        cmd.Text += cmdPromptText
    End Sub

#End Region



#Region "RegionMarker_FtpButtonHandlers"

    ''' <summary>
    ''' Handles the KeyDown event of the ftpUrl control. Especially the Enter key
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
    Private Sub ftpUrl_KeyDown(sender As Object, e As KeyEventArgs) Handles ftpUrl.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' On enter then navigate to url
            Dim urlAtThisMoment As String = ftpUrl.Text

            ftpActionNormalizeDirectoryPath(urlAtThisMoment)

            ftpUrl.Text = urlAtThisMoment

            ftpActionNavigateTo(urlAtThisMoment)

            e.SuppressKeyPress = True
        End If
    End Sub

    ''' <summary>
    ''' Handles the MouseDoubleClick event of the ftpView control.
    ''' Clicked on a file/folder.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub ftpView_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ftpView.MouseDoubleClick
        Dim lvi As ListViewItem = ftpView.HitTest(e.Location).Item

        If lvi Is Nothing Then Exit Sub

        Dim sItem As String = lvi.SubItems(0).Text

        If lvi.Tag = File Then
            '''' If I pressed a button representing a file then I have to do some processing first

        Else
            '''' If I pressed a folder item then get the list of subitems 

            If ftpUrl.Text(0) = Home Then
                ftpUrl.Text = sItem
            Else
                sItem &= Home
                ftpUrl.Text = ftpUrl.Text & sItem
            End If

            '''' Send the command to the client
            ftpActionNavigateTo(ftpUrl.Text)

        End If
    End Sub

    ''' <summary>
    ''' Handles the DragEnter event of the ftpView control.
    ''' Can drag and drop files only.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
    Private Sub ftpView_DragEnter(sender As Object, e As DragEventArgs) Handles ftpView.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ''' <summary>
    ''' Handles the DragDrop event of the ftpView control.
    ''' Can drag and drop files only.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
    Private Sub ftpView_DragDrop(sender As Object, e As DragEventArgs) Handles ftpView.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            Dim baseUrl As String = ftpActionGetNormalizedUrl()
            Dim argumentList As New List(Of String)

            For Each droppedFilePath As String In filePaths
                Dim isDirectory As Boolean = (IO.File.GetAttributes(droppedFilePath) And FileAttributes.Directory) = FileAttributes.Directory

                If isDirectory Then

                Else
                    argumentList.Add(droppedFilePath)
                    argumentList.Add(baseUrl + IO.Path.GetFileName(droppedFilePath))
                End If
            Next

            ' Start a new transaction request to upload.
            ftpActionUploadFilesTransaction(argumentList)
        End If
    End Sub

    ''' <summary>
    ''' Handles the MouseUp event of the ftpView control.
    ''' Show context menu
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub ftpView_MouseUp(sender As Object, e As MouseEventArgs) Handles ftpView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim lvi As ListViewItem = ftpView.HitTest(e.Location).Item

            If lvi Is Nothing Then
                ftpMenuEmptyClick.Show(ftpView, e.Location)
            Else
                ftpMenu.Show(ftpView, e.Location)
            End If
        End If
    End Sub

    ''' <summary>
    ''' FTPs the BTN back click.
    ''' </summary>
    ''' <param name="sender">The sender.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnBackClick(sender As Object, e As EventArgs) Handles ftpBtnBack.Click
        If ftpUrl.Text.Length = 0 Then ftpUrl.Text = Home

        If ftpUrl.Text(0) = Home Then
            Exit Sub
        End If

        Dim cpyUrl As String = ftpUrl.Text.Substring(0, ftpUrl.Text.Length - 1) ' remove the last backslash
        Dim lastBckSlsh As Integer = cpyUrl.LastIndexOf("\")

        cpyUrl = cpyUrl.Substring(0, lastBckSlsh + 1)

        If cpyUrl = "" Then
            cpyUrl = Home
        End If

        ftpUrl.Text = cpyUrl

        ftpActionNavigateTo(ftpUrl.Text)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ftpBtnSearch control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnSearch_Click(sender As Object, e As EventArgs)
        ftpActionNavigateTo(ftpUrl.Text)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ftpBtnDownloadFile control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnDownloadFile_Click(sender As Object, e As EventArgs) Handles ftpBtnDownloadFile.Click
        ftpActionDownloadProcess(False)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ftpBtnDelete control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnDelete_Click(sender As Object, e As EventArgs) Handles ftpBtnDelete.Click
        ftpActionCreateTransaction(dataTypes.delete_folder)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ftpBtnRename control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnRename_Click(sender As Object, e As EventArgs) Handles ftpBtnRename.Click
        ftpActionCreateTransaction(dataTypes.rename)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ftpBtnNewFolder control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnNewFolder_Click(sender As Object, e As EventArgs) Handles ftpBtnNewFolder.Click
        ftpActionCreateTransaction(dataTypes.create_folder)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ftpBtnNewFile control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnNewFile_Click(sender As Object, e As EventArgs) Handles ftpBtnNewFile.Click
        ftpActionCreateTransaction(dataTypes.create_file)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ftpBtnRefresh control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnRefresh_Click(sender As Object, e As EventArgs) Handles ftpBtnRefresh.Click
        ftpActionNavigateTo(ftpUrl.Text)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ftpBtnUpload control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ftpBtnUpload_Click(sender As Object, e As EventArgs) Handles ftpBtnUpload.Click

        Dim result As DialogResult = openFileDialog.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Dim basePath As String = ftpActionGetNormalizedUrl()

            If basePath(0) = Home Then Exit Sub

            Dim argumentList As New List(Of String)

            For Each selectedFileToUpload As String In openFileDialog.FileNames
                argumentList.Add(selectedFileToUpload)
                argumentList.Add(basePath + IO.Path.GetFileName(selectedFileToUpload))
            Next

            ftpActionUploadFilesTransaction(argumentList)

        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnShortcutDesktop control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnShortcutDesktop_Click(sender As Object, e As EventArgs) Handles btnShortcutDesktop.Click
        ftpActionHandleShortcutRedirection("Desktop")
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnShortcutAppData control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnShortcutAppData_Click(sender As Object, e As EventArgs) Handles btnShortcutAppData.Click
        ftpActionHandleShortcutRedirection("AppData")
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnShortcutStartup control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnShortcutStartup_Click(sender As Object, e As EventArgs) Handles btnShortcutStartup.Click
        ftpActionHandleShortcutRedirection("Startup")
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnShortcutStartupAll control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnShortcutStartupAll_Click(sender As Object, e As EventArgs) Handles btnShortcutStartupAll.Click
        ftpActionHandleShortcutRedirection("StartupAll")
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnShortcutTemp control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnShortcutTemp_Click(sender As Object, e As EventArgs) Handles btnShortcutTemp.Click
        ftpActionHandleShortcutRedirection("Temp")
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnShortcutWindows control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnShortcutWindows_Click(sender As Object, e As EventArgs) Handles btnShortcutWindows.Click
        ftpActionHandleShortcutRedirection("Windows")
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnShortcutHome control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnShortcutHome_Click(sender As Object, e As EventArgs) Handles btnShortcutHome.Click
        ftpActionHandleShortcutRedirection(Home)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnShortcutRecycleBin control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnShortcutRecycleBin_Click(sender As Object, e As EventArgs) Handles btnShortcutRecycleBin.Click
        ftpActionHandleShortcutRedirection("Recycle")
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnFtpRunAs control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnFtpRunAs_Click(sender As Object, e As EventArgs) Handles btnFtpRunAs.Click
        Dim basePath As String = ftpActionGetNormalizedUrl()

        For Each lvItem As ListViewItem In ftpView.SelectedItems
            If lvItem.Tag = File Then

                Dim thisFilePath As String = basePath + lvItem.Text

                ftpActionRunProgram(thisFilePath, True)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnFtpRun control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnFtpRun_Click(sender As Object, e As EventArgs) Handles btnFtpRun.Click
        Dim basePath As String = ftpActionGetNormalizedUrl()

        For Each lvItem As ListViewItem In ftpView.SelectedItems
            If lvItem.Tag = File Then

                Dim thisFilePath As String = basePath + lvItem.Text

                ftpActionRunProgram(thisFilePath)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnFtpOpen control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnFtpOpen_Click(sender As Object, e As EventArgs) Handles btnFtpOpen.Click
        ftpActionDownloadProcess(True)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnFtpDownloadInterrupt control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnFtpDownloadInterrupt_Click(sender As Object, e As EventArgs) Handles btnFtpDownloadInterrupt.Click

        Dim client As ClientInstance = get_client(clientTypes.download_manager)

        If client Is Nothing Then Exit Sub

        client.destroy()

    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnFtpUploadInterrupt control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnFtpUploadInterrupt_Click(sender As Object, e As EventArgs) Handles btnFtpUploadInterrupt.Click

        Dim client As ClientInstance = get_client(clientTypes.upload_manager)

        If client Is Nothing Then Exit Sub

        client.destroy()

    End Sub

#End Region



#Region "RegionMarker_FtpActionHandlers"
    ''' <summary>
    ''' FTPs the action download process.
    ''' </summary>
    ''' <param name="downloadToOpenLocallyAfterwards">if set to <c>true</c> [download to open locally afterwards].</param>
    Private Sub ftpActionDownloadProcess(ByVal downloadToOpenLocallyAfterwards As Boolean)

        Dim client As ClientInstance = get_client(clientTypes.download_manager)

        If client Is Nothing Then Exit Sub

        Dim basePath As String = ftpActionGetNormalizedUrl()

        Dim sPacket As com_packet

        For Each lvItem As ListViewItem In ftpView.SelectedItems

            If lvItem.Tag = File Then
                Dim thisFilePath As String = basePath + lvItem.Text
                Dim paramArguments As String = createPacketParam("wantedFile", thisFilePath)

                If downloadToOpenLocallyAfterwards Then
                    If thisFilePath.Contains(".exe") Or thisFilePath.Contains(".lnk") Then
                        '''' I certainly don't want to open this file
                        Continue For
                    End If

                    '''' Create an argument which will tell me at receival if I want to open it or not
                    paramArguments += createPacketParam("openFile", "true")
                End If

                paramArguments += createPacketParam("baseFolder", basePath)
                paramArguments += createPacketParam("buildDirs", "false")

                If Not client.send_header(dataTypes.download_file, 0, paramArguments, sPacket) Then Exit Sub
            ElseIf lvItem.Tag = Folder And Not downloadToOpenLocallyAfterwards Then
                Dim thisFilePath As String = basePath + lvItem.Text

                '''' Append and make sure that the path follows the convention
                ftpActionNormalizeDirectoryPath(thisFilePath)

                Dim paramArguments As String = createPacketParam("wantedFile", thisFilePath)

                paramArguments += createPacketParam("baseFolder", basePath)
                paramArguments += createPacketParam("buildDirs", "true")

                If Not client.send_header(dataTypes.download_folder, 0, paramArguments, sPacket) Then Exit Sub
            End If

        Next

    End Sub

    ''' <summary>
    ''' Create FTP transaction by type. i.e create folder etc.
    ''' </summary>
    ''' <param name="createDataTypeVal">The create data type value.</param>
    Private Sub ftpActionCreateTransaction(ByVal createDataTypeVal As Integer)
        '''' Here I send specially craftfed command to the client

        Dim client As ClientInstance = get_client(clientTypes.ftp)

        If client Is Nothing Then Exit Sub

        Dim basePath As String = ftpActionGetNormalizedUrl()

        Dim sPacket As com_packet

        Select Case createDataTypeVal
            Case dataTypes.create_folder, dataTypes.create_file

                '''' Methods used here only to create a file or a folder

                Dim newName As String = InputBox("Create folder ", "New", "default")

                If newName = "default" Or newName = "" Then Exit Sub

                Dim paramArguments As String = createPacketParam("wantedFile", basePath + newName)

                If Not client.send_header(createDataTypeVal, 0, paramArguments, sPacket) Then Exit Sub

                Dim smallIconIndex As Integer = 1

                If createDataTypeVal = dataTypes.create_folder Then smallIconIndex = 0

                '''' Create a new folder entry in the ftp control view
                Dim newItem As ListViewItem = New ListViewItem(newName, smallIconIndex)

                newItem.SubItems.Add("0 b")
                newItem.SubItems.Add("00/00/0000")
                newItem.Tag = File

                If createDataTypeVal = dataTypes.create_folder Then newItem.Tag = Folder

                ftpView.Items.Add(newItem)
            Case dataTypes.rename

                For Each lvItem As ListViewItem In ftpView.SelectedItems
                    Dim thisFilePath As String = basePath + lvItem.Text
                    Dim paramArguments As String = createPacketParam("wantedFile", thisFilePath)
                    Dim newName As String = InputBox("Insert new name for '" + lvItem.Text + "'", "Rename", lvItem.Text)

                    If newName = lvItem.Text Or newName = "" Then Continue For

                    paramArguments += createPacketParam("newName", basePath + newName)

                    lvItem.Text = newName

                    If Not client.send_header(dataTypes.rename, 0, paramArguments, sPacket) Then Exit Sub
                Next

            Case dataTypes.delete_folder, dataTypes.delete_file
                For Each lvItem As ListViewItem In ftpView.SelectedItems
                    If lvItem.Tag = File Then
                        Dim thisFilePath As String = basePath + lvItem.Text
                        Dim paramArguments As String = createPacketParam("wantedFile", thisFilePath)

                        If Not client.send_header(dataTypes.delete_file, 0, paramArguments, sPacket) Then Exit Sub
                    ElseIf lvItem.Tag = Folder Then
                        Dim thisFilePath As String = basePath + lvItem.Text

                        ftpActionNormalizeDirectoryPath(thisFilePath)

                        Dim paramArguments As String = createPacketParam("wantedFile", thisFilePath)

                        If Not client.send_header(dataTypes.delete_folder, 0, paramArguments, sPacket) Then Exit Sub
                    End If

                    ftpView.Items.Remove(lvItem)
                Next
        End Select

    End Sub

    ''' <summary>
    ''' Ftp view navigate to url.
    ''' </summary>
    ''' <param name="newUrl">The new URL.</param>
    Private Sub ftpActionNavigateTo(ByVal newUrl As String)
        Dim sPacket As com_packet

        If newUrl = "" Then newUrl = Home

        '''' Clear the window ftp of it's actual content
        ftpView.Items.Clear()


        Dim client As ClientInstance = get_client(clientTypes.ftp)

        If client Is Nothing Then Exit Sub

        Dim wantedDataType As Integer = dataTypes.enum_folders_and_files

        If newUrl(0) = Home Then wantedDataType = dataTypes.enum_drives

        client.send_header(wantedDataType, 0, newUrl, sPacket)

    End Sub

    ''' <summary>
    ''' Ftp run program.
    ''' </summary>
    ''' <param name="appPath">The application path.</param>
    ''' <param name="invokeAdmin">if set to <c>true</c> [invoke admin].</param>
    Private Sub ftpActionRunProgram(ByVal appPath As String, Optional invokeAdmin As Boolean = False)

        Dim sPacket As com_packet
        Dim client As ClientInstance = get_client(clientTypes.ftp)

        If client Is Nothing Then Exit Sub

        Dim paramArguments As String = createPacketParam("wantedFile", appPath)

        If invokeAdmin Then paramArguments += createPacketParam("invokeAdmin", "true")

        If Not client.send_header(dataTypes.run, 0, paramArguments, sPacket) Then Exit Sub

    End Sub

    ''' <summary>
    ''' FTPs action upload files transaction.
    ''' </summary>
    ''' <param name="arguments">The arguments.</param>
    Private Sub ftpActionUploadFilesTransaction(ByVal arguments As List(Of String))
        '''' Note that the array must have the following form: first is the PathOnMyPc and the
        '''' next one must be the PathOnTheClientsPc.

        If Not uploadBackgroundWorker.IsBusy() Then

            '''' This means that there is no upload process 
            '''' going on at the moment. Therfore I can
            '''' start a new such process.
            uploadBackgroundWorker.RunWorkerAsync(arguments)
        Else
            '''' This means that there is already a upload process
            '''' going on. Therefore I cannot upload anything at the
            '''' momment.

            debugMessage("An upload transaction is already on course!", informationcode.error)
        End If

    End Sub

#Region "__upload_background_worker_event_handlers"

    ''' <summary>
    ''' Handles the DoWork event of the uploadBackgroundWorker control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
    Private Sub uploadBackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles uploadBackgroundWorker.DoWork

        '''' Convert the object back into an array
        Dim argumentList As List(Of String) = CType(e.Argument, List(Of String))

        '''' Get the instance of the background worker that raised this event
        Dim lpBackgroundWorker As BackgroundWorker = CType(sender, BackgroundWorker)

        '''' Get the ftp client from the wrapper
        Dim client As ClientInstance = get_client(clientTypes.upload_manager)


        '''' Check to see if there is an active client selected
        If Not client Is Nothing Then
            '''' Declare a struct used to send header data to clients
            Dim sPacket As com_packet

            For argumentItterator = 0 To argumentList.Count() - 1 Step 2

                '''' Get the parameters passed by an object argument
                Dim pathOnMyMachine As String = argumentList(argumentItterator)
                Dim pathOnClientMachine As String = argumentList(argumentItterator + 1)

                '''' Get the filename from the pah string
                Dim FileName As String = Path.GetFileName(pathOnMyMachine)

                '''' Create an argument to be sent to the client
                Dim paramArguments As String = createPacketParam("pathOnClientMachine", pathOnClientMachine)
                StripUnicodeCharactersFromString(paramArguments)

                Try
                    Using reader As FileStream = New FileStream(pathOnMyMachine, FileMode.Open)
                        Dim thunkWindowSize As Long = 65536
                        Dim buffer(thunkWindowSize) As Byte
                        Dim fileLength As Long = reader.Length


                        '''' Maybe there was an error sending a small header packet. Chucks !
                        If Not client.send_header(dataTypes.upload_file, fileLength, paramArguments, sPacket) Then Exit Sub


                        '''' Updating the progress bar status
                        doThreadSafeObjectLinkedAction(ftpUploadProgressBar, Function()
                                                                                 ftpUploadProgressBar.Minimum = 0
                                                                                 ftpUploadProgressBar.Maximum = fileLength
                                                                                 ftpUploadProgressBar.Value = 0

                                                                                 Return True
                                                                             End Function)

                        '''' Update the label with the name of the file uploading
                        '''' Note that this label will be reset in the other event.
                        doThreadSafeObjectLinkedAction(lblUploadName, Function()
                                                                          lblUploadName.Text = pathOnMyMachine
                                                                          Return True
                                                                      End Function)



                        '''' Send this entire file in a fragmented manner.
                        While fileLength > 0

                            '''' Check for a cancelation signal from the BackgroundWorker instance
                            If lpBackgroundWorker.CancellationPending() Then
                                e.Cancel = True

                                '''' Induce a self destroy sequence and that is because at this moment the calient awaits for 
                                '''' a number of bytes to be received which I will no longer deliver which leads to packet shift.
                                client.destroy()

                                '''' Exit from the for forcefully
                                Exit For
                            End If

                            '''' Decide how big the chunk size should be .
                            Dim mThunkChoice As Long = Math.Min(thunkWindowSize, fileLength)

                            '''' Read the chunk into the file.
                            reader.Read(buffer, 0, mThunkChoice)


                            '''' Send the chunk to the client.
                            If Not client.send(buffer, mThunkChoice) Then Exit While

                            '''' Update the ftpDownloadProgressBar accoridingly.
                            doThreadSafeObjectLinkedAction(ftpDownloadProgressBar, Function()
                                                                                       ftpUploadProgressBar.Value += mThunkChoice
                                                                                       Return True
                                                                                   End Function)
                            '''' Upldate wanted byte count.
                            fileLength -= mThunkChoice
                        End While

                    End Using
                Catch ex As Exception

                    '''' That means that the desired file is not accesible.
                    debugMessage("Cannot open file '" + pathOnMyMachine + "' for uploading!", informationcode.error)
                End Try
            Next
        Else
            '''' Tell the background worker that
            '''' there has been an error. This 
            '''' cancelation token will be passed to
            '''' the uploadBackgroundWorker_RunWorkerCompleted.
            e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' Handles the RunWorkerCompleted event of the uploadBackgroundWorker control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
    Private Sub uploadBackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles uploadBackgroundWorker.RunWorkerCompleted

        If Not e.Error Is Nothing Then

            '''' Then  to process raised an exception.
        ElseIf e.Cancelled = True Then

            '''' Then the upload has been canceled forcefully.
            debugMessage("Upload transaction has been cancelled!", informationcode.warning)

        Else
            '''' Then the upload finished succesfully.

            debugMessage("Upload finished succesfully!", informationcode.normal)
        End If

        '''' Reset the progress bar's level
        doThreadSafeObjectLinkedAction(ftpDownloadProgressBar, Function()
                                                                   ftpUploadProgressBar.Value = 0
                                                                   Return True
                                                               End Function)

        '''' Reset the label with the name of the file uploading
        doThreadSafeObjectLinkedAction(lblUploadName, Function()
                                                          lblUploadName.Text = ""
                                                          Return True
                                                      End Function)
    End Sub

#End Region

    ''' <summary>
    ''' Handle shortcut redirection i.e clicked on the Desktop shortcut etc..
    ''' </summary>
    ''' <param name="destinationUrl">The destination URL.</param>
    Private Sub ftpActionHandleShortcutRedirection(ByVal destinationUrl As String)

        Dim client As ClientInstance = get_client(clientTypes.ftp)

        If client Is Nothing Then Exit Sub

        Dim expandedPath As String = ""

        Select Case destinationUrl
            Case "Desktop"
                expandedPath = "C:\Users\" + client.get_user_descriptor().user_name + "\Desktop\"
            Case "AppData"
                expandedPath = "C:\Users\" + client.get_user_descriptor().user_name + "\AppData\"
            Case "Temp"
                expandedPath = "C:\Users\" + client.get_user_descriptor().user_name + "\AppData\Local\Temp\"
            Case "Windows"
                expandedPath = "C:\Windows\"
            Case "Startup"
                expandedPath = "C:\Users\" + client.get_user_descriptor().user_name + "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\"
            Case "StartupAll"
                expandedPath = "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\"
            Case "Recycle"

            Case Home
                expandedPath = Home
        End Select

        '''' If there wasn't found a match in the list
        If expandedPath = "" Then Exit Sub

        '''' Before actually navigating to that path we must first change the path in the url
        doThreadSafeObjectLinkedAction(ftpUrl, Function()
                                                   ftpUrl.Text = expandedPath

                                                   Return True
                                               End Function)

        '''' Navigate to this path
        ftpActionNavigateTo(expandedPath)


    End Sub

    ''' <summary>
    ''' Normalize a string directory path. Always en in '\'
    ''' </summary>
    ''' <param name="desiredPath">The desired path.</param>
    Private Sub ftpActionNormalizeDirectoryPath(ByRef desiredPath As String)
        Dim index As Long = 0

        For index = desiredPath.Count - 1 To 0 Step -1
            If Not (desiredPath(index) = " " Or desiredPath(index) = "\") Then Exit For
        Next

        desiredPath = desiredPath.Substring(0, index + 1)

        desiredPath += "\"
    End Sub

    ''' <summary>
    ''' Get a always ending in '\' path and update the url text ui component.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Private Function ftpActionGetNormalizedUrl() As String
        Dim theUrl As String = ""

        doThreadSafeObjectLinkedAction(ftpUrl, Function()
                                                   theUrl = ftpUrl.Text
                                                   Return True
                                               End Function)

        ftpActionNormalizeDirectoryPath(theUrl)

        Return theUrl
    End Function

#End Region



#Region "RegionMarker_RegeditFunctions"

    ''' <summary>
    ''' Initialize the regedit tree view component.
    ''' </summary>
    Private Sub regedit_initialize()
        doThreadSafeObjectLinkedAction(regKeyHolder, Function()
                                                         regKeyHolder.Nodes.Clear()

                                                         regKeyHolder.AddTreeNode("HKEY_CLASSES_ROOT")   ' 0
                                                         regKeyHolder.AddTreeNode("HKEY_CURRENT_USER")   ' 1
                                                         regKeyHolder.AddTreeNode("HKEY_LOCAL_MACHINE")  ' 2
                                                         regKeyHolder.AddTreeNode("HKEY_USERS")          ' 3
                                                         regKeyHolder.AddTreeNode("HKEY_CURRENT_CONFIG") ' 4

                                                         Return True
                                                     End Function)
    End Sub

    ''' <summary>
    ''' Get a packet parameter that holds details with regard to the path in regedit i.e keypath\value    ''' </summary>
    ''' <param name="data">The data.</param>
    ''' <returns>System.String.</returns>
    Private Function regedit_get_keypath_argument(ByVal data As String) As String
        '''' Split the data in root key and the rest of the path 
        Dim splitArray() As String = Split(data, "\", 2)

        Dim regrtkey As String
        Dim regpth As String

        If splitArray.Length = 1 Then
            regrtkey = data
            regpth = ""
        Else
            regrtkey = splitArray(0)
            regpth = splitArray(1)
        End If

        Select Case regrtkey
            Case "HKEY_CLASSES_ROOT"
                regrtkey = 0
            Case "HKEY_CURRENT_USER"
                regrtkey = 1
            Case "HKEY_LOCAL_MACHINE"
                regrtkey = 2
            Case "HKEY_USERS"
                regrtkey = 3
            Case "HKEY_CURRENT_CONFIG"
                regrtkey = 4
        End Select

        data = createPacketParam("regpth", regpth)
        data = createPacketParam("regrtkey", regrtkey) + data

        Return data
    End Function

    ''' <summary>
    ''' Retrieve info with regard to the selected node from client. Mark node as visited i.e cache the node.
    ''' </summary>
    ''' <param name="e">The e.</param>
    Private Sub regedit_key_hit_test_node(ByVal e As TreeNode)
        Dim sPacket As com_packet

        Dim client As ClientInstance = get_client(clientTypes.regedit)

        If client Is Nothing Then Exit Sub

        '''' Get the node's full path
        Dim data As String = regedit_get_keypath_argument(e.regedit_get_full_path())

        If Not (e.IsExpanded Or e.Tag = "visited") Then
            '''' Send the command to the client
            If Not client.send_header(dataTypes.enum_keys, 0, data, sPacket) Then Exit Sub

            '''' Set this node as selected
            e.Tag = "visited"
        End If

        '''' Remove all items from the view
        regValueHolder.Items.Clear()

        '''' No matter the conditions I will always query the values
        If Not client.send_header(dataTypes.enum_values, 0, data, sPacket) Then Exit Sub

    End Sub

    ''' <summary>
    ''' Get regedit stringed version of value type.
    ''' </summary>
    ''' <param name="type">The type.</param>
    ''' <returns>System.String.</returns>
    Private Function regedit_get_type_string(ByVal type As Integer) As String
        Dim str_type As String = "REG_SZ"

        Select Case type
            Case 1
                str_type = "REG_SZ"
            Case 3
                str_type = "REG_BINARY"
            Case 4
                str_type = "REG_DWORD"
            Case 11
                str_type = "REG_QWORD"
            Case 7
                str_type = "REG_MULTI_SZ"
            Case 2
                str_type = "REG_EXPAND_SZ"
        End Select

        Return str_type
    End Function

    ''' <summary>
    ''' Create action transaction for regedit i.e create key etc..
    ''' </summary>
    ''' <param name="datatype">The datatype.</param>
    Private Sub regeditActionCreateTransaction(ByVal datatype As Integer)
        '''' Get a instance to a client
        Dim client As ClientInstance = get_client(clientTypes.regedit)

        '''' Check for client validity
        If client Is Nothing Then Exit Sub

        '''' Get a instance to the selected node
        Dim selectedNode As TreeNode = regKeyHolder.SelectedNode

        '''' Check for node existence
        If selectedNode Is Nothing Then Exit Sub

        '''' Declare a new packet used in tcp.
        Dim sPacket As com_packet

        Select Case datatype
            Case dataTypes.rename_key
                Dim paramArguments As String = regedit_get_keypath_argument(selectedNode.regedit_get_full_path())

                Dim currentNodeName As String = selectedNode.Text

                Dim newName As String = InputBox("Insert new name for '" + currentNodeName + "'", "Rename", currentNodeName)

                If newName = currentNodeName Or newName = "" Then Exit Select

                selectedNode.Name = selectedNode.Parent.regedit_get_full_path() + "\" + newName

                paramArguments += createPacketParam("newName", newName)

                selectedNode.Text = newName

                If Not client.send_header(dataTypes.rename, 0, paramArguments, sPacket) Then Exit Sub

            Case dataTypes.delete_key

                regKeyHolder.Nodes.Remove(selectedNode)

                Dim strarg As String = regedit_get_keypath_argument(selectedNode.regedit_get_full_path())

                If Not client.send_header(dataTypes.delete_key, 0, strarg, sPacket) Then Exit Sub

            Case dataTypes.create_key

                Dim paramArguments As String = regedit_get_keypath_argument(selectedNode.regedit_get_full_path())

                Dim newName As String = InputBox("Insert name for new node ", "New", "")

                If newName = "" Then Exit Select

                Dim newNodeEntry As New TreeNode

                newNodeEntry.Name = selectedNode.Name + "\" + newName

                newNodeEntry.Text = newName

                selectedNode.Nodes.Add(newNodeEntry)

                newNodeEntry.Expand()

                paramArguments += createPacketParam("newName", newName)

                If Not client.send_header(dataTypes.create_key, 0, paramArguments, sPacket) Then Exit Sub

            Case dataTypes.create_value

                '''' Create a handle to the dialog window request
                Dim dialogResult As DialogResult = WindowRegNewValue.ShowDialog()

                If dialogResult = DialogResult.OK Then

                    Dim vname As String = WindowRegNewValue.get_reg_value_name()
                    Dim vtype As String = WindowRegNewValue.get_reg_type()
                    Dim vdata As String = WindowRegNewValue.get_reg_value_data()

                    If vname = "" Then Exit Select

                    '''' Add the new entry to the listview
                    Dim newEntryList As New ListViewItem(vname, 2)
                    newEntryList.SubItems.Add(regedit_get_type_string(vtype))
                    newEntryList.SubItems.Add(vdata)
                    regValueHolder.Items.Add(newEntryList)


                    '''' Prepare the arguments
                    Dim paramArguments As String = regedit_get_keypath_argument(selectedNode.regedit_get_full_path())
                    paramArguments += createPacketParam("name", vname)
                    paramArguments += createPacketParam("type", vtype)
                    paramArguments += createPacketParam("data", vdata) '''' TODO: send the vdata as data, not as parameter.

                    If Not client.send_header(dataTypes.create_value, 0, paramArguments, sPacket) Then Exit Sub
                End If

        End Select
    End Sub



    ''' <summary>
    ''' Handles the NodeMouseClick event of the regKeyHolder control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
    Private Sub regKeyHolder_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles regKeyHolder.NodeMouseClick
        regedit_key_hit_test_node(e.Node)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the regBtnKeyRefresh control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub regBtnKeyRefresh_Click(sender As Object, e As EventArgs) Handles regBtnKeyRefresh.Click
        regKeyHolder.SelectedNode.Nodes.Clear()

        regedit_key_hit_test_node(regKeyHolder.SelectedNode)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the regBtnKeyRename control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub regBtnKeyRename_Click(sender As Object, e As EventArgs)
        regeditActionCreateTransaction(dataTypes.rename_key)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the regBtnKeyDelete control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub regBtnKeyDelete_Click(sender As Object, e As EventArgs) Handles regBtnKeyDelete.Click
        regeditActionCreateTransaction(dataTypes.delete_key)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the regBtnKeyNewSubkey control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub regBtnKeyNewSubkey_Click(sender As Object, e As EventArgs) Handles regBtnKeyNewSubkey.Click
        regeditActionCreateTransaction(dataTypes.create_key)
    End Sub


    ''' <summary>
    ''' Handles the Click event of the regBtnValueRefresh control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub regBtnValueRefresh_Click(sender As Object, e As EventArgs) Handles regBtnValueRefresh.Click

    End Sub

    ''' <summary>
    ''' Handles the Click event of the regBtnValueDelete control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub regBtnValueDelete_Click(sender As Object, e As EventArgs) Handles regBtnValueDelete.Click
        ' 
    End Sub

    ''' <summary>
    ''' Handles the Click event of the regBtnValueNewValue control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub regBtnValueNewValue_Click(sender As Object, e As EventArgs) Handles regBtnValueNewValue.Click
        regeditActionCreateTransaction(dataTypes.create_value)
    End Sub


    ''' <summary>
    ''' Handles the MouseUp event of the regKeyHolder control.
    ''' Show context menu on regedit keys right click
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub regKeyHolder_MouseUp(sender As Object, e As MouseEventArgs) Handles regKeyHolder.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim itemKeyNode As TreeNode = regKeyHolder.HitTest(e.Location).Node

            If Not itemKeyNode Is Nothing Then
                '''' First select the node
                regKeyHolder.SelectedNode = itemKeyNode

                '''' Do operations on the selected node
                regKeyContextMenu.Show(regKeyHolder, e.Location)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Handles the MouseUp event of the regValueHolder control.
    ''' Show context menu on regedit value right click
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub regValueHolder_MouseUp(sender As Object, e As MouseEventArgs) Handles regValueHolder.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim itemValue As ListViewItem = regValueHolder.HitTest(e.Location).Item

            If Not itemValue Is Nothing Then
                '''' If I have selected an item in the list
                regBtnValueRefresh.Visible = False
                regBtnValueDelete.Visible = True
            Else
                '''' If I haven't selected an item in the list
                regBtnValueRefresh.Visible = True
                regBtnValueDelete.Visible = False
            End If

            regValueContextMenu.Show(regValueHolder, e.Location)
        End If

    End Sub

    ''' <summary>
    ''' Handles the MouseDoubleClick event of the regValueHolder control.
    ''' Start editing a double clicked regedit value.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub regValueHolder_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles regValueHolder.MouseDoubleClick

        '''' Get the entry at location
        Dim itemRegValue As ListViewItem = regValueHolder.HitTest(e.Location).Item

        '''' Check for entry validity
        If itemRegValue Is Nothing Then Exit Sub

        '''' Get the name of value entry
        Dim regValueName As String = itemRegValue.SubItems(0).Text

        '''' Get the full path of the value entry
        Dim regValuePath As String = regKeyHolder.SelectedNode.regedit_get_full_path() + "\" + regValueName

        '''' Get the value data
        Dim regValueData As String = itemRegValue.SubItems(2).Text

        '''' Check to see if the entry has been expanded or not
        If regValueData.Contains("(Expand)") Then Exit Sub

        '''' Set appropriate data in the ByteEditor window
        WindowByteViewer.set_reg_value_path(regValuePath)

        WindowByteViewer.set_hex_editor_data(regValueData)

        Try
            '''' Wonder why the Try Catch block ? Answer. Because
            '''' of the idiot who built the hex control.
            '''' He had no ideea what error checking is.

            '''' Create a handle to the dialog window request
            Dim dialogResult As DialogResult = WindowByteViewer.ShowDialog()

            If dialogResult = DialogResult.OK Then
                Dim modifiedRegValueData() As Byte = WindowByteViewer.get_bytes()

                itemRegValue.SubItems(2).Text = System.Text.Encoding.ASCII.GetString(modifiedRegValueData)
            End If
        Catch ex As Exception
            '''' Nothing to do with the exception here.
        End Try


    End Sub

#End Region



#Region "RegionMarker_HandleButtonsInTheLeftSidePanel"

    ''' <summary>
    ''' Handles the Click event of the btnBan control.
    ''' Ban user
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnBan_Click(sender As Object, e As EventArgs) Handles btnBan.Click
        If Not safeSelectedClientWrapper.value Is Nothing Then
            databaseOfUsers.blackListUser(safeSelectedClientWrapper.value.ip)

            safeSelectedClientWrapper.value.destroy_every_client()
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnDestroy control.
    ''' Destroy client
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnDestroy_Click(sender As Object, e As EventArgs) Handles btnDestroy.Click
        If Not safeSelectedClientWrapper.value Is Nothing Then
            Dim temp As ClientWrapper = safeSelectedClientWrapper.value

            temp.isUIConnected = False
            safeSelectedClientWrapper.value = Nothing
            resetInformationPanel()
            temp.destroy_every_client()
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnViewClientLogs control.
    ''' Show client database window.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnViewClientLogs_Click(sender As Object, e As EventArgs) Handles btnViewClientLogs.Click
        If Not WindowViewClientLogs.databaseInited Then
            WindowViewClientLogs.setDatabase(databaseOfUsers)
        End If

        WindowViewClientLogs.Show()
    End Sub


    ''' <summary>
    ''' Handles the Click event of the btnLive control.
    ''' Start the video stream. Create video window and display input feed in it.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnLive_Click(sender As Object, e As EventArgs) Handles btnLive.Click
        Dim client As ClientInstance = get_client(clientTypes.screenCapture)

        Dim sPacket As com_packet

        If client Is Nothing Then Exit Sub
        videoFrm = New WindowVideo
        videoFrm.Show()

        Try
            If videoData IsNot Nothing Then
                videoData.destroy()
            End If

            videoData = initInternalFrame(videoFrm.getCanvasInstance, 1000, 1000)       ' maxWidth and maxHeight parameters are unknwon. Will be set on each frame received
        Catch ex As Exception
            Exit Sub
        End Try

        If Not client.send_header(dataTypes.video_start, 8, sPacket) Then
            videoFrm.Hide()
            Exit Sub
        End If

        Dim frameCount As UInt32 = videoFrm.getFramesCountValue
        Dim rowHeight As UInt32 = videoFrm.getRowHeightValue

        Dim buffer(12) As Byte

        BitConverter.GetBytes(frameCount).CopyTo(buffer, 0)
        BitConverter.GetBytes(rowHeight).CopyTo(buffer, 4)

        If Not client.send(buffer, sPacket) Then
            videoFrm.Hide()
            Exit Sub
        End If

        ' If everything is good with the video start the mouse also
        client = get_client(clientTypes.mouse)
        If client Is Nothing Then Exit Sub

        If Not client.send_header(dataTypes.mouse_start, 0, sPacket) Then
            Exit Sub
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnLocalDir control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnLocalDir_Click(sender As Object, e As EventArgs) Handles btnLocalDir.Click

        Dim client As ClientInstance = get_client(clientTypes.ftp)

        If Not client Is Nothing Then Process.Start(client.workingPath)

    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnUnhideClientsPanel control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnUnhideClientsPanel_Click(sender As Object, e As EventArgs) Handles btnUnhideClientsPanel.Click
        hiddenPanel.Visible = True
    End Sub




    ''' <summary>
    ''' Forces the load of a specific client component on the client's machine.
    ''' </summary>
    ''' <param name="clienttype">The clienttype.</param>
    Private Sub forceLoadActionCreateTransaction(ByVal clienttype As UInt32)
        Dim client As ClientInstance = get_active_client()

        If client Is Nothing Then Exit Sub

        If clienttype = client.get_client_type() Then Exit Sub

        Dim sPacket As com_packet

        If Not client.send_header(dataTypes.load_component, 4, sPacket) Then Exit Sub

        If Not client.send(BitConverter.GetBytes(clienttype), sPacket) Then Exit Sub
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnForceShell control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnForceShell_Click(sender As Object, e As EventArgs) Handles btnForceShell.Click
        forceLoadActionCreateTransaction(clientTypes.shell)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnForceRegedit control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnForceRegedit_Click(sender As Object, e As EventArgs) Handles btnForceRegedit.Click
        forceLoadActionCreateTransaction(clientTypes.regedit)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnForceDownload control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnForceDownload_Click(sender As Object, e As EventArgs) Handles btnForceDownload.Click
        forceLoadActionCreateTransaction(clientTypes.download_manager)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnForceUpload control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnForceUpload_Click(sender As Object, e As EventArgs) Handles btnForceUpload.Click
        forceLoadActionCreateTransaction(clientTypes.upload_manager)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnForceFtp control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnForceFtp_Click(sender As Object, e As EventArgs) Handles btnForceFtp.Click
        forceLoadActionCreateTransaction(clientTypes.ftp)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnForceVideo control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnForceVideo_Click(sender As Object, e As EventArgs) Handles btnForceVideo.Click
        forceLoadActionCreateTransaction(clientTypes.screenCapture)
    End Sub

#End Region



#Region "RegionMarker_UserDescriptorUpdateSpecificMember"

    ''' <summary>
    ''' Sets the name of the structure member by.
    ''' </summary>
    ''' <param name="parentStructure">The parent structure.</param>
    ''' <param name="newFieldValue">The new field value.</param>
    ''' <param name="fieldName">Name of the field.</param>
    Public Sub SetStructureMemberByName(ByVal parentStructure As Object, newFieldValue As Object, ByVal fieldName As String)

        Dim field As FieldInfo = parentStructure.GetType().GetField(fieldName, BindingFlags.Public Or BindingFlags.Instance)

        field.SetValue(parentStructure, newFieldValue)

    End Sub

    ''' <summary>
    ''' Gets the name of the structure member by.
    ''' </summary>
    ''' <param name="parentStructure">The parent structure.</param>
    ''' <param name="fieldName">Name of the field.</param>
    ''' <returns>System.Object.</returns>
    Public Function GetStructureMemberByName(ByVal parentStructure As Object, ByVal fieldName As String) As Object
        Dim field As FieldInfo = parentStructure.GetType().GetField(fieldName, BindingFlags.Public Or BindingFlags.Instance)

        Return field.GetValue(parentStructure)
    End Function

    ''' <summary>
    ''' Prepares the user descriptor control for edit.
    ''' </summary>
    ''' <param name="winControl">The win control.</param>
    ''' <param name="userdescriptorMemberName">Name of the userdescriptor member.</param>
    Private Sub prepareUserDescriptorControlForEdit(ByVal winControl As Control, ByVal userdescriptorMemberName As String)
        Dim marginTop As Integer = 10

        If winControl.Text.Contains(emptystr) Then Exit Sub

        panelEditUserDescriptor.Top = winControl.Top + marginTop
        panelEditUserDescriptor.Left = panelInfoHolder.Left
        panelEditUserDescriptor.Width = panelInfoHolder.Width
        panelEditUserDescriptor.Height = panelInfoHolder.Top + panelInfoHolder.Height - winControl.Top - marginTop

        txtEditUserDescriptor.Text = winControl.Text
        txtEditUserDescriptor.Tag = userdescriptorMemberName

        panelEditUserDescriptor.Visible = True

        txtEditUserDescriptor.Select()

        panelEditUserDescriptor.BringToFront()
    End Sub

    ''' <summary>
    ''' Prepares the user descriptor control for save edit.
    ''' </summary>
    Private Sub prepareUserDescriptorControlForSaveEdit()
        txtEditUserDescriptor.Text = ""
        txtEditUserDescriptor.Tag = ""

        panelEditUserDescriptor.Visible = False
    End Sub

    ''' <summary>
    ''' Handles the Click event of the lcustom control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub lcustom_Click(sender As Object, e As EventArgs) Handles lcustom.Click
        prepareUserDescriptorControlForEdit(lcustom, "custom_name")
    End Sub

    ''' <summary>
    ''' Handles the MouseClick event of the ldesc control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub ldesc_MouseClick(sender As Object, e As MouseEventArgs) Handles ldesc.MouseClick
        prepareUserDescriptorControlForEdit(ldesc, "pc_description")
    End Sub

    ''' <summary>
    ''' Handles the MouseClick event of the lextra control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub lextra_MouseClick(sender As Object, e As MouseEventArgs) Handles lextra.MouseClick
        prepareUserDescriptorControlForEdit(lextra, "extra_data")
    End Sub

    ''' <summary>
    ''' Handles the KeyDown event of the txtEditUserDescriptor control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
    Private Sub txtEditUserDescriptor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEditUserDescriptor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not safeSelectedClientWrapper.value Is Nothing Then
                Dim client As ClientInstance

                SyncLock safeSelectedClientWrapper.value
                    client = safeSelectedClientWrapper.value.get_one_active_client()
                End SyncLock

                If client Is Nothing Then GoTo exit_edit_window

                Dim structInstanceOfUserDescriptor As Object = client.get_user_descriptor()

                Dim previousData As String = GetStructureMemberByName(structInstanceOfUserDescriptor, txtEditUserDescriptor.Tag)

                Dim newValueEdit As String = txtEditUserDescriptor.Text

                If newValueEdit = previousData Or newValueEdit = "" Then GoTo exit_edit_window

                SetStructureMemberByName(structInstanceOfUserDescriptor, newValueEdit, txtEditUserDescriptor.Tag)

                If Not client.authentificate(client.usrdescriptor) Then GoTo exit_edit_window

                Dim wantedControl As Control = lcustom

                Select Case txtEditUserDescriptor.Tag
                    Case "custom_name"
                        wantedControl = lcustom
                    Case "pc_description"
                        wantedControl = ldesc
                    Case "extra_data"
                        wantedControl = lextra
                End Select

                wantedControl.Text = newValueEdit

exit_edit_window:
                prepareUserDescriptorControlForSaveEdit()
            End If

            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Escape Then
            prepareUserDescriptorControlForSaveEdit()
        End If

    End Sub

#End Region



#Region "RegionMarker_DefinitionsOfClientComponentThreads"

    ''' <summary>
    ''' Main thread that listesns for clients and adds them to a waiting list.
    ''' </summary>
    Private Sub threadMainUIListenerFunc()
        '''' Declare the tcplistener
        TcpListener = New TcpListener(IPAddress.Any, 1717)
        TcpListener.Start()

        While True
            Try
                Dim acceptedClient As TcpClient = TcpListener.AcceptTcpClient
                Dim client As New ClientInstance(acceptedClient)

                '''' Set a channel for comunicating errors
                client.set_debugging_slot(AddressOf debugMessageLowLevel)


                client.threadAuthentificate = New Thread(New ParameterizedThreadStart(AddressOf client.threadAuthentificateFunc)) With {
                    .Name = "ThreadAuthenitificate",
                    .IsBackground = True
                }
                client.threadAuthentificate.Start()


                '''' Push the new client in the concurrent queue
                clientPendingAuthentificationConqurentQueue.Enqueue(client)

            Catch ex As Exception
                Exit While
            End Try
        End While
    End Sub


    ''' <summary>
    ''' Consumes the authentification waiting list.
    ''' </summary>
    Private Sub threadMainAuthentificatePostProcessorFunc()
        While True
            Thread.Sleep(200)

            Dim tInstance As ClientInstance = Nothing

            If Not clientPendingAuthentificationConqurentQueue.TryDequeue(tInstance) Then Continue While

            Dim authStatus As Integer

            authStatus = Interlocked.Read(tInstance.authentificated)

            If authStatus = 0 Then      ' ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                clientPendingAuthentificationConqurentQueue.Enqueue(tInstance)
                Continue While
            ElseIf authStatus = 1 Then  ' ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If Not databaseOfUsers.isUserBlacklisted(tInstance.ip) Then
                    '''' Showing a simple notification message about the connection status
                    debugMessage("client " + tInstance.get_to_string() + " got banned -> failed to authentificate! ", informationcode.error)

                    '''' Writing the decision in the database
                    '  databaseOfUsers.blackListUser(tInstance.ip)
                Else
                    '''' Showing a simple notification message about the connection status
                    debugMessage("client " + tInstance.get_to_string() + " is banned but tried to connect!", informationcode.error)

                End If

                Continue While
            Else                        ' ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                '''' Checking to see if this authentificated
                '''' tInstance is in the blacklist table.
                If databaseOfUsers.isUserBlacklisted(tInstance.ip) Then
                    debugMessage("client " + tInstance.get_to_string() + " is in the blacklist!", informationcode.warning)

                    Try
                        tInstance.socket.Close()
                    Catch ex As Exception
                        ' nada
                    End Try

                    Continue While
                End If



                '''' Register a new tInstance in the database.
                If Not databaseOfUsers.isUserRegistered(tInstance.ip) Then databaseOfUsers.registerNewUser(tInstance)

                '''' Show a welcoming message to the user
                debugMessage("client " + tInstance.get_to_string() + " has been accepted!")


                '''' Lock the object for somewhat multithread safety
                doThreadSafeObjectLinkedAction(clientList,
                    Function()
                        Dim clientWrapper As ClientWrapper = Nothing
                        Dim createdNewWrapper As Boolean = False

                        SyncLock listbindingsource
                            For Each componentWrapper As ClientWrapper In listbindingsource.List
                                If componentWrapper.get_system_id().Equals(tInstance.get_system_id()) Then

                                    '''' This means that I have found a wrapper in the list.
                                    clientWrapper = componentWrapper
                                    Exit For
                                End If
                            Next

                            '''' This means that there was
                            '''' no tInstance in the list and 
                            '''' that I have to create one.
                            If clientWrapper Is Nothing Then
                                clientWrapper = New ClientWrapper()
                                clientWrapper.set_wrapper_information(tInstance)
                                clientWrapper.set_on_destroy(AddressOf clientDestroyedCallback)
                                clientWrapper.set_on_empty_wrapper(AddressOf onEmptyWrapperCallback)

                                createdNewWrapper = True
                            End If

                            Select Case tInstance.get_client_type()
                                Case clientTypes.shell
                                    clientWrapper.set_new_client(tInstance, AddressOf threadShellReceiver)
                                Case clientTypes.ftp
                                    clientWrapper.set_new_client(tInstance, AddressOf threadFtpReceiver)
                                Case clientTypes.upload_manager
                                    clientWrapper.set_new_client(tInstance, AddressOf threadUploadMgrReceiver)
                                Case clientTypes.download_manager
                                    clientWrapper.set_new_client(tInstance, AddressOf threadDownloadMgrReceiver)
                                Case clientTypes.regedit
                                    clientWrapper.set_new_client(tInstance, AddressOf threadRegeditMgr)
                                Case clientTypes.screenCapture
                                    clientWrapper.set_new_client(tInstance, AddressOf threadScreenCapture)
                                Case clientTypes.mouse
                                    clientWrapper.set_new_client(tInstance, AddressOf threadMouseHandler)
                            End Select

                            If createdNewWrapper Then listbindingsource.Add(clientWrapper)

                            If safeSelectedClientWrapper.value IsNot Nothing And clientWrapper.get_same_as(safeSelectedClientWrapper.value) Then
                                '''' Start the receiving thread for this tInstance
                                tInstance.start_client_component()

                                If Not clientWrapper.isUIConnected Then Return True


                                '''' Fill the info container
                                linkDataToInformationPanel(clientWrapper)

                                '''' Do some actions at the begginging of tInstance activity
                                doOnClientInitiation(tInstance)
                            End If
                        End SyncLock

                        Return True
                    End Function)

            End If
        End While
    End Sub




    ''' <summary>
    ''' Ftp receiver thread
    ''' </summary>
    ''' <param name="client">The client.</param>
    ''' <param name="rPacket">The r packet.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Function threadFtpReceiver(ByVal client As ClientInstance, ByVal rPacket As com_packet) As Boolean
        Dim operationResult As Boolean = True

        Select Case rPacket.dataType
            Case dataTypes.enum_drives, dataTypes.enum_folders_and_files

                '''' Declare a buffer made especially for win32 data structures
                Dim buffer(szOfWin32FindDataa * 10 + 10) As Byte

                '''' Read only the number of entries from the client now.
                If Not client.receive(buffer, 8) Then Return False

                '''' Convert the stream into a uint64
                Dim noOfEntries As UInt64 = BitConverter.ToUInt64(buffer, 0)

                '''' Now that I have read those 8 bytes I must decrement them from the packet's packetsize
                rPacket.packetSize -= 8


                '''' Disable drawing events for Ftp controll
                doThreadSafeObjectLinkedAction(ftpView, Function()
                                                            ftpView.BeginUpdate()
                                                            Return True
                                                        End Function)

                '''' Trying to receive the entire item collection in a fragmented manner.
                If Not client.receive_fragmented(buffer, rPacket, szOfWin32FindDataa,
                       Function(ByVal lrecvBytes As UInt64)
                           Dim win32DataStruct As WIN32_FIND_DATAA = convertStreamToWin32FindData(buffer, 0)
                           Dim fileSizeBytes As UInt64 = 0
                           Dim smallIconIndex As Integer = 1

                           If win32DataStruct.dwFileAttributes And 16 Then smallIconIndex = 0

                           Dim newItem As ListViewItem = New ListViewItem(win32DataStruct.cFileName, smallIconIndex)

                           fileSizeBytes = win32DataStruct.nFileSizeHigh << 32 Or win32DataStruct.nFileSizeLow
                           newItem.SubItems.Add(FormatFileSize(fileSizeBytes))
                           newItem.SubItems.Add(FileTimeToString(win32DataStruct.ftLastWriteTime))

                           If win32DataStruct.dwFileAttributes And 16 Then
                               newItem.Tag = Folder
                           Else
                               newItem.Tag = File
                           End If


                           doThreadSafeObjectLinkedAction(ftpView, Function()
                                                                       ftpView.Items.Add(newItem)
                                                                       Return True
                                                                   End Function)

                           Return True
                       End Function) Then operationResult = False

                '''' Re-enable drawing events for Ftp controll
                doThreadSafeObjectLinkedAction(ftpView, Function()
                                                            ftpView.EndUpdate()
                                                            Return True
                                                        End Function)
        End Select

        Return operationResult
    End Function

    ''' <summary>
    ''' Shell thread.
    ''' </summary>
    ''' <param name="client">The client.</param>
    ''' <param name="rPacket">The r packet.</param>
    ''' <returns></returns>
    Public Function threadShellReceiver(ByVal client As ClientInstance, ByVal rPacket As com_packet) As Boolean
        '''' This client is expected to always give me only the shell datatype.
        If Not rPacket.dataType = dataTypes.shell Then

            debugMessage("Expected shell transmission but received otherwise !", informationcode.error)
            Return False
        End If

        Dim buffer(65535) As Byte


        If Not client.receive_fragmented(buffer, rPacket, buffer.Length, Function(ByVal lrecvBytes As UInt64)

                                                                             cmd.Invoke(Sub() cmd.AppendText(System.Text.Encoding.ASCII.GetString(buffer)))

                                                                             Return True
                                                                         End Function) Then Return False
        Return True
    End Function

    ''' <summary>
    ''' Upload manager thread.
    ''' </summary>
    ''' <param name="client">The client.</param>
    ''' <param name="rPacket">The r packet.</param>
    ''' <returns></returns>
    Public Function threadUploadMgrReceiver(ByVal client As ClientInstance, ByVal rPacket As com_packet) As Boolean

        Return True
    End Function

    ''' <summary>
    ''' Regedit thread.
    ''' </summary>
    ''' <param name="client">The client.</param>
    ''' <param name="rPacket">The r packet.</param>
    ''' <returns></returns>
    Public Function threadRegeditMgr(ByVal client As ClientInstance, ByVal rPacket As com_packet) As Boolean
        Dim operationResult As Boolean = True

        Dim buffer(255) As Byte

        Select Case rPacket.dataType
            Case dataTypes.enum_keys
                '''' Getting the full path of the string
                Dim regrtkey_i As Integer = rPacket.getPacketParamValue("regrtkey")
                Dim regrtkey_s As String = ""

                Select Case regrtkey_i
                    Case 0
                        regrtkey_s = "HKEY_CLASSES_ROOT"
                    Case 1
                        regrtkey_s = "HKEY_CURRENT_USER"
                    Case 2
                        regrtkey_s = "HKEY_LOCAL_MACHINE"
                    Case 3
                        regrtkey_s = "HKEY_USERS"
                    Case 4
                        regrtkey_s = "HKEY_CURRENT_CONFIG"
                End Select

                Dim regpth As String = rPacket.getPacketParamValue("regpth")

                If Not regpth = "" Then regrtkey_s += "\" + regpth

                Dim wantedNode As TreeNode

                '''' Disable drawing events for reg controll
                doThreadSafeObjectLinkedAction(regKeyHolder, Function()
                                                                 wantedNode = regKeyHolder.GetNodeByFullPath(regrtkey_s)

                                                                 regKeyHolder.BeginUpdate()
                                                                 Return True
                                                             End Function)

                '''' Check for errors in node find before reading data
                ' TODO:


                '''' Trying to receive the entire item collection in a fragmented manner.
                If Not client.receive_fragmented(buffer, rPacket, 255,
                       Function(ByVal lrecvBytes As UInt64)

                           Dim keyName As String = System.Text.Encoding.ASCII.GetString(buffer, 0, lrecvBytes)

                           SafeString(keyName)

                           '''' Insert the new node into the tree view
                           doThreadSafeObjectLinkedAction(regKeyHolder, Function()
                                                                            wantedNode.AddTreeNode(keyName)
                                                                            Return True
                                                                        End Function)
                           Return True
                       End Function) Then operationResult = False

                '''' Expand the tree node
                doThreadSafeObjectLinkedAction(regKeyHolder, Function()
                                                                 wantedNode.Expand()
                                                                 Return True
                                                             End Function)

                '''' Re-enable drawing events for reg controll
                doThreadSafeObjectLinkedAction(regKeyHolder, Function()
                                                                 regKeyHolder.EndUpdate()
                                                                 Return True
                                                             End Function)

                Return operationResult

            Case dataTypes.enum_values
                '''' Read the size of the value name
                If Not client.receive(buffer, 4) Then Return False
                Dim sizeOfValueName As UInt32 = BitConverter.ToUInt32(buffer, 0)

                '''' Read the value name
                If Not client.receive(buffer, sizeOfValueName) Then Return False
                Dim valueName As String = System.Text.Encoding.ASCII.GetString(buffer, 0, sizeOfValueName)
                SafeString(valueName)


                '''' Read the reg type
                If Not client.receive(buffer, 4) Then Return False
                Dim regType As UInt32 = BitConverter.ToUInt32(buffer, 0)


                '''' Read the size of data
                If Not client.receive(buffer, 4) Then Return False
                Dim sizeOfValueData As UInt32 = BitConverter.ToUInt32(buffer, 0)


                '''' By default the client is not allowed to send me value data's with a size
                '''' bigger than the size of the value's name size which is 255
                If sizeOfValueData > 255 Then Return False

                '''' Read the data
                If Not client.receive(buffer, sizeOfValueData) Then Return False
                Dim valueData As String = System.Text.Encoding.ASCII.GetString(buffer, 0, sizeOfValueData)

                Dim newEntryList As New ListViewItem(valueName, 2)
                newEntryList.SubItems.Add(regedit_get_type_string(regType))
                newEntryList.SubItems.Add(valueData)

                doThreadSafeObjectLinkedAction(regValueHolder, Function()
                                                                   regValueHolder.Items.Add(newEntryList)

                                                                   Return True
                                                               End Function)

                Return True
        End Select

        Return True
    End Function

    ''' <summary>
    ''' Download manager thread.
    ''' </summary>
    ''' <param name="client">The client.</param>
    ''' <param name="rPacket">The r packet.</param>
    ''' <returns></returns>
    Public Function threadDownloadMgrReceiver(ByVal client As ClientInstance, ByVal rPacket As com_packet) As Boolean
        Dim operationResult As Boolean = True

        Select Case rPacket.dataType
            Case dataTypes.download_file

                '''' Tranfer bandwidth is of 65536 bytes for the moment
                Dim fragmentSize As UInt64 = 65536

                '''' Declare a buffer especially for the file transfer
                Dim buffer(fragmentSize + 10) As Byte

                '''' Hold the name of the file to download or the path to the folder ready to be downloaded
                Dim wantedFile As String

                '''' If buildDirs is true then that means this call has been made by a directory-download
                Dim buildDirs As String = rPacket.getPacketParamValue("buildDirs")

                '''' Hold the base folder. Important because it tells me how much to trim from the files found inside that folder.
                Dim baseFolder As String = rPacket.getPacketParamValue("baseFolder")

                '''' Get an argument which will tell me if I want to open it or not
                Dim openFile As String = rPacket.getPacketParamValue("openFile")


                If buildDirs = "true" Then
                    wantedFile = rPacket.getPacketParamValue("fInDirName")
                Else
                    wantedFile = rPacket.getPacketParamValue("wantedFile")
                End If

                '''' Tells me where to download on the filesystem
                Dim whereToDownload As String = client.workingPath + wantedFile.Substring(baseFolder.Count, wantedFile.Count - baseFolder.Count)

                '''' Checking for some some sort of a path traversal here. A very important step as it could affect my coputer
                If hackedPathTraversal(whereToDownload) Then
                    debugMessage("Client " + client.get_to_string() + " got banned -> path traversal detected while downloading '" + whereToDownload + "'!", informationcode.error)

                    databaseOfUsers.blackListUser(client.ip)
                    Return False
                End If


                '''' If I want to build dirs then build them
                If buildDirs = "true" Then Directory.CreateDirectory(Path.GetDirectoryName(whereToDownload))


                '''' Updating the progress bar status
                doThreadSafeObjectLinkedAction(ftpDownloadProgressBar, Function()
                                                                           ftpDownloadProgressBar.Minimum = 0
                                                                           ftpDownloadProgressBar.Maximum = rPacket.packetSize
                                                                           ftpDownloadProgressBar.Value = 0

                                                                           Return True
                                                                       End Function)

                '''' Show the name of the file currently being downloaded in a label
                doThreadSafeObjectLinkedAction(lblDownloadName, Function()
                                                                    lblDownloadName.Text = whereToDownload
                                                                    Return True
                                                                End Function)

                '''' Trying to receive the entire file stream.
                Using writer As FileStream = New FileStream(whereToDownload, FileMode.Create)
                    If Not client.receive_fragmented(buffer, rPacket, fragmentSize,
                       Function(ByVal lrecvBytes As UInt64)

                           '''' Write the received bytes to the file stream
                           writer.Write(buffer, 0, lrecvBytes)

                           '''' Update the progress bar's statuss
                           doThreadSafeObjectLinkedAction(ftpDownloadProgressBar, Function()
                                                                                      ftpDownloadProgressBar.Value += lrecvBytes
                                                                                      Return True
                                                                                  End Function)
                           Return True
                       End Function) Then operationResult = False
                End Using


                '''' This means I want to open the file after dowloading/
                '''' That means I have to check if the speciied file is 
                '''' an executable or not. I don't want to run executables.
                If openFile = "true" Then
                    If whereToDownload.Contains(".exe") Or whereToDownload.Contains(".lnk") Then

                        '''' Why is this an error ? 
                        '''' Because I can't send a packet to the client reuesting it to download and
                        '''' open for me an executable. I filter those packets out, so they never reach the client.
                        '''' That means that the packet has been forged and that someone is trying to open files
                        '''' on my behalf.
                        debugMessage("Client " + client.get_to_string() + " got banned -> cannot open executables on my machine!", informationcode.error)

                        databaseOfUsers.blackListUser(client.ip)

                        Return False
                    Else
                        Process.Start(whereToDownload)
                    End If
                End If


                '''' Clear the label which stored the name of the file being downloaded
                doThreadSafeObjectLinkedAction(lblDownloadName, Function()
                                                                    lblDownloadName.Text = ""
                                                                    Return True
                                                                End Function)


                '''' Adding the file path to the list with operation activity holder
                doThreadSafeObjectLinkedAction(ftpOperationHistory, Function()
                                                                        ftpOperationHistory.Items.Add(whereToDownload)
                                                                        Return True
                                                                    End Function)

                '''' Reset the progress bar's level
                doThreadSafeObjectLinkedAction(ftpDownloadProgressBar, Function()
                                                                           ftpDownloadProgressBar.Value = 0
                                                                           Return True
                                                                       End Function)
        End Select

        Return operationResult
        Return True
    End Function

    ''' <summary>
    ''' The last frame time
    ''' </summary>
    Dim lastFrameTime As Date = Date.Now

    ''' <summary>
    ''' The video stream thread.
    ''' </summary>
    ''' <param name="client">The client.</param>
    ''' <param name="rPacket">The r packet.</param>
    ''' <returns></returns>
    Public Function threadScreenCapture(ByVal client As ClientInstance, ByVal rPacket As com_packet) As Boolean
        Select Case rPacket.dataType
            Case dataTypes.video_end
                Dim sPacket As com_packet

                If Not client.send_header(dataTypes.video_start, 8, sPacket) Then Return False

                Dim frameCount As UInt32 = videoFrm.getFramesCountValue
                Dim rowHeight As UInt32 = videoFrm.getRowHeightValue

                Dim buffer(12) As Byte

                BitConverter.GetBytes(frameCount).CopyTo(buffer, 0)
                BitConverter.GetBytes(rowHeight).CopyTo(buffer, 4)

                If Not client.send(buffer, sPacket) Then Return False

                ' Restart mouse component
                client = get_client(clientTypes.mouse)
                If client Is Nothing Then Return True

                client.send_header(dataTypes.mouse_start, 0, sPacket)       ' Doesn't matter if succeded or not. The video continues
            Case dataTypes.video_frame
                Dim rowHeight As UInt32
                Dim width As UInt32
                Dim height As UInt32
                Dim yOffset As UInt32

                Dim init_buff(24) As Byte

                If Not client.receive(init_buff, 16) Then Return False

                rowHeight = BitConverter.ToUInt32(init_buff, 0)
                width = BitConverter.ToUInt32(init_buff, 4)
                height = BitConverter.ToUInt32(init_buff, 8)
                yOffset = BitConverter.ToUInt32(init_buff, 12)


                '''' This is to prevent some sort of unsigned type issues
                If rPacket.packetSize < 16 Then Return False

                rPacket.packetSize -= 16

                If rPacket.packetSize > 12000000 Then Return False

                Dim frameBuffer(0 To rPacket.packetSize - 1) As Byte

                If Not client.receive(frameBuffer, rPacket) Then Return False

                Dim bmi As New BITMAPINFO With {
                    .bmiheader = New BITMAPINFOHEADER With {
                    .biSize = 40,   'Size, in bytes, of the header (always 40)
                    .biPlanes = 1,  'Number of planes (always one)
                    .biBitCount = 24,    'Bits per pixel (always 24 for image processing)
                    .biCompression = 0,  'Compression: none or RLE (always zero)
                    .biWidth = width,
                    .biHeight = rowHeight,
                    .biSizeImage = rPacket.packetSize
                    }
                }

                If videoData Is Nothing Then Return False

                Try
                    videoData.maxWidth = width
                    videoData.maxHeight = height
                    updateDirectFrame(videoData, frameBuffer, bmi, yOffset)
                Catch ex As Exception
                    'videoData.destroy()   videoData is destroyed in event
                    Return False
                End Try

                ' New whole frame
                If yOffset = 0 Then
                    videoFrm.setFPS = Date.Now.Subtract(lastFrameTime).TotalMilliseconds
                    lastFrameTime = Date.Now
                End If
        End Select

        Return True
    End Function

    ''' <summary>
    ''' Handles the Closing event of the WindowVideo control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
    Private Sub WindowVideo_Closing(sender As Object, e As CancelEventArgs) Handles videoFrm.Closing
        Dim videoComponent As ClientInstance = get_client(clientTypes.screenCapture)

        If videoComponent IsNot Nothing Then
            videoComponent.destroy()
        End If

        Try
            videoData.destroy()
            videoData = Nothing
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Mouse thread.
    ''' </summary>
    ''' <param name="client">The client.</param>
    ''' <param name="rPacket">The r packet.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Function threadMouseHandler(ByVal client As ClientInstance, ByVal rPacket As com_packet) As Boolean
        Select Case rPacket.dataType
            Case dataTypes.mouse_pos
                Dim sPacket As com_packet

                Dim init_buff(24) As Byte

                If Not client.receive(init_buff, 16) Then Return False

                Dim screenW As UInt32 = BitConverter.ToUInt32(init_buff, 0)
                Dim screenH As UInt32 = BitConverter.ToUInt32(init_buff, 4)
                Dim x As UInt32 = BitConverter.ToUInt32(init_buff, 8)
                Dim y As UInt32 = BitConverter.ToUInt32(init_buff, 12)

                If videoFrm.getCanvasInstance().IsDisposed Then Return False

                doThreadSafeObjectLinkedAction(videoFrm.getCanvasInstance, Function()
                                                                               Dim p As New System.Drawing.Pen(Color.Red, 4)
                                                                               If videoFrm.getCanvasInstance().IsDisposed Then Exit Function

                                                                               Dim g As Graphics = videoFrm.getCanvasInstance.CreateGraphics
                                                                               g.DrawEllipse(p, CInt(videoFrm.getCanvasInstance.Width * x / screenW), CInt(videoFrm.getCanvasInstance.Height * y / screenH), 3, 3)
                                                                               g.Dispose()
                                                                           End Function)

                'Send live mouse position
                Dim mouse As Point = videoFrm.getLiveMouse

                If mouse.X < 0 Or mouse.Y < 0 Then Return True
                If Not client.send_header(dataTypes.mouse_pos, 8, sPacket) Then Return False

                Dim buffer(8) As Byte
                BitConverter.GetBytes(Convert.ToUInt32(screenW * mouse.X / videoFrm.getCanvasInstance.Width)).CopyTo(buffer, 0)
                BitConverter.GetBytes(Convert.ToUInt32(screenH * mouse.Y / videoFrm.getCanvasInstance.Height)).CopyTo(buffer, 4)

                If Not client.send(buffer, sPacket) Then Return False

                'Send live mouse clicks

                Dim tempClick As Integer = videoFrm.getLiveClick
                If tempClick = 0 Then Return True
                If Not client.send_header(IIf(tempClick = 1, dataTypes.mouse_click_left, dataTypes.mouse_click_right), 0, sPacket) Then Return False

        End Select

        Return True
    End Function

    ''' <summary>
    ''' Handles the Tick event of the pingDisabledClients control.
    ''' Check for inactive/timedout clients.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub pingDisabledClients_Tick(sender As Object, e As EventArgs) Handles pingDisabledClients.Tick
        SyncLock listbindingsource
            For i As Integer = 0 To listbindingsource.Count - 1 Step 1
                Dim clientWrapper As ClientWrapper = CType(listbindingsource.Item(i), ClientWrapper)

                If Not clientWrapper.get_same_as(safeSelectedClientWrapper.value) Then
                    clientWrapper.ping_every_client_component()
                End If
            Next
        End SyncLock
    End Sub

#End Region



#Region "RegionMarker_SimpleMemoryAndDataProcessingUtils"

    ''' <summary>
    ''' Gets a safe clientinstance.
    ''' </summary>
    ''' <param name="clienttype">The clienttype.</param>
    ''' <returns>ClientInstance.</returns>
    Private Function get_client(ByVal clienttype As Integer) As ClientInstance
        If Not safeSelectedClientWrapper.value Is Nothing Then
            Dim client As ClientInstance

            SyncLock safeSelectedClientWrapper.value
                client = safeSelectedClientWrapper.value.get_client_component_by_type(clienttype)
            End SyncLock

            Return client
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Gets the active client.
    ''' </summary>
    ''' <returns>ClientInstance.</returns>
    Private Function get_active_client() As ClientInstance
        If Not safeSelectedClientWrapper.value Is Nothing Then
            Dim client As ClientInstance

            SyncLock safeSelectedClientWrapper.value
                client = safeSelectedClientWrapper.value.get_one_active_client()
            End SyncLock

            Return client
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Resets the information panel.
    ''' </summary>
    Private Sub resetInformationPanel()
        wTextBoxThread(luid, emptystr)
        wTextBoxThread(luid, emptystr)
        wTextBoxThread(luser, emptystr)
        wTextBoxThread(lver, emptystr)
        wTextBoxThread(losver, emptystr)
        wTextBoxThread(lcustom, emptystr)
        wTextBoxThread(lextra, emptystr)
        wTextBoxThread(ldesc, emptystr)

        wTextBoxThread(statusshell, cmp_off)
        wTextBoxThread(statusftp, cmp_off)
        wTextBoxThread(statusUploadMgr, cmp_off)
        wTextBoxThread(statusDownloadMnager, cmp_off)
        wTextBoxThread(statusRegedit, cmp_off)
        wTextBoxThread(statusVideo, cmp_off)
    End Sub

    ''' <summary>
    ''' Links the data to information panel.
    ''' </summary>
    ''' <param name="clWrapper">The cl wrapper.</param>
    Private Sub linkDataToInformationPanel(ByVal clWrapper As ClientWrapper)
        Dim usrdescriptor As userdescriptor = clWrapper.get_user_descriptor()

        wTextBoxThread(luid, usrdescriptor.unique_id)
        wTextBoxThread(luser, usrdescriptor.user_name)
        wTextBoxThread(lver, usrdescriptor.version)
        wTextBoxThread(losver, usrdescriptor.os_version)

        wTextBoxThread(lcustom, usrdescriptor.custom_name)
        wTextBoxThread(lextra, usrdescriptor.extra_data)
        wTextBoxThread(ldesc, usrdescriptor.pc_description)

        If Not clWrapper.get_client_exists(clientTypes.shell) Then
            wTextBoxThread(statusshell, cmp_off)
        Else
            wTextBoxThread(statusshell, cmp_on)
        End If

        If Not clWrapper.get_client_exists(clientTypes.ftp) Then
            wTextBoxThread(statusftp, cmp_off)
        Else
            wTextBoxThread(statusftp, cmp_on)
        End If

        If Not clWrapper.get_client_exists(clientTypes.upload_manager) Then
            wTextBoxThread(statusUploadMgr, cmp_off)
        Else
            wTextBoxThread(statusUploadMgr, cmp_on)
        End If

        If Not clWrapper.get_client_exists(clientTypes.download_manager) Then
            wTextBoxThread(statusDownloadMnager, cmp_off)
        Else
            wTextBoxThread(statusDownloadMnager, cmp_on)
        End If

        If Not clWrapper.get_client_exists(clientTypes.regedit) Then
            wTextBoxThread(statusRegedit, cmp_off)
        Else
            wTextBoxThread(statusRegedit, cmp_on)
        End If

        If Not clWrapper.get_client_exists(clientTypes.screenCapture) Then
            wTextBoxThread(statusVideo, cmp_off)
        Else
            wTextBoxThread(statusVideo, cmp_on)
        End If

    End Sub

    ''' <summary>
    ''' Do a thread safe ui action.
    ''' </summary>
    ''' <param name="wtControl">The wt control.</param>
    ''' <param name="functionOnObject">The function on object.</param>
    Private Sub doThreadSafeObjectLinkedAction(ByVal wtControl As Control, ByVal functionOnObject As Func(Of Boolean))
        ' In rare ocassions the control is disposed and this may throw error

        If wtControl.IsDisposed Then Exit Sub

        Try
            If wtControl.InvokeRequired Then
                wtControl.Invoke(Sub() functionOnObject())
            Else
                functionOnObject()
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Safely write to a text component.
    ''' </summary>
    ''' <param name="tbox">The tbox.</param>
    ''' <param name="str">The string.</param>
    ''' <param name="append">if set to <c>true</c> [append].</param>
    Private Sub wTextBoxThread(ByVal tbox As Object, ByVal str As String, Optional append As Boolean = False)
        doThreadSafeObjectLinkedAction(tbox, Function()
                                                 If append Then
                                                     tbox.Text += str
                                                 Else
                                                     tbox.Text = str
                                                 End If

                                                 Return True
                                             End Function)
    End Sub

    ''' <summary>
    ''' Show a debug message.
    ''' </summary>
    ''' <param name="data">The data.</param>
    ''' <param name="icode">The icode.</param>
    Public Sub debugMessage(ByVal data As String, Optional icode As Integer = informationcode.normal)

        Dim prefix As String = debugGetInfoPrefix(icode)

        System.Diagnostics.Debug.Print(prefix + data)

        Try
            doThreadSafeObjectLinkedAction(debugView,
                                            Function()
                                                Dim _start As Integer = debugView.TextLength

                                                debugView.AppendText(prefix + data + vbCrLf)

                                                debugView.Select(_start, data.Length + prefix.Length)

                                                debugView.SelectionColor = debugGetColorizationStyle(icode)

                                                debugView.SelectionLength = 0

                                                '''' Scroll to the bottom 
                                                debugView.SelectionStart = debugView.Text.Length
                                                debugView.ScrollToCaret()

                                                Return True
                                            End Function)
        Catch ex As Exception
            '''' the debug view control may be disposed at the moment of logging. Therfore some exceptions could've been raised!
        End Try

    End Sub

    ''' <summary>
    ''' Message low level.
    ''' </summary>
    ''' <param name="data">The data.</param>
    ''' <param name="icode">The icode.</param>
    Public Sub debugMessageLowLevel(ByVal data As String, Optional icode As Integer = informationcode.normal)

        Dim prefix As String = debugGetInfoPrefix(icode)

        System.Diagnostics.Debug.Print(prefix + data)

        Try
            doThreadSafeObjectLinkedAction(debugLowLevelView,
                                            Function()
                                                Dim _start As Integer = debugLowLevelView.TextLength

                                                debugLowLevelView.AppendText(prefix + data + vbCrLf)

                                                debugLowLevelView.Select(_start, data.Length + prefix.Length)

                                                debugLowLevelView.SelectionColor = debugGetColorizationStyle(icode)

                                                debugLowLevelView.SelectionLength = 0

                                                '''' Scroll to the bottom 
                                                debugLowLevelView.SelectionStart = debugLowLevelView.Text.Length
                                                debugLowLevelView.ScrollToCaret()

                                                Return True
                                            End Function)
        Catch ex As Exception
            '''' the debug view control may be disposed at the moment of logging. Therfore some exceptions could've been raised!
        End Try

    End Sub

    ''' <summary>
    ''' Get colorization style by icode
    ''' </summary>
    ''' <param name="icode">The icode.</param>
    ''' <returns>Color.</returns>
    Private Function debugGetColorizationStyle(ByVal icode As Integer) As Color
        Select Case icode
            Case informationcode.error
                Return Color.Red
            Case informationcode.warning
                Return Color.Lime
        End Select

        Return Color.White
    End Function

    ''' <summary>
    ''' Debugs the get information prefix.
    ''' </summary>
    ''' <param name="icode">The icode.</param>
    ''' <returns>System.String.</returns>
    Private Function debugGetInfoPrefix(ByVal icode As Integer) As String
        Select Case icode
            Case informationcode.error
                Return " [-] "
            Case informationcode.warning
                Return " [!] "
        End Select

        Return " [+] "
    End Function

    ''' <summary>
    ''' Handles the Click event of the ExitToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the HelpToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        WindowHelp.ShowDialog()
    End Sub


#End Region



    ''' <summary>
    ''' STORES SAFELY an object. Once the object is accesed through a get property it is no longer safe.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public Class SafeObjectHandler(Of T)
        Dim internal_subject As T, lock As New Object

        ''' <summary>
        ''' Gets or sets the value.
        ''' </summary>
        ''' <value>The value.</value>
        Public Property value As T
            Get
                SyncLock lock
                    Return internal_subject
                End SyncLock
            End Get

            Set(value As T)
                SyncLock lock
                    internal_subject = value
                End SyncLock
            End Set
        End Property

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SafeObjectHandler{T}"/> class.
        ''' </summary>
        ''' <param name="subject">The subject.</param>
        Public Sub New(ByRef subject As T)
            internal_subject = subject
        End Sub
    End Class


End Class