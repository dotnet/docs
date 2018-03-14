
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int n1, int n2);

        [OperationContract]
        int Subtract(int n1, int n2);

        [OperationContract]
        int Multiply(int n1, int n2);
//<snippet1>
        [OperationContract]
        [FaultContract(typeof(MathFault))]
        int Divide(int n1, int n2);
//</snippet1>
    }

//<snippet2>
    // Define a math fault data contract
    [DataContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public class MathFault
    {    
        private string operation;
        private string problemType;

        [DataMember]
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        [DataMember]        
        public string ProblemType
        {
            get { return problemType; }
            set { problemType = value; }
        }

    }
//</snippet2>

    // Service class which implements the service contract.
    public class CalculatorService : ICalculator
    {
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Subtract(int n1, int n2)
        {
            return n1 - n2;
        }

        public int Multiply(int n1, int n2)
        {
            return n1 * n2;
        }

        public int Divide(int n1, int n2)
        {
            try
            {
                return n1 / n2;
            }
            catch (DivideByZeroException)
            {
                MathFault mf = new MathFault();
                mf.Operation = "division";
                mf.ProblemType = "divide by zero";
                throw new FaultException<MathFault>(mf);
            }
        }

    }

}
