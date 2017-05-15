 '  <SNIPPET1>
Imports System
Imports System.Reflection
Imports System.Security.Policy

Class ADAppendPrivatePath
   
   Public Shared Sub Main()
      'Create evidence for new appdomain.
      Dim adevidence As Evidence = AppDomain.CurrentDomain.Evidence
      
      'Create the new application domain.
      Dim domain As AppDomain = AppDomain.CreateDomain("MyDomain", adevidence)
      
      'Display the current relative search path.
      Console.WriteLine("Relative search path is: " & domain.RelativeSearchPath)
      
      'Append the relative path.
      Dim Newpath As [String] = "www.code.microsoft.com"
      domain.AppendPrivatePath(Newpath)
      
      'Display the new relative search path.
      Console.WriteLine("Relative search path is: " & domain.RelativeSearchPath)
      
      'Clear the private search path.
      domain.ClearPrivatePath()
      
      'Display the new relative search path.
      Console.WriteLine("Relative search path is now: " & domain.RelativeSearchPath)
      
      
      AppDomain.Unload(domain)
   End Sub 'Main
End Class 'ADAppendPrivatePath
'  </SNIPPET1>


