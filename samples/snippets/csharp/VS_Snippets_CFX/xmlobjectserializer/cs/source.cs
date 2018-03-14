using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;

[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Example
{
    //<snippet1>    
    public class Test
    {
        private void WriteObjectWithInstance(XmlObjectSerializer xm, Company graph,
           string fileName)
        {
            // Use either the XmlDataContractSerializer or NetDataContractSerializer,
            // or any other class that inherits from XmlObjectSerializer to write with.
            Console.WriteLine(xm.GetType());
            FileStream fs = new FileStream(fileName, FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            xm.WriteObject(writer, graph);
            Console.WriteLine("Done writing {0}", fileName);
        }

        private void Run()
        {
            // Create the object to write to a file.
            Company graph = new Company();
            graph.Name = "cohowinery.com";

            // Create a DataContractSerializer and a NetDataContractSerializer.
            // Pass either one to the WriteObjectWithInstance method.
            DataContractSerializer dcs = new DataContractSerializer(typeof(Company));
            NetDataContractSerializer ndcs = new NetDataContractSerializer();
            WriteObjectWithInstance(dcs, graph, @"datacontract.xml");
            WriteObjectWithInstance(ndcs, graph, @"netDatacontract.xml");
        }

        [DataContract]
        public class Company
        {
            [DataMember]
            public string Name;
        }

        static void Main()
        {
            try
            {
                Console.WriteLine("Starting");
                Test t = new Test();
                t.Run();
                Console.WriteLine("Done");
                Console.ReadLine();
            }

            catch (InvalidDataContractException iExc)
            {
                Console.WriteLine("You have an invalid data contract: ");
                Console.WriteLine(iExc.Message);
                Console.ReadLine();
            }

            catch (SerializationException serExc)
            {
                Console.WriteLine("There is a problem with the instance:");
                Console.WriteLine(serExc.Message);
                Console.ReadLine();
            }

            catch (QuotaExceededException qExc)
            {
                Console.WriteLine("The quota has been exceeded");
                Console.WriteLine(qExc.Message);
                Console.ReadLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.ToString());
                Console.ReadLine();
            }
        }
        //</snippet1>
    }
}

