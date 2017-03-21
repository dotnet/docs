Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingRoleManagerSection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As System.Web.Configuration.RoleManagerSection = _
         CType(config.GetSection("system.web/roleManager"), _
         System.Web.Configuration.RoleManagerSection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", config.FilePath)
        Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name)

        ' Display CacheRolesInCookie property.
        Console.WriteLine("CacheRolesInCookie: {0}", _
         configSection.CacheRolesInCookie)

        ' Set CacheRolesInCookie property.
        configSection.CacheRolesInCookie = False

        ' Display CookieName property.
        Console.WriteLine("CookieName: {0}", configSection.CookieName)

        ' Set CookieName property.
        configSection.CookieName = ".ASPXROLES"

        ' Display CookiePath property.
        Console.WriteLine("CookiePath: {0}", configSection.CookiePath)

        ' Set CookiePath property.
        configSection.CookiePath = "/"

        ' Display CookieProtection property.
        Console.WriteLine("CookieProtection: {0}", _
         configSection.CookieProtection)

        ' Set CookieProtection property.
        configSection.CookieProtection = _
         System.Web.Security.CookieProtection.All

        ' Display CookieRequireSSL property.
        Console.WriteLine("CookieRequireSSL: {0}", _
         configSection.CookieRequireSSL)

        ' Set CookieRequireSSL property.
        configSection.CookieRequireSSL = False

        ' Display CookieSlidingExpiration property.
        Console.WriteLine("CookieSlidingExpiration: {0}", _
         configSection.CookieSlidingExpiration)

        ' Set CookieSlidingExpiration property.
        configSection.CookieSlidingExpiration = True

        ' Display CookieTimeout property.
        Console.WriteLine("CookieTimeout: {0}", configSection.CookieTimeout)

        ' Set CookieTimeout property.
        configSection.CookieTimeout = TimeSpan.FromMinutes(30)

        ' Display CreatePersistentCookie property.
        Console.WriteLine("CreatePersistentCookie: {0}", _
         configSection.CreatePersistentCookie)

        ' Set CreatePersistentCookie property.
        configSection.CreatePersistentCookie = False

        ' Display DefaultProvider property.
        Console.WriteLine("DefaultProvider: {0}", _
         configSection.DefaultProvider)

        ' Set DefaultProvider property.
        configSection.DefaultProvider = "AspNetSqlRoleProvider"

        ' Display Domain property.
        Console.WriteLine("Domain: {0}", configSection.Domain)

        ' Set Domain property.
        configSection.Domain = ""

        ' Display Enabled property.
        Console.WriteLine("Enabled: {0}", configSection.Enabled)

        ' Set CookieName property.
        configSection.Enabled = False

        ' Display the number of Providers
        Console.WriteLine("Providers Collection Count: {0}", _
         configSection.Providers.Count)

        ' Display elements of the Providers collection property.
        For Each providerItem As ProviderSettings In configSection.Providers()
          Console.WriteLine()
          Console.WriteLine("Provider Details:")
          Console.WriteLine("Name: {0}", providerItem.Name)
          Console.WriteLine("Type: {0}", providerItem.Type)
        Next

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

      ' Display and wait
      Console.ReadLine()
    End Sub
  End Class
End Namespace