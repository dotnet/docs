' Visual Basic .NET Document

' Illustrate rounding error in Math.Round(Double).
Option Strict On
' <Snippet4>
Module Example
   Public Sub Main()
      Dim value As Double = 11.1
      For ctr As Integer = 0 To 5    
         value = RoundValueAndAdd(value)
      Next
      Console.WriteLine()

      value = 11.5
      RoundValueAndAdd(value)
   End Sub
   
   Private Function RoundValueAndAdd(value As Double) As Double
      Console.WriteLine("{0} --> {1}", value, Math.Round(value, 
                        MidpointRounding.AwayFromZero))
      Return value + .1
   End Function   
End Module
' The example displays the following output:
'       11.1 --> 11
'       11.2 --> 11
'       11.3 --> 11
'       11.4 --> 11
'       11.5 --> 11
'       11.6 --> 12
'       
'       11.5 --> 12
' </Snippet4>

