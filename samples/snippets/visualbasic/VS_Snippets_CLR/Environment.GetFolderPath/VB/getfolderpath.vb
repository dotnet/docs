'<snippet1>
' Sample for the Environment.GetFolderPath method
Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      Console.WriteLine("GetFolderPath: {0}", Environment.GetFolderPath(Environment.SpecialFolder.System))
   End Sub
End Class
'
'This example produces the following results:
'
'GetFolderPath: C:\WINNT\System32
'
'</snippet1>