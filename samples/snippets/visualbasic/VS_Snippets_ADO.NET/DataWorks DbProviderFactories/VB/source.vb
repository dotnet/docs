Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.Common

Class Program
    Shared Sub Main()
        Dim t As DataTable = GetProviderFactoryClasses()
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    ' This example assumes a reference to System.Data.Common.
    Private Shared Function GetProviderFactoryClasses() As DataTable

        ' Retrieve the installed providers and factories.
        Dim table As DataTable = DbProviderFactories.GetFactoryClasses()

        ' Display each row and column value.
        Dim row As DataRow
        Dim column As DataColumn
        For Each row In table.Rows
            For Each column In table.Columns
                Console.WriteLine(row(column))
            Next
        Next

        Return table
    End Function
    ' </Snippet1>
End Class

