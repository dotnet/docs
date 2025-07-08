Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim connectionString As String =
            GetConnectionString()
        ConnectToData(connectionString)
    End Sub
    Private Sub ConnectToData(
         ByVal connectionString As String)

        Using connection As SqlConnection = New SqlConnection(
           connectionString)

            Dim adapter As New SqlDataAdapter(
              "SELECT CustomerID, CompanyName FROM Customers", connection)
            Dim dataSet As New DataSet

            ' <Snippet1>
            Dim customers As DataTable = dataSet.Tables("Customers")

            ' Make modifications to the Customers table.

            ' Get changes to the DataSet.
            Dim dataSetChanges As DataSet = dataSet.GetChanges()

            ' Add an event handler to handle the errors during Update.
            AddHandler adapter.RowUpdated, New SqlRowUpdatedEventHandler(
              AddressOf OnRowUpdated)

            connection.Open()
            adapter.Update(dataSetChanges, "Customers")
            connection.Close()

            ' Merge the updates.
            dataSet.Merge(dataSetChanges, True, MissingSchemaAction.Add)

            ' Reject changes on rows with errors and clear the error.
            Dim errRows() As DataRow = dataSet.Tables("Customers").GetErrors()
            Dim errRow As DataRow
            For Each errRow In errRows
                errRow.RejectChanges()
                errRow.RowError = Nothing
            Next

            ' Commit the changes.
            dataSet.AcceptChanges()

            ' </Snippet1>

        End Using
    End Sub
    ' <Snippet2>
    Private Sub OnRowUpdated(
        ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)
        If args.Status = UpdateStatus.ErrorsOccurred Then
            args.Row.RowError = args.Errors.Message
            args.Status = UpdateStatus.SkipCurrentRow
        End If
    End Sub
    ' </Snippet2>

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function

End Module
