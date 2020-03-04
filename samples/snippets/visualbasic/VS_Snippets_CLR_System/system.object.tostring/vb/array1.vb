' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim values() As Integer = { 1, 2, 4, 8, 16, 32, 64, 128 }
      Console.WriteLine(values.ToString())
      
      Dim list As New List(Of Integer)(values)
      Console.WriteLine(list.ToString())
   End Sub
End Module
' The example displays the following output:
'    System.Int32[]
'    System.Collections.Generic.List`1[System.Int32]
' </Snippet6>
