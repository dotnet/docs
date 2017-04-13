' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Collections
Imports System.Collections.Generic

Public Class ScoreComparer(Of T1, T2) : Implements IComparer
   Public Function Compare(x As Object, y As Object) As Integer _
                   Implements IComparer.Compare
      Dim tX As Tuple(Of T1, T2) = TryCast(x, Tuple(Of T1, T2))
      If tX Is Nothing Then
         Return 0
      Else
         Dim tY As Tuple(Of T1, T2) = DirectCast(y, Tuple(Of T1, T2))
         Return Comparer(Of T2).Default.Compare(tx.Item2, tY.Item2)             
      End If
   End Function
End Class

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

      Console.WriteLine("The values in unsorted order:")
      For Each score In scores
         Console.WriteLine(score.ToString())
      Next
      Console.WriteLine()

      Array.Sort(scores, New ScoreComparer(Of String, Nullable(Of Integer))())

      Console.WriteLine("The values in sorted order:")
      For Each score In scores
         Console.WriteLine(score.ToString())
      Next
   End Sub
End Module
' The example displays the following output;
'       The values in unsorted order:
'       (Jack, 78)
'       (Abbey, 92)
'       (Dave, 88)
'       (Sam, 91)
'       (Ed, )
'       (Penelope, 82)
'       (Linda, 99)
'       (Judith, 84)
'       
'       The values in sorted order:
'       (Ed, )
'       (Jack, 78)
'       (Penelope, 82)
'       (Judith, 84)
'       (Dave, 88)
'       (Sam, 91)
'       (Abbey, 92)
'       (Linda, 99)
' </Snippet2>
