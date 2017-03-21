    Sub TestPPMT()
        Dim PVal, APR, TotPmts, Payment, Period, P, I As Double
        Dim PayType As DueDate
        Dim Msg As String
        Dim Response As MsgBoxResult

        ' Define money format.
        Dim Fmt As String = "###,###,##0.00"
        ' Usually 0 for a loan.
        Dim Fval As Double = 0
        PVal = CDbl(InputBox("How much do you want to borrow?"))
        APR = CDbl(InputBox("What is the annual percentage rate of your loan?"))
        ' Ensure proper form.
        If APR > 1 Then APR = APR / 100
        TotPmts = CDbl(InputBox("How many monthly payments do you have to make?"))
        Response = MsgBox("Do you make payments at the end of month?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            PayType = DueDate.BegOfPeriod
        Else
            PayType = DueDate.EndOfPeriod
        End If
        Payment = Math.Abs(-Pmt(APR / 12, TotPmts, PVal, FVal, PayType))
        Msg = "Your monthly payment is " & Format(Payment, Fmt) & ". "
        Msg = Msg & "Would you like a breakdown of your principal and "
        Msg = Msg & "interest per period?"
        ' See if chart is desired. 
        Response = MsgBox(Msg, MsgBoxStyle.YesNo)
        If Response <> MsgBoxResult.No Then
            If TotPmts > 12 Then MsgBox("Only first year will be shown.")
            Msg = "Month  Payment  Principal  Interest" & vbNewLine
            For Period = 1 To TotPmts
                ' Show only first 12.
                If Period > 12 Then Exit For
                P = PPmt(APR / 12, Period, TotPmts, -PVal, FVal, PayType)
                ' Round principal.
                P = (Int((P + 0.005) * 100) / 100)
                I = Payment - P
                ' Round interest.
                I = (Int((I + 0.005) * 100) / 100)
                Msg = Msg & Period & vbTab & Format(Payment, Fmt)
                Msg = Msg & vbTab & Format(P, Fmt) & vbTab & Format(I, Fmt) & vbNewLine
            Next Period
            ' Display amortization table.
            MsgBox(Msg)
        End If
    End Sub