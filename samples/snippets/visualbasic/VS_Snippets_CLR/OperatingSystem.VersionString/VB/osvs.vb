'<snippet1>
' This example demonstrates the VersionString property.
Imports System

Class Sample
   Public Shared Sub Main()
      Dim os As OperatingSystem = Environment.OSVersion

' Display the value of OperatingSystem.VersionString. By default, this is
' the same value as OperatingSystem.ToString.

      Console.WriteLine("This operating system is {0}", os.VersionString)

   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'This operating system is Microsoft Windows NT 5.1.2600.0 Service Pack 1
'</snippet1>