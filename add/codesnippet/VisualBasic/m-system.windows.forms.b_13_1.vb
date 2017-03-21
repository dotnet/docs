    Private Sub CancelEdit()
        ' Gets the CurrencyManager which is returned when the 
        ' data source is a DataView.
        Dim myMgr As BindingManagerBase = _
        CType(BindingContext(myDataView), CurrencyManager)

        ' Gets the current row and changes a value. Then cancels the 
        ' edit and thereby discards the changes.
        Dim tempRowView As DataRowView = _
        CType(myMgr.Current, DataRowView)
        Console.WriteLine("Original: {0}", tempRowView("myCol"))
        tempRowView("myCol") = "These changes will be discarded"
        Console.WriteLine("Edit: {0}", tempRowView("myCol"))
        myMgr.CancelCurrentEdit()
        Console.WriteLine("After CanceCurrentlEdit: {0}", _
        tempRowView("myCol"))
    End Sub

    Private Sub EndEdit()
        ' Gets the CurrencyManager which is returned when the 
        ' data source is a DataView.
        Dim myMgr As BindingManagerBase = _
        CType(BindingContext(myDataView), CurrencyManager)

        ' Gets the current row and changes a value. Then ends the 
        ' edit and thereby keeps the changes.
        Dim tempRowView As DataRowView = _
        CType(myMgr.Current, DataRowView)
        Console.WriteLine("Original: {0}", tempRowView("myCol"))
        tempRowView("myCol") = "These changes will be kept"
        Console.WriteLine("Edit: {0}", tempRowView("myCol"))
        myMgr.EndCurrentEdit()
        Console.WriteLine("After EndCurrentEdit: {0}", _
        tempRowView("myCol"))
    End Sub