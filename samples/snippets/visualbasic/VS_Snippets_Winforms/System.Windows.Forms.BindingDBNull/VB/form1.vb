 ' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    Public Sub New() 
    End Sub
    
    ' The controls and components we need for the form.
    Private WithEvents button1 As Button
    Private pictureBox1 As PictureBox
    Private bindingSource1 As BindingSource
    Private textBox1 As TextBox
    Private textBox2 As TextBox
    
    ' Data table to hold the database data.
    Private employeeTable As New DataTable()
    
    
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        ' Basic form setup.
        Me.pictureBox1 = New PictureBox()
        Me.bindingSource1 = New BindingSource()
        Me.textBox1 = New TextBox()
        Me.textBox2 = New TextBox()
        Me.button1 = New Button()
        Me.pictureBox1.Location = New System.Drawing.Point(20, 20)
        Me.pictureBox1.Size = New System.Drawing.Size(174, 179)
        Me.textBox1.Location = New System.Drawing.Point(25, 215)
        Me.textBox1.ReadOnly = True
        Me.textBox2.Location = New System.Drawing.Point(25, 241)
        Me.textBox2.ReadOnly = True
        Me.button1.Location = New System.Drawing.Point(200, 103)
        Me.button1.Text = "Move Next"
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.pictureBox1)
        Me.ResumeLayout(False)
        Me.PerformLayout()

        ' Create the connection string and populate the data table
        ' with data.
        Dim connectionString As String = "Integrated Security=SSPI;" & _
            "Persist Security Info = False;Initial Catalog=Northwind;" _
            & "Data Source = localhost"
        Dim connection As New SqlConnection()
        connection.ConnectionString = connectionString
        Dim employeeAdapter As New SqlDataAdapter _
            (New SqlCommand("Select * from Employees", connection))
        connection.Open()
        employeeAdapter.Fill(employeeTable)

        ' Set the DataSource property of the BindingSource to the employee table.
        bindingSource1.DataSource = employeeTable

        ' Set up the binding to the ReportsTo column.
        Dim reportsToBinding As Binding = _
            textBox2.DataBindings.Add("Text", bindingSource1, "ReportsTo", _
                True)

        ' Set the NullValue property for this binding.
        reportsToBinding.NullValue = "No Manager"

        ' Set up the binding for the PictureBox using the Add method, setting
        ' the null value in method call.
        pictureBox1.DataBindings.Add("Image", bindingSource1, "Photo", _
            True, DataSourceUpdateMode.Never, _
            New Bitmap(GetType(Button), "Button.bmp"))

        ' Set up the remaining binding.
        textBox1.DataBindings.Add("Text", bindingSource1, "LastName", True)

    End Sub
    
    
    ' Move through the data when the button is clicked.
    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles button1.Click

        bindingSource1.MoveNext()

    End Sub
    
    
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub
End Class
' </snippet1>
