' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim frequency(9) As Integer
      Dim number As Double
      Dim rnd As New Random()
      
      For ctr As Integer = 0 To 99
         number = rnd.NextDouble()
         frequency(CInt(Math.Floor(number*10))) += 1
      Next
      Console.WriteLine("Distribution of Random Numbers:")
      For ctr As Integer = frequency.GetLowerBound(0) To frequency.GetUpperBound(0)
         Console.WriteLine("0.{0}0-0.{0}9       {1}", ctr, frequency(ctr))
      Next         
   End Sub
End Module
' The following example displays output similar to the following:
'       Distribution of Random Numbers:
'       0.00-0.09       16
'       0.10-0.19       8
'       0.20-0.29       8
'       0.30-0.39       11
'       0.40-0.49       9
'       0.50-0.59       6
'       0.60-0.69       13
'       0.70-0.79       6
'       0.80-0.89       9
'       0.90-0.99       14
' </Snippet2>