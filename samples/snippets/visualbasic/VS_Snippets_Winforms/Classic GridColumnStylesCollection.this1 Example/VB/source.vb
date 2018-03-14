imports System
imports System.Data
imports System.ComponentModel
imports System.Windows.Forms

Public Class Form1: Inherits Form

Shared Sub Main()
End Sub

 Protected DataGrid1 As DataGrid
 Protected DataSet1 As DataSet
' <Snippet1>
Private Sub GetGridColumn()
    Dim myDataGridColumnStyle As DataGridColumnStyle 
    ' Get the DataGridColumnStyle at the specified index.
    myDataGridColumnStyle = _
    DataGrid1.TableStyles(0).GridColumnStyles("Fname")
    Console.WriteLine(myDataGridColumnStyle.MappingName)
End Sub 
' </Snippet1>
End Class
