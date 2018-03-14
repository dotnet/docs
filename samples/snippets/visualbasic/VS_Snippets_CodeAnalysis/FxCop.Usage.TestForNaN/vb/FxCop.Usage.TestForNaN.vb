'<Snippet1>
Imports System

Namespace UsageLibrary

   Class NaNTests
   
      Shared zero As Double
      
      Shared Sub Main()
         Console.WriteLine( 0/zero = Double.NaN )
         Console.WriteLine( 0/zero <> Double.NaN )
         Console.WriteLine( Double.IsNaN(0/zero) )
      End Sub

   End Class

End Namespace
'</Snippet1>
