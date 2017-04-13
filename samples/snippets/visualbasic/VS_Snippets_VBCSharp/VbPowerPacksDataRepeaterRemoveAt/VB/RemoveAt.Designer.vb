<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemoveAt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RemoveAt))
        Dim EmployeeIDLabel As System.Windows.Forms.Label
        Dim LastNameLabel As System.Windows.Forms.Label
        Dim FirstNameLabel As System.Windows.Forms.Label
        Dim TitleLabel As System.Windows.Forms.Label
        Dim TitleOfCourtesyLabel As System.Windows.Forms.Label
        Dim BirthDateLabel As System.Windows.Forms.Label
        Dim HireDateLabel As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim CityLabel As System.Windows.Forms.Label
        Dim RegionLabel As System.Windows.Forms.Label
        Dim PostalCodeLabel As System.Windows.Forms.Label
        Dim CountryLabel As System.Windows.Forms.Label
        Dim HomePhoneLabel As System.Windows.Forms.Label
        Dim ExtensionLabel As System.Windows.Forms.Label
        Dim NotesLabel As System.Windows.Forms.Label
        Dim ReportsToLabel As System.Windows.Forms.Label
        Dim PhotoPathLabel As System.Windows.Forms.Label
        Me.DataRepeater1 = New Microsoft.VisualBasic.PowerPacks.DataRepeater
        Me.RemoveButton = New System.Windows.Forms.Button
        Me.NorthwndDataSet = New VbPowerPacksDataRepeaterRemoveAt.northwndDataSet
        Me.EmployeesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeesTableAdapter = New VbPowerPacksDataRepeaterRemoveAt.northwndDataSetTableAdapters.EmployeesTableAdapter
        Me.TableAdapterManager = New VbPowerPacksDataRepeaterRemoveAt.northwndDataSetTableAdapters.TableAdapterManager
        Me.EmployeesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.EmployeesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.EmployeeIDTextBox = New System.Windows.Forms.TextBox
        Me.LastNameTextBox = New System.Windows.Forms.TextBox
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox
        Me.TitleTextBox = New System.Windows.Forms.TextBox
        Me.TitleOfCourtesyTextBox = New System.Windows.Forms.TextBox
        Me.BirthDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.HireDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.AddressTextBox = New System.Windows.Forms.TextBox
        Me.CityTextBox = New System.Windows.Forms.TextBox
        Me.RegionTextBox = New System.Windows.Forms.TextBox
        Me.PostalCodeTextBox = New System.Windows.Forms.TextBox
        Me.CountryTextBox = New System.Windows.Forms.TextBox
        Me.HomePhoneTextBox = New System.Windows.Forms.TextBox
        Me.ExtensionTextBox = New System.Windows.Forms.TextBox
        Me.NotesTextBox = New System.Windows.Forms.TextBox
        Me.ReportsToTextBox = New System.Windows.Forms.TextBox
        Me.PhotoPathTextBox = New System.Windows.Forms.TextBox
        EmployeeIDLabel = New System.Windows.Forms.Label
        LastNameLabel = New System.Windows.Forms.Label
        FirstNameLabel = New System.Windows.Forms.Label
        TitleLabel = New System.Windows.Forms.Label
        TitleOfCourtesyLabel = New System.Windows.Forms.Label
        BirthDateLabel = New System.Windows.Forms.Label
        HireDateLabel = New System.Windows.Forms.Label
        AddressLabel = New System.Windows.Forms.Label
        CityLabel = New System.Windows.Forms.Label
        RegionLabel = New System.Windows.Forms.Label
        PostalCodeLabel = New System.Windows.Forms.Label
        CountryLabel = New System.Windows.Forms.Label
        HomePhoneLabel = New System.Windows.Forms.Label
        ExtensionLabel = New System.Windows.Forms.Label
        NotesLabel = New System.Windows.Forms.Label
        ReportsToLabel = New System.Windows.Forms.Label
        PhotoPathLabel = New System.Windows.Forms.Label
        Me.DataRepeater1.ItemTemplate.SuspendLayout()
        Me.DataRepeater1.SuspendLayout()
        CType(Me.NorthwndDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmployeesBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataRepeater1
        '
        '
        'DataRepeater1.ItemTemplate
        '
        Me.DataRepeater1.ItemTemplate.Controls.Add(EmployeeIDLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.EmployeeIDTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(LastNameLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.LastNameTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(FirstNameLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.FirstNameTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(TitleLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.TitleTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(TitleOfCourtesyLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.TitleOfCourtesyTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(BirthDateLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.BirthDateDateTimePicker)
        Me.DataRepeater1.ItemTemplate.Controls.Add(HireDateLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.HireDateDateTimePicker)
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
        Me.DataRepeater1.ItemTemplate.Controls.Add(HomePhoneLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.HomePhoneTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(ExtensionLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.ExtensionTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(NotesLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.NotesTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(ReportsToLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.ReportsToTextBox)
        Me.DataRepeater1.ItemTemplate.Controls.Add(PhotoPathLabel)
        Me.DataRepeater1.ItemTemplate.Controls.Add(Me.PhotoPathTextBox)
        Me.DataRepeater1.ItemTemplate.Size = New System.Drawing.Size(398, 495)
        Me.DataRepeater1.Location = New System.Drawing.Point(12, 28)
        Me.DataRepeater1.Name = "DataRepeater1"
        Me.DataRepeater1.Size = New System.Drawing.Size(423, 467)
        Me.DataRepeater1.TabIndex = 0
        Me.DataRepeater1.Text = "DataRepeater1"
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(469, 345)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(142, 32)
        Me.RemoveButton.TabIndex = 1
        Me.RemoveButton.Text = "Button1"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'NorthwndDataSet
        '
        Me.NorthwndDataSet.DataSetName = "northwndDataSet"
        Me.NorthwndDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmployeesBindingSource
        '
        Me.EmployeesBindingSource.DataMember = "Employees"
        Me.EmployeesBindingSource.DataSource = Me.NorthwndDataSet
        '
        'EmployeesTableAdapter
        '
        Me.EmployeesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EmployeesTableAdapter = Me.EmployeesTableAdapter
        Me.TableAdapterManager.UpdateOrder = VbPowerPacksDataRepeaterRemoveAt.northwndDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'EmployeesBindingNavigator
        '
        Me.EmployeesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.EmployeesBindingNavigator.BindingSource = Me.EmployeesBindingSource
        Me.EmployeesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.EmployeesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.EmployeesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.EmployeesBindingNavigatorSaveItem})
        Me.EmployeesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.EmployeesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.EmployeesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.EmployeesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.EmployeesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.EmployeesBindingNavigator.Name = "EmployeesBindingNavigator"
        Me.EmployeesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.EmployeesBindingNavigator.Size = New System.Drawing.Size(639, 25)
        Me.EmployeesBindingNavigator.TabIndex = 2
        Me.EmployeesBindingNavigator.Text = "BindingNavigator1"
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
        'EmployeesBindingNavigatorSaveItem
        '
        Me.EmployeesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EmployeesBindingNavigatorSaveItem.Image = CType(resources.GetObject("EmployeesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.EmployeesBindingNavigatorSaveItem.Name = "EmployeesBindingNavigatorSaveItem"
        Me.EmployeesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.EmployeesBindingNavigatorSaveItem.Text = "Save Data"
        '
        'EmployeeIDLabel
        '
        EmployeeIDLabel.AutoSize = True
        EmployeeIDLabel.Location = New System.Drawing.Point(31, 24)
        EmployeeIDLabel.Name = "EmployeeIDLabel"
        EmployeeIDLabel.Size = New System.Drawing.Size(70, 13)
        EmployeeIDLabel.TabIndex = 0
        EmployeeIDLabel.Text = "Employee ID:"
        '
        'EmployeeIDTextBox
        '
        Me.EmployeeIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "EmployeeID", True))
        Me.EmployeeIDTextBox.Location = New System.Drawing.Point(125, 21)
        Me.EmployeeIDTextBox.Name = "EmployeeIDTextBox"
        Me.EmployeeIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.EmployeeIDTextBox.TabIndex = 1
        '
        'LastNameLabel
        '
        LastNameLabel.AutoSize = True
        LastNameLabel.Location = New System.Drawing.Point(31, 50)
        LastNameLabel.Name = "LastNameLabel"
        LastNameLabel.Size = New System.Drawing.Size(61, 13)
        LastNameLabel.TabIndex = 2
        LastNameLabel.Text = "Last Name:"
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "LastName", True))
        Me.LastNameTextBox.Location = New System.Drawing.Point(125, 47)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.LastNameTextBox.TabIndex = 3
        '
        'FirstNameLabel
        '
        FirstNameLabel.AutoSize = True
        FirstNameLabel.Location = New System.Drawing.Point(31, 76)
        FirstNameLabel.Name = "FirstNameLabel"
        FirstNameLabel.Size = New System.Drawing.Size(60, 13)
        FirstNameLabel.TabIndex = 4
        FirstNameLabel.Text = "First Name:"
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "FirstName", True))
        Me.FirstNameTextBox.Location = New System.Drawing.Point(125, 73)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.FirstNameTextBox.TabIndex = 5
        '
        'TitleLabel
        '
        TitleLabel.AutoSize = True
        TitleLabel.Location = New System.Drawing.Point(31, 102)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New System.Drawing.Size(30, 13)
        TitleLabel.TabIndex = 6
        TitleLabel.Text = "Title:"
        '
        'TitleTextBox
        '
        Me.TitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "Title", True))
        Me.TitleTextBox.Location = New System.Drawing.Point(125, 99)
        Me.TitleTextBox.Name = "TitleTextBox"
        Me.TitleTextBox.Size = New System.Drawing.Size(200, 20)
        Me.TitleTextBox.TabIndex = 7
        '
        'TitleOfCourtesyLabel
        '
        TitleOfCourtesyLabel.AutoSize = True
        TitleOfCourtesyLabel.Location = New System.Drawing.Point(31, 128)
        TitleOfCourtesyLabel.Name = "TitleOfCourtesyLabel"
        TitleOfCourtesyLabel.Size = New System.Drawing.Size(88, 13)
        TitleOfCourtesyLabel.TabIndex = 8
        TitleOfCourtesyLabel.Text = "Title Of Courtesy:"
        '
        'TitleOfCourtesyTextBox
        '
        Me.TitleOfCourtesyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "TitleOfCourtesy", True))
        Me.TitleOfCourtesyTextBox.Location = New System.Drawing.Point(125, 125)
        Me.TitleOfCourtesyTextBox.Name = "TitleOfCourtesyTextBox"
        Me.TitleOfCourtesyTextBox.Size = New System.Drawing.Size(200, 20)
        Me.TitleOfCourtesyTextBox.TabIndex = 9
        '
        'BirthDateLabel
        '
        BirthDateLabel.AutoSize = True
        BirthDateLabel.Location = New System.Drawing.Point(31, 155)
        BirthDateLabel.Name = "BirthDateLabel"
        BirthDateLabel.Size = New System.Drawing.Size(57, 13)
        BirthDateLabel.TabIndex = 10
        BirthDateLabel.Text = "Birth Date:"
        '
        'BirthDateDateTimePicker
        '
        Me.BirthDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EmployeesBindingSource, "BirthDate", True))
        Me.BirthDateDateTimePicker.Location = New System.Drawing.Point(125, 151)
        Me.BirthDateDateTimePicker.Name = "BirthDateDateTimePicker"
        Me.BirthDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.BirthDateDateTimePicker.TabIndex = 11
        '
        'HireDateLabel
        '
        HireDateLabel.AutoSize = True
        HireDateLabel.Location = New System.Drawing.Point(31, 181)
        HireDateLabel.Name = "HireDateLabel"
        HireDateLabel.Size = New System.Drawing.Size(55, 13)
        HireDateLabel.TabIndex = 12
        HireDateLabel.Text = "Hire Date:"
        '
        'HireDateDateTimePicker
        '
        Me.HireDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EmployeesBindingSource, "HireDate", True))
        Me.HireDateDateTimePicker.Location = New System.Drawing.Point(125, 177)
        Me.HireDateDateTimePicker.Name = "HireDateDateTimePicker"
        Me.HireDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.HireDateDateTimePicker.TabIndex = 13
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Location = New System.Drawing.Point(31, 206)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(48, 13)
        AddressLabel.TabIndex = 14
        AddressLabel.Text = "Address:"
        '
        'AddressTextBox
        '
        Me.AddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "Address", True))
        Me.AddressTextBox.Location = New System.Drawing.Point(125, 203)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(200, 20)
        Me.AddressTextBox.TabIndex = 15
        '
        'CityLabel
        '
        CityLabel.AutoSize = True
        CityLabel.Location = New System.Drawing.Point(31, 232)
        CityLabel.Name = "CityLabel"
        CityLabel.Size = New System.Drawing.Size(27, 13)
        CityLabel.TabIndex = 16
        CityLabel.Text = "City:"
        '
        'CityTextBox
        '
        Me.CityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "City", True))
        Me.CityTextBox.Location = New System.Drawing.Point(125, 229)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CityTextBox.TabIndex = 17
        '
        'RegionLabel
        '
        RegionLabel.AutoSize = True
        RegionLabel.Location = New System.Drawing.Point(31, 258)
        RegionLabel.Name = "RegionLabel"
        RegionLabel.Size = New System.Drawing.Size(44, 13)
        RegionLabel.TabIndex = 18
        RegionLabel.Text = "Region:"
        '
        'RegionTextBox
        '
        Me.RegionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "Region", True))
        Me.RegionTextBox.Location = New System.Drawing.Point(125, 255)
        Me.RegionTextBox.Name = "RegionTextBox"
        Me.RegionTextBox.Size = New System.Drawing.Size(200, 20)
        Me.RegionTextBox.TabIndex = 19
        '
        'PostalCodeLabel
        '
        PostalCodeLabel.AutoSize = True
        PostalCodeLabel.Location = New System.Drawing.Point(31, 284)
        PostalCodeLabel.Name = "PostalCodeLabel"
        PostalCodeLabel.Size = New System.Drawing.Size(67, 13)
        PostalCodeLabel.TabIndex = 20
        PostalCodeLabel.Text = "Postal Code:"
        '
        'PostalCodeTextBox
        '
        Me.PostalCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "PostalCode", True))
        Me.PostalCodeTextBox.Location = New System.Drawing.Point(125, 281)
        Me.PostalCodeTextBox.Name = "PostalCodeTextBox"
        Me.PostalCodeTextBox.Size = New System.Drawing.Size(200, 20)
        Me.PostalCodeTextBox.TabIndex = 21
        '
        'CountryLabel
        '
        CountryLabel.AutoSize = True
        CountryLabel.Location = New System.Drawing.Point(31, 310)
        CountryLabel.Name = "CountryLabel"
        CountryLabel.Size = New System.Drawing.Size(46, 13)
        CountryLabel.TabIndex = 22
        CountryLabel.Text = "Country:"
        '
        'CountryTextBox
        '
        Me.CountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "Country", True))
        Me.CountryTextBox.Location = New System.Drawing.Point(125, 307)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CountryTextBox.TabIndex = 23
        '
        'HomePhoneLabel
        '
        HomePhoneLabel.AutoSize = True
        HomePhoneLabel.Location = New System.Drawing.Point(31, 336)
        HomePhoneLabel.Name = "HomePhoneLabel"
        HomePhoneLabel.Size = New System.Drawing.Size(72, 13)
        HomePhoneLabel.TabIndex = 24
        HomePhoneLabel.Text = "Home Phone:"
        '
        'HomePhoneTextBox
        '
        Me.HomePhoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "HomePhone", True))
        Me.HomePhoneTextBox.Location = New System.Drawing.Point(125, 333)
        Me.HomePhoneTextBox.Name = "HomePhoneTextBox"
        Me.HomePhoneTextBox.Size = New System.Drawing.Size(200, 20)
        Me.HomePhoneTextBox.TabIndex = 25
        '
        'ExtensionLabel
        '
        ExtensionLabel.AutoSize = True
        ExtensionLabel.Location = New System.Drawing.Point(31, 362)
        ExtensionLabel.Name = "ExtensionLabel"
        ExtensionLabel.Size = New System.Drawing.Size(56, 13)
        ExtensionLabel.TabIndex = 26
        ExtensionLabel.Text = "Extension:"
        '
        'ExtensionTextBox
        '
        Me.ExtensionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "Extension", True))
        Me.ExtensionTextBox.Location = New System.Drawing.Point(125, 359)
        Me.ExtensionTextBox.Name = "ExtensionTextBox"
        Me.ExtensionTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ExtensionTextBox.TabIndex = 27
        '
        'NotesLabel
        '
        NotesLabel.AutoSize = True
        NotesLabel.Location = New System.Drawing.Point(31, 388)
        NotesLabel.Name = "NotesLabel"
        NotesLabel.Size = New System.Drawing.Size(38, 13)
        NotesLabel.TabIndex = 28
        NotesLabel.Text = "Notes:"
        '
        'NotesTextBox
        '
        Me.NotesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "Notes", True))
        Me.NotesTextBox.Location = New System.Drawing.Point(125, 385)
        Me.NotesTextBox.Name = "NotesTextBox"
        Me.NotesTextBox.Size = New System.Drawing.Size(200, 20)
        Me.NotesTextBox.TabIndex = 29
        '
        'ReportsToLabel
        '
        ReportsToLabel.AutoSize = True
        ReportsToLabel.Location = New System.Drawing.Point(31, 414)
        ReportsToLabel.Name = "ReportsToLabel"
        ReportsToLabel.Size = New System.Drawing.Size(63, 13)
        ReportsToLabel.TabIndex = 30
        ReportsToLabel.Text = "Reports To:"
        '
        'ReportsToTextBox
        '
        Me.ReportsToTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "ReportsTo", True))
        Me.ReportsToTextBox.Location = New System.Drawing.Point(125, 411)
        Me.ReportsToTextBox.Name = "ReportsToTextBox"
        Me.ReportsToTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ReportsToTextBox.TabIndex = 31
        '
        'PhotoPathLabel
        '
        PhotoPathLabel.AutoSize = True
        PhotoPathLabel.Location = New System.Drawing.Point(31, 440)
        PhotoPathLabel.Name = "PhotoPathLabel"
        PhotoPathLabel.Size = New System.Drawing.Size(63, 13)
        PhotoPathLabel.TabIndex = 32
        PhotoPathLabel.Text = "Photo Path:"
        '
        'PhotoPathTextBox
        '
        Me.PhotoPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeesBindingSource, "PhotoPath", True))
        Me.PhotoPathTextBox.Location = New System.Drawing.Point(125, 437)
        Me.PhotoPathTextBox.Name = "PhotoPathTextBox"
        Me.PhotoPathTextBox.Size = New System.Drawing.Size(200, 20)
        Me.PhotoPathTextBox.TabIndex = 33
        '
        'RemoveAt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 536)
        Me.Controls.Add(Me.EmployeesBindingNavigator)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.DataRepeater1)
        Me.Name = "RemoveAt"
        Me.Text = "Form1"
        Me.DataRepeater1.ItemTemplate.ResumeLayout(False)
        Me.DataRepeater1.ItemTemplate.PerformLayout()
        Me.DataRepeater1.ResumeLayout(False)
        CType(Me.NorthwndDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmployeesBindingNavigator.ResumeLayout(False)
        Me.EmployeesBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataRepeater1 As Microsoft.VisualBasic.PowerPacks.DataRepeater
    Friend WithEvents RemoveButton As System.Windows.Forms.Button
    Friend WithEvents NorthwndDataSet As VbPowerPacksDataRepeaterRemoveAt.northwndDataSet
    Friend WithEvents EmployeesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeesTableAdapter As VbPowerPacksDataRepeaterRemoveAt.northwndDataSetTableAdapters.EmployeesTableAdapter
    Friend WithEvents TableAdapterManager As VbPowerPacksDataRepeaterRemoveAt.northwndDataSetTableAdapters.TableAdapterManager
    Friend WithEvents EmployeesBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents EmployeesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents EmployeeIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LastNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FirstNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TitleOfCourtesyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BirthDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents HireDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents AddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RegionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PostalCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CountryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HomePhoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ExtensionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NotesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReportsToTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhotoPathTextBox As System.Windows.Forms.TextBox

End Class
