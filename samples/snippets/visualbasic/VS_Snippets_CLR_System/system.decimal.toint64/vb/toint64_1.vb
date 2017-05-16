' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As Decimal = { 123d, New Decimal(123000, 0, 0, false, 3), 
                                  123.999d, 18446744073709551615.999d, 
                                  18446744073709551616d, 9223372036854775807.999d, 
                                  9223372036854775808d, -0.999d, -1d, 
                                  -9223372036854775808.999d, 
                                  -9223372036854775809d }

      For Each value In values
         Try
            Dim number As Long = Decimal.ToInt64(value)
            Console.WriteLine("{0} --> {1}", value, number)       
         Catch e As OverflowException
             Console.WriteLine("{0}: {1}", e.GetType().Name, value)
         End Try   
      Next
   End Sub
End Module
' The example displays the following output:
'   123 --> 123
'   123.000 --> 123
'   123.999 --> 123
'   OverflowException: 18446744073709551615.999
'   OverflowException: 18446744073709551616
'   9223372036854775807.999 --> 9223372036854775807
'   OverflowException: 9223372036854775808
'   -0.999 --> 0
'   -1 --> -1
'   -9223372036854775808.999 --> -9223372036854775808
'   OverflowException: -9223372036854775809
' </Snippet1>
 
