imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

Shared Sub Main()
End Sub
' <Snippet1>
' This object variable must go in the Declarations section:
Private DataGrid1 As DataGrid
 
Private Sub CreateDataGrid()
   ' Initialize a new DataGrid control.
   me.Datagrid1 = New DataGrid
   
   Dim myDataSet As DataSet = New DataSet("myDataSet")
   Dim myDataTable As DataTable = New DataTable("Customers")
   myDataSet.Tables.Add(myDataTable)
   ' Insert code to populate the DataTable with rows.
   ' Set the DataSource and DataMember of the DataGrid control.
   DataGrid1.SetDataBinding(myDataSet, "Customers")
End Sub

' </Snippet1>
End Class
