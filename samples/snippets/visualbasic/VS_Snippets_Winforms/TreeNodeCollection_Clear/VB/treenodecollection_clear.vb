' System.Windows.Forms.TreeNodeCollection.Clear
' System.Windows.Forms.TreeNodeCollection.AddRange

' The following program demonstrates the 'Clear' and 'AddRange' methods of 
' the 'TreeNodeCollection' class. It creates two 'TreeView' objects, the first 
' object contains the customer list and the second object is empty. The user
' is provided with the option to add or remove a 'TreeNode'.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public Class myTreeNodeCollectionForm
   Inherits Form
   Private myButtonAddAll As Button
   Private myButtonAdd As Button
   Private myTreeViewBase As TreeView
   Private myTreeViewCustom As TreeView
   Private myButtonRemoveAll As Button
   
   Public Sub New()
      InitializeComponent()
      FillMyTreeView()
      AddHandler myButtonAddAll.Click, AddressOf MyButtonAddAllClick
      AddHandler myButtonAdd.Click, AddressOf MyButtonAddClick
      AddHandler myButtonRemoveAll.Click, AddressOf MyButtonRemoveAllClick
   End Sub 'New

' <Snippet2>
' <Snippet1>
Private Sub MyButtonAddAllClick(sender As Object, e As EventArgs)
   ' Get the 'myTreeNodeCollection' from the 'myTreeViewBase' TreeView.
   Dim myTreeNodeCollection As TreeNodeCollection = myTreeViewBase.Nodes
   ' Create an array of 'TreeNodes'.
   Dim myTreeNodeArray(myTreeViewBase.Nodes.Count-1) As TreeNode
   ' Copy the tree nodes to the 'myTreeNodeArray' array.
   myTreeViewBase.Nodes.CopyTo(myTreeNodeArray, 0)
   ' Remove all the tree nodes from the 'myTreeViewBase' TreeView.
   myTreeViewBase.Nodes.Clear()
   ' Add the 'myTreeNodeArray' to the 'myTreeViewCustom' TreeView.
      myTreeViewCustom.Nodes.AddRange(myTreeNodeArray)
