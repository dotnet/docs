' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim divisor As BigInteger = BigInteger.Pow(Int64.MaxValue, 2)
      
      Dim dividends() As BigInteger = { BigInteger.Multiply(CType(Single.MaxValue, BigInteger), 2), 
                                        BigInteger.Parse("90612345123875509091827560007100099"), 
                                        BigInteger.One, 
                                        BigInteger.Multiply(Int32.MaxValue, Int64.MaxValue),
                                        divisor + BigInteger.One }

      ' Divide each dividend by divisor in three different ways.
      For Each dividend As BigInteger In dividends
         Dim quotient As BigInteger
         Dim remainder As BigInteger = 0
         
         ' Divide using division operator.
         Console.WriteLine("Dividend: {0:N0}", dividend)
         Console.WriteLine("Divisor:  {0:N0}", divisor)
         Console.WriteLine("Results:")
         Console.WriteLine("   Using Divide method:     {0:N0}", 
                           BigInteger.Divide(dividend, divisor))
         Console.WriteLine("   Using Division operator: {0:N0}", 
                           dividend / divisor)
         quotient = BigInteger.DivRem(dividend, divisor, remainder)
         Console.WriteLine("   Using DivRem method:     {0:N0}, remainder {1:N0}", 
                           quotient, remainder)
         
         Console.WriteLine()         
      Next                                        
   End Sub
End Module
' The example displays the following output:
'    Dividend: 680,564,693,277,057,719,623,408,366,969,033,850,880
'    Divisor:  85,070,591,730,234,615,847,396,907,784,232,501,249
'    Results:
'       Using Divide method:     7
'       Using Division operator: 7
'       Using DivRem method:     7, remainder 85,070,551,165,415,408,691,630,012,479,406,342,137
'    
'    Dividend: 90,612,345,123,875,509,091,827,560,007,100,099
'    Divisor:  85,070,591,730,234,615,847,396,907,784,232,501,249
'    Results:
'       Using Divide method:     0
'       Using Division operator: 0
'       Using DivRem method:     0, remainder 90,612,345,123,875,509,091,827,560,007,100,099
'    
'    Dividend: 1
'    Divisor:  85,070,591,730,234,615,847,396,907,784,232,501,249
'    Results:
'       Using Divide method:     0
'       Using Division operator: 0
'       Using DivRem method:     0, remainder 1
'    
'    Dividend: 19,807,040,619,342,712,359,383,728,129
'    Divisor:  85,070,591,730,234,615,847,396,907,784,232,501,249
'    Results:
'       Using Divide method:     0
'       Using Division operator: 0
'       Using DivRem method:     0, remainder 19,807,040,619,342,712,359,383,728,129
'    
'    Dividend: 85,070,591,730,234,615,847,396,907,784,232,501,250
'    Divisor:  85,070,591,730,234,615,847,396,907,784,232,501,249
'    Results:
'       Using Divide method:     1
'       Using Division operator: 1
'       Using DivRem method:     1, remainder 1
' </Snippet1>
