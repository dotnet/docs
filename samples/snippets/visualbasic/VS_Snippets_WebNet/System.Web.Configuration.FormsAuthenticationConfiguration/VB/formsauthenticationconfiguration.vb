Imports System
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web





Class UsingFormsAuthentication
   
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the external Authentication section.
        Dim authenticationSection _
        As AuthenticationSection = _
        CType(configuration.GetSection( _
        "system.web/authentication"), AuthenticationSection)
      
      ' Get the external Forms section .
        Dim formsAuthentication _
        As FormsAuthenticationConfiguration = _
        authenticationSection.Forms
      
      '</Snippet1>
      
      ' <Snippet2>
      ' Create a new FormsAuthentication object.
        Dim newformsAuthentication _
        As New FormsAuthenticationConfiguration()
      
      ' </Snippet2>
      
      
      ' <Snippet3>
      ' Get the current LoginUrl.
        Dim currentLoginUrl As String = _
        formsAuthentication.LoginUrl
      
      ' Set the LoginUrl. 
      formsAuthentication.LoginUrl = "newLoginUrl"
      
      ' </Snippet3>
      
      ' <Snippet4>
      ' Get current DefaultUrl.
        Dim currentDefaultUrl As String = _
        formsAuthentication.DefaultUrl
      
      ' Set current DefaultUrl.
      formsAuthentication.DefaultUrl = "newDefaultUrl"
      
      ' </Snippet4>
      
      ' <Snippet5>
      ' Get current Cookieless.
        Dim currentCookieless _
        As System.Web.HttpCookieMode = _
        formsAuthentication.Cookieless
      
      ' Set current Cookieless.
      formsAuthentication.Cookieless = HttpCookieMode.AutoDetect
      
      ' </Snippet5>
      
      ' <Snippet6>
      ' Get the current Domain.
      Dim currentDomain As String = formsAuthentication.Domain
      
      ' Set the current Domain
      formsAuthentication.Domain = "newDomain"
      
      
      ' </Snippet6>
      
      ' <Snippet7>
      ' Get the current SlidingExpiration.
        Dim currentSlidingExpiration As Boolean = _
        formsAuthentication.SlidingExpiration
      
      ' Set the SlidingExpiration.
      formsAuthentication.SlidingExpiration = False
      
      
      ' </Snippet7>
      
      ' <Snippet8>
      ' Get the current EnableCrossAppRedirects.
        Dim currentEnableCrossAppRedirects As Boolean = _
        formsAuthentication.EnableCrossAppRedirects
      
      ' Set the EnableCrossAppRedirects.
      formsAuthentication.EnableCrossAppRedirects = False
      
      
      ' </Snippet8>
      
      ' <Snippet9>
      ' Get the current Path.
      Dim currentPath As String = formsAuthentication.Path
      ' Set the Path property.
      formsAuthentication.Path = "newPath"
      
      ' </Snippet9>
      ' <Snippet10>
      ' Get the current Timeout.
        Dim currentTimeout As System.TimeSpan = _
        formsAuthentication.Timeout
      
      ' Set the Timeout.
        formsAuthentication.Timeout = _
        System.TimeSpan.FromMinutes(10)
      
      ' </Snippet10>
      
      ' <Snippet11>
      ' Get the current Protection.
        Dim currentProtection As FormsProtectionEnum = _
        formsAuthentication.Protection
      
      ' Set the Protection property.
      formsAuthentication.Protection = FormsProtectionEnum.All
      
      ' </Snippet11>
      
      ' <Snippet12>
      ' Get the current RequireSSL.
        Dim currentRequireSSL As Boolean = _
        formsAuthentication.RequireSSL
      
      ' Set the RequireSSL property value.
      formsAuthentication.RequireSSL = True
      
      ' </Snippet12>
      
      ' <Snippet13>
      ' Get the current Name property value.
        Dim currentName As String = _
        formsAuthentication.Name
      ' Set the Name property value.
      formsAuthentication.Name = "newName"
      
      
      ' </Snippet13>
      
      ' <Snippet14>
      ' Get the current Credentials.
        Dim currentCredentials _
        As FormsAuthenticationCredentials = _
        formsAuthentication.Credentials
      
      Dim credentials As New StringBuilder()
      ' Get all the credentials.
      Dim i As System.Int32
      For i = 0 To currentCredentials.Users.Count - 1
            credentials.Append(("Name: " + _
            currentCredentials.Users(i).Name + _
            " Password: " + _
            currentCredentials.Users(i).Password))
         credentials.Append(Environment.NewLine)
        Next i
        ' </Snippet14>

    End Sub 'Main 
End Class 'UsingFormsAuthentication

