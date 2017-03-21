        Private Sub CheckCurrencyManager(myCurrencyManager As CurrencyManager)
            ' This code is from a class named MyDataGridColumnStyle derived
            ' from DataGridColumnStyle.
            Dim myGridColumn As MyDataGridColumnStyle = Me
            Try
                myGridColumn.CheckValidDataSource(myCurrencyManager)
            Catch e As ArgumentNullException
                Console.WriteLine(e.Message)
            Catch e As ApplicationException
                Console.WriteLine(e.Message)
            End Try
        End Sub 'CheckCurrencyManager