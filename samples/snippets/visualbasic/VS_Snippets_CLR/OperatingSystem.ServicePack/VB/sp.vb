'<snippet1>
' This example demonstrates the OperatingSystem.ServicePack property.
Imports System

Class Sample
   Public Shared Sub Main()
      Dim os As OperatingSystem = Environment.OSVersion
      Console.WriteLine("Service pack version = ""{0}""", os.ServicePack)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'Service pack version = "Service Pack 1"
'
'</snippet1>