<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim OrderIDLabel As System.Windows.Forms.Label
Dim ProductIDLabel As System.Windows.Forms.Label
Dim UnitPriceLabel As System.Windows.Forms.Label
Dim QuantityLabel As System.Windows.Forms.Label
Dim DiscountLabel As System.Windows.Forms.Label
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
Me.NorthwindDataSet1 = New VB.NorthwindDataSet
Me.CustomersTableAdapter1 = New VB.NorthwindDataSetTableAdapters.CustomersTableAdapter
Me.OrdersTableAdapter1 = New VB.NorthwindDataSetTableAdapters.OrdersTableAdapter
Me.Order_DetailsTableAdapter1 = New VB.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter
Me.Order_DetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
Me.Order_DetailsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
Me.Order_DetailsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
Me.OrderIDTextBox = New System.Windows.Forms.TextBox
Me.ProductIDTextBox = New System.Windows.Forms.TextBox
Me.UnitPriceTextBox = New System.Windows.Forms.TextBox
Me.QuantityTextBox = New System.Windows.Forms.TextBox
Me.DiscountTextBox = New System.Windows.Forms.TextBox
Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
OrderIDLabel = New System.Windows.Forms.Label
ProductIDLabel = New System.Windows.Forms.Label
UnitPriceLabel = New System.Windows.Forms.Label
QuantityLabel = New System.Windows.Forms.Label
DiscountLabel = New System.Windows.Forms.Label
CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.Order_DetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.Order_DetailsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
Me.Order_DetailsBindingNavigator.SuspendLayout()
CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'OrderIDLabel
'
OrderIDLabel.AutoSize = True
OrderIDLabel.Location = New System.Drawing.Point(21, 28)
OrderIDLabel.Name = "OrderIDLabel"
OrderIDLabel.Size = New System.Drawing.Size(50, 13)
OrderIDLabel.TabIndex = 1
OrderIDLabel.Text = "Order ID:"
'
'ProductIDLabel
'
ProductIDLabel.AutoSize = True
ProductIDLabel.Location = New System.Drawing.Point(21, 54)
ProductIDLabel.Name = "ProductIDLabel"
ProductIDLabel.Size = New System.Drawing.Size(61, 13)
ProductIDLabel.TabIndex = 3
ProductIDLabel.Text = "Product ID:"
'
'UnitPriceLabel
'
UnitPriceLabel.AutoSize = True
UnitPriceLabel.Location = New System.Drawing.Point(21, 80)
UnitPriceLabel.Name = "UnitPriceLabel"
UnitPriceLabel.Size = New System.Drawing.Size(56, 13)
UnitPriceLabel.TabIndex = 5
UnitPriceLabel.Text = "Unit Price:"
'
'QuantityLabel
'
QuantityLabel.AutoSize = True
QuantityLabel.Location = New System.Drawing.Point(21, 106)
QuantityLabel.Name = "QuantityLabel"
QuantityLabel.Size = New System.Drawing.Size(49, 13)
QuantityLabel.TabIndex = 7
QuantityLabel.Text = "Quantity:"
'
'DiscountLabel
'
DiscountLabel.AutoSize = True
DiscountLabel.Location = New System.Drawing.Point(21, 132)
DiscountLabel.Name = "DiscountLabel"
DiscountLabel.Size = New System.Drawing.Size(52, 13)
DiscountLabel.TabIndex = 9
DiscountLabel.Text = "Discount:"
'
'NorthwindDataSet1
'
Me.NorthwindDataSet1.DataSetName = "NorthwindDataSet"
'
'CustomersTableAdapter1
'
Me.CustomersTableAdapter1.ClearBeforeFill = True
'
'OrdersTableAdapter1
'
Me.OrdersTableAdapter1.ClearBeforeFill = True
'
'Order_DetailsTableAdapter1
'
Me.Order_DetailsTableAdapter1.ClearBeforeFill = True
'
'Order_DetailsBindingSource
'
Me.Order_DetailsBindingSource.DataMember = "Order Details"
Me.Order_DetailsBindingSource.DataSource = Me.NorthwindDataSet1
'
'Order_DetailsBindingNavigator
'
Me.Order_DetailsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
Me.Order_DetailsBindingNavigator.BindingSource = Me.Order_DetailsBindingSource
Me.Order_DetailsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
Me.Order_DetailsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
Me.Order_DetailsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.Order_DetailsBindingNavigatorSaveItem})
Me.Order_DetailsBindingNavigator.Location = New System.Drawing.Point(0, 0)
Me.Order_DetailsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
Me.Order_DetailsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
Me.Order_DetailsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
Me.Order_DetailsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
Me.Order_DetailsBindingNavigator.Name = "Order_DetailsBindingNavigator"
Me.Order_DetailsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
Me.Order_DetailsBindingNavigator.Size = New System.Drawing.Size(328, 25)
Me.Order_DetailsBindingNavigator.TabIndex = 0
Me.Order_DetailsBindingNavigator.Text = "BindingNavigator1"
'
'BindingNavigatorAddNewItem
'
Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorAddNewItem.Text = "Add new"
'
'BindingNavigatorCountItem
'
Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
Me.BindingNavigatorCountItem.Text = "of {0}"
Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
'
'BindingNavigatorDeleteItem
'
Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorDeleteItem.Text = "Delete"
'
'BindingNavigatorMoveFirstItem
'
Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorMoveFirstItem.Text = "Move first"
'
'BindingNavigatorMovePreviousItem
'
Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
'
'BindingNavigatorSeparator
'
Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
'
'BindingNavigatorPositionItem
'
Me.BindingNavigatorPositionItem.AccessibleName = "Position"
Me.BindingNavigatorPositionItem.AutoSize = False
Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
Me.BindingNavigatorPositionItem.Text = "0"
Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
'
'BindingNavigatorSeparator1
'
Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
'
'BindingNavigatorMoveNextItem
'
Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorMoveNextItem.Text = "Move next"
'
'BindingNavigatorMoveLastItem
'
Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorMoveLastItem.Text = "Move last"
'
'BindingNavigatorSeparator2
'
Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
'
'Order_DetailsBindingNavigatorSaveItem
'
Me.Order_DetailsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.Order_DetailsBindingNavigatorSaveItem.Image = CType(resources.GetObject("Order_DetailsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
Me.Order_DetailsBindingNavigatorSaveItem.Name = "Order_DetailsBindingNavigatorSaveItem"
Me.Order_DetailsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
Me.Order_DetailsBindingNavigatorSaveItem.Text = "Save Data"
'
'OrderIDTextBox
'
Me.OrderIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Order_DetailsBindingSource, "OrderID", True))
Me.OrderIDTextBox.Location = New System.Drawing.Point(88, 25)
Me.OrderIDTextBox.Name = "OrderIDTextBox"
Me.OrderIDTextBox.Size = New System.Drawing.Size(100, 20)
Me.OrderIDTextBox.TabIndex = 2
'
'ProductIDTextBox
'
Me.ProductIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Order_DetailsBindingSource, "ProductID", True))
Me.ProductIDTextBox.Location = New System.Drawing.Point(88, 51)
Me.ProductIDTextBox.Name = "ProductIDTextBox"
Me.ProductIDTextBox.Size = New System.Drawing.Size(100, 20)
Me.ProductIDTextBox.TabIndex = 4
'
'UnitPriceTextBox
'
Me.UnitPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Order_DetailsBindingSource, "UnitPrice", True))
Me.UnitPriceTextBox.Location = New System.Drawing.Point(88, 77)
Me.UnitPriceTextBox.Name = "UnitPriceTextBox"
Me.UnitPriceTextBox.Size = New System.Drawing.Size(100, 20)
Me.UnitPriceTextBox.TabIndex = 6
'
'QuantityTextBox
'
Me.QuantityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Order_DetailsBindingSource, "Quantity", True))
Me.QuantityTextBox.Location = New System.Drawing.Point(88, 103)
Me.QuantityTextBox.Name = "QuantityTextBox"
Me.QuantityTextBox.Size = New System.Drawing.Size(100, 20)
Me.QuantityTextBox.TabIndex = 8
'
'DiscountTextBox
'
Me.DiscountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Order_DetailsBindingSource, "Discount", True))
Me.DiscountTextBox.Location = New System.Drawing.Point(88, 129)
Me.DiscountTextBox.Name = "DiscountTextBox"
Me.DiscountTextBox.Size = New System.Drawing.Size(100, 20)
Me.DiscountTextBox.TabIndex = 10
'
'ErrorProvider1
'
Me.ErrorProvider1.ContainerControl = Me
'
'Form1
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(328, 266)
Me.Controls.Add(OrderIDLabel)
Me.Controls.Add(Me.OrderIDTextBox)
Me.Controls.Add(ProductIDLabel)
Me.Controls.Add(Me.ProductIDTextBox)
Me.Controls.Add(UnitPriceLabel)
Me.Controls.Add(Me.UnitPriceTextBox)
Me.Controls.Add(QuantityLabel)
Me.Controls.Add(Me.QuantityTextBox)
Me.Controls.Add(DiscountLabel)
Me.Controls.Add(Me.DiscountTextBox)
Me.Controls.Add(Me.Order_DetailsBindingNavigator)
Me.Name = "Form1"
Me.Text = "Form1"
CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.Order_DetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.Order_DetailsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
Me.Order_DetailsBindingNavigator.ResumeLayout(False)
Me.Order_DetailsBindingNavigator.PerformLayout()
CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents NorthwindDataSet1 As VB.NorthwindDataSet
    Friend WithEvents CustomersTableAdapter1 As VB.NorthwindDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents OrdersTableAdapter1 As VB.NorthwindDataSetTableAdapters.OrdersTableAdapter
    Friend WithEvents Order_DetailsTableAdapter1 As VB.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter
    Friend WithEvents Order_DetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Order_DetailsBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Order_DetailsBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents OrderIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProductIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnitPriceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QuantityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DiscountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

End Class
