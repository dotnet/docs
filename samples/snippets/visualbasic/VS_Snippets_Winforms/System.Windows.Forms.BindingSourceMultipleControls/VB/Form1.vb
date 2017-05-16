
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO



Public Class Form1
    Inherits Form
    
    
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'InitializeControlsAndDataSource();
        InitializeControlsAndData()

    End Sub
    
    '<snippet1>
    '<snippet3>
    ' Declare the controls to be used.
    Private WithEvents bindingSource1 As BindingSource
    Private WithEvents textBox1 As TextBox
    Private WithEvents textBox2 As TextBox
    Private WithEvents dataGridView1 As DataGridView
    
    
    Private Sub InitializeControlsAndDataSource() 
        ' Initialize the controls and set location, size and 
        ' other basic properties.
        Me.dataGridView1 = New DataGridView()
        Me.bindingSource1 = New BindingSource()
        Me.textBox1 = New TextBox()
        Me.textBox2 = New TextBox()
        Me.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Dock = DockStyle.Top
        Me.dataGridView1.Location = New Point(0, 0)
        Me.dataGridView1.Size = New Size(292, 150)
        Me.textBox1.Location = New Point(132, 156)
        Me.textBox1.Size = New Size(100, 20)
        Me.textBox2.Location = New Point(12, 156)
        Me.textBox2.Size = New Size(100, 20)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.dataGridView1)
        
        ' Declare the DataSet and add a table and column.
        Dim set1 As New DataSet()
        set1.Tables.Add("Menu")
        set1.Tables(0).Columns.Add("Beverages")
        
        ' Add some rows to the table.
        set1.Tables(0).Rows.Add("coffee")
        set1.Tables(0).Rows.Add("tea")
        set1.Tables(0).Rows.Add("hot chocolate")
        set1.Tables(0).Rows.Add("milk")
        set1.Tables(0).Rows.Add("orange juice")
        
        ' Set the data source to the DataSet.
        bindingSource1.DataSource = set1
        
        'Set the DataMember to the Menu table.
        bindingSource1.DataMember = "Menu"
        
        ' Add the control data bindings.
        dataGridView1.DataSource = bindingSource1
        textBox1.DataBindings.Add("Text", bindingSource1, "Beverages", _
            True, DataSourceUpdateMode.OnPropertyChanged)
        textBox2.DataBindings.Add("Text", bindingSource1, "Beverages", _
            True, DataSourceUpdateMode.OnPropertyChanged)

    
    End Sub 'InitializeControlsAndDataSource
    
    '</snippet3>
    '<snippet2>
    Private Sub bindingSource1_BindingComplete(ByVal sender As Object, _
        ByVal e As BindingCompleteEventArgs) Handles bindingSource1.BindingComplete

        ' Check if the data source has been updated, and that no error has occured.
        If e.BindingCompleteContext = BindingCompleteContext.DataSourceUpdate _
            AndAlso e.Exception Is Nothing Then

            ' If not, end the current edit.
            e.Binding.BindingManagerBase.EndCurrentEdit()
        End If

    End Sub
     '</snippet2>
 '</snippet1>
    '<snippet11>
    Dim WithEvents bmb As BindingManagerBase

    Private Sub InitializeControlsAndData() 
        ' Initialize the controls and set location, size and 
        ' other basic properties.
        Me.dataGridView1 = New DataGridView()
        
        Me.textBox1 = New TextBox()
        Me.textBox2 = New TextBox()
        Me.dataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Dock = DockStyle.Top
        Me.dataGridView1.Location = New Point(0, 0)
        Me.dataGridView1.Size = New Size(292, 150)
        Me.textBox1.Location = New Point(132, 156)
        Me.textBox1.Size = New Size(100, 20)
        Me.textBox2.Location = New Point(12, 156)
        Me.textBox2.Size = New Size(100, 20)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.dataGridView1)
        
        ' Declare the DataSet and add a table and column.
        Dim set1 As New DataSet()
        set1.Tables.Add("Menu")
        set1.Tables(0).Columns.Add("Beverages")
        
        ' Add some rows to the table.
        set1.Tables(0).Rows.Add("coffee")
        set1.Tables(0).Rows.Add("tea")
        set1.Tables(0).Rows.Add("hot chocolate")
        set1.Tables(0).Rows.Add("milk")
        set1.Tables(0).Rows.Add("orange juice")

        ' Add the control data bindings.
        dataGridView1.DataSource = set1
        dataGridView1.DataMember = "Menu"
        textBox1.DataBindings.Add("Text", set1, "Menu.Beverages", _
            True, DataSourceUpdateMode.OnPropertyChanged)
        textBox2.DataBindings.Add("Text", set1, "Menu.Beverages", _
            True, DataSourceUpdateMode.OnPropertyChanged)

        ' Get the BindingManagerBase for this binding.
        bmb = Me.BindingContext(set1, "Menu")

    End Sub
    
    Private Sub bmb_BindingComplete(ByVal sender As Object, ByVal e As BindingCompleteEventArgs) _
        Handles bmb.BindingComplete

        ' Check if the data source has been updated, and that no error has occured.
        If e.BindingCompleteContext = BindingCompleteContext.DataSourceUpdate _
            AndAlso e.Exception Is Nothing Then

            ' If not, end the current edit.
            e.Binding.BindingManagerBase.EndCurrentEdit()
        End If
    End Sub
    '</snippet11>

    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub
End Class