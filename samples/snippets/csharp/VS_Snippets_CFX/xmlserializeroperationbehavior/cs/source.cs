using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Example
{
    public class Test
    {
        //<snippet1>
        private void Run()
        {
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            Uri baseAddress = new Uri("http://localhost:1066/calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddress);
            sh.AddServiceEndpoint(typeof(ICalculator), b, "");

            // Find the ContractDescription of the operation to find.
            ContractDescription cd = sh.Description.Endpoints[0].Contract;
            OperationDescription myOperationDescription = cd.Operations.Find("Add");

            // Find the serializer behavior.
            XmlSerializerOperationBehavior  serializerBehavior =
                myOperationDescription.Behaviors.
                   Find<XmlSerializerOperationBehavior>();

            // If the serializer is not found, create one and add it.
            if (serializerBehavior == null)
            {
                serializerBehavior = new XmlSerializerOperationBehavior(myOperationDescription);
                myOperationDescription.Behaviors.Add(serializerBehavior);
            }
            
            // Change style of the serialize attribute.
            serializerBehavior.XmlSerializerFormatAttribute.Style = OperationFormatStyle.Document;
                        
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            sh.Close();
        }
        //</snippet1>


        static void Main()
        {
            try
            {
                Test t = new Test();
                t.Run();
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
        object GetInfo(string request);

    }

    [MessageContract(ProtectionLevel = System.Net.Security.ProtectionLevel.Sign)]
    public class Calculator : ICalculator
    {

        public double Add(double a, double b)
        {
            return a + b;
        }


        public object GetInfo(string request)
        {
            if (request == "Version")
                return "1.0";
            else
            {
                ComplexNumber x = new ComplexNumber();
                x.numberID_Value = "Calculator 1.0";
                return x;
            }
        }
    }

    [DataContract]
    public class ComplexNumber
    {
        [DataMember]
        public string numberID_Value;
    }
}
