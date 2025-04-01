//code for c_HowTo_CodeClientBindings client

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
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

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : Microsoft.ServiceModel.Samples.ICalculator, System.ServiceModel.IClientChannel
    {
    }

    //<snippet2>

    public class CalculatorClient : System.ServiceModel.ClientBase<Microsoft.ServiceModel.Samples.ICalculator>, Microsoft.ServiceModel.Samples.ICalculator
    {

        public CalculatorClient()
        {
        }

        public CalculatorClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public CalculatorClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public double Add(double n1, double n2)
        {
            return base.Channel.Add(n1, n2);
        }

        public double Subtract(double n1, double n2)
        {
            return base.Channel.Subtract(n1, n2);
        }

        public double Multiply(double n1, double n2)
        {
            return base.Channel.Multiply(n1, n2);
        }

        public double Divide(double n1, double n2)
        {
            return base.Channel.Divide(n1, n2);
        }
    }

    //</snippet2>

//<snippet3>

    //Client implementation code.
    class Client
    {
        static void Main()
        {

            //Specify the binding to be used for the client.
            BasicHttpBinding binding = new BasicHttpBinding();

            //Specify the address to be used for the client.
            EndpointAddress address =
               new EndpointAddress("http://localhost/servicemodelsamples/service.svc");

            // Create a client that is configured with this address and binding.
            CalculatorClient client = new CalculatorClient(binding, address);

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine($"Add({value1},{value2}) = {result}");

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine($"Subtract({value1},{value2}) = {result}");

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine($"Multiply({value1},{value2}) = {result}");

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine($"Divide({value1},{value2}) = {result}");

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}

//</snippet3>
