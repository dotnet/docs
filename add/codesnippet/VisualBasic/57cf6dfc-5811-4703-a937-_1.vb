    Sub TestNPer()
        Dim TotPmts As Double
        Dim PVal, APR, Payment As Double
        Dim PayType As DueDate
        Dim Response As MsgBoxResult

        ' Usually 0 for a loan.
        Dim Fval As Double = 0
        PVal = CDbl(InputBox("How much do you want to borrow?"))
        APR = CDbl(InputBox("What is the annual percentage rate of your loan?"))
        ' Usually 0 for a loan.
        If APR > 1 Then APR = APR / 100
        Payment = CDbl(InputBox("How much do you want to pay each month?"))
        Response = MsgBox("Do you make payments at the end of month?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            PayType = DueDate.BegOfPeriod
        Else
            PayType = DueDate.EndOfPeriod
        End If
        TotPmts = NPer(APR / 12, -Payment, PVal, FVal, PayType)
        If Int(TotPmts) <> TotPmts Then TotPmts = Int(TotPmts) + 1

        MsgBox("It will take you " & TotPmts & " months to pay off your loan.")
    End Sub