' System.Windows.Forms.TreeNode.Expand()
' System.Windows.Forms.TreeNode.Collapse()
' System.Windows.Forms.TreeNode.EnsureVisible()
' System.Windows.Forms.TreeNode.Clone()

' The following program demonstrates 'Expand', 'Collapse',
' 'EnsureVisible' and 'Clone' methods of 'System.Windows.Forms.TreeNode'
' class. It creates a TreeView, adds 10 TreeNode objects to it and
' expands node1,collapses node1 and makes a clone to Node 9 and add it to Node7.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace MyTreeNode
   Public Class Form1
      Inherits Form
      Private treeView1 As TreeView
      Private myCustomerList As New ArrayList()
      Private WithEvents button1 As Button
      Private WithEvents button2 As Button
      Private WithEvents button3 As Button
      Private WithEvents button4 As Button
      Private components As Container = Nothing

      Public Sub New()
         ' Required for Windows Form Designer support.
         InitializeComponent()
         AddTreeNode()
      End Sub 'New

      ' Clean up any resources being used.
      Protected Overrides Overloads Sub Dispose(disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose

      ' The main entry point for the application.
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main

      ' Required method for Designer support.
      Private Sub InitializeComponent()
         Me.treeView1 = New TreeView()
         Me.button1 = New Button()
         Me.button2 = New Button()
         Me.button3 = New Button()
         Me.button4 = New Button()
         Me.SuspendLayout()

         Me.treeView1.ImageIndex = - 1
         Me.treeView1.Location = New Point(32, 48)
         Me.treeView1.Name = "treeView1"
         Me.treeView1.SelectedImageIndex = - 1
         Me.treeView1.Size = New Size(168, 96)
         Me.treeView1.TabIndex = 0

         Me.button1.Location = New Point(40, 160)
         Me.button1.Name = "button1"
         Me.button1.Size = New Size(160, 23)
         Me.button1.TabIndex = 1
         Me.button1.Text = "Expand Customer1 Node"

         Me.button2.Location = New Point(40, 185)
         Me.button2.Name = "button2"
         Me.button2.Size = New Size(160, 23)
         Me.button2.TabIndex = 2
         Me.button2.Text = "Collapse Customer1 Node"

         Me.button3.Location = New Point(40, 210)
         Me.button3.Name = "button3"
         Me.button3.Size = New Size(160, 23)
         Me.button3.TabIndex = 3
         Me.button3.Text = "EnsureVisible Order7 Node"

         Me.button4.Location = New Point(40, 235)
         Me.button4.Name = "button4"
         Me.button4.Size = New Size(160, 23)
         Me.button4.TabIndex = 4
         Me.button4.Text = "Clone Customer9 Node"

         Me.ClientSize = New Size(240, 273)
         Me.Controls.AddRange(New Control() {Me.button4, Me.button3, Me.button2, Me.button1, _
                                                                              Me.treeView1})
         Me.Name = "Form1"
         Me.Text = "Demonstrating TreeNode members"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent


      ' Add TreeNode to the TreeView.
      Private Sub AddTreeNode()
         ' Add customers to ArrayList of Customer objects.
         Dim i As Integer
         For i = 1 To 10
            myCustomerList.Add(New Customer("Customer" + i.ToString()))
         Next i

         ' Add orders to each Customer object in the ArrayList.
         Dim x As Integer = 1
         Dim Customer1 As Customer
         For Each Customer1 In  myCustomerList
            Customer1.MyOrders.Add(New Order("Order" + x.ToString()))
            x += 1
         Next Customer1

         ' Prevent repainting of TreeView until all objects have been created.
         treeView1.BeginUpdate()

         ' Clear the TreeView each time the method is called.
         treeView1.Nodes.Clear()

         ' Add a root TreeNode for each Customer object in the ArrayList.
         Dim Customer2 As Customer
         For Each Customer2 In  myCustomerList
            treeView1.Nodes.Add(New TreeNode(Customer2.myCustomerName))

            ' Add a child TreeNode to each Customer TreeNode.
            Dim Order2 As Order
            For Each Order2 In  Customer2.MyOrders
               treeView1.Nodes(myCustomerList.IndexOf(Customer2)).Nodes.Add(New TreeNode _
                                                                     (Order2.myOrderName))
            Next Order2
         Next Customer2
      End Sub 'AddTreeNode

' <Snippet1>
Private Sub button1_Click(sender As Object, _
  e As System.EventArgs) Handles button1.Click
   If treeView1.SelectedNode.IsExpanded Then
      treeView1.SelectedNode.Collapse()
      MessageBox.Show(treeView1.SelectedNode.Text & _ 
        " tree node collapsed.")
   Else
      treeView1.SelectedNode.Expand()
      MessageBox.Show(treeView1.SelectedNode.Text & _
        " tree node expanded.")
   End If
End Sub 
' </Snippet1>


' <Snippet2>
Private Sub button3_Click(sender As Object, _
  e As System.EventArgs) Handles button3.Click
   Dim lastNode as TreeNode
   lastNode = treeView1.Nodes(treeView1.Nodes.Count - 1). _
     Nodes(treeView1.Nodes(treeView1.Nodes.Count - 1).Nodes.Count - 1)

   If Not lastNode.IsVisible Then
      lastNode.EnsureVisible()
      MessageBox.Show(lastNode.Text & _
        " tree node is visible.")
   End If
End Sub
' </Snippet2>


' <Snippet3>
Private Sub button4_Click(sender As Object, _
  e As System.EventArgs) Handles button4.Click
   Dim lastNode as TreeNode
   lastNode = treeView1.Nodes(treeView1.Nodes.Count - 1). _
     Nodes(treeView1.Nodes(treeView1.Nodes.Count - 1).Nodes.Count - 1)

   ' Clone the last child node.
   Dim clonedNode As TreeNode = CType(lastNode.Clone(), TreeNode)

   ' Insert the cloned node as the first root node.
   treeView1.Nodes.Insert(0, clonedNode)
   MessageBox.Show(lastNode.Text & _
     " tree node cloned and added to " & treeView1.Nodes(0).Text)
End Sub
' </Snippet3>


   End Class 'Form1


   ' Define a Customer Class.
   Public Class Customer
      Public myCustomerName As String
      Public MyOrders As New ArrayList()

      Public Sub New(name As String)
         myCustomerName = name
      End Sub 'New
   End Class 'Customer

   ' Define an Order Class which will be associated to a customer.
   Public Class Order
      Public myOrderName As String

      Public Sub New(name1 As String)
         myOrderName = name1
      End Sub 'New
   End Class 'Order
End Namespace 'MyTreeNode