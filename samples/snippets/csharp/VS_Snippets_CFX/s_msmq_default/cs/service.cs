
// <Snippet8>
// This is the service code.
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
using System;

using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // <Snippet1>
    // Define a service contract. 
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface IQueueCalculator
    {
        [OperationContract(IsOneWay=true)]
        void Add(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Subtract(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Multiply(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Divide(double n1, double n2);
    }
    // </Snippet1>

    // <Snippet2>
    // Service class that implements the service contract.
    // Added code to write output to the console window
    public class CalculatorService : IQueueCalculator
    {
        [OperationBehavior]
        public void Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1}) - result: {2}", n1, n2, result);
        }

        [OperationBehavior]
        public void Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1}) - result: {2}", n1, n2, result);
        }

        [OperationBehavior]
        public void Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1}) - result: {2}", n1, n2, result);
        }

        [OperationBehavior]
        public void Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1}) - result: {2}", n1, n2, result);
        }
    }
    // </Snippet2>
 }
// </Snippet8>