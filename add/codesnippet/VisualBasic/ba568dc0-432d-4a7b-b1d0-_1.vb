        ' Define money format.
        Dim MoneyFmt As String = "###,##0.00"
        ' Define percentage format.
        Dim PercentFmt As String = "#0.00"

        Dim values(4) As Double
        ' Business start-up costs.
        values(0) = -70000
        ' Positive cash flows reflecting income for four successive years.
        values(1) = 22000
        values(2) = 25000
        values(3) = 28000
        values(4) = 31000

        ' Use the MIRR function to calculate the internal return rate.
        ' Set the loan rate.
        Dim LoanAPR As Double = 0.1
        ' Set the reinvestment rate.
        Dim InvAPR As Double = 0.12
        ' Calculate internal rate.
        Dim RetRate As Double = MIRR(values, LoanAPR, InvAPR)
        ' Display internal return rate.
        MsgBox("The modified internal rate of return for these cash flows is " & 
            Format(Math.Abs(RetRate) * 100, CStr(PercentFmt)) & "%.")