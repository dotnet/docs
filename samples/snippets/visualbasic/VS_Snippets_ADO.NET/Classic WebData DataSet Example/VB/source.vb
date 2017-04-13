' <Snippet1>
Option Explicit On
Option Strict On

Imports System.Data
Imports system.Data.SqlClient

Public Class NorthwindDataSet

    Public Shared Sub Main()
        Dim connectionString As String = _
            GetConnectionString()
        ConnectToData(connectionString)
    End Sub

    Private Shared Sub ConnectToData( _
        ByVal connectionString As String)

        ' Create a SqlConnection to the Northwind database.
        Using connection As SqlConnection = New SqlConnection( _
           connectionString)

            ' Create a SqlDataAdapter for the Suppliers table.
            Dim suppliersAdapter As SqlDataAdapter = _
               New SqlDataAdapter()

            ' A table mapping names the DataTable.
            suppliersAdapter.TableMappings.Add("Table", "Suppliers")

            ' Open the connection.
            connection.Open()
            Console.WriteLine("The SqlConnection is open.")

            ' Create a SqlCommand to retrieve Suppliers data.
            Dim suppliersCommand As SqlCommand = New SqlCommand( _
               "SELECT SupplierID, CompanyName FROM dbo.Suppliers;", _
               connection)
            suppliersCommand.CommandType = CommandType.Text

            ' Set the SqlDataAdapter's SelectCommand.
            suppliersAdapter.SelectCommand = suppliersCommand

            ' Fill the DataSet.
            Dim dataSet As DataSet = New DataSet("Suppliers")
            suppliersAdapter.Fill(dataSet)

            ' Create a second SqlDataAdapter and SqlCommand to get
            ' the Products table, a child table of Suppliers. 
            Dim productsAdapter As SqlDataAdapter = _
                New SqlDataAdapter()
            productsAdapter.TableMappings.Add("Table", "Products")

            Dim productsCommand As SqlCommand = New SqlCommand( _
               "SELECT ProductID, SupplierID FROM dbo.Products;", _
               connection)
            productsAdapter.SelectCommand = productsCommand

            ' Fill the DataSet.
            productsAdapter.Fill(dataSet)

            ' Close the connection.
            connection.Close()
            Console.WriteLine("The SqlConnection is closed.")

            ' Create a DataRelation to link the two tables
            ' based on the SupplierID.
            Dim parentColumn As DataColumn = _
               dataSet.Tables("Suppliers").Columns("SupplierID")
            Dim childColumn As DataColumn = _
               dataSet.Tables("Products").Columns("SupplierID")
            Dim relation As DataRelation = New _
               System.Data.DataRelation("SuppliersProducts", _
               parentColumn, childColumn)
            dataSet.Relations.Add(relation)

            Console.WriteLine( _
               "The {0} DataRelation has been created.", _
               relation.RelationName)
        End Using

    End Sub

    Private Shared Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=Northwind;" _
           & "Integrated Security=SSPI;"
    End Function
End Class
' </Snippet1>
