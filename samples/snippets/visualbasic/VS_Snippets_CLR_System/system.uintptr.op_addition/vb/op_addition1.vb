' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
      Dim ptr = CType(arr(0), UIntPtr)
      For ctr As Integer = 0 To arr.Length - 1
         Dim newPtr As UIntPtr = ptr + ctr
         Console.WriteLine(newPtr)
      Next
      ' </Snippet1>
   End Sub
End Module

