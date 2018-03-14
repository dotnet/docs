' <Snippet1>
Module Example
    Sub Main( )
        ' Create parallel arrays of Decimals to use as the dividend and divisor.
        Dim dividends() As Decimal = { 79d, 1000d, -1000d, 123d, 1234567800000d,
                                       1234.0123d }
        Dim divisors() As Decimal = { 11d, 7d, 7d, .00123d, 0.12345678d,
                                      1234.5678d }
        
        For ctr As Integer = 0 To dividends.Length - 1
           Dim dividend As Decimal = dividends(ctr)
           Dim divisor As Decimal = divisors(ctr)
           Console.WriteLine("{0:N3} / {1:N3} = {2:N3} Remainder {3:N3}", dividend,
                             divisor, Decimal.Divide(dividend, divisor),
                             Decimal.Remainder(dividend, divisor)) 
        Next
    End Sub
End Module 
' The example displays the following output:
'       79.000 / 11.000 = 7.182 Remainder 2.000
'       1,000.000 / 7.000 = 142.857 Remainder 6.000
'       -1,000.000 / 7.000 = -142.857 Remainder -6.000
'       123.000 / 0.001 = 100,000.000 Remainder 0.000
'       1,234,567,800,000.000 / 0.123 = 10,000,000,000,000.000 Remainder 0.000
'       1,234.012 / 1,234.568 = 1.000 Remainder 1,234.012
' </Snippet1>
