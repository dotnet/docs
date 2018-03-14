' System.Windows.Forms.TreeNode.Checked
' System.Windows.Forms.TreeNode.BackColor

' The following example demonstrates the properties 'Checked' and
' 'BackColor' of the 'TreeNode' class. This example displays customer
' information in a 'TreeView' control. The root tree nodes display 
' customer names, and the child tree nodes display the order numbers 
' assigned to each customer. It also displays selected nodes in a
' messagebox.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms

Public Class Customer
   Public CustomerOrders As ArrayList
   Public CustomerName As String
   Public Sub New(myName As String)
      CustomerName = myName
      CustomerOrders = New ArrayList()
   End Sub 'New
End Class 'Customer

Public Class Order
   Public OrderID As String
   Public Sub New(myOrderID As String)
      Me.OrderID = myOrderID
   End Sub 'New
End Class 'Order

Public Class TreeNode_Bounds
   Inherits Form
   Private myTreeView As TreeView
   Private myButton As Button
   Public Sub New()
      InitializeComponent()
      FillMyTreeView()
   End Sub 'New
   ' ArrayList object to hold the Customer objects.
   Private customerArray As New ArrayList()
   Private rootNode As TreeNode

   Private Sub FillMyTreeView()
      ' Add customers to the ArrayList of 'Customer' objects.
      Dim x As Integer
      For x = 1 To 5
         customerArray.Add(New Customer("Customer" + x.ToString()))
      Next x

      ' Add orders to each 'Customer' object in the ArrayList.
      Dim customer1 As Customer
      For Each customer1 In  customerArray
         Dim y As Integer
         For y = 1 To 5
            customer1.CustomerOrders.Add(New Order("Order" + y.ToString()))
         Next y
      Next customer1
      ' Supress repainting of the TreeView.
      myTreeView.BeginUpdate()

      ' Clear the TreeView each time the method is called.
      myTreeView.Nodes.Clear()
      rootNode = New TreeNode()
      rootNode.Text = "CustomerList"

      ' Add a main root treenode.
      myTreeView.Nodes.Add(rootNode)
      myTreeView.CheckBoxes = True

      ' Add a root treenode for each 'Customer' object in the ArrayList.
      Dim myCustomer As Customer
      For Each myCustomer In  customerArray
         ' Add a child treenode for each 'Order' object.
         Dim countIndex As Integer = 0
         Dim myTreeNodeArray(4) As TreeNode
         Dim myOrder As Order
         For Each myOrder In  myCustomer.CustomerOrders
            myTreeNodeArray(countIndex) = New TreeNode(myOrder.OrderID)
            countIndex += 1
         Next myOrder
         Dim customerNode As New TreeNode(myCustomer.CustomerName, myTreeNodeArray)
         myTreeView.Nodes(0).Nodes.Add(customerNode)
      Next myCustomer

      ' Begin repainting the TreeView.
      myTreeView.EndUpdate()
   End Sub 'FillMyTreeView


' <Snippet1>
Public Sub HighlightCheckedNodes()
   Dim countIndex As Integer = 0
   Dim selectedNode As String = "Selected customer nodes are : "
   Dim myNode As TreeNode
   For Each myNode In  myTreeView.Nodes(0).Nodes
      ' Check whether the tree node is checked.
      If myNode.Checked Then
         ' Set the node's backColor.
         myNode.BackColor = Color.Yellow
         selectedNode += myNode.Text + " "
         countIndex += 1
      Else
         myNode.BackColor = Color.White
      End If
   Next myNode

   If countIndex > 0 Then
      MessageBox.Show(selectedNode)
   Else
      MessageBox.Show("No nodes are selected")
   End If
End Sub
' </Snippet1>


   Private Sub MyButton_Click(sender As Object, e As EventArgs)
      HighlightCheckedNodes()
   End Sub



   Private Sub InitializeComponent()
      Me.myTreeView = New System.Windows.Forms.TreeView()
      Me.SuspendLayout()
      Me.myTreeView.ImageIndex = - 1
      Me.myTreeView.Location = New System.Drawing.Point(8, 0)
      Me.myTreeView.Name = "myTreeView"
      Me.myTreeView.SelectedImageIndex = - 1
      Me.myTreeView.Size = New Size(280, 152)
      Me.myTreeView.TabIndex = 0
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.myButton = New Button()
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.myButton, Me.myTreeView})
      Me.myButton.Location = New Point(80, 200)
      Me.myButton.Size = New Size(140, 25)
      Me.myButton.Text = "Display Selected Nodes"
      AddHandler Me.myButton.Click, AddressOf MyButton_Click
      Me.Text = "TreeNode Example"
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent

   Shared Sub Main()
      Application.Run(New TreeNode_Bounds())
   End Sub 'Main
End Class 'TreeNode_Bounds
