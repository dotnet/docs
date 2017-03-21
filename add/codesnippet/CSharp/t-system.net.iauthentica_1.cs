  // The CustomBasic class creates a custom Basic authentication by implementing the
  // IAuthenticationModule interface. It performs the following
  // tasks:
  // 1) Defines and initializes the required properties.
  // 2) Implements the Authenticate method.
  
  public class CustomBasic : IAuthenticationModule
  {

    private string m_authenticationType ;
    private bool m_canPreAuthenticate ;

    // The CustomBasic constructor initializes the properties of the customized 
    // authentication.
    public CustomBasic()
    {
      m_authenticationType = "Basic";
      m_canPreAuthenticate = false;
    }

    // Define the authentication type. This type is then used to identify this
    // custom authentication module. The default is set to Basic.
    public string AuthenticationType
    {
      get
      {
        return m_authenticationType;
      }
    }

    // Define the pre-authentication capabilities for the module. The default is set
    // to false.
    public bool CanPreAuthenticate
    {
      get
      {
        return m_canPreAuthenticate;
      }
    }

    // The checkChallenge method checks whether the challenge sent by the HttpWebRequest 
    // contains the correct type (Basic) and the correct domain name. 
    // Note: The challenge is in the form BASIC REALM="DOMAINNAME"; 
    // the Internet Web site must reside on a server whose
    // domain name is equal to DOMAINNAME.
    public bool checkChallenge(string Challenge, string domain) 
    {
      bool challengePasses = false;

      String tempChallenge = Challenge.ToUpper();

      // Verify that this is a Basic authorization request and that the requested domain
      // is correct.
      // Note: When the domain is an empty string, the following code only checks 
      // whether the authorization type is Basic.

      if (tempChallenge.IndexOf("BASIC") != -1)
        if (domain != String.Empty)
          if (tempChallenge.IndexOf(domain.ToUpper()) != -1)
            challengePasses = true;
          else
            // The domain is not allowed and the authorization type is Basic.
            challengePasses = false;
        else
          // The domain is a blank string and the authorization type is Basic.
          challengePasses = true;

      return challengePasses;
    }

    // The PreAuthenticate method specifies whether the authentication implemented 
    // by this class allows pre-authentication. 
    // Even if you do not use it, this method must be implemented to obey to the rules 
    // of interface implementation.
    // In this case it always returns null. 
    public Authorization PreAuthenticate(WebRequest request, ICredentials credentials) 
    {                
      return null;
    }

    // Authenticate is the core method for this custom authentication.
    // When an Internet resource requests authentication, the WebRequest.GetResponse 
    // method calls the AuthenticationManager.Authenticate method. This method, in 
    // turn, calls the Authenticate method on each of the registered authentication
    // modules, in the order in which they were registered. When the authentication is 
    // complete an Authorization object is returned to the WebRequest.
    public Authorization Authenticate(String challenge, WebRequest request, ICredentials credentials) 
    {
      Encoding ASCII = Encoding.ASCII;        

      // Get the username and password from the credentials
      NetworkCredential MyCreds = credentials.GetCredential(request.RequestUri, "Basic");        

      if (PreAuthenticate(request, credentials) == null)
        Console.WriteLine("\n Pre-authentication is not allowed.");
      else
        Console.WriteLine("\n Pre-authentication is allowed.");

      // Verify that the challenge satisfies the authorization requirements.
      bool challengeOk = checkChallenge(challenge, MyCreds.Domain);

      if (!challengeOk)
        return null;

      // Create the encrypted string according to the Basic authentication format as
      // follows:
      // a)Concatenate the username and password separated by colon;
      // b)Apply ASCII encoding to obtain a stream of bytes;
      // c)Apply Base64 encoding to this array of bytes to obtain the encoded 
      // authorization.
      string BasicEncrypt = MyCreds.UserName + ":" + MyCreds.Password;

      string BasicToken = "Basic " + Convert.ToBase64String(ASCII.GetBytes(BasicEncrypt));

      // Create an Authorization object using the encoded authorization above.
      Authorization resourceAuthorization = new Authorization(BasicToken);

      // Get the Message property, which contains the authorization string that the 
      // client returns to the server when accessing protected resources.
      Console.WriteLine("\n Authorization Message:{0}",resourceAuthorization.Message);

      // Get the Complete property, which is set to true when the authentication process 
      // between the client and the server is finished.
      Console.WriteLine("\n Authorization Complete:{0}",resourceAuthorization.Complete);

      Console.WriteLine("\n Authorization ConnectionGroupId:{0}",resourceAuthorization.ConnectionGroupId);


      return resourceAuthorization;
    }
  }