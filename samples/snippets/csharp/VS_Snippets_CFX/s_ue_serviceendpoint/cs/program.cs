using System;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace ServiceEndpointSnippets
{
  	[ServiceContract()]
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

        public static void Main()
        {
            Snippet.Snippet5();
            // <Snippet0>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            // <Snippet1>
            ContractDescription cd = new ContractDescription("Calculator");
            ServiceEndpoint svcEndpoint = new ServiceEndpoint(cd);
            // </Snippet1>
            
            // <Snippet3>                       
            ServiceEndpoint endpnt = serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            Console.WriteLine("Address: {0}", endpnt.Address);
            // </Snippet3>

            // Enable Mex
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);

            serviceHost.Open();
	    // </Snippet0>

        }
    }
}
