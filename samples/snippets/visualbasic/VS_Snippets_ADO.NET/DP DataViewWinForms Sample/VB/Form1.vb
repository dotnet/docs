Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Globalization

Public Class Form1

    Private dataSet As DataSet
    Private contactsDataAdapter As SqlDataAdapter
    Private contactView As DataView

    ' <SnippetLDVSample1FormLoad>
    Private Sub Form1_Load(ByVal sender As System.Object, _
                           ByVal e As System.EventArgs) _
                           Handles MyBase.Load
        ' Connect to the database and fill the DataSet.
        GetData()

        contactDataGridView.DataSource = contactBindingSource

        ' Create a LinqDataView from a LINQ to DataSet query and bind it
        ' to the Windows Forms control.
        Dim contactQuery = _
            From row In dataSet.Tables("Contact").AsEnumerable() _
            Where row.Field(Of String)("EmailAddress") <> Nothing _
            Order By row.Field(Of String)("LastName") _
            Select row

        contactView = contactQuery.AsDataView()

        ' Bind the DataGridView to the BindingSource.
        contactBindingSource.DataSource = contactView
        contactDataGridView.AutoResizeColumns()
    End Sub
    ' </SnippetLDVSample1FormLoad>

    ' <SnippetLDVSample1GetData>
    Private Sub GetData()
        Try
            ' Initialize the DataSet.
            dataSet = New DataSet()
            dataSet.Locale = CultureInfo.InvariantCulture

            ' Create the connection string for the AdventureWorks sample database.
            Dim connectionString As String = "..."

            ' Create the command strings for querying the Contact table.
            Dim contactSelectCommand As String = "SELECT ContactID, Title, FirstName, LastName, EmailAddress, Phone FROM Person.Contact"

            ' Create the contacts data adapter.
            contactsDataAdapter = New SqlDataAdapter( _
                contactSelectCommand, _
                connectionString)

            ' Create a command builder to generate SQL update, insert, and
            ' delete commands based on the contacts select command. These are used to
            ' update the database.
            Dim contactsCommandBuilder As SqlCommandBuilder = New SqlCommandBuilder(contactsDataAdapter)

            ' Fill the data set with the contact information.
            contactsDataAdapter.Fill(dataSet, "Contact")

        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    ' </SnippetLDVSample1GetData>

End Class

