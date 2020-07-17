<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerOrders
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
        Me.customersComboBox = New System.Windows.Forms.ComboBox
        Me.ordersDataGridView = New System.Windows.Forms.DataGridView
        CType(Me.ordersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'customersComboBox
        '
        Me.customersComboBox.FormattingEnabled = True
        Me.customersComboBox.Location = New System.Drawing.Point(65, 6)
        Me.customersComboBox.Name = "customersComboBox"
        Me.customersComboBox.Size = New System.Drawing.Size(121, 21)
        Me.customersComboBox.TabIndex = 15
        '
        'ordersDataGridView
        '
        Me.ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ordersDataGridView.Location = New System.Drawing.Point(26, 106)
        Me.ordersDataGridView.Name = "ordersDataGridView"
        Me.ordersDataGridView.Size = New System.Drawing.Size(570, 237)
        Me.ordersDataGridView.TabIndex = 14
        '
        'CustomerOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 371)
        Me.Controls.Add(Me.customersComboBox)
        Me.Controls.Add(Me.ordersDataGridView)
        Me.Name = "CustomerOrders"
        Me.Text = "CustomerOrders"
        CType(Me.ordersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents customersComboBox As System.Windows.Forms.ComboBox
    Private WithEvents ordersDataGridView As System.Windows.Forms.DataGridView
End Class
