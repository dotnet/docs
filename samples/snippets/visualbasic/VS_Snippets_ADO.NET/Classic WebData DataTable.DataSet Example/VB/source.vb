imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Function GetDataSetFromTable() As DataSet
    Dim table As DataTable

    ' Check to see if the DataGrid's DataSource property
    ' is a DataTable.
    If TypeOf dataGrid1.DataSource Is DataTable Then
        table = CType(DataGrid1.DataSource, DataTable)
        GetDataSetFromTable = table.DataSet
    Else
        return Nothing
    End If
End Function
' </Snippet1>

End Class
