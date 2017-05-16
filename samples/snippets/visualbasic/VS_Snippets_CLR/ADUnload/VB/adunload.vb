' <SNIPPET1>
Imports System
Imports System.Reflection
Imports System.Security.Policy

Class ADUnload
   
   Public Shared Sub Main()

      'Create evidence for the new appdomain.
      Dim adevidence As Evidence = AppDomain.CurrentDomain.Evidence

      ' Create the new application domain.
      Dim domain As AppDomain = AppDomain.CreateDomain("MyDomain", adevidence)
      
      Console.WriteLine(("Host domain: " + AppDomain.CurrentDomain.FriendlyName))
      Console.WriteLine(("child domain: " + domain.FriendlyName))
      ' Unload the application domain.
      AppDomain.Unload(domain)
      
      Try
         Console.WriteLine()
         ' Note that the following statement creates an exception because the domain no longer exists.
         Console.WriteLine(("child domain: " + domain.FriendlyName))
      
      Catch e As AppDomainUnloadedException
         Console.WriteLine("The appdomain MyDomain does not exist.")
      End Try
   End Sub 'Main 
End Class 'ADUnload
' </SNIPPET1>