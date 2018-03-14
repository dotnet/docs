' System.Windows.Forms.TreeNode.TreeNode()
' System.Windows.Forms.TreeNode.TreeNode(string,TreeNode[])
' System.Windows.Forms.TreeNode.Bounds
' System.Windows.Forms.TreeNode.ForeColor
' System.Windows.Forms.TreeNode.NodeFont
' System.Windows.Forms.TreeNode.Text
' System.Windows.Forms.TreeNode.Tag
' System.Windows.Forms.TreeView.ItemHeight

' The following example demonstrates the constructors 'TreeNode()'
' and 'TreeNode(string,TreeNode[])' and the property 'Bounds' of the
' 'TreeNode' class. This example displays customer information in a 
' 'TreeView' control. The root tree nodes display customer names, and 
' the child tree nodes display the order numbers assigned to each 
' customer.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data



Public Class TreeNode_Bounds
   Inherits Form
   Private myTreeView As TreeView
   Private myButton As Button
   Private mylabel As Label
   Private myComboBox As ComboBox

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

      AddRootNodes()      

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
' </Snippet1>


' <Snippet2>
Private Sub Button1_Click(sender As Object, e As EventArgs)
   myTreeView.ItemHeight = 5
   myTreeView.SelectedNode.NodeFont = New Font("Arial", 5)

   ' Get the font size from combobox.
   Dim selectedString As String = myComboBox.SelectedItem.ToString()
   Dim myNodeFontSize As Integer = Int32.Parse(selectedString)

   ' Set the font of root node.
   myTreeView.SelectedNode.NodeFont = New Font("Arial", myNodeFontSize)
   Dim i As Integer
   For  i = 0 To (myTreeView.Nodes(0).Nodes.Count) - 1
      ' Set the font of child nodes.
      myTreeView.Nodes(0).Nodes(i).NodeFont = New Font("Arial", _
        myNodeFontSize)
   Next i

   ' Get the bounds of the tree node.
   Dim myRectangle As Rectangle = myTreeView.SelectedNode.Bounds
   Dim myNodeHeight As Integer = myRectangle.Height
   If myNodeHeight < myNodeFontSize Then
      myNodeHeight = myNodeFontSize
   End If
   myTreeView.ItemHeight = myNodeHeight + 4
End Sub 
' </Snippet2>

   Private Sub InitializeComponent()
      Me.myTreeView = New System.Windows.Forms.TreeView()
      Me.myButton = New System.Windows.Forms.Button()
      Me.myComboBox = New System.Windows.Forms.ComboBox()
      Me.mylabel = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      Me.myTreeView.ImageIndex = - 1
      Me.myTreeView.Location = New System.Drawing.Point(8, 0)
      Me.myTreeView.Name = "myTreeView"
      Me.myTreeView.SelectedImageIndex = - 1
      Me.myTreeView.Size = New Size(280, 152)
      Me.myTreeView.TabIndex = 0
      Me.myButton.Location = New System.Drawing.Point(104, 232)
      Me.myButton.Name = "myButton"
      Me.myButton.TabIndex = 2
      Me.myButton.Text = "Submit"
      AddHandler Me.myButton.Click, AddressOf Me.Button1_Click
      Me.myComboBox.DropDownWidth = 121
      Me.myComboBox.Items.AddRange(New Object() {"6", "7", "8", "10", "12", "14", "16", "18", "20", "22"})
      Me.myComboBox.Location = New System.Drawing.Point(112, 184)
      Me.myComboBox.Name = "myComboBox"
      Me.myComboBox.Size = New System.Drawing.Size(121, 21)
      Me.myComboBox.TabIndex = 1
      Me.myComboBox.SelectedIndex = 0
      Me.myComboBox.DropDownStyle = ComboBoxStyle.DropDownList
      Me.mylabel.Location = New System.Drawing.Point(0, 184)
      Me.mylabel.Name = "mylabel"
      Me.mylabel.TabIndex = 3
      Me.mylabel.Text = "Select a Height for TreeNode"
      Me.mylabel.Size = New Size(100, 50)
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.mylabel, _
                                    Me.myButton, Me.myComboBox, Me.myTreeView})
      Me.Text = "TreeNode Example"
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent

   Shared Sub Main()
      Application.Run(New TreeNode_Bounds())
   End Sub 'Main
End Class 'TreeNode_Bounds
