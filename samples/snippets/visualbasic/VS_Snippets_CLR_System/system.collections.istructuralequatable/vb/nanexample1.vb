' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Collections
Imports System.Collections.Generic

Public Class NanComparer : Implements IEqualityComparer
   Public Overloads Function Equals(x As Object, y As Object) As Boolean _
          Implements IEqualityComparer.Equals
      If TypeOf x Is Single Then
         Return CSng(x) = CSng(y)
      ElseIf TypeOf x Is Double Then
         Return CDbl(x) = CDbl(y)
      Else
         Return EqualityComparer(Of Object).Default.Equals(x, y)
      End If
   End Function
   
   Public Overloads Function GetHashCode(obj As Object) As Integer _
          Implements IEqualityComparer.GetHashCode
      Return EqualityComparer(Of Object).Default.GetHashCode(obj)
   End Function
End Class
' </Snippet1>

' <Snippet2>
Module Example
   Public Sub Main()
      Dim t1 = Tuple.Create(12.3, Double.NaN, 16.4)
      Dim t2 = Tuple.Create(12.3, Double.NaN, 16.4)
      
      ' Call default Equals method.
      Console.WriteLine(t1.Equals(t2))
      
      Dim equ As IStructuralEquatable = t1
      ' Call IStructuralEquatable.Equals using default comparer.
      Console.WriteLine(equ.Equals(t2, EqualityComparer(Of Object).Default))
      
      ' Call IStructuralEquatable.Equals using 
      ' StructuralComparisons.StructuralEqualityComparer.
      Console.WriteLine(equ.Equals(t2, 
                        StructuralComparisons.StructuralEqualityComparer))
      
      ' Call IStructuralEquatable.Equals using custom comparer.
      Console.WriteLine(equ.Equals(t2, New NanComparer))
   End Sub
End Module
' The example displays the following output:
'       True
'       True
'       True
'       False
' </Snippet2>