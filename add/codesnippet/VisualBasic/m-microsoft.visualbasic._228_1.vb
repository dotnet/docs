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

        ' Use the IRR function to calculate the rate of return.
        ' Guess starts at 10 percent.
        Dim Guess As Double = 0.1
        ' Calculate internal rate.
        Dim CalcRetRate As Double = IRR(values, Guess) * 100
        ' Display internal return rate.
        MsgBox("The internal rate of return for these cash flows is " & 
            Format(CalcRetRate, CStr(PercentFmt)) & " percent.")