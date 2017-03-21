Imports System.Collections.Generic
Imports System.Numerics

Public Structure StarInfo : Implements IComparable(Of StarInfo)
   ' Define constructors.
   Public Sub New(name As String, lightYears As Double)
      Me.Name = name
      ' Calculate distance in miles from light years.
      Me.Distance = CType(Math.Round(lightYears * 5.88e12), BigInteger)
   End Sub
   
   Public Sub New(name As String, distance As BigInteger)
      Me.Name = name
      Me.Distance = distance
   End Sub
   
   ' Define public fields.
   Public Name As String
   Public Distance As BigInteger

   ' Display name of star and its distance in parentheses.
   Public Overrides Function ToString() As String
      Return String.Format("{0,-10} ({1:N0})", Me.Name, Me.Distance)
   End Function

   ' Compare StarInfo objects by their distance from Earth.
   Public Function CompareTo(other As starInfo) As Integer _
                   Implements IComparable(Of StarInfo).CompareTo
      Return Me.Distance.CompareTo(other.Distance)
   End Function                
End Structure