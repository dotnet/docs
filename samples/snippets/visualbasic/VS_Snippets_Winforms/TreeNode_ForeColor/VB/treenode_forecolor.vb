' System.Windows.Forms.TreeNode.ExpandAll()
' System.Windows.Forms.TreeNode.FirstNode
' System.Windows.Forms.TreeNode.ForeColor
' System.Windows.Forms.TreeNode.GetNodeCount(bool)
' System.Windows.Forms.TreeNode.IsEditing
' System.Windows.Forms.TreeNode.IsExpanded
' System.Windows.Forms.TreeNode.IsSelected
' System.Windows.Forms.TreeNode.FullPath
' System.Windows.Forms.TreeView.PathSeparator

'   The following example demonstrates the  properties 'FirstNode',
'   ForeColor', 'IsEditing','IsExpanded' and 'IsSelected', the methods
'   ExpandAll' and 'GetNodeCount(bool)' of the 'TreeNode' class. In the
'   program, a form is created and to it 'TreeView', 'GroupBox',
'   and two 'CheckBox' controls are added. A 'TreeView' control is
'   associated with the class 'ContextMenu' so as to enable the user to change
'   the content of a 'TreeNode'. The 'TreeView' control displays a
'   hierarchical collection of 'Customer' objects which in turn contain
'   Order' objects.



Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data



Public Class MyTreeNode_FirstNode
   Inherits Form
   Private WithEvents myTreeView As TreeView
   Private WithEvents myGroupBox As GroupBox
   Private WithEvents myCheckBox As CheckBox
   Private WithEvents myCheckBox2 As CheckBox
   Private WithEvents myButton As Button
   Private WithEvents myContextMenu As ContextMenu
   Private WithEvents myMenuItem As MenuItem
   Private mySelectedNode As TreeNode
   
   
   Public Sub New()
      InitializeComponent()
      FillMyTreeView()
   End Sub 'New
   
   ' ArrayList object to hold the 'Customer' objects.
   Private myCustomerArrayList As New ArrayList()
   
   
   Private Sub FillMyTreeView()
      ' Add customers to the ArrayList of 'Customer' objects.
      Dim iIndex As Integer
      For iIndex = 1 To 10
         myCustomerArrayList.Add(New Customer("Customer" + iIndex.ToString()))
      Next iIndex
      ' Add orders to each 'Customer' object in the ArrayList.
      Dim myCustomer1 As Customer
      For Each myCustomer1 In  myCustomerArrayList
         Dim jIndex As Integer
         For jIndex = 1 To 5
            myCustomer1.CustomerOrders.Add(New Order("Order" + jIndex.ToString()))
         Next jIndex
      Next myCustomer1
      
      ' Suppress repainting the TreeView until it is fully created.
      myTreeView.BeginUpdate()
      ' Clear the TreeView each time the method is called.
      myTreeView.Nodes.Clear()
      Dim myMainNode As New TreeNode("CustomerList")
      myTreeView.Nodes.Add(myMainNode)
      
      ' Add a root treenode for each 'Customer' in the ArrayList.
      Dim myCustomer2 As Customer
      For Each myCustomer2 In  myCustomerArrayList
         Dim myTreeNode1 As New TreeNode(myCustomer2.CustomerName)
         myTreeNode1.ForeColor = Color.Orange
         myTreeView.Nodes(0).Nodes.Add(myTreeNode1)
         ' Add a child for each 'Order' in the current 'Customer'.
         Dim myOrder1 As Order
         For Each myOrder1 In  myCustomer2.CustomerOrders
            myTreeView.Nodes(0).Nodes(myCustomerArrayList.IndexOf(myCustomer2)).Nodes.Add(New TreeNode(myOrder1.OrderID))
         Next myOrder1
      Next myCustomer2
      
      ' Reset the cursor back to the default for all controls.
      Cursor.Current = Cursors.Default
      ' Begin repainting the TreeView.
      myTreeView.EndUpdate()
      If myTreeView.Nodes(0).IsExpanded = False Then
         myTreeView.Nodes(0).Expand()
      End If
   End Sub 'FillMyTreeView
    
   Private Sub InitializeComponent()
      Me.myMenuItem = New MenuItem()
      Me.myCheckBox = New CheckBox()
      Me.myButton = New Button()
      Me.myCheckBox2 = New CheckBox()
      Me.myTreeView = New TreeView()
      Me.myContextMenu = New ContextMenu()
      Me.myGroupBox = New GroupBox()
      Me.myGroupBox.SuspendLayout()
      Me.SuspendLayout()
      
      Me.myMenuItem.Checked = True
      Me.myMenuItem.DefaultItem = True
      Me.myMenuItem.Index = 0
      Me.myMenuItem.Text = "Edit"
      
      Me.myCheckBox.Location = New System.Drawing.Point(24, 24)
      Me.myCheckBox.Name = "myCheckBox"
      Me.myCheckBox.TabIndex = 0
      Me.myCheckBox.Text = "Expand All"
      
      Me.myButton.Location = New System.Drawing.Point(136, 24)
      Me.myButton.Name = "myCheckBox2"
      Me.myButton.TabIndex = 1
      Me.myButton.Text = "Child Nodes"
      
      Me.myTreeView.ContextMenu = Me.myContextMenu
      Me.myTreeView.ImageIndex = - 1
      Me.myTreeView.LabelEdit = True
      Me.myTreeView.Location = New System.Drawing.Point(8, 0)
      Me.myTreeView.Name = "myTreeView"
      Me.myTreeView.SelectedImageIndex = - 1
      Me.myTreeView.Size = New System.Drawing.Size(280, 152)
      Me.myTreeView.TabIndex = 0
      
      Me.myContextMenu.MenuItems.AddRange(New MenuItem() {Me.myMenuItem})
      
      
      Me.myGroupBox.Controls.AddRange(New Control() {Me.myButton, Me.myCheckBox})
      Me.myGroupBox.Location = New System.Drawing.Point(8, 168)
      Me.myGroupBox.Name = "myGroupBox"
      Me.myGroupBox.Size = New System.Drawing.Size(272, 96)
      Me.myGroupBox.TabIndex = 1
      Me.myGroupBox.TabStop = False
      Me.myGroupBox.Text = "myGroupBox"
      
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.AddRange(New Control() {Me.myGroupBox, Me.myTreeView})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.myGroupBox.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent
    
   
   Shared Sub Main()
      Application.Run(New MyTreeNode_FirstNode())
   End Sub 'Main
   
   
