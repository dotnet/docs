using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    //<snippet2>
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
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

    // Service class which implements the service contract.
    //<snippet1>
    [ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.PerCall)]
    //</snippet1>
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public double Divide(double n1, double n2)
        {
            return n1 / n2;
        }
    }
    //</snippet2>
    public class Class3
    {
        // for FXCOp.
    }
    public class Class4
    { }
    public class Class5
    { }
}
