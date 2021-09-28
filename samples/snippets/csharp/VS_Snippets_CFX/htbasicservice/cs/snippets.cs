using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
namespace Microsoft.ServiceModel.Samples.BasicWebProgramming
{
    class Snippets
    {
        public static void Snippet4()
        {
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8000/"));

            // <Snippet4>
            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.HttpHelpPageEnabled = false;
            // </Snippet4>
        }

        public static void Snippet5()
        {
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8000/"));

            // <Snippet5>
            host.Open();
            Console.WriteLine("Service is running");
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
            host.Close();
            // </Snippet5>
        }

        public static void Snippet6()
        {
        }
    }
}
