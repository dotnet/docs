Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    
    
    ' <Snippet1>
    Public Sub CreateParameterCollection(connection As OdbcConnection)
      Dim command As OdbcCommand = New OdbcCommand( _
        "SELECT * FROM Customers WHERE CustomerID = ?", connection)
      Dim paramCollection As OdbcParameterCollection = command.Parameters
      Dim parameter As OdbcParameter = paramCollection.Add( _
        "CustomerID", OdbcType.VarChar, 5, "CustomerID")
    End Sub
    ' </Snippet1>
End Class 'Form1 
