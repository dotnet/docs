Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim connectionString As String = GetConnectionString()

        ' Open a connection to the AdventureWorks database.
        Using sourceConnection As SqlConnection = _
           New SqlConnection(connectionString)
            sourceConnection.Open()

            ' Perform an initial count on the destination table.
            Dim commandRowCount As New SqlCommand( _
            "SELECT COUNT(*) FROM dbo.BulkCopyDemoDifferentColumns;", _
                sourceConnection)
            Dim countStart As Long = _
               System.Convert.ToInt32(commandRowCount.ExecuteScalar())
            Console.WriteLine("Starting row count = {0}", countStart)

            ' Get data from the source table as a SqlDataReader.
            Dim commandSourceData As SqlCommand = New SqlCommand( _
               "SELECT ProductID, Name, ProductNumber " & _
               "FROM Production.Product;", sourceConnection)
            Dim reader As SqlDataReader = commandSourceData.ExecuteReader

            ' Set up the bulk copy object.
            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(connectionString)
                bulkCopy.DestinationTableName = _
                "dbo.BulkCopyDemoDifferentColumns"

                ' The column order in the source doesn't match the order 
                ' in the destination, so ColumnMappings must be defined.
                bulkCopy.ColumnMappings.Add("ProductID", "ProdID")
                bulkCopy.ColumnMappings.Add("Name", "ProdName")
                bulkCopy.ColumnMappings.Add("ProductNumber", "ProdNum")

                ' Write from the source to the destination.
                Try
                    bulkCopy.WriteToServer(reader)

                Catch ex As Exception
                    Console.WriteLine(ex.Message)

                Finally
                    ' Close the SqlDataReader. The SqlBulkCopy
                    ' object is automatically closed at the end
                    ' of the Using block.
                    reader.Close()
                End Try
            End Using

            ' Perform a final count on the destination table
            ' to see how many rows were added.
            Dim countEnd As Long = _
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
            Console.WriteLine("Ending row count = {0}", countEnd)
            Console.WriteLine("{0} rows were added.", countEnd - countStart)

            Console.WriteLine("Press Enter to finish.")
            Console.ReadLine()
        End Using
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the sourceConnection string in your code, 
        ' you can retrieve it from a configuration file. 
        Return "Data Source=(local);" & _
            "Integrated Security=true;" & _
            "Initial Catalog=AdventureWorks;"
    End Function
End Module
' </Snippet1>
