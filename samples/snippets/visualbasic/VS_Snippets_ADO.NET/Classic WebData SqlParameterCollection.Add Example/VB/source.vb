Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Sample
' <Snippet1>
  Public Sub AddSqlParameter(command As SqlCommand) 
    command.Parameters.Add(New SqlParameter("Description", "Beverages"))
  End Sub
' </Snippet1>
End Class