'  <SNIPPET1>
Imports System
Imports System.Reflection
Imports System.Security.Policy
 'for evidence object

Class ADSetup
   
   Public Shared Sub Main()
      ' Create application domain setup information
      Dim domaininfo As New AppDomainSetup()
      
      'Create evidence for the new appdomain from evidence of the current application domain
      Dim adevidence As Evidence = AppDomain.CurrentDomain.Evidence
      
      ' Create appdomain
      Dim domain As AppDomain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo)
      
      ' Write out application domain information
      Console.WriteLine(("Host domain: " + AppDomain.CurrentDomain.FriendlyName))
      Console.WriteLine(("child domain: " + domain.FriendlyName))
      Console.WriteLine(("child domain name using ToString:" + domain.ToString()))
      Console.WriteLine()
      
      AppDomain.Unload(domain)
   End Sub 'Main 
End Class 'ADSetup

'  </SNIPPET1>