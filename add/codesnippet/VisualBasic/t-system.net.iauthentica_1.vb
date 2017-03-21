    ' The CustomBasic class creates a custom Basic authentication by implementing the
    ' IAuthenticationModule interface. It performs the following
    ' tasks:
    ' 1) Defines and initializes the required properties.
    ' 2) Implements the Authenticate and PreAuthenticate methods.

    Public Class CustomBasic
      Implements IAuthenticationModule

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


      ' The PreAuthenticate method specifies whether the authentication implemented 
      ' by this class allows pre-authentication. 
      ' Even if you do not use it, this method must be implemented to obey to the rules 
      ' of interface implementation.
      ' In this case it always returns null. 
      Public Function PreAuthenticate(ByVal request As WebRequest, ByVal credentials As ICredentials) As Authorization _
          Implements IAuthenticationModule.PreAuthenticate

        Return Nothing
      End Function 'PreAuthenticate

      
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


        Return resourceAuthorization
      End Function 'Authenticate
    End Class 'CustomBasic 