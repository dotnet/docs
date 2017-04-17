' System.Windows.Forms.TreeNodeCollection.Contains()
' System.Windows.Forms.TreeNodeCollection.GetEnumerator()

' The following program demonstrates 'Contains' and 'GetEnumerator'
' methods of 'System.Windows.Forms.TreeNodeCollection' class. It
' creates a TreeView with two TreeNodes and gets the collection of
' TreeNodes. It checks for a TreeNode in the collection and also
' gets an Enumerator to iterate through the collection.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports MicroSoft.VisualBasic

Public Class MyForm
   Inherits Form
   Private myTreeView As TreeView
   Private myTreeNode1 As TreeNode
   Private myTreeNode2 As TreeNode
   Private myLabel As Label
   Private components As Container = Nothing

   Public Sub New()
      InitializeComponent()
   End Sub 'New

   Protected Overloads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose

   Private Sub InitializeComponent()
      Me.myTreeView = New TreeView()
      Me.myLabel = New Label()
      Me.SuspendLayout()
      '
      ' myTreeView
      '
      Me.myTreeView.ImageIndex = - 1
      Me.myTreeView.Name = "treeView1"
      Me.myTreeView.SelectedImageIndex = - 1
      Me.myTreeView.TabIndex = 0
      ' Create TreeNodes.
      myTreeNode1 = New TreeNode("Node1")
      myTreeNode2 = New TreeNode("Node2")
      Me.myTreeView.Nodes.AddRange(New TreeNode() {myTreeNode1, myTreeNode2})
      '
      ' myLabel
      '
      Me.myLabel.Location = New Point(8, 136)
      Me.myLabel.Name = "myLabel"
      Me.myLabel.Size = New Size(248, 112)
      Me.myLabel.TabIndex = 1
      '
      ' MyForm
      '
      Me.ClientSize = New Size(292, 273)
      Me.Controls.AddRange(New Control() {Me.myLabel, Me.myTreeView})
      Me.Name = "MyForm"
      Me.Text = "MyForm"
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent

<STAThread()>  _
      Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main

   Private Sub MyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
	EnumerateTreeNodes()
   End Sub 'MyForm_Load

 ' <snippet2>
 ' <snippet1>
Private Sub EnumerateTreeNodes()
   Dim myNodeCollection As TreeNodeCollection = myTreeView.Nodes
   ' Check for a node in the collection.
   If myNodeCollection.Contains(myTreeNode2) Then
      myLabel.Text += "Node2 is at index: " + myNodeCollection.IndexOf(myTreeNode2)
   End If
   myLabel.Text += ControlChars.Cr + ControlChars.Cr + _
     "Elements of the TreeNodeCollection:" + ControlChars.Cr
   
   ' Create an enumerator for the collection.
   Dim myEnumerator As IEnumerator = myNodeCollection.GetEnumerator()
   While myEnumerator.MoveNext()
      myLabel.Text += CType(myEnumerator.Current, TreeNode).Text + ControlChars.Cr
   End While
End Sub 
' </snippet1>
' </snippet2>


End Class 'MyForm