' Visual Basic .NET Document
' The example illustrates DivRem(Int32, Int32)
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      ' Define several positive and negative dividends.
      Dim dividends() As Long = { Int64.MaxValue, 13952, 0, -14032, _
                                     Int64.MinValue }
      ' Define one positive and one negative divisor.
      Dim divisors() As Long = { 2000, -2000 }
      
      For Each divisor As Long In divisors
         For Each dividend As Long In dividends
            Dim remainder As Long 
            Dim quotient As Long = Math.DivRem(dividend, divisor, remainder)
            Console.WriteLine("{0:N0} \ {1:N0} = {2:N0}, remainder {3:N0}", _
                              dividend, divisor, quotient, remainder)
         Next
      Next                                
   End Sub
End Module
' The example displays the following output:
'    9,223,372,036,854,775,807 \ 2,000 = 4,611,686,018,427,387, remainder 1,807
'    13,952 \ 2,000 = 6, remainder 1,952
'    0 \ 2,000 = 0, remainder 0
'    -14,032 \ 2,000 = -7, remainder -32
'    -9,223,372,036,854,775,808 \ 2,000 = -4,611,686,018,427,387, remainder -1,808
'    9,223,372,036,854,775,807 \ -2,000 = -4,611,686,018,427,387, remainder 1,807
'    13,952 \ -2,000 = -6, remainder 1,952
'    0 \ -2,000 = 0, remainder 0
'    -14,032 \ -2,000 = 7, remainder -32
'    -9,223,372,036,854,775,808 \ -2,000 = 4,611,686,018,427,387, remainder -1,808
' </Snippet2>
