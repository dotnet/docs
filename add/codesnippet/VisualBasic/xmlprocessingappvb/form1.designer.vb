<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TreeViewGroupBox = New System.Windows.Forms.GroupBox()
        Me.xmlTreeView = New System.Windows.Forms.TreeView()
        Me.TextGroupBox = New System.Windows.Forms.GroupBox()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.refreshTreeButton = New System.Windows.Forms.Button()
        Me.positionDownButton = New System.Windows.Forms.Button()
        Me.positionUpButton = New System.Windows.Forms.Button()
        Me.XmlTextBox = New System.Windows.Forms.RichTextBox()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.loadTab = New System.Windows.Forms.TabPage()
        Me.optionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.generateSchemaCheckBox = New System.Windows.Forms.CheckBox()
        Me.generateCheckBox = New System.Windows.Forms.CheckBox()
        Me.validateCheckBox = New System.Windows.Forms.CheckBox()
        Me.loadButton = New System.Windows.Forms.Button()
        Me.addTab = New System.Windows.Forms.TabPage()
        Me.addElementGroupBox = New System.Windows.Forms.GroupBox()
        Me.newPositionLabel = New System.Windows.Forms.Label()
        Me.positionComboBox = New System.Windows.Forms.ComboBox()
        Me.newTitleTextBox = New System.Windows.Forms.TextBox()
        Me.newTitleLabel = New System.Windows.Forms.Label()
        Me.newISBNLabel = New System.Windows.Forms.Label()
        Me.newPriceLabel = New System.Windows.Forms.Label()
        Me.newISBNTextBox = New System.Windows.Forms.TextBox()
        Me.newPriceTextBox = New System.Windows.Forms.TextBox()
        Me.newPubDateLabel = New System.Windows.Forms.Label()
        Me.newGenreLabel = New System.Windows.Forms.Label()
        Me.newPubDateTextBox = New System.Windows.Forms.TextBox()
        Me.addNewBookButton = New System.Windows.Forms.Button()
        Me.newGenreTextBox = New System.Windows.Forms.TextBox()
        Me.editTab = New System.Windows.Forms.TabPage()
        Me.EditElementGroupBox = New System.Windows.Forms.GroupBox()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.editTitleTextBox = New System.Windows.Forms.TextBox()
        Me.editTitleLabel = New System.Windows.Forms.Label()
        Me.editISBNLabel = New System.Windows.Forms.Label()
        Me.editPriceLabel = New System.Windows.Forms.Label()
        Me.editISBNTextBox = New System.Windows.Forms.TextBox()
        Me.editPriceTextBox = New System.Windows.Forms.TextBox()
        Me.editPubDateLabel = New System.Windows.Forms.Label()
        Me.editGenreLabel = New System.Windows.Forms.Label()
        Me.editPubDateTextBox = New System.Windows.Forms.TextBox()
        Me.submitButton = New System.Windows.Forms.Button()
        Me.editGenreTextBox = New System.Windows.Forms.TextBox()
        Me.filterTab = New System.Windows.Forms.TabPage()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.matchesComboBox = New System.Windows.Forms.ComboBox()
        Me.matchesLabel = New System.Windows.Forms.Label()
        Me.applyLabel = New System.Windows.Forms.Label()
        Me.condition4Panel = New System.Windows.Forms.Panel()
        Me.condition4CheckBox = New System.Windows.Forms.CheckBox()
        Me.operator4ComboBox = New System.Windows.Forms.ComboBox()
        Me.condition4ComboBox = New System.Windows.Forms.ComboBox()
        Me.condition4TextBox = New System.Windows.Forms.TextBox()
        Me.condition3Panel = New System.Windows.Forms.Panel()
        Me.condition3CheckBox = New System.Windows.Forms.CheckBox()
        Me.operator3ComboBox = New System.Windows.Forms.ComboBox()
        Me.condition3ComboBox = New System.Windows.Forms.ComboBox()
        Me.condition3TextBox = New System.Windows.Forms.TextBox()
        Me.condition2Panel = New System.Windows.Forms.Panel()
        Me.condition2CheckBox = New System.Windows.Forms.CheckBox()
        Me.operator2ComboBox = New System.Windows.Forms.ComboBox()
        Me.condition2ComboBox = New System.Windows.Forms.ComboBox()
        Me.condition2TextBox = New System.Windows.Forms.TextBox()
        Me.condition1Panel = New System.Windows.Forms.Panel()
        Me.condition1CheckBox = New System.Windows.Forms.CheckBox()
        Me.operator1ComboBox = New System.Windows.Forms.ComboBox()
        Me.condition1ComboBox = New System.Windows.Forms.ComboBox()
        Me.condition1TextBox = New System.Windows.Forms.TextBox()
        Me.clearButton = New System.Windows.Forms.Button()
        Me.addFilterButton = New System.Windows.Forms.Button()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.filterBox = New System.Windows.Forms.GroupBox()
        Me.filterTreeView = New System.Windows.Forms.TreeView()
        Me.TreeViewGroupBox.SuspendLayout()
        Me.TextGroupBox.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.loadTab.SuspendLayout()
        Me.optionsGroupBox.SuspendLayout()
        Me.addTab.SuspendLayout()
        Me.addElementGroupBox.SuspendLayout()
        Me.editTab.SuspendLayout()
        Me.EditElementGroupBox.SuspendLayout()
        Me.filterTab.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.condition4Panel.SuspendLayout()
        Me.condition3Panel.SuspendLayout()
        Me.condition2Panel.SuspendLayout()
        Me.condition1Panel.SuspendLayout()
        Me.filterBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeViewGroupBox
        '
        Me.TreeViewGroupBox.Controls.Add(Me.xmlTreeView)
        Me.TreeViewGroupBox.ForeColor = System.Drawing.Color.White
        Me.TreeViewGroupBox.Location = New System.Drawing.Point(373, 12)
        Me.TreeViewGroupBox.Name = "TreeViewGroupBox"
        Me.TreeViewGroupBox.Size = New System.Drawing.Size(286, 688)
        Me.TreeViewGroupBox.TabIndex = 4
        Me.TreeViewGroupBox.TabStop = False
        Me.TreeViewGroupBox.Text = "Book List"
        '
        'xmlTreeView
        '
        Me.xmlTreeView.BackColor = System.Drawing.Color.Black
        Me.xmlTreeView.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xmlTreeView.ForeColor = System.Drawing.Color.White
        Me.xmlTreeView.Location = New System.Drawing.Point(16, 19)
        Me.xmlTreeView.Name = "xmlTreeView"
        Me.xmlTreeView.Size = New System.Drawing.Size(258, 656)
        Me.xmlTreeView.TabIndex = 3
        '
        'TextGroupBox
        '
        Me.TextGroupBox.Controls.Add(Me.saveButton)
        Me.TextGroupBox.Controls.Add(Me.refreshTreeButton)
        Me.TextGroupBox.Controls.Add(Me.positionDownButton)
        Me.TextGroupBox.Controls.Add(Me.positionUpButton)
        Me.TextGroupBox.Controls.Add(Me.XmlTextBox)
        Me.TextGroupBox.ForeColor = System.Drawing.Color.White
        Me.TextGroupBox.Location = New System.Drawing.Point(665, 12)
        Me.TextGroupBox.Name = "TextGroupBox"
        Me.TextGroupBox.Size = New System.Drawing.Size(526, 688)
        Me.TextGroupBox.TabIndex = 5
        Me.TextGroupBox.TabStop = False
        Me.TextGroupBox.Text = "Xml View"
        '
        'saveButton
        '
        Me.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveButton.Image = CType(resources.GetObject("saveButton.Image"), System.Drawing.Image)
        Me.saveButton.Location = New System.Drawing.Point(6, 196)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(31, 34)
        Me.saveButton.TabIndex = 38
        Me.toolTip1.SetToolTip(Me.saveButton, "Save XML with new element positions")
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'refreshTreeButton
        '
        Me.refreshTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.refreshTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.refreshTreeButton.Image = CType(resources.GetObject("refreshTreeButton.Image"), System.Drawing.Image)
        Me.refreshTreeButton.Location = New System.Drawing.Point(6, 150)
        Me.refreshTreeButton.Name = "refreshTreeButton"
        Me.refreshTreeButton.Size = New System.Drawing.Size(31, 34)
        Me.refreshTreeButton.TabIndex = 37
        Me.toolTip1.SetToolTip(Me.refreshTreeButton, "Refresh tree view to reflect new order of elements")
        Me.refreshTreeButton.UseVisualStyleBackColor = True
        '
        'positionDownButton
        '
        Me.positionDownButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.positionDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.positionDownButton.Image = CType(resources.GetObject("positionDownButton.Image"), System.Drawing.Image)
        Me.positionDownButton.Location = New System.Drawing.Point(6, 105)
        Me.positionDownButton.Name = "positionDownButton"
        Me.positionDownButton.Size = New System.Drawing.Size(31, 34)
        Me.positionDownButton.TabIndex = 36
        Me.toolTip1.SetToolTip(Me.positionDownButton, "Move selected item down in the list")
        Me.positionDownButton.UseVisualStyleBackColor = True
        '
        'positionUpButton
        '
        Me.positionUpButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.positionUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.positionUpButton.Image = CType(resources.GetObject("positionUpButton.Image"), System.Drawing.Image)
        Me.positionUpButton.Location = New System.Drawing.Point(6, 59)
        Me.positionUpButton.Name = "positionUpButton"
        Me.positionUpButton.Size = New System.Drawing.Size(31, 34)
        Me.positionUpButton.TabIndex = 35
        Me.toolTip1.SetToolTip(Me.positionUpButton, "Move selected item up in the list")
        Me.positionUpButton.UseVisualStyleBackColor = True
        '
        'XmlTextBox
        '
        Me.XmlTextBox.BackColor = System.Drawing.Color.Black
        Me.XmlTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XmlTextBox.ForeColor = System.Drawing.Color.White
        Me.XmlTextBox.Location = New System.Drawing.Point(43, 19)
        Me.XmlTextBox.Name = "XmlTextBox"
        Me.XmlTextBox.Size = New System.Drawing.Size(477, 656)
        Me.XmlTextBox.TabIndex = 6
        Me.XmlTextBox.Text = ""
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.loadTab)
        Me.tabControl1.Controls.Add(Me.addTab)
        Me.tabControl1.Controls.Add(Me.editTab)
        Me.tabControl1.Controls.Add(Me.filterTab)
        Me.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl1.Location = New System.Drawing.Point(12, 12)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(354, 247)
        Me.tabControl1.TabIndex = 7
        '
        'loadTab
        '
        Me.loadTab.BackColor = System.Drawing.Color.Black
        Me.loadTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.loadTab.Controls.Add(Me.optionsGroupBox)
        Me.loadTab.Controls.Add(Me.loadButton)
        Me.loadTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loadTab.ForeColor = System.Drawing.Color.White
        Me.loadTab.Location = New System.Drawing.Point(4, 25)
        Me.loadTab.Name = "loadTab"
        Me.loadTab.Padding = New System.Windows.Forms.Padding(3)
        Me.loadTab.Size = New System.Drawing.Size(346, 218)
        Me.loadTab.TabIndex = 1
        Me.loadTab.Text = "Load XML"
        '
        'optionsGroupBox
        '
        Me.optionsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.optionsGroupBox.Controls.Add(Me.generateSchemaCheckBox)
        Me.optionsGroupBox.Controls.Add(Me.generateCheckBox)
        Me.optionsGroupBox.Controls.Add(Me.validateCheckBox)
        Me.optionsGroupBox.ForeColor = System.Drawing.Color.White
        Me.optionsGroupBox.Location = New System.Drawing.Point(16, 56)
        Me.optionsGroupBox.Name = "optionsGroupBox"
        Me.optionsGroupBox.Size = New System.Drawing.Size(324, 104)
        Me.optionsGroupBox.TabIndex = 8
        Me.optionsGroupBox.TabStop = False
        Me.optionsGroupBox.Text = "Options"
        '
        'generateSchemaCheckBox
        '
        Me.generateSchemaCheckBox.AutoSize = True
        Me.generateSchemaCheckBox.Enabled = False
        Me.generateSchemaCheckBox.Location = New System.Drawing.Point(14, 77)
        Me.generateSchemaCheckBox.Name = "generateSchemaCheckBox"
        Me.generateSchemaCheckBox.Size = New System.Drawing.Size(295, 20)
        Me.generateSchemaCheckBox.TabIndex = 10
        Me.generateSchemaCheckBox.Text = "If the schema file is not found, then generate it."
        Me.generateSchemaCheckBox.UseVisualStyleBackColor = True
        Me.generateSchemaCheckBox.Visible = False
        '
        'generateCheckBox
        '
        Me.generateCheckBox.AutoSize = True
        Me.generateCheckBox.ForeColor = System.Drawing.Color.White
        Me.generateCheckBox.Location = New System.Drawing.Point(13, 24)
        Me.generateCheckBox.Name = "generateCheckBox"
        Me.generateCheckBox.Size = New System.Drawing.Size(257, 20)
        Me.generateCheckBox.TabIndex = 9
        Me.generateCheckBox.Text = "If the file is not found, generate the XML."
        Me.generateCheckBox.UseVisualStyleBackColor = True
        '
        'validateCheckBox
        '
        Me.validateCheckBox.AutoSize = True
        Me.validateCheckBox.ForeColor = System.Drawing.Color.White
        Me.validateCheckBox.Location = New System.Drawing.Point(13, 51)
        Me.validateCheckBox.Name = "validateCheckBox"
        Me.validateCheckBox.Size = New System.Drawing.Size(239, 20)
        Me.validateCheckBox.TabIndex = 8
        Me.validateCheckBox.Text = "Validate the XML against a schema."
        Me.validateCheckBox.UseVisualStyleBackColor = True
        '
        'loadButton
        '
        Me.loadButton.BackColor = System.Drawing.Color.Black
        Me.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loadButton.Location = New System.Drawing.Point(16, 16)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(136, 27)
        Me.loadButton.TabIndex = 0
        Me.loadButton.Text = "Load XML from file"
        Me.loadButton.UseVisualStyleBackColor = False
        '
        'addTab
        '
        Me.addTab.BackColor = System.Drawing.Color.Black
        Me.addTab.Controls.Add(Me.addElementGroupBox)
        Me.addTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addTab.ForeColor = System.Drawing.Color.White
        Me.addTab.Location = New System.Drawing.Point(4, 25)
        Me.addTab.Name = "addTab"
        Me.addTab.Padding = New System.Windows.Forms.Padding(3)
        Me.addTab.Size = New System.Drawing.Size(346, 218)
        Me.addTab.TabIndex = 0
        Me.addTab.Text = "Add Book"
        '
        'addElementGroupBox
        '
        Me.addElementGroupBox.Controls.Add(Me.newPositionLabel)
        Me.addElementGroupBox.Controls.Add(Me.positionComboBox)
        Me.addElementGroupBox.Controls.Add(Me.newTitleTextBox)
        Me.addElementGroupBox.Controls.Add(Me.newTitleLabel)
        Me.addElementGroupBox.Controls.Add(Me.newISBNLabel)
        Me.addElementGroupBox.Controls.Add(Me.newPriceLabel)
        Me.addElementGroupBox.Controls.Add(Me.newISBNTextBox)
        Me.addElementGroupBox.Controls.Add(Me.newPriceTextBox)
        Me.addElementGroupBox.Controls.Add(Me.newPubDateLabel)
        Me.addElementGroupBox.Controls.Add(Me.newGenreLabel)
        Me.addElementGroupBox.Controls.Add(Me.newPubDateTextBox)
        Me.addElementGroupBox.Controls.Add(Me.addNewBookButton)
        Me.addElementGroupBox.Controls.Add(Me.newGenreTextBox)
        Me.addElementGroupBox.Location = New System.Drawing.Point(6, 6)
        Me.addElementGroupBox.Name = "addElementGroupBox"
        Me.addElementGroupBox.Size = New System.Drawing.Size(334, 201)
        Me.addElementGroupBox.TabIndex = 0
        Me.addElementGroupBox.TabStop = False
        '
        'newPositionLabel
        '
        Me.newPositionLabel.AutoSize = True
        Me.newPositionLabel.Location = New System.Drawing.Point(18, 164)
        Me.newPositionLabel.Name = "newPositionLabel"
        Me.newPositionLabel.Size = New System.Drawing.Size(59, 16)
        Me.newPositionLabel.TabIndex = 28
        Me.newPositionLabel.Text = "Position:"
        '
        'positionComboBox
        '
        Me.positionComboBox.BackColor = System.Drawing.Color.Black
        Me.positionComboBox.ForeColor = System.Drawing.Color.White
        Me.positionComboBox.FormattingEnabled = True
        Me.positionComboBox.Items.AddRange(New Object() {"Top", "Bottom", "Above selected item", "Below selected item"})
        Me.positionComboBox.Location = New System.Drawing.Point(111, 157)
        Me.positionComboBox.Name = "positionComboBox"
        Me.positionComboBox.Size = New System.Drawing.Size(128, 24)
        Me.positionComboBox.TabIndex = 27
        Me.positionComboBox.Text = "Top"
        '
        'newTitleTextBox
        '
        Me.newTitleTextBox.BackColor = System.Drawing.Color.Black
        Me.newTitleTextBox.ForeColor = System.Drawing.Color.White
        Me.newTitleTextBox.Location = New System.Drawing.Point(111, 21)
        Me.newTitleTextBox.Name = "newTitleTextBox"
        Me.newTitleTextBox.Size = New System.Drawing.Size(192, 22)
        Me.newTitleTextBox.TabIndex = 16
        '
        'newTitleLabel
        '
        Me.newTitleLabel.AutoSize = True
        Me.newTitleLabel.Location = New System.Drawing.Point(18, 21)
        Me.newTitleLabel.Name = "newTitleLabel"
        Me.newTitleLabel.Size = New System.Drawing.Size(37, 16)
        Me.newTitleLabel.TabIndex = 18
        Me.newTitleLabel.Text = "Title:"
        '
        'newISBNLabel
        '
        Me.newISBNLabel.AutoSize = True
        Me.newISBNLabel.Location = New System.Drawing.Point(18, 48)
        Me.newISBNLabel.Name = "newISBNLabel"
        Me.newISBNLabel.Size = New System.Drawing.Size(42, 16)
        Me.newISBNLabel.TabIndex = 19
        Me.newISBNLabel.Text = "ISBN:"
        '
        'newPriceLabel
        '
        Me.newPriceLabel.AutoSize = True
        Me.newPriceLabel.Location = New System.Drawing.Point(18, 107)
        Me.newPriceLabel.Name = "newPriceLabel"
        Me.newPriceLabel.Size = New System.Drawing.Size(42, 16)
        Me.newPriceLabel.TabIndex = 26
        Me.newPriceLabel.Text = "Price:"
        '
        'newISBNTextBox
        '
        Me.newISBNTextBox.BackColor = System.Drawing.Color.Black
        Me.newISBNTextBox.ForeColor = System.Drawing.Color.White
        Me.newISBNTextBox.Location = New System.Drawing.Point(111, 48)
        Me.newISBNTextBox.Name = "newISBNTextBox"
        Me.newISBNTextBox.Size = New System.Drawing.Size(192, 22)
        Me.newISBNTextBox.TabIndex = 20
        '
        'newPriceTextBox
        '
        Me.newPriceTextBox.BackColor = System.Drawing.Color.Black
        Me.newPriceTextBox.ForeColor = System.Drawing.Color.White
        Me.newPriceTextBox.Location = New System.Drawing.Point(111, 100)
        Me.newPriceTextBox.Name = "newPriceTextBox"
        Me.newPriceTextBox.Size = New System.Drawing.Size(75, 22)
        Me.newPriceTextBox.TabIndex = 25
        '
        'newPubDateLabel
        '
        Me.newPubDateLabel.AutoSize = True
        Me.newPubDateLabel.Location = New System.Drawing.Point(18, 74)
        Me.newPubDateLabel.Name = "newPubDateLabel"
        Me.newPubDateLabel.Size = New System.Drawing.Size(87, 16)
        Me.newPubDateLabel.TabIndex = 21
        Me.newPubDateLabel.Text = "Publish Date:"
        '
        'newGenreLabel
        '
        Me.newGenreLabel.AutoSize = True
        Me.newGenreLabel.Location = New System.Drawing.Point(18, 135)
        Me.newGenreLabel.Name = "newGenreLabel"
        Me.newGenreLabel.Size = New System.Drawing.Size(48, 16)
        Me.newGenreLabel.TabIndex = 24
        Me.newGenreLabel.Text = "Genre:"
        '
        'newPubDateTextBox
        '
        Me.newPubDateTextBox.BackColor = System.Drawing.Color.Black
        Me.newPubDateTextBox.ForeColor = System.Drawing.Color.White
        Me.newPubDateTextBox.Location = New System.Drawing.Point(111, 74)
        Me.newPubDateTextBox.Name = "newPubDateTextBox"
        Me.newPubDateTextBox.Size = New System.Drawing.Size(125, 22)
        Me.newPubDateTextBox.TabIndex = 22
        '
        'addNewBookButton
        '
        Me.addNewBookButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addNewBookButton.Location = New System.Drawing.Point(245, 157)
        Me.addNewBookButton.Name = "addNewBookButton"
        Me.addNewBookButton.Size = New System.Drawing.Size(70, 24)
        Me.addNewBookButton.TabIndex = 17
        Me.addNewBookButton.Text = "Add"
        Me.addNewBookButton.UseVisualStyleBackColor = True
        '
        'newGenreTextBox
        '
        Me.newGenreTextBox.BackColor = System.Drawing.Color.Black
        Me.newGenreTextBox.ForeColor = System.Drawing.Color.White
        Me.newGenreTextBox.Location = New System.Drawing.Point(111, 128)
        Me.newGenreTextBox.Name = "newGenreTextBox"
        Me.newGenreTextBox.Size = New System.Drawing.Size(125, 22)
        Me.newGenreTextBox.TabIndex = 23
        '
        'editTab
        '
        Me.editTab.BackColor = System.Drawing.Color.Black
        Me.editTab.Controls.Add(Me.EditElementGroupBox)
        Me.editTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editTab.ForeColor = System.Drawing.Color.White
        Me.editTab.Location = New System.Drawing.Point(4, 25)
        Me.editTab.Name = "editTab"
        Me.editTab.Padding = New System.Windows.Forms.Padding(3)
        Me.editTab.Size = New System.Drawing.Size(346, 218)
        Me.editTab.TabIndex = 2
        Me.editTab.Text = "Edit Books"
        '
        'EditElementGroupBox
        '
        Me.EditElementGroupBox.Controls.Add(Me.deleteButton)
        Me.EditElementGroupBox.Controls.Add(Me.editTitleTextBox)
        Me.EditElementGroupBox.Controls.Add(Me.editTitleLabel)
        Me.EditElementGroupBox.Controls.Add(Me.editISBNLabel)
        Me.EditElementGroupBox.Controls.Add(Me.editPriceLabel)
        Me.EditElementGroupBox.Controls.Add(Me.editISBNTextBox)
        Me.EditElementGroupBox.Controls.Add(Me.editPriceTextBox)
        Me.EditElementGroupBox.Controls.Add(Me.editPubDateLabel)
        Me.EditElementGroupBox.Controls.Add(Me.editGenreLabel)
        Me.EditElementGroupBox.Controls.Add(Me.editPubDateTextBox)
        Me.EditElementGroupBox.Controls.Add(Me.submitButton)
        Me.EditElementGroupBox.Controls.Add(Me.editGenreTextBox)
        Me.EditElementGroupBox.Location = New System.Drawing.Point(6, 6)
        Me.EditElementGroupBox.Name = "EditElementGroupBox"
        Me.EditElementGroupBox.Size = New System.Drawing.Size(334, 201)
        Me.EditElementGroupBox.TabIndex = 1
        Me.EditElementGroupBox.TabStop = False
        '
        'deleteButton
        '
        Me.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteButton.Location = New System.Drawing.Point(21, 163)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(119, 25)
        Me.deleteButton.TabIndex = 27
        Me.deleteButton.Text = "Delete Book"
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'editTitleTextBox
        '
        Me.editTitleTextBox.BackColor = System.Drawing.Color.Black
        Me.editTitleTextBox.ForeColor = System.Drawing.Color.White
        Me.editTitleTextBox.Location = New System.Drawing.Point(111, 21)
        Me.editTitleTextBox.Name = "editTitleTextBox"
        Me.editTitleTextBox.Size = New System.Drawing.Size(192, 22)
        Me.editTitleTextBox.TabIndex = 16
        '
        'editTitleLabel
        '
        Me.editTitleLabel.AutoSize = True
        Me.editTitleLabel.Location = New System.Drawing.Point(18, 21)
        Me.editTitleLabel.Name = "editTitleLabel"
        Me.editTitleLabel.Size = New System.Drawing.Size(37, 16)
        Me.editTitleLabel.TabIndex = 18
        Me.editTitleLabel.Text = "Title:"
        '
        'editISBNLabel
        '
        Me.editISBNLabel.AutoSize = True
        Me.editISBNLabel.Location = New System.Drawing.Point(18, 48)
        Me.editISBNLabel.Name = "editISBNLabel"
        Me.editISBNLabel.Size = New System.Drawing.Size(42, 16)
        Me.editISBNLabel.TabIndex = 19
        Me.editISBNLabel.Text = "ISBN:"
        '
        'editPriceLabel
        '
        Me.editPriceLabel.AutoSize = True
        Me.editPriceLabel.Location = New System.Drawing.Point(18, 107)
        Me.editPriceLabel.Name = "editPriceLabel"
        Me.editPriceLabel.Size = New System.Drawing.Size(42, 16)
        Me.editPriceLabel.TabIndex = 26
        Me.editPriceLabel.Text = "Price:"
        '
        'editISBNTextBox
        '
        Me.editISBNTextBox.BackColor = System.Drawing.Color.Black
        Me.editISBNTextBox.ForeColor = System.Drawing.Color.White
        Me.editISBNTextBox.Location = New System.Drawing.Point(111, 48)
        Me.editISBNTextBox.Name = "editISBNTextBox"
        Me.editISBNTextBox.Size = New System.Drawing.Size(192, 22)
        Me.editISBNTextBox.TabIndex = 20
        '
        'editPriceTextBox
        '
        Me.editPriceTextBox.BackColor = System.Drawing.Color.Black
        Me.editPriceTextBox.ForeColor = System.Drawing.Color.White
        Me.editPriceTextBox.Location = New System.Drawing.Point(111, 100)
        Me.editPriceTextBox.Name = "editPriceTextBox"
        Me.editPriceTextBox.Size = New System.Drawing.Size(75, 22)
        Me.editPriceTextBox.TabIndex = 25
        '
        'editPubDateLabel
        '
        Me.editPubDateLabel.AutoSize = True
        Me.editPubDateLabel.Location = New System.Drawing.Point(18, 74)
        Me.editPubDateLabel.Name = "editPubDateLabel"
        Me.editPubDateLabel.Size = New System.Drawing.Size(87, 16)
        Me.editPubDateLabel.TabIndex = 21
        Me.editPubDateLabel.Text = "Publish Date:"
        '
        'editGenreLabel
        '
        Me.editGenreLabel.AutoSize = True
        Me.editGenreLabel.Location = New System.Drawing.Point(18, 135)
        Me.editGenreLabel.Name = "editGenreLabel"
        Me.editGenreLabel.Size = New System.Drawing.Size(48, 16)
        Me.editGenreLabel.TabIndex = 24
        Me.editGenreLabel.Text = "Genre:"
        '
        'editPubDateTextBox
        '
        Me.editPubDateTextBox.BackColor = System.Drawing.Color.Black
        Me.editPubDateTextBox.ForeColor = System.Drawing.Color.White
        Me.editPubDateTextBox.Location = New System.Drawing.Point(111, 74)
        Me.editPubDateTextBox.Name = "editPubDateTextBox"
        Me.editPubDateTextBox.Size = New System.Drawing.Size(125, 22)
        Me.editPubDateTextBox.TabIndex = 22
        '
        'submitButton
        '
        Me.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitButton.Location = New System.Drawing.Point(184, 163)
        Me.submitButton.Name = "submitButton"
        Me.submitButton.Size = New System.Drawing.Size(119, 25)
        Me.submitButton.TabIndex = 17
        Me.submitButton.Text = "Submit Updates"
        Me.submitButton.UseVisualStyleBackColor = True
        '
        'editGenreTextBox
        '
        Me.editGenreTextBox.BackColor = System.Drawing.Color.Black
        Me.editGenreTextBox.ForeColor = System.Drawing.Color.White
        Me.editGenreTextBox.Location = New System.Drawing.Point(111, 128)
        Me.editGenreTextBox.Name = "editGenreTextBox"
        Me.editGenreTextBox.Size = New System.Drawing.Size(125, 22)
        Me.editGenreTextBox.TabIndex = 23
        '
        'filterTab
        '
        Me.filterTab.BackColor = System.Drawing.Color.Black
        Me.filterTab.Controls.Add(Me.groupBox1)
        Me.filterTab.ForeColor = System.Drawing.Color.White
        Me.filterTab.Location = New System.Drawing.Point(4, 25)
        Me.filterTab.Name = "filterTab"
        Me.filterTab.Size = New System.Drawing.Size(346, 218)
        Me.filterTab.TabIndex = 3
        Me.filterTab.Text = "Filter"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.matchesComboBox)
        Me.groupBox1.Controls.Add(Me.matchesLabel)
        Me.groupBox1.Controls.Add(Me.applyLabel)
        Me.groupBox1.Controls.Add(Me.condition4Panel)
        Me.groupBox1.Controls.Add(Me.condition3Panel)
        Me.groupBox1.Controls.Add(Me.condition2Panel)
        Me.groupBox1.Controls.Add(Me.condition1Panel)
        Me.groupBox1.Controls.Add(Me.clearButton)
        Me.groupBox1.Controls.Add(Me.addFilterButton)
        Me.groupBox1.Location = New System.Drawing.Point(6, 6)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(334, 201)
        Me.groupBox1.TabIndex = 2
        Me.groupBox1.TabStop = False
        '
        'matchesComboBox
        '
        Me.matchesComboBox.BackColor = System.Drawing.Color.Black
        Me.matchesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.matchesComboBox.ForeColor = System.Drawing.Color.White
        Me.matchesComboBox.FormattingEnabled = True
        Me.matchesComboBox.Items.AddRange(New Object() {"Any", "All"})
        Me.matchesComboBox.Location = New System.Drawing.Point(255, 28)
        Me.matchesComboBox.Name = "matchesComboBox"
        Me.matchesComboBox.Size = New System.Drawing.Size(67, 24)
        Me.matchesComboBox.TabIndex = 59
        Me.matchesComboBox.Text = "Any"
        Me.matchesComboBox.Visible = False
        '
        'matchesLabel
        '
        Me.matchesLabel.AutoSize = True
        Me.matchesLabel.Location = New System.Drawing.Point(187, 33)
        Me.matchesLabel.Name = "matchesLabel"
        Me.matchesLabel.Size = New System.Drawing.Size(62, 16)
        Me.matchesLabel.TabIndex = 58
        Me.matchesLabel.Text = "Matches:"
        Me.matchesLabel.Visible = False
        '
        'applyLabel
        '
        Me.applyLabel.AutoSize = True
        Me.applyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.applyLabel.Location = New System.Drawing.Point(7, 53)
        Me.applyLabel.Name = "applyLabel"
        Me.applyLabel.Size = New System.Drawing.Size(33, 13)
        Me.applyLabel.TabIndex = 57
        Me.applyLabel.Text = "Apply"
        Me.applyLabel.Visible = False
        '
        'condition4Panel
        '
        Me.condition4Panel.Controls.Add(Me.condition4CheckBox)
        Me.condition4Panel.Controls.Add(Me.operator4ComboBox)
        Me.condition4Panel.Controls.Add(Me.condition4ComboBox)
        Me.condition4Panel.Controls.Add(Me.condition4TextBox)
        Me.condition4Panel.Location = New System.Drawing.Point(5, 163)
        Me.condition4Panel.Name = "condition4Panel"
        Me.condition4Panel.Size = New System.Drawing.Size(324, 36)
        Me.condition4Panel.TabIndex = 56
        Me.condition4Panel.Visible = False
        '
        'condition4CheckBox
        '
        Me.condition4CheckBox.AutoSize = True
        Me.condition4CheckBox.Location = New System.Drawing.Point(7, 11)
        Me.condition4CheckBox.Name = "condition4CheckBox"
        Me.condition4CheckBox.Size = New System.Drawing.Size(15, 14)
        Me.condition4CheckBox.TabIndex = 54
        Me.condition4CheckBox.UseVisualStyleBackColor = True
        '
        'operator4ComboBox
        '
        Me.operator4ComboBox.BackColor = System.Drawing.Color.Black
        Me.operator4ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.operator4ComboBox.ForeColor = System.Drawing.Color.White
        Me.operator4ComboBox.FormattingEnabled = True
        Me.operator4ComboBox.Items.AddRange(New Object() {"=", ">", "<", ">=", "<>"})
        Me.operator4ComboBox.Location = New System.Drawing.Point(131, 6)
        Me.operator4ComboBox.Name = "operator4ComboBox"
        Me.operator4ComboBox.Size = New System.Drawing.Size(78, 24)
        Me.operator4ComboBox.TabIndex = 53
        Me.operator4ComboBox.Text = "="
        '
        'condition4ComboBox
        '
        Me.condition4ComboBox.BackColor = System.Drawing.Color.Black
        Me.condition4ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.condition4ComboBox.ForeColor = System.Drawing.Color.White
        Me.condition4ComboBox.FormattingEnabled = True
        Me.condition4ComboBox.Items.AddRange(New Object() {"Title", "ISBN", "Publish Year", "Price", "Genre"})
        Me.condition4ComboBox.Location = New System.Drawing.Point(29, 6)
        Me.condition4ComboBox.Name = "condition4ComboBox"
        Me.condition4ComboBox.Size = New System.Drawing.Size(96, 24)
        Me.condition4ComboBox.TabIndex = 52
        Me.condition4ComboBox.Text = "Condition"
        '
        'condition4TextBox
        '
        Me.condition4TextBox.BackColor = System.Drawing.Color.Black
        Me.condition4TextBox.ForeColor = System.Drawing.Color.White
        Me.condition4TextBox.Location = New System.Drawing.Point(215, 6)
        Me.condition4TextBox.Name = "condition4TextBox"
        Me.condition4TextBox.Size = New System.Drawing.Size(102, 22)
        Me.condition4TextBox.TabIndex = 51
        '
        'condition3Panel
        '
        Me.condition3Panel.Controls.Add(Me.condition3CheckBox)
        Me.condition3Panel.Controls.Add(Me.operator3ComboBox)
        Me.condition3Panel.Controls.Add(Me.condition3ComboBox)
        Me.condition3Panel.Controls.Add(Me.condition3TextBox)
        Me.condition3Panel.Location = New System.Drawing.Point(5, 130)
        Me.condition3Panel.Name = "condition3Panel"
        Me.condition3Panel.Size = New System.Drawing.Size(324, 36)
        Me.condition3Panel.TabIndex = 55
        Me.condition3Panel.Visible = False
        '
        'condition3CheckBox
        '
        Me.condition3CheckBox.AutoSize = True
        Me.condition3CheckBox.Location = New System.Drawing.Point(7, 11)
        Me.condition3CheckBox.Name = "condition3CheckBox"
        Me.condition3CheckBox.Size = New System.Drawing.Size(15, 14)
        Me.condition3CheckBox.TabIndex = 54
        Me.condition3CheckBox.UseVisualStyleBackColor = True
        '
        'operator3ComboBox
        '
        Me.operator3ComboBox.BackColor = System.Drawing.Color.Black
        Me.operator3ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.operator3ComboBox.ForeColor = System.Drawing.Color.White
        Me.operator3ComboBox.FormattingEnabled = True
        Me.operator3ComboBox.Items.AddRange(New Object() {"=", ">", "<", ">=", "<>"})
        Me.operator3ComboBox.Location = New System.Drawing.Point(131, 6)
        Me.operator3ComboBox.Name = "operator3ComboBox"
        Me.operator3ComboBox.Size = New System.Drawing.Size(78, 24)
        Me.operator3ComboBox.TabIndex = 53
        Me.operator3ComboBox.Text = "="
        '
        'condition3ComboBox
        '
        Me.condition3ComboBox.BackColor = System.Drawing.Color.Black
        Me.condition3ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.condition3ComboBox.ForeColor = System.Drawing.Color.White
        Me.condition3ComboBox.FormattingEnabled = True
        Me.condition3ComboBox.Items.AddRange(New Object() {"Title", "ISBN", "Publish Year", "Price", "Genre"})
        Me.condition3ComboBox.Location = New System.Drawing.Point(29, 6)
        Me.condition3ComboBox.Name = "condition3ComboBox"
        Me.condition3ComboBox.Size = New System.Drawing.Size(96, 24)
        Me.condition3ComboBox.TabIndex = 52
        Me.condition3ComboBox.Text = "Condition"
        '
        'condition3TextBox
        '
        Me.condition3TextBox.BackColor = System.Drawing.Color.Black
        Me.condition3TextBox.ForeColor = System.Drawing.Color.White
        Me.condition3TextBox.Location = New System.Drawing.Point(215, 6)
        Me.condition3TextBox.Name = "condition3TextBox"
        Me.condition3TextBox.Size = New System.Drawing.Size(102, 22)
        Me.condition3TextBox.TabIndex = 51
        '
        'condition2Panel
        '
        Me.condition2Panel.Controls.Add(Me.condition2CheckBox)
        Me.condition2Panel.Controls.Add(Me.operator2ComboBox)
        Me.condition2Panel.Controls.Add(Me.condition2ComboBox)
        Me.condition2Panel.Controls.Add(Me.condition2TextBox)
        Me.condition2Panel.Location = New System.Drawing.Point(5, 97)
        Me.condition2Panel.Name = "condition2Panel"
        Me.condition2Panel.Size = New System.Drawing.Size(324, 36)
        Me.condition2Panel.TabIndex = 50
        Me.condition2Panel.Visible = False
        '
        'condition2CheckBox
        '
        Me.condition2CheckBox.AutoSize = True
        Me.condition2CheckBox.Location = New System.Drawing.Point(7, 11)
        Me.condition2CheckBox.Name = "condition2CheckBox"
        Me.condition2CheckBox.Size = New System.Drawing.Size(15, 14)
        Me.condition2CheckBox.TabIndex = 54
        Me.condition2CheckBox.UseVisualStyleBackColor = True
        '
        'operator2ComboBox
        '
        Me.operator2ComboBox.BackColor = System.Drawing.Color.Black
        Me.operator2ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.operator2ComboBox.ForeColor = System.Drawing.Color.White
        Me.operator2ComboBox.FormattingEnabled = True
        Me.operator2ComboBox.Items.AddRange(New Object() {"=", ">", "<", ">=", "<>"})
        Me.operator2ComboBox.Location = New System.Drawing.Point(131, 6)
        Me.operator2ComboBox.Name = "operator2ComboBox"
        Me.operator2ComboBox.Size = New System.Drawing.Size(78, 24)
        Me.operator2ComboBox.TabIndex = 53
        Me.operator2ComboBox.Text = "="
        '
        'condition2ComboBox
        '
        Me.condition2ComboBox.BackColor = System.Drawing.Color.Black
        Me.condition2ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.condition2ComboBox.ForeColor = System.Drawing.Color.White
        Me.condition2ComboBox.FormattingEnabled = True
        Me.condition2ComboBox.Items.AddRange(New Object() {"Title", "ISBN", "Publish Year", "Price", "Genre"})
        Me.condition2ComboBox.Location = New System.Drawing.Point(29, 6)
        Me.condition2ComboBox.Name = "condition2ComboBox"
        Me.condition2ComboBox.Size = New System.Drawing.Size(96, 24)
        Me.condition2ComboBox.TabIndex = 52
        Me.condition2ComboBox.Text = "Condition"
        '
        'condition2TextBox
        '
        Me.condition2TextBox.BackColor = System.Drawing.Color.Black
        Me.condition2TextBox.ForeColor = System.Drawing.Color.White
        Me.condition2TextBox.Location = New System.Drawing.Point(215, 6)
        Me.condition2TextBox.Name = "condition2TextBox"
        Me.condition2TextBox.Size = New System.Drawing.Size(102, 22)
        Me.condition2TextBox.TabIndex = 51
        '
        'condition1Panel
        '
        Me.condition1Panel.Controls.Add(Me.condition1CheckBox)
        Me.condition1Panel.Controls.Add(Me.operator1ComboBox)
        Me.condition1Panel.Controls.Add(Me.condition1ComboBox)
        Me.condition1Panel.Controls.Add(Me.condition1TextBox)
        Me.condition1Panel.Location = New System.Drawing.Point(5, 65)
        Me.condition1Panel.Name = "condition1Panel"
        Me.condition1Panel.Size = New System.Drawing.Size(324, 36)
        Me.condition1Panel.TabIndex = 49
        Me.condition1Panel.Visible = False
        '
        'condition1CheckBox
        '
        Me.condition1CheckBox.AutoSize = True
        Me.condition1CheckBox.Location = New System.Drawing.Point(7, 11)
        Me.condition1CheckBox.Name = "condition1CheckBox"
        Me.condition1CheckBox.Size = New System.Drawing.Size(15, 14)
        Me.condition1CheckBox.TabIndex = 54
        Me.condition1CheckBox.UseVisualStyleBackColor = True
        '
        'operator1ComboBox
        '
        Me.operator1ComboBox.BackColor = System.Drawing.Color.Black
        Me.operator1ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.operator1ComboBox.ForeColor = System.Drawing.Color.White
        Me.operator1ComboBox.FormattingEnabled = True
        Me.operator1ComboBox.Items.AddRange(New Object() {"=", ">", "<", ">=", "<>"})
        Me.operator1ComboBox.Location = New System.Drawing.Point(131, 6)
        Me.operator1ComboBox.Name = "operator1ComboBox"
        Me.operator1ComboBox.Size = New System.Drawing.Size(78, 24)
        Me.operator1ComboBox.TabIndex = 53
        Me.operator1ComboBox.Text = "="
        '
        'condition1ComboBox
        '
        Me.condition1ComboBox.BackColor = System.Drawing.Color.Black
        Me.condition1ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.condition1ComboBox.ForeColor = System.Drawing.Color.White
        Me.condition1ComboBox.FormattingEnabled = True
        Me.condition1ComboBox.Items.AddRange(New Object() {"Title", "ISBN", "Publish Year", "Price", "Genre"})
        Me.condition1ComboBox.Location = New System.Drawing.Point(29, 6)
        Me.condition1ComboBox.Name = "condition1ComboBox"
        Me.condition1ComboBox.Size = New System.Drawing.Size(96, 24)
        Me.condition1ComboBox.TabIndex = 52
        Me.condition1ComboBox.Text = "Condition"
        '
        'condition1TextBox
        '
        Me.condition1TextBox.BackColor = System.Drawing.Color.Black
        Me.condition1TextBox.ForeColor = System.Drawing.Color.White
        Me.condition1TextBox.Location = New System.Drawing.Point(215, 6)
        Me.condition1TextBox.Name = "condition1TextBox"
        Me.condition1TextBox.Size = New System.Drawing.Size(102, 22)
        Me.condition1TextBox.TabIndex = 51
        '
        'clearButton
        '
        Me.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearButton.Location = New System.Drawing.Point(94, 19)
        Me.clearButton.Name = "clearButton"
        Me.clearButton.Size = New System.Drawing.Size(87, 25)
        Me.clearButton.TabIndex = 27
        Me.clearButton.Text = "Clear last"
        Me.clearButton.UseVisualStyleBackColor = True
        '
        'addFilterButton
        '
        Me.addFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addFilterButton.Location = New System.Drawing.Point(11, 19)
        Me.addFilterButton.Name = "addFilterButton"
        Me.addFilterButton.Size = New System.Drawing.Size(77, 25)
        Me.addFilterButton.TabIndex = 17
        Me.addFilterButton.Text = "Add Filter"
        Me.addFilterButton.UseVisualStyleBackColor = True
        '
        'filterBox
        '
        Me.filterBox.Controls.Add(Me.filterTreeView)
        Me.filterBox.ForeColor = System.Drawing.Color.White
        Me.filterBox.Location = New System.Drawing.Point(34, 278)
        Me.filterBox.Name = "filterBox"
        Me.filterBox.Size = New System.Drawing.Size(284, 391)
        Me.filterBox.TabIndex = 8
        Me.filterBox.TabStop = False
        Me.filterBox.Text = "Filtered Book List"
        Me.filterBox.Visible = False
        '
        'filterTreeView
        '
        Me.filterTreeView.BackColor = System.Drawing.Color.Black
        Me.filterTreeView.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.filterTreeView.ForeColor = System.Drawing.Color.White
        Me.filterTreeView.Location = New System.Drawing.Point(10, 19)
        Me.filterTreeView.Name = "filterTreeView"
        Me.filterTreeView.Size = New System.Drawing.Size(258, 366)
        Me.filterTreeView.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1203, 727)
        Me.Controls.Add(Me.filterBox)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.TextGroupBox)
        Me.Controls.Add(Me.TreeViewGroupBox)
        Me.Name = "Form1"
        Me.Text = "In Memory XML Processing App"
        Me.TreeViewGroupBox.ResumeLayout(False)
        Me.TextGroupBox.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.loadTab.ResumeLayout(False)
        Me.optionsGroupBox.ResumeLayout(False)
        Me.optionsGroupBox.PerformLayout()
        Me.addTab.ResumeLayout(False)
        Me.addElementGroupBox.ResumeLayout(False)
        Me.addElementGroupBox.PerformLayout()
        Me.editTab.ResumeLayout(False)
        Me.EditElementGroupBox.ResumeLayout(False)
        Me.EditElementGroupBox.PerformLayout()
        Me.filterTab.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.condition4Panel.ResumeLayout(False)
        Me.condition4Panel.PerformLayout()
        Me.condition3Panel.ResumeLayout(False)
        Me.condition3Panel.PerformLayout()
        Me.condition2Panel.ResumeLayout(False)
        Me.condition2Panel.PerformLayout()
        Me.condition1Panel.ResumeLayout(False)
        Me.condition1Panel.PerformLayout()
        Me.filterBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Dim TreeViewGroupBox As System.Windows.Forms.GroupBox
    Dim WithEvents xmlTreeView As System.Windows.Forms.TreeView
    Dim TextGroupBox As System.Windows.Forms.GroupBox
    Dim XmlTextBox As System.Windows.Forms.RichTextBox
    Dim WithEvents tabControl1 As System.Windows.Forms.TabControl
    Dim addTab As System.Windows.Forms.TabPage
    Dim loadTab As System.Windows.Forms.TabPage
    Dim editTab As System.Windows.Forms.TabPage
    Dim WithEvents loadButton As System.Windows.Forms.Button
    Dim optionsGroupBox As System.Windows.Forms.GroupBox
    Dim generateCheckBox As System.Windows.Forms.CheckBox
    Dim WithEvents validateCheckBox As System.Windows.Forms.CheckBox
    Dim addElementGroupBox As System.Windows.Forms.GroupBox
    Dim newPositionLabel As System.Windows.Forms.Label
    Dim WithEvents positionComboBox As System.Windows.Forms.ComboBox
    Dim newTitleTextBox As System.Windows.Forms.TextBox
    Dim newTitleLabel As System.Windows.Forms.Label
    Dim newISBNLabel As System.Windows.Forms.Label
    Dim newPriceLabel As System.Windows.Forms.Label
    Dim newISBNTextBox As System.Windows.Forms.TextBox
    Dim newPriceTextBox As System.Windows.Forms.TextBox
    Dim newPubDateLabel As System.Windows.Forms.Label
    Dim newGenreLabel As System.Windows.Forms.Label
    Dim newPubDateTextBox As System.Windows.Forms.TextBox
    Dim WithEvents addNewBookButton As System.Windows.Forms.Button
    Dim newGenreTextBox As System.Windows.Forms.TextBox
    Dim generateSchemaCheckBox As System.Windows.Forms.CheckBox
    Dim EditElementGroupBox As System.Windows.Forms.GroupBox
    Dim editTitleTextBox As System.Windows.Forms.TextBox
    Dim editTitleLabel As System.Windows.Forms.Label
    Dim editISBNLabel As System.Windows.Forms.Label
    Dim editPriceLabel As System.Windows.Forms.Label
    Dim editISBNTextBox As System.Windows.Forms.TextBox
    Dim editPriceTextBox As System.Windows.Forms.TextBox
    Dim editPubDateLabel As System.Windows.Forms.Label
    Dim editGenreLabel As System.Windows.Forms.Label
    Dim editPubDateTextBox As System.Windows.Forms.TextBox
    Dim WithEvents submitButton As System.Windows.Forms.Button
    Dim editGenreTextBox As System.Windows.Forms.TextBox
    Dim WithEvents deleteButton As System.Windows.Forms.Button
    Dim toolTip1 As System.Windows.Forms.ToolTip
    Dim WithEvents positionDownButton As System.Windows.Forms.Button
    Dim WithEvents positionUpButton As System.Windows.Forms.Button
    Dim WithEvents saveButton As System.Windows.Forms.Button
    Dim WithEvents refreshTreeButton As System.Windows.Forms.Button
    Dim filterTab As System.Windows.Forms.TabPage
    Dim groupBox1 As System.Windows.Forms.GroupBox
    Dim WithEvents clearButton As System.Windows.Forms.Button
    Dim condition1Panel As System.Windows.Forms.Panel
    Dim WithEvents addFilterButton As System.Windows.Forms.Button
    Dim condition4Panel As System.Windows.Forms.Panel
    Dim WithEvents condition4CheckBox As System.Windows.Forms.CheckBox
    Dim operator4ComboBox As System.Windows.Forms.ComboBox
    Dim WithEvents condition4ComboBox As System.Windows.Forms.ComboBox
    Dim condition4TextBox As System.Windows.Forms.TextBox
    Dim condition3Panel As System.Windows.Forms.Panel
    Dim WithEvents condition3CheckBox As System.Windows.Forms.CheckBox
    Dim operator3ComboBox As System.Windows.Forms.ComboBox
    Dim WithEvents condition3ComboBox As System.Windows.Forms.ComboBox
    Dim condition3TextBox As System.Windows.Forms.TextBox
    Dim condition2Panel As System.Windows.Forms.Panel
    Dim WithEvents condition2CheckBox As System.Windows.Forms.CheckBox
    Dim operator2ComboBox As System.Windows.Forms.ComboBox
    Dim WithEvents condition2ComboBox As System.Windows.Forms.ComboBox
    Dim condition2TextBox As System.Windows.Forms.TextBox
    Dim WithEvents condition1CheckBox As System.Windows.Forms.CheckBox
    Dim operator1ComboBox As System.Windows.Forms.ComboBox
    Dim WithEvents condition1ComboBox As System.Windows.Forms.ComboBox
    Dim condition1TextBox As System.Windows.Forms.TextBox
    Dim applyLabel As System.Windows.Forms.Label
    Dim filterBox As System.Windows.Forms.GroupBox
    Dim WithEvents filterTreeView As System.Windows.Forms.TreeView
    Dim WithEvents matchesComboBox As System.Windows.Forms.ComboBox
    Dim matchesLabel As System.Windows.Forms.Label

End Class
