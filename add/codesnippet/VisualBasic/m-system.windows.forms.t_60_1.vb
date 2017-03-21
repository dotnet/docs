      Public Class Customer
         Inherits [Object]
         Private custName As String = ""
         Friend custOrders As New ArrayList()

         Public Sub New(ByVal customername As String)
            Me.custName = customername
         End Sub

         Public Property CustomerName() As String
            Get
               Return Me.custName
            End Get
            Set(ByVal Value As String)
               Me.custName = Value
            End Set
         End Property

         Public ReadOnly Property CustomerOrders() As ArrayList
            Get
               Return Me.custOrders
            End Get
         End Property
      End Class 'End Customer class


      Public Class Order
         Inherits [Object]
         Private ordID As String

         Public Sub New(ByVal orderid As String)
            Me.ordID = orderid
         End Sub 'New

         Public Property OrderID() As String
            Get
               Return Me.ordID
            End Get
            Set(ByVal Value As String)
               Me.ordID = Value
            End Set
         End Property
      End Class ' End Order class

      ' Create a new ArrayList to hold the Customer objects.
      Private customerArray As New ArrayList()

      Private Sub FillMyTreeView()
         ' Add customers to the ArrayList of Customer objects.
         Dim x As Integer
         For x = 0 To 999
            customerArray.Add(New Customer("Customer" + x.ToString()))
         Next x

         ' Add orders to each Customer object in the ArrayList.
         Dim customer1 As Customer
         For Each customer1 In customerArray
            Dim y As Integer
            For y = 0 To 14
               customer1.CustomerOrders.Add(New Order("Order" + y.ToString()))
            Next y
         Next customer1

         ' Display a wait cursor while the TreeNodes are being created.
         Cursor.Current = New Cursor("MyWait.cur")

         ' Suppress repainting the TreeView until all the objects have been created.
         treeView1.BeginUpdate()

         ' Clear the TreeView each time the method is called.
         treeView1.Nodes.Clear()

         ' Add a root TreeNode for each Customer object in the ArrayList.
         Dim customer2 As Customer
         For Each customer2 In customerArray
            treeView1.Nodes.Add(New TreeNode(customer2.CustomerName))

            ' Add a child TreeNode for each Order object in the current Customer object.
            Dim order1 As Order
            For Each order1 In customer2.CustomerOrders
               treeView1.Nodes(customerArray.IndexOf(customer2)).Nodes.Add( _
          New TreeNode(customer2.CustomerName + "." + order1.OrderID))
            Next order1
         Next customer2

         ' Reset the cursor to the default for all controls.
         Cursor.Current = System.Windows.Forms.Cursors.Default

         ' Begin repainting the TreeView.
         treeView1.EndUpdate()
      End Sub 'FillMyTreeView