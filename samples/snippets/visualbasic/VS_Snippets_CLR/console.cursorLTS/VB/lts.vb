'<snippet1>
' This example demonstrates the 
'     Console.CursorLeft and 
'     Console.CursorTop properties, and the
'     Console.SetCursorPosition and 
'     Console.Clear methods.
Imports System

Class Sample
   Protected Shared origRow As Integer
   Protected Shared origCol As Integer
   
   Protected Shared Sub WriteAt(s As String, x As Integer, y As Integer)
      Try
         Console.SetCursorPosition(origCol + x, origRow + y)
         Console.Write(s)
      Catch e As ArgumentOutOfRangeException
         Console.Clear()
         Console.WriteLine(e.Message)
      End Try
   End Sub 'WriteAt
   
   Public Shared Sub Main()
      ' Clear the screen, then save the top and left coordinates.
      Console.Clear()
      origRow = Console.CursorTop
      origCol = Console.CursorLeft
      
      ' Draw the left side of a 5x5 rectangle, from top to bottom.
      WriteAt("+", 0, 0)
      WriteAt("|", 0, 1)
      WriteAt("|", 0, 2)
      WriteAt("|", 0, 3)
      WriteAt("+", 0, 4)
      
      ' Draw the bottom side, from left to right.
      WriteAt("-", 1, 4) ' shortcut: WriteAt("---", 1, 4)
      WriteAt("-", 2, 4) ' ...
      WriteAt("-", 3, 4) ' ...
      WriteAt("+", 4, 4)
      
      ' Draw the right side, from bottom to top.
      WriteAt("|", 4, 3)
      WriteAt("|", 4, 2)
      WriteAt("|", 4, 1)
      WriteAt("+", 4, 0)
      
      ' Draw the top side, from right to left.
      WriteAt("-", 3, 0) ' shortcut: WriteAt("---", 1, 0)
      WriteAt("-", 2, 0) ' ...
      WriteAt("-", 1, 0) ' ...
      '
      WriteAt("All done!", 0, 6)
      Console.WriteLine()
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'+---+
'|   |
'|   |
'|   |
'+---+
'
'All done!
'
'</snippet1>