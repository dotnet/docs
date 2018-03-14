' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Collections
Imports System.Collections.Generic

Public Class PopulationComparer(Of T1, T2, T3, T4, T5, T6) : Implements IComparer
   Private itemPosition As Integer
   Private multiplier As Integer = -1
      
   Public Sub New(component As Integer)
      Me.New(component, True)
   End Sub
   
   Public Sub New(component As Integer, descending As Boolean)
      If Not descending Then multiplier = 1
      
      If component <= 0 Or component > 6 Then 
         Throw New ArgumentException("The component argument is out of range.")
      End If
      itemPosition = component
   End Sub 
   
   Public Function Compare(x As Object, y As Object) As Integer _
                   Implements IComparer.Compare
 
      Dim tX = TryCast(x, Tuple(Of T1, T2, T3, T4, T5, T6))
      If tX Is Nothing Then
         Return 0
      Else
         Dim tY = DirectCast(y, Tuple(Of T1, T2, T3, T4, T5, T6))
         Select Case itemPosition
            Case 1
               Return Comparer(Of T1).Default.Compare(tX.Item1, tY.Item1) * multiplier
            Case 2
               Return Comparer(Of T2).Default.Compare(tX.Item2, tY.Item2) * multiplier
            Case 3
               Return Comparer(Of T3).Default.Compare(tX.Item3, tY.Item3) * multiplier
            Case 4
               Return Comparer(Of T4).Default.Compare(tX.Item4, tY.Item4) * multiplier
            Case 5
               Return Comparer(Of T5).Default.Compare(tX.Item5, tY.Item5) * multiplier
            Case 6
               Return Comparer(Of T6).Default.Compare(tX.Item6, tY.Item6) * multiplier
            ' This should never happen.
            Case Else
               Return 0
         End Select      
      End If
   End Function
End Class

Module Example
   Public Sub Main()
      ' Create array of sextuple with population data for three U.S. 
      ' cities, 1960-2000.
      Dim cities() = 
          { Tuple.Create("Los Angeles", 2479015, 2816061, 2966850, 3485398, 3694820),
            Tuple.Create("New York", 7781984, 7894862, 7071639, 7322564, 8008278),  
            Tuple.Create("Chicago", 3550904, 3366957, 3005072, 2783726, 2896016) } 
      
      ' Display array in unsorted order.
      Console.WriteLine("In unsorted order:")
      For Each city In cities
         Console.WriteLine(city.ToString())
      Next
      Console.WriteLine()
      
      Array.Sort(cities, New PopulationComparer(Of String, Integer, Integer, Integer, Integer, Integer)(3)) 
                           
      ' Display array in sorted order.
      Console.WriteLine("Sorted by population in 1970:")
      For Each city In cities
         Console.WriteLine(city.ToString())
      Next
      Console.WriteLine()
      
      Array.Sort(cities, New PopulationComparer(Of String, Integer, Integer, Integer, Integer, Integer)(6))
                           
      ' Display array in sorted order.
      Console.WriteLine("Sorted by population in 2000:")
      For Each city In cities
         Console.WriteLine(city.ToString())
      Next
   End Sub
End Module
' The example displays the following output:
'    In unsorted order:
'    (Los Angeles, 2479015, 2816061, 2966850, 3485398, 3694820)
'    (New York, 7781984, 7894862, 7071639, 7322564, 8008278)
'    (Chicago, 3550904, 3366957, 3005072, 2783726, 2896016)
'    
'    Sorted by population in 1970:
'    (New York, 7781984, 7894862, 7071639, 7322564, 8008278)
'    (Chicago, 3550904, 3366957, 3005072, 2783726, 2896016)
'    (Los Angeles, 2479015, 2816061, 2966850, 3485398, 3694820)
'    
'    Sorted by population in 2000:
'    (New York, 7781984, 7894862, 7071639, 7322564, 8008278)
'    (Los Angeles, 2479015, 2816061, 2966850, 3485398, 3694820)
'    (Chicago, 3550904, 3366957, 3005072, 2783726, 2896016)
' </Snippet2>
