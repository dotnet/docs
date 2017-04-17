' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim result1 As Single = -8.997e37 + -2.985e38
      Console.WriteLine("{0} (Negative Infinity: {1})", 
                        result1, Single.IsNegativeInfinity(result1))
      
      Dim result2 As Single = -1.5935e250 * 7.948e110
      Console.WriteLine("{0} (Negative Infinity: {1})", 
                        result2, Single.IsNegativeInfinity(result2))
   End Sub
End Module
' The example displays the following output:
'    -Infinity (Negative Infinity: True)
'    -Infinity (Negative Infinity: True)
' </Snippet1>


