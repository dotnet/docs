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

Public Sub AddRootNodes()
   ' Add a root node to assign the customer nodes to.
   Dim rootNode As TreeNode
   rootNode = New TreeNode()
   rootNode.Text = "CustomerList"
   ' Add a main root treenode.
   myTreeView.Nodes.Add(rootNode)

   ' Add a root treenode for each Customer object in the ArrayList.
   Dim myCustomer As Customer
   For Each myCustomer In customerArray
      ' Add a child treenode for each Order object.
      Dim i As Integer = 0
      Dim myTreeNodeArray(4) As TreeNode
      Dim myOrder As Order
      For Each myOrder In  myCustomer.CustomerOrders
         myTreeNodeArray(i) = New TreeNode(myOrder.OrderID)
         i += 1
      Next myOrder
      Dim customerNode As New TreeNode(myCustomer.CustomerName, _
        myTreeNodeArray)
      ' Display the customer names with and Orange font.
      customerNode.ForeColor = Color.Orange
      ' Store the Customer object in the Tag property of the TreeNode.
      customerNode.Tag = myCustomer
      myTreeView.Nodes(0).Nodes.Add(customerNode)
   Next myCustomer
End Sub