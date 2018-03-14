' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim key As ConsoleKeyInfo
      Dim moved As Boolean = False
            
      Console.BufferWidth = 120
      Console.Clear()
      
      ShowConsoleStatistics()
      Do While True
         key = Console.ReadKey(True)
         If key.Key = ConsoleKey.LeftArrow Then
            Dim pos As Integer = Console.WindowLeft - 1
            If pos >= 0 And pos + Console.WindowWidth <= Console.BufferWidth Then 
               Console.WindowLeft = pos
               moved = True
            End If       
         ElseIf key.Key = ConsoleKey.RightArrow Then
            Dim pos As Integer = Console.WindowLeft + 1
            If pos + Console.WindowWidth <= Console.BufferWidth Then 
               Console.WindowLeft = pos
               moved = True
            End If
         End If
         If moved Then ShowConsoleStatistics() : moved = False
         Console.WriteLine()
      Loop
   End Sub
   
   Private Sub ShowConsoleStatistics()
      Console.WriteLine("Console statistics:")
      Console.WriteLine("   Buffer: {0} x {1}", Console.BufferHeight, Console.BufferWidth)
      Console.WriteLine("   Window: {0} x {1}", Console.WindowHeight, Console.WindowWidth)
      Console.WriteLine("   Window starts at {0}.", Console.WindowLeft)
      Console.WriteLine("Press <- or -> to move window, Ctrl+C to exit.")
   End Sub
End Module
' </Snippet1>
