Module Module1

    Sub Main()
        ' Two interest rates are declared, one a constant and one a 
        ' variable.
        Const highRate As Double = 12.5
        Dim lowRate = highRate * 0.6

        Dim initialDebt = 4999.99
        ' Make a copy of the original value of the debt.
        Dim debtWithInterest = initialDebt

        ' Calculate the total debt with the high interest rate applied.
        ' Argument highRate is a constant, which is appropriate for a 
        ' ByVal parameter. Argument debtWithInterest must be a variable
        ' because the procedure will change its value to the calculated
        ' total with interest applied.
        Calculate(highRate, debtWithInterest)
        ' Format the result to represent currency, and display it.
        Dim debtString = Format(debtWithInterest, "C")
        Console.WriteLine("What I owe with high interest: " & debtString)

        ' Repeat the process with lowRate. Argument lowRate is not a 
        ' constant, but the ByVal parameter protects it from accidental
        ' or intentional change by the procedure. 

        ' Set debtWithInterest back to the original value.
        debtWithInterest = initialDebt
        Calculate(lowRate, debtWithInterest)
        debtString = Format(debtWithInterest, "C")
        Console.WriteLine("What I owe with low interest:  " & debtString)
    End Sub

    ' Parameter rate is a ByVal parameter because the procedure should
    ' not change the value of the corresponding argument in the 
    ' calling code. 

    ' The calculated value of the debt parameter, however, should be
    ' reflected in the value of the corresponding argument in the 
    ' calling code. Therefore, it must be declared ByRef. 
    Sub Calculate(ByVal rate As Double, ByRef debt As Double)
        debt = debt + (debt * rate / 100)
    End Sub

End Module