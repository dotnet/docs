' Visual Basic .NET Document
' The example illustrates DivRem(Int32, Int32)
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Define several positive and negative dividends.
      Dim dividends() As Integer = { Int32.MaxValue, 13952, 0, -14032, _
                                     Int32.MinValue }
      ' Define one positive and one negative divisor.
      Dim divisors() As Integer = { 2000, -2000 }
      
      For Each divisor As Integer In divisors
         For Each dividend As Integer In dividends
            Dim remainder As Integer 
            Dim quotient As Integer = Math.DivRem(dividend, divisor, remainder)
            Console.WriteLine("{0:N0} \ {1:N0} = {2:N0}, remainder {3:N0}", _
                              dividend, divisor, quotient, remainder)
         Next
      Next                                
   End Sub
End Module
' The example displays the following output:
'       2,147,483,647 \ 2,000 = 1,073,741, remainder 1,647
'       13,952 \ 2,000 = 6, remainder 1,952
'       0 \ 2,000 = 0, remainder 0
'       -14,032 \ 2,000 = -7, remainder -32
'       -2,147,483,648 \ 2,000 = -1,073,741, remainder -1,648
'       2,147,483,647 \ -2,000 = -1,073,741, remainder 1,647
'       13,952 \ -2,000 = -6, remainder 1,952
'       0 \ -2,000 = 0, remainder 0
'       -14,032 \ -2,000 = 7, remainder -32
'       -2,147,483,648 \ -2,000 = 1,073,741, remainder -1,648
' </Snippet1>
