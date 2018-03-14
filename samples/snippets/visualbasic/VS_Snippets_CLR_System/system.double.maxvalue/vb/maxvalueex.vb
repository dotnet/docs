' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim result1 As Double = 7.997e307 + 9.985e307
      Console.WriteLine("{0} (Positive Infinity: {1})", 
                        result1, Double.IsPositiveInfinity(result1))
      
      Dim result2 As Double = 1.5935e250 * 7.948e110
      Console.WriteLine("{0} (Positive Infinity: {1})", 
                        result2, Double.IsPositiveInfinity(result2))
      
      Dim result3 As Double = Math.Pow(1.256e100, 1.34e20)
      Console.WriteLine("{0} (Positive Infinity: {1})", 
                        result3, Double.IsPositiveInfinity(result3))
   End Sub
End Module
' The example displays the following output:
'    Infinity (Positive Infinity: True)
'    Infinity (Positive Infinity: True)
'    Infinity (Positive Infinity: True)
' </Snippet1>

