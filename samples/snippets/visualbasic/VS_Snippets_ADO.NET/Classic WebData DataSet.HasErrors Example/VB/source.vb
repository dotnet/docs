imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataSet2 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub CheckForErrors()
    If Not DataSet1.HasErrors Then
        DataSet1.Merge(DataSet2)
    Else
       PrintRowErrs(DataSet1)
    End If
End Sub
 
Private Sub PrintRowErrs(ByVal dataSet As DataSet)
    Dim row As DataRow
    Dim table As DataTable
    For Each table In  dataSet.Tables
       For Each row In table.Rows
          If row.HasErrors Then
             Console.WriteLine(row.RowError)
          End If
       Next
    Next
End Sub
' </Snippet1>

End Class
