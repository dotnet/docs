// Snippet for X509CertificateValidationMode
/*
 * 
 *  CalculatorChannel is not consistent with store, so changed everything else
              ChannelFactory<ISimpleChannel> cf =
                    new ChannelFactory<ISimpleChannel>();
                cf.Credentials.ClientCertificate.SetCertificate(
                    StoreLocation.CurrentUser, StoreName.My,
                    X509FindType.FindByThumbprint, "37 28 05 09 22 81 07 08 a0 cd 2a af dd c3 83 cd c3 3b 8f 9d");
                cf.Credentials.ServiceCertificate.SetDefaultCertificate(
                    StoreLocation.CurrentUser,
                    StoreName.TrustedPeople,
                    X509FindType.FindByThumbprint, "33 93 68 cc 7c 75 80 24 a2 80 9f 45 8c 81 fa 92 ad 5b 04 39");
                cf.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;
    using System.ServiceModel.Security;
 * 
* 
 * 
 * 
 */

//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.Security.Cryptography.X509Certificates;

using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Security.Principal;


namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedwcfClient.cs, generated from the service by the svcutil tool.
    //Client implementation code.
    class Client
    {
      static void Main()
      {
        // Create a wcfClient with Username endpoint configuration
        CalculatorClient wcfClient = new CalculatorClient("Username");
        try
        {
          wcfClient.ClientCredentials.UserName.UserName = "test1";
          wcfClient.ClientCredentials.UserName.Password = "1tset";

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

        // Create a wcfClient with Certificate endpoint configuration
        CalculatorClient eptwcfClient = new CalculatorClient("Certificate");
        try
        {
          // <Snippet0>
          ChannelFactory<ISimpleChannel> cf =
              new ChannelFactory<ISimpleChannel>();
          cf.Credentials.ClientCertificate.SetCertificate(
              StoreLocation.CurrentUser, StoreName.My,
              X509FindType.FindByThumbprint,
"37 28 05 09 22 81 07 08 a0 cd 2a af dd c3 83 cd c3 3b 8f 9d");
          cf.Credentials.ServiceCertificate.SetDefaultCertificate(
              StoreLocation.CurrentUser,
              StoreName.TrustedPeople,
              X509FindType.FindByThumbprint,
"33 93 68 cc 7c 75 80 24 a2 80 9f 45 8c 81 fa 92 ad 5b 04 39");
          cf.Credentials.ServiceCertificate.Authentication.CertificateValidationMode
              = X509CertificateValidationMode.PeerOrChainTrust;
          // </Snippet0>

          eptwcfClient.ClientCredentials.ClientCertificate.SetCertificate
              (StoreLocation.CurrentUser,
              StoreName.TrustedPeople,
              X509FindType.FindBySubjectName, "test1");

          // Call the Add service operation.
          double value1 = 100.00D;
          double value2 = 15.99D;
          double result = eptwcfClient.Add(value1, value2);
          Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

          // Call the Subtract service operation.
          value1 = 145.00D;
          value2 = 76.54D;
          result = eptwcfClient.Subtract(value1, value2);
          Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

          // Call the Multiply service operation.
          value1 = 9.00D;
          value2 = 81.25D;
          result = eptwcfClient.Multiply(value1, value2);
          Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

          // Call the Divide service operation.
          value1 = 22.00D;
          value2 = 7.00D;
          result = eptwcfClient.Divide(value1, value2);
          Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

          eptwcfClient.Close();

        }
        catch (TimeoutException timeProblem)
        {
          Console.WriteLine("The service operation timed out. " + timeProblem.Message);
          Console.ReadLine();
          eptwcfClient.Abort();
        }
        catch (CommunicationException commProblem)
        {
          Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
          Console.ReadLine();
          eptwcfClient.Abort();
        }

        Console.WriteLine();
        Console.WriteLine("Press <ENTER> to terminate client.");
        Console.ReadLine();
      }
    }
}
