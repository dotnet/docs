        DisplayInExcel(bankAccounts,
               Sub(account, cell)
                   ' This multiline lambda expression sets custom
                   ' processing rules for the bankAccounts.
                   cell.Value = account.ID
                   cell.Offset(0, 1).Value = account.Balance

                   If account.Balance < 0 Then
                       cell.Interior.Color = RGB(255, 0, 0)
                       cell.Offset(0, 1).Interior.Color = RGB(255, 0, 0)
                   End If
               End Sub)