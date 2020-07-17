'<snippet3>
Imports System.Reflection

Class AppDomain5
    Public Shared Sub Main()
        ' Application domain setup information.
        Dim domaininfo As New AppDomainSetup()
        domaininfo.ApplicationBase = "f:\work\development\latest"
        domaininfo.ConfigurationFile = "f:\work\development\latest\appdomain5.exe.config"

        ' Creates the application domain.
        Dim domain As AppDomain = AppDomain.CreateDomain("MyDomain", Nothing, domaininfo)

        ' Write the application domain information to the console.
        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName)
        Console.WriteLine("Child domain: " + domain.FriendlyName)
        Console.WriteLine()
        Console.WriteLine("Application base is: " + domain.SetupInformation.ApplicationBase)
        Console.WriteLine("Configuration file is: " + domain.SetupInformation.ConfigurationFile)

        ' Unloads the application domain.
        AppDomain.Unload(domain)
    End Sub
End Class
'</snippet3>
