' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim number1 As BigInteger = BigInteger.Pow(Int64.MaxValue, 100)
      Dim number2 As BigInteger = number1 + 1
      Dim relation As String = ""
      Select Case BigInteger.Compare(number1, number2)
         Case -1
            relation = "<"
         Case 0
            relation = "="
         Case 1
            relation = ">"
      End Select            
      Console.WriteLine("{0} {1} {2}", number1, relation, number2)
      ' The example displays the following output:
      '    3.0829940252776347122742186219E+1896 < 3.0829940252776347122742186219E+1896
      ' </Snippet1>
   End Sub
End Module

