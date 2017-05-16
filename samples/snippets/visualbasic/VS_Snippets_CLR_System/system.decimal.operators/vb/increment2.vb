' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Module Example
   Public Sub Main()
      Dim number As Decimal = 1079.8d
      Console.WriteLine("Original value:    {0:N}", number)
      Console.WriteLine("Incremented value: {0:N}", Decimal.Add(number, 1))
   End Sub
End Module
' The example displays the following output:
'       Original value:    1,079.80
'       Incremented value: 1,080.80
' </Snippet14>
