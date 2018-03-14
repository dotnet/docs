Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web

Namespace Samples.AspNet
  Class UsingSessionStateSection
    Public Shared Sub Main()
      Try
        ' <Snippet1>
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the section.
        Dim sessionStateSection As System.Web.Configuration.SessionStateSection = _
        CType(configuration.GetSection("system.web/sessionState"), _
          System.Web.Configuration.SessionStateSection)
        ' </Snippet1>

        ' <Snippet2>
        ' Display the current AllowCustomSqlDatabase property value.
        Console.WriteLine("AllowCustomSqlDatabase: {0}", _
          sessionStateSection.AllowCustomSqlDatabase)
        ' </Snippet2>

        ' <Snippet3>
        ' Display the current RegenerateExpiredSessionId property value.
        Console.WriteLine("RegenerateExpiredSessionId: {0}", _
          sessionStateSection.RegenerateExpiredSessionId)
        ' </Snippet3>

        ' <Snippet4>
        ' Display the current CustomProvider property value.
        Console.WriteLine("CustomProvider: {0}", sessionStateSection.CustomProvider)
        ' </Snippet4>

        ' <Snippet5>
        ' Display the current CookieName property value.
        Console.WriteLine("CookieName: {0}", sessionStateSection.CookieName)
        ' </Snippet5>

        ' <Snippet6>
        ' Display the current StateNetworkTimeout property value.
        Console.WriteLine("StateNetworkTimeout: {0}", _
          sessionStateSection.StateNetworkTimeout)
        ' </Snippet6>

        ' <Snippet7>
        ' Display the current Cookieless property value.
        Console.WriteLine("Cookieless: {0}", sessionStateSection.Cookieless)
        ' </Snippet7>

        ' <Snippet8>
        ' Display the current SqlConnectionString property value.
        Console.WriteLine("SqlConnectionString: {0}", _
          sessionStateSection.SqlConnectionString)
        ' </Snippet8>

        ' <Snippet9>
        ' Display the current StateConnectionString property value.
        Console.WriteLine("StateConnectionString: {0}", _
          sessionStateSection.StateConnectionString)
        ' </Snippet9>

        ' <Snippet10>
        ' Display the current Providers property value.
        For Each providerItem As ProviderSettings In sessionStateSection.Providers()
          Console.WriteLine()
          Console.WriteLine("Provider Details:")
          Console.WriteLine("Name: {0}", providerItem.Name)
          Console.WriteLine("Type: {0}", providerItem.Type)
        Next
        ' </Snippet10>

        ' <Snippet11>
        ' Display the current Timeout property value.
        Console.WriteLine("Timeout: {0}", sessionStateSection.Timeout)
        ' </Snippet11>

        ' <Snippet13>
        ' Display the current SqlCommandTimeout property value.
        Console.WriteLine("SqlCommandTimeout: {0}", _
          sessionStateSection.SqlCommandTimeout)
        ' </Snippet13>

        ' <Snippet14>
        ' Display the current Mode property value.
        Console.WriteLine("Mode: {0}", sessionStateSection.Mode)
        ' </Snippet14>

      Catch e As System.ArgumentException
        ' Unknown error.
        Console.WriteLine("A invalid argument exception detected " & _
         "in UsingSessionStateSection Main. Check your command " & _
         "line for errors.")
      End Try
      Console.ReadLine()
    End Sub
  End Class   ' UsingSessionStateSection.
End Namespace ' Samples.Aspnet.SystemWebConfiguration


