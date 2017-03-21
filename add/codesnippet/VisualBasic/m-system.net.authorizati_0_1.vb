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