// <Internal>
// This program contains snippets applicable to the following:
// System.Net.AuthenticationManger (Snippet1);  
// System.Net.AuthenticationManger.Register (Snippet2);
// System.Net.AuthenticationUnregister (Snippet2);    
// System.Net.AuthenticationManger.RegisteredModules (Snippet8);  
// System.Net.Authorization.Authorization (Snippet3); 
// System.Net.Authorization.Message (Snippet5);  
// System.Net.Authorization.Complete (Snippet5);  
// System.Net.Authorization.GroupId (Snippet5);  
// System.Net.IAuthenticationModule (Snippet6);  
// System.Net.IAuthenticationModule.AuthenticationType (Snippet7);  
// System.Net.IAuthenticationModule.CanPreAuthenticate (Snippet7);  
// System.Net.IAuthenticationModule.Authenticate (Snippet3);  
// System.Net.IAuthenticationModule.PreAuthenticate (Snippet4);  
// </Internal>

//<Snippet1>

// The following example shows how to create a custom Basic authentication module,
// how to register it using the AuthenticationManager class and how to authorize  
// users to access a Web site.
// Note: To run this program you must create a test Web site that performs
// Basic authentication. Also you must add to your server machine a user whose
// credentials are the same as the ones you use in this program.
// Attention: Basic authentication sends the user's credentials over HTTP. 
// Passwords and user names are encoded using Base64 encoding. Although the 
// user information is encoded, it is considered insecure becasue it could be deciphered 
// relatively easily. 
// If you must use Basic authentication you are strongly advised to use strong 
// security mechanisms, such as SSL, when transferring sensitive information.


using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections;


namespace Mssc.Services.Authentication
{
  // The ClientAuthentication class performs the following main tasks:
  // 1) Obtains the user's credentials.
  // 2) Unregisters the standard Basic authentication.
  // 3) Registers the custom Basic authentication.
  // 4) Reads the selected page and displays it on the console.
  class TestAuthentication 
  {

    private static string username, password, domain, uri;

    // This method invoked when the user does not enter the required input parameters.
    private static void showusage() 
    {
      Console.WriteLine("Attempts to authenticate to a URL");
      Console.WriteLine("\r\nUse one of the following:");
      Console.WriteLine("\tcustomBasicAuthentication URL username password domain");
      Console.WriteLine("\tcustomBasicAuthentication URL username password");
    }

// <Snippet8>
    // Display registered authentication modules.
    private static void displayRegisteredModules() 
    {
      // The AuthenticationManager calls all authentication modules sequentially 
      // until one of them responds with an authorization instance.  Show
      // the current registered modules.
      IEnumerator registeredModules = AuthenticationManager.RegisteredModules; 
      Console.WriteLine("\r\nThe following authentication modules are now registered with the system:");
      while(registeredModules.MoveNext())
      {
        Console.WriteLine("\r \n Module : {0}",registeredModules.Current); 
        IAuthenticationModule currentAuthenticationModule = (IAuthenticationModule)registeredModules.Current;
        Console.WriteLine("\t  CanPreAuthenticate : {0}",currentAuthenticationModule.CanPreAuthenticate); 
      }      
    }
// </Snippet8>

    // The getPage method accesses the selected page and displays its content 
    // on the console.
    private static void getPage(String url) 
    {
      try 
      {
        // Create the Web request object.
        HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
        
        // Define the request access method.
        req.Method = "GET";
        
        // Define the request credentials according to the user's input.
        if (domain == String.Empty)
          req.Credentials = new NetworkCredential(username, password);
        else
          // If the user does not specify the Internet resource domain, this usually
          // is by default the name of the sever hosting the resource.
          req.Credentials = new NetworkCredential(username, password, domain);

        // Issue the request.
        HttpWebResponse result = (HttpWebResponse) req.GetResponse();

        Console.WriteLine("\nAuthentication Succeeded:");

        // Store the response.
        Stream sData = result.GetResponseStream();

        // Display the response.
        displayPageContent(sData);
      }
      catch (WebException e)
      {
        // Display any errors. In particular, display any protocol-related error. 
        if (e.Status == WebExceptionStatus.ProtocolError)
        {                
          HttpWebResponse hresp = (HttpWebResponse) e.Response;
          Console.WriteLine("\nAuthentication Failed, " + hresp.StatusCode);
          Console.WriteLine("Status Code: " + (int) hresp.StatusCode);
          Console.WriteLine("Status Description: " + hresp.StatusDescription);                
          return;
        }
        Console.WriteLine("Caught Exception: " + e.Message);
        Console.WriteLine("Stack: " + e.StackTrace);
      }
    }

    // The displayPageContent method display the content of the
    // selected page.
    private static void displayPageContent(Stream ReceiveStream) 
    {
      // Create an ASCII encoding object.
      Encoding ASCII = Encoding.ASCII;
    
      // Define the byte array to temporarily hold the current read bytes. 
      Byte[] read = new Byte[512];

      Console.WriteLine("\r\nPage Content...\r\n");

      // Read the page content and display it on the console.
      // Read the first 512 bytes.
      int bytes = ReceiveStream.Read(read, 0, 512);
      while (bytes > 0) 
      {
        Console.Write(ASCII.GetString(read, 0, bytes));
        bytes = ReceiveStream.Read(read, 0, 512);
      }
      Console.WriteLine("");
    }

// <Snippet2>
    // This is the program entry point. It allows the user to enter 
    // her credentials and the Internet resource (Web page) to access.
    // It also unregisters the standard and registers the customized Basic 
    // authentication.
    public static void Main(string[] args) 
    {
    
      if (args.Length < 3)
        showusage();
      else 
      {    
         
        // Read the user's credentials.
        uri = args[0];
        username = args[1];
        password = args[2];

        if (args.Length == 3)
          domain = string.Empty;
        else
          // If the domain exists, store it. Usually the domain name
          // is by default the name of the server hosting the Internet
          // resource.
          domain = args[3];

      
        // Instantiate the custom Basic authentication module.
        CustomBasic customBasicModule = new CustomBasic();
           
        // Unregister the standard Basic authentication module.
        AuthenticationManager.Unregister("Basic");

        // Register the custom Basic authentication module.
        AuthenticationManager.Register(customBasicModule);
 
        // Display registered authorization modules.
        displayRegisteredModules();
        
        // Read the specified page and display it on the console.
        getPage(uri);
      }
      return;
    }
//</Snippet2>
  }
 
// <Snippet6>
  // The CustomBasic class creates a custom Basic authentication by implementing the
  // IAuthenticationModule interface. It performs the following
  // tasks:
  // 1) Defines and initializes the required properties.
  // 2) Implements the Authenticate method.
  
  public class CustomBasic : IAuthenticationModule
  {

// <Snippet7>
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
// </Snippet7>

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

// <Snippet4> 
    // The PreAuthenticate method specifies whether the authentication implemented 
    // by this class allows pre-authentication. 
    // Even if you do not use it, this method must be implemented to obey to the rules 
    // of interface implementation.
    // In this case it always returns null. 
    public Authorization PreAuthenticate(WebRequest request, ICredentials credentials) 
    {                
      return null;
    }
// </Snippet4>

// <Snippet3>
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

// <Snippet5> 
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
// </Snippet5>

      Console.WriteLine("\n Authorization ConnectionGroupId:{0}",resourceAuthorization.ConnectionGroupId);


      return resourceAuthorization;
    }
// </Snippet3>
  }
// </Snippet6>
}
// </Snippet1>
