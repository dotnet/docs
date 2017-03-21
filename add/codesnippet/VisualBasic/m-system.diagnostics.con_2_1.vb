    Sub Insert(ByVal index As Integer, ByVal value As [Object]) Implements IArray.Insert
        Contract.Requires(index >= 0)
        Contract.Requires(index <= CType(Me, IArray).Count) ' For inserting immediately after the end.
        Contract.Ensures(CType(Me, IArray).Count = Contract.OldValue(CType(Me, IArray).Count) + 1)

    End Sub 'IArray.Insert