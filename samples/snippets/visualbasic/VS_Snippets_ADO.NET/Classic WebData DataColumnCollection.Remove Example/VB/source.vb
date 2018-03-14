imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub TestAndRemove(ByVal colToRemove As DataColumn)
    ' Get the DataColumnCollection from a DataTable in a DataSet.
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Orders").Columns
 
    If columns.Contains(colToRemove.ColumnName) Then
       columns.Remove(colToRemove)
    End If
End Sub
' </Snippet1>

End Class
