    Sub TestRate()
        Dim PVal, Payment, TotPmts, APR As Double
        Dim PayType As DueDate

        ' Define percentage format.
        Dim Fmt As String = "##0.00"
        Dim Response As MsgBoxResult
        ' Usually 0 for a loan.
        Dim FVal As Double = 0
        ' Guess of 10 percent.
        Dim Guess As Double = 0.1
        PVal = CDbl(InputBox("How much did you borrow?"))
        Payment = CDbl(InputBox("What's your monthly payment?"))
        TotPmts = CDbl(InputBox("How many monthly payments do you have to make?"))
        Response = MsgBox("Do you make payments at the end of the month?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            PayType = DueDate.BegOfPeriod
        Else
            PayType = DueDate.EndOfPeriod
        End If
        APR = (Rate(TotPmts, -Payment, PVal, FVal, PayType, Guess) * 12) * 100

        MsgBox("Your interest rate is " & Format(CInt(APR), Fmt) & " percent.")
    End Sub