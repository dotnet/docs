    Function Add(ByVal value As Object) As Integer Implements IArray.Add
        ' Returns the index in which an item was inserted.
        Contract.Ensures(Contract.Result(Of Integer)() >= -1) '
        Contract.Ensures(Contract.Result(Of Integer)() < CType(Me, IArray).Count) '
        Return 0
        
    End Function 'IArray.Add