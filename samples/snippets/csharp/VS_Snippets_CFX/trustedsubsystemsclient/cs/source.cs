
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    class Client
    {
        static void Main()
        {
            Console.WriteLine("Username authentication required.");
            Console.WriteLine("Provide a username and a password that match (ex. username:test password:test)");
            Console.WriteLine("   Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("   Enter password:");
            StringBuilder password = new StringBuilder();

            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    password.Append(info.KeyChar);
                    info = Console.ReadKey(true);
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (password.Length != 0)
                    {
                        password.Remove(password.Length - 1, 1);
                    }
                    info = Console.ReadKey(true);
                }
            }

            for (int i = 0; i < password.Length; i++)
                Console.Write("*");

            Console.WriteLine();

            // <snippet1>
            // Create the binding.
            WSHttpBinding subsystemBinding = new WSHttpBinding();
            subsystemBinding.Security.Mode = SecurityMode.Message;
            subsystemBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.UserName;

            // Create the endpoint address.
            EndpointAddress ea = new
                EndpointAddress("http://www.cohowinery.com:8000/FacadeService");

            CalculatorClient client = new CalculatorClient(subsystemBinding, ea);

            // Configure client with valid machine or domain account (username,password)
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password.ToString();

            // Call the Multiply service operation.
            double value1 = 39D;
            double value2 = 50.44D;
            double result = client.Multiply(value1, value2);
            Console.WriteLine($"Multiply({value1},{value2}) = {result}");

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();
            // </snippet1>
        }
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples", ConfigurationName = "Microsoft.ServiceModel.Samples.ICalculator")]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")]
        double Multiply(double n1, double n2);
   }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : Microsoft.ServiceModel.Samples.ICalculator, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<Microsoft.ServiceModel.Samples.ICalculator>, Microsoft.ServiceModel.Samples.ICalculator
    {

        public CalculatorClient()
        {
        }

        public CalculatorClient(string endpointConfigurationName)
            :
                base(endpointConfigurationName)
        {
        }

        public CalculatorClient(string endpointConfigurationName, string remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(binding, remoteAddress)
        {
        }

        public double Multiply(double n1, double n2)
        {
            return base.Channel.Multiply(n1, n2);
        }
     }
}
