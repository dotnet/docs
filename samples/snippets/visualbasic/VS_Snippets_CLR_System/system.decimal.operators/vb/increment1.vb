' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Module Example
   Public Sub Main()
      Dim number As Decimal = 1079.8d
      Console.WriteLine("Original value:    {0:N}", number)
      Console.WriteLine("Incremented value: {0:N}", Decimal.op_Increment(number))
   End Sub
End Module
' The example displays the following output:
'       Original value:    1,079.80
'       Incremented value: 1,080.80
' </Snippet13>
