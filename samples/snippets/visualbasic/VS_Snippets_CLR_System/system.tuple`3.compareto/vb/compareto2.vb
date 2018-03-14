' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Collections
Imports System.Collections.Generic

Public Class ScoreComparer(Of T1, T2, T3) : Implements IComparer
   Public Function Compare(x As Object, y As Object) As Integer _
                   Implements IComparer.Compare
      Dim tX As Tuple(Of T1, T2, T3) = TryCast(x, Tuple(Of T1, T2, T3))
      If tX Is Nothing Then
         Return 0
      Else
         Dim tY As Tuple(Of T1, T2, T3) = DirectCast(y, Tuple(Of T1, T2, T3))
         Return Comparer(Of T2).Default.Compare(tx.Item2, tY.Item2)             
      End If
   End Function
End Class

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

      Console.WriteLine("The values in unsorted order:")
      For Each score In scores
         Console.WriteLine(score.ToString())
      Next
      Console.WriteLine()

      Array.Sort(scores, New ScoreComparer(Of String, Double, Integer)())

      Console.WriteLine("The values in sorted order:")
      For Each score In scores
         Console.WriteLine(score.ToString())
      Next
   End Sub
End Module
' The example displays the following output;
'       The values in unsorted order:
'       (Jack, 78.8, 8)
'       (Abbey, 92.1, 9)
'       (Dave, 88.3, 9)
'       (Sam, 91.7, 8)
'       (Ed, 71.2, 5)
'       (Penelope, 82.9, 8)
'       (Linda, 99, 9)
'       (Judith, 84.3, 9)
'       
'       The values in sorted order:
'       (Ed, 71.2, 5)
'       (Jack, 78.8, 8)
'       (Penelope, 82.9, 8)
'       (Judith, 84.3, 9)
'       (Dave, 88.3, 9)
'       (Sam, 91.7, 8)
'       (Abbey, 92.1, 9)
'       (Linda, 99, 9)
' </Snippet2>