' <Snippet1>
Private Sub myCheckBox_CheckedChanged(ByVal sender As Object, _
   ByVal e As System.EventArgs) Handles myCheckBox.CheckedChanged
   ' If the check box is checked, expand all the tree nodes.
   If myCheckBox.Checked = True Then
      myTreeView.ExpandAll()
   Else
      ' If the check box is not cheked, collapse the first tree node.
      myTreeView.Nodes(0).FirstNode.Collapse()
      MessageBox.Show("The first and last node of CutomerList root node is collapsed")
   End If
End Sub
' </Snippet1>

' <Snippet2>
Private Sub myButton_Click(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles myButton.Click
   ' Set the tree view's PathSeparator property.
   myTreeView.PathSeparator = "."

   ' Get the count of the child tree nodes contained in the SelectedNode.
   Dim myNodeCount As Integer = myTreeView.SelectedNode.GetNodeCount(True)
   Dim myChildPercentage As Decimal = CDec(myNodeCount) / _
      CDec(myTreeView.GetNodeCount(True)) * 100

   ' Display the tree node path and the number of child nodes it and the tree view have.
   MessageBox.Show(("The '" + myTreeView.SelectedNode.FullPath + "' node has " _
      + myNodeCount.ToString() + " child nodes." + Microsoft.VisualBasic.ControlChars.Lf _
      + "That is " + String.Format("{0:###.##}", myChildPercentage) _
      + "% of the total tree nodes in the tree view control."))
End Sub
' </Snippet2>


   ' Save the tree node under the mouse pointer.
   Private Sub TreeView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles myTreeView.MouseDown
      mySelectedNode = myTreeView.GetNodeAt(e.X, e.Y)
   End Sub 'TreeView1_MouseDown


   Private Sub MenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles myMenuItem.Click

      If (mySelectedNode IsNot Nothing) And (mySelectedNode.Parent IsNot Nothing) Then
         myTreeView.SelectedNode = mySelectedNode
         myTreeView.LabelEdit = True
         mySelectedNode.BeginEdit()
         If mySelectedNode.IsEditing = True Then
            MessageBox.Show(("The name of node being edited: " + mySelectedNode.Text))
         End If
         mySelectedNode.BeginEdit()

      Else
         MessageBox.Show(("No tree node selected or selected node is a " + "root node. Editing of root nodes is not allowed." + "Invalid selection"))
      End If
   End Sub 'MenuItem1_Click


   Private Sub TreeView1_AfterLabelEdit(ByVal sender As Object, ByVal e As NodeLabelEditEventArgs) Handles myTreeView.AfterLabelEdit
      If (e.Label IsNot Nothing) Then
         If e.Label.Length > 0 Then
            If e.Label.IndexOfAny(New Char() {"@"c, "."c, ","c, "!"c}) = -1 Then
               ' Stop editing without cancelling the label change.
               e.Node.EndEdit(False)
            Else
               ' Cancel the label edit action, place it in edit mode.
               e.CancelEdit = True
               MessageBox.Show("Invalid tree node label." + Microsoft.VisualBasic.ControlChars.Lf + "The invalid characters are: '@','.', ',', '!'", "Node Label Edit")
               e.Node.BeginEdit()
            End If
         Else
            ' Cancel the label edit action, place it in edit mode.
            e.CancelEdit = True
            MessageBox.Show("Invalid tree node label." + "The label cannot be blank", "Node Label Edit")
            e.Node.BeginEdit()
         End If
         Me.myTreeView.LabelEdit = False
      End If
   End Sub 'TreeView1_AfterLabelEdit
End Class 'MyTreeNode_FirstNode



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