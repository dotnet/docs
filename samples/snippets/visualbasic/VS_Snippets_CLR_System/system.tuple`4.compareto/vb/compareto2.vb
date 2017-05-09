' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections
Imports System.Collections.Generic

Public Class PitcherComparer(Of T1, T2, T3, T4) : Implements IComparer
   Public Function Compare(x As Object, y As Object) As Integer _
                   Implements IComparer.Compare
      Dim tX As Tuple(Of T1, T2, T3) = TryCast(x, Tuple(Of T1, T2, T3))
      If tX Is Nothing Then
         Return 0
      Else
         Dim tY As Tuple(Of T1, T2, T3) = DirectCast(y, Tuple(Of T1, T2, T3))
         Return Comparer(Of T3).Default.Compare(tx.Item3, tY.Item3)             
      End If
   End Function
End Class

Module Example
   Public Sub Main()
      Dim pitchers() = 
                { Tuple.Create("McHale, Joe", 240.1, 3.60, 221),
                  Tuple.Create("Paul, Dave", 233.1, 3.24, 231), 
                  Tuple.Create("Williams, Mike", 193.2, 4.00, 183),
                  Tuple.Create("Blair, Jack", 168.1, 3.48, 146), 
                  Tuple.Create("Henry, Walt", 140.1, 1.92, 96),
                  Tuple.Create("Lee, Adam", 137.2, 2.94, 109),
                  Tuple.Create("Rohr, Don", 101.0, 3.74, 110) }

      Console.WriteLine("The values in unsorted order:")
      For Each pitcher In pitchers
         Console.WriteLine(pitcher.ToString())
      Next
      Console.WriteLine()

      Array.Sort(pitchers, New PitcherComparer(Of String, Double, Double, Integer)())

      Console.WriteLine("The values sorted by earned run average (component 3):")
      For Each pitcher In pitchers
         Console.WriteLine(pitcher.ToString())
      Next
   End Sub
End Module
' The example displays the following output;
'       The values in unsorted order:
'       (McHale, Joe, 240.1, 3.6, 221)
'       (Paul, Dave, 233.1, 3.24, 231)
'       (Williams, Mike, 193.2, 4, 183)
'       (Blair, Jack, 168.1, 3.48, 146)
'       (Henry, Walt, 140.1, 1.92, 96)
'       (Lee, Adam, 137.2, 2.94, 109)
'       (Rohr, Don, 101, 3.74, 110)
'       
'       The values sorted by earned run average (component 3):
'       (Henry, Walt, 140.1, 1.92, 96)
'       (Lee, Adam, 137.2, 2.94, 109)
'       (Rohr, Don, 101, 3.74, 110)
'       (Blair, Jack, 168.1, 3.48, 146)
'       (McHale, Joe, 240.1, 3.6, 221)
'       (Paul, Dave, 233.1, 3.24, 231)
'       (Williams, Mike, 193.2, 4, 183)
' </Snippet2>
