'<snippet1>
' Sample for the Environment.GetFolderPath method
Imports System

Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      Console.WriteLine("GetFolderPath: {0}", Environment.GetFolderPath(Environment.SpecialFolder.System))
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'GetFolderPath: C:\WINNT\System32
'
'</snippet1>