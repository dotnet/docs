' <Snippet1>
Imports System.Data
Imports System.Data.SqlClient
Public Class A
   Public Shared Sub Main()
      Using connection As New SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI;")
      connection.Open()
      Dim command As SqlCommand = connection.CreateCommand()
      command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID"
      command.CommandTimeout = 15
      command.CommandType = CommandType.Text
      End Using
   End Sub
End Class
' </Snippet1>