<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Color
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Color))
        Dim ContactIDLabel As System.Windows.Forms.Label
        Dim ContactTypeLabel As System.Windows.Forms.Label
        Dim CompanyNameLabel As System.Windows.Forms.Label
        Dim ContactNameLabel As System.Windows.Forms.Label
        Dim ContactTitleLabel As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim CityLabel As System.Windows.Forms.Label
        Dim RegionLabel As System.Windows.Forms.Label
        Dim PostalCodeLabel As System.Windows.Forms.Label
        Dim CountryLabel As System.Windows.Forms.Label
        Dim PhoneLabel As System.Windows.Forms.Label
        Dim ExtensionLabel As System.Windows.Forms.Label
        Dim FaxLabel As System.Windows.Forms.Label
        Dim HomePageLabel As System.Windows.Forms.Label
        Dim PhotoPathLabel As System.Windows.Forms.Label
        Me.DataRepeater1 = New Microsoft.VisualBasic.PowerPacks.DataRepeater
        Me.NorthwndDataSet = New VbPowerPacksDataRepeaterColor.northwndDataSet
        Me.ContactsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ContactsTableAdapter = New VbPowerPacksDataRepeaterColor.northwndDataSetTableAdapters.ContactsTableAdapter
        Me.TableAdapterManager = New VbPowerPacksDataRepeaterColor.northwndDataSetTableAdapters.TableAdapterManager
        Me.ContactsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.ContactsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ContactIDTextBox = New System.Windows.Forms.TextBox
        Me.ContactTypeTextBox = New System.Windows.Forms.TextBox
        Me.CompanyNameTextBox = New System.Windows.Forms.TextBox
        Me.ContactNameTextBox = New System.Windows.Forms.TextBox
        Me.ContactTitleTextBox = New System.Windows.Forms.TextBox
        Me.AddressTextBox = New System.Windows.Forms.TextBox
        Me.CityTextBox = New System.Windows.Forms.TextBox
        Me.RegionTextBox = New System.Windows.Forms.TextBox
        Me.PostalCodeTextBox = New System.Windows.Forms.TextBox
        Me.CountryTextBox = New System.Windows.Forms.TextBox
        Me.PhoneTextBox = New System.Windows.Forms.TextBox
        Me.ExtensionTextBox = New System.Windows.Forms.TextBox
        Me.FaxTextBox = New System.Windows.Forms.TextBox
        Me.HomePageTextBox = New System.Windows.Forms.TextBox
        Me.PhotoPathTextBox = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        ContactIDLabel = New System.Windows.Forms.Label
        ContactTypeLabel = New System.Windows.Forms.Label
        CompanyNameLabel = New System.Windows.Forms.Label
        ContactNameLabel = New System.Windows.Forms.Label
        ContactTitleLabel = New System.Windows.Forms.Label
        AddressLabel = New System.Windows.Forms.Label
        CityLabel = New System.Windows.Forms.Label
        RegionLabel = New System.Windows.Forms.Label
        PostalCodeLabel = New System.Windows.Forms.Label
        CountryLabel = New System.Windows.Forms.Label
        PhoneLabel = New System.Windows.Forms.Label
        ExtensionLabel = New System.Windows.Forms.Label
        FaxLabel = New System.Windows.Forms.Label
        HomePageLabel = New System.Windows.Forms.Label
        PhotoPathLabel = New System.Windows.Forms.Label
        Me.DataRepeater1.ItemTemplate.SuspendLayout()
        Me.DataRepeater1.SuspendLayout()
        CType(Me.NorthwndDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContactsBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataRepeater1
        '
        '
        'DataRepeater1.ItemTemplate
        '
        Me.DataRepeater1.ItemTemplate.Controls.Add(ContactIDLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.ContactIDTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(ContactTypeLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.ContactTypeTextBox)
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
        Me.DataRepeater1.ItemTemplate.Controls.Add(ExtensionLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.ExtensionTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(FaxLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.FaxTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(HomePageLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.HomePageTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(PhotoPathLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.PhotoPathTextBox)
        Me.DataRepeater1.ItemTemplate.Size = New System.Drawing.Size(421, 436)
        Me.DataRepeater1.Location = New System.Drawing.Point(29, 39)
        Me.DataRepeater1.Name = "DataRepeater1"
        Me.DataRepeater1.Size = New System.Drawing.Size(446, 441)
        Me.DataRepeater1.TabIndex = 0
        Me.DataRepeater1.Text = "DataRepeater1"
        '
        'NorthwndDataSet
        '
        Me.NorthwndDataSet.DataSetName = "northwndDataSet"
        Me.NorthwndDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ContactsBindingSource
        '
        Me.ContactsBindingSource.DataMember = "Contacts"
        Me.ContactsBindingSource.DataSource = Me.NorthwndDataSet
        '
        'ContactsTableAdapter
        '
        Me.ContactsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.ContactsTableAdapter = Me.ContactsTableAdapter
        Me.TableAdapterManager.UpdateOrder = VbPowerPacksDataRepeaterColor.northwndDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ContactsBindingNavigator
        '
        Me.ContactsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ContactsBindingNavigator.BindingSource = Me.ContactsBindingSource
        Me.ContactsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ContactsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ContactsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ContactsBindingNavigatorSaveItem})
        Me.ContactsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ContactsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ContactsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ContactsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ContactsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ContactsBindingNavigator.Name = "ContactsBindingNavigator"
        Me.ContactsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ContactsBindingNavigator.Size = New System.Drawing.Size(597, 25)
        Me.ContactsBindingNavigator.TabIndex = 1
        Me.ContactsBindingNavigator.Text = "BindingNavigator1"
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
        'ContactsBindingNavigatorSaveItem
        '
        Me.ContactsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ContactsBindingNavigatorSaveItem.Image = CType(resources.GetObject("ContactsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ContactsBindingNavigatorSaveItem.Name = "ContactsBindingNavigatorSaveItem"
        Me.ContactsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.ContactsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'ContactIDLabel
        '
        ContactIDLabel.AutoSize = True
        ContactIDLabel.Location = New System.Drawing.Point(48, 17)
        ContactIDLabel.Name = "ContactIDLabel"
        ContactIDLabel.Size = New System.Drawing.Size(61, 13)
        ContactIDLabel.TabIndex = 0
        ContactIDLabel.Text = "Contact ID:"
        '
        'ContactIDTextBox
        '
        Me.ContactIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "ContactID", True))
        Me.ContactIDTextBox.Location = New System.Drawing.Point(139, 14)
        Me.ContactIDTextBox.Name = "ContactIDTextBox"
        Me.ContactIDTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ContactIDTextBox.TabIndex = 1
        '
        'ContactTypeLabel
        '
        ContactTypeLabel.AutoSize = True
        ContactTypeLabel.Location = New System.Drawing.Point(48, 43)
        ContactTypeLabel.Name = "ContactTypeLabel"
        ContactTypeLabel.Size = New System.Drawing.Size(74, 13)
        ContactTypeLabel.TabIndex = 2
        ContactTypeLabel.Text = "Contact Type:"
        '
        'ContactTypeTextBox
        '
        Me.ContactTypeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "ContactType", True))
        Me.ContactTypeTextBox.Location = New System.Drawing.Point(139, 40)
        Me.ContactTypeTextBox.Name = "ContactTypeTextBox"
        Me.ContactTypeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ContactTypeTextBox.TabIndex = 3
        '
        'CompanyNameLabel
        '
        CompanyNameLabel.AutoSize = True
        CompanyNameLabel.Location = New System.Drawing.Point(48, 69)
        CompanyNameLabel.Name = "CompanyNameLabel"
        CompanyNameLabel.Size = New System.Drawing.Size(85, 13)
        CompanyNameLabel.TabIndex = 4
        CompanyNameLabel.Text = "Company Name:"
        '
        'CompanyNameTextBox
        '
        Me.CompanyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "CompanyName", True))
        Me.CompanyNameTextBox.Location = New System.Drawing.Point(139, 66)
        Me.CompanyNameTextBox.Name = "CompanyNameTextBox"
        Me.CompanyNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CompanyNameTextBox.TabIndex = 5
        '
        'ContactNameLabel
        '
        ContactNameLabel.AutoSize = True
        ContactNameLabel.Location = New System.Drawing.Point(48, 95)
        ContactNameLabel.Name = "ContactNameLabel"
        ContactNameLabel.Size = New System.Drawing.Size(78, 13)
        ContactNameLabel.TabIndex = 6
        ContactNameLabel.Text = "Contact Name:"
        '
        'ContactNameTextBox
        '
        Me.ContactNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "ContactName", True))
        Me.ContactNameTextBox.Location = New System.Drawing.Point(139, 92)
        Me.ContactNameTextBox.Name = "ContactNameTextBox"
        Me.ContactNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ContactNameTextBox.TabIndex = 7
        '
        'ContactTitleLabel
        '
        ContactTitleLabel.AutoSize = True
        ContactTitleLabel.Location = New System.Drawing.Point(48, 121)
        ContactTitleLabel.Name = "ContactTitleLabel"
        ContactTitleLabel.Size = New System.Drawing.Size(70, 13)
        ContactTitleLabel.TabIndex = 8
        ContactTitleLabel.Text = "Contact Title:"
        '
        'ContactTitleTextBox
        '
        Me.ContactTitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "ContactTitle", True))
        Me.ContactTitleTextBox.Location = New System.Drawing.Point(139, 118)
        Me.ContactTitleTextBox.Name = "ContactTitleTextBox"
        Me.ContactTitleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ContactTitleTextBox.TabIndex = 9
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Location = New System.Drawing.Point(48, 147)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(48, 13)
        AddressLabel.TabIndex = 10
        AddressLabel.Text = "Address:"
        '
        'AddressTextBox
        '
        Me.AddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "Address", True))
        Me.AddressTextBox.Location = New System.Drawing.Point(139, 144)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AddressTextBox.TabIndex = 11
        '
        'CityLabel
        '
        CityLabel.AutoSize = True
        CityLabel.Location = New System.Drawing.Point(48, 173)
        CityLabel.Name = "CityLabel"
        CityLabel.Size = New System.Drawing.Size(27, 13)
        CityLabel.TabIndex = 12
        CityLabel.Text = "City:"
        '
        'CityTextBox
        '
        Me.CityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "City", True))
        Me.CityTextBox.Location = New System.Drawing.Point(139, 170)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CityTextBox.TabIndex = 13
        '
        'RegionLabel
        '
        RegionLabel.AutoSize = True
        RegionLabel.Location = New System.Drawing.Point(48, 199)
        RegionLabel.Name = "RegionLabel"
        RegionLabel.Size = New System.Drawing.Size(44, 13)
        RegionLabel.TabIndex = 14
        RegionLabel.Text = "Region:"
        '
        'RegionTextBox
        '
        Me.RegionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "Region", True))
        Me.RegionTextBox.Location = New System.Drawing.Point(139, 196)
        Me.RegionTextBox.Name = "RegionTextBox"
        Me.RegionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RegionTextBox.TabIndex = 15
        '
        'PostalCodeLabel
        '
        PostalCodeLabel.AutoSize = True
        PostalCodeLabel.Location = New System.Drawing.Point(48, 225)
        PostalCodeLabel.Name = "PostalCodeLabel"
        PostalCodeLabel.Size = New System.Drawing.Size(67, 13)
        PostalCodeLabel.TabIndex = 16
        PostalCodeLabel.Text = "Postal Code:"
        '
        'PostalCodeTextBox
        '
        Me.PostalCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "PostalCode", True))
        Me.PostalCodeTextBox.Location = New System.Drawing.Point(139, 222)
        Me.PostalCodeTextBox.Name = "PostalCodeTextBox"
        Me.PostalCodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PostalCodeTextBox.TabIndex = 17
        '
        'CountryLabel
        '
        CountryLabel.AutoSize = True
        CountryLabel.Location = New System.Drawing.Point(48, 251)
        CountryLabel.Name = "CountryLabel"
        CountryLabel.Size = New System.Drawing.Size(46, 13)
        CountryLabel.TabIndex = 18
        CountryLabel.Text = "Country:"
        '
        'CountryTextBox
        '
        Me.CountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "Country", True))
        Me.CountryTextBox.Location = New System.Drawing.Point(139, 248)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CountryTextBox.TabIndex = 19
        '
        'PhoneLabel
        '
        PhoneLabel.AutoSize = True
        PhoneLabel.Location = New System.Drawing.Point(48, 277)
        PhoneLabel.Name = "PhoneLabel"
        PhoneLabel.Size = New System.Drawing.Size(41, 13)
        PhoneLabel.TabIndex = 20
        PhoneLabel.Text = "Phone:"
        '
        'PhoneTextBox
        '
        Me.PhoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "Phone", True))
        Me.PhoneTextBox.Location = New System.Drawing.Point(139, 274)
        Me.PhoneTextBox.Name = "PhoneTextBox"
        Me.PhoneTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PhoneTextBox.TabIndex = 21
        '
        'ExtensionLabel
        '
        ExtensionLabel.AutoSize = True
        ExtensionLabel.Location = New System.Drawing.Point(48, 303)
        ExtensionLabel.Name = "ExtensionLabel"
        ExtensionLabel.Size = New System.Drawing.Size(56, 13)
        ExtensionLabel.TabIndex = 22
        ExtensionLabel.Text = "Extension:"
        '
        'ExtensionTextBox
        '
        Me.ExtensionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "Extension", True))
        Me.ExtensionTextBox.Location = New System.Drawing.Point(139, 300)
        Me.ExtensionTextBox.Name = "ExtensionTextBox"
        Me.ExtensionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ExtensionTextBox.TabIndex = 23
        '
        'FaxLabel
        '
        FaxLabel.AutoSize = True
        FaxLabel.Location = New System.Drawing.Point(48, 329)
        FaxLabel.Name = "FaxLabel"
        FaxLabel.Size = New System.Drawing.Size(27, 13)
        FaxLabel.TabIndex = 24
        FaxLabel.Text = "Fax:"
        '
        'FaxTextBox
        '
        Me.FaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "Fax", True))
        Me.FaxTextBox.Location = New System.Drawing.Point(139, 326)
        Me.FaxTextBox.Name = "FaxTextBox"
        Me.FaxTextBox.Size = New System.Drawing.Size(100, 20)
        Me.FaxTextBox.TabIndex = 25
        '
        'HomePageLabel
        '
        HomePageLabel.AutoSize = True
        HomePageLabel.Location = New System.Drawing.Point(48, 355)
        HomePageLabel.Name = "HomePageLabel"
        HomePageLabel.Size = New System.Drawing.Size(66, 13)
        HomePageLabel.TabIndex = 26
        HomePageLabel.Text = "Home Page:"
        '
        'HomePageTextBox
        '
        Me.HomePageTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "HomePage", True))
        Me.HomePageTextBox.Location = New System.Drawing.Point(139, 352)
        Me.HomePageTextBox.Name = "HomePageTextBox"
        Me.HomePageTextBox.Size = New System.Drawing.Size(100, 20)
        Me.HomePageTextBox.TabIndex = 27
        '
        'PhotoPathLabel
        '
        PhotoPathLabel.AutoSize = True
        PhotoPathLabel.Location = New System.Drawing.Point(48, 381)
        PhotoPathLabel.Name = "PhotoPathLabel"
        PhotoPathLabel.Size = New System.Drawing.Size(63, 13)
        PhotoPathLabel.TabIndex = 28
        PhotoPathLabel.Text = "Photo Path:"
        '
        'PhotoPathTextBox
        '
        Me.PhotoPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContactsBindingSource, "PhotoPath", True))
        Me.PhotoPathTextBox.Location = New System.Drawing.Point(139, 378)
        Me.PhotoPathTextBox.Name = "PhotoPathTextBox"
        Me.PhotoPathTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PhotoPathTextBox.TabIndex = 29
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(491, 381)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Color
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 487)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ContactsBindingNavigator)
        Me.Controls.Add(Me.DataRepeater1)
        Me.Name = "Color"
        Me.Text = "Form1"
        Me.DataRepeater1.ItemTemplate.ResumeLayout(False)
        Me.DataRepeater1.ItemTemplate.PerformLayout()
        Me.DataRepeater1.ResumeLayout(False)
        CType(Me.NorthwndDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContactsBindingNavigator.ResumeLayout(False)
        Me.ContactsBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataRepeater1 As Microsoft.VisualBasic.PowerPacks.DataRepeater
    Friend WithEvents NorthwndDataSet As VbPowerPacksDataRepeaterColor.northwndDataSet
    Friend WithEvents ContactsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContactsTableAdapter As VbPowerPacksDataRepeaterColor.northwndDataSetTableAdapters.ContactsTableAdapter
    Friend WithEvents TableAdapterManager As VbPowerPacksDataRepeaterColor.northwndDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ContactsBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents ContactsBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContactIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContactTypeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContactNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContactTitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RegionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PostalCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CountryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ExtensionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FaxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HomePageTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhotoPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
