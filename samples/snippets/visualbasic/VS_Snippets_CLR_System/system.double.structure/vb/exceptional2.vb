' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim value1 As Double = 4.565e153
      Dim value2 As Double = 6.9375e172
      Dim result As Double = value1 * value2
      Console.WriteLine("PositiveInfinity: {0}", 
                         Double.IsPositiveInfinity(result))
      Console.WriteLine("NegativeInfinity: {0}", 
                        Double.IsNegativeInfinity(result))
      Console.WriteLine()                  
      value1 = -value1
      result = value1 * value2
      Console.WriteLine("PositiveInfinity: {0}", 
                         Double.IsPositiveInfinity(result))
      Console.WriteLine("NegativeInfinity: {0}", 
                        Double.IsNegativeInfinity(result))
   End Sub
End Module
' The example displays the following output:
'       PositiveInfinity: True
'       NegativeInfinity: False
'       
'       PositiveInfinity: False
'       NegativeInfinity: True
' </Snippet2>
