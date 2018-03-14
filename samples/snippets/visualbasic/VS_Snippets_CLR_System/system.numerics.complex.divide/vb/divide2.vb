' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example
   Public Sub Main()
      ' <Snippet2>
      Dim c1 As New Complex(2.3, 3.7)
      Dim c2 As New Complex(1.4, 2.3)
      Dim c3 As Complex = c1 / c2 
      ' </Snippet2>
      Console.WriteLine(c3)
   End Sub
End Module

