' <snippet1000>
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents flowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents label2 As Label
    Friend WithEvents dataGridView1 As DataGridView
    Friend WithEvents nameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents salaryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents iDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents employeeListSource1 As EmployeeListSource

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()
    End Sub

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
        components = New System.ComponentModel.Container()

        Dim dataGridViewCellStyle1 = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle2 = New System.Windows.Forms.DataGridViewCellStyle()
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.label2 = New System.Windows.Forms.Label()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.nameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salaryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employeeListSource1 = New EmployeeListSource(Me.components)
        Me.flowLayoutPanel1.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' flowLayoutPanel1
        ' 
        Me.flowLayoutPanel1.AutoSize = True
        Me.flowLayoutPanel1.Controls.Add(Me.label2)
        Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(416, 51)
        Me.flowLayoutPanel1.TabIndex = 11
        ' 
        ' label2
        ' 
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 6)
        Me.label2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(408, 39)
        Me.label2.TabIndex = 0
        Me.label2.Text = "This sample demonstrates how to implement the IListSource interface.  In this sam" + _
            "ple, a DataGridView is bound at design time to a Component (employeeListSource1)" + _
            " that implements IListSource."
        ' 
        ' dataGridView1
        ' 
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192)
        Me.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1
        Me.dataGridView1.AutoGenerateColumns = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { _
        Me.nameDataGridViewTextBoxColumn, Me.salaryDataGridViewTextBoxColumn, Me.iDDataGridViewTextBoxColumn})
        Me.dataGridView1.DataSource = Me.employeeListSource1
        Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridView1.Location = New System.Drawing.Point(0, 51)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RowHeadersVisible = False
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(416, 215)
        Me.dataGridView1.TabIndex = 12
        ' 
        ' nameDataGridViewTextBoxColumn
        ' 
        Me.nameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.nameDataGridViewTextBoxColumn.FillWeight = 131.7987F
        Me.nameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn"
        ' 
        ' salaryDataGridViewTextBoxColumn
        ' 
        Me.salaryDataGridViewTextBoxColumn.DataPropertyName = "ParkingID"
        Me.salaryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2
        Me.salaryDataGridViewTextBoxColumn.FillWeight = 121.8274F
        Me.salaryDataGridViewTextBoxColumn.HeaderText = "Parking ID"
        Me.salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn"
        ' 
        ' iDDataGridViewTextBoxColumn
        ' 
        Me.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.iDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.iDDataGridViewTextBoxColumn.FillWeight = 46.37391F
        Me.iDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn"
        Me.iDDataGridViewTextBoxColumn.ReadOnly = True
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 266)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.flowLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "IListSource Sample"
        Me.flowLayoutPanel1.ResumeLayout(False)
        Me.flowLayoutPanel1.PerformLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1000>