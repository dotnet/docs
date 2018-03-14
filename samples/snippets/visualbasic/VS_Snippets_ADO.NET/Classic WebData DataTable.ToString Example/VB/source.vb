imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub PrintToString(dataSet As DataSet)
    Dim table As DataTable
    For Each table In dataSet.Tables
       Console.WriteLine(table.ToString())
    Next
End Sub
' </Snippet1>

End Class
