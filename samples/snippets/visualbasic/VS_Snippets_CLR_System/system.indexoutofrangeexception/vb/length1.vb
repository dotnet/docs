' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim characters As New List(Of Char)()
      characters.InsertRange(0, { "a"c, "b"c, "c"c, "d"c, "e"c, "f"c} )
      For ctr As Integer = 0 To characters.Count
         Console.Write("'{0}'    ", characters(ctr))
      Next
   End Sub
End Module
' The example displays the following output:
'    'a'    'b'    'c'    'd'    'e'    'f'
'    Unhandled Exception: 
'    System.ArgumentOutOfRangeException: 
'    Index was out of range. Must be non-negative and less than the size of the collection.
'    Parameter name: index
'       at System.Collections.Generic.List`1.get_Item(Int32 index)
'       at Example.Main()
' </Snippet3>
