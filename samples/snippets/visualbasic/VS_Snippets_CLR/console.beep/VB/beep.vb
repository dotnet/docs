'<snippet1>
' This example demonstrates the Console.Beep() method.
Imports System

Class Sample
   Public Shared Sub Main(args() As String)
      Dim x As Integer = 0
      Dim i As Integer
      '
      If      (args.Length = 1) _
      AndAlso (Int32.TryParse(args(0), x) = True) _
      AndAlso ((x >= 1) AndAlso (x <= 9)) Then
         For i = 1 To x
            Console.WriteLine("Beep number {0}.", i)
            Console.Beep()
         Next i
      Else
         Console.WriteLine("Usage: Enter the number of times (between 1 and 9) to beep.")
      End If
   End Sub 'Main
End Class 'Sample 
'
'This example produces the following results:
'
'>beep
'Usage: Enter the number of times (between 1 and 9) to beep
'
'>beep 9
'Beep number 1.
'Beep number 2.
'Beep number 3.
'Beep number 4.
'Beep number 5.
'Beep number 6.
'Beep number 7.
'Beep number 8.
'Beep number 9.
'
'</snippet1>