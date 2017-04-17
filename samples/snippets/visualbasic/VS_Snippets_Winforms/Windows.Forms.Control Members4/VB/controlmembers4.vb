Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace ControlMembers4
   Public Class Form2
      Inherits System.Windows.Forms.Form
      Private withevents panel1 As System.Windows.Forms.Panel
      Private withevents button1 As System.Windows.Forms.Button
      Private withevents statusBar1 As System.Windows.Forms.StatusBar
      Private withevents treeView1 As System.Windows.Forms.TreeView
      Private withevents contextMenu1 As System.Windows.Forms.ContextMenu
      Private withevents menuItem1 As System.Windows.Forms.MenuItem
      Private withevents menuItem2 As System.Windows.Forms.MenuItem
      Private withevents menuItem3 As System.Windows.Forms.MenuItem
      Private withevents label1 As System.Windows.Forms.Label

      Private components As System.ComponentModel.Container = Nothing
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      Private Sub InitializeComponent()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.button1 = New System.Windows.Forms.Button()
         Me.label1 = New System.Windows.Forms.Label()
         Me.statusBar1 = New System.Windows.Forms.StatusBar()
         Me.treeView1 = New System.Windows.Forms.TreeView()
         Me.contextMenu1 = New System.Windows.Forms.ContextMenu()
         Me.menuItem1 = New System.Windows.Forms.MenuItem()
         Me.menuItem2 = New System.Windows.Forms.MenuItem()
         Me.menuItem3 = New System.Windows.Forms.MenuItem()
         Me.panel1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' panel1
         ' 
         Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.label1})
         Me.panel1.Location = New System.Drawing.Point(48, 40)
         Me.panel1.Name = "panel1"
         Me.panel1.TabIndex = 0
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(16, 16)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 1
         Me.button1.Text = "button1"
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(16, 16)
         Me.label1.Name = "label1"
         Me.label1.TabIndex = 2
         Me.label1.Text = "label1"
         ' 
         ' statusBar1
         ' 
         Me.statusBar1.Location = New System.Drawing.Point(0, 295)
         Me.statusBar1.Name = "statusBar1"
         Me.statusBar1.Size = New System.Drawing.Size(320, 22)
         Me.statusBar1.TabIndex = 1
         Me.statusBar1.Text = "statusBar1"
         ' 
         ' treeView1
         ' 
         Me.treeView1.ContextMenu = Me.contextMenu1
         Me.treeView1.ImageIndex = - 1
         Me.treeView1.Location = New System.Drawing.Point(64, 152)
         Me.treeView1.Name = "treeView1"
         Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node2")})})})
         Me.treeView1.SelectedImageIndex = - 1
         Me.treeView1.TabIndex = 2
         ' 
         ' contextMenu1
         ' 
         Me.contextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem1, Me.menuItem2, Me.menuItem3})
         ' 
         ' menuItem1
         ' 
         Me.menuItem1.Index = 0
         Me.menuItem1.Text = "Edit"
         ' 
         ' menuItem2
         ' 
         Me.menuItem2.Index = 1
         Me.menuItem2.Text = "Expand"
         ' 
         ' menuItem3
         ' 
         Me.menuItem3.Index = 2
         Me.menuItem3.Text = "Collapse"
         ' 
         ' Form2
         ' 
         Me.ClientSize = New System.Drawing.Size(320, 317)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.treeView1, Me.statusBar1, Me.panel1})
         Me.Name = "Form2"
         Me.Text = "Form2"
         Me.panel1.ResumeLayout(False)
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
      
<STAThread()> _
Shared Sub Main()
   Application.Run(New Form2())
End Sub 'Main


' <snippet1>
Private Sub MakeLabelVisible()
   ' If the panel contains label1, bring it 
   ' to the front to make sure it is visible. 
   If panel1.Contains(label1) Then
      label1.BringToFront()
   End If
End Sub
' </snippet1>

' <snippet2>
Private Sub button1_Click(sender As Object, _
  e As EventArgs) Handles button1.Click
   ' If the CTRL key is pressed when the 
   ' control is clicked, hide the control. 
   If Control.ModifierKeys = Keys.Control Then
      CType(sender, Control).Hide()
   End If
End Sub
' </snippet2>

' <snippet3>
Private Sub treeView1_KeyDown(sender As Object, _
  e As KeyEventArgs) Handles treeView1.KeyDown
   ' If the 'Alt' and 'E' keys are pressed,
   ' allow the user to edit the TreeNode label. 
   If e.Alt And e.KeyCode = Keys.E Then
      treeView1.LabelEdit = True
      ' If there is a TreeNode under the mose cursor, begin editing. 
      Dim editNode As TreeNode = treeView1.GetNodeAt( _
        treeView1.PointToClient(System.Windows.Forms.Control.MousePosition))
      If (editNode IsNot Nothing) Then
         editNode.BeginEdit()
      End If
   End If
End Sub

Private Sub treeView1_AfterLabelEdit(sender As Object, _
  e As NodeLabelEditEventArgs) Handles treeView1.AfterLabelEdit
   ' Disable the ability to edit the TreeNode labels.
   treeView1.LabelEdit = False
End Sub
' </snippet3>

   End Class
End Namespace