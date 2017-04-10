using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;

namespace Example
{
    public class Test
    {
        static void Main()
        {
            Test t = new Test();
            t.Snippet1();
            }


        private void Snippet1()
        {
            //<snippet1>
            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses a username/password credential.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            // Add an endpoint.
            sh.AddServiceEndpoint(typeof(ICalculator), b, "UserNamePasswordCalculator");

            // Get a reference to the UserNamePasswordServiceCredential object.
            UserNamePasswordServiceCredential unpCredential = 
                sh.Credentials.UserNameAuthentication;
            // Print out values.
            Console.WriteLine("IncludeWindowsGroup: {0}", 
                unpCredential.IncludeWindowsGroups);
            Console.WriteLine("UserNamePasswordValidationMode: {0}",
                unpCredential.UserNamePasswordValidationMode);
            Console.WriteLine("CachedLogonTokenLifetime.Minutes: {0}",
                unpCredential.CachedLogonTokenLifetime.Minutes );
            Console.WriteLine("CacheLogonTokens: {0}",
                unpCredential.CacheLogonTokens );
            Console.WriteLine("MaxCachedLogonTokens: {0}",
                unpCredential.MaxCachedLogonTokens );
                        
            Console.ReadLine();
            //</snippet1>
        }
    }

    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);
    }

    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
}