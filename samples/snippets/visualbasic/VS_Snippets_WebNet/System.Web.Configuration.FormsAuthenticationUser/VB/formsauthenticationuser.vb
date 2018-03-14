
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web.Security



' Accesses the
' System.Web.Configuration.FormsAuthenticationUser members
' selected by the user.

Class UsingFormsAuthenticationUser
   
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnet")
      ' Get the section.
        Dim authenticationSection _
        As AuthenticationSection = _
        CType(configuration.GetSection( _
        "system.web/authentication"), AuthenticationSection)
      ' Get the users collection.
        Dim formsAuthenticationUsers _
        As FormsAuthenticationUserCollection = _
        authenticationSection.Forms.Credentials.Users
      
      ' </Snippet1>

      ' <Snippet3>
      ' Define the user name.
      Dim name As String = "userName"
      ' Define the encrypted password.
        Dim password As String = _
        "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8"
      
      ' Create a new FormsAuthenticationUser object.
        Dim newformsAuthenticationUser _
        As New FormsAuthenticationUser(name, password)
      
      ' </Snippet3>
      ' <Snippet4> 
      ' Using the Password property.
      ' Get current password.
        Dim currentPassword As String = _
        formsAuthenticationUsers(0).Password
      
      ' Set a SHA1 encrypted password.
        formsAuthenticationUsers(0).Password = _
        "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8"
      
      ' </Snippet4>
      ' <Snippet5>
      ' Using the Name property.
      ' Get current name.
        Dim currentName As String = _
        formsAuthenticationUsers(0).Name
      
      ' Set a new name.
      formsAuthenticationUsers(0).Name = "userName"
        ' </Snippet5>

    End Sub 'Main 
End Class 'UsingFormsAuthenticationUser 


