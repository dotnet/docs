 '<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Class Form1
    Inherits Form

    Private WithEvents nextButton As Button
    Private WithEvents findButton As Button
    Private WithEvents customersBindingSource As BindingSource
    Private customersDataGridView As DataGridView

    Public Sub New()
        Me.customersDataGridView = New DataGridView()
        Me.nextButton = New Button()
        Me.findButton = New Button()
        Me.customersBindingSource = New BindingSource()

        Me.customersDataGridView.Location = New Point(23, 62)
        Me.customersDataGridView.Size = New Size(240, 150)
        Me.nextButton.Location = New Point(23, 22)
        Me.nextButton.Size = New Size(75, 23)
        Me.nextButton.Text = "Next"
        Me.findButton.Location = New Point(122, 22)
        Me.findButton.Size = New Size(75, 23)
        Me.findButton.Text = "Find ANTON"
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.findButton)
        Me.Controls.Add(Me.nextButton)
        Me.Controls.Add(Me.customersDataGridView)
    End Sub


    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub

    '<snippet2>
    Sub findButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles findButton.Click
        Dim foundIndex As Integer = customersBindingSource.Find("CustomerID", _
            "ANTON")
        customersBindingSource.Position = foundIndex
    End Sub
    '</snippet2>

    '<snippet3>
    Sub customersBindingSource_PositionChanged(ByVal sender As Object, _
        ByVal e As EventArgs)

        If customersBindingSource.Position = _
            customersBindingSource.Count - 1 Then
            nextButton.Enabled = False
        Else
            nextButton.Enabled = True
        End If
    End Sub
    '</snippet3>

    '<snippet4>
    Private Sub nextButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles nextButton.Click
        Me.customersBindingSource.MoveNext()
    End Sub
    '</snippet4>

    '<snippet5>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load
        ' Create the connection string, data adapter, data table and data view.
        Dim connectionString As _
            New SqlConnection("Initial Catalog=Northwind;" & _
            "Data Source=localhost;Integrated Security=SSPI;")
        Dim customersDataAdapter As New SqlDataAdapter("Select * from Customers", _
            connectionString)

        Dim customerTable As New DataTable()

        ' Fill the the table with the contents of the customer table.
        customersDataAdapter.Fill(customerTable)
        Dim customerView As New DataView(customerTable)

        ' Set data source for customersBindingSource.
        customersBindingSource.DataSource = customerView
        customersDataGridView.DataSource = customersBindingSource
    End Sub
    '</snippet5>
End Class
'</snippet1>