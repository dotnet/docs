// <Snippet0>
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Metadata.Samples
{
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract]
        string SimpleMethod(string msg);
    }

    class SimpleService : ISimpleService
    {
        public string SimpleMethod(string msg)
        {
            Console.WriteLine("The caller passed in " + msg);
            return "Hello " + msg;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(SimpleService)); 
            try
            {
                // Open the service host to accept incoming calls
                host.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                host.Close();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                Console.Read();
            }
        }
    }
}
// </Snippet0>