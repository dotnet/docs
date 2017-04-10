' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections
Imports System.Collections.Generic

Public Class YardsGained(Of T1, T2, T3, T4, T5) : Implements IComparer
   Public Function Compare(x As Object, y As Object) As Integer _
                   Implements IComparer.Compare
      Dim tX As Tuple(Of T1, T2, T3, T4, T5) = TryCast(x, Tuple(Of T1, T2, T3, T4, T5))
      If tX Is Nothing Then
         Return 0
      Else
         Dim tY As Tuple(Of T1, T2, T3, T4, T5) = DirectCast(y, Tuple(Of T1, T2, T3, T4, T5))
         Return -1 * Comparer(Of T4).Default.Compare(tx.Item4, tY.Item4)             
      End If
   End Function
End Class

Module Example
   Public Sub Main()
      ' Organization of runningBacks 5-tuple:
      '    Component 1: Player name
      '    Component 2: Number of games played
      '    Component 3: Number of attempts (carries)
      '    Component 4: Number of yards gained 
      '    Component 5: Number of touchdowns   
      Dim runningBacks() =
          { Tuple.Create("Payton, Walter", 190, 3838, 16726, 110),  
            Tuple.Create("Sanders, Barry", 153, 3062, 15269, 99),            
            Tuple.Create("Brown, Jim", 118, 2359, 12312, 106),            
            Tuple.Create("Dickerson, Eric", 144, 2996, 13259, 90),            
            Tuple.Create("Faulk, Marshall", 176, 2836, 12279, 100) } 

      ' Display the array in unsorted order.
      Console.WriteLine("The values in unsorted order:")
      For Each runningBack In runningBacks
         Console.WriteLine(runningBack.ToString())
      Next
      Console.WriteLine()
      
      ' Sort the array
      Array.Sort(runningBacks, New YardsGained(Of String, Integer, Integer, Integer, Integer)())
      
      ' Display the array in sorted order.
      Console.WriteLine("The values in sorted order:")
      For Each runningBack In runningBacks
         Console.WriteLine(runningBack.ToString())
      Next
   End Sub
End Module
' The example displays the following output:
'       The values in unsorted order:
'       (Payton, Walter, 190, 3838, 16726, 110)
'       (Sanders, Barry, 153, 3062, 15269, 99)
'       (Brown, Jim, 118, 2359, 12312, 106)
'       (Dickerson, Eric, 144, 2996, 13259, 90)
'       (Faulk, Marshall, 176, 2836, 12279, 100)
'       
'       The values in sorted order:
'       (Payton, Walter, 190, 3838, 16726, 110)
'       (Sanders, Barry, 153, 3062, 15269, 99)
'       (Dickerson, Eric, 144, 2996, 13259, 90)
'       (Brown, Jim, 118, 2359, 12312, 106)
'       (Faulk, Marshall, 176, 2836, 12279, 100)
' </Snippet2>
