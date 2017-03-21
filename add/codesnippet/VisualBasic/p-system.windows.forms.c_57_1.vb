    Private Sub GetCurrentItem()
        Dim myCurrencyManager As CurrencyManager
        ' Get the CurrencyManager of a TextBox control.
        myCurrencyManager = CType(textBox1.BindingContext(0), CurrencyManager)
        ' Get the current item cast as a DataRowView.
        Dim myDataRowView As DataRowView
        myDataRowView = CType(myCurrencyManager.Current, DataRowView)
        ' Print the column named ContactName.
        Console.WriteLine(myDataRowView("ContactName"))
    End Sub 'GetCurrentItem