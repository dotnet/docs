' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim value As Single = 16.325
      Console.WriteLine("Widening Conversion of {0:R} (type {1}) to {2:R} (type {3}): ", 
                        value, value.GetType().Name, CDbl(value), 
                        CDbl(value).GetType().Name)
      Console.WriteLine(Math.Round(value, 2))
      Console.WriteLine(Math.Round(value, 2, MidpointRounding.AwayFromZero))
      Console.WriteLine()
      
      Dim decValue As Decimal = CDec(value)
      Console.WriteLine("Cast of {0:R} (type {1}) to {2} (type {3}): ", 
                        value, value.GetType().Name, decValue, 
                        decValue.GetType().Name)
      Console.WriteLine(Math.Round(decValue, 2))
      Console.WriteLine(Math.Round(decValue, 2, MidpointRounding.AwayFromZero))
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'    Widening Conversion of 16.325 (type Single) to 16.325000762939453 (type Double):
'    16.33
'    16.33
'    
'    Cast of 16.325 (type Single) to 16.325 (type Decimal):
'    16.32
'    16.33
' </Snippet1>
