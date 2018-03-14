Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace ToolBarStuff

  Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents treeView1 As System.Windows.Forms.TreeView
      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents treeView2 As System.Windows.Forms.TreeView
      Private WithEvents button2 As System.Windows.Forms.Button

      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
       
      
      Private Sub InitializeComponent()
         Me.treeView1 = New System.Windows.Forms.TreeView()
         Me.button1 = New System.Windows.Forms.Button()
         Me.treeView2 = New System.Windows.Forms.TreeView()
         Me.button2 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' treeView1
         ' 
         Me.treeView1.ImageIndex = - 1
         Me.treeView1.Location = New System.Drawing.Point(8, 8)
         Me.treeView1.Name = "treeView1"
         Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node5"), New System.Windows.Forms.TreeNode("Node6"), New System.Windows.Forms.TreeNode("Node7")}), New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node8"), New System.Windows.Forms.TreeNode("Node9"), New System.Windows.Forms.TreeNode("Node10")}), New System.Windows.Forms.TreeNode("Node2", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node11"), New System.Windows.Forms.TreeNode("Node12"), New System.Windows.Forms.TreeNode("Node13")}), New System.Windows.Forms.TreeNode("Node3", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node14", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node15")}), New System.Windows.Forms.TreeNode("Node16"), New System.Windows.Forms.TreeNode("Node17")}), New System.Windows.Forms.TreeNode("Node4", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node18", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node19", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node20", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node21")})})})})})
         Me.treeView1.SelectedImageIndex = - 1
         Me.treeView1.Size = New System.Drawing.Size(128, 224)
         Me.treeView1.TabIndex = 0
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(8, 240)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 1
         Me.button1.Text = "Move ->"
         ' 
         ' treeView2
         ' 
         Me.treeView2.ImageIndex = - 1
         Me.treeView2.Location = New System.Drawing.Point(144, 8)
         Me.treeView2.Name = "treeView2"
         Me.treeView2.SelectedImageIndex = - 1
         Me.treeView2.Size = New System.Drawing.Size(144, 224)
         Me.treeView2.TabIndex = 2
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(192, 240)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(96, 23)
         Me.button2.TabIndex = 3
         Me.button2.Text = "Delete [0] Node"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.treeView2, Me.button1, Me.treeView1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      <STAThread()>Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      
' <snippet1>
Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
   ' If neither TreeNodeCollection is read-only, move the 
   ' selected node from treeView1 to treeView2. 
   If Not treeView1.Nodes.IsReadOnly And Not treeView2.Nodes.IsReadOnly Then
      If (treeView1.SelectedNode IsNot Nothing) Then
         Dim tn As TreeNode = treeView1.SelectedNode
         treeView1.Nodes.Remove(tn)
         treeView2.Nodes.Insert(treeView2.Nodes.Count, tn)
      End If
   End If
End Sub
' </snippet1>

' <snippet2>
Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
   ' Delete the first TreeNode in the collection 
   ' if the Text property is "Node0." 
   If Me.treeView1.Nodes(0).Text = "Node0" Then
      Me.treeView1.Nodes.RemoveAt(0)
   End If
End Sub
' </snippet2>

   End Class 'Form1 
End Namespace 'ToolBarStuff