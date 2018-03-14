Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim connectionString As String = _
            GetConnectionString()
        ConnectToData(connectionString)
    End Sub
    Private Sub ConnectToData( _
         ByVal connectionString As String)

        Using connection As SqlConnection = New SqlConnection( _
           connectionString)

            Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
              "SELECT CustomerID, CompanyName FROM Customers", connection)
            Dim dataSet As New DataSet

            ' <Snippet1>
            Dim customers As DataTable = dataSet.Tables("Customers")

            ' Make modifications to the Customers table.

            ' Get changes to the DataSet.
            Dim dataSetChanges As DataSet = dataSet.GetChanges()

            ' Add an event handler to handle the errors during Update.
            AddHandler adapter.RowUpdated, New SqlRowUpdatedEventHandler( _
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
    Private Sub OnRowUpdated( _
        ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)
        If args.Status = UpdateStatus.ErrorsOccurred Then
            args.Row.RowError = args.Errors.Message
            args.Status = UpdateStatus.SkipCurrentRow
        End If
    End Sub
    ' </Snippet2>

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=Northwind;" _
           & "Integrated Security=SSPI;"
    End Function

End Module
