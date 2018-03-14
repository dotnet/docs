using System;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Microsoft.ServiceModel.Samples
{

    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
    }

    // Implement the service contract.
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }


        public static void Main()
        {
            // <Snippet1>
            // Create an EndpointAddress with a specified address.
            EndpointAddress epa1 = new EndpointAddress("http://localhost/ServiceModelSamples");
            Console.WriteLine("The URI of the EndpointAddress is {0}:", epa1.Uri);
            Console.WriteLine();

            //Initialize an EndpointAddressAugust2004 from the endpointAddress.
            EndpointAddressAugust2004 epaA4 = EndpointAddressAugust2004.FromEndpointAddress(epa1);

            //Serialize and then deserializde the EndpointAugust2004 type.

            //Convert the EndpointAugust2004 back into an EndpointAddress.
            EndpointAddress epa2 = epaA4.ToEndpointAddress();

            Console.WriteLine("The URI of the EndpointAddress is still {0}:", epa2.Uri);
            Console.WriteLine();
            // </Snippet1>

        }
    }
}

