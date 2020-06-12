using System;
using System.ServiceModel;

namespace UE.Samples
{

    [ServiceContract]
    public interface IHello
    {
        [OperationContract]
        string SayHello(string name);
    }

    class HelloService : IHello
    {
        public string SayHello(string name)
        {
            return "Hello " + name;
        }

        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/HelloService");
            using (ServiceHost serviceHost = new ServiceHost(typeof(HelloService), baseAddress))
            {
                serviceHost.Open();
                Console.WriteLine("Press <enter> to terminate service");
                Console.ReadLine();
                serviceHost.Close();
            }
        }
    }
}
