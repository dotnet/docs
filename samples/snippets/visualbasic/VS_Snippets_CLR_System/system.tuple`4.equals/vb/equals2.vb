' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Collections

Public Class Item3And4Comparer(Of T1, T2, T3, T4) : Implements IEqualityComparer
   
   Private argument As Integer = 0
   
   Public Overloads Function Equals(x As Object, y As Object) As Boolean _
                   Implements IEqualityComparer.Equals
      argument += 1
      
      ' Return true for all values of Item1, Item2.
      If argument <= 2 Then
         Return True
      Else
         Return x.Equals(y)
      End If
   End Function
   
   Public Overloads Function GetHashCode(obj As Object) As Integer _
                    Implements IEqualityComparer.GetHashCode
      If TypeOf obj Is T1 Then
         Return CType(obj, T1).GetHashCode()
      ElseIf TypeOf obj Is T2 Then
         Return CType(obj, T2).GetHashCode()
      ElseIf TypeOf obj Is T3 Then
         REturn CType(Obj, T3).GetHashCode()
      Else	
         Return CType(obj, T4).GetHashCode()
      End If
   End Function                
End Class

Module Example
   Public Sub Main()
      Dim temperatures() = 
              { Tuple.Create("New York, NY", 4, 61, 43), _
                Tuple.Create("Chicago, IL", 2, 34, 18), _ 
                Tuple.Create("Newark, NJ", 4, 61, 43), _
                Tuple.Create("Boston, MA", 6, 77, 59), _
                Tuple.Create("Detroit, MI", 9, 74, 53), _
                Tuple.Create("Minneapolis, MN", 8, 81, 61) } 
      ' Compare each item with every other item for equality.
      For ctr As Integer = 0 To temperatures.Length - 1
         Dim temperatureInfo As IStructuralEquatable = temperatures(ctr)
         For ctr2 As Integer = ctr + 1 To temperatures.Length - 1
            Console.WriteLine("{0} = {1}: {2}", 
                              temperatureInfo, temperatures(ctr2), 
                              temperatureInfo.Equals(temperatures(ctr2), 
                                              New Item3And4Comparer(Of String, Integer, Double, Double)))
         Next  
         Console.WriteLine()                                               
      Next
   End Sub
End Module
' The example displays the following output:
'    (New York, NY, 4, 61, 43) = (Chicago, IL, 2, 34, 18): False
'    (New York, NY, 4, 61, 43) = (Newark, NJ, 4, 61, 43): True
'    (New York, NY, 4, 61, 43) = (Boston, MA, 6, 77, 59): False
'    (New York, NY, 4, 61, 43) = (Detroit, MI, 9, 74, 53): False
'    (New York, NY, 4, 61, 43) = (Minneapolis, MN, 8, 81, 61): False
'    
'    (Chicago, IL, 2, 34, 18) = (Newark, NJ, 4, 61, 43): False
'    (Chicago, IL, 2, 34, 18) = (Boston, MA, 6, 77, 59): False
'    (Chicago, IL, 2, 34, 18) = (Detroit, MI, 9, 74, 53): False
'    (Chicago, IL, 2, 34, 18) = (Minneapolis, MN, 8, 81, 61): False
'    
'    (Newark, NJ, 4, 61, 43) = (Boston, MA, 6, 77, 59): False
'    (Newark, NJ, 4, 61, 43) = (Detroit, MI, 9, 74, 53): False
'    (Newark, NJ, 4, 61, 43) = (Minneapolis, MN, 8, 81, 61): False
'    
'    (Boston, MA, 6, 77, 59) = (Detroit, MI, 9, 74, 53): False
'    (Boston, MA, 6, 77, 59) = (Minneapolis, MN, 8, 81, 61): False
'    
'    (Detroit, MI, 9, 74, 53) = (Minneapolis, MN, 8, 81, 61): False
' </Snippet2>
