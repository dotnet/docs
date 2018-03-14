' <snippet100>
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents flowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents dataGridView1 As DataGridView
    Friend WithEvents button1 As Button
    Friend WithEvents button2 As Button

    Dim sortableBindingListOfCustomers As SortableBindingList(Of Customer)
    Dim bindingListOfCustomers As BindingList(Of Customer)

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        sortableBindingListOfCustomers = New SortableBindingList(Of Customer)()
        bindingListOfCustomers = New BindingList(Of Customer)()

        Me.dataGridView1.DataSource = bindingListOfCustomers
    End Sub


    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Me.dataGridView1.DataSource = Nothing
        Me.dataGridView1.DataSource = sortableBindingListOfCustomers
    End Sub


    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        Me.dataGridView1.DataSource = Nothing
        Me.dataGridView1.DataSource = bindingListOfCustomers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.label2 = New System.Windows.Forms.Label
        Me.dataGridView1 = New System.Windows.Forms.DataGridView
        Me.button1 = New System.Windows.Forms.Button
        Me.button2 = New System.Windows.Forms.Button
        Me.flowLayoutPanel1.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.AutoSize = True
        Me.flowLayoutPanel1.Controls.Add(Me.label2)
        Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(566, 51)
        Me.flowLayoutPanel1.TabIndex = 13
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 6)
        Me.label2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(558, 39)
        Me.label2.TabIndex = 0
        Me.label2.Text = "This sample demonstrates how to implement the ITypedList interface.  Clicking on the 'Sort Columns' button will bind the DataGridView to a sub-classed BindingList<T> that implements ITypedList to provide a sorted list of columns.  Clicking on the 'Reset' button will bind the DataGridView to a normal BindingList<T>."
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(6, 57)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.ReadOnly = True
        Me.dataGridView1.RowHeadersVisible = False
        Me.dataGridView1.Size = New System.Drawing.Size(465, 51)
        Me.dataGridView1.TabIndex = 14
        '
        'button1
        '
        Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button1.Location = New System.Drawing.Point(477, 57)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(82, 23)
        Me.button1.TabIndex = 15
        Me.button1.Text = "Sort Columns"
        Me.button1.UseVisualStyleBackColor = True
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(477, 86)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(82, 23)
        Me.button2.TabIndex = 16
        Me.button2.Text = "Reset"
        Me.button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 120)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.flowLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "ITypedList Sample"
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


' </snippet100>