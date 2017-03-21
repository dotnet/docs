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