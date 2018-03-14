imports System
imports System.Data

Public Class Form1

' <Snippet1>
 Private Sub CreateConstraint(dataSet As DataSet, _
    table1 As String, table2 As String, _
    column1 As String, column2 As String)

    ' Declare parent column and child column variables.
    Dim parentColumn As DataColumn
    Dim childColumn As DataColumn
    Dim foreignKeyConstraint As ForeignKeyConstraint

    ' Set parent and child column variables.
    parentColumn = dataSet.Tables(table1).Columns(column1)
    childColumn = dataSet.Tables(table2).Columns(column2)
    foreignKeyConstraint = New ForeignKeyConstraint _
       ("SupplierForeignKeyConstraint", parentColumn, childColumn)

    ' Set null values when a value is deleted.
    foreignKeyConstraint.DeleteRule = Rule.SetNull
    foreignKeyConstraint.UpdateRule = Rule.Cascade
    foreignKeyConstraint.AcceptRejectRule = AcceptRejectRule.None

    ' Add the constraint, and set EnforceConstraints to true.
    dataSet.Tables(table1).Constraints.Add(foreignKeyConstraint)
    dataSet.EnforceConstraints = True
 End Sub
' </Snippet1>

End Class

