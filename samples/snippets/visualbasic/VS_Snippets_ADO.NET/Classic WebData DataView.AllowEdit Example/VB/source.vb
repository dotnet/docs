imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub EditRow(view As DataView)
    view.AllowEdit = True
    view(0).BeginEdit
    view(0)("FirstName") = "Mary"
    view(0)("LastName") = "Jones"
    view(0).EndEdit
End Sub
' </Snippet1>

End Class
