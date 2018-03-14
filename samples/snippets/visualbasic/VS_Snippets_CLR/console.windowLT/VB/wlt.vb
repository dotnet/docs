'<snippet1>
' This example demonstrates the Console.WindowLeft and
'                               Console.WindowTop properties.
Imports System.IO
Imports System.Text

Class Sample
   Public Shared saveBufferWidth As Integer
   Public Shared saveBufferHeight As Integer
   Public Shared saveWindowHeight As Integer
   Public Shared saveWindowWidth As Integer
   Public Shared saveCursorVisible As Boolean
   
   Public Shared Sub Main()
      Dim m1 As String = _
          "1) Press the cursor keys to move the console window." & vbCrlf & _
          "2) Press any key to begin. When you're finished..."   & vbCrlf & _
          "3) Press the Escape key to quit."
      Dim g1 As String = "+----"
      Dim g2 As String = "|    "
      Dim grid1 As String
      Dim grid2 As String
      Dim sbG1 As New StringBuilder()
      Dim sbG2 As New StringBuilder()
      Dim cki As ConsoleKeyInfo
      Dim y As Integer
      '
      Try
         saveBufferWidth = Console.BufferWidth
         saveBufferHeight = Console.BufferHeight
         saveWindowHeight = Console.WindowHeight
         saveWindowWidth = Console.WindowWidth
         saveCursorVisible = Console.CursorVisible
         '
         Console.Clear()
         Console.WriteLine(m1)
         Console.ReadKey(True)
         
         ' Set the smallest possible window size before setting the buffer size.
         Console.SetWindowSize(1, 1)
         Console.SetBufferSize(80, 80)
         Console.SetWindowSize(40, 20)
         
         ' Create grid lines to fit the buffer. (The buffer width is 80, but
         ' this same technique could be used with an arbitrary buffer width.)
         For y = 0 To (Console.BufferWidth / g1.Length) - 1
            sbG1.Append(g1)
            sbG2.Append(g2)
         Next y
         sbG1.Append(g1, 0, Console.BufferWidth Mod g1.Length)
         sbG2.Append(g2, 0, Console.BufferWidth Mod g2.Length)
         grid1 = sbG1.ToString()
         grid2 = sbG2.ToString()
         
         Console.CursorVisible = False
         Console.Clear()
         For y = 0 To (Console.BufferHeight - 2)
            If y Mod 3 = 0 Then
               Console.Write(grid1)
            Else
               Console.Write(grid2)
            End If
         Next y 
         '
         Console.SetWindowPosition(0, 0)
         Do
            cki = Console.ReadKey(True)
            Select Case cki.Key
               Case ConsoleKey.LeftArrow
                  If Console.WindowLeft > 0 Then
                     Console.SetWindowPosition(Console.WindowLeft - 1, Console.WindowTop)
                  End If
               Case ConsoleKey.UpArrow
                  If Console.WindowTop > 0 Then
                     Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1)
                  End If
               Case ConsoleKey.RightArrow
                  If Console.WindowLeft < Console.BufferWidth - Console.WindowWidth Then
                     Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop)
                  End If
               Case ConsoleKey.DownArrow
                  If Console.WindowTop < Console.BufferHeight - Console.WindowHeight Then
                     Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1)
                  End If
            End Select
         Loop While cki.Key <> ConsoleKey.Escape
      ' end do-while
      ' end try
      Catch e As IOException
         Console.WriteLine(e.Message)
      Finally
         Console.Clear()
         Console.SetWindowSize(1, 1)
         Console.SetBufferSize(saveBufferWidth, saveBufferHeight)
         Console.SetWindowSize(saveWindowWidth, saveWindowHeight)
         Console.CursorVisible = saveCursorVisible
      End Try
   End Sub 'Main ' end Main
End Class 'Sample ' end Sample
'
'This example produces results similar to the following:
'
'1) Press the cursor keys to move the console window.
'2) Press any key to begin. When you're finished...
'3) Press the Escape key to quit.
'
'...
'
'+----+----+----+-
'|    |    |    |
'|    |    |    |
'+----+----+----+-
'|    |    |    |
'|    |    |    |
'+----+----+----+-
'
'</snippet1>
