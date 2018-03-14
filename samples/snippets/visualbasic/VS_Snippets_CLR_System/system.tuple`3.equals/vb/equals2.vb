' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections

Public Class Item2Comparer(Of T1, T2, T3) : Implements IEqualityComparer
   
   Public Overloads Function Equals(x As Object, y As Object) As Boolean _
                   Implements IEqualityComparer.Equals
      ' Return true for all values of Item1.
      If TypeOf x Is T1 Then
         Return True
      ElseIf TypeOf x Is T2 Then
         Return x.Equals(y)
      Else
         Return True
      End If
   End Function
   
   Public Overloads Function GetHashCode(obj As Object) As Integer _
                    Implements IEqualityComparer.GetHashCode
      If TypeOf obj Is T1 Then
         Return CType(obj, T1).GetHashCode()
      ElseIf TypeOf obj Is T2 Then
         Return CType(obj, T2).GetHashCode()
      Else	
         Return CType(obj, T3).GetHashCode()
      End If   
   End Function                
End Class

Module Example
   Public Sub Main()
      Dim scores() = 
                { Tuple.Create("Ed", 78.8, 8),
                  Tuple.Create("Abbey", 92.1, 9), 
                  Tuple.Create("Jim", 71.2, 9),
                  Tuple.Create("Sam", 91.7, 8), 
                  Tuple.Create("Sandy", 71.2, 5),
                  Tuple.Create("Penelope", 82.9, 8),
                  Tuple.Create("Serena", 71.2, 9),
                  Tuple.Create("Judith", 84.3, 9) }

      For ctr As Integer = 0 To scores.Length - 1
         Dim score As IStructuralEquatable = scores(ctr)
         For ctr2 As Integer = ctr + 1 To scores.Length - 1
            Console.WriteLine("{0} = {1}: {2}", score, 
                              scores(ctr2), 
                              score.Equals(scores(ctr2), 
                                           new Item2Comparer(Of String, Double, Integer)))
         Next
         Console.WriteLine()
      Next                     
   End Sub
End Module
' The example displays the following output:
'      (Ed, 78.8, 8) = (Abbey, 92.1, 9): False
'      (Ed, 78.8, 8) = (Jim, 71.2, 9): False
'      (Ed, 78.8, 8) = (Sam, 91.7, 8): False
'      (Ed, 78.8, 8) = (Sandy, 71.2, 5): False
'      (Ed, 78.8, 8) = (Penelope, 82.9, 8): False
'      (Ed, 78.8, 8) = (Serena, 71.2, 9): False
'      (Ed, 78.8, 8) = (Judith, 84.3, 9): False
'      
'      (Abbey, 92.1, 9) = (Jim, 71.2, 9): False
'      (Abbey, 92.1, 9) = (Sam, 91.7, 8): False
'      (Abbey, 92.1, 9) = (Sandy, 71.2, 5): False
'      (Abbey, 92.1, 9) = (Penelope, 82.9, 8): False
'      (Abbey, 92.1, 9) = (Serena, 71.2, 9): False
'      (Abbey, 92.1, 9) = (Judith, 84.3, 9): False
'
'      (Jim, 71.2, 9) = (Sam, 91.7, 8): False
'      (Jim, 71.2, 9) = (Sandy, 71.2, 5): True
'      (Jim, 71.2, 9) = (Penelope, 82.9, 8): False
'      (Jim, 71.2, 9) = (Serena, 71.2, 9): True
'      (Jim, 71.2, 9) = (Judith, 84.3, 9): False
'
'      (Sam, 91.7, 8) = (Sandy, 71.2, 5): False
'      (Sam, 91.7, 8) = (Penelope, 82.9, 8): False
'      (Sam, 91.7, 8) = (Serena, 71.2, 9): False
'      (Sam, 91.7, 8) = (Judith, 84.3, 9): False
'
'      (Sandy, 71.2, 5) = (Penelope, 82.9, 8): False
'      (Sandy, 71.2, 5) = (Serena, 71.2, 9): True
'      (Sandy, 71.2, 5) = (Judith, 84.3, 9): False
'
'      (Penelope, 82.9, 8) = (Serena, 71.2, 9): False
'      (Penelope, 82.9, 8) = (Judith, 84.3, 9): False
'
'      (Serena, 71.2, 9) = (Judith, 84.3, 9): False
' </Snippet2>
