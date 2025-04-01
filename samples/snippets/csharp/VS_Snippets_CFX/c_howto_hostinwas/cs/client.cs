// This is the code for the topic: How to: Host a WCF Service in WAS
//<snippet1211>

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{

    //<snippet1221>
    //Generated interface defining the ICalculator contract	
    [System.ServiceModel.ServiceContractAttribute(
    Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="Microsoft.ServiceModel.Samples.ICalculator")]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(
	Action="http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction="http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")]
        double Add(double n1, double n2);

        	[System.ServiceModel.OperationContractAttribute(
	Action="http://Microsoft.ServiceModel.Samples/ICalculator/Subtract", ReplyAction="http://Microsoft.ServiceModel.Samples/ICalculator/SubtractResponse")]
        double Subtract(double n1, double n2);

        	[System.ServiceModel.OperationContractAttribute(
	Action="http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", ReplyAction="http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")]
        double Multiply(double n1, double n2);

        	[System.ServiceModel.OperationContractAttribute(
	Action="http://Microsoft.ServiceModel.Samples/ICalculator/Divide", ReplyAction="http://Microsoft.ServiceModel.Samples/ICalculator/DivideResponse")]
        double Divide(double n1, double n2);
    }
    //</snippet1221>

    //<snippet1222>
    // Implementation of the CalculatorClient
    public partial class CalculatorClient : System.ServiceModel.ClientBase<Microsoft.ServiceModel.Samples.ICalculator>, Microsoft.ServiceModel.Samples.ICalculator
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

        public CalculatorClient(string endpointConfigurationName,
				System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(System.ServiceModel.Channels.Binding binding, 				System.ServiceModel.EndpointAddress remoteAddress) :
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
    //</snippet1222>

    //<snippet1223>
    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a client with given client endpoint configuration
            CalculatorClient client = new CalculatorClient();

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
    //</snippet1223>
}
//</snippet1211>