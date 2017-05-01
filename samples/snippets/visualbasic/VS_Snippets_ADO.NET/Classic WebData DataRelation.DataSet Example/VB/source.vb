imports System
imports System.Data
imports System.Diagnostics
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub GetRelDataSet(relation As DataRelation)
    ' Get the DataSet of the passed in DataRelation.
    Dim dataSet As DataSet = relation.DataSet

    ' Print the table names of each table in the DataSet.
    Dim table As DataTable
    For Each table In dataSet.Tables
        Console.WriteLine(table.TableName.ToString())
    Next
End Sub
' </Snippet1>

End Class
