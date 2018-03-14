Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Module Module1

    Sub Main()
        Dim str As String = GetConnectionString()

        Dim dataSet As DataSet = GetCustomerData("CustomerData", str)

        Dim table As DataTable
        Dim column As DataColumn
        Dim row As DataRow

        For Each table In dataSet.Tables

            Console.WriteLine(table.TableName)
            For Each column In table.Columns
                Console.Write("  {0}", column.ColumnName)
            Next
            Console.WriteLine()
            For Each row In table.Rows
                For Each column In table.Columns
                    Console.Write("  {0}", row(column))
                Next
                Console.WriteLine()
            Next
        Next
    End Sub

    '<Snippet1>
    Private Function GetCustomerData(ByVal dataSetName As String, _
        ByVal connectionString As String) As DataSet

        Dim dataSet As DataSet = New DataSet(dataSetName)

        Using connection As SqlConnection = New SqlConnection(connectionString)

            Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
               "SELECT CustomerID, CompanyName, ContactName FROM dbo.Customers", _
               connection)

            Dim mapping As DataTableMapping = adapter.TableMappings.Add( _
               "Table", "Customers")
            mapping.ColumnMappings.Add("CompanyName", "Name")
            mapping.ColumnMappings.Add("ContactName", "Contact")

            connection.Open()

            adapter.FillSchema(dataSet, SchemaType.Source, "Customers")
            adapter.Fill(dataSet)
            Return dataSet
        End Using
    End Function
    '</Snippet1>
    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=Northwind;" _
           & "Integrated Security=SSPI;"
    End Function

End Module
