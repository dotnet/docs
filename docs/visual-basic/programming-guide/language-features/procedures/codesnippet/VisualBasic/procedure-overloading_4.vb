    Dim customer As String
    Dim accountNum As Integer
    Dim amount As Single
    customer = MSVB.Interaction.InputBox("Enter customer name or number")
    amount = MSVB.Interaction.InputBox("Enter transaction amount")
    Try
        accountNum = CInt(customer)
        Call post(accountNum, amount)
    Catch
        Call post(customer, amount)
    End Try