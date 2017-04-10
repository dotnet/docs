' <Snippet1>
Class Example
   Public Shared Sub Main()
      Dim cki As ConsoleKeyInfo
      ' Prevent example from ending if CTL+C is pressed.
      Console.TreatControlCAsInput = True

      Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.")
      Console.WriteLine("Press the Escape (Esc) key to quit: " + vbCrLf)
      Do
         cki = Console.ReadKey()
         Console.Write(" --- You pressed ")
         If (cki.Modifiers And ConsoleModifiers.Alt) <> 0 Then Console.Write("ALT+")
         If (cki.Modifiers And ConsoleModifiers.Shift) <> 0 Then Console.Write("SHIFT+")
         If (cki.Modifiers And ConsoleModifiers.Control) <> 0 Then Console.Write("CTL+")
         Console.WriteLine(cki.Key.ToString)
      Loop While cki.Key <> ConsoleKey.Escape
   End Sub 
End Class 
' This example displays output similar to the following:
'       Press any combination of CTL, ALT, and SHIFT, and a console key.
'       Press the Escape (Esc) key to quit:
'       
'       a --- You pressed A 
'       k --- You pressed ALT+K 
'       ► --- You pressed CTL+P 
'         --- You pressed RightArrow 
'       R --- You pressed SHIFT+R 
'                --- You pressed CTL+I 
'       j --- You pressed ALT+J 
'       O --- You pressed SHIFT+O 
'       § --- You pressed CTL+U 
' </Snippet1>
