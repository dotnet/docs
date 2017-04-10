imports System
imports System.Xml
imports System.Data
imports System.Data.OleDb
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 ' The next line goes into the Declarations section.
 ' SuppliersProducts is a class derived from DataSet.
 Private suppliersProducts As SuppliersProducts
 
 Private Sub CreateConstraint()
    ' Declare parent column and child column variables.
    Dim parentColumns(1) As DataColumn
    Dim childColumns(1) As DataColumn
    Dim fkConstraint As ForeignKeyConstraint

    ' Set parent and child column variables.
    parentColumns(0) = _
        suppliersProducts.Tables("OrderDetails").Columns("OrderID")
    parentColumns(1) = _
        suppliersProducts.Tables("OrderDetails").Columns("ProductID")
    childColumns(0) = _
        suppliersProducts.Tables("Sales").Columns("OrderID")
    childColumns(1) = _
        suppliersProducts.Tables("Sales").Columns("ProductID")
    fkConstraint = _
        New ForeignKeyConstraint(parentColumns, childColumns)

    ' Set various properties of the constraint.
    With fkConstraint
       .ConstraintName = "ProductSalesOrders"
       .DeleteRule = Rule.SetDefault
       .UpdateRule = Rule.Cascade
       .AcceptRejectRule = AcceptRejectRule.Cascade
    End With

    ' Add the constraint, and set EnforceConstraints to true.
    suppliersProducts.Tables( _
        "OrderDetails").Constraints.Add(fkConstraint)
    suppliersProducts.EnforceConstraints = True
 End Sub
 ' </Snippet1>

End Class

Public Class SuppliersProducts : Inherits DataSet

End Class
