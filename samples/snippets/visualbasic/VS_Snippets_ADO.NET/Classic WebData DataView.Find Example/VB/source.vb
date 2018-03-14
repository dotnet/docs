imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms

Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub FindValueInDataView(table As DataTable)
    Dim view As DataView = New DataView(table)
    view.Sort = "CustomerID"

    ' Find the customer named "DUMON" in the primary key column
    Dim i As Integer = view.Find("DUMON")
    Console.WriteLine(view(i))
End Sub
' </Snippet1>

End Class
