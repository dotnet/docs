Imports System.Data
Imports System.Data.SqlClient

Public Class Sample
' <Snippet1>
  Public Sub AddSqlParameter(command As SqlCommand) 
    Dim param As SqlParameter = command.Parameters.Add( _
        "@Description", SqlDbType.NVarChar)
    param.Size = 16
    param.Value = "Beverages"
  End Sub
' </Snippet1>
End Class
