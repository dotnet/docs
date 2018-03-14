' Visual Basic .NET Document
Option Strict On

' <Snippet1>
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
' </Snippet1>

' <Snippet2>
Module Example
   Public Sub Main()
      Dim star As StarInfo
      Dim stars As New List(Of StarInfo)
      
      star = New StarInfo("Sirius", 8.6d)
      stars.Add(star)
      star = New StarInfo("Rigel", 1400d)
      stars.Add(star)
      star = New StarInfo("Castor", 49d)
      stars.Add(star)
      star = New StarInfo("Antares", 520d)
      stars.Add(star)
      
      stars.Sort()
      
      For Each star In stars
         Console.WriteLine(star)
      Next   
   End Sub
End Module
' The example displays the following output:
'       Sirius     (50,568,000,000,000)
'       Castor     (288,120,000,000,000)
'       Antares    (3,057,600,000,000,000)
'       Rigel      (8,232,000,000,000,000)
' </Snippet2>
