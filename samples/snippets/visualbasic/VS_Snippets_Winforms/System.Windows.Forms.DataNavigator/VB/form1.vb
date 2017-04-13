 '<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms


' This form demonstrates using a BindingNavigator to display 
' rows from a database query sequentially.
Public Class Form1
    Inherits Form
    ' This is the BindingNavigator that allows the user
    ' to navigate through the rows in a DataSet.
    Private customersBindingNavigator As New BindingNavigator(True)

    ' This is the BindingSource that provides data for
    ' the Textbox control.
    Private customersBindingSource As New BindingSource()

    ' This is the TextBox control that displays the CompanyName
    ' field from the the DataSet.
    Private companyNameTextBox As New TextBox()


    Public Sub New()
        ' Set up the BindingSource component.
        Me.customersBindingNavigator.BindingSource = Me.customersBindingSource
        Me.customersBindingNavigator.Dock = DockStyle.Top
        Me.Controls.Add(Me.customersBindingNavigator)

        ' Set up the TextBox control for displaying company names.
        Me.companyNameTextBox.Dock = DockStyle.Bottom
        Me.Controls.Add(Me.companyNameTextBox)

        ' Set up the form.
        Me.Size = New Size(800, 200)
        AddHandler Me.Load, AddressOf Form1_Load

    End Sub 'New


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Open a connection to the database.
        ' Replace the value of connectString with a valid 
        ' connection string to a Northwind database accessible 
        ' to your system.
        Dim connectString As String = _
            "Integrated Security=SSPI;Persist Security Info=False;" & _
            "Initial Catalog=Northwind;Data Source=localhost"

        Dim connection As New SqlConnection(connectString)
        Try

            Dim dataAdapter1 As New SqlDataAdapter( _
                New SqlCommand("Select * From Customers", connection))
            Dim ds As New DataSet("Northwind Customers")
            ds.Tables.Add("Customers")
            dataAdapter1.Fill(ds.Tables("Customers"))

            ' Assign the DataSet as the DataSource for the BindingSource.
            Me.customersBindingSource.DataSource = ds.Tables("Customers")

            ' Bind the CompanyName field to the TextBox control.
            Me.companyNameTextBox.DataBindings.Add(New Binding("Text", _
                Me.customersBindingSource, "CompanyName", True))
        Finally
            connection.Dispose()
        End Try

    End Sub 'Form1_Load


    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub
End Class
'</snippet1>