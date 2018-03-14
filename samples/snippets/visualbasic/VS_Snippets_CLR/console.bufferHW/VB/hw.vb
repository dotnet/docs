'<snippet1>
' This example demonstrates the Console.BufferHeight and 
'                               Console.BufferWidth properties.
Imports System

Class Sample
   Public Shared Sub Main()
      Console.WriteLine("The current buffer height is {0} rows.", _
                        Console.BufferHeight)
      Console.WriteLine("The current buffer width is {0} columns.", _
                        Console.BufferWidth)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'The current buffer height is 300 rows.
'The current buffer width is 85 columns.
'
'</snippet1>