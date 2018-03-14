// System.Net.Authorization.Authorization(string,bool);System.Net.Authorization.ProtectionRealm

/* This program demonstrates the 'ProtectionRealm' property and 'Authorization(string,bool)' constructor of 
   the "Authorization" class. The "IAuthenticationModule" interface is implemented in 'CloneBasic' to make
   it a custom authentication module. The custom authentication module encodes username and password as
   base64 strings and then returns back an 'Authorization' instance. The 'Authorization' instance encapsulates
   a list of Uri's for which it is applicable using the "ProtectionRealm" property.
 */
using System;
using System.Net;
using System.Text;

namespace CloneBasicAuthentication
{
    // The 'CloneBasic' authentication module class implements 'IAuthenticationModule'.
    class CloneBasic : IAuthenticationModule
    {
        private string m_authenticationType ;
        private bool m_canPreAuthenticate ;

        public CloneBasic()
        {
            m_authenticationType = "CloneBasic";
            m_canPreAuthenticate = false;
        }
        public string AuthenticationType
        {
            get{
                return m_authenticationType;
             }
        }
        public bool CanPreAuthenticate
        {
            get{
                return m_canPreAuthenticate;
            }
        }
// <Snippet1>
// <Snippet2>
        public Authorization Authenticate( string challenge,WebRequest request,ICredentials credentials)
        {
            try
            {
                string message;
                // Check if Challenge string was raised by a site which requires 'CloneBasic' authentication.
                if ((challenge == null) || (!challenge.StartsWith("CloneBasic")))
                    return null; 
                NetworkCredential myCredentials;
                if (credentials is CredentialCache)
                {
                    myCredentials = credentials.GetCredential(request.RequestUri,"CloneBasic");
                    if (myCredentials == null)
                        return null;
                }
                else    
                    myCredentials = (NetworkCredential)credentials;  
                // Message encryption scheme : 
                //   a)Concatenate username and password seperated by space;
                //   b)Apply ASCII encoding to obtain a stream of bytes;
                //   c)Apply Base64 Encoding to this array of bytes to obtain our encoded authorization message.
                 
                message = myCredentials.UserName + " " + myCredentials.Password;
                // Apply AsciiEncoding to 'message' string to obtain it as an array of bytes.
                Encoding ascii = Encoding.ASCII;
                byte[] byteArray = new byte[ascii.GetByteCount(message)];
                byteArray = ascii.GetBytes(message);

                // Performing Base64 transformation.
                message = Convert.ToBase64String(byteArray);
                Authorization myAuthorization = new Authorization("CloneBasic " + message,true);
                string[] protectionRealm = new string[]{request.RequestUri.AbsolutePath};
                myAuthorization.ProtectionRealm = protectionRealm;

                return myAuthorization;
            }
            catch(Exception e)
            {
                Console.WriteLine("The following exception was raised in Authenticate method:{0}",e.Message);
                return null;
            }
          }
// </Snippet2>
// </Snippet1>

        public Authorization PreAuthenticate(WebRequest request,ICredentials credentials)
        {
          return null;
        }
    }

    // The 'Client' class is defined here to test the above  custom authentication module.

     class Client
    {
    public static void Main(string[] args)
    {
        string url,userName,passwd;
        if (args.Length < 3)     
        {
            Client.PrintUsage();
            return;
        } 
        else
        {    
            url = args[0];
            userName = args[1];
            passwd = args[2];                    
        }
        Console.WriteLine();
        CloneBasic authenticationModule = new CloneBasic();
       AuthenticationManager.Register(authenticationModule);
       AuthenticationManager.Unregister("Basic");
       // Get response from Uri. 
       GetPage(url,userName,passwd);       
    }
    
    public static void GetPage(String url,string username,string passwd) 
    {
        try
        {
            string challenge = null;
            HttpWebRequest myHttpWebRequest = null;
            try 
            {
                // Create a 'HttpWebRequest' object for the above 'url'.
                myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
                // The following method call throws the 'WebException'.
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                // Release resources of response object.
                myHttpWebResponse.Close();
            } 
            catch(WebException e) 
            {
                for(int i=0; i < e.Response.Headers.Count; ++i) 
                {
                    // Retrieve the challenge string from the header "WWW-Authenticate".
                    if((String.Compare(e.Response.Headers.Keys[i],"WWW-Authenticate",true) == 0))
                        challenge = e.Response.Headers[i]; 
                }
            }

            if (challenge!= null)
            {
                // Challenge was raised by the client.Declare your credentials.
                NetworkCredential myCredentials = new NetworkCredential(username,passwd);
               // Pass the challenge , 'NetworkCredential' object and the 'HttpWebRequest' object to the
               //    'Authenticate' method of the  "AuthenticationManager" to retrieve an "Authorization" ;
               //    instance. 
                Authorization urlAuthorization = AuthenticationManager.Authenticate(challenge,myHttpWebRequest,myCredentials);
                if (urlAuthorization != null)
                {
                    Console.WriteLine("\nSuccessfully Created 'Authorization' object with authorization Message:\n \"{0}\"",urlAuthorization.Message);
                    Console.WriteLine("\n\nThis authorization is valid for the following Uri's:");
                    int count = 0;
                    foreach(string uri in urlAuthorization.ProtectionRealm)
                    {
                        ++count;
                        Console.WriteLine("\nUri[{0}]: {1}",count,uri);
                    }
                }
                else
                    Console.WriteLine("\nAuthorization object was returned as null. Please check if site accepts 'CloneBasic' authentication");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("\n The following exception was raised : {0}",e.Message);
        }

        }

        public static void PrintUsage() 
        {            
            Console.WriteLine("\r\nUsage: Try a site which requires CloneBasic(custom made) authentication as below");
            Console.WriteLine("   Authorization_ProtectionRealm URLname username password");
            Console.WriteLine("\nExample:");
            Console.WriteLine("\n   Authorization_ProtectionRealm http://www.microsoft.com/net/ george george123");
        }
    } 
}

