'<snippet1>
Imports System.Security

Class Example
   Public Shared Sub Main()
      Dim cki As ConsoleKeyInfo
      Dim m As String = vbCrLf & "Enter your password (up to 15 letters, numbers, and underscores)" &
                        vbCrLf & "Press BACKSPACE to delete the last character entered. " & vbCrLf &
                        "Press Enter when done, or ESCAPE to quit: "
      Dim password As New SecureString()
      Dim top, left As Integer

      ' The Console.TreatControlCAsInput property prevents CTRL+C from
      ' ending this example.
      Console.TreatControlCAsInput = True

      Console.Clear()
      Console.WriteLine(m)

      top = Console.CursorTop
      left = Console.CursorLeft

      ' Read user input from the console. Store up to 15 letter, digit, or underscore
      ' characters in a SecureString object, or delete a character if the user enters 
      ' a backspace. Display an asterisk (*) on the console to represent each character 
      ' that is stored.
      
      Do
         cki = Console.ReadKey(True)
         If cki.Key = ConsoleKey.Escape Then Exit Do

         If cki.Key = ConsoleKey.Backspace Then
            If password.Length > 0 Then
               Console.SetCursorPosition(left + password.Length - 1, top)
               Console.Write(" "c)
               Console.SetCursorPosition(left + password.Length - 1, top)
               password.RemoveAt(password.Length - 1)
            End If
         Else
            If password.Length < 15 AndAlso([Char].IsLetterOrDigit(cki.KeyChar) _
            OrElse cki.KeyChar = "_"c) Then
               password.AppendChar(cki.KeyChar)
               Console.SetCursorPosition(left + password.Length - 1, top)
               Console.Write("*"c)
            End If
         End If
      Loop While cki.Key <> ConsoleKey.Enter And password.Length < 15

      ' Make the password read-only to prevent modification.
      password.MakeReadOnly()
      ' Dispose of the SecureString instance.
      password.Dispose()
   End Sub
End Class
' The example displays output like the following:
'    Enter your password (up to 15 letters, numbers, and underscores)
'    Press BACKSPACE to delete the last character entered.
'    Press Enter when done, or ESCAPE to quit:
'    ************
'</snippet1>