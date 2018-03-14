using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Net.Security;

namespace Server
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

    public class CalculatorService: ICalculator
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
            // <Snippet0>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            // Enable Mex
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);
 
            serviceHost.Open();

            // <Snippet1>
            ContractDescription cd0 = new ContractDescription("ICalculator");
            // </Snippet1>
            // <Snippet2>
            ContractDescription cd1 = new ContractDescription("ICalculator", "http://www.tempuri.org");
            // </Snippet2>
            // <Snippet13>
            ContractDescription cd2 = ContractDescription.GetContract(typeof(ICalculator));
            // </Snippet13>
            // <Snippet14>
            CalculatorService calcSvc = new CalculatorService();
            ContractDescription cd3 = ContractDescription.GetContract(typeof(ICalculator), calcSvc);
            // </Snippet14>
            // <Snippet15>
            ContractDescription cd4 = ContractDescription.GetContract(typeof(ICalculator), typeof(CalculatorService));
            // </Snippet15>
            ContractDescription cd = serviceHost.Description.Endpoints[0].Contract;         

            Console.WriteLine("Displaying information for contract: {0}", cd.Name.ToString());

            // <Snippet3>
            KeyedByTypeCollection<IContractBehavior> behaviors = cd.Behaviors;
            Console.WriteLine("\tDisplay all behaviors:");
            foreach (IContractBehavior behavior in behaviors)
            {
                Console.WriteLine("\t\t" + behavior.ToString());
            }
            // </Snippet3>

            // <Snippet4>
            Type type = cd.CallbackContractType;
            // </Snippet4>

            // <Snippet5>
            string configName = cd.ConfigurationName;
            Console.WriteLine("\tConfiguration name: {0}", configName);
            // </Snippet5>

            // <Snippet6>
            Type contractType = cd.ContractType;
            Console.WriteLine("\tContract type: {0}", contractType.ToString());
            // </Snippet6>

            // <Snippet7>
            bool hasProtectionLevel = cd.HasProtectionLevel;
            if (hasProtectionLevel)
            {
                // <Snippet11>
                ProtectionLevel protectionLevel = cd.ProtectionLevel;
                Console.WriteLine("\tProtection Level: {0}", protectionLevel.ToString());
                // </Snippet11>
            }
            // </Snippet7>

            
            // <Snippet8>
            string name = cd.Name;
            Console.WriteLine("\tName: {0}", name);
            // </Snippet8>

            // <Snippet9>
            string namespc = cd.Namespace;
            Console.WriteLine("\tNamespace: {0}", namespc);
            // </Snippet9>

            // <Snippet10>
            OperationDescriptionCollection odc = cd.Operations;
            Console.WriteLine("\tDisplay Operations:");
            foreach (OperationDescription od in odc)
            {
                Console.WriteLine("\t\t" + od.Name);
            }
            // </Snippet10>

            // <Snippet12>
            SessionMode sm = cd.SessionMode;
            Console.WriteLine("\tSessionMode: {0}", sm.ToString());
            // </Snippet12>

            // <Snippet16>
            Collection<ContractDescription> inheretedContracts = cd.GetInheritedContracts();
            Console.WriteLine("\tInherited Contracts:");
            foreach (ContractDescription contractdescription in inheretedContracts)
            {
                Console.WriteLine("\t\t" + contractdescription.Name);
            }
            // </Snippet16>

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
            // </Snippet0>
        }
    }
}
