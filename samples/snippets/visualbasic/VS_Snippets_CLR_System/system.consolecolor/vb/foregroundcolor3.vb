' <Snippet1>
Public Module Example
   Public Sub Main()
      ' Get an array with the values of ConsoleColor enumeration members.
      Dim colors() As ConsoleColor = ConsoleColor.GetValues(GetType(ConsoleColor))
      ' Save the current background and foreground colors.
      Dim currentBackground As ConsoleColor = Console.BackgroundColor
      Dim currentForeground As ConsoleColor = Console.ForegroundColor
      
      ' Display all foreground colors except the one that matches the background.
      Console.WriteLine("All the foreground colors except {0}, the background color:",
                        currentBackground)
      For Each color In colors
         If color = currentBackground Then Continue For
          
         Console.ForegroundColor = color
         Console.WriteLine("   The foreground color is {0}.", color)
      Next 
      Console.WriteLine()
      
      ' Restore the foreground color.
      Console.ForegroundColor = currentForeground
      
      ' Display each background color except the one that matches the current foreground color.
      Console.WriteLine("All the background colors except {0}, the foreground color:",
                        currentForeground)
      For Each color In colors
         If color = currentForeground  then Continue For
         Console.BackgroundColor = color
         Console.WriteLine("   The background color is {0}.", color)
      Next
      ' Restore the original console colors.
      Console.ResetColor
      Console.WriteLine()
      Console.WriteLine("Original colors restored...")
   End Sub
End Module
'The example displays output like the following:
'       The background color is DarkCyan.
'       The background color is DarkRed.
'       The background color is DarkMagenta.
'       The background color is DarkYellow.
'       The background color is Gray.
'       The background color is DarkGray.
'       The background color is Blue.
'       The background color is Green.
'       The background color is Cyan.
'       The background color is Red.
'       The background color is Magenta.
'       The background color is Yellow.
'    
'    Original colors restored...
' </Snippet1>
