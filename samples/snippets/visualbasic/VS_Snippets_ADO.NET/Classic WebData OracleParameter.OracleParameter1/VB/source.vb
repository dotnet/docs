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
    Public Sub CreateOracleParameter()
        Dim parameter As New OracleParameter("DName", OracleType.VarChar)
        parameter.Direction = ParameterDirection.Output
        parameter.Size = 14
    End Sub 
    ' </Snippet1>
End Class 'Form1 
