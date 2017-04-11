imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub DeleteRow(view As DataView, val As String)
    ' Find the given value in the DataView and delete the row.
    Dim i As Integer = view.Find(val)

    If i = -1 Then
        ' The value wasn'table found
        Console.WriteLine("Value not found in primary key column")
        Exit Sub
    Else
        view.Delete(i)
    End If
End Sub
' </Snippet1>

End Class
