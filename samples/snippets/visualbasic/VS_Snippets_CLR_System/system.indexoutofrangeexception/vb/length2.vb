' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim characters As New List(Of Char)()
      characters.InsertRange(0, { "a"c, "b"c, "c"c, "d"c, "e"c, "f"c} )
      For ctr As Integer = 0 To characters.Count - 1
         Console.Write("'{0}'    ", characters(ctr))
      Next
   End Sub
End Module
' The example displays the following output:
'       'a'    'b'    'c'    'd'    'e'    'f'
' </Snippet4>
