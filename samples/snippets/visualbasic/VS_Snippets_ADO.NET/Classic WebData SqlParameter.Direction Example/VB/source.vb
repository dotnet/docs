
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
    Public Sub CreateSqlParameter()
        Dim parameter As New SqlParameter( _
            "@Description", SqlDbType.VarChar)
        parameter.Direction = ParameterDirection.Output
    End Sub 
    ' </Snippet1>
End Class 'Form1 
