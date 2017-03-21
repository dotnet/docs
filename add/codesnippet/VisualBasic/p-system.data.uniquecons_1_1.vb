Private Sub GetPrimaryKey()
    Dim dataRelation As DataRelation
    Dim uniqueConstraint As UniqueConstraint

    ' Get a DataRelation from a DataSet.
    dataRelation = DataSet1.Relations("CustomerOrders")

    ' Get the ParentKeyConstraint.
    uniqueConstraint = dataRelation.ParentKeyConstraint

    ' Test if the IsPrimaryKey is true.
    If uniqueConstraint.IsPrimaryKey Then
       Console.WriteLine("IsPrimaryKey=True")
    Else
       Console.WriteLine("IsPrimaryKey=False")
    End If
 End Sub