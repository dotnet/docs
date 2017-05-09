'<Snippet1>
' The following example shows how to create a custom Basic authentication module,
' how to register it using the AuthenticationManager class and how to authorize  
' users to access a Web site.
' Note: To run this program you must create a test Web site that performs
' Basic authentication. Also you must add to your server machine a user whose
' credentials are the same as the ones you use in this program.
' Attention: Basic authentication sends the user's credentials over HTTP. 
' Passwords and user names are encoded using Base64 encoding. Although the 
' user information is encoded, it is considered insecure becasue it could be deciphered 
' relatively easily. 
' If you must use Basic authentication you are strongly advised to use strong 
' security mechanisms, such as SSL, when transferring sensitive information.


Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Collections
Imports Microsoft.VisualBasic

Namespace Mssc.Services.Authentication

  Module TestingAuthentication

    ' The ClientAuthentication class performs the following main tasks:
    ' 1) Obtains the user's credentials.
    ' 2) Unregisters the standard Basic authentication.
    ' 3) Registers the custom Basic authentication.
    ' 4) Reads the selected page and displays it on the console.

    Class TestAuthentication

      Private Shared username, password, domain, uri As String


      'This method invoked when the user does not enter the required input parameters.
      Private Shared Sub showusage()
        Console.WriteLine("Attempts to authenticate to a URL")
        Console.WriteLine(ControlChars.Cr + ControlChars.Lf + "Use one of the following:")
        Console.WriteLine(ControlChars.Tab + "customBasicAuthentication URL username password domain")
        Console.WriteLine(ControlChars.Tab + "customBasicAuthentication URL username password")
      End Sub 'showusage


      ' <Snippet8>
      ' Display registered authentication modules.
      Private Shared Sub displayRegisteredModules()
        ' The AuthenticationManager calls all authentication modules sequentially 
        ' until one of them responds with an authorization instance.  Show
        ' the current registered modules.
        Dim registeredModules As IEnumerator = AuthenticationManager.RegisteredModules
        Console.WriteLine(ControlChars.Cr + ControlChars.Lf + "The following authentication modules are now registered with the system:")
        While registeredModules.MoveNext()
          Console.WriteLine(ControlChars.Cr + " " + ControlChars.Lf + " Module : {0}", registeredModules.Current)
          Dim currentAuthenticationModule As IAuthenticationModule = CType(registeredModules.Current, IAuthenticationModule)
          Console.WriteLine(ControlChars.Tab + "  CanPreAuthenticate : {0}", currentAuthenticationModule.CanPreAuthenticate)
        End While
      End Sub 'displayRegisteredModules 

      ' </Snippet8>
      ' The getPage method accesses the selected page and displays its content 
      ' on the console.
      Private Shared Sub getPage(ByVal url As [String])
        Try
          ' Create the Web request object.
          Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)

          ' Define the request access method.
          req.Method = "GET"

          ' Define the request credentials according to the user's input.
          If domain = [String].Empty Then
            req.Credentials = New NetworkCredential(username, password)
            ' If the user does not specify the Internet resource domain, this usually
            ' is by default the name of the sever hosting the resource.
          Else
            req.Credentials = New NetworkCredential(username, password, domain)
          End If
          ' Issue the request.
          Dim result As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)

          Console.WriteLine(ControlChars.Lf + "Authentication Succeeded:")

          ' Store the response.
          Dim sData As Stream = result.GetResponseStream()

          ' Display the response.
          displayPageContent(sData)
        Catch e As WebException
          ' Display any errors. In particular, display any protocol-related error. 
          If e.Status = WebExceptionStatus.ProtocolError Then
            Dim hresp As HttpWebResponse = CType(e.Response, HttpWebResponse)
            Console.WriteLine((ControlChars.Lf + "Authentication Failed, " + hresp.StatusCode))
            Console.WriteLine(("Status Code: " + Fix(hresp.StatusCode)))
            Console.WriteLine(("Status Description: " + hresp.StatusDescription))
            Return
          End If
          Console.WriteLine(("Caught Exception: " + e.Message))
          Console.WriteLine(("Stack: " + e.StackTrace))
        End Try
      End Sub 'getPage


      ' The displayPageContent method display the content of the
      ' selected page.
      Private Shared Sub displayPageContent(ByVal ReceiveStream As Stream)
        ' Create an ASCII encoding object.
        Dim ASCII As Encoding = Encoding.ASCII

        ' Define the byte array to temporarily hold the current read bytes. 
        Dim read(511) As [Byte]

        Console.WriteLine(ControlChars.Cr + ControlChars.Lf + "Page Content..." + ControlChars.Cr + ControlChars.Lf)

        ' Read the page content and display it on the console.
        ' Read the first 512 bytes.
        Dim bytes As Integer = ReceiveStream.Read(read, 0, 512)
        While bytes > 0
          Console.Write(ASCII.GetString(read, 0, bytes))
          bytes = ReceiveStream.Read(read, 0, 512)
        End While
        Console.WriteLine("")
      End Sub 'displayPageContent

      'Entry point which delegates to C-style main Private Function
      'Public Overloads Sub Main(ByVal args() As String)
      ' Main(System.Environment.GetCommandLineArgs())
      'End Sub


      ' <Snippet2>
      ' This is the program entry point. It allows the user to enter 
      ' her credentials and the Internet resource (Web page) to access.
      ' It also unregisters the standard and registers the customized Basic 
      ' authentication.
      Public Shared Sub Main(ByVal args() As String)

        If args.Length < 3 Then
          showusage()
        Else

          ' Read the user's credentials.
          uri = args(0)
          username = args(1)
          password = args(2)

          If args.Length = 3 Then
            domain = String.Empty
            ' If the domain exists, store it. Usually the domain name
            ' is by default the name of the server hosting the Internet
            ' resource.
          Else
            domain = args(3)
          End If

          ' Instantiate the custom Basic authentication module.
          Dim customBasicModule As New CustomBasic()

          ' Unregister the standard Basic authentication module.
          AuthenticationManager.Unregister("Basic")

          ' Register the custom Basic authentication module.
          AuthenticationManager.Register(customBasicModule)

          ' Display registered authorization modules.
          displayRegisteredModules()

          ' Read the specified page and display it on the console.
          getPage(uri)
        End If
        Return
      End Sub 'Main

    End Class 'ClientAuthentication 
    '</Snippet2>

    ' <Snippet6>
    ' The CustomBasic class creates a custom Basic authentication by implementing the
    ' IAuthenticationModule interface. It performs the following
    ' tasks:
    ' 1) Defines and initializes the required properties.
    ' 2) Implements the Authenticate and PreAuthenticate methods.

    Public Class CustomBasic
      Implements IAuthenticationModule

      ' <Snippet7>
      Private m_authenticationType As String
      Private m_canPreAuthenticate As Boolean


      ' The CustomBasic constructor initializes the properties of the customized 
      ' authentication.
      Public Sub New()
        m_authenticationType = "Basic"
        m_canPreAuthenticate = False
      End Sub 'New

      ' Define the authentication type. This type is then used to identify this
      ' custom authentication module. The default is set to Basic.

      Public ReadOnly Property AuthenticationType() As String _
       Implements IAuthenticationModule.AuthenticationType

        Get
          Return m_authenticationType
        End Get
      End Property

      ' Define the pre-authentication capabilities for the module. The default is set
      ' to false.

      Public ReadOnly Property CanPreAuthenticate() As Boolean _
       Implements IAuthenticationModule.CanPreAuthenticate


        Get
          Return m_canPreAuthenticate
        End Get
      End Property

      ' </Snippet7>
    ' The checkChallenge method checks whether the challenge sent by the HttpWebRequest 
    ' contains the correct type (Basic) and the correct domain name. 
    ' Note: The challenge is in the form BASIC REALM="DOMAINNAME"; 
    ' the Internet Web site must reside on a server whose
    ' domain name is equal to DOMAINNAME.
      Public Function checkChallenge(ByVal Challenge As String, ByVal domain As String) As Boolean
        Dim challengePasses As Boolean = False

        Dim tempChallenge As [String] = Challenge.ToUpper()

        ' Verify that this is a Basic authorization request and that the requested domain
        ' is correct.
        ' Note: When the domain is an empty string, the following code only checks 
        ' whether the authorization type is Basic.
        If tempChallenge.IndexOf("BASIC") <> -1 Then
          If domain <> [String].Empty Then
            If tempChallenge.IndexOf(domain.ToUpper()) <> -1 Then
              challengePasses = True
              ' The domain is not allowed and the authorization type is Basic.
            Else
              challengePasses = False
            End If
            ' The domain is a blank string and the authorization type is Basic.
          Else
            challengePasses = True
          End If
        End If
        Return challengePasses
      End Function 'checkChallenge


      ' <Snippet4> 
      ' The PreAuthenticate method specifies whether the authentication implemented 
      ' by this class allows pre-authentication. 
      ' Even if you do not use it, this method must be implemented to obey to the rules 
      ' of interface implementation.
      ' In this case it always returns null. 
      Public Function PreAuthenticate(ByVal request As WebRequest, ByVal credentials As ICredentials) As Authorization _
          Implements IAuthenticationModule.PreAuthenticate

        Return Nothing
      End Function 'PreAuthenticate

      ' </Snippet4>
      
      ' <Snippet3>
      ' Authenticate is the core method for this custom authentication.
      ' When an Internet resource requests authentication, the WebRequest.GetResponse 
      ' method calls the AuthenticationManager.Authenticate method. This method, in 
      ' turn, calls the Authenticate method on each of the registered authentication
      ' modules, in the order in which they were registered. When the authentication is 
      ' complete an Authorization object is returned to the WebRequest.
      Public Function Authenticate(ByVal challenge As String, ByVal request As WebRequest, ByVal credentials As ICredentials) As Authorization _
          Implements IAuthenticationModule.Authenticate


        Dim ASCII As Encoding = Encoding.ASCII

        ' Get the username and password from the credentials
        Dim MyCreds As NetworkCredential = credentials.GetCredential(request.RequestUri, "Basic")

        If PreAuthenticate(request, credentials) Is Nothing Then
          Console.WriteLine(ControlChars.Lf + " Pre-authentication is not allowed.")
        Else
          Console.WriteLine(ControlChars.Lf + " Pre-authentication is allowed.")
        End If
        ' Verify that the challenge satisfies the authorization requirements.
        Dim challengeOk As Boolean = checkChallenge(challenge, MyCreds.Domain)

        If Not challengeOk Then
          Return Nothing
        End If
        ' <Snippet5> 

        ' Create the encrypted string according to the Basic authentication format as
        ' follows:
        ' a)Concatenate the username and password separated by colon;
        ' b)Apply ASCII encoding to obtain a stream of bytes;
        ' c)Apply Base64 encoding to this array of bytes to obtain the encoded 
        ' authorization.
        Dim BasicEncrypt As String = MyCreds.UserName + ":" + MyCreds.Password

        Dim BasicToken As String = "Basic " + Convert.ToBase64String(ASCII.GetBytes(BasicEncrypt))

        ' Create an Authorization object using the encoded authorization above.
        Dim resourceAuthorization As New Authorization(BasicToken)

        ' Get the Message property, which contains the authorization string that the 
        ' client returns to the server when accessing protected resources.
        Console.WriteLine(ControlChars.Lf + " Authorization Message:{0}", resourceAuthorization.Message)

        ' Get the Complete property, which is set to true when the authentication process 
        ' between the client and the server is finished.
        Console.WriteLine(ControlChars.Lf + " Authorization Complete:{0}", resourceAuthorization.Complete)

        Console.WriteLine(ControlChars.Lf + " Authorization ConnectionGroupId:{0}", resourceAuthorization.ConnectionGroupId)

        ' </Snippet5>

        Return resourceAuthorization
      End Function 'Authenticate
    End Class 'CustomBasic 
    ' </Snippet3>
    ' </Snippet6>
  End Module
End Namespace
' </Snippet1>
