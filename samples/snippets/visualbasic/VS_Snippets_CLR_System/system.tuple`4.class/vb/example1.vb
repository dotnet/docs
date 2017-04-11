' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim pitchers() =  
               { Tuple.Create("McHale, Joe", 240.1d, 221, 96),
                 Tuple.Create("Paul, Dave", 233.1d, 231, 84), 
                 Tuple.Create("Williams, Mike", 193.2d, 183, 86),
                 Tuple.Create("Blair, Jack", 168.1d, 146, 65), 
                 Tuple.Create("Henry, Walt", 140.1d, 96, 30),
                 Tuple.Create("Lee, Adam", 137.2d, 109, 45),
                 Tuple.Create("Rohr, Don", 101.0d, 110, 42) }
      Dim results() = ComputeStatistics(pitchers)

      ' Display the results.
      Console.WriteLine("{0,-20} {1,9} {2,11} {3,15}", "Pitcher", "ERA", "Hits/Inn.", "Effectiveness")
      Console.WriteLine()
      For Each result In results
         Console.WriteLine("{0,-20} {1,9:F2} {2,11:F2} {3,15:F2}",  
                        result.Item1, result.Item2, result.Item3, result.Item4)
      Next
   End Sub
   
   Private Function ComputeStatistics(pitchers() As Tuple(Of String, Decimal, Integer, Integer)) _ 
                                As Tuple(Of String, Double, Double, Double)()
      Dim list As New List(Of Tuple(Of String, Double, Double, Double))
      Dim result As Tuple(Of String, Double, Double, Double)

      For Each pitcher As Tuple(Of String, Decimal, Integer, Integer) In pitchers
         ' Decimal portion of innings pitched represents 1/3 of an inning
         Dim innings As Double = CDbl(Math.Truncate(pitcher.Item2))
         innings = innings + ((pitcher.Item2 - innings) * .33)
         
         Dim ERA As Double = pitcher.Item4/innings * 9
         Dim hitsPerInning As Double = pitcher.Item3/innings
         Dim EI As Double = (ERA * 2 + hitsPerInning * 9)/3
         result = New Tuple(Of String, Double, Double, Double) _
                           (pitcher.Item1, ERA, hitsPerInning, EI)
         list.Add(result) 
      Next
      Return list.ToArray()
   End Function
End Module
' The example displays the following output:
'       Pitcher                    ERA   Hits/Inn.   Effectiveness
'       
'       McHale, Joe               3.60        0.92            5.16
'       Paul, Dave                3.24        0.99            5.14
'       Williams, Mike            4.01        0.95            5.52
'       Blair, Jack               3.48        0.87            4.93
'       Henry, Walt               1.93        0.69            3.34
'       Lee, Adam                 2.95        0.80            4.36
'       Rohr, Don                 3.74        1.09            5.76
' </Snippet1>
