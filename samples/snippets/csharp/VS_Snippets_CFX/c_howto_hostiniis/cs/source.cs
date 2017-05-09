//Code for con topic: HowTo: Host a WCF Service in IIS

//<snippet1>
using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{

    //<snippet11>
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

    //</snippet11>

    //<snippet12>
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

    //</snippet12>
//</snippet1>


    public class Test
    {
        public static void Main()
        {
        }

    }
}
