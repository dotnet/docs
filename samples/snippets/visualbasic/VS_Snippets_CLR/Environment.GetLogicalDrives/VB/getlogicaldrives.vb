'<snippet1>
' Sample for the Environment.GetLogicalDrives method
Imports System

Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      Dim drives As [String]() = Environment.GetLogicalDrives()
      Console.WriteLine("GetLogicalDrives: {0}", [String].Join(", ", drives))
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'GetLogicalDrives: A:\, C:\, D:\
'
'</snippet1>