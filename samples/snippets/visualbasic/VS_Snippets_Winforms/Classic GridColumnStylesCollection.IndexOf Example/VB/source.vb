imports System
imports System.Data
imports System.ComponentModel
imports System.Windows.Forms


Public Class Form1: Inherits Form

Shared Sub Main()
End Sub
 Protected DataGrid1 As DataGrid
 Protected DataSet1 As DataSet
' <Snippet1>
Private Sub RemoveCol(ByVal dc As DataColumn) 
    Dim myGridColumns As GridColumnStylesCollection
    myGridColumns = DataGrid1.TableStyles(0).GridColumnStyles

    If myGridColumns.Contains("FirstName") Then
        Dim i As Integer
        i = myGridColumns.IndexOf(myGridColumns("FirstName"))
        myGridColumns.RemoveAt(i)
    End If
End Sub 
' </Snippet1>
End Class
