' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Save colors so they can be restored when use finishes input.
      Dim dftForeColor As ConsoleColor = Console.ForegroundColor
      Dim dftBackColor As ConsoleColor = Console.BackgroundColor
      Dim continueFlag As Boolean = True
      Console.Clear()
            
      Do 
         Dim newForeColor As ConsoleColor
         Dim newBackColor As ConsoleColor
                  
         Dim foreColorSelection As Char = GetKeyPress("Select Text Color (B for Blue, R for Red, Y for Yellow): ", 
                                              { "B"c, "R"c, "Y"c } )
         Select Case foreColorSelection
            Case "B"c, "b"c
               newForeColor = ConsoleColor.DarkBlue
            Case "R"c, "r"c
               newForeColor = ConsoleColor.DarkRed
            Case "Y"c, "y"c
               newForeColor = ConsoleColor.DarkYellow   
         End Select
         Dim backColorSelection As Char = GetKeyPress("Select Background Color (W for White, G for Green, M for Magenta): ",
                                              { "W"c, "G"c, "M"c })
         Select Case backColorSelection
            Case "W"c, "w"c
               newBackColor = ConsoleColor.White
            Case "G"c, "g"c
               newBackColor = ConsoleColor.Green
            Case "M"c, "m"c
               newBackColor = ConsoleColor.Magenta   
         End Select
         
         Console.WriteLine()
         Console.Write("Enter a message to display: ")
         Dim textToDisplay As String = Console.ReadLine()
         Console.WriteLine()
         Console.ForegroundColor = newForeColor
         Console.BackgroundColor = newBackColor
         Console.WriteLine(textToDisplay)
         Console.WriteLine()
         If Char.ToUpper(GetKeyPress("Display another message (Y/N): ", { "Y"c, "N"c } )) = "N" Then
            continueFlag = False
         End If
         ' Restore the default settings and clear the screen.
         Console.ForegroundColor = dftForeColor
         Console.BackgroundColor = dftBackColor
         Console.Clear()
      Loop While continueFlag
   End Sub
   
   Private Function GetKeyPress(msg As String, validChars() As Char) As Char
      Dim keyPressed As ConsoleKeyInfo
      Dim valid As Boolean = False
      
      Console.WriteLine()
      Do
         Console.Write(msg)
         keyPressed = Console.ReadKey()
         Console.WriteLine()
         If Array.Exists(validChars, Function(ch As Char) ch.Equals(Char.ToUpper(keypressed.KeyChar)))           
            valid = True
         End If
      Loop While Not valid
      Return keyPressed.KeyChar 
   End Function
End Module
' </Snippet1>
