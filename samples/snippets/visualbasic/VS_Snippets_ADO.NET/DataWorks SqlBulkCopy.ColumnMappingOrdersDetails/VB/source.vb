Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim connectionString As String = GetConnectionString()

        ' Open a connection to the AdventureWorks database.
        Using connection As SqlConnection = New SqlConnection(connectionString)
            connection.Open()

            ' Empty the destination tables.
            Dim deleteHeader As New SqlCommand( _
              "DELETE FROM dbo.BulkCopyDemoOrderHeader;", connection)
            deleteHeader.ExecuteNonQuery()
            deleteHeader.Dispose()
            Dim deleteDetail As New SqlCommand( _
              "DELETE FROM dbo.BulkCopyDemoOrderDetail;", connection)
            deleteDetail.ExecuteNonQuery()

            ' Perform an initial count on the destination table
            ' with matching columns.
            Dim countRowHeader As New SqlCommand( _
               "SELECT COUNT(*) FROM dbo.BulkCopyDemoOrderHeader;", _
                connection)
            Dim countStartHeader As Long = System.Convert.ToInt32( _
             countRowHeader.ExecuteScalar())
            Console.WriteLine("Starting row count for Header table = {0}", _
             countStartHeader)

            ' Perform an initial count on the destination table
            ' with different column positions.
            Dim countRowDetail As New SqlCommand( _
                "SELECT COUNT(*) FROM dbo.BulkCopyDemoOrderDetail;", _
                connection)
            Dim countStartDetail As Long = System.Convert.ToInt32( _
                countRowDetail.ExecuteScalar())
            Console.WriteLine("Starting row count for Detail table = " & _
               countStartDetail)

            ' Get data from the source table as a SqlDataReader.
            ' The Sales.SalesOrderHeader and Sales.SalesOrderDetail
            ' tables are quite large and could easily cause a timeout
            ' if all data from the tables is added to the destination.
            ' To keep the example simple and quick, a parameter is
            ' used to select only orders for a particular account as
            ' the source for the bulk insert.
            Dim headerData As SqlCommand = New SqlCommand( _
             "SELECT [SalesOrderID], [OrderDate], " & _
             "[AccountNumber] FROM [Sales].[SalesOrderHeader] " & _
             "WHERE [AccountNumber] = @accountNumber;", _
             connection)

            Dim parameterAccount As SqlParameter = New SqlParameter()
            parameterAccount.ParameterName = "@accountNumber"
            parameterAccount.SqlDbType = SqlDbType.NVarChar
            parameterAccount.Direction = ParameterDirection.Input
            parameterAccount.Value = "10-4020-000034"
            headerData.Parameters.Add(parameterAccount)

            Dim readerHeader As SqlDataReader = _
             headerData.ExecuteReader()

            ' Get the Detail data in a separate connection.
            Using connection2 As SqlConnection = New SqlConnection(connectionString)
                connection2.Open()

                Dim sourceDetailData As SqlCommand = New SqlCommand( _
                 "SELECT [Sales].[SalesOrderDetail].[SalesOrderID], " & _
                 "[SalesOrderDetailID], [OrderQty], [ProductID], [UnitPrice] " & _
                 "FROM [Sales].[SalesOrderDetail] INNER JOIN " & _
                 "[Sales].[SalesOrderHeader] " & _
                 "ON [Sales].[SalesOrderDetail].[SalesOrderID] = " & _
                 "[Sales].[SalesOrderHeader].[SalesOrderID] " & _
                 "WHERE [AccountNumber] = @accountNumber;", connection2)

                Dim accountDetail As SqlParameter = New SqlParameter()
                accountDetail.ParameterName = "@accountNumber"
                accountDetail.SqlDbType = SqlDbType.NVarChar
                accountDetail.Direction = ParameterDirection.Input
                accountDetail.Value = "10-4020-000034"
                sourceDetailData.Parameters.Add( _
                 accountDetail)

                Dim readerDetail As SqlDataReader = _
                 sourceDetailData.ExecuteReader()

                ' Create the SqlBulkCopy object.
                Using bulkCopy As SqlBulkCopy = _
                  New SqlBulkCopy(connectionString)
                    bulkCopy.DestinationTableName = "dbo.BulkCopyDemoOrderHeader"

                    ' Guarantee that columns are mapped correctly by
                    ' defining the column mappings for the order.
                    bulkCopy.ColumnMappings.Add("SalesOrderID", "SalesOrderID")
                    bulkCopy.ColumnMappings.Add("OrderDate", "OrderDate")
                    bulkCopy.ColumnMappings.Add("AccountNumber", "AccountNumber")

                    ' Write readerHeader to the destination.
                    Try
                        bulkCopy.WriteToServer(readerHeader)
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    Finally
                        readerHeader.Close()
                    End Try

                    ' Set up the order details destination.
                    bulkCopy.DestinationTableName = "dbo.BulkCopyDemoOrderDetail"

                    ' Clear the ColumnMappingCollection.
                    bulkCopy.ColumnMappings.Clear()

                    ' Add order detail column mappings.
                    bulkCopy.ColumnMappings.Add("SalesOrderID", "SalesOrderID")
                    bulkCopy.ColumnMappings.Add("SalesOrderDetailID", "SalesOrderDetailID")
                    bulkCopy.ColumnMappings.Add("OrderQty", "OrderQty")
                    bulkCopy.ColumnMappings.Add("ProductID", "ProductID")
                    bulkCopy.ColumnMappings.Add("UnitPrice", "UnitPrice")

                    ' Write readerDetail to the destination.
                    Try
                        bulkCopy.WriteToServer(readerDetail)
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    Finally
                        readerDetail.Close()
                    End Try
                End Using

                ' Perform a final count on the destination tables
                ' to see how many rows were added.
                Dim countEndHeader As Long = System.Convert.ToInt32( _
                  countRowHeader.ExecuteScalar())
                Console.WriteLine("{0} rows were added to the Header table.", _
                  countEndHeader - countStartHeader)
                Dim countEndDetail As Long = System.Convert.ToInt32( _
                   countRowDetail.ExecuteScalar())
                Console.WriteLine("{0} rows were added to the Detail table.", _
                    countEndDetail - countStartDetail)

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
