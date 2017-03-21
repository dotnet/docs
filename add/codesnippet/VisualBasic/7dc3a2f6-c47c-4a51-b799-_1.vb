    Sub TestPMT()
        Dim PVal, APR, Payment, TotPmts As Double
        Dim PayType As DueDate
        Dim Response As MsgBoxResult

        ' Define money format.
        Dim Fmt As String = "###,###,##0.00"
        ' Usually 0 for a loan.
        Dim FVal As Double = 0
        PVal = CDbl(InputBox("How much do you want to borrow?"))
        APR = CDbl(InputBox("What is the annual percentage rate of your loan?"))
        If APR > 1 Then APR = APR / 100 ' Ensure proper form.
        TotPmts = CDbl(InputBox("How many monthly payments will you make?"))
        Response = MsgBox("Do you make payments at the end of month?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            PayType = DueDate.BegOfPeriod
        Else
            PayType = DueDate.EndOfPeriod
        End If
        Payment = Pmt(APR / 12, TotPmts, -PVal, FVal, PayType)

        MsgBox("Your payment will be " & Format(Payment, Fmt) & " per month.")
    End Sub