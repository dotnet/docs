
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic


Namespace TN_Checked
    
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents treeView1 As System.Windows.Forms.TreeView
      Private WithEvents button1 As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 
      
      
'      Protected Overrides Sub Dispose(disposing As Boolean)
'         If disposing Then
'            If (components IsNot Nothing) Then
'               components.Dispose()
'            End If
'         End If
'         MyBase.Dispose(disposing)
'      End Sub 
      
      
      Private Sub InitializeComponent()
         Me.treeView1 = New System.Windows.Forms.TreeView()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' treeView1
         ' 
         Me.treeView1.CheckBoxes = True
         Me.treeView1.ImageIndex = - 1
         Me.treeView1.Location = New System.Drawing.Point(8, 8)
         Me.treeView1.Name = "treeView1"
         Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node2", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node3")}), New System.Windows.Forms.TreeNode("Node5")})})})
         
         Me.treeView1.SelectedImageIndex = - 1
         Me.treeView1.TabIndex = 0
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(24, 128)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(72, 24)
         Me.button1.TabIndex = 1
         Me.button1.Text = "button1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(200, 229)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.treeView1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 
       
      
      
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub


      
      
'<snippet1>
' Updates all child tree nodes recursively.
Private Sub CheckAllChildNodes(treeNode As TreeNode, nodeChecked As Boolean)
   Dim node As TreeNode
   For Each node In  treeNode.Nodes 
      node.Checked = nodeChecked
      If node.Nodes.Count > 0 Then
         ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
         Me.CheckAllChildNodes(node, nodeChecked)
      End If
   Next node
End Sub
      
' NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
' After a tree node's Checked property is changed, all its child nodes are updated to the same value.
Private Sub node_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeView1.AfterCheck
   ' The code only executes if the user caused the checked state to change.
   If e.Action <> TreeViewAction.Unknown Then 
      If e.Node.Nodes.Count > 0 Then
         ' Calls the CheckAllChildNodes method, passing in the current 
         ' Checked value of the TreeNode whose checked state changed. 
         Me.CheckAllChildNodes(e.Node, e.Node.Checked)
      End If
   End If
End Sub 
'</snippet1>
 

     
      Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
         Me.treeView1.Nodes(0).Nodes(0).Checked = True
      End Sub 
      
      
      Private Sub treeView1_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles treeView1.BeforeCheck
         MessageBox.Show(e.Node.ToString() + ControlChars.Lf + e.Action.ToString(), "BeforeCheck")
      End Sub 
   End Class 
End Namespace