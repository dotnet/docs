' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim result1 As Single = 1.867e38 + 2.385e38
      Console.WriteLine("{0} (Positive Infinity: {1})", 
                        result1, Single.IsPositiveInfinity(result1))
      
      Dim result2 As Single = 1.5935e25 * 7.948e20
      Console.WriteLine("{0} (Positive Infinity: {1})", 
                        result2, Single.IsPositiveInfinity(result2))
   End Sub
End Module
' The example displays the following output:
'    Infinity (Positive Infinity: True)
'    Infinity (Positive Infinity: True)
' </Snippet1>

