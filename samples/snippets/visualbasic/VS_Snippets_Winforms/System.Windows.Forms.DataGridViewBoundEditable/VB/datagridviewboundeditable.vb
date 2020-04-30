Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Private dataGridView1 As New DataGridView()
    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private WithEvents ReloadButton As New Button()
    Private WithEvents SubmitButton As New Button()

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    ' Initialize the form.
    Public Sub New()

        dataGridView1.Dock = DockStyle.Fill

        ReloadButton.Text = "Reload"
        SubmitButton.Text = "Submit"

        Dim panel As New FlowLayoutPanel With {
            .Dock = DockStyle.Top,
            .AutoSize = True
        }
        panel.Controls.AddRange(New Control() {ReloadButton, SubmitButton})

        Controls.AddRange(New Control() {dataGridView1, panel})
        Text = "DataGridView data binding and updating demo"

    End Sub

    Private Sub GetData(ByVal selectCommand As String)

        Try
            ' Specify a connection string.  
            ' Replace <SQL Server> with the SQL Server for your Northwind sample database.
            ' Replace "Integrated Security=True" with user login information if necessary.
            Dim connectionString As String =
                "Data Source=<SQL Server>;Initial Catalog=Northwind;" +
                "Integrated Security=True;"

            ' Create a new data adapter based on the specified query.
            dataAdapter = New SqlDataAdapter(selectCommand, connectionString)

            ' Create a command builder to generate SQL update, insert, and
            ' delete commands based on selectCommand. 
            Dim commandBuilder As New SqlCommandBuilder(dataAdapter)

            ' Populate a new data table and bind it to the BindingSource.
            Dim table As New DataTable With {
                .Locale = Globalization.CultureInfo.InvariantCulture
            }
            dataAdapter.Fill(table)
            bindingSource1.DataSource = table

            ' Resize the DataGridView columns to fit the newly loaded content.
            dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)

        Catch ex As SqlException
            MessageBox.Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.")
        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        ' Bind the DataGridView to the BindingSource
        ' and load the data from the database.
        dataGridView1.DataSource = bindingSource1
        GetData("select * from Customers")

    End Sub

    Private Sub ReloadButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ReloadButton.Click

        ' Reload the data from the database.
        GetData(dataAdapter.SelectCommand.CommandText)

    End Sub

    Private Sub SubmitButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles SubmitButton.Click

        ' Update the database with changes.
        dataAdapter.Update(CType(bindingSource1.DataSource, DataTable))

    End Sub

End Class
