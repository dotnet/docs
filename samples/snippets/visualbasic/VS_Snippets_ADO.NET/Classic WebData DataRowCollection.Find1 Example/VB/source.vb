imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub FindInMultiPKey(ByVal table As DataTable)
    ' Create an array for the key values to find.
    Dim findTheseVals(2) As Object

    ' Set the values of the keys to find.
    findTheseVals(0) = "John"
    findTheseVals(1) = "Smith"
    findTheseVals(2) = "5 Main St."

    Dim foundRow As DataRow = table.Rows.Find(findTheseVals)
    ' Display column 1 of the found row.
    If Not (foundRow Is Nothing) Then
        Console.WriteLine(foundRow(1).ToString())
    End If
End Sub
' </Snippet1>

End Class
