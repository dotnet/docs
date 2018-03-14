Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Namespace Foo

   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents treeView1 As System.Windows.Forms.TreeView
      Private WithEvents statusBar1 As System.Windows.Forms.StatusBar
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New

'      Protected Overrides Sub Dispose(disposing As Boolean)
'         If disposing Then
'            If (components IsNot Nothing) Then
'               components.Dispose()
'            End If
'         End If
'         MyBase.Dispose(disposing)
'      End Sub 'Dispose
      
      Private Sub InitializeComponent()
         Me.treeView1 = New System.Windows.Forms.TreeView()
         Me.statusBar1 = New System.Windows.Forms.StatusBar()
         Me.SuspendLayout()
         ' 
         ' treeView1
         ' 
         Me.treeView1.ImageIndex = - 1
         Me.treeView1.Location = New System.Drawing.Point(8, 8)
         Me.treeView1.Name = "treeView1"
         Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node3", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node4", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node5")})})}), New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node6", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node7", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node8")})})}), New System.Windows.Forms.TreeNode("Node2", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node9", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node10", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node11")})})})})
         Me.treeView1.SelectedImageIndex = - 1
         Me.treeView1.Size = New System.Drawing.Size(128, 144)
         Me.treeView1.TabIndex = 0
         ' 
         ' statusBar1
         ' 
         Me.statusBar1.Location = New System.Drawing.Point(0, 247)
         Me.statusBar1.Name = "statusBar1"
         Me.statusBar1.Size = New System.Drawing.Size(256, 22)
         Me.statusBar1.TabIndex = 2
         Me.statusBar1.Text = "statusBar1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(256, 269)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.statusBar1, Me.treeView1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      <STAThread()>Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      
' <snippet1>
Private Sub treeView1_MouseDown(sender As Object, _
  e As MouseEventArgs) Handles treeView1.MouseDown
   Select Case e.Button
      ' Remove the TreeNode under the mouse cursor 
      ' if the right mouse button was clicked. 
      Case MouseButtons.Right
         treeView1.GetNodeAt(e.X, e.Y).Remove()
      
      ' Toggle the TreeNode under the mouse cursor 
      ' if the middle mouse button (mouse wheel) was clicked. 
      Case MouseButtons.Middle
         treeView1.GetNodeAt(e.X, e.Y).Toggle()
   End Select
End Sub
' </snippet1>

'<snippet2>
Private Sub treeView1_AfterSelect(sender As Object, _
  e As TreeViewEventArgs) Handles treeView1.AfterSelect
   ' Display the Text and Index of the 
   ' selected tree node's Parent. 
   If (e.Node.Parent IsNot Nothing) 
      If (e.Node.Parent.GetType() Is GetType(TreeNode)) Then
         statusBar1.Text = "Parent: " + e.Node.Parent.Text + _
           ControlChars.Cr + "Index Position: " + e.Node.Parent.Index.ToString()
      End If
   Else
      statusBar1.Text = "No parent node."
   End If
End Sub 
' </snippet2>

' <snippet3>
Private Sub treeView1_AfterCollapse(sender As Object, _
  e As TreeViewEventArgs) Handles treeView1.AfterCollapse
   ' Create a copy of the e.Node from its Handle.
   Dim tn As TreeNode = TreeNode.FromHandle(e.Node.TreeView, e.Node.Handle)
   tn.Text += "Copy"
   ' Remove the e.Node so it can be replaced with tn.
   e.Node.Remove()
   ' Add tn to the TreeNodeCollection.
   treeView1.Nodes.Add(tn)
End Sub 
' </snippet3>

   End Class 'Form1 
End Namespace 'Foo




