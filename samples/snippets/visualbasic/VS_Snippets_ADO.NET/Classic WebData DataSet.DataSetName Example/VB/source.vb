imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub CreateDataSet() 
    Dim dataSet As DataSet
    dataSet = New DataSet("SuppliersProducts")
    Console.WriteLine(dataSet.DataSetName)
End Sub
' </Snippet1>

End Class
