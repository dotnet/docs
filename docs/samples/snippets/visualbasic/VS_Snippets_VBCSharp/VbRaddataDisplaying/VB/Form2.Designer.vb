<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form2
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
Me.NorthwindDataSet = New VB.NorthwindDataSet
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
CType(Me.NorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.OrdersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'NorthwindDataSet
'
Me.NorthwindDataSet.DataSetName = "NorthwindDataSet"
'
'OrdersBindingSource
'
Me.OrdersBindingSource.DataMember = "Orders"
Me.OrdersBindingSource.DataSource = Me.NorthwindDataSet
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
Me.OrdersDataGridView.Location = New System.Drawing.Point(18, 48)
Me.OrdersDataGridView.Name = "OrdersDataGridView"
Me.OrdersDataGridView.Size = New System.Drawing.Size(300, 220)
Me.OrdersDataGridView.TabIndex = 1
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
'Form2
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(338, 288)
Me.Controls.Add(Me.OrdersDataGridView)
Me.Name = "Form2"
Me.Text = "Form2"
CType(Me.NorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.OrdersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
    Friend WithEvents NorthwindDataSet As VB.NorthwindDataSet
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
