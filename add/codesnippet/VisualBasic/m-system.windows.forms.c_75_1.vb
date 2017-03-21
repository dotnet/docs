    Private Sub RemoveFromList()
        ' Get the CurrencyManager of a TextBox control.
        Dim myCurrencyManager As CurrencyManager = CType(textBox1.BindingContext(0), CurrencyManager)
        ' If the count is 0, exit the function.
        If myCurrencyManager.Count > 1 Then
            myCurrencyManager.RemoveAt(0)
        End If
        
    End Sub 'RemoveFromList