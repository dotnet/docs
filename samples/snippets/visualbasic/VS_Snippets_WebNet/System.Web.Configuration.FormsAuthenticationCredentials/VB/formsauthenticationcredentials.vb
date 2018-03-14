
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration




Class UsingFormsAuthenticationCredentials
   
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the authentication section.
        Dim authenticationSection _
        As AuthenticationSection = _
        CType(configuration.GetSection( _
        "system.web/authentication"), AuthenticationSection)
      
      ' Get the forms credentials collection .
        Dim formsAuthenticationCredentials _
        As FormsAuthenticationCredentials = _
        authenticationSection.Forms.Credentials
      
      ' </Snippet1>

        ' <Snippet2>
      ' Create a new FormsAuthenticationCredentials object.
        Dim newformsAuthenticationCredentials _
        As New FormsAuthenticationCredentials()
      
      ' </Snippet2>
      
      
      ' <Snippet3>
      ' Get the current PasswordFormat property value.
        Dim currentPasswordFormat _
        As FormsAuthPasswordFormat = _
        formsAuthenticationCredentials.PasswordFormat
      
      
      ' Set the PasswordFormat property value.
        formsAuthenticationCredentials.PasswordFormat = _
        FormsAuthPasswordFormat.SHA1
      
      ' </Snippet3>
      ' <Snippet4>
      ' Create a new FormsAuthenticationUserCollection object.
        Dim newformsAuthenticationUser _
        As New FormsAuthenticationUserCollection()
      
      ' </Snippet4>
      ' <Snippet5>
      ' Display all credentials collection elements.
      Dim credentials As New StringBuilder()
      Dim i As System.Int32
      For i = 0 To formsAuthenticationCredentials.Users.Count - 1
            credentials.Append(("User: " _
            + formsAuthenticationCredentials.Users(i).Name))
            credentials.Append(("Password: " _
            + formsAuthenticationCredentials.Users(i).Password))
         credentials.Append(Environment.NewLine)
      Next i
      ' </Snippet5>
      
      ' <Snippet6>
      ' Using method Add.
      ' Define the SHA1 encrypted password.
        Dim password As String = _
        "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8"
      ' Define the user name.
      Dim userName As String = "newUser"
      
      ' Create the new user.
        Dim currentUser _
        As New FormsAuthenticationUser(userName, password)
      
      ' Execute the Add method.
      formsAuthenticationCredentials.Users.Add(currentUser)
      
      ' Update if not locked
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If
      
      ' </Snippet6>
      
      ' <Snippet7>
      ' Using method Clear.
      formsAuthenticationCredentials.Users.Clear()
      ' Update if not locked
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If
      ' </Snippet7>
      
      ' <Snippet9>
      ' Using method Remove.
      ' Execute the Remove method.
      formsAuthenticationCredentials.Users.Remove("userName")
      
      ' Update if not locked
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If
      ' </Snippet9>
      ' <Snippet10>
      ' Using method RemoveAt.
      formsAuthenticationCredentials.Users.RemoveAt(0)
      
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If
      ' </Snippet10>
      
      ' <Snippet11>
      ' Using method Set.
      ' Define the SHA1 encrypted password.
        Dim newPassword As String = _
        "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8"
      ' Define the user name.
      Dim currentUserName As String = "userName"
      
      ' Create the new user.
        Dim theUser _
        As New FormsAuthenticationUser(currentUserName, newPassword)
      
      formsAuthenticationCredentials.Users.Set(theUser)
      
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If
      ' </Snippet11>
      ' <Snippet12>
      ' Get the user with the specified name.
        Dim storedUser As FormsAuthenticationUser = _
        formsAuthenticationCredentials.Users.Get("userName")
      
      ' </Snippet12>
      ' <Snippet13>
      ' Get the user at the specified index.
        Dim storedUser2 As FormsAuthenticationUser = _
        formsAuthenticationCredentials.Users.Get(0)
      
      ' </Snippet13>
      ' <Snippet14>
      ' Get the key at the specified index.
        Dim thisKey As String = _
        formsAuthenticationCredentials.Users.GetKey(0)
      
      ' </Snippet14>
      ' <Snippet15>
      ' Get the user element at the specified index.
        Dim storedUser3 As FormsAuthenticationUser = _
        formsAuthenticationCredentials.Users(0)
      
      ' </Snippet15>
      ' <Snippet16>
      ' Get the user element with the specified name.
        Dim storedUser4 As FormsAuthenticationUser = _
        formsAuthenticationCredentials.Users("userName")
      
      ' </Snippet16>
      ' <Snippet17>
      ' Get the collection keys.
        Dim keys As String() = _
        formsAuthenticationCredentials.Users.AllKeys
        ' </Snippet17>

    End Sub 'Main

End Class 'UsingFormsAuthenticationCredentials 





