' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim result1 As Double = -7.997e307 + -9.985e307
      Console.WriteLine("{0} (Negative Infinity: {1})", 
                        result1, Double.IsNegativeInfinity(result1))
      
      Dim result2 As Double = -1.5935e250 * 7.948e110
      Console.WriteLine("{0} (Negative Infinity: {1})", 
                        result2, Double.IsNegativeInfinity(result2))
   End Sub
End Module
' The example displays the following output:
'    -Infinity (Negative Infinity: True)
'    -Infinity (Negative Infinity: True)
' </Snippet1>


