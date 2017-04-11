
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
'<snippet4>
Imports System.IO
'</snippet4>



Public Class Form1
    Inherits Form
    Private splitContainer1 As SplitContainer
    Private WithEvents treeView1 As TreeView
    Private imageList1 As ImageList
    Private components As IContainer
    Private nameColumn As ColumnHeader
    Private typeColumn As ColumnHeader
    Private modifiedColumn As ColumnHeader
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Private listView1 As ListView
    
    
    '<snippet2>
    Public Sub New() 
        InitializeComponent()
        PopulateTreeView()
    
    End Sub 'New
    
    '</snippet2>
    '<snippet3>
    Private Sub treeView1_NodeMouseClick(ByVal sender As Object, _
        ByVal e As TreeNodeMouseClickEventArgs) _
            Handles treeView1.NodeMouseClick

        Dim newSelected As TreeNode = e.Node
        listView1.Items.Clear()
        Dim nodeDirInfo As DirectoryInfo = _
        CType(newSelected.Tag, DirectoryInfo)
        Dim subItems() As ListViewItem.ListViewSubItem
        Dim item As ListViewItem = Nothing

        Dim dir As DirectoryInfo
        For Each dir In nodeDirInfo.GetDirectories()
            item = New ListViewItem(dir.Name, 0)
            subItems = New ListViewItem.ListViewSubItem() _
                {New ListViewItem.ListViewSubItem(item, "Directory"), _
                New ListViewItem.ListViewSubItem(item, _
                dir.LastAccessTime.ToShortDateString())}

            item.SubItems.AddRange(subItems)
            listView1.Items.Add(item)
        Next dir
        Dim file As FileInfo
        For Each file In nodeDirInfo.GetFiles()
            item = New ListViewItem(file.Name, 1)
            subItems = New ListViewItem.ListViewSubItem() _
                {New ListViewItem.ListViewSubItem(item, "File"), _
                New ListViewItem.ListViewSubItem(item, _
                file.LastAccessTime.ToShortDateString())}

            item.SubItems.AddRange(subItems)
            listView1.Items.Add(item)
        Next file

        listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub
    
    '</snippet3>
    '<snippet1>
    Private Sub PopulateTreeView() 
        Dim rootNode As TreeNode
        
        Dim info As New DirectoryInfo("../..")
        If info.Exists Then
            rootNode = New TreeNode(info.Name)
            rootNode.Tag = info
            GetDirectories(info.GetDirectories(), rootNode)
            treeView1.Nodes.Add(rootNode)
        End If
    
    End Sub
    
    Private Sub GetDirectories(ByVal subDirs() As DirectoryInfo, _
        ByVal nodeToAddTo As TreeNode)

        Dim aNode As TreeNode
        Dim subSubDirs() As DirectoryInfo
        Dim subDir As DirectoryInfo
        For Each subDir In subDirs
            aNode = New TreeNode(subDir.Name, 0, 0)
            aNode.Tag = subDir
            aNode.ImageKey = "folder"
            subSubDirs = subDir.GetDirectories()
            If subSubDirs.Length <> 0 Then
                GetDirectories(subSubDirs, aNode)
            End If
            nodeToAddTo.Nodes.Add(aNode)
        Next subDir

    End Sub
    
    '</snippet1>
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    
    Private Sub InitializeComponent() 
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.treeView1 = New System.Windows.Forms.TreeView
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.listView1 = New System.Windows.Forms.ListView
        Me.nameColumn = New System.Windows.Forms.ColumnHeader("")
        Me.typeColumn = New System.Windows.Forms.ColumnHeader("")
        Me.modifiedColumn = New System.Windows.Forms.ColumnHeader("")
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.treeView1)
        '
        'Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.listView1)
        Me.splitContainer1.Size = New System.Drawing.Size(492, 466)
        Me.splitContainer1.SplitterDistance = 166
        Me.splitContainer1.TabIndex = 0
        Me.splitContainer1.Text = "splitContainer1"
        '
        'treeView1
        '
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeView1.ImageList = Me.imageList1
        Me.treeView1.Location = New System.Drawing.Point(0, 0)
        Me.treeView1.Name = "treeView1"
        Me.treeView1.Size = New System.Drawing.Size(166, 466)
        Me.treeView1.TabIndex = 0
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.Images.SetKeyName(0, "FOLDER.ICO")
        Me.imageList1.Images.SetKeyName(1, "DOC.ICO")
        '
        'listView1
        '
        Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nameColumn, Me.typeColumn, Me.modifiedColumn})
        Me.listView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listView1.Location = New System.Drawing.Point(0, 0)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(322, 466)
        Me.listView1.SmallImageList = Me.imageList1
        Me.listView1.TabIndex = 0
        Me.listView1.View = System.Windows.Forms.View.Details
        '
        'nameColumn
        '
        Me.nameColumn.Text = "Name"
        Me.nameColumn.Width = 82
        '
        'typeColumn
        '
        Me.typeColumn.Text = "Type"
        Me.typeColumn.Width = 78
        '
        'modifiedColumn
        '
        Me.modifiedColumn.Text = "Last Modified"
        Me.modifiedColumn.Width = 109
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(492, 466)
        Me.Controls.Add(Me.splitContainer1)
        Me.Name = "Form1"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent 
End Class 'Form1