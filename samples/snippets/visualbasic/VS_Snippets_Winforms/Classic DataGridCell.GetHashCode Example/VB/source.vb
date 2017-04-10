imports System
imports System.Data
imports System.Drawing
Imports System.Collections
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
' <Snippet1>
 Private myHashTable As New Hashtable()
 
    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim dg As DataGrid = CType(sender, DataGrid)
        Dim myCell As DataGridCell = dg.CurrentCell
        Dim tempkey As String = myCell.ToString
        Console.WriteLine("Temp " & tempkey)
        If myHashTable.Contains(tempkey) Then Exit Sub
        myHashTable.Add(tempkey, myCell.GetHashCode)
        Console.WriteLine("Hashcode: " & myCell.GetHashCode.ToString)
    End Sub
       
' </Snippet1>
End Class
