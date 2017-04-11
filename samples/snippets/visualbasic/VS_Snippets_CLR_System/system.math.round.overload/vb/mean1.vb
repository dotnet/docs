' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim values() As Decimal = { 1.15d, 1.25d, 1.35d, 1.45d, 1.55d, 1.65d }
      Dim sum As Decimal
      
      ' Calculate true mean.
      For Each value In values
         sum += value
      Next
      Console.WriteLine("True mean:     {0:N2}", sum/values.Length)
      
      ' Calculate mean with rounding away from zero.
      sum = 0
      For Each value In values
         sum += Math.Round(value, 1, MidpointRounding.AwayFromZero)
      Next
      Console.WriteLine("AwayFromZero:  {0:N2}", sum/values.Length)
      
      ' Calculate mean with rounding to nearest.
      sum = 0
      For Each value In values
         sum += Math.Round(value, 1, MidpointRounding.ToEven)
      Next
      Console.WriteLine("ToEven:        {0:N2}", sum/values.Length)
   End Sub
End Module
' The example displays the following output:
'       True mean:     1.40
'       AwayFromZero:  1.45
'       ToEven:        1.40
' </Snippet2>
