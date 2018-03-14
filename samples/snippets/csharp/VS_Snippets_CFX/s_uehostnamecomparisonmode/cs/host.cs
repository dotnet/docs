using System;
using System.ServiceModel;

namespace UE.Samples
{
    class host
    {
        static void Main()
        {
            Uri baseAddress = new Uri("http://localhost:8000/UESamples/HelloService");

            using (ServiceHost serviceHost = new ServiceHost(typeof(HelloService), baseAddress))
            {
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
