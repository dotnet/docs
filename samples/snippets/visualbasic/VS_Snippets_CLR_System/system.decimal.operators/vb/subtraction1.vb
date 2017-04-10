' Visual Basic .NET Document
Option Strict On

' <Snippet21>
Module Example
   Public Sub Main()
      Dim number1 As Decimal = 120.07d 
      Dim number2 As Decimal = 163.19d 
      Dim number3 As Decimal = number1 - number2
      Console.WriteLine("{0} - {1} = {2}", 
                        number1, number2, number3)
   End Sub
End Module
' The example displays the following output:
'       120.07 - 163.19 = -43.12
' </Snippet21>
