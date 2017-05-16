Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  ' Accesses the System.Web.Configuration.HttpCookiesSection
  ' members selected by the user.
  Class UsingHttpCookiesSection
    Public Shared Sub Main()

      '<Snippet1>

            ' Get the Web application configuration.
            Dim webConfig _
            As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

            ' Get the section.
            Dim configPath As String _
            = "system.web/httpCookies"

            Dim httpCookiesSection _
            As System.Web.Configuration.HttpCookiesSection = _
            CType(webConfig.GetSection(configPath), _
            System.Web.Configuration.HttpCookiesSection)
           
      ' </Snippet1>

      '<Snippet5>
            Dim cookiesSection _
            As System.Web.Configuration.HttpCookiesSection = _
            New System.Web.Configuration.HttpCookiesSection()

      '</Snippet5>

      ' <Snippet2>

            ' Get the current Domain.
            Dim domainValue As String = _
            httpCookiesSection.Domain
            ' Set the Domain property.
            httpCookiesSection.Domain = _
            String.Empty

      ' </Snippet2>

      ' <Snippet3>

            ' Get the current RequireSSL.
            Dim requireSSLValue As Boolean = _
            httpCookiesSection.RequireSSL

            ' Set the RequireSSL.
            httpCookiesSection.RequireSSL = _
            False

      ' </Snippet3>

      ' <Snippet4>

            ' Get the current HttpOnlyCookies.
            Dim httpOnlyCookiesValue As Boolean = _
            httpCookiesSection.HttpOnlyCookies

            ' Set the HttpOnlyCookies.
            httpCookiesSection.HttpOnlyCookies = _
            False

      ' </Snippet4>

    End Sub

  End Class ' UsingHttpCookiesSection.
    
End Namespace ' Samples.Aspnet.SystemWebConfiguration
