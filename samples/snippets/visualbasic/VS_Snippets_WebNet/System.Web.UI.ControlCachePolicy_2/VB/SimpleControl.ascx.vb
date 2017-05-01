' <Snippet2>
Imports System.Data.SqlClient

Partial Class SimpleControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ItemsRemaining.Text = GetAvailableItems().ToString()
        CacheTime.Text = DateTime.Now.ToLongTimeString()
    End Sub

    Private Function GetAvailableItems() As Integer
        Dim sqlConnection As SqlConnection
        Dim sqlCommand As SqlCommand
        Dim items As Integer

        sqlConnection = New SqlConnection("Initial Catalog=Northwind;Data Source=localhost;Integrated Security=SSPI;")
        sqlCommand = sqlConnection.CreateCommand()
        sqlCommand.CommandType = Data.CommandType.StoredProcedure
        sqlCommand.CommandText = "GetRemainingItems"
        sqlConnection.Open()
        items = CInt(sqlCommand.ExecuteScalar())
        sqlConnection.Close()
        Return items
    End Function
End Class
' </Snippet2>
