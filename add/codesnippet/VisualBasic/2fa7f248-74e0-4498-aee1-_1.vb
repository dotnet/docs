    Sub TestIPMT()
        Dim APR, PVal, Period, IntPmt, TotInt, TotPmts As Double
        Dim PayType As DueDate
        Dim Response As MsgBoxResult

        ' Usually 0 for a loan.
        Dim Fval As Double = 0
        ' Define money format.
        Dim Fmt As String = "###,###,##0.00"
        PVal = CDbl(InputBox("How much do you want to borrow?"))
        APR = CDbl(InputBox("What is the annual percentage rate of your loan?"))
        If APR > 1 Then APR = APR / 100 ' Ensure proper form.
        TotPmts = CInt(InputBox("How many monthly payments?"))
        Response = MsgBox("Do you make payments at end of the month?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            PayType = DueDate.BegOfPeriod
        Else
            PayType = DueDate.EndOfPeriod
        End If
        For Period = 1 To TotPmts   ' Total all interest.
            IntPmt = IPmt(APR / 12, Period, TotPmts, -PVal, Fval, PayType)
            TotInt = TotInt + IntPmt
        Next Period

        ' Display results.
        MsgBox("You will pay a total of " & Format(TotInt, Fmt) & 
            " in interest for this loan.")
    End Sub