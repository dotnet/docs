' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingMembershipSection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As System.Web.Configuration.MembershipSection = _
         CType(config.GetSection("system.web/membership"), _
         System.Web.Configuration.MembershipSection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", _
         config.FilePath)
        Console.WriteLine("Section Path: {0}", _
         configSection.SectionInformation.Name)

        ' <Snippet2>
        ' Display Default Provider.
        Console.WriteLine("DefaultProvider: {0}", _
         configSection.DefaultProvider)
        ' </Snippet2>

        ' Set Default Provider.
        configSection.DefaultProvider = _
         "AspNetSqlRoleProvider"

        ' <Snippet3>
        ' Display HashAlgorithmType value.
        Console.WriteLine("HashAlgorithmType: {0}", _
         configSection.HashAlgorithmType)
        ' </Snippet3>

        ' Set HashAlgorithmType value.
        configSection.HashAlgorithmType = _
         MachineKeyValidation.SHA1.ToString()

        ' <Snippet4>
        ' Display UserIsOnlineTimeWindow value.
        Console.WriteLine("UserIsOnlineTimeWindow: {0}", _
         configSection.UserIsOnlineTimeWindow)
        ' </Snippet4>

        ' Set UserIsOnlineTimeWindow value.
        configSection.UserIsOnlineTimeWindow = _
         TimeSpan.FromMinutes(15)

        ' Display the number of Providers.
        Console.WriteLine("Providers Collection Count: {0}", _
         configSection.Providers.Count)

        ' <Snippet5>
        ' Display elements of the Providers collection property.
        For Each providerItem As ProviderSettings In configSection.Providers()
          Console.WriteLine()
          Console.WriteLine("Provider Details:")
          Console.WriteLine("Name: {0}", providerItem.Name)
          Console.WriteLine("Type: {0}", providerItem.Type)
        Next
        ' </Snippet5>

        ' Update if not locked.
        If Not configSection.SectionInformation.IsLocked Then
          config.Save()
          Console.WriteLine("** Configuration updated.")
        Else
          Console.WriteLine("** Could not update, section is locked.")
        End If

      Catch e As Exception
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try

      ' Display and wait.
      Console.ReadLine()
    End Sub
  End Class
End Namespace
' </Snippet1>