imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
' Put the next line into the Declarations section.
private dataSet As DataSet 
 
Private Sub MakeDataTables()
    ' Run all of the functions. 
    MakeParentTable()
    MakeChildTable()
    MakeDataRelation()
    BindToDataGrid()
End Sub
 
Private Sub MakeParentTable()
    ' Create a new DataTable.
    Dim table As DataTable = new DataTable("ParentTable")

    ' Declare variables for DataColumn and DataRow objects.
    Dim column As DataColumn 
    Dim row As DataRow 
 
    ' Create new DataColumn, set DataType, ColumnName 
    ' and add to DataTable.    
    column = New DataColumn()
    column.DataType = System.Type.GetType("System.Int32")
    column.ColumnName = "id"
    column.ReadOnly = True
    column.Unique = True

    ' Add the Column to the DataColumnCollection.
    table.Columns.Add(column)
 
    ' Create second column.
    column = New DataColumn()
    column.DataType = System.Type.GetType("System.String")
    column.ColumnName = "ParentItem"
    column.AutoIncrement = False
    column.Caption = "ParentItem"
    column.ReadOnly = False
    column.Unique = False

    ' Add the column to the table.
    table.Columns.Add(column)
 
    ' Make the ID column the primary key column.
    Dim PrimaryKeyColumns(0) As DataColumn
    PrimaryKeyColumns(0)= table.Columns("id")
    table.PrimaryKey = PrimaryKeyColumns
 
    ' Instantiate the DataSet variable.
    dataSet = New DataSet()

    ' Add the new DataTable to the DataSet.
    dataSet.Tables.Add(table)
 
    ' Create three new DataRow objects and add 
    ' them to the DataTable
    Dim i As Integer
    For i = 0 to 2
       row = table.NewRow()
       row("id") = i
       row("ParentItem") = "ParentItem " + i.ToString()
       table.Rows.Add(row)
    Next i
End Sub
 
Private Sub MakeChildTable()
    ' Create a new DataTable.
    Dim table As DataTable = New DataTable("childTable")
    Dim column As DataColumn 
    Dim row As DataRow 
 
    ' Create first column and add to the DataTable.
    column = New DataColumn()
    column.DataType= System.Type.GetType("System.Int32")
    column.ColumnName = "ChildID"
    column.AutoIncrement = True
    column.Caption = "ID"
    column.ReadOnly = True
    column.Unique = True

    ' Add the column to the DataColumnCollection.
    table.Columns.Add(column)
 
    ' Create second column.
    column = New DataColumn()
    column.DataType= System.Type.GetType("System.String")
    column.ColumnName = "ChildItem"
    column.AutoIncrement = False
    column.Caption = "ChildItem"
    column.ReadOnly = False
    column.Unique = False
    table.Columns.Add(column)
 
    ' Create third column.
    column = New DataColumn()
    column.DataType= System.Type.GetType("System.Int32")
    column.ColumnName = "ParentID"
    column.AutoIncrement = False
    column.Caption = "ParentID"
    column.ReadOnly = False
    column.Unique = False
    table.Columns.Add(column)
 
    dataSet.Tables.Add(table)

    ' Create three sets of DataRow objects, five rows each, 
    ' and add to DataTable.
    Dim i As Integer
    For i = 0 to 4
       row = table.NewRow()
       row("childID") = i
       row("ChildItem") = "Item " + i.ToString()
       row("ParentID") = 0 
       table.Rows.Add(row)
    Next i
    For i = 0 to 4
       row = table.NewRow()
       row("childID") = i + 5
       row("ChildItem") = "Item " + i.ToString()
       row("ParentID") = 1 
       table.Rows.Add(row)
    Next i
    For i = 0 to 4
       row = table.NewRow()
       row("childID") = i + 10
       row("ChildItem") = "Item " + i.ToString()
       row("ParentID") = 2 
       table.Rows.Add(row)
    Next i
End Sub
 
Private Sub MakeDataRelation()
    ' DataRelation requires two DataColumn 
    ' (parent and child) and a name.
    Dim parentColumn As DataColumn = _
        dataSet.Tables("ParentTable").Columns("id")
    Dim childColumn As DataColumn = _
        dataSet.Tables("ChildTable").Columns("ParentID")
    Dim relation As DataRelation = new _
        DataRelation("parent2Child", parentColumn, childColumn)
    dataSet.Tables("ChildTable").ParentRelations.Add(relation)
End Sub
 
Private Sub BindToDataGrid()
    ' Instruct the DataGrid to bind to the DataSet, with the 
    ' ParentTable as the topmost DataTable.
    DataGrid1.SetDataBinding(dataSet,"ParentTable")
End Sub
 
' </Snippet1>

End Class
