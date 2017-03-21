            ' Compute the next binomial coefficient.  
            ' If an exception is thrown, quit.
            Dim result As Decimal = CalcBinomial(possibilities, iter)
            If result = 0 Then Return

            ' Format the trace and console output.
            Dim binomial As String = String.Format( _
                    "Binomial( {0}, {1} ) = ", possibilities, iter)
            defaultListener.Write(binomial)
            defaultListener.WriteLine(result.ToString)
            Console.WriteLine("{0} {1}", binomial, result)