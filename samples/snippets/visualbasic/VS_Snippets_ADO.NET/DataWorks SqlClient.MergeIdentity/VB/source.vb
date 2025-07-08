Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Class1

    Sub Main()
        Dim connectionString As String = _
            GetConnectionString()
        MergeIdentityColumns(connectionString)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub MergeIdentityColumns(ByVal connectionString As String)

        Using connection As SqlConnection = New SqlConnection( _
           connectionString)

            ' Create the DataAdapter
            Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
              "SELECT ShipperID, CompanyName FROM dbo.Shippers", connection)

            ' Add the InsertCommand to retrieve new identity value.
            adapter.InsertCommand = New SqlCommand( _
                "INSERT INTO dbo.Shippers (CompanyName) " & _
                "VALUES (@CompanyName); " & _
                "SELECT ShipperID, CompanyName FROM dbo.Shippers " & _
                "WHERE ShipperID = SCOPE_IDENTITY();", _
                connection)

            ' Add the parameter for the inserted value.
            adapter.InsertCommand.Parameters.Add( _
               New SqlParameter("@CompanyName", SqlDbType.NVarChar, 40, _
               "CompanyName"))
            adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both

            ' MissingSchemaAction adds any missing schema to
            ' the DataTable, including identity columns
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

            ' Fill the DataTable.
            Dim shipper As New DataTable
            adapter.Fill(shipper)

            ' Add a new shipper.
            Dim newRow As DataRow = shipper.NewRow()
            newRow("CompanyName") = "New Shipper"
            shipper.Rows.Add(newRow)

            ' Add changed rows to a new DataTable. This
            ' DataTable will be used by the DataAdapter.
            Dim dataChanges As DataTable = shipper.GetChanges()

            ' Add the event handler.
            AddHandler adapter.RowUpdated, New _
               SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

            ' Update the datasource with the modified records.
            adapter.Update(dataChanges)

            ' Merge the two DataTables.
            shipper.Merge(dataChanges)

            ' Commit the changes.
            shipper.AcceptChanges()

            Console.WriteLine("Rows after merge.")
            Dim row As DataRow
            For Each row In shipper.Rows
                Console.WriteLine("{0}: {1}", row(0), row(1))
            Next
        End Using
    End Sub
    ' </Snippet1>

    ' <Snippet2>
    Private Sub OnRowUpdated( _
        ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)
        ' If this is an insert, then skip this row.
        If e.StatementType = StatementType.Insert Then
            e.Status = UpdateStatus.SkipCurrentRow
        End If
    End Sub
    ' </Snippet2>

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function

End Module
