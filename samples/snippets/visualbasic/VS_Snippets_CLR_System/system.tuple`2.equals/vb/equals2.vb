' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Collections

Public Class Item2Comparer(Of T1, T2) : Implements IEqualityComparer
   
   Public Overloads Function Equals(x As Object, y As Object) As Boolean _
                   Implements IEqualityComparer.Equals
      ' Return true for all values of Item1.
      If TypeOf x Is T1 Then
         Return True
      Else
         Return x.Equals(y)
      End If
   End Function
   
   Public Overloads Function GetHashCode(obj As Object) As Integer _
                    Implements IEqualityComparer.GetHashCode
      If TypeOf obj Is T1 Then
         Return CType(obj, T1).GetHashCode()
      Else
         Return CType(obj, T2).GetHashCode()
      End If   
   End Function                
End Class

Module Example
   Public Sub Main()
      Dim distancesWalked() = {
                        Tuple.Create("Jan", Double.NaN), 
                        Tuple.Create("Joe", Double.NaN), 
                        Tuple.Create("Adam", 1.36), 
                        Tuple.Create("Selena", 2.01),
                        Tuple.Create("Jake", 1.36) }
      For ctr As Integer = 0 To distancesWalked.Length - 1
         Dim distanceWalked As Tuple(Of String, Double) = distancesWalked(ctr)
         For ctr2 As Integer = ctr + 1 To distancesWalked.Length - 1
            Console.WriteLine("{0} = {1}: {2}", distanceWalked, 
                              distancesWalked(ctr2), 
                              DirectCast(distanceWalked, IStructuralEquatable).Equals(distancesWalked(ctr2), 
                                                    new Item2Comparer(Of String, Double)))
         Next
         Console.WriteLine()
      Next                     
   End Sub
End Module
' The example displays the following output:
'       (Jan, NaN) = (Joe, NaN): True
'       (Jan, NaN) = (Adam, 1.36): False
'       (Jan, NaN) = (Selena, 2.01): False
'       (Jan, NaN) = (Jake, 1.36): False
'       
'       (Joe, NaN) = (Adam, 1.36): False
'       (Joe, NaN) = (Selena, 2.01): False
'       (Joe, NaN) = (Jake, 1.36): False
'       
'       (Adam, 1.36) = (Selena, 2.01): False
'       (Adam, 1.36) = (Jake, 1.36): True
'       
'       (Selena, 2.01) = (Jake, 1.36): False
' </Snippet2>
