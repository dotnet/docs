' System.Windows.Forms.TreeNode.ImageIndex
' System.Windows.Forms.TreeNode.SelectedImageIndex
' System.Windows.Forms.TreeView.ImageIndex
' System.Windows.Forms.TreeView.SelectedImageIndex
' System.Windows.Forms.TreeView.ImageList
' System.Windows.Forms.TreeNode.TreeNode(string,int,int)
' System.Windows.Forms.TreeNode.TreeNode(string,int,int,TreeNode[])

'   The following example demonstrates the constructors 
'   TreeNode(string,int,int)' and 'TreeNode(string,int,int,TreeNode[])' of 
'   the 'TreeNode' class. This example displays customerinformation in a
'   TreeView' control. The root tree nodes display customer names, and the
'   child tree nodes display the order numbers assigned to each customer. 


Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms





Public Class TreeNode_Checked
   Inherits Form
   Private rootImageIndex As Integer
   Private selectedCustomerImageIndex As Integer
   Private unselectedCustomerImageIndex As Integer
   Private selectedOrderImageIndex As Integer
   Private unselectedOrderImageIndex As Integer
   Private myTreeView As TreeView
   
   
   Public Sub New()
      InitializeComponent()
      FillMyTreeView()
   End Sub 'New
   ' ArrayList object to hold the 'Customer' objects.
   Private customerArray As New ArrayList()
   
   
   Private Sub FillMyTreeView()
      ' Add customers to the ArrayList of 'Customer' objects.
      Dim xIndex As Integer
      For xIndex = 1 To 5
         customerArray.Add(New Customer("Customer" + xIndex.ToString()))
      Next xIndex
      
      ' Add orders to each 'Customer' object in the ArrayList.
      Dim customer1 As Customer
      For Each customer1 In  customerArray
         Dim yIndex As Integer
         For yIndex = 1 To 5
            customer1.CustomerOrders.Add(New Order("Order" + yIndex.ToString()))
         Next yIndex
      Next customer1
      ' Supress repainting of the TreeView.
      myTreeView.BeginUpdate()
      
      ' Clear the TreeView each time the method is called.
      myTreeView.Nodes.Clear()
      
      FillTreeView()
      
      ' Begin repainting the TreeView.
      myTreeView.EndUpdate()
   End Sub 'FillMyTreeView
   
   
   
' <Snippet1>  
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
' </Snippet1>  
   
   Private Sub InitializeComponent()
      Me.myTreeView = New TreeView()
      Me.SuspendLayout()
      Me.myTreeView.ImageIndex = - 1
      Me.myTreeView.Location = New Point(8, 0)
      Me.myTreeView.Name = "myTreeView"
      Me.myTreeView.SelectedImageIndex = - 1
      Me.myTreeView.Size = New Size(280, 152)
      Me.myTreeView.TabIndex = 0
      Me.ClientSize = New Size(292, 273)
      Me.Controls.Add(myTreeView)
      Me.Name = "Form1"
      Me.Text = "TreeNode Example"
      Me.ResumeLayout(True)
   End Sub 'InitializeComponent
   
   
   Shared Sub Main()
      Application.Run(New TreeNode_Checked())
   End Sub 'Main
End Class 'TreeNode_Checked