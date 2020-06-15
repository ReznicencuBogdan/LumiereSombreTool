' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="MTreeViewExtension.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Runtime.CompilerServices

''' <summary>
''' Class MTreeViewExtension. Handles the regedit view.
''' </summary>
Public Module MTreeViewExtension


    ''' <summary>
    ''' Adds a node to a parent node in the tree view.
    ''' </summary>
    ''' <param name="parentNode">The parent node.</param>
    ''' <param name="text">The text.</param>
    ''' <returns>TreeNode.</returns>
    <Extension()>
    Public Function AddTreeNode(ByVal parentNode As TreeNode, ByVal text As String) As TreeNode
        Dim tn As New TreeNode(text)

        Dim leveledPath As String = parentNode.Name & "\" & text

        SafeString(leveledPath)

        tn.Name = leveledPath
        parentNode.Nodes.Add(tn)

        Return tn
    End Function

    ''' <summary>
    ''' Adds a node to the master tree.
    ''' </summary>
    ''' <param name="treeView">The tree view.</param>
    ''' <param name="text">The text.</param>
    ''' <returns>TreeNode.</returns>
    <Extension()>
    Public Function AddTreeNode(ByVal treeView As TreeView, ByVal text As String) As TreeNode
        Dim tn As New TreeNode(text)

        tn.Name = text
        treeView.Nodes.Add(tn)

        Return tn
    End Function

    ''' <summary>
    ''' Gets the node by full path. Find node by id.
    ''' </summary>
    ''' <param name="treeView">The tree view.</param>
    ''' <param name="fullPath">The full path.</param>
    ''' <returns>TreeNode.</returns>
    <Extension()>
    Public Function GetNodeByFullPath(ByVal treeView As TreeView, ByVal fullPath As String) As TreeNode
        Dim tn() As TreeNode = treeView.Nodes.Find(fullPath, True)

        If tn.Count > 0 Then Return tn(0) Else Return Nothing
    End Function

    ''' <summary>
    ''' Regedit - the get full path.
    ''' </summary>
    ''' <param name="node">The node.</param>
    ''' <returns>System.String.</returns>
    <Extension()>
    Public Function regedit_get_full_path(ByVal node As TreeNode) As String
        Return node.Name
    End Function

End Module
