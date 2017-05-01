' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      ' <Snippet1>
      Dim floatNumber As Double
      
      floatNumber = 32.7865
      ' Displays 32      
      Console.WriteLine(Math.Truncate(floatNumber)) 
      
      floatNumber = -32.9012
      ' Displays -32
      Console.WriteLine(Math.Truncate(floatNumber))
      ' </Snippet1>
      
      ' <Snippet2>
      Dim decimalNumber As Decimal
      
      decimalNumber = 32.7865d
      ' Displays 32      
      Console.WriteLine(Math.Truncate(decimalNumber))
      
      decimalNumber = -32.9012d
      ' Displays -32
      Console.WriteLine(Math.Truncate(decimalNumber))  
      ' </Snippet2>
   End Sub
End Module

