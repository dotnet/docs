//  Snippet for
//  System.ServiceModel.Security.X509ServiceCertificateAuthentication
//  Snippet0,1,2,3,4
//
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Security.Principal;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security.Tokens;
using System.IdentityModel.Selectors;


namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.
    class MyCertificateValidator : X509CertificateValidator
    {
        public override void  Validate(X509Certificate2 certificate)
        {
 	        throw new Exception("The method or operation is not implemented.");
}
        }

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            {
                // <Snippet1>
                // Configure custom certificate validation.
                ClientCredentials creds = new ClientCredentials();
                creds.ServiceCertificate.Authentication.CertificateValidationMode
                    = X509CertificateValidationMode.Custom;
                creds.ServiceCertificate.Authentication.CustomCertificateValidator
                    = new MyCertificateValidator();
                // </Snippet1>
            }
            {
                // <Snippet2>
                ClientCredentials creds = new ClientCredentials();

                // Configure chain trust.

                creds.ServiceCertificate.Authentication.CertificateValidationMode =
                X509CertificateValidationMode.ChainTrust;

                creds.ServiceCertificate.Authentication.RevocationMode =
                X509RevocationMode.NoCheck;
                // </Snippet2>
            }
            {
                // <Snippet3>
                ClientCredentials creds = new ClientCredentials();

                // Configure chain trust.
                creds.ServiceCertificate.Authentication.CertificateValidationMode
                    = X509CertificateValidationMode.ChainTrust;
                creds.ServiceCertificate.Authentication.TrustedStoreLocation
                    = StoreLocation.LocalMachine;
                // </Snippet3>
            }

            {
                // <Snippet4>
                ClientCredentials clientCreds = 
                    new ClientCredentials();
                Console.WriteLine(
                    clientCreds.ServiceCertificate.Authentication);
                // </Snippet4>
            }

            // Create a client with given client endpoint configuration
            CalculatorClient wcfClient = new CalculatorClient();
            try
            {
                // set new credentials
                wcfClient.ChannelFactory.Endpoint.Behaviors.Remove(typeof(ClientCredentials));
                wcfClient.ChannelFactory.Endpoint.Behaviors.Add(new MyUserNameClientCredentials());
                /*
                Setting the CertificateValidationMode to PeerOrChainTrust means that if the certificate 
                is in the Trusted People store, then it will be trusted without performing a
                validation of the certificate's issuer chain. This setting is used here for convenience so that the 
                sample can be run without having to have certificates issued by a certificate authority (CA).
                This setting is less secure than the default, ChainTrust. The security implications of this 
                setting should be carefully considered before using PeerOrChainTrust in production code. 
                */
                wcfClient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                    X509CertificateValidationMode.PeerOrChainTrust;
                // <Snippet0>
                ClientCredentials creds = new ClientCredentials();
                // Configure peer trust.
                creds.ServiceCertificate.Authentication.CertificateValidationMode =
                          X509CertificateValidationMode.PeerTrust;

                // Configure chain trust.
                creds.ServiceCertificate.Authentication.CertificateValidationMode =
                              X509CertificateValidationMode.ChainTrust;

                // Configure custom certificate validation.
                creds.ServiceCertificate.Authentication.CertificateValidationMode =
                              X509CertificateValidationMode.Custom;
                creds.ServiceCertificate.Authentication.CustomCertificateValidator =
                    new MyCertificateValidator();
                // </Snippet0>
                // Call the Add service operation.
                double value1 = 100.00D;
                double value2 = 15.99D;
                double result = wcfClient.Add(value1, value2);
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                // Call the Subtract service operation.
                value1 = 145.00D;
                value2 = 76.54D;
                result = wcfClient.Subtract(value1, value2);
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

                // Call the Multiply service operation.
                value1 = 9.00D;
                value2 = 81.25D;
                result = wcfClient.Multiply(value1, value2);
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                // Call the Divide service operation.
                value1 = 22.00D;
                value2 = 7.00D;
                result = wcfClient.Divide(value1, value2);
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
                wcfClient.Close();
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                Console.ReadLine();
                wcfClient.Abort();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
                Console.ReadLine();
                wcfClient.Abort();
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
