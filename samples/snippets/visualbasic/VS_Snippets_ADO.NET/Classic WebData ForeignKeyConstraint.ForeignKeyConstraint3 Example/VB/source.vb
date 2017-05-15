Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Private Sub CreateConstraint(ByVal suppliersProducts As DataSet)
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
        fkConstraint = New ForeignKeyConstraint( _
            "ProductSalesOrders", parentColumns, childColumns)

        ' Set various properties of the constraint.
        With fkConstraint
            .DeleteRule = Rule.SetDefault
            .UpdateRule = Rule.Cascade
            .AcceptRejectRule = AcceptRejectRule.Cascade
        End With

        ' Add the constraint, and set EnforceConstraints to true.
        suppliersProducts.Tables("OrderDetails").Constraints.Add( _
            fkConstraint)
        suppliersProducts.EnforceConstraints = True
    End Sub
    ' </Snippet1>

End Module
