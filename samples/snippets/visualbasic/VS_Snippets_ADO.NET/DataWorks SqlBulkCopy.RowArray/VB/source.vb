Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim connectionString As String = GetConnectionString()

        ' Open a connection to the AdventureWorks database.
        Using connection As SqlConnection = _
           New SqlConnection(connectionString)
            connection.Open()

            ' Perform an initial count on the destination table.
            Dim commandRowCount As New SqlCommand( _
            "SELECT COUNT(*) FROM dbo.BulkCopyDemoMatchingColumns;", _
                connection)
            Dim countStart As Long = _
               System.Convert.ToInt32(commandRowCount.ExecuteScalar())
            Console.WriteLine("Starting row count = {0}", countStart)

            ' Create a table with some rows.
            Dim newProducts As DataTable = MakeTable()

            ' Get a reference to a single row in the table.
            Dim rowArray() As DataRow = newProducts.Select( _
             "Name='CC-101-BK'")

            ' Note that the column positions in the source DataTable 
            ' match the column positions in the destination table, 
            ' so there is no need to map columns.
            Using bulkCopy As SqlBulkCopy = _
              New SqlBulkCopy(connection)
                bulkCopy.DestinationTableName = "dbo.BulkCopyDemoMatchingColumns"

                Try
                    ' Write the array of rows to the destination.
                    bulkCopy.WriteToServer(rowArray)

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
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

    Private Function MakeTable() As DataTable
        ' Create a new DataTable named NewProducts.
        Dim newProducts As DataTable = _
         New DataTable("NewProducts")

        ' Add three column objects to the table.
        Dim productID As DataColumn = New DataColumn()
        productID.DataType = System.Type.GetType("System.Int32")
        productID.ColumnName = "ProductID"
        productID.AutoIncrement = True
        newProducts.Columns.Add(productID)

        Dim productName As DataColumn = New DataColumn()
        productName.DataType = System.Type.GetType("System.String")
        productName.ColumnName = "Name"
        newProducts.Columns.Add(productName)

        Dim productNumber As DataColumn = New DataColumn()
        productNumber.DataType = System.Type.GetType("System.String")
        productNumber.ColumnName = "ProductNumber"
        newProducts.Columns.Add(productNumber)

        ' Create an array for DataColumn objects.
        Dim keys(0) As DataColumn
        keys(0) = productID
        newProducts.PrimaryKey = keys

        ' Add some new rows to the collection.
        Dim row As DataRow
        row = newProducts.NewRow()
        row("Name") = "CC-101-WH"
        row("ProductNumber") = "Cyclocomputer - White"
        newProducts.Rows.Add(row)

        row = newProducts.NewRow()
        row("Name") = "CC-101-BK"
        row("ProductNumber") = "Cyclocomputer - Black"
        newProducts.Rows.Add(row)

        row = newProducts.NewRow()
        row("Name") = "CC-101-ST"
        row("ProductNumber") = "Cyclocomputer - Stainless"
        newProducts.Rows.Add(row)
        newProducts.AcceptChanges()

        ' Return the new DataTable.
        Return newProducts
    End Function

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code, 
        ' you can retrieve it from a configuration file. 
        Return "Data Source=(local);" & _
            "Integrated Security=true;" & _
            "Initial Catalog=AdventureWorks;"
    End Function
End Module
' </Snippet1>
