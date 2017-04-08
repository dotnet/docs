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
    Public Sub CreateOdbcParameter()
        Dim parameter As New OdbcParameter()
        parameter.ParameterName = "Description"
        parameter.OdbcType = OdbcType.VarChar
        parameter.Direction = ParameterDirection.Output
        parameter.Size = 88
    End Sub 
    ' </Snippet1>
End Class 'Form1 
