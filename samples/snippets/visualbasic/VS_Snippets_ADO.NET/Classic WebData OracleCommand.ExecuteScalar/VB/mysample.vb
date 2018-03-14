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
Public Sub CreateOracleCommand(myScalarQuery As String, connection As OracleConnection)
    Dim command As New OracleCommand(myScalarQuery, connection)
    command.Connection.Open()
    command.ExecuteScalar()
    connection.Close()
End Sub 'CreateOracleCommand
' </Snippet1>
End Class
