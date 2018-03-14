' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      WriteCharacterStrings(1, 26, True)
      Console.MoveBufferArea(0, Console.CursorTop - 10, 30, 1, Console.CursorLeft, Console.CursorTop + 1)
      Console.CursorTop = Console.CursorTop + 3
      Console.WriteLine("Press any key...") : Console.ReadKey()

      Console.Clear()
      WriteCharacterStrings(1, 26, False)
   End Sub
   
   Private Sub WriteCharacterStrings(start As Integer, _end As Integer, 
                                     changeColor As Boolean)
      For ctr As Integer = start To _end
         If changeColor Then
            Console.BackgroundColor = CType((ctr - 1) Mod 16, ConsoleColor)
         End If      
         Console.WriteLine(New String(Convert.ToChar(ctr + 64), 30))
      Next   
   End Sub
End Module
' </Snippet1>

