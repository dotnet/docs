Option Explicit On
Option Strict On
Imports System.Data

Module Module1

    Sub Main()

        CreateUniqueConstraint(CreateDataSet())
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub CreateUniqueConstraint(ByVal dataSetSuppliers As DataSet)
        Dim uniqueConstraint As UniqueConstraint

        ' Get the DataColumn of a table in a DataSet.
        Dim dataColumn As DataColumn
        dataColumn = dataSetSuppliers.Tables("Suppliers").Columns("SupplierID")

        ' Create the constraint.
        uniqueConstraint = New UniqueConstraint("supplierIdConstraint", dataColumn)

        ' Add the constraint to the ConstraintCollection of the DataTable.
        dataSetSuppliers.Tables("Suppliers").Constraints.Add(uniqueConstraint)
    End Sub
    ' </Snippet1>

    ' test by adding the following line of code before End Sub:
    ' Console.WriteLine(dataSetSuppliers.Tables(0).Constraints(0).ConstraintName)

    Private Function CreateDataSet() As DataSet
        Dim ds As New DataSet("dataSetSuppliers")
        Dim dt As New DataTable("Suppliers")
        Dim firstName As New DataColumn("SupplierID", _
          Type.GetType("System.String"))
        dt.Columns.Add(firstName)
        ds.Tables.Add(dt)
        Return ds
    End Function

End Module