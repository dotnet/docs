//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace CalculatorSample
{
    class CalculatorClient
    {
        static void Main()
        {
            // Create a client
            var channelFactory = new ChannelFactory<ICalculator>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:8090/CalculatorSample/service"));

            // Call the Add/Subtract/Multiply/Divide service operation.
            var proxy = channelFactory.CreateChannel();
            Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, -1, proxy.Add(1, -1));
            Console.WriteLine("x - y = {2} when x = {0} and y = {1}", 1, -1, proxy.Subtract(1, -1));
            Console.WriteLine("x * y = {2} when x = {0} and y = {1}", 1, -1, proxy.Multiply(1, -1));
            Console.WriteLine("x / y = {2} when x = {0} and y = {1}", 1, -1, proxy.Divide(1, -1));
            Console.ReadLine();

            //Closing the client gracefully closes the connection and cleans up resources
            channelFactory.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }

    // Define a service contract.
    [ServiceContract]
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
}

