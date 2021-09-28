using System;
using System.ServiceModel;

namespace UE.Samples
{
    public class Snippets
    {
        public static void Snippet2()
        {
            // <Snippet2>
            Uri baseAddress = new Uri("http://localhost:8000/HelloService");
            string address = "http://localhost:8000/HelloService/MyService";

            using (ServiceHost serviceHost = new ServiceHost(typeof(HelloService), baseAddress))
            {
                serviceHost.AddServiceEndpoint(typeof(IHello), new BasicHttpBinding(), address);
                serviceHost.Open();
                Console.WriteLine("Press <enter> to terminate service");
                Console.ReadLine();
                serviceHost.Close();
            }
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            Uri baseAddress = new Uri("http://localhost:8000/HelloService");

            using (ServiceHost serviceHost = new ServiceHost(typeof(HelloService), baseAddress))
            {
                serviceHost.AddServiceEndpoint(typeof(IHello), new BasicHttpBinding(), "MyService");
                serviceHost.Open();
                Console.WriteLine("Press <enter> to terminate service");
                Console.ReadLine();
                serviceHost.Close();
            }
            // </Snippet3>
        }
    }
}
