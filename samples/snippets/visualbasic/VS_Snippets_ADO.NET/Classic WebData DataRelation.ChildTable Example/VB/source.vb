imports System
imports System.Data
imports System.Diagnostics
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub GetChildTable()
    ' Get a DataRelation of a DataSet.
    Dim relation As DataRelation = _
        DataSet1.Relations("CustomerOrders")

    ' Get the child DataTable of the relation.
    Dim table As DataTable = relation.ChildTable

    ' Print the name and number of rows of the child table.
    Console.Writeline("Name: {0} Rowcount: {1}", _
        table.TableName, table.Rows.Count.ToString())
End Sub
' </Snippet1>

End Class
