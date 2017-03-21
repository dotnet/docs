    Private Sub AddListItem()
        ' Get the CurrencyManager for a DataTable.
        Dim myCurrencyManager As CurrencyManager = _ 
            CType(Me.BindingContext(DataTable1), CurrencyManager)
        myCurrencyManager.AddNew()
    End Sub 'AddListItem