Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Function ReturnDataView( _
    rowView As DataRowView) As DataView
    Return rowView.DataView
End Function
' </Snippet1>
End Class
