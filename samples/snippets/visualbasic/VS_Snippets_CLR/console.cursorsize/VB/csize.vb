'<snippet1>
' This example demonstrates the Console.CursorSize property.
Imports System
Imports Microsoft.VisualBasic

Class Sample
   Public Shared Sub Main()
      Dim m0 As String = "This example increments the cursor size from " & _
                         "1% to 100%:" & vbCrLf
      Dim m1 As String = "Cursor size = {0}%. (Press any key to continue...)"
      Dim sizes As Integer() =  {1, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100}
      Dim saveCursorSize As Integer
      '
      saveCursorSize = Console.CursorSize
      Console.WriteLine(m0)
      Dim size As Integer
      For Each size In  sizes
         Console.CursorSize = size
         Console.WriteLine(m1, size)
         Console.ReadKey()
      Next size
      Console.CursorSize = saveCursorSize
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'This example increments the cursor size from 1% to 100%:
'
'Cursor size = 1%. (Press any key to continue...)
'Cursor size = 10%. (Press any key to continue...)
'Cursor size = 20%. (Press any key to continue...)
'Cursor size = 30%. (Press any key to continue...)
'Cursor size = 40%. (Press any key to continue...)
'Cursor size = 50%. (Press any key to continue...)
'Cursor size = 60%. (Press any key to continue...)
'Cursor size = 70%. (Press any key to continue...)
'Cursor size = 80%. (Press any key to continue...)
'Cursor size = 90%. (Press any key to continue...)
'Cursor size = 100%. (Press any key to continue...)
'
'</snippet1>