' <SNIPPET1>
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Security.Policy

Module Example
   Public Sub Main()
      ' Create the application domain setup information.
      Dim domaininfo As New AppDomainSetup()
      domaininfo.ConfigurationFile = Environment.CurrentDirectory + 
                                    Path.DirectorySeparatorChar + 
                                     "ADSetup.exe.config"
      domaininfo.ApplicationBase = Environment.CurrentDirectory
      
      'Create evidence for the new appdomain from evidence of the current application domain.
      Dim adEvidence As Evidence = AppDomain.CurrentDomain.Evidence
      
      ' Create appdomain.
      Dim domain As AppDomain = AppDomain.CreateDomain("Domain2", adevidence, domaininfo)
      
      ' Display the application domain information.
      Console.WriteLine(("Host domain: " + AppDomain.CurrentDomain.FriendlyName))
      Console.WriteLine(("Child domain: " + domain.FriendlyName))
      Console.WriteLine()
      Console.WriteLine(("Configuration file: " + domain.SetupInformation.ConfigurationFile))
      Console.WriteLine(("Application Base Directory: " + domain.BaseDirectory))
     
      AppDomain.Unload(domain)
   End Sub 
End Module 
' The example displays output like the following:
'    Host domain: adsetup.exe
'    Child domain: Domain2
'    
'    Configuration file: C:\Test\ADSetup.exe.config
'    Application Base Directory: C:\Test
' </SNIPPET1>

