Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Sample
' <Snippet1>
  Public Sub AddSqlParameter(command As SqlCommand) 
    Dim param As SqlParameter = New SqlParameter( _
        "@Description", SqlDbType.NVarChar, 16)
    param.Value = "Beverages"
    command.Parameters.Add(param)
  End Sub
' </Snippet1>
End Class