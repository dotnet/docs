Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Private Sub DemonstrateMerge()
     ' Create a DataSet with one table, two columns, and three rows.
     Dim dataSet As New DataSet("dataSet")
     Dim table As New DataTable("Items")
     Dim idColumn As New DataColumn("id", Type.GetType("System.Int32"))
     idColumn.AutoIncrement = True
     Dim itemColumn As New DataColumn("Item", Type.GetType("System.Int32"))

     ' DataColumn array to set primary key.
     Dim keyColumn(1) As DataColumn
     Dim row As DataRow

     ' Create variable for temporary DataSet. 
     Dim changeDataSet As DataSet

     ' Add columns to table, and table to DataSet.   
     table.Columns.Add(idColumn)
     table.Columns.Add(itemColumn)
     dataSet.Tables.Add(table)

     ' Set primary key column.
     keyColumn(0) = idColumn
     table.PrimaryKey = keyColumn

     ' Add ten rows.
     Dim i As Integer
     For i = 0 To 9
         row = table.NewRow()
         row("Item") = i
         table.Rows.Add(row)
     Next i

     ' Accept changes.
     dataSet.AcceptChanges()
     PrintValues(dataSet, "Original values")

     ' Change two row values.
     table.Rows(0)("Item") = 50
     table.Rows(1)("Item") = 111

     ' Add one row.
     row = table.NewRow()
     row("Item") = 74
     table.Rows.Add(row)

     ' Insert code for error checking. Set one row in error.
     table.Rows(1).RowError = "over 100"
     PrintValues(dataSet, "Modified and New Values")

     ' If the table has changes or errors, create a subset DataSet.
     If dataSet.HasChanges(DataRowState.Modified Or DataRowState.Added) _
        And dataSet.HasErrors Then

         ' Use GetChanges to extract subset.
         changeDataSet = dataSet.GetChanges(DataRowState.Modified _
            Or DataRowState.Added)
         PrintValues(changeDataSet, "Subset values")

         ' Insert code to reconcile errors. In this case, reject changes.
         Dim changeTable As DataTable
         For Each changeTable In  changeDataSet.Tables
             If changeTable.HasErrors Then
                 Dim changeRow As DataRow
                 For Each changeRow In  changeTable.Rows
                     'Console.WriteLine(changeRow["Item"]);
                     If CInt(changeRow("Item", _
                        DataRowVersion.Current)) > 100 Then
                         changeRow.RejectChanges()
                         changeRow.ClearErrors()
                     End If
                 Next changeRow
             End If
         Next changeTable
         PrintValues(changeDataSet, "Reconciled subset values")

         ' Merge changes back to first DataSet.
         dataSet.Merge(changeDataSet)
         PrintValues(dataSet, "Merged Values")
     End If
 End Sub
 
Private Sub PrintValues(dataSet As DataSet, label As String)
     Console.WriteLine(ControlChars.Cr & label)
     Dim table As DataTable
     For Each table In  dataSet.Tables
         Console.WriteLine("TableName: " & table.TableName)
         Dim row As DataRow
         For Each row In  table.Rows
             Dim column As DataColumn
             For Each column In  table.Columns
                 Console.Write(ControlChars.Tab & " " _
                    & row(column).ToString())
             Next column
             Console.WriteLine()
         Next row
     Next table
End Sub
' </Snippet1>
End Class
