'<snippet1>
' Sample for the Environment.SystemDirectory property
Imports System

Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      '  <-- Keep this information secure! -->
      Console.WriteLine("SystemDirectory: {0}", Environment.SystemDirectory)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'SystemDirectory: C:\WINNT\System32
'
'</snippet1>