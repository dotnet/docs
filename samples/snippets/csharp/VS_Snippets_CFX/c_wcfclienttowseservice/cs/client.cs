//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

// <snippet0>
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    // The service contract is defined in generatedClient.cs, generated from the service by
    // the svcutil tool.

    class Program
    {
        static void Main(string[] args)
        {
            CallWseService(true);
        }
        // <snippet4>
        static void CallWseService(bool usePolicyFile)
        {
            EndpointAddress address = new EndpointAddress(new Uri("http://localhost/WSSecurityAnonymousPolicy/WSSecurityAnonymousService.asmx"),
                                                          EndpointIdentity.CreateDnsIdentity("WSE2QuickStartServer"));

            WseHttpBinding binding = new WseHttpBinding();
            if (!usePolicyFile)
            {
                binding.SecurityAssertion = WseSecurityAssertion.AnonymousForCertificate;
                binding.EstablishSecurityContext = true;
                binding.RequireDerivedKeys = true;
                binding.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt;
            }
            else
                binding.LoadPolicy("..\\wse3policyCache.config", "ServerPolicy");

            WSSecurityAnonymousServiceSoapClient client = new WSSecurityAnonymousServiceSoapClient(binding, address);
            // </snippet4>

            // Need to supply the credentials depending on the type of WseSecurityAssertion used.
            // Anonymous only requires server certificate. UsernameForCertificate would also require
            // a username and password to be supplied.
            client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(
                                                                 StoreLocation.LocalMachine,
                                                                 StoreName.My,
                                                                 X509FindType.FindBySubjectDistinguishedName,
                                                                 "CN=WSE2QuickStartServer");
            string[] symbols = new string[] { "FABRIKAM", "CONTOSO" };
            StockQuote[] quotes = client.StockQuoteRequest(symbols);

            client.Close();

            // Success!
            foreach (StockQuote quote in quotes)
            {
                Console.WriteLine("");
                Console.WriteLine("Symbol: " + quote.Symbol);
                Console.WriteLine("\tName:\t\t\t" + quote.Name);
                Console.WriteLine("\tLast Price:\t\t" + quote.Last);
                Console.WriteLine("\tPrevious Change:\t" + quote.PreviousChange + "%");
            }

            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
// </snippet0>