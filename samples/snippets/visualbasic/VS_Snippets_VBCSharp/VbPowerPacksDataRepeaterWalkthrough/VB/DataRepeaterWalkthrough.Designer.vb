<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataRepeaterWalkthrough
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataRepeaterWalkthrough))
        Dim OrderIDLabel As System.Windows.Forms.Label
        Dim CustomerIDLabel1 As System.Windows.Forms.Label
        Dim EmployeeIDLabel As System.Windows.Forms.Label
        Dim OrderDateLabel As System.Windows.Forms.Label
        Dim RequiredDateLabel As System.Windows.Forms.Label
        Dim ShippedDateLabel As System.Windows.Forms.Label
        Dim ShipViaLabel As System.Windows.Forms.Label
        Dim FreightLabel As System.Windows.Forms.Label
        Dim ShipNameLabel As System.Windows.Forms.Label
        Dim ShipAddressLabel As System.Windows.Forms.Label
        Dim ShipCityLabel As System.Windows.Forms.Label
        Dim ShipRegionLabel As System.Windows.Forms.Label
        Dim ShipPostalCodeLabel As System.Windows.Forms.Label
        Dim ShipCountryLabel As System.Windows.Forms.Label
        Me.DataRepeater1 = New Microsoft.VisualBasic.PowerPacks.DataRepeater
        Me.CustomerIDTextBox = New System.Windows.Forms.TextBox
        Me.CustomersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NorthwndDataSet = New DataRepeaterApp.northwndDataSet
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
        Me.CustomersTableAdapter = New DataRepeaterApp.northwndDataSetTableAdapters.CustomersTableAdapter
        Me.TableAdapterManager = New DataRepeaterApp.northwndDataSetTableAdapters.TableAdapterManager
        Me.CustomersBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.CustomersBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.SearchTextBox = New System.Windows.Forms.TextBox
        Me.SearchButton = New System.Windows.Forms.Button
        Me.DataRepeater2 = New Microsoft.VisualBasic.PowerPacks.DataRepeater
        Me.OrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrdersTableAdapter = New DataRepeaterApp.northwndDataSetTableAdapters.OrdersTableAdapter
        Me.OrderIDTextBox = New System.Windows.Forms.TextBox
        Me.CustomerIDTextBox1 = New System.Windows.Forms.TextBox
        Me.EmployeeIDTextBox = New System.Windows.Forms.TextBox
        Me.OrderDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.RequiredDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ShippedDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ShipViaTextBox = New System.Windows.Forms.TextBox
        Me.FreightTextBox = New System.Windows.Forms.TextBox
        Me.ShipNameTextBox = New System.Windows.Forms.TextBox
        Me.ShipAddressTextBox = New System.Windows.Forms.TextBox
        Me.ShipCityTextBox = New System.Windows.Forms.TextBox
        Me.ShipRegionTextBox = New System.Windows.Forms.TextBox
        Me.ShipPostalCodeTextBox = New System.Windows.Forms.TextBox
        Me.ShipCountryTextBox = New System.Windows.Forms.TextBox
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
        OrderIDLabel = New System.Windows.Forms.Label
        CustomerIDLabel1 = New System.Windows.Forms.Label
        EmployeeIDLabel = New System.Windows.Forms.Label
        OrderDateLabel = New System.Windows.Forms.Label
        RequiredDateLabel = New System.Windows.Forms.Label
        ShippedDateLabel = New System.Windows.Forms.Label
        ShipViaLabel = New System.Windows.Forms.Label
        FreightLabel = New System.Windows.Forms.Label
        ShipNameLabel = New System.Windows.Forms.Label
        ShipAddressLabel = New System.Windows.Forms.Label
        ShipCityLabel = New System.Windows.Forms.Label
        ShipRegionLabel = New System.Windows.Forms.Label
        ShipPostalCodeLabel = New System.Windows.Forms.Label
        ShipCountryLabel = New System.Windows.Forms.Label
        Me.DataRepeater1.ItemTemplate.SuspendLayout()
        Me.DataRepeater1.SuspendLayout()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NorthwndDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomersBindingNavigator.SuspendLayout()
        Me.DataRepeater2.ItemTemplate.SuspendLayout()
        Me.DataRepeater2.SuspendLayout()
        CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomerIDLabel
        '
        CustomerIDLabel.AutoSize = True
        CustomerIDLabel.Location = New System.Drawing.Point(14, 13)
        CustomerIDLabel.Name = "CustomerIDLabel"
        CustomerIDLabel.Size = New System.Drawing.Size(68, 13)
        CustomerIDLabel.TabIndex = 0
        CustomerIDLabel.Text = "Customer ID:"
        '
        'CompanyNameLabel
        '
        CompanyNameLabel.AutoSize = True
        CompanyNameLabel.Location = New System.Drawing.Point(14, 39)
        CompanyNameLabel.Name = "CompanyNameLabel"
        CompanyNameLabel.Size = New System.Drawing.Size(85, 13)
        CompanyNameLabel.TabIndex = 2
        CompanyNameLabel.Text = "Company Name:"
        '
        'ContactNameLabel
        '
        ContactNameLabel.AutoSize = True
        ContactNameLabel.Location = New System.Drawing.Point(14, 65)
        ContactNameLabel.Name = "ContactNameLabel"
        ContactNameLabel.Size = New System.Drawing.Size(78, 13)
        ContactNameLabel.TabIndex = 4
        ContactNameLabel.Text = "Contact Name:"
        '
        'ContactTitleLabel
        '
        ContactTitleLabel.AutoSize = True
        ContactTitleLabel.Location = New System.Drawing.Point(14, 91)
        ContactTitleLabel.Name = "ContactTitleLabel"
        ContactTitleLabel.Size = New System.Drawing.Size(70, 13)
        ContactTitleLabel.TabIndex = 6
        ContactTitleLabel.Text = "Contact Title:"
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Location = New System.Drawing.Point(14, 117)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(48, 13)
        AddressLabel.TabIndex = 8
        AddressLabel.Text = "Address:"
        '
        'CityLabel
        '
        CityLabel.AutoSize = True
        CityLabel.Location = New System.Drawing.Point(14, 143)
        CityLabel.Name = "CityLabel"
        CityLabel.Size = New System.Drawing.Size(27, 13)
        CityLabel.TabIndex = 10
        CityLabel.Text = "City:"
        '
        'RegionLabel
        '
        RegionLabel.AutoSize = True
        RegionLabel.Location = New System.Drawing.Point(224, 13)
        RegionLabel.Name = "RegionLabel"
        RegionLabel.Size = New System.Drawing.Size(44, 13)
        RegionLabel.TabIndex = 12
        RegionLabel.Text = "Region:"
        '
        'PostalCodeLabel
        '
        PostalCodeLabel.AutoSize = True
        PostalCodeLabel.Location = New System.Drawing.Point(224, 39)
        PostalCodeLabel.Name = "PostalCodeLabel"
        PostalCodeLabel.Size = New System.Drawing.Size(67, 13)
        PostalCodeLabel.TabIndex = 14
        PostalCodeLabel.Text = "Postal Code:"
        '
        'CountryLabel
        '
        CountryLabel.AutoSize = True
        CountryLabel.Location = New System.Drawing.Point(224, 65)
        CountryLabel.Name = "CountryLabel"
        CountryLabel.Size = New System.Drawing.Size(46, 13)
        CountryLabel.TabIndex = 16
        CountryLabel.Text = "Country:"
        '
        'PhoneLabel
        '
        PhoneLabel.AutoSize = True
        PhoneLabel.Location = New System.Drawing.Point(224, 91)
        PhoneLabel.Name = "PhoneLabel"
        PhoneLabel.Size = New System.Drawing.Size(41, 13)
        PhoneLabel.TabIndex = 18
        PhoneLabel.Text = "Phone:"
        '
        'FaxLabel
        '
        FaxLabel.AutoSize = True
        FaxLabel.Location = New System.Drawing.Point(224, 117)
        FaxLabel.Name = "FaxLabel"
        FaxLabel.Size = New System.Drawing.Size(27, 13)
        FaxLabel.TabIndex = 20
        FaxLabel.Text = "Fax:"
        '
        'DataRepeater1
        '
        Me.DataRepeater1.BackColor = System.Drawing.Color.White
        '
        'DataRepeater1.ItemTemplate
        '
        Me.DataRepeater1.ItemTemplate.Controls.Add(CustomerIDLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.CustomerIDTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(CompanyNameLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.CompanyNameTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(ContactNameLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.ContactNameTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(ContactTitleLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.ContactTitleTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(AddressLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.AddressTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(CityLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.CityTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(RegionLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.RegionTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(PostalCodeLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.PostalCodeTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(CountryLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.CountryTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(PhoneLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.PhoneTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(FaxLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.FaxTextBox)
        Me.DataRepeater1.ItemTemplate.Size = New System.Drawing.Size(452, 170)
        Me.DataRepeater1.Location = New System.Drawing.Point(0, 25)
        Me.DataRepeater1.Name = "DataRepeater1"
        Me.DataRepeater1.Size = New System.Drawing.Size(460, 600)
        Me.DataRepeater1.TabIndex = 0
        Me.DataRepeater1.Text = "DataRepeater1"
        '
        'CustomerIDTextBox
        '
        Me.CustomerIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "CustomerID", True))
        Me.CustomerIDTextBox.Location = New System.Drawing.Point(105, 10)
        Me.CustomerIDTextBox.Name = "CustomerIDTextBox"
        Me.CustomerIDTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CustomerIDTextBox.TabIndex = 1
        '
        'CustomersBindingSource
        '
        Me.CustomersBindingSource.DataMember = "Customers"
        Me.CustomersBindingSource.DataSource = Me.NorthwndDataSet
        '
        'NorthwndDataSet
        '
        Me.NorthwndDataSet.DataSetName = "northwndDataSet"
        Me.NorthwndDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CompanyNameTextBox
        '
        Me.CompanyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "CompanyName", True))
        Me.CompanyNameTextBox.Location = New System.Drawing.Point(105, 36)
        Me.CompanyNameTextBox.Name = "CompanyNameTextBox"
        Me.CompanyNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CompanyNameTextBox.TabIndex = 3
        '
        'ContactNameTextBox
        '
        Me.ContactNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "ContactName", True))
        Me.ContactNameTextBox.Location = New System.Drawing.Point(105, 62)
        Me.ContactNameTextBox.Name = "ContactNameTextBox"
        Me.ContactNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ContactNameTextBox.TabIndex = 5
        '
        'ContactTitleTextBox
        '
        Me.ContactTitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "ContactTitle", True))
        Me.ContactTitleTextBox.Location = New System.Drawing.Point(105, 88)
        Me.ContactTitleTextBox.Name = "ContactTitleTextBox"
        Me.ContactTitleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ContactTitleTextBox.TabIndex = 7
        '
        'AddressTextBox
        '
        Me.AddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Address", True))
        Me.AddressTextBox.Location = New System.Drawing.Point(105, 114)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AddressTextBox.TabIndex = 9
        '
        'CityTextBox
        '
        Me.CityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "City", True))
        Me.CityTextBox.Location = New System.Drawing.Point(105, 140)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CityTextBox.TabIndex = 11
        '
        'RegionTextBox
        '
        Me.RegionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Region", True))
        Me.RegionTextBox.Location = New System.Drawing.Point(315, 10)
        Me.RegionTextBox.Name = "RegionTextBox"
        Me.RegionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RegionTextBox.TabIndex = 13
        '
        'PostalCodeTextBox
        '
        Me.PostalCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "PostalCode", True))
        Me.PostalCodeTextBox.Location = New System.Drawing.Point(315, 36)
        Me.PostalCodeTextBox.Name = "PostalCodeTextBox"
        Me.PostalCodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PostalCodeTextBox.TabIndex = 15
        '
        'CountryTextBox
        '
        Me.CountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Country", True))
        Me.CountryTextBox.Location = New System.Drawing.Point(315, 62)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CountryTextBox.TabIndex = 17
        '
        'PhoneTextBox
        '
        Me.PhoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Phone", True))
        Me.PhoneTextBox.Location = New System.Drawing.Point(315, 88)
        Me.PhoneTextBox.Name = "PhoneTextBox"
        Me.PhoneTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PhoneTextBox.TabIndex = 19
        '
        'FaxTextBox
        '
        Me.FaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomersBindingSource, "Fax", True))
        Me.FaxTextBox.Location = New System.Drawing.Point(315, 114)
        Me.FaxTextBox.Name = "FaxTextBox"
        Me.FaxTextBox.Size = New System.Drawing.Size(100, 20)
        Me.FaxTextBox.TabIndex = 21
        '
        'CustomersTableAdapter
        '
        Me.CustomersTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CustomersTableAdapter = Me.CustomersTableAdapter
        Me.TableAdapterManager.OrdersTableAdapter = Me.OrdersTableAdapter
        Me.TableAdapterManager.UpdateOrder = DataRepeaterApp.northwndDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        Me.CustomersBindingNavigator.Size = New System.Drawing.Size(894, 25)
        Me.CustomersBindingNavigator.TabIndex = 1
        Me.CustomersBindingNavigator.Text = "BindingNavigator1"
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
        'CustomersBindingNavigatorSaveItem
        '
        Me.CustomersBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CustomersBindingNavigatorSaveItem.Image = CType(resources.GetObject("CustomersBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.CustomersBindingNavigatorSaveItem.Name = "CustomersBindingNavigatorSaveItem"
        Me.CustomersBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.CustomersBindingNavigatorSaveItem.Text = "Save Data"
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Location = New System.Drawing.Point(20, 638)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(217, 20)
        Me.SearchTextBox.TabIndex = 2
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(297, 637)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(158, 20)
        Me.SearchButton.TabIndex = 3
        Me.SearchButton.Text = "Button1"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'DataRepeater2
        '
        '
        'DataRepeater2.ItemTemplate
        '
        Me.DataRepeater2.ItemTemplate.Controls.Add(OrderIDLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.OrderIDTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(CustomerIDLabel1)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.CustomerIDTextBox1)
        Me.DataRepeater2.ItemTemplate.Controls.Add(EmployeeIDLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.EmployeeIDTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(OrderDateLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.OrderDateDateTimePicker)
        Me.DataRepeater2.ItemTemplate.Controls.Add(RequiredDateLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.RequiredDateDateTimePicker)
        Me.DataRepeater2.ItemTemplate.Controls.Add(ShippedDateLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.ShippedDateDateTimePicker)
        Me.DataRepeater2.ItemTemplate.Controls.Add(ShipViaLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.ShipViaTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(FreightLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.FreightTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(ShipNameLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.ShipNameTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(ShipAddressLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.ShipAddressTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(ShipCityLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.ShipCityTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(ShipRegionLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.ShipRegionTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(ShipPostalCodeLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.ShipPostalCodeTextBox)
        Me.DataRepeater2.ItemTemplate.Controls.Add(ShipCountryLabel)
        Me.DataRepeater2.ItemTemplate.Controls.Add(Me.ShipCountryTextBox)
        Me.DataRepeater2.ItemTemplate.Size = New System.Drawing.Size(421, 378)
        Me.DataRepeater2.Location = New System.Drawing.Point(465, 25)
        Me.DataRepeater2.Name = "DataRepeater2"
        Me.DataRepeater2.Size = New System.Drawing.Size(429, 600)
        Me.DataRepeater2.TabIndex = 4
        Me.DataRepeater2.Text = "DataRepeater2"
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
        'OrderIDLabel
        '
        OrderIDLabel.AutoSize = True
        OrderIDLabel.Location = New System.Drawing.Point(65, 13)
        OrderIDLabel.Name = "OrderIDLabel"
        OrderIDLabel.Size = New System.Drawing.Size(50, 13)
        OrderIDLabel.TabIndex = 0
        OrderIDLabel.Text = "Order ID:"
        '
        'OrderIDTextBox
        '
        Me.OrderIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "OrderID", True))
        Me.OrderIDTextBox.Location = New System.Drawing.Point(162, 10)
        Me.OrderIDTextBox.Name = "OrderIDTextBox"
        Me.OrderIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.OrderIDTextBox.TabIndex = 1
        '
        'CustomerIDLabel1
        '
        CustomerIDLabel1.AutoSize = True
        CustomerIDLabel1.Location = New System.Drawing.Point(65, 39)
        CustomerIDLabel1.Name = "CustomerIDLabel1"
        CustomerIDLabel1.Size = New System.Drawing.Size(68, 13)
        CustomerIDLabel1.TabIndex = 2
        CustomerIDLabel1.Text = "Customer ID:"
        '
        'CustomerIDTextBox1
        '
        Me.CustomerIDTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "CustomerID", True))
        Me.CustomerIDTextBox1.Location = New System.Drawing.Point(162, 36)
        Me.CustomerIDTextBox1.Name = "CustomerIDTextBox1"
        Me.CustomerIDTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.CustomerIDTextBox1.TabIndex = 3
        '
        'EmployeeIDLabel
        '
        EmployeeIDLabel.AutoSize = True
        EmployeeIDLabel.Location = New System.Drawing.Point(65, 65)
        EmployeeIDLabel.Name = "EmployeeIDLabel"
        EmployeeIDLabel.Size = New System.Drawing.Size(70, 13)
        EmployeeIDLabel.TabIndex = 4
        EmployeeIDLabel.Text = "Employee ID:"
        '
        'EmployeeIDTextBox
        '
        Me.EmployeeIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "EmployeeID", True))
        Me.EmployeeIDTextBox.Location = New System.Drawing.Point(162, 62)
        Me.EmployeeIDTextBox.Name = "EmployeeIDTextBox"
        Me.EmployeeIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.EmployeeIDTextBox.TabIndex = 5
        '
        'OrderDateLabel
        '
        OrderDateLabel.AutoSize = True
        OrderDateLabel.Location = New System.Drawing.Point(65, 92)
        OrderDateLabel.Name = "OrderDateLabel"
        OrderDateLabel.Size = New System.Drawing.Size(62, 13)
        OrderDateLabel.TabIndex = 6
        OrderDateLabel.Text = "Order Date:"
        '
        'OrderDateDateTimePicker
        '
        Me.OrderDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.OrdersBindingSource, "OrderDate", True))
        Me.OrderDateDateTimePicker.Location = New System.Drawing.Point(162, 88)
        Me.OrderDateDateTimePicker.Name = "OrderDateDateTimePicker"
        Me.OrderDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.OrderDateDateTimePicker.TabIndex = 7
        '
        'RequiredDateLabel
        '
        RequiredDateLabel.AutoSize = True
        RequiredDateLabel.Location = New System.Drawing.Point(65, 118)
        RequiredDateLabel.Name = "RequiredDateLabel"
        RequiredDateLabel.Size = New System.Drawing.Size(79, 13)
        RequiredDateLabel.TabIndex = 8
        RequiredDateLabel.Text = "Required Date:"
        '
        'RequiredDateDateTimePicker
        '
        Me.RequiredDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.OrdersBindingSource, "RequiredDate", True))
        Me.RequiredDateDateTimePicker.Location = New System.Drawing.Point(162, 114)
        Me.RequiredDateDateTimePicker.Name = "RequiredDateDateTimePicker"
        Me.RequiredDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.RequiredDateDateTimePicker.TabIndex = 9
        '
        'ShippedDateLabel
        '
        ShippedDateLabel.AutoSize = True
        ShippedDateLabel.Location = New System.Drawing.Point(65, 144)
        ShippedDateLabel.Name = "ShippedDateLabel"
        ShippedDateLabel.Size = New System.Drawing.Size(75, 13)
        ShippedDateLabel.TabIndex = 10
        ShippedDateLabel.Text = "Shipped Date:"
        '
        'ShippedDateDateTimePicker
        '
        Me.ShippedDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.OrdersBindingSource, "ShippedDate", True))
        Me.ShippedDateDateTimePicker.Location = New System.Drawing.Point(162, 140)
        Me.ShippedDateDateTimePicker.Name = "ShippedDateDateTimePicker"
        Me.ShippedDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.ShippedDateDateTimePicker.TabIndex = 11
        '
        'ShipViaLabel
        '
        ShipViaLabel.AutoSize = True
        ShipViaLabel.Location = New System.Drawing.Point(65, 169)
        ShipViaLabel.Name = "ShipViaLabel"
        ShipViaLabel.Size = New System.Drawing.Size(49, 13)
        ShipViaLabel.TabIndex = 12
        ShipViaLabel.Text = "Ship Via:"
        '
        'ShipViaTextBox
        '
        Me.ShipViaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "ShipVia", True))
        Me.ShipViaTextBox.Location = New System.Drawing.Point(162, 166)
        Me.ShipViaTextBox.Name = "ShipViaTextBox"
        Me.ShipViaTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ShipViaTextBox.TabIndex = 13
        '
        'FreightLabel
        '
        FreightLabel.AutoSize = True
        FreightLabel.Location = New System.Drawing.Point(65, 195)
        FreightLabel.Name = "FreightLabel"
        FreightLabel.Size = New System.Drawing.Size(42, 13)
        FreightLabel.TabIndex = 14
        FreightLabel.Text = "Freight:"
        '
        'FreightTextBox
        '
        Me.FreightTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "Freight", True))
        Me.FreightTextBox.Location = New System.Drawing.Point(162, 192)
        Me.FreightTextBox.Name = "FreightTextBox"
        Me.FreightTextBox.Size = New System.Drawing.Size(200, 20)
        Me.FreightTextBox.TabIndex = 15
        '
        'ShipNameLabel
        '
        ShipNameLabel.AutoSize = True
        ShipNameLabel.Location = New System.Drawing.Point(65, 221)
        ShipNameLabel.Name = "ShipNameLabel"
        ShipNameLabel.Size = New System.Drawing.Size(62, 13)
        ShipNameLabel.TabIndex = 16
        ShipNameLabel.Text = "Ship Name:"
        '
        'ShipNameTextBox
        '
        Me.ShipNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "ShipName", True))
        Me.ShipNameTextBox.Location = New System.Drawing.Point(162, 218)
        Me.ShipNameTextBox.Name = "ShipNameTextBox"
        Me.ShipNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ShipNameTextBox.TabIndex = 17
        '
        'ShipAddressLabel
        '
        ShipAddressLabel.AutoSize = True
        ShipAddressLabel.Location = New System.Drawing.Point(65, 247)
        ShipAddressLabel.Name = "ShipAddressLabel"
        ShipAddressLabel.Size = New System.Drawing.Size(72, 13)
        ShipAddressLabel.TabIndex = 18
        ShipAddressLabel.Text = "Ship Address:"
        '
        'ShipAddressTextBox
        '
        Me.ShipAddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "ShipAddress", True))
        Me.ShipAddressTextBox.Location = New System.Drawing.Point(162, 244)
        Me.ShipAddressTextBox.Name = "ShipAddressTextBox"
        Me.ShipAddressTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ShipAddressTextBox.TabIndex = 19
        '
        'ShipCityLabel
        '
        ShipCityLabel.AutoSize = True
        ShipCityLabel.Location = New System.Drawing.Point(65, 273)
        ShipCityLabel.Name = "ShipCityLabel"
        ShipCityLabel.Size = New System.Drawing.Size(51, 13)
        ShipCityLabel.TabIndex = 20
        ShipCityLabel.Text = "Ship City:"
        '
        'ShipCityTextBox
        '
        Me.ShipCityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "ShipCity", True))
        Me.ShipCityTextBox.Location = New System.Drawing.Point(162, 270)
        Me.ShipCityTextBox.Name = "ShipCityTextBox"
        Me.ShipCityTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ShipCityTextBox.TabIndex = 21
        '
        'ShipRegionLabel
        '
        ShipRegionLabel.AutoSize = True
        ShipRegionLabel.Location = New System.Drawing.Point(65, 299)
        ShipRegionLabel.Name = "ShipRegionLabel"
        ShipRegionLabel.Size = New System.Drawing.Size(68, 13)
        ShipRegionLabel.TabIndex = 22
        ShipRegionLabel.Text = "Ship Region:"
        '
        'ShipRegionTextBox
        '
        Me.ShipRegionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "ShipRegion", True))
        Me.ShipRegionTextBox.Location = New System.Drawing.Point(162, 296)
        Me.ShipRegionTextBox.Name = "ShipRegionTextBox"
        Me.ShipRegionTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ShipRegionTextBox.TabIndex = 23
        '
        'ShipPostalCodeLabel
        '
        ShipPostalCodeLabel.AutoSize = True
        ShipPostalCodeLabel.Location = New System.Drawing.Point(65, 325)
        ShipPostalCodeLabel.Name = "ShipPostalCodeLabel"
        ShipPostalCodeLabel.Size = New System.Drawing.Size(91, 13)
        ShipPostalCodeLabel.TabIndex = 24
        ShipPostalCodeLabel.Text = "Ship Postal Code:"
        '
        'ShipPostalCodeTextBox
        '
        Me.ShipPostalCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "ShipPostalCode", True))
        Me.ShipPostalCodeTextBox.Location = New System.Drawing.Point(162, 322)
        Me.ShipPostalCodeTextBox.Name = "ShipPostalCodeTextBox"
        Me.ShipPostalCodeTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ShipPostalCodeTextBox.TabIndex = 25
        '
        'ShipCountryLabel
        '
        ShipCountryLabel.AutoSize = True
        ShipCountryLabel.Location = New System.Drawing.Point(65, 351)
        ShipCountryLabel.Name = "ShipCountryLabel"
        ShipCountryLabel.Size = New System.Drawing.Size(70, 13)
        ShipCountryLabel.TabIndex = 26
        ShipCountryLabel.Text = "Ship Country:"
        '
        'ShipCountryTextBox
        '
        Me.ShipCountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrdersBindingSource, "ShipCountry", True))
        Me.ShipCountryTextBox.Location = New System.Drawing.Point(162, 348)
        Me.ShipCountryTextBox.Name = "ShipCountryTextBox"
        Me.ShipCountryTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ShipCountryTextBox.TabIndex = 27
        '
        'DataRepeaterWalkthrough
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 666)
        Me.Controls.Add(Me.DataRepeater2)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.SearchTextBox)
        Me.Controls.Add(Me.CustomersBindingNavigator)
        Me.Controls.Add(Me.DataRepeater1)
        Me.Name = "DataRepeaterWalkthrough"
        Me.Text = "Form1"
        Me.DataRepeater1.ItemTemplate.ResumeLayout(False)
        Me.DataRepeater1.ItemTemplate.PerformLayout()
        Me.DataRepeater1.ResumeLayout(False)
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NorthwndDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomersBindingNavigator.ResumeLayout(False)
        Me.CustomersBindingNavigator.PerformLayout()
        Me.DataRepeater2.ItemTemplate.ResumeLayout(False)
        Me.DataRepeater2.ItemTemplate.PerformLayout()
        Me.DataRepeater2.ResumeLayout(False)
        CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataRepeater1 As Microsoft.VisualBasic.PowerPacks.DataRepeater
    Friend WithEvents NorthwndDataSet As DataRepeaterApp.northwndDataSet
    Friend WithEvents CustomersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomersTableAdapter As DataRepeaterApp.northwndDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents TableAdapterManager As DataRepeaterApp.northwndDataSetTableAdapters.TableAdapterManager
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
    Friend WithEvents SearchTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents OrdersTableAdapter As DataRepeaterApp.northwndDataSetTableAdapters.OrdersTableAdapter
    Friend WithEvents DataRepeater2 As Microsoft.VisualBasic.PowerPacks.DataRepeater
    Friend WithEvents OrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrderIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CustomerIDTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents EmployeeIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrderDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents RequiredDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ShippedDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ShipViaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FreightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShipNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShipAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShipCityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShipRegionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShipPostalCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShipCountryTextBox As System.Windows.Forms.TextBox

End Class
