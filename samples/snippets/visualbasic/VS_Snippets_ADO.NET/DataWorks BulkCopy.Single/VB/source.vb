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
            "SELECT COUNT(*) FROM dbo.BulkCopyDemoMatchingColumns;", _
                sourceConnection)
            Dim countStart As Long = _
               System.Convert.ToInt32(commandRowCount.ExecuteScalar())
            Console.WriteLine("Starting row count = {0}", countStart)

            ' Get data from the source table as a SqlDataReader.
            Dim commandSourceData As New SqlCommand( _
               "SELECT ProductID, Name, ProductNumber " & _
               "FROM Production.Product;", sourceConnection)
            Dim reader As SqlDataReader = commandSourceData.ExecuteReader

            ' Open the destination connection. In the real world you would
            ' not use SqlBulkCopy to move data from one table to the other
            ' in the same database. This is for demonstration purposes only.
            Using destinationConnection As SqlConnection = _
                New SqlConnection(connectionString)
                destinationConnection.Open()

                ' Set up the bulk copy object.
                ' The column positions in the source data reader
                ' match the column positions in the destination table,
                ' so there is no need to map columns.
                Using bulkCopy As SqlBulkCopy = _
                  New SqlBulkCopy(destinationConnection)
                    bulkCopy.DestinationTableName = _
                    "dbo.BulkCopyDemoMatchingColumns"

                    Try
                        ' Write from the source to the destination.
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
        End Using
    End Sub

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function
End Module
' </Snippet1>
