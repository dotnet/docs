
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // <Snippet5>
    // Define a duplex service contract.
    // A duplex contract consists of two interfaces.
    // The primary interface is used to send messages from client to service.
    // The callback interface is used to send messages from service back to client.
    // ICalculatorDuplex allows one to perform multiple operations on a running result.
    // The result is sent back after each operation on the ICalculatorCallback interface.
    // <Snippet3>
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", SessionMode=SessionMode.Required,
                     CallbackContract=typeof(ICalculatorDuplexCallback))]
    public interface ICalculatorDuplex
    {
        [OperationContract(IsOneWay=true)]
        void Clear();
        [OperationContract(IsOneWay = true)]
        void AddTo(double n);
        [OperationContract(IsOneWay = true)]
        void SubtractFrom(double n);
        [OperationContract(IsOneWay = true)]
        void MultiplyBy(double n);
        [OperationContract(IsOneWay = true)]
        void DivideBy(double n);
    }
    // </Snippet3>
    // The callback interface is used to send messages from service back to client.
    // The Equals operation will return the current result after each operation.
    // The Equation operation will return the complete equation after Clear() is called.
    // <Snippet4>
    public interface ICalculatorDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Equals(double result);
        [OperationContract(IsOneWay = true)]
        void Equation(string eqn);
    }
    // </Snippet4>
    // Service class which implements a duplex service contract.
    // Use an InstanceContextMode of PerSession to store the result
    // An instance of the service will be bound to each duplex session
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CalculatorService : ICalculatorDuplex
    {
        double result;
        string equation;
        // <Snippet1>
        ICalculatorDuplexCallback callback = null;
        // </Snippet1>

        public CalculatorService()
        {
            result = 0.0D;
            equation = result.ToString();
            // <Snippet2>
            callback = OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
            // </Snippet2>
        }

        public void Clear()
        {
            callback.Equation(equation + " = " + result.ToString());
            result = 0.0D;
            equation = result.ToString();
        }

        public void AddTo(double n)
        {
            result += n;
            equation += " + " + n.ToString();
            callback.Equals(result);
        }

        public void SubtractFrom(double n)
        {
            result -= n;
            equation += " - " + n.ToString();
            callback.Equals(result);
        }

        public void MultiplyBy(double n)
        {
            result *= n;
            equation += " * " + n.ToString();
            callback.Equals(result);
        }

        public void DivideBy(double n)
        {
            result /= n;
            equation += " / " + n.ToString();
            callback.Equals(result);
        }
    }
    // </Snippet5>
}
