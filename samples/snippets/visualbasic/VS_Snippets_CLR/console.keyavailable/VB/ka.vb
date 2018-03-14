'<snippet1>
Imports System.Threading

Class Sample
   Public Shared Sub Main()
      Dim cki As ConsoleKeyInfo
      
      Do
         Console.WriteLine(vbCrLf & "Press a key to display; press the 'x' key to quit.")

         ' Your code could perform some useful task in the following loop. However, 
         ' for the sake of this example we'll merely pause for a quarter second.
         
         While Console.KeyAvailable = False
            Thread.Sleep(250) ' Loop until input is entered.
         End While
         cki = Console.ReadKey(True)
         Console.WriteLine("You pressed the '{0}' key.", cki.Key)
      Loop While cki.Key <> ConsoleKey.X
   End Sub 
End Class 
'This example produces results similar to the following:
'
'Press a key to display; press the 'x' key to quit.
'You pressed the 'H' key.
'
'Press a key to display; press the 'x' key to quit.
'You pressed the 'E' key.
'
'Press a key to display; press the 'x' key to quit.
'You pressed the 'PageUp' key.
'
'Press a key to display; press the 'x' key to quit.
'You pressed the 'DownArrow' key.
'
'Press a key to display; press the 'x' key to quit.
'You pressed the 'X' key.
'
'</snippet1>