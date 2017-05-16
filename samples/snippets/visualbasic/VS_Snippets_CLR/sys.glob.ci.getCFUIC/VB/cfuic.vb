'<snippet1>
' This example demonstrates the GetConsoleFallbackUICulture() method
Imports System
Imports System.Globalization

Class Sample
   Public Shared Sub Main()
      Dim ci As New CultureInfo("ar-DZ")
      Console.WriteLine("Culture name: . . . . . . . . . {0}", ci.Name)
      Console.WriteLine("Console fallback UI culture:. . {0}", _
                         ci.GetConsoleFallbackUICulture().Name)
   End Sub 'Main
End Class 'Sample
'
'This code example produces the following results:
'
'Culture name: . . . . . . . . . ar-DZ
'Console fallback UI culture:. . fr-FR
'
'</snippet1>