Module Example
   Public Sub Main()
      If Console.BackgroundColor = ConsoleColor.Black Then
         Console.BackgroundColor = ConsoleColor.Red
         Console.ForegroundColor = ConsoleColor.Black
         Console.Clear()
      End If
   End Sub
End Module