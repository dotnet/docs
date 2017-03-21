    Private Sub DemonstrateRefresh()
        ' Create an array with ten elements and bind to a TextBox.
        Dim myArray(9) As String
        Dim i As Integer
        For i = 0 To 9
            myArray(i) = "item " & i
        Next i
        textBox1.DataBindings.Add("Text", myArray, "")
        ' Change one value.
        myArray(0) = "New value"

        ' Uncomment the next line to refresh the CurrencyManager.
        ' RefreshGrid(myArray);

    End Sub 'DemonstrateRefresh

    Private Sub RefreshGrid(dataSource As Object)
        Dim myCurrencyManager As CurrencyManager = CType(Me.BindingContext(dataSource), CurrencyManager)
        myCurrencyManager.Refresh()
    End Sub 'RefreshGrid