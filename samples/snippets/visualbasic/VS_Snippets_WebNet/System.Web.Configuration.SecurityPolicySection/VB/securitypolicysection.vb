' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingSecurityPolicySection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath)

                ' Get the section-related object.
        Dim configSection As System.Web.Configuration.SecurityPolicySection = _
         CType(config.GetSection("system.web/securityPolicy"), _
         System.Web.Configuration.SecurityPolicySection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath)
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name)

                ' Display the number of trust levels.
        Console.WriteLine("TrustLevels Collection Count: {0}", _
          configSection.TrustLevels.Count)

        ' <Snippet2>
        ' Display elements of the TrustLevels collection property.
        For i As Integer = 0 To (configSection.TrustLevels.Count - 1)
          Console.WriteLine()
          Console.WriteLine("TrustLevel {0}:", i)
          Console.WriteLine("Name: {0}", _
           configSection.TrustLevels.Get(i).Name)
          Console.WriteLine("Type: {0}", _
           configSection.TrustLevels.Get(i).PolicyFile)
        Next i

        ' Add a TrustLevel element to the configuration file.
        configSection.TrustLevels.Add(New TrustLevel("myTrust", "mytrust.config"))
        ' </Snippet2>

        ' Update if not locked.
        If Not configSection.SectionInformation.IsLocked Then
          config.Save()
          Console.WriteLine("** Configuration updated.")
        Else
                    Console.WriteLine("** Could not update; section is locked.")
        End If

      Catch e As Exception
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try

      ' Display and wait
      Console.ReadLine()
    End Sub
  End Class
End Namespace
' </Snippet1>