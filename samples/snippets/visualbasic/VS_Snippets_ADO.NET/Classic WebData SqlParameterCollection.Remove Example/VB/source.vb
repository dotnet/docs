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
    Protected command As SqlCommand
    Protected param As SqlParameter
    
    
    ' <Snippet1>
    Public Sub SearchSqlParams()
        ' ...
        ' create SqlCommand command and SqlParameter param
        ' ...
        If command.Parameters.Contains(param) Then
            command.Parameters.Remove(param)
        End If
    End Sub 'SearchSqlParams
    ' </Snippet1>
End Class 'Form1