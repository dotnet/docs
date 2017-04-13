using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;

[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Example
{
    public class Test
    {
        //<snippet1>
        private void DataContractBehavior()
        {
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            Uri baseAddress = new Uri("http://localhost:1066/calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddress);
            sh.AddServiceEndpoint(typeof(ICalculator), b, "");

            // Find the ContractDescription of the operation to find.
            ContractDescription cd = sh.Description.Endpoints[0].Contract;
            OperationDescription myOperationDescription = cd.Operations.Find("Add");

            // Find the serializer behavior.
            DataContractSerializerOperationBehavior serializerBehavior =
                myOperationDescription.Behaviors.
                   Find<DataContractSerializerOperationBehavior>();

            // If the serializer is not found, create one and add it.
            if (serializerBehavior == null)
            {
                serializerBehavior = new DataContractSerializerOperationBehavior(myOperationDescription);
                myOperationDescription.Behaviors.Add(serializerBehavior);
            }

            // Change the settings of the behavior.
            serializerBehavior.MaxItemsInObjectGraph = 10000;
            serializerBehavior.IgnoreExtensionDataObject = true;
            
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
        }
        //</snippet1>

        //<snippet2>
        private void PrintDescription(ServiceHost sh)
        {
            // Declare variables.
            int i, j, k, l, c;
            ServiceDescription servDesc = sh.Description;
            OperationDescription opDesc;
            ContractDescription contractDesc;
            MessageDescription methDesc;
            MessageBodyDescription mBodyDesc;
            MessagePartDescription partDesc;
            IServiceBehavior servBeh;
            ServiceEndpoint servEP;

            // Print the behaviors of the service.
            Console.WriteLine("Behaviors:");
            for (c = 0; c < servDesc.Behaviors.Count; c++)
            {
                servBeh = servDesc.Behaviors[c];
                Console.WriteLine("\t{0}", servBeh.ToString());                
            }

            // Print the endpoint descriptions of the service.
            Console.WriteLine("Endpoints");
            for (i = 0; i < servDesc.Endpoints.Count; i++)
            {
                // Print the endpoint names.
                servEP = servDesc.Endpoints[i];
                Console.WriteLine("\tName: {0}", servEP.Name);
                contractDesc = servEP.Contract;

                Console.WriteLine("\tOperations:");
                for (j = 0; j < contractDesc.Operations.Count; j++)
                {
                    // Print the operation names.
                    opDesc = servEP.Contract.Operations[j];
                    Console.WriteLine("\t\t{0}", opDesc.Name);
                    Console.WriteLine("\t\tActions:");
                    for (k  = 0; k < opDesc.Messages.Count; k++)
                    {
                        // Print the message action. 
                        methDesc = opDesc.Messages[k];
                        Console.WriteLine("\t\t\tAction:{0}", methDesc.Action);
                       
                        // Check for the existence of a body, then the body description.
                        mBodyDesc = methDesc.Body;
                        if (mBodyDesc.Parts.Count > 0)
                        {
                            for (l = 0; l < methDesc.Body.Parts.Count; l++)
                            {
                                partDesc = methDesc.Body.Parts[l];
                                Console.WriteLine("\t\t\t\t{0}",partDesc.Name);
                            }
                        }
                    }
                }
            }
        }
        //</snippet2>

        static void Main()
        {
            try
            {
                Test t = new Test();
                t.DataContractBehavior();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();
            }
        }
    }
    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);

        [OperationContract]
        string GetInfo(string request);

    }

    [MessageContract(ProtectionLevel = System.Net.Security.ProtectionLevel.Sign)]
    public class Calculator : ICalculator
    {
        
        public double Add(double a, double b)
        {
            return a + b;
        }

        
        public string GetInfo(string request)
        {
            if (request == "Version")
                return "1.0";
            else
                return "Calculator 1.0";
        }
    }
}
