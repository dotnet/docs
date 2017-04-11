imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub PrintAllErrs(ByVal dataSet As DataSet)
    Dim rowsInError() As DataRow
    Dim table As DataTable  
    Dim i As Integer
    Dim column As DataColumn
    For Each table In dataSet.Tables
       ' Test if the table has errors. If not, skip it.
       If table.HasErrors Then
          ' Get an array of all rows with errors.
          rowsInError = table.GetErrors()
          ' Print the error of each column in each row.
          For i = 0 To rowsInError.GetUpperBound(0)
             For Each column In table.Columns
                Console.WriteLine(column.ColumnName, _
                rowsInError(i).GetColumnError(column))
             Next
             ' Clear the row errors
          rowsInError(i).ClearErrors
          Next i
       End If
    Next
End Sub
' </Snippet1>

End Class
