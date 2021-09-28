﻿
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.Threading;

namespace Microsoft.ServiceModel.Samples
{
    // The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    class Client
    {
        static void Main()
        {
          Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.");
          Console.WriteLine();

          // Create a client
          //<snippet3>
          ChannelFactory<ICalculatorChannel> factory = new ChannelFactory<ICalculatorChannel>();
          ICalculatorChannel channelClient = factory.CreateChannel();

          // BeginAdd
          double value1 = 100.00D;
          double value2 = 15.99D;

          IAsyncResult arAdd = channelClient.BeginAdd(value1, value2, AddCallback, channelClient);
          Console.WriteLine("Add({0},{1})", value1, value2);
          //</snippet3>
          // BeginSubstract
          value1 = 145.00D;
          value2 = 76.54D;
          IAsyncResult arSubtract = channelClient.BeginSubtract(value1, value2, SubtractCallback, channelClient);
          Console.WriteLine("Subtract({0},{1})", value1, value2);

          // Multiply
          value1 = 9.00D;
          value2 = 81.25D;
          double result = channelClient.Multiply(value1, value2);
          Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

          // Divide
          value1 = 22.00D;
          value2 = 7.00D;
          result = channelClient.Divide(value1, value2);
          Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

          Console.ReadLine();

          //Closing the client gracefully closes the connection and cleans up resources
          channelClient.Close();
        }

        // Asynchronous callbacks for displaying results.
        //<snippet2>
        static void AddCallback(IAsyncResult ar)
        {
            double result = ((CalculatorClient)ar.AsyncState).EndAdd(ar);
            Console.WriteLine("Add Result: {0}", result);
        }
        //</snippet2>
        static void SubtractCallback(IAsyncResult ar)
        {
            double result = ((CalculatorClient)ar.AsyncState).EndSubtract(ar);
            Console.WriteLine("Subtract Result: {0}", result);
        }
    }
}
