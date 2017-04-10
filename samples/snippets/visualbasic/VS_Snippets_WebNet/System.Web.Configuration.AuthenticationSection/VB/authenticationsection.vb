
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web




Class UsingAuthenticationSection
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the section.
        Dim authenticationSection _
        As AuthenticationSection = _
        CType(configuration.GetSection( _
        "system.web/authentication"), AuthenticationSection)
      
      ' </Snippet1>
      
      ' <Snippet2>
        Dim newauthenticationSection _
        As New AuthenticationSection()
      
      ' </Snippet2>
      
      ' <Snippet3>
      ' Get the current Passport property.
        Dim currentPassport _
        As PassportAuthentication = _
        authenticationSection.Passport
      
      ' Get the Passport redirect URL.
        Dim passRedirectUrl As String = _
        currentPassport.RedirectUrl
      
      ' </Snippet3>
      
      ' <Snippet4>
      ' Get the current Mode property.
        Dim currentMode As AuthenticationMode = _
        authenticationSection.Mode
      
      ' Set the Mode property to Windows.
        authenticationSection.Mode = _
        AuthenticationMode.Windows
      
      ' </Snippet4>
      
      ' <Snippet5>
      ' Get the current Forms property.
        Dim currentForms _
        As FormsAuthenticationConfiguration = _
        authenticationSection.Forms
      
      ' Get the Forms attributes.
        Dim name As String = _
        currentForms.Name
        Dim login As String = _
        currentForms.LoginUrl
        Dim path As String = _
        currentForms.Path
        Dim cookieLess As HttpCookieMode = _
        currentForms.Cookieless
        Dim requireSSL As Boolean = _
        currentForms.RequireSSL
        Dim slidingExpiration As Boolean = _
        currentForms.SlidingExpiration
        Dim enableXappRedirect As Boolean = _
        currentForms.EnableCrossAppRedirects
      
        Dim timeout As TimeSpan = _
        currentForms.Timeout
        Dim protection As FormsProtectionEnum = _
        currentForms.Protection
        Dim defaultUrl As String = _
        currentForms.DefaultUrl
        Dim domain As String = _
        currentForms.Domain
        ' </Snippet5>

   End Sub 'Main 
End Class 'UsingAuthenticationSection 


