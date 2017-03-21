    Sub TestPV()
        ' Define money format.
        Dim Fmt As String = "###,##0.00"
        ' Annual percentage rate.
        Dim APR As Double = 0.0825
        ' Total number of payments.
        Dim TotPmts As Double = 20
        ' Yearly income.
        Dim YrIncome As Double = 50000
        ' Future value.
        Dim FVal As Double = 1000000
        ' Payment at beginning of month.
        Dim PayType As DueDate = DueDate.BegOfPeriod
        Dim PVal As Double = PV(APR, TotPmts, -YrIncome, FVal, PayType)
        MsgBox("The present value is " & Format(PVal, Fmt) & ".")
    End Sub