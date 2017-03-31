using System;
using System.ServiceModel;

namespace Samples
{

//<snippet1>
using System.ServiceModel; 

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


    public class Test
    {
        public static void Main()
        {
        }

    }
}
