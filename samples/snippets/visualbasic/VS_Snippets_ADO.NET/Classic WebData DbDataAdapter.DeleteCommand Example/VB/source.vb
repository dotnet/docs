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

    Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter()
    Dim command As OleDbCommand
    Dim parameter As OleDbParameter

    ' Create the SelectCommand.
    command = New OleDbCommand("SELECT CustomerID FROM Customers " & _
        "WHERE Country = ? AND City = ?", connection)

    command.Parameters.Add("Country", OleDbType.VarChar, 15)
    command.Parameters.Add("City", OleDbType.VarChar, 15)

    dataAdapter.SelectCommand = command

    ' Create the DeleteCommand.
    command = New OleDbCommand( _
        "DELETE * FROM Customers WHERE CustomerID = ?", _
        connection)

    parameter = command.Parameters.Add( _
        "CustomerID", OleDbType.Char, 5, "CustomerID")
    parameter.SourceVersion = DataRowVersion.Original

    dataAdapter.DeleteCommand = command

    Return dataAdapter
End Function
'</Snippet1>
End Class



