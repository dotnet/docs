
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // <snippet1>
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples", SessionMode=SessionMode.Required)]
    public interface ICalculatorSession
    {
        [OperationContract(IsOneWay=true, IsInitiating=true, IsTerminating=false)]
        void Clear();
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void AddTo(double n);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void SubtractFrom(double n);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void MultiplyBy(double n);
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void DivideBy(double n);
        [OperationContract(IsInitiating = false, IsTerminating = true)]
        double Equals();
    }
    // </snippet1>

    // Service class which implements the service contract.
    // Use an InstanceContextMode of PrivateSession to store the result
    // An instance of the service will be bound to each session
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class CalculatorService : ICalculatorSession
    {
        double result = 0.0D;

        public void Clear()
        {
            result = 0.0D;
        }

        public void AddTo(double n)
        {
            result += n;
        }

        public void SubtractFrom(double n)
        {
            result -= n;
        }

        public void MultiplyBy(double n)
        {
            result *= n;
        }

        public void DivideBy(double n)
        {
            result /= n;
        }

        public double Equals()
        {
            return result;
        }
    }

}
