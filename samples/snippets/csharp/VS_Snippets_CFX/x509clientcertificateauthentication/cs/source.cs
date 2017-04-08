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
            t.Snippet7();
            Console.ReadLine();
        }


        private void Snippet1()
        {
            //<snippet1>
            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);
            
            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
            
            // Configure peer trust.
            myAuthProperties.CertificateValidationMode =
                X509CertificateValidationMode.PeerTrust;
            // Configure chain trust.
            myAuthProperties.CertificateValidationMode =
                X509CertificateValidationMode.ChainTrust;
            // Configure custom certificate validation.
            myAuthProperties.CertificateValidationMode =
                X509CertificateValidationMode.Custom;

            // Specify a custom certificate validator (not shown here) that inherits 
            // from the X509CertificateValidator class. 
            // creds.ClientCertificate.Authentication.CustomCertificateValidator =
            //    new MyCertificateValidator();
            //</snippet1>
        }

        private void Snippet2()
        {
            //<snippet2>
            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
                        
            // Configure custom certificate validation.
            myAuthProperties.CertificateValidationMode =
                X509CertificateValidationMode.Custom;
            // Specify a custom certificate validator (not shown here) that inherits 
            // from the X509CertificateValidator class.
            // creds.ClientCertificate.Authentication.CustomCertificateValidator =
            //    new MyCertificateValidator();
            //</snippet2>
        }

        private void Snippet3()
        {
            //<snippet3>
            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);
            // Create a binding that uses a certificate.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType = 
                MessageCredentialType.Certificate; 


            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
            // Configure IncludeWindowsGroups.
            myAuthProperties.IncludeWindowsGroups = true;
            //</snippet3>
        }

        private void Snippet4()
        {   
            //<snippet4>
            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses Windows security.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
            // Configure IncludeWindowsGroups.
            myAuthProperties.IncludeWindowsGroups = true;
            //</snippet4>
        }

        private void Snippet5()
        {
            //<snippet5>
            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses a certificate.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate; 
            
            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
            
            // Configure ChainTrust with no revocation check.
            myAuthProperties.CertificateValidationMode = 
                X509CertificateValidationMode.ChainTrust;
            myAuthProperties.RevocationMode = X509RevocationMode.NoCheck;
            //</snippet5>
        }

        private void Snippet6()
        {
            //<snippet6>
            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses a certificate.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate; 

            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;
            // Configure peer trust.
            myAuthProperties.CertificateValidationMode =
                X509CertificateValidationMode.PeerTrust;
            myAuthProperties.TrustedStoreLocation =
                StoreLocation.LocalMachine;
            //</snippet6>
        }

        private void Snippet7()
        {
            //<snippet7>
            // Create a service host.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);

            // Create a binding that uses a certificate.
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

            // Get a reference to the authentication object.
            X509ClientCertificateAuthentication myAuthProperties =
                sh.Credentials.ClientCertificate.Authentication;

            switch (myAuthProperties.CertificateValidationMode)
            {
                case X509CertificateValidationMode.ChainTrust:
                    Console.WriteLine("ChainTrust");
                    break;
                case X509CertificateValidationMode.Custom:
                    Console.WriteLine("Custom");
                    break;
                case X509CertificateValidationMode.None:
                    Console.WriteLine("ChainTrust");
                    break;
                case X509CertificateValidationMode.PeerOrChainTrust:
                    Console.WriteLine("PeerOrChainTrust");
                    break;
                case X509CertificateValidationMode.PeerTrust:
                    Console.WriteLine("PeerTrust");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
            //</snippet7>
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