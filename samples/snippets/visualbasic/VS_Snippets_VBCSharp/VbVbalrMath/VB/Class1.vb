Option Explicit On
Option Strict On

' <snippet8>
Imports System.Math
' </snippet8>

' These are the finitial functions.

' NPV Function
Class Class07270518dc58458f8a7e45da3f6d0867

    ' IRR Function
    'Class Class6fdadd351a28404688397610c7f41d58

    ' MIRR Function
    'Class Classf837020ff441423b947ed07c06570fbc


    Sub TestNPV()
        ' <snippet1>
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
        ' </snippet1>
    End Sub

    Sub TestIRR()
        ' <snippet20>
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
        ' </snippet20>
    End Sub

    Sub TestMIRR()
        ' <snippet29>
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
        ' </snippet29>
    End Sub

End Class

' =======================================================

' Rate Function
Class Class159a1783a7c9466ca1b8a1df2906e28e

    ' <snippet2>
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
    ' </snippet2>

End Class

' Pmt Function
Class Class435250666f92427a83251e1b106de1c4

    ' <snippet7>
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
    ' </snippet7>

End Class

' PPmt Function
Class Class9b20cd53c9d649169e840eb84667a921

    ' <snippet24>
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
    ' </snippet24>

End Class

' NPer Function
Class Class56567d1629f74928b05fb4cd56d4fd42

    ' <snippet19>
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
    ' </snippet19>

End Class


' IPmt Function
Class Classc0cce8e3c6614ed5be5270fe6e0e1b28

    ' <snippet26>
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
    ' </snippet26>

End Class

' -------------------
' The next one is somewhat similar.

' FV Function
Class Class88842fc2610a4a83b75977326a168ab0

    ' <snippet22>
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
    ' </snippet22>

End Class

' ====================================================================


' PV Function
Class Classaab6ab0ba0704177a142d25612b6c32f

    ' <snippet25>
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
    ' </snippet25>

End Class

' =====================================================================

' SYD Function
Class Class23c25672f5dd49ac98934faa82634181
    ' SLN Function
    '   Class Class8e06130a056e4266a8a91592b86f58d2
    '   was snippet 23
    ' DDB Function
    '   Class Classc7cf8929d1584399b3cb31d897d12556
    '   was snippet 28

    Sub Snippet3()
        ' <snippet3>
        Dim InitCost, SalvageVal, LifeTime, DepYear As Double
        Dim Fmt As String = "###,##0.00"

        InitCost = CDbl(InputBox("What's the initial cost of the asset?"))
        SalvageVal = CDbl(InputBox("Enter the asset's value at end of its life."))
        LifeTime = CDbl(InputBox("What's the asset's useful life in years?"))

        ' Use the SLN function to calculate the deprecation per year.
        Dim SlnDepr As Double = SLN(InitCost, SalvageVal, LifeTime)
        Dim msg As String = "The depreciation per year: " & Format(SlnDepr, Fmt)
        msg &= vbCrLf & "Year" & vbTab & "Linear" & vbTab & "Doubling" & vbCrLf

        ' Use the SYD and DDB functions to calculate the deprecation for each year.
        For DepYear = 1 To LifeTime
            msg &= DepYear & vbTab & 
                Format(SYD(InitCost, SalvageVal, LifeTime, DepYear), Fmt) & vbTab & 
                Format(DDB(InitCost, SalvageVal, LifeTime, DepYear), Fmt) & vbCrLf
        Next
        MsgBox(msg)
        ' </snippet3>
    End Sub

End Class


' Now for the true math functions

' Rnd Function (Visual Basic)
Class Classf8fbc1222723465a980cc167e5dc027f

    Public Sub Method30()
        Dim upperbound As Integer = 5
        Dim lowerbound As Integer = 2
        Dim randomvalue As Integer

        ' <snippet30>
    randomValue = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        ' </snippet30>
    End Sub

End Class

' Randomize Function (Visual Basic)
Class Class802499dc2ace4611926233ebbd87abc8

    Public Sub Method21()
        ' <snippet21>
        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and 6.
        Dim value As Integer = CInt(Int((6 * Rnd()) + 1))
        ' </snippet21>
    End Sub

End Class

' Int, Fix Functions (Visual Basic)
Class Class2855c7fe20054f9988786c9f070f5af8

    Public Sub Method4()
        ' snippet4 is in Class2, because it needs Option Strict Off
        Dim MyNumber As Integer

        ' <snippet5>
        MyNumber = CInt(99.8)    ' Returns 100.
        MyNumber = CInt(-99.8)   ' Returns -100.
        MyNumber = CInt(-99.2)   ' Returns -99.
        ' </snippet5>

        ' <snippet6>
        MyNumber = CInt(Fix(99.8))   ' Returns 99.
        MyNumber = CInt(Int(99.8))   ' Returns 99.
        ' </snippet6>
    End Sub

End Class

' Math Functions (Visual Basic)
Class Class4d2d82e7692442fea4a7b4dd5bebbd0c

    Public Sub Method9()
        ' <snippet9>
        ' Returns 50.3.
        Dim MyNumber1 As Double = Math.Abs(50.3)
        ' Returns 50.3.
        Dim MyNumber2 As Double = Math.Abs(-50.3)
        ' </snippet9>
    End Sub

    ' <snippet10>
    Public Function GetPi() As Double
        ' Calculate the value of pi.
        Return 4.0 * Math.Atan(1.0)
    End Function
    ' </snippet10>

    ' <snippet11>
    Public Function Sec(ByVal angle As Double) As Double
        ' Calculate the secant of angle, in radians.
        Return 1.0 / Math.Cos(angle)
    End Function
    ' </snippet11>

    ' <snippet12>
    Public Function Sinh(ByVal angle As Double) As Double
        ' Calculate hyperbolic sine of an angle, in radians.
        Return (Math.Exp(angle) - Math.Exp(-angle)) / 2.0
    End Function
    ' </snippet12>

    ' <snippet13>
    Public Function Asinh(ByVal value As Double) As Double
        ' Calculate inverse hyperbolic sine, in radians.
        Return Math.Log(value + Math.Sqrt(value * value + 1.0))
    End Function
    ' </snippet13>

    Public Sub Method14()
        ' <snippet14>
        ' Returns 3.
        Dim MyVar2 As Double = Math.Round(2.8)
        ' </snippet14>
    End Sub

    Public Sub Method15()
        ' <snippet15>
        ' Returns 1.
        Dim MySign1 As Integer = Math.Sign(12)
        ' Returns -1.
        Dim MySign2 As Integer = Math.Sign(-2.4)
        ' Returns 0.
        Dim MySign3 As Integer = Math.Sign(0)
        ' </snippet15>
    End Sub

    ' <snippet16>
    Public Function Csc(ByVal angle As Double) As Double
        ' Calculate cosecant of an angle, in radians.
        Return 1.0 / Math.Sin(angle)
    End Function
    ' </snippet16>

    Public Sub Method17()
        ' <snippet17>
        ' Returns 2.
        Dim MySqr1 As Double = Math.Sqrt(4)
        ' Returns 4.79583152331272.
        Dim MySqr2 As Double = Math.Sqrt(23)
        ' Returns 0.
        Dim MySqr3 As Double = Math.Sqrt(0)
        ' Returns NaN (not a number).
        Dim MySqr4 As Double = Math.Sqrt(-4)
        ' </snippet17>
    End Sub

    ' <snippet18>
    Public Function Ctan(ByVal angle As Double) As Double
        ' Calculate cotangent of an angle, in radians.
        Return 1.0 / Math.Tan(angle)
    End Function
    ' </snippet18>

End Class
