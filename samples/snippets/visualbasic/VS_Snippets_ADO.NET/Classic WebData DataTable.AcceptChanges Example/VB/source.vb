imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub AcceptOrReject(table As DataTable)
    ' If there are errors, try to reconcile.
        If (table.HasErrors) Then
            If (Reconcile(table)) Then
                ' Fixed all errors.
                table.AcceptChanges()
            Else
                ' Couldn'table fix all errors.
                table.RejectChanges()
            End If
        Else
            ' If no errors, AcceptChanges.
            table.AcceptChanges()
        End If
 End Sub
 
Private Function Reconcile(thisTable As DataTable) As Boolean
    Dim row As DataRow
    For Each row in thisTable.Rows
       'Insert code to try to reconcile error.

       ' If there are still errors return immediately
       ' since the caller rejects all changes upon error.
       If row.HasErrors Then
           Reconcile = False
           Exit Function
       End If
    Next row
    Reconcile = True
 End Function
 ' </Snippet1>

End Class
