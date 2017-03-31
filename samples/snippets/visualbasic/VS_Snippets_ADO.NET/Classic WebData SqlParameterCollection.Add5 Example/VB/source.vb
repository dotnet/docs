Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Sample
' <Snippet1>
  Public Sub AddSqlParameter(cmd As SqlCommand) 
    Dim p1 As SqlParameter = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 16, "Description")
  End Sub
' </Snippet1>
End Class