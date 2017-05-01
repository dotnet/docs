Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class Sample

  Public Shared Sub Main()
  

  End Sub

'<Snippet1>
Public Shared Function CreateCustomerAdapter(conn As OleDbConnection) As OleDbDataAdapter 
  
  Dim da As OleDbDataAdapter = New OleDbDataAdapter()
  Dim cmd As OleDbCommand
  Dim parm As OleDbParameter

  ' Create the SelectCommand.

  cmd = New OleDbCommand("SELECT * FROM Customers " & _
                       "WHERE Country = @Country AND City = @City", conn)

  cmd.Parameters.Add("@Country", OleDbType.VarChar, 15)
  cmd.Parameters.Add("@City", OleDbType.VarChar, 15)

  da.SelectCommand = cmd

  ' Create the UpdateCommand.

  cmd = New OleDbCommand("UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " & _
                       "WHERE CustomerID = @oldCustomerID", conn)

  cmd.Parameters.Add("@CustomerID", OleDbType.Char, 5, "CustomerID")
  cmd.Parameters.Add("@CompanyName", OleDbType.VarChar, 40, "CompanyName")

  parm = cmd.Parameters.Add("@oldCustomerID", OleDbType.Char, 5, "CustomerID")
  parm.SourceVersion = DataRowVersion.Original

  da.UpdateCommand = cmd

  Return da
End Function
'</Snippet1>
End Class
