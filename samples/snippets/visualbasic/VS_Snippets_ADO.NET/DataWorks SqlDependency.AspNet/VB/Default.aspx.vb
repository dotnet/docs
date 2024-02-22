Option Strict On
Option Explicit On
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    ' <Snippet1>
    Protected Sub Page_Load(ByVal sender As Object, _
       ByVal e As System.EventArgs) Handles Me.Load

        Label1.Text = "Cache Refresh: " & _
           Date.Now.ToLongTimeString()

        ' Create a dependency connection to the database
        SqlDependency.Start(GetConnectionString())

        Using connection As New SqlConnection(GetConnectionString())
            Using command As New SqlCommand(GetSQL(), connection)
                Dim dependency As New SqlCacheDependency(command)

                ' Refresh the cache after the number of minutes
                ' listed below if a change does not occur.
                ' This value could be stored in a configuration file.
                Dim numberOfMinutes As Integer = 3
                Dim expires As Date = _
                    DateTime.Now.AddMinutes(numberOfMinutes)

                Response.Cache.SetExpires(expires)
                Response.Cache.SetCacheability(HttpCacheability.Public)
                Response.Cache.SetValidUntilExpires(True)

                Response.AddCacheDependency(dependency)

                connection.Open()

                GridView1.DataSource = command.ExecuteReader()
                GridView1.DataBind()
            End Using
        End Using
    End Sub
    ' </Snippet1>

    ' <Snippet2>
    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file.

        Return "Data Source=(local);Integrated Security=true;" & _
         "Initial Catalog=AdventureWorks;"
    End Function

    Private Function GetSQL() As String
        Return "SELECT Production.Product.ProductID, " & _
        "Production.Product.Name, " & _
        "Production.Location.Name AS Location, " & _
        "Production.ProductInventory.Quantity " & _
        "FROM Production.Product INNER JOIN " & _
        "Production.ProductInventory " & _
        "ON Production.Product.ProductID = " & _
        "Production.ProductInventory.ProductID " & _
        "INNER JOIN Production.Location " & _
        "ON Production.ProductInventory.LocationID = " & _
        "Production.Location.LocationID " & _
        "WHERE ( Production.ProductInventory.Quantity <= 100) " & _
        "ORDER BY Production.ProductInventory.Quantity, " & _
        "Production.Product.Name;"
    End Function
    ' </Snippet2>
End Class
