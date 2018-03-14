using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.ServiceModel.Samples
{
    class Client
    {
        static void Main(string[] args)
        {
            CalculatorClient client = new CalculatorClient();
            
            //X509Certificate2 cert = new X509Certificate2("c:\\MyClientCert.pfx", "password", X509KeyStorageFlags.DefaultKeySet);
            //client.ClientCredentials.ClientCertificate.Certificate = cert;
            //client.ClientCredentials.UserName.UserName = "migree";
            //client.ClientCredentials.UserName.Password = "Wgth#123";

            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
