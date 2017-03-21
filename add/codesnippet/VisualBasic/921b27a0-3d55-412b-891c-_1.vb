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