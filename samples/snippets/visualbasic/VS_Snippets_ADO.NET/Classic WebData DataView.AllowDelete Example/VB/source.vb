imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub CheckAllowDelete(rowToDelete As DataRow)
    Dim view As DataView = New DataView(DataSet1.Tables("Suppliers"))
    If view.AllowDelete Then
    rowToDelete.Delete()
    End If
End Sub
' </Snippet1>

End Class
