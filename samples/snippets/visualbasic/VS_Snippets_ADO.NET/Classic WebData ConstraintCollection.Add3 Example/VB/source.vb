Imports System
Imports System.Data

Public Class Form1
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub AddForeignConstraint(dataSet As DataSet)
    Try
        Dim parentColumn As DataColumn = _
            dataSet.Tables("Suppliers").Columns("SupplierID")
        Dim childColumn As DataColumn = _
            dataSet.Tables("Products").Columns("SupplierID")
        dataSet.Tables("Products").Constraints.Add _
            ("ProductsSuppliers", parentColumn, childColumn)
        
    Catch ex As Exception
        ' In case the constraint already exists, 
        ' catch the collision here and respond.
        Console.WriteLine("Exception of type {0} occurred.", _
            ex.GetType().ToString())
    End Try
End Sub
' </Snippet1>
End Class
