    Sub TestFV()
        Dim TotPmts As Integer
        Dim Payment, APR, PVal, Fval As Double
        Dim PayType As DueDate
        Dim Response As MsgBoxResult

        ' Define money format.
        Dim Fmt As String = "###,###,##0.00"
        Payment = CDbl(InputBox("How much do you plan to save each month?"))
        APR = CDbl(InputBox("Enter the expected interest annual percentage rate."))
        ' Ensure proper form.
        If APR > 1 Then APR = APR / 100
        TotPmts = CInt(InputBox("For how many months do you expect to save?"))
        Response = MsgBox("Do you make payments at the end of month?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            PayType = DueDate.BegOfPeriod
        Else
            PayType = DueDate.EndOfPeriod
        End If
        PVal = CDbl(InputBox("How much is in this savings account now?"))
        Fval = FV(APR / 12, TotPmts, -Payment, -PVal, PayType)
        MsgBox("Your savings will be worth " & Format(Fval, Fmt) & ".")
    End Sub