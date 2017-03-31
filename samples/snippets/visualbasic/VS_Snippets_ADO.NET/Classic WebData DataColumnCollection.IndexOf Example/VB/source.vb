imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub GetIndex(ByVal table As DataTable)
    Dim iCol As Integer
    Dim columns As DataColumnCollection = table.Columns
    If columns.Contains("City") Then
       Console.WriteLine(columns.IndexOf("City"))
    End If
End Sub
 ' </Snippet1>

End Class
