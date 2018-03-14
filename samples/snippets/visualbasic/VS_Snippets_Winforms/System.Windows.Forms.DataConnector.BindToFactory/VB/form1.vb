 ' <snippet1>
' <snippet2>
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Diagnostics
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms

' </snippet2>
' <snippet3>
' This form demonstrates using a BindingSource to bind to a factory
' object. 

Public Class Form1
    Inherits System.Windows.Forms.Form
    ' <snippet4>
    ' This is the TextBox for entering CustomerID values.
    Private WithEvents customerIdTextBox As New TextBox()
    
    ' This is the DataGridView that displays orders for the 
    ' specified customer.
    Private customersDataGridView As New DataGridView()
    
    ' This is the BindingSource for binding the database query
    ' result set to the DataGridView.
    Private ordersBindingSource As New BindingSource()
    
    ' </snippet4>
    ' <snippet5>
    Public Sub New() 

        ' Set up the CustomerID TextBox.
        Me.customerIdTextBox.Location = New Point(100, 200)
        Me.customerIdTextBox.Size = New Size(500, 30)
        Me.customerIdTextBox.Text = _
            "Enter a valid Northwind CustomerID, for example: ALFKI," & _
            " then RETURN or click outside the TextBox"
        Me.Controls.Add(Me.customerIdTextBox)
        
        ' Set up the DataGridView.
        customersDataGridView.Dock = DockStyle.Top
        Me.Controls.Add(customersDataGridView)
        
        ' Set up the form.
        Me.Size = New Size(800, 500)
    End Sub
    
    ' </snippet5>
    ' <snippet6>
    ' This event handler binds the BindingSource to the DataGridView
    ' control's DataSource property.
    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        ' Attach the BindingSource to the DataGridView.
        Me.customersDataGridView.DataSource = Me.ordersBindingSource

    End Sub
    
    ' </snippet6>
    ' <snippet7>
    ' This is a static factory method. It queries the Northwind 
    ' database for the orders belonging to the specified
    ' customer and returns an IEnumerable.
    Public Shared Function GetOrdersByCustomerId(ByVal id As String) _
        As IEnumerable

        ' Open a connection to the database.
        Dim connectString As String = "Integrated Security=SSPI;" & _
             "Persist Security Info=False;Initial Catalog=Northwind;" & _
             "Data Source= localhost"
        Dim connection As New SqlConnection()

        connection.ConnectionString = connectString
        connection.Open()

        ' Execute the query.
        Dim queryString As String = _
            String.Format("Select * From Orders where CustomerID = '{0}'", id)
        Dim command As New SqlCommand(queryString, connection)
        Dim reader As SqlDataReader = _
            command.ExecuteReader(CommandBehavior.CloseConnection)
        Return reader

    End Function
     
    ' </snippet7>
    ' <snippet8>
    ' These event handlers are called when the user tabs or clicks
    ' out of the customerIdTextBox or hits the return key.
    ' The database is then queried with the CustomerID
    '  in the customerIdTextBox.Text property.
    Private Sub customerIdTextBox_Leave(ByVal sender As Object, _
        ByVal e As EventArgs) Handles customerIdTextBox.Leave

        ' Attach the data source to the BindingSource control.
        Me.ordersBindingSource.DataSource = _
            GetOrdersByCustomerId(Me.customerIdTextBox.Text)

    End Sub
    
    
    Private Sub customerIdTextBox_KeyDown(ByVal sender As Object, _
        ByVal e As KeyEventArgs) Handles customerIdTextBox.KeyDown

        If e.KeyCode = Keys.Return Then

            ' Attach the data source to the BindingSource control.
            Me.ordersBindingSource.DataSource = _
                GetOrdersByCustomerId(Me.customerIdTextBox.Text)
        End If

    End Sub
    ' </snippet8>

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub
End Class
' </snippet3>
' </snippet1>