' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim dividend1 As BigInteger = BigInteger.Pow(Int64.MaxValue, 3)
      Dim dividend2 As BigInteger = dividend1 * BigInteger.MinusOne
      Dim divisor1 As BigInteger = Int32.MaxValue
      Dim divisor2 As BigInteger = divisor1 * BigInteger.MinusOne
      Dim remainder1, remainder2 As BigInteger
      Dim divRem1 As BigInteger = BigInteger.Zero
      Dim divRem2 As BigInteger = BigInteger.Zero
       
      remainder1 = BigInteger.Remainder(dividend1, divisor1)
      remainder2 = BigInteger.Remainder(dividend2, divisor1)

      BigInteger.DivRem(dividend1, divisor1, divRem1)
      Console.WriteLine("BigInteger.Remainder({0}, {1}) = {2}", 
                        dividend1, divisor1, remainder1)
      Console.WriteLine("BigInteger.DivRem({0}, {1}) = {2}", 
                        dividend1, divisor1, divRem1)                    
      If remainder1.Equals(divRem1) Then Console.WriteLine("The remainders are equal.")
      Console.WriteLine()
      
      BigInteger.DivRem(dividend2, divisor2, divRem2)
      Console.WriteLine("BigInteger.Remainder({0}, {1}) = {2}", 
                        dividend2, divisor2, remainder2)
      Console.WriteLine("BigInteger.DivRem({0}, {1}) = {2}", 
                        dividend2, divisor2, divRem2)                    
      If remainder2.Equals(divRem2) Then Console.WriteLine("The remainders are equal.")
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'    BigInteger.Remainder(7.8463771692333509522426190271E+56, 2147483647) = 1
'    BigInteger.DivRem(7.8463771692333509522426190271E+56, 2147483647) = 1
'    The remainders are equal.
'    
'    BigInteger.Remainder(-7.8463771692333509522426190271E+56, -2147483647) = -1
'    BigInteger.DivRem(-7.8463771692333509522426190271E+56, -2147483647) = -1
'    The remainders are equal.
' </Snippet1>
