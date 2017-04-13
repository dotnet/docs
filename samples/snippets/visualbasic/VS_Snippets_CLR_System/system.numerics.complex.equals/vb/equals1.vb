' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Public Class Complex2
   Dim real, imaginary As Double
   
   Public Overloads Function Equals(value As Complex2) As Boolean
      ' <Snippet1>
      Return Me.Real.Equals(value.Real) AndAlso Me.Imaginary.Equals(value.Imaginary)
      ' </Snippet1>
   End Function  
   
   Public Overrides Function Equals(value As Object) As Boolean
      ' <Snippet2>
      Return Me.Real.Equals(CType(value, Complex).Real) AndAlso 
             Me.Imaginary.Equals(CType(value, Complex).Imaginary)
      ' </Snippet2>
   End Function 
   
   Public Function opEquality(value As Complex) As Boolean
      ' <Snippet3>
      Return Me.Real = value.Real AndAlso Me.Imaginary = value.Imaginary
      ' </Snippet3>
   End Function
End Class

Module Example

   Public Sub Main()

   End Sub
End Module

