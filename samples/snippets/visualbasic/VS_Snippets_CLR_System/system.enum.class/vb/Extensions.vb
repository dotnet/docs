'<snippet18>
Imports System.Runtime.CompilerServices

' Define an enumeration to represent student grades.
Public Enum Grades As Integer
   F = 0
   D = 1
   C = 2
   B = 3
   A = 4
End Enum   

' Define an extension method for the Grades enumeration.
Public Module Extensions
  Public minPassing As Grades = Grades.D
 
  <Extension>
  Public Function Passing(grade As Grades) As Boolean
     Return grade >= minPassing
  End Function
End Module

Public Module Example
  Public Sub Main()
      Dim g1 As Grades = Grades.D
      Dim g2 As Grades = Grades.F
      Console.WriteLine("{0} {1} a passing grade.", 
                        g1, If(g1.Passing(), "is", "is not"))
      Console.WriteLine("{0} {1} a passing grade.", 
                        g2, If(g2.Passing(), "is", "is not"))
      Console.WriteLine()
      
      Extensions.minPassing = Grades.C
      Console.WriteLine("Raising the bar!")
      Console.WriteLine()
      Console.WriteLine("{0} {1} a passing grade.", 
                        g1, If(g1.Passing(), "is", "is not"))
      Console.WriteLine("{0} {1} a passing grade.", 
                        g2, If(g2.Passing(), "is", "is not"))
  End Sub
End Module
' The exmaple displays the following output:
'       D is a passing grade.
'       F is not a passing grade.
'       
'       Raising the bar!
'       
'       D is not a passing grade.
'       F is not a passing grade.
'</snippet18>


