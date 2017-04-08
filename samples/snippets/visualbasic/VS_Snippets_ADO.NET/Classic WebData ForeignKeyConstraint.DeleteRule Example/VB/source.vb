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
 ' The next line goes into the Declarations section of the module:
 ' SuppliersProducts is a class derived from DataSet.
 Private suppliersProducts As SuppliersProducts 
 
 Private Sub CreateConstraint()
    ' Declare parent column and child column variables.
    Dim parentColumn As DataColumn
    Dim childColumn As DataColumn
    Dim fkConstraint As ForeignKeyConstraint

    ' Set parent and child column variables.
    parentColumn = suppliersProducts.Tables("Suppliers").Columns("SupplierID")
    childColumn = suppliersProducts.Tables("Products").Columns("SupplieriD")
    fkConstraint = New ForeignKeyConstraint( _
        "SuppierFKConstraint", parentColumn, childColumn)

    ' Set null values when a value is deleted.
    fkConstraint.DeleteRule = Rule.SetNull
    fkConstraint.UpdateRule = Rule.Cascade
    fkConstraint.AcceptRejectRule = AcceptRejectRule.Cascade

    ' Add the constraint, and set EnforceConstraints to true.
    suppliersProducts.Tables("Suppliers").Constraints.Add(fkConstraint)
    suppliersProducts.EnforceConstraints = True
 End Sub
' </Snippet1>

End Class

Public Class SuppliersProducts : Inherits DataSet
    
End Class
