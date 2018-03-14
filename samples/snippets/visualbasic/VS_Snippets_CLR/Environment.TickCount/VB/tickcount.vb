'<snippet1>

' Sample for the Environment.TickCount property.
' TickCount cycles between Int32.MinValue, which is a negative 
' number, and Int32.MaxValue once every 49.8 days. This sample
' removes the sign bit to yield a nonnegative number that cycles 
' between zero and Int32.MaxValue once every 24.9 days.

Imports System

Class Sample
   Public Shared Sub Main()
      Dim result As Integer = Environment.TickCount And Int32.MaxValue

      Console.WriteLine("TickCount: {0}", result)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'TickCount: 101931139
'
'</snippet1>