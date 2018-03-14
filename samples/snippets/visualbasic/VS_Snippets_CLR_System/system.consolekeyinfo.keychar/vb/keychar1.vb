' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Configure console.
      Console.BufferWidth = 80
      Console.WindowWidth = Console.BufferWidth
      Console.TreatControlCAsInput = True
      
      Dim inputString As String = String.Empty
      Dim keyInfo As ConsoleKeyInfo

      Console.WriteLine("Enter a string. Press <Enter> or Esc to exit.")
      Do
         keyInfo = Console.ReadKey(True)
         ' Ignore if Alt or Ctrl is pressed.
         If (keyInfo.Modifiers And ConsoleModifiers.Alt) = ConsoleModifiers.Alt _
                              Then Continue Do 
         If (keyInfo.Modifiers And ConsoleModifiers.Control) = ConsoleModifiers.Control _
                              Then Continue Do 
         ' Ignore if KeyChar value is \u0000.
         If keyInfo.KeyChar = ChrW(0) Then Continue Do
         ' Ignore tab, clear key.
         If keyInfo.Key = ConsoleKey.Tab Then Continue Do
         ' Handle backspace.
         If keyInfo.Key = ConsoleKey.Backspace Then
            ' Are there any characters to erase?
            If inputString.Length >= 1 Then
               ' Determine where we are in the console buffer.
               Dim cursorCol As Integer = Console.CursorLeft - 1
               Dim oldLength As Integer = inputString.Length
               Dim extraRows As Integer = oldLength \ 80

               inputString = inputString.Substring(0, oldLength - 1)
               Console.CursorLeft = 0
               Console.CursorTop = Console.CursorTop - extraRows
               Console.Write(inputString + New String(" "c, oldLength - inputString.Length))
               Console.CursorLeft = cursorCol
            End If
            Continue Do
         End If   
         ' Handle Escape key.
         If keyInfo.Key = ConsoleKey.Escape Then Exit Do
         ' Handle key by adding it to input string.
         Console.Write(keyInfo.KeyChar)
         inputString += keyInfo.KeyChar 
      Loop While keyInfo.Key <> ConsoleKey.Enter
      Console.WriteLine("{0}{0}You entered:{0}    {1}", vbCrLf, _
                        IIf(String.IsNullOrEmpty(inputString), "<nothing>", inputString))
   End Sub
End Module
' </Snippet1>
