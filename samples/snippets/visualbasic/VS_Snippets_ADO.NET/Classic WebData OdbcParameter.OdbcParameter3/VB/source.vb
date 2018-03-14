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
        Dim parameter As New OdbcParameter("Description", OdbcType.VarChar, 88, "Description")
        parameter.Direction = ParameterDirection.Output
    End Sub 
    ' </Snippet1>
End Class 'Form1 
