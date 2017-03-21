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

Private Sub FillTreeView()
   ' Load the images in an ImageList.
   Dim myImageList As New ImageList()
   myImageList.Images.Add(Image.FromFile("Default.gif"))
   myImageList.Images.Add(Image.FromFile("SelectedDefault.gif"))
   myImageList.Images.Add(Image.FromFile("Root.gif"))
   myImageList.Images.Add(Image.FromFile("UnselectedCustomer.gif"))
   myImageList.Images.Add(Image.FromFile("SelectedCustomer.gif"))
   myImageList.Images.Add(Image.FromFile("UnselectedOrder.gif"))
   myImageList.Images.Add(Image.FromFile("SelectedOrder.gif"))
   
   ' Assign the ImageList to the TreeView.
   myTreeView.ImageList = myImageList
   
   ' Set the TreeView control's default image and selected image indexes.
   myTreeView.ImageIndex = 0
   myTreeView.SelectedImageIndex = 1
   
   ' Set the index of image from the 
   ' ImageList for selected and unselected tree nodes.
   Me.rootImageIndex = 2
   Me.selectedCustomerImageIndex = 3
   Me.unselectedCustomerImageIndex = 4
   Me.selectedOrderImageIndex = 5
   Me.unselectedOrderImageIndex = 6
   
   ' Create the root tree node.
   Dim rootNode As New TreeNode("CustomerList")
   rootNode.ImageIndex = rootImageIndex
   rootNode.SelectedImageIndex = rootImageIndex
   
   ' Add a main root tree node.
   myTreeView.Nodes.Add(rootNode)
   
   ' Add a root tree node for each Customer object in the ArrayList.
   Dim myCustomer As Customer
   For Each myCustomer In  customerArray
      ' Add a child tree node for each Order object.
      Dim countIndex As Integer = 0
      Dim myTreeNodeArray(myCustomer.CustomerOrders.Count) As TreeNode
      Dim myOrder As Order
      For Each myOrder In  myCustomer.CustomerOrders
         ' Add the Order tree node to the array.
         myTreeNodeArray(countIndex) = New TreeNode(myOrder.OrderID, _
            unselectedOrderImageIndex, selectedOrderImageIndex)
         countIndex += 1
      Next myOrder
      ' Add the Customer tree node.
      Dim customerNode As New TreeNode(myCustomer.CustomerName, _
         unselectedCustomerImageIndex, selectedCustomerImageIndex, myTreeNodeArray)
      myTreeView.Nodes(0).Nodes.Add(customerNode)
   Next myCustomer
End Sub