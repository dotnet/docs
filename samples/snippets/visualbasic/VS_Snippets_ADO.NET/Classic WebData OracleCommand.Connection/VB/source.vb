Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Public Sub CreateOracleCommand()
     Dim queryString As String = _
        "SELECT * FROM Emp ORDER BY EmpNo"
     Dim command As New OracleCommand(queryString)
     command.CommandType = CommandType.Text
 End Sub
' </Snippet1>
End Class
