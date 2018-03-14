' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim scores() As Tuple(Of String, Nullable(Of Integer)) = 
                      { New Tuple(Of String, Nullable(Of Integer))("Jack", 78),
                        New Tuple(Of String, Nullable(Of Integer))("Abbey", 92), 
                        New Tuple(Of String, Nullable(Of Integer))("Dave", 88),
                        New Tuple(Of String, Nullable(Of Integer))("Sam", 91), 
                        New Tuple(Of String, Nullable(Of Integer))("Ed", Nothing),
                        New Tuple(Of String, Nullable(Of Integer))("Penelope", 82),
                        New Tuple(Of String, Nullable(Of Integer))("Linda", 99),
                        New Tuple(Of String, Nullable(Of Integer))("Judith", 84) }
      Dim number As Integer
      Dim mean As Double = ComputeMean(scores, number)
      Console.WriteLine("Average test score: {0:N2} (n={1})", mean, number)
   End Sub
   
   Private Function ComputeMean(scores() As Tuple(Of String, Nullable(Of Integer)), 
                                ByRef n As Integer) As Double
      n = 0      
      Dim sum As Integer
      For Each score In scores
         If score.Item2.HasValue Then 
            n += 1
            sum += score.Item2.Value
         End If
      Next     
      If n > 0 Then
         Return sum / n
      Else
         Return 0
      End If             
   End Function
End Module
' The example displays the following output:
'       Average test score: 88 (n=7)
' </Snippet1>
