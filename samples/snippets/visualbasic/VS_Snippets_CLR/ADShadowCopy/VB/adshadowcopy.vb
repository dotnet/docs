' <SNIPPET1>
Imports System
Imports System.Security.Policy
 'for evidence object

Class ADShadowCopy
   
   'Entry point which delegates to C-style main Private Function
   ' Public Overloads Shared Sub Main()
    '  Main(System.Environment.GetCommandLineArgs())
   ' End Sub
   
   Public Overloads Shared Sub Main(args() As String)
      
      Dim setup As New AppDomainSetup()
      ' Shadow copying will not work unless the application has a name.
      setup.ApplicationName = "MyApplication"
      
      'Create evidence for the new application domain from evidence of
      ' current application domain.
      Dim adevidence As Evidence = AppDomain.CurrentDomain.Evidence
      
      ' Create a new application domain.
      Dim domain As AppDomain = AppDomain.CreateDomain("MyDomain", adevidence, setup)
      
      ' MyAssembly.dll is located in the Assemblies subdirectory.
      domain.AppendPrivatePath("Assemblies")
      ' MyOtherAssembly.dll and MyThirdAssembly.dll are located in the
      ' MoreAssemblies subdirectory.
      domain.AppendPrivatePath("MoreAssemblies")
      ' Display the relative search path.
      Console.WriteLine(("RelativeSearchPath: " + domain.RelativeSearchPath))
      ' Because Load returns an Assembly object, the assemblies must be
      ' loaded into the current domain as well. This will fail unless the
      ' current domain also has these directories in its search path.
      AppDomain.CurrentDomain.AppendPrivatePath("Assemblies")
      AppDomain.CurrentDomain.AppendPrivatePath("MoreAssemblies")
      
      ' Save shadow copies to C:\Cache
      domain.SetCachePath("C:\Cache")
      ' Shadow copy only the assemblies in the Assemblies directory.
      domain.SetShadowCopyPath((domain.BaseDirectory + "Assemblies"))
      ' Turn shadow copying on.
      domain.SetShadowCopyFiles()
      
      ' This will be copied.
      ' You must supply a valid fully qualified assembly name here. 
      domain.Load("Assembly1 text name, Version, Culture, PublicKeyToken")
      ' This will not be copied.
      ' You must supply a valid fully qualified assembly name here. 
      domain.Load("Assembly2 text name, Version, Culture, PublicKeyToken")
      
      ' When the shadow copy path is cleared, the CLR will make shadow copies
      ' of all private assemblies.
      domain.ClearShadowCopyPath()
      ' MoreAssemblies\MyThirdAssembly.dll should be shadow copied this time.
      ' You must supply a valid fully qualified assembly name here.
      domain.Load("Assembly3 text name, Version, Culture, PublicKeyToken")
      
      ' Unload the domain.
      AppDomain.Unload(domain)
   End Sub 'Main
End Class 'ADShadowCopy
' </SNIPPET1>