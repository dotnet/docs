using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Data;

[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]

namespace Example
{
    //<snippet1>    
    public  class Test
    {
        static void Main()
        {
            try
            {
                Test t = new Test();
                t.Run();
            }
                 
            // Catch the InvalidDataContractException here.
            catch(InvalidDataContractException iExc)
            {
                Console.WriteLine("You have an invalid data contract: ");
                Console.WriteLine(iExc.Message);
                Console.ReadLine();
                
            }
              catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.ToString() );
                Console.ReadLine();
            }
        }

        private void Run()
        {
            // Create a new WSHttpBinding and set the security mode to Message;
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);

            // Create a ServiceHost instance, and add a metadata endpoint.
            Uri baseUri= new Uri("http://localhost:1008/");            
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseUri);

            // Optional. Add a metadata endpoint. The method is defined below.
            AddMetadataEndpoint(ref sh);

            // Add an endpoint using the binding, and open the service.
            sh.AddServiceEndpoint(typeof(ICalculator), b, "myCalculator");
            sh.Open();
            
            Console.WriteLine("Listening...");
            Console.ReadLine();

        }

        private void AddMetadataEndpoint(ref ServiceHost sh)
        {
            Uri mex = new Uri(@"http://localhost:1001/metadata/");
            ServiceMetadataBehavior sm = new ServiceMetadataBehavior();
            sm.HttpGetEnabled = true;
            sm.HttpGetUrl = mex;
            sh.Description.Behaviors.Add(sm);
        }
        
    }
    
    // This class will cause an InvalidDataContractException to be thrown because
    // neither the DataContractAttribute nor DataMemberAttribute has been applied to it.
    public class ExtraData
    {
        public System.Collections.Generic.List<string> RandomData;
    }

    [ServiceContract(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign) ]
    interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);

        [OperationContract]
        ExtraData MoreData();
    }

    public class Calculator : ICalculator
    { 
        public double Add(double a, double b)
        {
            return a + b;
        }

        public ExtraData MoreData()
        {
            ExtraData ex = new ExtraData();
            ex.RandomData.Add("Hello");
            ex.RandomData.Add( "World" );
            return ex;
        }
    }
    //</snippet1>
}