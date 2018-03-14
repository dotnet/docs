' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim scores() = 
                      { Tuple.Create("Jack", 78.8, 8),
                        Tuple.Create("Abbey", 92.1, 9), 
                        Tuple.Create("Dave", 88.3, 9),
                        Tuple.Create("Sam", 91.7, 8), 
                        Tuple.Create("Ed", 71.2, 5),
                        Tuple.Create("Penelope", 82.9, 8),
                        Tuple.Create("Linda", 99.0, 9),
                        Tuple.Create("Judith", 84.3, 9) }
      Dim result = ComputeStatistics(scores)
      Console.WriteLine("Mean score: {0:N2} (SD={1:N2}) (n={2})", 
                        result.Item2, result.Item3, result.Item1)
   End Sub
   
   Private Function ComputeStatistics(scores() As Tuple(Of String, Double, Integer)) _ 
                                As Tuple(Of Integer, Double, Double)
      Dim n As Integer = 0      
      Dim sum As Double = 0
      
      ' Compute the mean.
      For Each score In scores
         n+= score.Item3 
         sum += score.Item2 * score.Item3
      Next     
      Dim mean As Double = sum / n

      ' Compute the standard deviation.
      Dim ss As Double = 0
      For Each score In scores
         ss = Math.Pow(score.Item2 - mean, 2)
      Next
      Dim sd As Double = Math.Sqrt(ss/scores.Length)
      Return Tuple.Create(scores.Length, mean, sd)
   End Function
End Module
' The example displays the following output:
'       Mean score: 87.02 (SD=0.96) (n=8)
' </Snippet1>
