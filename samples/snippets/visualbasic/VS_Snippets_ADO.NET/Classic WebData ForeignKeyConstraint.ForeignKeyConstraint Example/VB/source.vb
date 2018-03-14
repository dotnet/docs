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
    Dim parentColumn As DataColumn
    Dim childColumn As DataColumn
    Dim fkConstraint As ForeignKeyConstraint

    ' Set parent and child column variables.
    parentColumn = _
        suppliersProducts.Tables("Suppliers").Columns("SupplierID")
    childColumn = _
        suppliersProducts.Tables("Products").Columns("SupplieriD")
    fkConstraint = New ForeignKeyConstraint(parentColumn, childColumn)

    ' Set various properties of the constraint.
    With fkConstraint
       .ConstraintName = "suppierFKConstraint"
       .DeleteRule = Rule.SetNull
       .UpdateRule = Rule.Cascade
       .AcceptRejectRule = AcceptRejectRule.Cascade
    End With

    ' Add the constraint, and set EnforceConstraints to true.
    suppliersProducts.Tables("Products").Constraints.Add(fkConstraint)
    suppliersProducts.EnforceConstraints = True
 End Sub
 ' </Snippet1>

End Class

Public Class SuppliersProducts : Inherits DataSet

End Class
