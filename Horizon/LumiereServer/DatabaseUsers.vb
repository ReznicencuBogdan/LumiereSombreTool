' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="DatabaseUsers.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Data.OleDb


''' <summary>
''' Manages user database operations.
''' </summary>
Public Class DatabaseUsers

    ''' <summary>
    ''' The odb connection used to communicate with the database.
    ''' </summary>
    Dim ODBConnection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ServerClientManagement2003.mdb")

    ''' <summary>
    ''' The synchronization object.
    ''' </summary>
    Dim syncroot As New Object

    ''' <summary>
    ''' Initializes a new instance of the <see cref="DatabaseUsers"/> class.
    ''' </summary>
    Public Sub New()
        ODBConnection.Open()
    End Sub

    ''' <summary>
    ''' Registers a new user.Adds it to the database.
    ''' </summary>
    ''' <param name="client">The client.</param>
    Public Sub registerNewUser(ByVal client As ClientInstance)
        SyncLock syncroot
            Using cmd As OleDbCommand = New OleDbCommand("INSERT INTO RegisteredClients (ip, username) VALUES ('" + client.ip + "', '" + client.get_user_descriptor().user_name + "')", ODBConnection)
                cmd.ExecuteNonQuery()
            End Using
        End SyncLock
    End Sub

    ''' <summary>
    ''' Blacklist the user.
    ''' </summary>
    ''' <param name="ip">The ip.</param>
    Public Sub blackListUser(ByVal ip As String)
        SyncLock syncroot
            '''' Insert the user into the blacklist
            Using cmd As OleDbCommand = New OleDbCommand("INSERT INTO Blacklist (ip) VALUES ('" + ip + "')", ODBConnection)
                cmd.ExecuteNonQuery()
            End Using
        End SyncLock
    End Sub

    ''' <summary>
    ''' Determines whether [is user registered] for [the specified ip].
    ''' </summary>
    ''' <param name="ip">The ip.</param>
    ''' <returns><c>true</c> if [is user registered] for [the specified ip]; otherwise, <c>false</c>.</returns>
    Public Function isUserRegistered(ByVal ip As String) As Boolean
        SyncLock syncroot
            '''' Verify the existence of the client
            Using cmd As OleDbCommand = New OleDbCommand("SELECT * FROM RegisteredClients WHERE ip='" + ip + "'", ODBConnection)
                Dim ODBReader As OleDbDataReader = cmd.ExecuteReader()

                If ODBReader.Read() Then Return True
            End Using

        End SyncLock

        Return False
    End Function

    ''' <summary>
    ''' Determines whether [is user blacklisted] for [the specified ip].
    ''' </summary>
    ''' <param name="ip">The ip.</param>
    ''' <returns><c>true</c> if [is user blacklisted] for [the specified ip]; otherwise, <c>false</c>.</returns>
    Public Function isUserBlacklisted(ByVal ip As String) As Boolean
        SyncLock syncroot
            '''' Verify the existence of the client
            Using cmd As OleDbCommand = New OleDbCommand("SELECT * FROM Blacklist WHERE ip='" + ip + "'", ODBConnection)
                Dim ODBReader As OleDbDataReader = cmd.ExecuteReader()

                If ODBReader.Read() Then Return True
            End Using

        End SyncLock

        Return False
    End Function

    ''' <summary>
    ''' Removes user from blacklist.
    ''' </summary>
    ''' <param name="ip">The ip of the user.</param>
    Public Sub removeFromBlacklist(ByVal ip As String)
        If isUserBlacklisted(ip) Then
            Using cmd As OleDbCommand = New OleDbCommand("DELETE FROM Blacklist WHERE ip='" + ip + "'", ODBConnection)
                cmd.ExecuteNonQuery()
            End Using
        End If
    End Sub

    ''' <summary>
    ''' Fills the data grid component.
    ''' </summary>
    ''' <param name="tableRegistered">The registered users gridview component.</param>
    ''' <param name="tableBlacklist">The blacklisted users gridview component.</param>
    Public Sub fillDataGridComponent(ByVal tableRegistered As DataGridView, ByVal tableBlacklist As DataGridView)
        SyncLock syncroot
            Using dataTable As DataTable = New DataTable()
                Using ODBAdapter As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM RegisteredClients", ODBConnection)
                    ODBAdapter.Fill(dataTable)
                End Using
                tableRegistered.DataSource = dataTable
            End Using

            Using dataTable As DataTable = New DataTable()
                Using ODBAdapter As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM Blacklist", ODBConnection)
                    ODBAdapter.Fill(dataTable)
                End Using
                tableBlacklist.DataSource = dataTable
            End Using
        End SyncLock
    End Sub

    ''' <summary>
    ''' Finalizes this instance.
    ''' </summary>
    Protected Overrides Sub Finalize()
        Try
            ODBConnection.Close()
            ODBConnection.Dispose()
        Catch ex As Exception

        End Try
    End Sub


End Class
