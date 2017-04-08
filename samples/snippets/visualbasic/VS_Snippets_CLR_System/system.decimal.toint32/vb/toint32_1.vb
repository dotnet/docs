' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As Decimal = { 123d, New Decimal(123000, 0, 0, false, 3), 
                                  123.999d, 4294967295.999d, 4294967296d,
                                  4294967296d, 2147483647.999d, 2147483648d, 
                                  -0.999d, -1d, -2147483648.999d, -2147483649d }

      For Each value In values
         Try
            Dim number As Integer = Decimal.ToInt32(value)
            Console.WriteLine("{0} --> {1}", value, number)       
         Catch e As OverflowException
             Console.WriteLine("{0}: {1}", e.GetType().Name, value)
         End Try   
      Next
   End Sub
End Module
' The example displays the following output:
'       123 --> 123
'       123.000 --> 123
'       123.999 --> 123
'       OverflowException: 4294967295.999
'       OverflowException: 4294967296
'       OverflowException: 4294967296
'       2147483647.999 --> 2147483647
'       OverflowException: 2147483648
'       -0.999 --> 0
'       -1 --> -1
'       -2147483648.999 --> -2147483648
'       OverflowException: -2147483649
' 
' </Snippet1>
