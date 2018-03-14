Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class Sample

  Public Shared Sub Main()
  

  End Sub

'<Snippet1>
Public Shared Function CreateCustomerAdapter( _
    connection As OleDbConnection) As OleDbDataAdapter 

    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
    Dim command As OleDbCommand

    ' Create the SelectCommand.
    command = New OleDbCommand("SELECT * FROM Customers " & _
        "WHERE Country = ? AND City = ?", connection)

    command.Parameters.Add("Country", OleDbType.VarChar, 15)
    command.Parameters.Add("City", OleDbType.VarChar, 15)

    adapter.SelectCommand = command

    ' Create the InsertCommand.
    command = New OleDbCommand( _
        "INSERT INTO Customers (CustomerID, CompanyName) " & _
        "VALUES (?, ?)", connection)

    command.Parameters.Add( _
        "CustomerID", OleDbType.Char, 5, "CustomerID")
    command.Parameters.Add( _
        "CompanyName", OleDbType.VarChar, 40, "CompanyName")

    adapter.InsertCommand = command
    Return adapter
End Function
'</Snippet1>
End Class



