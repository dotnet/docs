Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    
    
    ' <Snippet1>
    Public Sub CreateCommand()
        Dim queryString As String = "SELECT * FROM Categories ORDER BY CategoryID"
        Dim command As New SqlCommand(queryString)
        command.CommandTimeout = 15
        command.CommandType = CommandType.Text
    End Sub 
    ' </Snippet1>
End Class 'Form1 
