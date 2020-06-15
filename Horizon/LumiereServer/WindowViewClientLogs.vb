' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="WindowViewClientLogs.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' Class WindowViewClientLogs.
''' Implements the <see cref="System.Windows.Forms.Form" />
''' </summary>
''' <seealso cref="System.Windows.Forms.Form" />
Public Class WindowViewClientLogs
    ''' <summary>
    ''' The database of users
    ''' </summary>
    Dim databaseOfUsers As DatabaseUsers
    ''' <summary>
    ''' The database inited
    ''' </summary>
    Public databaseInited As Boolean = False

    ''' <summary>
    ''' Updates the grid view.
    ''' </summary>
    Private Sub updateGridView()
        databaseOfUsers.fillDataGridComponent(tableRegistered, tableBlacklist)
    End Sub

    ''' <summary>
    ''' Handles the Load event of the ViewClientLogs control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ViewClientLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateGridView()
    End Sub

    ''' <summary>
    ''' Sets the database.
    ''' </summary>
    ''' <param name="pDatabaseOfUsers">The p database of users.</param>
    Public Sub setDatabase(ByVal pDatabaseOfUsers As DatabaseUsers)
        databaseOfUsers = pDatabaseOfUsers

        databaseInited = True
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnmvtoblacklist control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnmvtoblacklist_Click(sender As Object, e As EventArgs) Handles btnmvtoblacklist.Click
        For Each row As DataGridViewRow In tableRegistered.SelectedRows
            Dim ip As String = row.Cells(1).Value

            If ip = Nothing Then Continue For

            If Not databaseOfUsers.isUserBlacklisted(ip) Then
                databaseOfUsers.blackListUser(ip)
            End If
        Next

        updateGridView()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnremofrmblacklist control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnremofrmblacklist_Click(sender As Object, e As EventArgs) Handles btnremofrmblacklist.Click
        For Each row As DataGridViewRow In tableBlacklist.SelectedRows
            Dim ip As String = row.Cells(1).Value

            If ip = Nothing Then Continue For

            databaseOfUsers.removeFromBlacklist(ip)
        Next

        updateGridView()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnmvtoblacklist_txt control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub btnmvtoblacklist_txt_Click(sender As Object, e As EventArgs) Handles btnmvtoblacklist_txt.Click
        Dim ip As String = txtip.Text

        If ip = "" Then Exit Sub

        If Not databaseOfUsers.isUserBlacklisted(ip) Then
            databaseOfUsers.blackListUser(ip)
        End If

        txtip.Text = ""

        updateGridView()
    End Sub

    ''' <summary>
    ''' Handles the TextChanged event of the txtip control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub txtip_TextChanged(sender As Object, e As EventArgs) Handles txtip.TextChanged

    End Sub
End Class