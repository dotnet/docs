imports System
imports System.Data
imports System.Diagnostics
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub GetParentTable()
    ' Get a DataRelation of a DataSet.
    Dim relation As DataRelation = _
        DataSet1.Relations("CustomerOrders")

    ' Get the parent DataTable of the relation.
    Dim table As DataTable = relation.ParentTable

    ' Print the name and number of rows of the parent table.
    Console.WriteLine(table.TableName.ToString())
    Console.WriteLine(table.Rows.Count.ToString())
End Sub
' </Snippet1>

End Class
