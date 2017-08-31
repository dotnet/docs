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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
Me.CustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
Me.CustomerBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
Me.CustomerBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
Me.CustomerDataGridView = New System.Windows.Forms.DataGridView
Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.OrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
Me.OrdersDataGridView = New System.Windows.Forms.DataGridView
Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NorthwindDataSet1 = New DataProjectVB.NorthwindDataSet
Me.CustomersTableAdapter1 = New DataProjectVB.NorthwindDataSetTableAdapters.CustomersTableAdapter
Me.OrdersTableAdapter1 = New DataProjectVB.NorthwindDataSetTableAdapters.OrdersTableAdapter
CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.CustomerBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
Me.CustomerBindingNavigator.SuspendLayout()
CType(Me.CustomerDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.OrdersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'CustomerBindingSource
'
Me.CustomerBindingSource.DataSource = GetType(DataProjectVB.Customer)
'
'CustomerBindingNavigator
'
Me.CustomerBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
Me.CustomerBindingNavigator.BindingSource = Me.CustomerBindingSource
Me.CustomerBindingNavigator.CountItem = Me.BindingNavigatorCountItem
Me.CustomerBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
Me.CustomerBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CustomerBindingNavigatorSaveItem})
Me.CustomerBindingNavigator.Location = New System.Drawing.Point(0, 0)
Me.CustomerBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
Me.CustomerBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
Me.CustomerBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
Me.CustomerBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
Me.CustomerBindingNavigator.Name = "CustomerBindingNavigator"
Me.CustomerBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
Me.CustomerBindingNavigator.Size = New System.Drawing.Size(671, 25)
Me.CustomerBindingNavigator.TabIndex = 0
Me.CustomerBindingNavigator.Text = "BindingNavigator1"
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
'CustomerBindingNavigatorSaveItem
'
Me.CustomerBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.CustomerBindingNavigatorSaveItem.Enabled = False
Me.CustomerBindingNavigatorSaveItem.Image = CType(resources.GetObject("CustomerBindingNavigatorSaveItem.Image"), System.Drawing.Image)
Me.CustomerBindingNavigatorSaveItem.Name = "CustomerBindingNavigatorSaveItem"
Me.CustomerBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
Me.CustomerBindingNavigatorSaveItem.Text = "Save Data"
'
'CustomerDataGridView
'
Me.CustomerDataGridView.AutoGenerateColumns = False
Me.CustomerDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
Me.CustomerDataGridView.DataSource = Me.CustomerBindingSource
Me.CustomerDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable
Me.CustomerDataGridView.Location = New System.Drawing.Point(43, 30)
Me.CustomerDataGridView.Name = "CustomerDataGridView"
Me.CustomerDataGridView.Size = New System.Drawing.Size(300, 220)
Me.CustomerDataGridView.TabIndex = 1
'
'DataGridViewTextBoxColumn1
'
Me.DataGridViewTextBoxColumn1.DataPropertyName = "Fax"
Me.DataGridViewTextBoxColumn1.HeaderText = "Fax"
Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
'
'DataGridViewTextBoxColumn2
'
Me.DataGridViewTextBoxColumn2.DataPropertyName = "City"
Me.DataGridViewTextBoxColumn2.HeaderText = "City"
Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
'
'DataGridViewTextBoxColumn3
'
Me.DataGridViewTextBoxColumn3.DataPropertyName = "PostalCode"
Me.DataGridViewTextBoxColumn3.HeaderText = "PostalCode"
Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
'
'DataGridViewTextBoxColumn4
'
Me.DataGridViewTextBoxColumn4.DataPropertyName = "CustomerID"
Me.DataGridViewTextBoxColumn4.HeaderText = "CustomerID"
Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
'
'DataGridViewTextBoxColumn5
'
Me.DataGridViewTextBoxColumn5.DataPropertyName = "Phone"
Me.DataGridViewTextBoxColumn5.HeaderText = "Phone"
Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
'
'DataGridViewTextBoxColumn6
'
Me.DataGridViewTextBoxColumn6.DataPropertyName = "Address"
Me.DataGridViewTextBoxColumn6.HeaderText = "Address"
Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
'
'DataGridViewTextBoxColumn7
'
Me.DataGridViewTextBoxColumn7.DataPropertyName = "Country"
Me.DataGridViewTextBoxColumn7.HeaderText = "Country"
Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
'
'DataGridViewTextBoxColumn8
'
Me.DataGridViewTextBoxColumn8.DataPropertyName = "ContactTitle"
Me.DataGridViewTextBoxColumn8.HeaderText = "ContactTitle"
Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
'
'DataGridViewTextBoxColumn9
'
Me.DataGridViewTextBoxColumn9.DataPropertyName = "CompanyName"
Me.DataGridViewTextBoxColumn9.HeaderText = "CompanyName"
Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
'
'DataGridViewTextBoxColumn10
'
Me.DataGridViewTextBoxColumn10.DataPropertyName = "ContactName"
Me.DataGridViewTextBoxColumn10.HeaderText = "ContactName"
Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
'
'DataGridViewTextBoxColumn11
'
Me.DataGridViewTextBoxColumn11.DataPropertyName = "Region"
Me.DataGridViewTextBoxColumn11.HeaderText = "Region"
Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
'
'OrdersBindingSource
'
Me.OrdersBindingSource.DataMember = "Orders"
Me.OrdersBindingSource.DataSource = Me.CustomerBindingSource
'
'OrdersDataGridView
'
Me.OrdersDataGridView.AutoGenerateColumns = False
Me.OrdersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26})
Me.OrdersDataGridView.DataSource = Me.OrdersBindingSource
Me.OrdersDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable
Me.OrdersDataGridView.Location = New System.Drawing.Point(351, 169)
Me.OrdersDataGridView.Name = "OrdersDataGridView"
Me.OrdersDataGridView.Size = New System.Drawing.Size(300, 220)
Me.OrdersDataGridView.TabIndex = 2
'
'DataGridViewTextBoxColumn12
'
Me.DataGridViewTextBoxColumn12.DataPropertyName = "ShipCountry"
Me.DataGridViewTextBoxColumn12.HeaderText = "ShipCountry"
Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
'
'DataGridViewTextBoxColumn13
'
Me.DataGridViewTextBoxColumn13.DataPropertyName = "ShipName"
Me.DataGridViewTextBoxColumn13.HeaderText = "ShipName"
Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
'
'DataGridViewTextBoxColumn14
'
Me.DataGridViewTextBoxColumn14.DataPropertyName = "ShippedDate"
Me.DataGridViewTextBoxColumn14.HeaderText = "ShippedDate"
Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
'
'DataGridViewTextBoxColumn15
'
Me.DataGridViewTextBoxColumn15.DataPropertyName = "ShipAddress"
Me.DataGridViewTextBoxColumn15.HeaderText = "ShipAddress"
Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
'
'DataGridViewTextBoxColumn16
'
Me.DataGridViewTextBoxColumn16.DataPropertyName = "ShipCity"
Me.DataGridViewTextBoxColumn16.HeaderText = "ShipCity"
Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
'
'DataGridViewTextBoxColumn17
'
Me.DataGridViewTextBoxColumn17.DataPropertyName = "Freight"
Me.DataGridViewTextBoxColumn17.HeaderText = "Freight"
Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
'
'DataGridViewTextBoxColumn18
'
Me.DataGridViewTextBoxColumn18.DataPropertyName = "CustomerID"
Me.DataGridViewTextBoxColumn18.HeaderText = "CustomerID"
Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
'
'DataGridViewTextBoxColumn19
'
Me.DataGridViewTextBoxColumn19.DataPropertyName = "OrderID"
Me.DataGridViewTextBoxColumn19.HeaderText = "OrderID"
Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
'
'DataGridViewTextBoxColumn20
'
Me.DataGridViewTextBoxColumn20.DataPropertyName = "OrderDate"
Me.DataGridViewTextBoxColumn20.HeaderText = "OrderDate"
Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
'
'DataGridViewTextBoxColumn21
'
Me.DataGridViewTextBoxColumn21.DataPropertyName = "RequiredDate"
Me.DataGridViewTextBoxColumn21.HeaderText = "RequiredDate"
Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
'
'DataGridViewTextBoxColumn22
'
Me.DataGridViewTextBoxColumn22.DataPropertyName = "ShipRegion"
Me.DataGridViewTextBoxColumn22.HeaderText = "ShipRegion"
Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
'
'DataGridViewTextBoxColumn23
'
Me.DataGridViewTextBoxColumn23.DataPropertyName = "EmployeeID"
Me.DataGridViewTextBoxColumn23.HeaderText = "EmployeeID"
Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
'
'DataGridViewTextBoxColumn24
'
Me.DataGridViewTextBoxColumn24.DataPropertyName = "ShipPostalCode"
Me.DataGridViewTextBoxColumn24.HeaderText = "ShipPostalCode"
Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
'
'DataGridViewTextBoxColumn25
'
Me.DataGridViewTextBoxColumn25.DataPropertyName = "Customer"
Me.DataGridViewTextBoxColumn25.HeaderText = "Customer"
Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
'
'DataGridViewTextBoxColumn26
'
Me.DataGridViewTextBoxColumn26.DataPropertyName = "ShipVia"
Me.DataGridViewTextBoxColumn26.HeaderText = "ShipVia"
Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
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
'Form1
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(671, 409)
Me.Controls.Add(Me.OrdersDataGridView)
Me.Controls.Add(Me.CustomerDataGridView)
Me.Controls.Add(Me.CustomerBindingNavigator)
Me.Name = "Form1"
Me.Text = "Form1"
CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.CustomerBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
Me.CustomerBindingNavigator.ResumeLayout(False)
Me.CustomerBindingNavigator.PerformLayout()
CType(Me.CustomerDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.OrdersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents CustomerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents CustomerBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CustomerDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdersDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NorthwindDataSet1 As DataProjectVB.NorthwindDataSet
    Friend WithEvents CustomersTableAdapter1 As DataProjectVB.NorthwindDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents OrdersTableAdapter1 As DataProjectVB.NorthwindDataSetTableAdapters.OrdersTableAdapter
End Class
