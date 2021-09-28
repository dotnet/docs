<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerOrders2
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
        Dim companyNameLabel As System.Windows.Forms.Label
        Dim faxLabel As System.Windows.Forms.Label
        Dim phoneLabel As System.Windows.Forms.Label
        Dim contactTitleLabel As System.Windows.Forms.Label
        Dim contactNameLabel As System.Windows.Forms.Label
        Me.dataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.button1 = New System.Windows.Forms.Button
        Me.dataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.customersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ordersDataGridView = New System.Windows.Forms.DataGridView
        Me.ordersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.phoneTextBox = New System.Windows.Forms.TextBox
        Me.faxTextBox = New System.Windows.Forms.TextBox
        Me.contactTitleTextBox = New System.Windows.Forms.TextBox
        Me.contactNameTextBox = New System.Windows.Forms.TextBox
        Me.companyNameTextBox = New System.Windows.Forms.TextBox
        companyNameLabel = New System.Windows.Forms.Label
        faxLabel = New System.Windows.Forms.Label
        phoneLabel = New System.Windows.Forms.Label
        contactTitleLabel = New System.Windows.Forms.Label
        contactNameLabel = New System.Windows.Forms.Label
        CType(Me.customersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ordersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ordersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'companyNameLabel
        '
        companyNameLabel.AutoSize = True
        companyNameLabel.Location = New System.Drawing.Point(25, 13)
        companyNameLabel.Name = "companyNameLabel"
        companyNameLabel.Size = New System.Drawing.Size(85, 13)
        companyNameLabel.TabIndex = 14
        companyNameLabel.Text = "Company Name:"
        '
        'dataGridViewTextBoxColumn6
        '
        Me.dataGridViewTextBoxColumn6.DataPropertyName = "ShipName"
        Me.dataGridViewTextBoxColumn6.HeaderText = "ShipName"
        Me.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6"
        '
        'dataGridViewTextBoxColumn5
        '
        Me.dataGridViewTextBoxColumn5.DataPropertyName = "Freight"
        Me.dataGridViewTextBoxColumn5.HeaderText = "Freight"
        Me.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5"
        '
        'dataGridViewTextBoxColumn4
        '
        Me.dataGridViewTextBoxColumn4.DataPropertyName = "ShippedDate"
        Me.dataGridViewTextBoxColumn4.HeaderText = "ShippedDate"
        Me.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4"
        '
        'dataGridViewTextBoxColumn3
        '
        Me.dataGridViewTextBoxColumn3.DataPropertyName = "RequiredDate"
        Me.dataGridViewTextBoxColumn3.HeaderText = "RequiredDate"
        Me.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
        '
        'dataGridViewTextBoxColumn7
        '
        Me.dataGridViewTextBoxColumn7.DataPropertyName = "ShipAddress"
        Me.dataGridViewTextBoxColumn7.HeaderText = "ShipAddress"
        Me.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7"
        '
        'dataGridViewTextBoxColumn8
        '
        Me.dataGridViewTextBoxColumn8.DataPropertyName = "ShipCity"
        Me.dataGridViewTextBoxColumn8.HeaderText = "ShipCity"
        Me.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8"
        '
        'dataGridViewTextBoxColumn9
        '
        Me.dataGridViewTextBoxColumn9.DataPropertyName = "ShipRegion"
        Me.dataGridViewTextBoxColumn9.HeaderText = "ShipRegion"
        Me.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(312, 65)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(100, 23)
        Me.button1.TabIndex = 25
        Me.button1.Text = "Save"
        Me.button1.UseVisualStyleBackColor = True
        '
        'dataGridViewTextBoxColumn12
        '
        Me.dataGridViewTextBoxColumn12.DataPropertyName = "Customers"
        Me.dataGridViewTextBoxColumn12.HeaderText = "Customers"
        Me.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12"
        '
        'dataGridViewTextBoxColumn11
        '
        Me.dataGridViewTextBoxColumn11.DataPropertyName = "ShipCountry"
        Me.dataGridViewTextBoxColumn11.HeaderText = "ShipCountry"
        Me.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11"
        '
        'dataGridViewTextBoxColumn10
        '
        Me.dataGridViewTextBoxColumn10.DataPropertyName = "ShipPostalCode"
        Me.dataGridViewTextBoxColumn10.HeaderText = "ShipPostalCode"
        Me.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10"
        '
        'dataGridViewTextBoxColumn2
        '
        Me.dataGridViewTextBoxColumn2.DataPropertyName = "OrderDate"
        Me.dataGridViewTextBoxColumn2.HeaderText = "OrderDate"
        Me.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2"
        '
        'dataGridViewTextBoxColumn1
        '
        Me.dataGridViewTextBoxColumn1.DataPropertyName = "OrderID"
        Me.dataGridViewTextBoxColumn1.HeaderText = "OrderID"
        Me.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1"
        '
        'comboBox1
        '
        Me.comboBox1.DataSource = Me.customersBindingSource
        Me.comboBox1.DisplayMember = "CustomerID"
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Location = New System.Drawing.Point(472, 10)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(121, 21)
        Me.comboBox1.TabIndex = 26
        Me.comboBox1.ValueMember = "CustomerID"
        '
        'customersBindingSource
        '
        Me.customersBindingSource.DataSource = GetType(Northwind.Customer)

        'ordersDataGridView
        '
        Me.ordersDataGridView.AutoGenerateColumns = False
        Me.ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ordersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataGridViewTextBoxColumn1, Me.dataGridViewTextBoxColumn2, Me.dataGridViewTextBoxColumn3, Me.dataGridViewTextBoxColumn4, Me.dataGridViewTextBoxColumn5, Me.dataGridViewTextBoxColumn6, Me.dataGridViewTextBoxColumn7, Me.dataGridViewTextBoxColumn8, Me.dataGridViewTextBoxColumn9, Me.dataGridViewTextBoxColumn10, Me.dataGridViewTextBoxColumn11, Me.dataGridViewTextBoxColumn12})
        Me.ordersDataGridView.DataSource = Me.ordersBindingSource
        Me.ordersDataGridView.Location = New System.Drawing.Point(12, 104)
        Me.ordersDataGridView.Name = "ordersDataGridView"
        Me.ordersDataGridView.Size = New System.Drawing.Size(570, 237)
        Me.ordersDataGridView.TabIndex = 24
        '
        'ordersBindingSource
        '
        Me.ordersBindingSource.DataMember = "Orders"
        Me.ordersBindingSource.DataSource = Me.customersBindingSource
        '
        'faxLabel
        '
        faxLabel.AutoSize = True
        faxLabel.Location = New System.Drawing.Point(279, 39)
        faxLabel.Name = "faxLabel"
        faxLabel.Size = New System.Drawing.Size(27, 13)
        faxLabel.TabIndex = 22
        faxLabel.Text = "Fax:"
        '
        'phoneLabel
        '
        phoneLabel.AutoSize = True
        phoneLabel.Location = New System.Drawing.Point(265, 13)
        phoneLabel.Name = "phoneLabel"
        phoneLabel.Size = New System.Drawing.Size(41, 13)
        phoneLabel.TabIndex = 20
        phoneLabel.Text = "Phone:"
        '
        'phoneTextBox
        '
        Me.phoneTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.customersBindingSource, "Phone", True))
        Me.phoneTextBox.Location = New System.Drawing.Point(312, 10)
        Me.phoneTextBox.Name = "phoneTextBox"
        Me.phoneTextBox.Size = New System.Drawing.Size(100, 20)
        Me.phoneTextBox.TabIndex = 21
        '
        'contactTitleLabel
        '
        contactTitleLabel.AutoSize = True
        contactTitleLabel.Location = New System.Drawing.Point(40, 65)
        contactTitleLabel.Name = "contactTitleLabel"
        contactTitleLabel.Size = New System.Drawing.Size(70, 13)
        contactTitleLabel.TabIndex = 18
        contactTitleLabel.Text = "Contact Title:"
        '
        'contactNameLabel
        '
        contactNameLabel.AutoSize = True
        contactNameLabel.Location = New System.Drawing.Point(32, 39)
        contactNameLabel.Name = "contactNameLabel"
        contactNameLabel.Size = New System.Drawing.Size(78, 13)
        contactNameLabel.TabIndex = 16
        contactNameLabel.Text = "Contact Name:"
        '
        'faxTextBox
        '
        Me.faxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.customersBindingSource, "Fax", True))
        Me.faxTextBox.Location = New System.Drawing.Point(312, 36)
        Me.faxTextBox.Name = "faxTextBox"
        Me.faxTextBox.Size = New System.Drawing.Size(100, 20)
        Me.faxTextBox.TabIndex = 23
        '
        'contactTitleTextBox
        '
        Me.contactTitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.customersBindingSource, "ContactTitle", True))
        Me.contactTitleTextBox.Location = New System.Drawing.Point(116, 62)
        Me.contactTitleTextBox.Name = "contactTitleTextBox"
        Me.contactTitleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.contactTitleTextBox.TabIndex = 19
        '
        'contactNameTextBox
        '
        Me.contactNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.customersBindingSource, "ContactName", True))
        Me.contactNameTextBox.Location = New System.Drawing.Point(116, 36)
        Me.contactNameTextBox.Name = "contactNameTextBox"
        Me.contactNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.contactNameTextBox.TabIndex = 17
        '
        'companyNameTextBox
        '
        Me.companyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.customersBindingSource, "CompanyName", True))
        Me.companyNameTextBox.Location = New System.Drawing.Point(116, 10)
        Me.companyNameTextBox.Name = "companyNameTextBox"
        Me.companyNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.companyNameTextBox.TabIndex = 15
        '
        'CustomerOrders2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 373)
        Me.Controls.Add(companyNameLabel)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.ordersDataGridView)
        Me.Controls.Add(faxLabel)
        Me.Controls.Add(phoneLabel)
        Me.Controls.Add(Me.phoneTextBox)
        Me.Controls.Add(contactTitleLabel)
        Me.Controls.Add(contactNameLabel)
        Me.Controls.Add(Me.faxTextBox)
        Me.Controls.Add(Me.contactTitleTextBox)
        Me.Controls.Add(Me.contactNameTextBox)
        Me.Controls.Add(Me.companyNameTextBox)
        Me.Name = "CustomerOrders2"
        Me.Text = "CustomerOrders2"
        CType(Me.customersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ordersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ordersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents dataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Private WithEvents customersBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents ordersDataGridView As System.Windows.Forms.DataGridView
    Private WithEvents ordersBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents phoneTextBox As System.Windows.Forms.TextBox
    Private WithEvents faxTextBox As System.Windows.Forms.TextBox
    Private WithEvents contactTitleTextBox As System.Windows.Forms.TextBox
    Private WithEvents contactNameTextBox As System.Windows.Forms.TextBox
    Private WithEvents companyNameTextBox As System.Windows.Forms.TextBox
End Class
