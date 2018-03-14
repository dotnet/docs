Option Explicit On
Option Strict On

Imports System
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

            ' Set AcceptChangesDuringUpdate to false.
            adapter.AcceptChangesDuringUpdate = False

            ' Add the parameter for the inserted value.
            adapter.InsertCommand.Parameters.Add( _
               New SqlParameter("@CompanyName", SqlDbType.NVarChar, 40, _
               "CompanyName"))
            adapter.InsertCommand.UpdatedRowSource = _
               UpdateRowSource.FirstReturnedRecord

            ' MissingSchemaAction adds any missing schema to 
            ' the DataTable, including auto increment columns
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

            ' Fill a DataTable.
            Dim shipper As New DataTable
            adapter.Fill(shipper)

            ' Add a new shipper row. 
            Dim newRow As DataRow = shipper.NewRow()
            newRow("CompanyName") = "New Shipper"
            shipper.Rows.Add(newRow)

            ' Add changed rows to a new DataTable. This
            ' DataTable will be used to update the data source.
            Dim dataChanges As DataTable = shipper.GetChanges()

            ' Update the data source with the modified records.
            adapter.Update(dataChanges)

            Console.WriteLine("Rows before merge.")
            Dim rowBefore As DataRow
            For Each rowBefore In shipper.Rows
                Console.WriteLine("{0}: {1}", rowBefore(0), rowBefore(1))
            Next

            ' Merge the two DataTables to get new values.
            shipper.Merge(dataChanges)

            ' Commit the changes.
            shipper.AcceptChanges()

            Console.WriteLine("Rows after merge.")
            Dim rowAfter As DataRow
            For Each rowAfter In shipper.Rows
                Console.WriteLine("{0}: {1}", rowAfter(0), rowAfter(1))
            Next
        End Using
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=Northwind;" _
           & "Integrated Security=true;"
    End Function

End Module
