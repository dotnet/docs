// NCLCredPolicy
using System;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using Microsoft.Win32;

//<snippet3>
    public class SelectedHostsCredentialPolicy: ICredentialPolicy
    {
        public SelectedHostsCredentialPolicy()
        {
        }
        
        public virtual bool ShouldSendCredential(Uri challengeUri, 
            WebRequest request, 
            NetworkCredential credential, 
            IAuthenticationModule authModule)
        {
            Console.WriteLine("Checking custom credential policy.");
            if (request.RequestUri.Host == "www.contoso.com" ||
                challengeUri.IsLoopback == true)
                return true;

            return false;
        }
    }
//</snippet3>

//<snippet4>
// The following class allows credentials to be sent if they are for requests for resources
// in the same domain, or if the request uses the HTTPSscheme and basic authentication is 
// required.

       public class HttpsBasicCredentialPolicy: IntranetZoneCredentialPolicy
    {
        public HttpsBasicCredentialPolicy()
        {
        }
        
        public override bool ShouldSendCredential(Uri challengeUri, 
            WebRequest request, 
            NetworkCredential credential, 
            IAuthenticationModule authModule)
        {
            Console.WriteLine("Checking custom credential policy for HTTPS and basic.");
            bool answer = base.ShouldSendCredential(challengeUri, request, credential, authModule);

            if (answer == true)
            {
                Console.WriteLine("Sending credential for intranet resource.");
                return answer;
            }
            // Determine whether the base implementation returned false for basic and HTTPS.
            if (request.RequestUri.Scheme == Uri.UriSchemeHttps &&
                authModule.AuthenticationType == "Basic")
            {
                Console.WriteLine("Sending credential for HTTPS and basic.");
                return true;
            }
            return false;
        }
    }
//</snippet4>
    public class CredentialPolicyExamples
    {

    public static void UseHttpsBasicCredentialPolicy()
        {
            HttpsBasicCredentialPolicy encryptedBasic = new HttpsBasicCredentialPolicy();
            AuthenticationManager.CredentialPolicy = encryptedBasic;
        }
        public static void UseCustomCredentialPolicy()
        {
            SelectedHostsCredentialPolicy hosts = new SelectedHostsCredentialPolicy();
            AuthenticationManager.CredentialPolicy = hosts;
        }
        // <snippet2>
         public static void UseIntranetCredentialPolicy()
        {
            IntranetZoneCredentialPolicy  policy = new IntranetZoneCredentialPolicy();
            AuthenticationManager.CredentialPolicy = policy;
        }
        // </snippet2>
        // <snippet1>

        // The following example uses the System, System.Net, 
        // and System.IO namespaces.
        
        public static void RequestMutualAuth(Uri resource)
        {
            // Create a new HttpWebRequest object for the specified resource.
            WebRequest request=(WebRequest) WebRequest.Create(resource);
            // Request mutual authentication.
           request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequested;
            // Supply client credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            // Determine whether mutual authentication was used.
            Console.WriteLine("Is mutually authenticated? {0}", response.IsMutuallyAuthenticated);
            // Read and display the response.
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
           Console.WriteLine(responseString);
            // Close the stream objects.
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse.
            response.Close();
        }
        // </snippet1>

        
        private static string GetUserName()
        {
            return @"sharriso1\Jane";
        }

         private static string GetUserPassword()
        {
            return "LXMP9804!";
        }
       public class HttpsBasicCredentialOnlyPolicy: ICredentialPolicy
    {
        public HttpsBasicCredentialOnlyPolicy()
        {
        }
        
        public bool ShouldSendCredential(Uri challengeUri, 
            WebRequest request, 
            NetworkCredential credential, 
            IAuthenticationModule authModule)
        {
            Console.WriteLine("Checking custom credential policy for HTTPS and basic.");
            // Determine whether the base implementation returned false for basic and https.
            if (request.RequestUri.Scheme == Uri.UriSchemeHttps &&
                authModule.AuthenticationType == "Basic")
            {
                Console.WriteLine("Sending credential for HTTPS and basic.");
                return true;
            }
            return false;
        }
    }
       public static void RequestHttpBasicResource(Uri resource)
        {
            // Set policy to send credentials when using HTTPS and basic authentication;
            HttpsBasicCredentialOnlyPolicy encryptedBasic = new HttpsBasicCredentialOnlyPolicy();
            AuthenticationManager.CredentialPolicy = encryptedBasic;
            // Create a new HttpWebRequest object for the specified resource.
            WebRequest request=(WebRequest) WebRequest.Create(resource);
            // Supply client credentials for basic authentication.
            request.Credentials = new NetworkCredential(GetUserName(), GetUserPassword());
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            // Determine whether mutual authentication was used.
            Console.WriteLine("Is mutually authenticated? {0}", response.IsMutuallyAuthenticated);
            // Read and display the response.
            System.IO.Stream streamResponse = response.GetResponseStream();
            System.IO.StreamReader streamRead = new System.IO.StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
           Console.WriteLine(responseString);
            // Close the stream objects.
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse.
            response.Close();
        }

// <snippet5>
       public static void RequestResource(Uri resource)
        {
            // Set policy to send credentials when using HTTPS and basic authentication.

            // Create a new HttpWebRequest object for the specified resource.
            WebRequest request=(WebRequest) WebRequest.Create(resource);
            // Supply client credentials for basic authentication.
            request.UseDefaultCredentials = true;
            request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            // Determine mutual authentication was used.
            Console.WriteLine("Is mutually authenticated? {0}", response.IsMutuallyAuthenticated);

             System.Collections.Specialized.StringDictionary spnDictionary = AuthenticationManager.CustomTargetNameDictionary;
            foreach (System.Collections.DictionaryEntry e in spnDictionary)
            {
                Console.WriteLine("Key: {0}  - {1}", e.Key as string, e.Value as string);
            }
            // Read and display the response.
            System.IO.Stream streamResponse = response.GetResponseStream();
            System.IO.StreamReader streamRead = new System.IO.StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
            Console.WriteLine(responseString);
            // Close the stream objects.
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse.
            response.Close();
        }
        
/*

The output from this example will differ based on the requested resource
and whether mutual authentication was successful. For the purpose of illustration,
a sample of the output is shown here:

Is mutually authenticated? True
Key: http://server1.someDomain.contoso.com  - HTTP/server1.someDomain.contoso.com

<html>
...
</html>

*/

// </snippet5>
        public static void Main()
        {
            // UseCustomCredentialPolicy();
            //RequestMutualAuth(new Uri("http://wasabi/noribeta/NamespaceExceptionReport.aspx?Namespace=System.Net"));
            //RequestMutualAuth(new Uri("http://sharriso1/test/postaccepter.aspx"));
           // RequestResource(new Uri("http://sharriso1.redmond.corp.microsoft.com/test/postaccepter.aspx"));
           RequestResource(new Uri("http://www.google.com"));

        }
    }

