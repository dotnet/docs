 ' System.Windows.Forms.TreeNode.PrevVisibleNode
' System.Windows.Forms.TreeNode.PrevNode
' System.Windows.Forms.TreeNode.NextVisibleNode
' System.Windows.Forms.TreeNode.NextNode
' System.Windows.Forms.TreeNode.LastNode
' System.Windows.Forms.TreeNode.FirstNode
' System.Windows.Forms.TreeNode.TreeView
' System.Windows.Forms.TreeNode.IsSelected

'   The following program demonstrates the 'NodeFont', 'Parent', 'Text' and 'PrevVisibleNode'
'   properties of the 'TreeNode' class. It creates a TreeView consisting of customer nodes
'   and 'order' as its child nodes. It also provides option for the user to change the font
'   and text of the node.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Public Class MyTreeNodeForm
   Inherits System.Windows.Forms.Form
   Private myTreeView As TreeView
   Private myButton As Button
   Private myComboBox As ComboBox
   Private myLabel1 As Label
   Private myLabel3 As Label
   Private myLabel4 As Label
   Private myTextBox As TextBox
   
   Public Sub New()
      InitializeComponent()
      AddHandler myButton.Click, AddressOf MyButtonClick
      FillMyTreeView()
   End Sub 'New
   

   Private Sub MyButtonClick(sender As Object, e As EventArgs)
      Dim selectedNode As TreeNode = Nothing
      Dim node As TreeNode

      For Each node In  Me.myTreeView.Nodes
         ' See if the root tree node is selected.
         If node.IsSelected Then
            selectedNode = node
            Exit For
         End If
         
         ' Recurse through the TreeNodeCollection.
         selectedNode = GetSelectedNode(node)
         If (selectedNode IsNot Nothing) Then
            Exit For
         End If
      Next node
      
      ' Display the previous visible node.
      If (selectedNode IsNot Nothing) Then
         SelectNode(selectedNode)
      End If
   End Sub 'MyButtonClick
   
   
' <Snippet1>
Private Sub SelectNode(node As TreeNode)
   If node.IsSelected Then
      ' Determine which TreeNode to select.
      Select Case myComboBox.Text
         Case "Previous"
            node.TreeView.SelectedNode = node.PrevNode
         Case "PreviousVisible"
            node.TreeView.SelectedNode = node.PrevVisibleNode
         Case "Next"
            node.TreeView.SelectedNode = node.NextNode
         Case "NextVisible"
            node.TreeView.SelectedNode = node.NextVisibleNode
         Case "First"
            node.TreeView.SelectedNode = node.FirstNode
         Case "Last"
            node.TreeView.SelectedNode = node.LastNode
      End Select
   End If
   node.TreeView.Focus()
