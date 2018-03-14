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

                // Create a binding that uses a WindowsServiceCredential.
                WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
                b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

                // Add an endpoint.
                sh.AddServiceEndpoint(typeof(ICalculator), b, "WindowsCalculator");

                // Get a reference to the WindowsServiceCredential object.
                WindowsServiceCredential winCredential =
                    sh.Credentials.WindowsAuthentication;
                // Print out values.
                Console.WriteLine("IncludeWindowsGroup: {0}",
                    winCredential.IncludeWindowsGroups);
                Console.WriteLine("UserNamePasswordValidationMode: {0}",
                    winCredential.AllowAnonymousLogons);

                Console.ReadLine();
                //</snippet1>
            }
            private void Snippet2()
            {
                //<snippet2>
                // Create a service host.
                Uri httpUri = new Uri("http://localhost/Calculator");
                ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

                // Create a binding that uses a WindowsServiceCredential .
                WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
                b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

                // Add an endpoint.
                sh.AddServiceEndpoint(typeof(ICalculator), b, "WindowsCalculator");

                // Get a reference to the WindowsServiceCredential object.
                SecureConversationServiceCredential ssCredential =
                    sh.Credentials.SecureConversationAuthentication;

                //</snippet2>
            }
            private void Snippet3()
            {
                //<snippet3>
                // Create a service host.
                Uri httpUri = new Uri("http://localhost/Calculator");
                ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

                // Create a binding that uses a WindowsServiceCredential .
                WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
                b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

                // Add an endpoint.
                sh.AddServiceEndpoint(typeof(ICalculator), b, "WindowsCalculator");

                // Clone these credentials.
                ServiceCredentials cloneCredential =
                    sh.Credentials.Clone();

                //</snippet3>
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