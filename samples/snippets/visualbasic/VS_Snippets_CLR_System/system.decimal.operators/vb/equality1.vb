' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim number1 As Decimal = 16354.0695d
      Dim number2 As Decimal = 16354.0699d
      Console.WriteLine("{0} = {1}: {2}", number1, 
                        number2, number1 = number2)

      number1 = Decimal.Round(number1, 2)
      number2 = Decimal.Round(number2, 2)
      Console.WriteLine("{0} = {1}: {2}", number1, 
                        number2, number1 = number2)
   End Sub
End Module
' The example displays the following output:
'       16354.0695 = 16354.0699: False
'       16354.07 = 16354.07: True
' </Snippet1>
