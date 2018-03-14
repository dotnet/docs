imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected TextBox1 As TextBox
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub RemoveFoundRow(ByVal table As DataTable)
    Dim rowCollection As DataRowCollection = table.Rows

    ' Test to see if the collection contains the value.
    If rowCollection.Contains(TextBox1.Text) Then
        Dim foundRow As DataRow = rowCollection.Find(TextBox1.Text)
        rowCollection.Remove(foundRow)
        Console.WriteLine("Row Deleted")
    Else
        Console.WriteLine("No such row found.")
    End If
 End Sub
 ' </Snippet1>

End Class
