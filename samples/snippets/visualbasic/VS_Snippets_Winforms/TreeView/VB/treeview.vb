Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace CustomerCodeExamples

   Public Class TV1
      Inherits System.Windows.Forms.Form
      Private treeView1 As System.Windows.Forms.TreeView
      Private button1 As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container

      Public Sub New()
         InitializeComponent()
      End Sub

      <System.STAThreadAttribute()>  _
      Public Shared Sub Main()
         System.Windows.Forms.Application.Run(New TV1)
      End Sub

      Private Sub InitializeComponent()
         Me.treeView1 = New System.Windows.Forms.TreeView()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' treeView1
         ' 
         Me.treeView1.ImageIndex = -1
         Me.treeView1.Name = "treeView1"
         Me.treeView1.SelectedImageIndex = -1
         Me.treeView1.Size = New System.Drawing.Size(128, 240)
         Me.treeView1.TabIndex = 0
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(216, 248)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 1
         Me.button1.Text = "button1"
         AddHandler Me.button1.Click, AddressOf Me.button1_Click
         ' 
         ' TV1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.treeView1})
         Me.Name = "TV1"
         Me.Text = "TV1"
         Me.ResumeLayout(False)
         Me.components = New System.ComponentModel.Container()
      End Sub 'InitializeComponent

      '<snippet1>
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
      '</snippet1>      


      Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         Me.FillMyTreeView()
      End Sub 'button1_Click

   End Class 'TV1


   


End Namespace 'TreeView