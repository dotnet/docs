imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub SetRowErrors(ByVal table As DataTable)
    ' Set error text for ten rows. 
    Dim i As Integer
    For i = 0 to 10
        ' Insert column 1 value into each error.
        table.Rows(i).RowError = "ERROR: " & _
            table.Rows(i)(1).ToString()
    Next
    ' Get the DataSet for the table, and test it for errors.
    Dim dataSet As DataSet = table.DataSet
    TestForErrors(dataSet)
End Sub
 
Private Sub TestForErrors(ByVal dataSet As DataSet)
    ' Test for errors. If DataSet has errors, 
    ' test each table.
    If dataSet.HasErrors
        Dim tempDataTable As DataTable
        For Each tempDataTable in dataSet.Tables
            ' If the table has errors, then print them.
            If(tempDataTable.HasErrors) Then 
                PrintRowErrs(tempDataTable)
            End If
        Next
        ' Refresh the DataGrid to see the error-marked rows.
        DataGrid1.Refresh()
    End If
End Sub
 
Private Sub PrintRowErrs(ByVal table As DataTable)
    Dim row As DataRow
    For Each row in table.Rows
       If(row.HasErrors) Then
          Console.WriteLine(row.RowError)
       End If
    Next
End Sub
' </Snippet1>

End Class
