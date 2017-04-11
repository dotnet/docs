'<snippet1>
' This example demonstrates the Console.CursorVisible property.
Imports System
Imports Microsoft.VisualBasic

Class Sample
   Public Shared Sub Main()
      Dim m1 As String = vbCrLf & "The cursor is {0}." & _
                         vbCrLf & "Type any text then press Enter. " & _
                         "Type '+' in the first column to show " & _
                         vbCrLf & "the cursor, '-' to hide the cursor, " & _
                         "or lowercase 'x' to quit:"
      Dim s As String
      Dim saveCursorVisibile As Boolean
      Dim saveCursorSize As Integer
      '
      Console.CursorVisible = True ' Initialize the cursor to visible.
      saveCursorVisibile = Console.CursorVisible
      saveCursorSize = Console.CursorSize
      Console.CursorSize = 100 ' Emphasize the cursor.
      While True
         Console.WriteLine(m1, _
            IIf(Console.CursorVisible = True, "VISIBLE", "HIDDEN"))
         s = Console.ReadLine()
         If String.IsNullOrEmpty(s) = False Then
            If s(0) = "+"c Then
               Console.CursorVisible = True
            ElseIf s(0) = "-"c Then
               Console.CursorVisible = False
            ElseIf s(0) = "x"c Then
               Exit While
            End If
         End If
      End While
      Console.CursorVisible = saveCursorVisibile
      Console.CursorSize = saveCursorSize
   End Sub 'Main
End Class 'Sample 
'
'This example produces the following results. Note that these results
'cannot depict cursor visibility. You must run the example to see the 
'cursor behavior:
'
'The cursor is VISIBLE.
'Type any text then press Enter. Type '+' in the first column to show
'the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
'The quick brown fox
'
'The cursor is VISIBLE.
'Type any text then press Enter. Type '+' in the first column to show
'the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
'-
'
'The cursor is HIDDEN.
'Type any text then press Enter. Type '+' in the first column to show
'the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
'jumps over
'
'The cursor is HIDDEN.
'Type any text then press Enter. Type '+' in the first column to show
'the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
'+
'
'The cursor is VISIBLE.
'Type any text then press Enter. Type '+' in the first column to show
'the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
'the lazy dog.
'
'The cursor is VISIBLE.
'Type any text then press Enter. Type '+' in the first column to show
'the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
'x
'
'</snippet1>