End Sub
' </Snippet1>
   
   Private Function GetSelectedNode(treeNode As TreeNode) As TreeNode
      ' Check each node recursively.
      Dim node As TreeNode
      For Each node In  treeNode.Nodes
         If node.IsSelected Then
            ' Return the TreeNode if it is selected.
            Return node
         End If
      Next node
      Return Nothing
   End Function 'GetSelectedNode
   
   
   ' ArrayList object to hold the 'MyCustomerClass' objects.
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
      myTreeView.BeginUpdate()
      
      ' Clear the 'TreeView' each time the method is called.
      myTreeView.Nodes.Clear()
      Dim myTreeNodeCollectionCustomer As TreeNodeCollection = myTreeView.Nodes
      ' Add a root treenode for each 'MyCustomerClass' object in the ArrayList.
      Dim myCustomerClass2 As MyCustomerClass
      For Each myCustomerClass2 In  customerArray
         myTreeNodeCollectionCustomer.Add(New TreeNode(myCustomerClass2.CustomerName))
         Dim myTreeNodeCollectionOrders As TreeNodeCollection = myTreeNodeCollectionCustomer(customerArray.IndexOf(myCustomerClass2)).Nodes
         ' Add a child treenode for each MyOrder object.
         Dim myOrder1 As MyOrder
         For Each myOrder1 In  myCustomerClass2.CustomerOrders
            myTreeNodeCollectionOrders.Add(New TreeNode(myOrder1.OrderID))
            Dim myTreeNodeOrder As TreeNode = myTreeNodeCollectionOrders(myCustomerClass2.CustomerOrders.IndexOf(myOrder1))
         Next myOrder1
      Next myCustomerClass2
      myTreeView.SelectedImageIndex = 0
      ' Begin repainting the 'TreeView'.
      myTreeView.EndUpdate()
   End Sub 'FillMyTreeView
   
   Private Sub InitializeComponent()
      Me.myTreeView = New System.Windows.Forms.TreeView()
      Me.myTextBox = New System.Windows.Forms.TextBox()
      Me.myComboBox = New System.Windows.Forms.ComboBox()
      Me.myLabel4 = New System.Windows.Forms.Label()
      Me.myButton = New System.Windows.Forms.Button()
      Me.myLabel1 = New System.Windows.Forms.Label()
      Me.myLabel3 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      ' 
      ' myTreeView
      ' 
      Me.myTreeView.ImageIndex = - 1
      Me.myTreeView.Location = New System.Drawing.Point(8, 16)
      Me.myTreeView.Name = "myTreeView"
      Me.myTreeView.SelectedImageIndex = - 1
      Me.myTreeView.Size = New System.Drawing.Size(136, 328)
      Me.myTreeView.TabIndex = 0
      ' 
      ' myTextBox
      ' 
      Me.myTextBox.Location = New System.Drawing.Point(368, 96)
      Me.myTextBox.Name = "myTextBox"
      Me.myTextBox.Size = New System.Drawing.Size(128, 20)
      Me.myTextBox.TabIndex = 9
      Me.myTextBox.Text = "TestNode"
      ' 
      ' myComboBox
      ' 
      Me.myComboBox.DropDownWidth = 121
      Me.myComboBox.Items.AddRange(New Object() {"PreviousVisible", "NextVisible", "Previous", "Next", "First", "Last"})
      Me.myComboBox.Location = New System.Drawing.Point(368, 24)
      Me.myComboBox.Name = "myComboBox"
      Me.myComboBox.Size = New System.Drawing.Size(128, 21)
      Me.myComboBox.TabIndex = 1
      ' 
      ' myLabel4
      ' 
      Me.myLabel4.Location = New System.Drawing.Point(152, 96)
      Me.myLabel4.Name = "myLabel4"
      Me.myLabel4.Size = New System.Drawing.Size(192, 16)
      Me.myLabel4.TabIndex = 7
      Me.myLabel4.Text = "Change text of selected TreeNode to"
      ' 
      ' myButton
      ' 
      Me.myButton.Location = New System.Drawing.Point(368, 152)
      Me.myButton.Name = "myButton"
      Me.myButton.Size = New System.Drawing.Size(128, 23)
      Me.myButton.TabIndex = 2
      Me.myButton.Text = "Apply"
      ' 
      ' myLabel1
      ' 
      Me.myLabel1.Location = New System.Drawing.Point(152, 216)
      Me.myLabel1.Name = "myLabel1"
      Me.myLabel1.Size = New System.Drawing.Size(408, 120)
      Me.myLabel1.TabIndex = 4
      ' 
      ' myLabel3
      ' 
      Me.myLabel3.Location = New System.Drawing.Point(152, 32)
      Me.myLabel3.Name = "myLabel3"
      Me.myLabel3.Size = New System.Drawing.Size(128, 16)
      Me.myLabel3.TabIndex = 6
      Me.myLabel3.Text = "Select Font"
      ' 
      ' MyTreeNodeForm
      ' 
      Me.ClientSize = New System.Drawing.Size(624, 365)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.myTextBox, Me.myLabel4, Me.myLabel3, Me.myLabel1, Me.myComboBox, Me.myButton, Me.myTreeView})
      Me.Name = "MyTreeNodeForm"
      Me.Text = "TreeNode class sample"
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent
    
   
   Shared Sub Main()
      Application.Run(New MyTreeNodeForm())
   End Sub 'Main
End Class 'MyTreeNodeForm
 _
Public Class MyCustomerClass
   Public CustomerOrders As ArrayList
   Public CustomerName As String
   
   Public Sub New(name As String)
      CustomerName = name
      CustomerOrders = New ArrayList()
   End Sub 'New
End Class 'MyCustomerClass
 _
Public Class MyOrder
   Public OrderID As String
   
   Public Sub New(orderID As String)
      Me.OrderID = orderID
   End Sub 'New
End Class 'MyOrder