End Sub
' </Snippet1>
' </Snippet2>


   Private Sub MyButtonRemoveAllClick(sender As Object, e As EventArgs)
      ' Get the 'myTreeNodeCollection' from the 'myTreeViewCustom' TreeView.
      Dim myTreeNodeCollection As TreeNodeCollection = myTreeViewCustom.Nodes
      ' Create an array of 'TreeNodes'.
      Dim myTreeNodeArray(myTreeViewCustom.Nodes.Count-1) As TreeNode
      ' Copy the tree nodes to the 'myTreeNodeArray' array.
      myTreeViewCustom.Nodes.CopyTo(myTreeNodeArray, 0)
      ' Remove all the tree nodes from the 'myTreeViewCustom' TreeView.
      myTreeViewCustom.Nodes.Clear()
      ' Add the 'myTreeNodeArray' to the 'myTreeViewBase' TreeView.
      myTreeViewBase.Nodes.AddRange(myTreeNodeArray)
   End Sub 'MyButtonRemoveAllClick
   
   Private Sub MyButtonAddClick(sender As Object, e As EventArgs)
      Dim myTreeNodeCollection As TreeNodeCollection = myTreeViewBase.Nodes
      Dim myTreeNode As TreeNode
      For Each myTreeNode In  myTreeNodeCollection
         If myTreeNode.IsSelected = True Then
            ' Remove the selected node from the 'myTreeViewBase' TreeView.
            myTreeViewBase.Nodes.Remove(myTreeNode)
            ' Add the selected node to the 'myTreeViewCustom' TreeView.
            myTreeViewCustom.Nodes.Add(myTreeNode)
         End If
      Next myTreeNode
   End Sub 'MyButtonAddClick
   
   Private Sub FillMyTreeView()
      Dim customerArray As New ArrayList()
      ' Add customers to the ArrayList of 'MyCustomerClass' objects.
      Dim x As Integer
      For x = 1 To 10
         customerArray.Add(New MyCustomerClass("Customer" + x.ToString()))
      Next x
      
      ' Add orders to each 'MyCustomerClass' object in the ArrayList.
      Dim myCustomerClass1 As MyCustomerClass
      For Each myCustomerClass1 In  customerArray
         Dim y As Integer
         For y = 1 To 5
            myCustomerClass1.CustomerOrders.Add(New MyOrder("Order" + y.ToString()))
         Next y
      Next myCustomerClass1
      
      ' Supress repainting until all the objects have been created.
      myTreeViewBase.BeginUpdate()
      
      ' Clear the 'TreeView' each time the method is called.
      myTreeViewBase.Nodes.Clear()
      Dim myTreeNodeCollectionCustomer As TreeNodeCollection = myTreeViewBase.Nodes
      ' Add a root treenode for each 'MyCustomerClass' object in the ArrayList.
      Dim myCustomerClass2 As MyCustomerClass
      For Each myCustomerClass2 In  customerArray
         myTreeNodeCollectionCustomer.Add(New TreeNode(myCustomerClass2.CustomerName))
         Dim myTreeNodeCollectionOrders As TreeNodeCollection = myTreeNodeCollectionCustomer _
                                          (customerArray.IndexOf(myCustomerClass2)).Nodes
         ' Add a child treenode for each 'MyOrder' object.
         Dim myOrder1 As MyOrder
         For Each myOrder1 In  myCustomerClass2.CustomerOrders
            myTreeNodeCollectionOrders.Add(New TreeNode(myOrder1.OrderID))
            Dim myTreeNodeOrder As TreeNode = myTreeNodeCollectionOrders _
                                       (myCustomerClass2.CustomerOrders.IndexOf(myOrder1))
         Next myOrder1
      Next myCustomerClass2
      myTreeViewBase.SelectedImageIndex = 0
      ' Begin repainting the 'TreeView'.
      myTreeViewBase.EndUpdate()
   End Sub 'FillMyTreeView
   
   Private Sub InitializeComponent()
      Me.myTreeViewBase = New TreeView()
      Me.myButtonAddAll = New Button()
      Me.myButtonAdd = New Button()
      Me.myTreeViewCustom = New TreeView()
      Me.myButtonRemoveAll = New Button()
      Me.SuspendLayout()
      Me.myTreeViewBase.ImageIndex = - 1
      Me.myTreeViewBase.Location = New Point(64, 16)
      Me.myTreeViewBase.Name = "myTreeViewBase"
      Me.myTreeViewBase.SelectedImageIndex = - 1
      Me.myTreeViewBase.Size = New Size(160, 192)
      Me.myTreeViewBase.TabIndex = 0
      Me.myButtonAddAll.Location = New Point(248, 112)
      Me.myButtonAddAll.Name = "myButtonAddAll"
      Me.myButtonAddAll.Size = New Size(96, 23)
      Me.myButtonAddAll.TabIndex = 2
      Me.myButtonAddAll.Text = "Add   >>"
      Me.myButtonAdd.Location = New Point(248, 48)
      Me.myButtonAdd.Name = "myButtonAdd"
      Me.myButtonAdd.Size = New Size(96, 23)
      Me.myButtonAdd.TabIndex = 3
      Me.myButtonAdd.Text = "Add     >"
      Me.myTreeViewCustom.ImageIndex = - 1
      Me.myTreeViewCustom.Location = New Point(376, 16)
      Me.myTreeViewCustom.Name = "myTreeViewCustom"
      Me.myTreeViewCustom.SelectedImageIndex = - 1
      Me.myTreeViewCustom.Size = New Size(168, 192)
      Me.myTreeViewCustom.TabIndex = 1
      Me.myButtonRemoveAll.Location = New Point(248, 176)
      Me.myButtonRemoveAll.Name = "myButtonRemoveAll"
      Me.myButtonRemoveAll.Size = New Size(96, 23)
      Me.myButtonRemoveAll.TabIndex = 4
      Me.myButtonRemoveAll.Text = "<<   Remove "
      Me.ClientSize = New Size(616, 273)
      Me.Controls.Add(myButtonRemoveAll)
      Me.Controls.Add(myButtonAdd)
      Me.Controls.Add(myButtonAddAll)
      Me.Controls.Add(myTreeViewCustom)
      Me.Controls.Add(myTreeViewBase)
      Me.Name = "myTreeNodeCollectionForm"
      Me.Text = "TreeNodeCollection class Sample"
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent
   
   Shared Sub Main()
      Application.Run(New myTreeNodeCollectionForm())
   End Sub 'Main
End Class 'myTreeNodeCollectionForm

Public Class MyCustomerClass
   Public CustomerOrders As ArrayList
   Public CustomerName As String
   
   Public Sub New(name As String)
      CustomerName = name
      CustomerOrders = New ArrayList()
   End Sub 'New
End Class 'MyCustomerClass

Public Class MyOrder
   Public OrderID As String
   
   Public Sub New(orderID As String)
      Me.OrderID = orderID
   End Sub 'New
End Class 'MyOrder