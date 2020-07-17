Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim connectionString As String = _
            GetConnectionString()
        ConnectToData(connectionString)
    End Sub
    Private Sub ConnectToData( _
         ByVal connectionString As String)

        ' <Snippet1>
        Using connection As SqlConnection = New SqlConnection( _
           connectionString)

            Dim adapter As New SqlDataAdapter( _
              "SELECT CustomerID, CompanyName FROM Customers", connection)

            connection.Open()

            Dim customers As New DataSet()
            adapter.FillSchema(customers, SchemaType.Source, "Customers")
            adapter.Fill(customers, "Customers")

            Dim orders As New DataSet()
            orders.ReadXml("Orders.xml", XmlReadMode.ReadSchema)
            orders.AcceptChanges()

            customers.Merge(orders, True, MissingSchemaAction.AddWithKey)
        End Using
        ' </Snippet1>
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=Northwind;" _
           & "Integrated Security=SSPI;"
    End Function

End Module
