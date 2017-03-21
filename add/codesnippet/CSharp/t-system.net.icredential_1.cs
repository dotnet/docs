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