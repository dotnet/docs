﻿Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim connectionString As String = GetConnectionString()

        ' Open a sourceConnection to the AdventureWorks database.
        Using sourceConnection As SqlConnection = _
           New SqlConnection(connectionString)
            sourceConnection.Open()

            ' Delete all from the destination table.
            Dim commandDelete As New SqlCommand
            commandDelete.Connection = sourceConnection
            commandDelete.CommandText = _
               "DELETE FROM dbo.BulkCopyDemoMatchingColumns"
            commandDelete.ExecuteNonQuery()

            ' Add a single row that will result in duplicate key
            ' when all rows from source are bulk copied.
            ' Note that this technique will only be successful in 
            ' illustrating the point if a row with ProductID = 446  
            ' exists in the AdventureWorks Production.Products table. 
            ' If you have made changes to the data in this table, change
            ' the SQL statement in the code to add a ProductID that
            ' does exist in your version of the Production.Products
            ' table. Choose any ProductID in the middle of the table
            ' (not first or last row) to best illustrate the result.
            Dim commandInsert As New SqlCommand
            commandInsert.Connection = sourceConnection
            commandInsert.CommandText = _
               "SET IDENTITY_INSERT dbo.BulkCopyDemoMatchingColumns ON;" & _
               "INSERT INTO dbo.BulkCopyDemoMatchingColumns " & _
               "([ProductID], [Name] ,[ProductNumber]) " & _
               "VALUES(446, 'Lock Nut 23','LN-3416');" & _
               "SET IDENTITY_INSERT dbo.BulkCopyDemoMatchingColumns OFF"
            commandInsert.ExecuteNonQuery()

            ' Perform an initial count on the destination table.
            Dim commandRowCount As New SqlCommand( _
               "SELECT COUNT(*) FROM dbo.BulkCopyDemoMatchingColumns;", _
                sourceConnection)
            Dim countStart As Long = _
               System.Convert.ToInt32(commandRowCount.ExecuteScalar())
            Console.WriteLine("Starting row count = {0}", countStart)

            ' Get data from the source table as a SqlDataReader.
            Dim commandSourceData As SqlCommand = New SqlCommand( _
               "SELECT ProductID, Name, ProductNumber " & _
               "FROM Production.Product;", sourceConnection)
            Dim reader As SqlDataReader = _
             commandSourceData.ExecuteReader()

            ' Set up the bulk copy object inside the transaction. 
            Using destinationConnection As SqlConnection = _
               New SqlConnection(connectionString)
                destinationConnection.Open()

                Using transaction As SqlTransaction = _
                  destinationConnection.BeginTransaction()

                    Using bulkCopy As SqlBulkCopy = New _
                      SqlBulkCopy(destinationConnection, _
                         SqlBulkCopyOptions.KeepIdentity, transaction)
                        bulkCopy.BatchSize = 10
                        bulkCopy.DestinationTableName = _
                         "dbo.BulkCopyDemoMatchingColumns"

                        ' Write from the source to the destination.
                        ' This should fail with a duplicate key error.
                        Try
                            bulkCopy.WriteToServer(reader)
                            transaction.Commit()

                        Catch ex As Exception
                            Console.WriteLine(ex.Message)
                            transaction.Rollback()

                        Finally
                            reader.Close()
                        End Try
                    End Using
                End Using
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
