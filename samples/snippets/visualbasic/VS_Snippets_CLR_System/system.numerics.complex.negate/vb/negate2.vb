' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example
   Public Sub Main()
      ' <Snippet2>
      Dim c1 As New Complex(1.7, 3.9)
      Dim c2 As Complex = -c1
      ' </Snippet2>
      Console.WriteLine(c2) 
   End Sub
End Module

