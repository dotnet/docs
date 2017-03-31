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
        Dim parameter As New OracleParameter( _
            "DName", OracleType.VarChar, 11, _
            ParameterDirection.Output, True, 0, 0, _
            "DName", DataRowVersion.Current, "ENGINEERING")
        Console.WriteLine(parameter.ToString())
    End Sub 
    ' </Snippet1>
End Class 'Form1 
