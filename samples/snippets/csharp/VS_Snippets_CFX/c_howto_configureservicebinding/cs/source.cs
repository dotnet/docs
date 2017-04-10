using System;
using System.ServiceModel;

namespace Samples
{

    //<snippet1>
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

    //</snippet1>

    //<snippet2>
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


    public class Test
    {
        public static void Main()
        {
        }

    }
}
