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
Me.NorthwindDataSet1 = New VB.NorthwindDataSet
Me.RegionTableAdapter1 = New VB.NorthwindDataSetTableAdapters.RegionTableAdapter
Me.RegionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
Me.RegionDataGridView = New System.Windows.Forms.DataGridView
Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.InsertButton = New System.Windows.Forms.Button
Me.UpdateButton = New System.Windows.Forms.Button
Me.DeleteButton = New System.Windows.Forms.Button
CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.RegionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.RegionDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'NorthwindDataSet1
'
Me.NorthwindDataSet1.DataSetName = "NorthwindDataSet"
'
'RegionTableAdapter1
'
Me.RegionTableAdapter1.ClearBeforeFill = True
'
'RegionBindingSource
'
Me.RegionBindingSource.DataMember = "Region"
Me.RegionBindingSource.DataSource = Me.NorthwindDataSet1
'
'RegionDataGridView
'
Me.RegionDataGridView.AutoGenerateColumns = False
Me.RegionDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
Me.RegionDataGridView.DataSource = Me.RegionBindingSource
Me.RegionDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable
Me.RegionDataGridView.Location = New System.Drawing.Point(12, 12)
Me.RegionDataGridView.Name = "RegionDataGridView"
Me.RegionDataGridView.Size = New System.Drawing.Size(300, 220)
Me.RegionDataGridView.TabIndex = 1
'
'DataGridViewTextBoxColumn1
'
Me.DataGridViewTextBoxColumn1.DataPropertyName = "RegionID"
Me.DataGridViewTextBoxColumn1.HeaderText = "RegionID"
Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
'
'DataGridViewTextBoxColumn2
'
Me.DataGridViewTextBoxColumn2.DataPropertyName = "RegionDescription"
Me.DataGridViewTextBoxColumn2.HeaderText = "RegionDescription"
Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
'
'InsertButton
'
Me.InsertButton.Location = New System.Drawing.Point(334, 29)
Me.InsertButton.Name = "InsertButton"
Me.InsertButton.Size = New System.Drawing.Size(75, 23)
Me.InsertButton.TabIndex = 2
Me.InsertButton.Text = "InsertButton"
Me.InsertButton.UseVisualStyleBackColor = True
'
'UpdateButton
'
Me.UpdateButton.Location = New System.Drawing.Point(334, 59)
Me.UpdateButton.Name = "UpdateButton"
Me.UpdateButton.Size = New System.Drawing.Size(75, 23)
Me.UpdateButton.TabIndex = 3
Me.UpdateButton.Text = "UpdateButton"
Me.UpdateButton.UseVisualStyleBackColor = True
'
'DeleteButton
'
Me.DeleteButton.Location = New System.Drawing.Point(334, 89)
Me.DeleteButton.Name = "DeleteButton"
Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
Me.DeleteButton.TabIndex = 4
Me.DeleteButton.Text = "DeleteButton"
Me.DeleteButton.UseVisualStyleBackColor = True
'
'Form1
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(462, 284)
Me.Controls.Add(Me.DeleteButton)
Me.Controls.Add(Me.UpdateButton)
Me.Controls.Add(Me.InsertButton)
Me.Controls.Add(Me.RegionDataGridView)
Me.Name = "Form1"
Me.Text = "Form1"
CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.RegionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.RegionDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
    Friend WithEvents NorthwindDataSet1 As VB.NorthwindDataSet
    Friend WithEvents RegionTableAdapter1 As VB.NorthwindDataSetTableAdapters.RegionTableAdapter
    Friend WithEvents RegionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RegionDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsertButton As System.Windows.Forms.Button
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button

End Class
