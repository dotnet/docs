' System.Windows.Forms.TreeNodeCollection.Count
' System.Windows.Forms.TreeNodeCollection.CopyTo()

' The following program demonstrates 'Count' property and 'CopyTo'
' method of 'System.Windows.Forms.TreeNodeCollection' class. It
' creates a TreeView with two TreeNodes and gets the collection of
' TreeNodes. It copies the collection into an array
' and displays the count of the collection and the elements of the
' array.

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
      ' Add TreeNodes.
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
   Shared  Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main


   Private Sub MyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
     CopyTreeNodes()
   End Sub


' <Snippet2>
' <Snippet1>
Private Sub CopyTreeNodes()
   ' Get the collection of TreeNodes.
   Dim myNodeCollection As TreeNodeCollection = myTreeView.Nodes
   Dim myCount As Integer = myNodeCollection.Count

   myLabel.Text += "Number of nodes in the collection :" + myCount.ToString()

   myLabel.Text += ControlChars.NewLine + ControlChars.NewLine + _
     "Elements of the Array after Copying from the collection :" + ControlChars.NewLine

   ' Create an Object array.
   Dim myArray(myCount -1) As Object

   ' Copy the collection into an array.
   myNodeCollection.CopyTo(myArray, 0)
   Dim i As Integer
   For i = 0 To myArray.Length - 1
      myLabel.Text += CType(myArray(i), TreeNode).Text + ControlChars.NewLine
   Next i
End Sub
' </Snippet1>
' </Snippet2>






End Class 'MyForm