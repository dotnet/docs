
//  Snippet file for S_UEBinding
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
//  Change ICalculator to CalculatorService.
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;


namespace UE.ServiceModel.Samples
{
// Define a service contract.
	[ServiceContract(Namespace = "http://UE.ServiceModel.Samples")]
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

	
    class Client
    {
        static void Main()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
 
            String url = "http://localhost:8000/servicemodelsamples/service/calc";
            EndpointAddress address = new EndpointAddress(url);
            ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>(binding, address);
            ICalculator channel = channelFactory.CreateChannel();

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
            ((IChannel)channel).Close();
            Console.ReadLine();
        }
    }
}
