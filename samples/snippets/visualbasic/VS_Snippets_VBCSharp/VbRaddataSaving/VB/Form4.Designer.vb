<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form4
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
Dim CustomerIDLabel As System.Windows.Forms.Label
Dim CompanyNameLabel As System.Windows.Forms.Label
Dim ContactNameLabel As System.Windows.Forms.Label
Dim ContactTitleLabel As System.Windows.Forms.Label
Dim AddressLabel As System.Windows.Forms.Label
Dim CityLabel As System.Windows.Forms.Label
Dim RegionLabel As System.Windows.Forms.Label
Dim PostalCodeLabel As System.Windows.Forms.Label
Dim CountryLabel As System.Windows.Forms.Label
Dim PhoneLabel As System.Windows.Forms.Label
Dim FaxLabel As System.Windows.Forms.Label
Me.NorthwindDataSet = New VB.NorthwindDataSet
Me.CustomersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
Me.CustomersTableAdapter = New VB.NorthwindDataSetTableAdapters.CustomersTableAdapter
Me.CustomersBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
Me.CustomersBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
Me.CustomerIDTextBox = New System.Windows.Forms.TextBox
Me.CompanyNameTextBox = New System.Windows.Forms.TextBox
Me.ContactNameTextBox = New System.Windows.Forms.TextBox
Me.ContactTitleTextBox = New System.Windows.Forms.TextBox
Me.AddressTextBox = New System.Windows.Forms.TextBox
Me.CityTextBox = New System.Windows.Forms.TextBox
Me.RegionTextBox = New System.Windows.Forms.TextBox
Me.PostalCodeTextBox = New System.Windows.Forms.TextBox
Me.CountryTextBox = New System.Windows.Forms.TextBox
Me.PhoneTextBox = New System.Windows.Forms.TextBox
Me.FaxTextBox = New System.Windows.Forms.TextBox
Me.OrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
Me.OrdersTableAdapter = New VB.NorthwindDataSetTableAdapters.OrdersTableAdapter
Me.OrdersDataGridView = New System.Windows.Forms.DataGridView
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
Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
CustomerIDLabel = New System.Windows.Forms.Label
CompanyNameLabel = New System.Windows.Forms.Label
ContactNameLabel = New System.Windows.Forms.Label
ContactTitleLabel = New System.Windows.Forms.Label
AddressLabel = New System.Windows.Forms.Label
CityLabel = New System.Windows.Forms.Label
RegionLabel = New System.Windows.Forms.Label
PostalCodeLabel = New System.Windows.Forms.Label
CountryLabel = New System.Windows.Forms.Label
PhoneLabel = New System.Windows.Forms.Label
FaxLabel = New System.Windows.Forms.Label
CType(Me.NorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.CustomersBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
Me.CustomersBindingNavigator.SuspendLayout()
CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.OrdersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'NorthwindDataSet
'
Me.NorthwindDataSet.DataSetName = "NorthwindDataSet"
'
'CustomersBindingSource
'
Me.CustomersBindingSource.DataMember = "Customers"
Me.CustomersBindingSource.DataSource = Me.NorthwindDataSet
'
'CustomersTableAdapter
'
Me.CustomersTableAdapter.ClearBeforeFill = True
'
'CustomersBindingNavigator
'
Me.CustomersBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
Me.CustomersBindingNavigator.BindingSource = Me.CustomersBindingSource
Me.CustomersBindingNavigator.CountItem = Me.BindingNavigatorCountItem
Me.CustomersBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
Me.CustomersBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CustomersBindingNavigatorSaveItem})
Me.CustomersBindingNavigator.Location = New System.Drawing.Point(0, 0)
Me.CustomersBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
Me.CustomersBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
Me.CustomersBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
Me.CustomersBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
Me.CustomersBindingNavigator.Name = "CustomersBindingNavigator"
Me.CustomersBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
Me.CustomersBindingNavigator.Size = New System.Drawing.Size(566, 25)
Me.CustomersBindingNavigator.TabIndex = 0
Me.CustomersBindingNavigator.Text = "BindingNavigator1"
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
'BindingNavigatorCountItem
'
Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 13)
Me.BindingNavigatorCountItem.Text = "of {0}"
Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
'
'BindingNavigatorSeparator1
'
Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
'
'BindingNavigatorMoveNextItem
'
Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 20)
Me.BindingNavigatorMoveNextItem.Text = "Move next"
'
'BindingNavigatorMoveLastItem
'
Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 20)
Me.BindingNavigatorMoveLastItem.Text = "Move last"
'
'BindingNavigatorSeparator2
'
Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
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
'BindingNavigatorDeleteItem
'
Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 20)
Me.BindingNavigatorDeleteItem.Text = "Delete"
'
'CustomersBindingNavigatorSaveItem
'
Me.CustomersBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.CustomersBindingNavigatorSaveItem.Image = CType(resources.GetObject("CustomersBindingNavigatorSaveItem.Image"), System.Drawing.Image)
Me.CustomersBindingNavigatorSaveItem.Name = "CustomersBindingNavigatorSaveItem"
Me.CustomersBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
Me.CustomersBindingNavigatorSaveItem.Text = "Save Data"
'
'CustomerIDLabel
'
CustomerIDLabel.AutoSize = True
CustomerIDLabel.Location = New System.Drawing.Point(12, 39)
CustomerIDLabel.Name = "CustomerIDLabel"
CustomerIDLabel.Size = New System.Drawing.Size(68, 13)
CustomerIDLabel.TabIndex = 1
CustomerIDLabel.Text = "Customer ID:"
'
'CustomerIDTextBox
'
Me.CustomerIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "CustomerID", True))
Me.CustomerIDTextBox.Location = New System.Drawing.Point(103, 36)
Me.CustomerIDTextBox.Name = "CustomerIDTextBox"
Me.CustomerIDTextBox.Size = New System.Drawing.Size(100, 20)
Me.CustomerIDTextBox.TabIndex = 2
'
'CompanyNameLabel
'
CompanyNameLabel.AutoSize = True
CompanyNameLabel.Location = New System.Drawing.Point(12, 65)
CompanyNameLabel.Name = "CompanyNameLabel"
CompanyNameLabel.Size = New System.Drawing.Size(85, 13)
CompanyNameLabel.TabIndex = 3
CompanyNameLabel.Text = "Company Name:"
'
'CompanyNameTextBox
'
Me.CompanyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "CompanyName", True))
Me.CompanyNameTextBox.Location = New System.Drawing.Point(103, 62)
Me.CompanyNameTextBox.Name = "CompanyNameTextBox"
Me.CompanyNameTextBox.Size = New System.Drawing.Size(100, 20)
Me.CompanyNameTextBox.TabIndex = 4
'
'ContactNameLabel
'
ContactNameLabel.AutoSize = True
ContactNameLabel.Location = New System.Drawing.Point(12, 91)
ContactNameLabel.Name = "ContactNameLabel"
ContactNameLabel.Size = New System.Drawing.Size(78, 13)
ContactNameLabel.TabIndex = 5
ContactNameLabel.Text = "Contact Name:"
'
'ContactNameTextBox
'
Me.ContactNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "ContactName", True))
Me.ContactNameTextBox.Location = New System.Drawing.Point(103, 88)
Me.ContactNameTextBox.Name = "ContactNameTextBox"
Me.ContactNameTextBox.Size = New System.Drawing.Size(100, 20)
Me.ContactNameTextBox.TabIndex = 6
'
'ContactTitleLabel
'
ContactTitleLabel.AutoSize = True
ContactTitleLabel.Location = New System.Drawing.Point(12, 117)
ContactTitleLabel.Name = "ContactTitleLabel"
ContactTitleLabel.Size = New System.Drawing.Size(70, 13)
ContactTitleLabel.TabIndex = 7
ContactTitleLabel.Text = "Contact Title:"
'
'ContactTitleTextBox
'
Me.ContactTitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "ContactTitle", True))
Me.ContactTitleTextBox.Location = New System.Drawing.Point(103, 114)
Me.ContactTitleTextBox.Name = "ContactTitleTextBox"
Me.ContactTitleTextBox.Size = New System.Drawing.Size(100, 20)
Me.ContactTitleTextBox.TabIndex = 8
'
'AddressLabel
'
AddressLabel.AutoSize = True
AddressLabel.Location = New System.Drawing.Point(12, 143)
AddressLabel.Name = "AddressLabel"
AddressLabel.Size = New System.Drawing.Size(48, 13)
AddressLabel.TabIndex = 9
AddressLabel.Text = "Address:"
'
'AddressTextBox
'
Me.AddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Address", True))
Me.AddressTextBox.Location = New System.Drawing.Point(103, 140)
Me.AddressTextBox.Name = "AddressTextBox"
Me.AddressTextBox.Size = New System.Drawing.Size(100, 20)
Me.AddressTextBox.TabIndex = 10
'
'CityLabel
'
CityLabel.AutoSize = True
CityLabel.Location = New System.Drawing.Point(12, 169)
CityLabel.Name = "CityLabel"
CityLabel.Size = New System.Drawing.Size(27, 13)
CityLabel.TabIndex = 11
CityLabel.Text = "City:"
'
'CityTextBox
'
Me.CityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "City", True))
Me.CityTextBox.Location = New System.Drawing.Point(103, 166)
Me.CityTextBox.Name = "CityTextBox"
Me.CityTextBox.Size = New System.Drawing.Size(100, 20)
Me.CityTextBox.TabIndex = 12
'
'RegionLabel
'
RegionLabel.AutoSize = True
RegionLabel.Location = New System.Drawing.Point(12, 195)
RegionLabel.Name = "RegionLabel"
RegionLabel.Size = New System.Drawing.Size(44, 13)
RegionLabel.TabIndex = 13
RegionLabel.Text = "Region:"
'
'RegionTextBox
'
Me.RegionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Region", True))
Me.RegionTextBox.Location = New System.Drawing.Point(103, 192)
Me.RegionTextBox.Name = "RegionTextBox"
Me.RegionTextBox.Size = New System.Drawing.Size(100, 20)
Me.RegionTextBox.TabIndex = 14
'
'PostalCodeLabel
'
PostalCodeLabel.AutoSize = True
PostalCodeLabel.Location = New System.Drawing.Point(12, 221)
PostalCodeLabel.Name = "PostalCodeLabel"
PostalCodeLabel.Size = New System.Drawing.Size(67, 13)
PostalCodeLabel.TabIndex = 15
PostalCodeLabel.Text = "Postal Code:"
'
'PostalCodeTextBox
'
Me.PostalCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "PostalCode", True))
Me.PostalCodeTextBox.Location = New System.Drawing.Point(103, 218)
Me.PostalCodeTextBox.Name = "PostalCodeTextBox"
Me.PostalCodeTextBox.Size = New System.Drawing.Size(100, 20)
Me.PostalCodeTextBox.TabIndex = 16
'
'CountryLabel
'
CountryLabel.AutoSize = True
CountryLabel.Location = New System.Drawing.Point(12, 247)
CountryLabel.Name = "CountryLabel"
CountryLabel.Size = New System.Drawing.Size(46, 13)
CountryLabel.TabIndex = 17
CountryLabel.Text = "Country:"
'
'CountryTextBox
'
Me.CountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Country", True))
Me.CountryTextBox.Location = New System.Drawing.Point(103, 244)
Me.CountryTextBox.Name = "CountryTextBox"
Me.CountryTextBox.Size = New System.Drawing.Size(100, 20)
Me.CountryTextBox.TabIndex = 18
'
'PhoneLabel
'
PhoneLabel.AutoSize = True
PhoneLabel.Location = New System.Drawing.Point(12, 273)
PhoneLabel.Name = "PhoneLabel"
PhoneLabel.Size = New System.Drawing.Size(41, 13)
PhoneLabel.TabIndex = 19
PhoneLabel.Text = "Phone:"
'
'PhoneTextBox
'
Me.PhoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Phone", True))
Me.PhoneTextBox.Location = New System.Drawing.Point(103, 270)
Me.PhoneTextBox.Name = "PhoneTextBox"
Me.PhoneTextBox.Size = New System.Drawing.Size(100, 20)
Me.PhoneTextBox.TabIndex = 20
'
'FaxLabel
'
FaxLabel.AutoSize = True
FaxLabel.Location = New System.Drawing.Point(12, 299)
FaxLabel.Name = "FaxLabel"
FaxLabel.Size = New System.Drawing.Size(27, 13)
FaxLabel.TabIndex = 21
FaxLabel.Text = "Fax:"
'
'FaxTextBox
'
Me.FaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Fax", True))
Me.FaxTextBox.Location = New System.Drawing.Point(103, 296)
Me.FaxTextBox.Name = "FaxTextBox"
Me.FaxTextBox.Size = New System.Drawing.Size(100, 20)
Me.FaxTextBox.TabIndex = 22
'
'OrdersBindingSource
'
Me.OrdersBindingSource.DataMember = "FK_Orders_Customers"
Me.OrdersBindingSource.DataSource = Me.CustomersBindingSource
'
'OrdersTableAdapter
'
Me.OrdersTableAdapter.ClearBeforeFill = True
'
'OrdersDataGridView
'
Me.OrdersDataGridView.AutoGenerateColumns = False
Me.OrdersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
Me.OrdersDataGridView.DataSource = Me.OrdersBindingSource
Me.OrdersDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable
Me.OrdersDataGridView.Location = New System.Drawing.Point(246, 55)
Me.OrdersDataGridView.Name = "OrdersDataGridView"
Me.OrdersDataGridView.Size = New System.Drawing.Size(300, 220)
Me.OrdersDataGridView.TabIndex = 23
'
'DataGridViewTextBoxColumn1
'
Me.DataGridViewTextBoxColumn1.DataPropertyName = "OrderID"
Me.DataGridViewTextBoxColumn1.HeaderText = "OrderID"
Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
Me.DataGridViewTextBoxColumn1.ReadOnly = True
'
'DataGridViewTextBoxColumn2
'
Me.DataGridViewTextBoxColumn2.DataPropertyName = "CustomerID"
Me.DataGridViewTextBoxColumn2.HeaderText = "CustomerID"
Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
'
'DataGridViewTextBoxColumn3
'
Me.DataGridViewTextBoxColumn3.DataPropertyName = "EmployeeID"
Me.DataGridViewTextBoxColumn3.HeaderText = "EmployeeID"
Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
'
'DataGridViewTextBoxColumn4
'
Me.DataGridViewTextBoxColumn4.DataPropertyName = "OrderDate"
Me.DataGridViewTextBoxColumn4.HeaderText = "OrderDate"
Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
'
'DataGridViewTextBoxColumn5
'
Me.DataGridViewTextBoxColumn5.DataPropertyName = "RequiredDate"
Me.DataGridViewTextBoxColumn5.HeaderText = "RequiredDate"
Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
'
'DataGridViewTextBoxColumn6
'
Me.DataGridViewTextBoxColumn6.DataPropertyName = "ShippedDate"
Me.DataGridViewTextBoxColumn6.HeaderText = "ShippedDate"
Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
'
'DataGridViewTextBoxColumn7
'
Me.DataGridViewTextBoxColumn7.DataPropertyName = "ShipVia"
Me.DataGridViewTextBoxColumn7.HeaderText = "ShipVia"
Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
'
'DataGridViewTextBoxColumn8
'
Me.DataGridViewTextBoxColumn8.DataPropertyName = "Freight"
Me.DataGridViewTextBoxColumn8.HeaderText = "Freight"
Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
'
'DataGridViewTextBoxColumn9
'
Me.DataGridViewTextBoxColumn9.DataPropertyName = "ShipName"
Me.DataGridViewTextBoxColumn9.HeaderText = "ShipName"
Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
'
'DataGridViewTextBoxColumn10
'
Me.DataGridViewTextBoxColumn10.DataPropertyName = "ShipAddress"
Me.DataGridViewTextBoxColumn10.HeaderText = "ShipAddress"
Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
'
'DataGridViewTextBoxColumn11
'
Me.DataGridViewTextBoxColumn11.DataPropertyName = "ShipCity"
Me.DataGridViewTextBoxColumn11.HeaderText = "ShipCity"
Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
'
'DataGridViewTextBoxColumn12
'
Me.DataGridViewTextBoxColumn12.DataPropertyName = "ShipRegion"
Me.DataGridViewTextBoxColumn12.HeaderText = "ShipRegion"
Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
'
'DataGridViewTextBoxColumn13
'
Me.DataGridViewTextBoxColumn13.DataPropertyName = "ShipPostalCode"
Me.DataGridViewTextBoxColumn13.HeaderText = "ShipPostalCode"
Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
'
'DataGridViewTextBoxColumn14
'
Me.DataGridViewTextBoxColumn14.DataPropertyName = "ShipCountry"
Me.DataGridViewTextBoxColumn14.HeaderText = "ShipCountry"
Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
'
'Form4
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(566, 337)
Me.Controls.Add(Me.OrdersDataGridView)
Me.Controls.Add(CustomerIDLabel)
Me.Controls.Add(Me.CustomerIDTextBox)
Me.Controls.Add(CompanyNameLabel)
Me.Controls.Add(Me.CompanyNameTextBox)
Me.Controls.Add(ContactNameLabel)
Me.Controls.Add(Me.ContactNameTextBox)
Me.Controls.Add(ContactTitleLabel)
Me.Controls.Add(Me.ContactTitleTextBox)
Me.Controls.Add(AddressLabel)
Me.Controls.Add(Me.AddressTextBox)
Me.Controls.Add(CityLabel)
Me.Controls.Add(Me.CityTextBox)
Me.Controls.Add(RegionLabel)
Me.Controls.Add(Me.RegionTextBox)
Me.Controls.Add(PostalCodeLabel)
Me.Controls.Add(Me.PostalCodeTextBox)
Me.Controls.Add(CountryLabel)
Me.Controls.Add(Me.CountryTextBox)
Me.Controls.Add(PhoneLabel)
Me.Controls.Add(Me.PhoneTextBox)
Me.Controls.Add(FaxLabel)
Me.Controls.Add(Me.FaxTextBox)
Me.Controls.Add(Me.CustomersBindingNavigator)
Me.Name = "Form4"
Me.Text = "Form4"
CType(Me.NorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.CustomersBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
Me.CustomersBindingNavigator.ResumeLayout(False)
Me.CustomersBindingNavigator.PerformLayout()
CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.OrdersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents NorthwindDataSet As VB.NorthwindDataSet
    Friend WithEvents CustomersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomersTableAdapter As VB.NorthwindDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents CustomersBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents CustomersBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CustomerIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContactNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContactTitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RegionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PostalCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CountryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FaxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdersTableAdapter As VB.NorthwindDataSetTableAdapters.OrdersTableAdapter
    Friend WithEvents OrdersDataGridView As System.Windows.Forms.DataGridView
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
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
