Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.VisualBasic


Namespace CursorSetStyle
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private withevents treeView1 As System.Windows.Forms.TreeView
      Private withevents comboBox1 As System.Windows.Forms.ComboBox
      
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
         Me.treeView1.ContextMenu = New ContextMenu(New MenuItem() {New MenuItem("Edit")})
      End Sub 'New
      
      
      Private Sub InitializeComponent()
         Me.treeView1 = New System.Windows.Forms.TreeView()
         Me.comboBox1 = New System.Windows.Forms.ComboBox()
         Me.SuspendLayout()
         ' 
         ' treeView1
         ' 
         Me.treeView1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
         Me.treeView1.ImageIndex = - 1
         Me.treeView1.Name = "treeView1"
         Me.treeView1.SelectedImageIndex = - 1
         Me.treeView1.Size = New System.Drawing.Size(232, 224)
         Me.treeView1.TabIndex = 0
         ' 
         ' comboBox1
         ' 
         Me.comboBox1.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.comboBox1.Location = New System.Drawing.Point(0, 224)
         Me.comboBox1.Name = "comboBox1"
         Me.comboBox1.Size = New System.Drawing.Size(232, 21)
         Me.comboBox1.TabIndex = 1
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(232, 245)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.comboBox1, Me.treeView1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      Shared Sub Main() '
         Application.Run(New Form1())
      End Sub 'Main
  
      
      
      ' <snippet1>
      Private Sub Form1_Load(sender As Object, _
        e As EventArgs) Handles MyBase.Load
         ' Display the hand cursor when the mouse pointer
         ' is over the combo box drop-down button. 
         comboBox1.Cursor = Cursors.Hand
         
         ' Fill the combo box with all the logical 
         ' drives available to the user. 
         Try
            Dim logicalDrive As String
            For Each logicalDrive In  Environment.GetLogicalDrives()
               comboBox1.Items.Add(logicalDrive)
            Next logicalDrive
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub
      ' </snippet1>

      ' <snippet4>
      Protected Overrides ReadOnly Property DefaultImeMode() As ImeMode
         Get
            ' Disable the IME mode for the control.
            Return ImeMode.Off
         End Get
      End Property
      ' </snippet4>
      
      ' <snippet3>
      Protected Overrides ReadOnly Property DefaultSize() As Size
         Get
            ' Set the default size of
            ' the form to 500 pixels square. 
            Return New Size(500, 500)
         End Get
      End Property
      ' </snippet3>

      ' <snippet5>
      Private Sub treeView1_MouseUp(sender As Object, _
        e As MouseEventArgs) Handles treeView1.MouseUp
         ' If the right mouse button was clicked and released,
         ' display the shortcut menu assigned to the TreeView. 
         If e.Button = MouseButtons.Right Then
            treeView1.ContextMenu.Show(treeView1, New Point(e.X, e.Y))
         End If
      End Sub
      ' </snippet5>


      Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox1.SelectedIndexChanged
         Try
            Dim dirInfo As New DirectoryInfo(comboBox1.SelectedItem.ToString())
            Me.treeView1.Nodes.Clear()
            
            ' Do not display or attempt to access System, Temporary, or Hidden directories.
            If dirInfo.Exists And(dirInfo.Attributes And(FileAttributes.Hidden Or FileAttributes.System Or FileAttributes.Temporary)) <> 0 Then
               Dim rootNode As New TreeNode(comboBox1.SelectedItem.ToString())
               treeView1.Nodes.Add(rootNode)
               CreateChildNodes(dirInfo, rootNode)
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub 
      
      Private Sub CreateChildNodes(dirInfo As DirectoryInfo, parentNode As TreeNode)
         Try
            Dim d As DirectoryInfo
            For Each d In  dirInfo.GetDirectories()
               ' Do not display or attempt to access System, Temporary, or System directories.
               If(d.Attributes And(FileAttributes.Hidden Or FileAttributes.System Or FileAttributes.Temporary)) = 0 Then
                  parentNode.Nodes.Add(New TreeNode(d.Name))
                  Application.DoEvents()
               End If
            Next d
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub 
      
      
      Private Sub treeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles treeView1.BeforeExpand
         Dim node As TreeNode
         For Each node In  e.Node.Nodes
            ' Create a DirectoryInfo object from the node path.
            CreateChildNodes(New DirectoryInfo(node.FullPath), node)
         Next node
      End Sub 



   End Class 'Form1 
End Namespace 'CursorSetStyle
