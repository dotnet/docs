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

        ' Use the NPV function to calculate the net present value.
        ' Set fixed internal rate.
        Dim FixedRetRate As Double = 0.0625
        ' Calculate net present value.
        Dim NetPVal As Double = NPV(FixedRetRate, values)
        ' Display net present value.
        MsgBox("The net present value of these cash flows is " & 
            Format(NetPVal, MoneyFmt) & ".")