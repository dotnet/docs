 ' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Configuration
Imports System.Configuration



Class UsingAnonymousIdentificationSection
   

    Public Overloads Shared Sub Main(ByVal args() As String)

        ' <Snippet2>
        ' Get the applicaqtion configuration.
        Dim configuration _
        As Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the section.
        Dim anonymousIdentificationSection _
        As AnonymousIdentificationSection = _
        CType(configuration.GetSection( _
        "system.web/anonymousIdentification"), _
        AnonymousIdentificationSection)
        ' </Snippet2>

        ' <Snippet3>
        ' Get Cookieless.
        Dim cookieless _
        As System.Web.HttpCookieMode = _
        anonymousIdentificationSection.Cookieless
        Console.WriteLine("Cookieless: {0}", cookieless)
        ' </Snippet3>

        ' <Snippet4>
        ' Get CookieName.
        Dim cookieName As String = _
        anonymousIdentificationSection.CookieName
        Console.WriteLine("Cookie name: {0}", cookieName)
        ' </Snippet4>

        ' <Snippet5>
        ' Get CookiePath.
        Dim cookiePath As String = _
        anonymousIdentificationSection.CookiePath
        Console.WriteLine("Cookie path: {0}", cookiePath)
        ' </Snippet5>

        ' <Snippet6>
        ' Get CookieProtection.
        Dim cookieProtection _
        As System.Web.Security.CookieProtection = _
        anonymousIdentificationSection.CookieProtection
        Console.WriteLine( _
        "Cookie protection: {0}", cookieProtection)
        ' </Snippet6>

        ' <Snippet7>
        ' Get CookieRequireSSL.
        Dim cookieRequireSSL As Boolean = _
        anonymousIdentificationSection.CookieRequireSSL
        Console.WriteLine("Cookie require SSL: {0}", _
        cookieRequireSSL.ToString())
        ' </Snippet7>

        ' <Snippet8>
        ' Get CookieSlidingExpiration.
        Dim cookieSlidingExpiration As Boolean = _
        anonymousIdentificationSection.CookieSlidingExpiration
        Console.WriteLine( _
        "Cookie sliding expiration: {0}", _
        cookieSlidingExpiration.ToString())
        ' </Snippet8>

        ' <Snippet9>
        ' Get CookieTimeout.
        Dim cookieTimeout As TimeSpan = _
        anonymousIdentificationSection.CookieTimeout
        Console.WriteLine( _
        "Cookie timeout: {0}", cookieTimeout.ToString())
        ' </Snippet9>

        ' <Snippet10>
        ' Get Domain.
        Dim domain As String = _
        anonymousIdentificationSection.Domain
        Console.WriteLine( _
        "Anonymous identification domain: {0}", domain)
        ' </Snippet10>

        ' <Snippet11>
        ' Get Enabled.
        Dim aIdEnabled As Boolean = _
        anonymousIdentificationSection.Enabled
        Console.WriteLine("Anonymous identification enabled: {0}", _
        aIdEnabled.ToString())
        ' </Snippet11>

    End Sub 'Main
End Class 'UsingAnonymousIdentificationSection 


' </Snippet1>