' <Snippet1>
Class Example
   Public Shared Sub Main()
      Dim cki As ConsoleKeyInfo
      ' Prevent example from ending if CTL+C is pressed.
      Console.TreatControlCAsInput = True

      Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.")
      Console.WriteLine("Press the Escape (Esc) key to quit: " + vbCrLf)
      Do
         cki = Console.ReadKey(True)
         Console.Write("You pressed ")
         If (cki.Modifiers And ConsoleModifiers.Alt) <> 0 Then Console.Write("ALT+")
         If (cki.Modifiers And ConsoleModifiers.Shift) <> 0 Then Console.Write("SHIFT+")
         If (cki.Modifiers And ConsoleModifiers.Control) <> 0 Then Console.Write("CTL+")
         Console.WriteLine("{0} (character '{1}')", cki.Key, cki.KeyChar)
      Loop While cki.Key <> ConsoleKey.Escape
   End Sub
End Class 
' This example displays output similar to the following:
'       Press any combination of CTL, ALT, and SHIFT, and a console key.
'       Press the Escape (Esc) key to quit:
'       
'       You pressed CTL+A (character '☺')
'       You pressed C (character 'c')
'       You pressed CTL+C (character '♥')
'       You pressed K (character 'k')
'       You pressed ALT+I (character 'i')
'       You pressed ALT+U (character 'u')
'       You pressed ALT+SHIFT+H (character 'H')
'       You pressed Escape (character '←')
' </Snippet1>
