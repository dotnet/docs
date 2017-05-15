Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    
    
    ' <Snippet1>
    Public Sub CreateParameters(connection As OleDbConnection)
      Dim command As OleDbCommand = New OleDbCommand( _
        "SELECT * FROM Customers WHERE CustomerID = ?", connection)
      Dim paramCollection As OleDbParameterCollection = command.Parameters
      Dim parameter As OleDbParameter = paramCollection.Add( _
        "CustomerID", OleDbType.VarChar, 5)
    End Sub
    ' </Snippet1>
End Class 'Form1 
