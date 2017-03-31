' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module modMain
   Public Sub Main()
      Multiply()
   End Sub
   
   Private Sub Multiply()
      ' <Snippet1>
      ' The statement
      '    Dim number As BigInteger = Int64.MaxValue * 3
      ' produces compiler error BC30439: Constant expression not representable in type 'Long'.
      ' The alternative:
      Dim number As BigInteger = BigInteger.Multiply(Int64.MaxValue, 3)
      ' </Snippet1>
   End Sub
   
   Private Sub Add()
      ' <Snippet2>
      ' The statement
      '    Dim number As BigInteger = Int64.MaxValue + Int32.MaxValue
      ' produces compiler error BC30439: Constant expression not representable in type 'Long'.
      ' The alternative:
      Dim number As BigInteger = BigInteger.Add(Int64.MaxValue, Int32.MaxValue)
      ' </Snippet2>
   End Sub
   
   Private Sub Subtract()
      ' <Snippet3>
      ' The statement
      '    Dim number As BigInteger = Int64.MinValue - Int64.MaxValue
      ' produces compiler error BC30439: Constant expression not representable in type 'Long'.
      ' The alternative:
      Dim number As BigInteger = BigInteger.Subtract(Int64.MinValue, Int64.MaxValue)
      ' </Snippet3>
   End Sub 
   
   Private Sub Negate()
      ' <Snippet4>
      ' The statement
      '    Dim number As BigInteger = -Int64.MinValue
      ' produces compiler error BC30439: Constant expression not representable in type 'Long'.
      ' The alternative:
      Dim number As BigInteger = BigInteger.Negate(Int64.MinValue)
      ' </Snippet4>
   End Sub  
End Module

