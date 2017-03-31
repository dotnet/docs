imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
 Private Sub RemoveColumnAtIndex(thisIndex As Integer)
    ' Get the DataColumnCollection from a DataTable in a DataSet.
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Orders").Columns

    If columns.CanRemove(columns(thisIndex)) Then 
       columns.RemoveAt(thisIndex)
    End If
 End Sub
' </Snippet1>

End Class
