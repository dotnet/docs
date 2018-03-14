' Visual Basic .NET Document

' Illustrate rounding error in Math.Round(Double).
Option Strict On
' <Snippet8>
Module Example
   Public Sub Main()
      Dim value As Double = 11.1

      Console.WriteLine("{0,5} {1,20:R}  {2,12} {3,15}\n", 
                        "Value", "Full Precision", "ToEven",
                        "AwayFromZero")
      For ctr As Integer = 0 To 5    
         value = RoundValueAndAdd(value)
      Next
      Console.WriteLine()

      value = 11.5
      RoundValueAndAdd(value)
   End Sub
   
   Private Function RoundValueAndAdd(value As Double) As Double
      Const tolerance As Double = 8e-14
      Console.WriteLine("{0,5:N1} {0,20:R}  {1,12} {2,15}", 
                        value, 
                        RoundApproximate(value, 0, tolerance, MidpointRounding.ToEven),
                        RoundApproximate(value, 0, tolerance, MidpointRounding.AwayFromZero))
      Return value + .1
   End Function   

   Private Function RoundApproximate(dbl As Double, digits As Integer, margin As Double, 
                                     mode As MidpointRounding) As Double
      Dim fraction As Double = dbl * Math.Pow(10, digits)
      Dim value As Double = Math.Truncate(fraction) 
      fraction = fraction - value   
      If fraction = 0 Then Return dbl
      
      Dim tolerance As Double = margin * dbl
      ' Determine whether this is a midpoint value.
      If (fraction >= .5 - tolerance) And (fraction <= .5 + tolerance) Then
         If mode = MidpointRounding.AwayFromZero Then
            Return (value + 1)/Math.Pow(10, digits)
         Else
            If value Mod 2 <> 0 Then
               Return (value + 1)/Math.Pow(10, digits)
            Else
               Return value/Math.Pow(10, digits)
            End If
         End If
      End If
      ' Any remaining fractional value greater than .5 is not a midpoint value.
      If fraction > .5 Then
         Return (value + 1)/Math.Pow(10, digits)
      Else
         return value/Math.Pow(10, digits)
      End If      
   End Function
End Module
' The example displays the following output:
'       Value       Full Precision        ToEven    AwayFromZero
'       
'        11.1                 11.1            11              11
'        11.2                 11.2            11              11
'        11.3   11.299999999999999            11              11
'        11.4   11.399999999999999            11              11
'        11.5   11.499999999999998            12              12
'        11.6   11.599999999999998            12              12
'       
'        11.5                 11.5            12              12
 ' </Snippet8>

