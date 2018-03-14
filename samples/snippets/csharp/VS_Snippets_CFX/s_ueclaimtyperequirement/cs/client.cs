// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// Snippet for System.ServiceModel.Security.Tokens.ClaimTypeRequirement
// snippet used 0,2
// 06-22-06 a-arthu put in snippets

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }

    // Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a channel.
            EndpointAddress address = new EndpointAddress("http://localhost/servicemodelsamples/service.svc");
            // <Snippet2>
            // <Snippet1>
            WSFederationHttpBinding binding = new WSFederationHttpBinding();
            binding.Security.Message.ClaimTypeRequirements.Add
               (new ClaimTypeRequirement
               ("http://schemas.microsoft.com/ws/2005/05/identity/claims/EmailAddress"));
            binding.Security.Message.ClaimTypeRequirements.Add
               (new ClaimTypeRequirement
               ("http://schemas.microsoft.com/ws/2005/05/identity/claims/UserName", true));
            // </Snippet1>
            ClaimTypeRequirement cr = new ClaimTypeRequirement
               ("http://schemas.microsoft.com/ws/2005/05/identity/claims/UserName", true);
            Console.WriteLine(cr.ClaimType);
            Console.WriteLine(cr.IsOptional);
            // </Snippet2>

            ChannelFactory<ICalculator> factory = new ChannelFactory<ICalculator>(binding, address);
            ICalculator channel = factory.CreateChannel();

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = channel.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = channel.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = channel.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = channel.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
            
            ((IChannel)channel).Close();
        }
    }
}
