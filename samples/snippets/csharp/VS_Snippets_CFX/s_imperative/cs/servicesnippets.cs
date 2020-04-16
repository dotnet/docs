using System;

using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.Generic;

namespace Microsoft.ServiceModel.Samples
{
    public class serviceSnippets
    {
        public static void Snippet3()
        {
            // <Snippet3>
             Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
             ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            // Create a custom binding that contains two binding elements.
            ReliableSessionBindingElement reliableSession = new ReliableSessionBindingElement();
            reliableSession.Ordered = true;

            HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
            httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous;
            httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

            BindingElement[] elements = new BindingElement[2];
            elements[0] = reliableSession;
            elements[1] = httpTransport;

            CustomBinding binding = new CustomBinding(elements);
            // </Snippet3>

           // Add an endpoint using that binding.
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, "");

            // Add a MEX endpoint.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.HttpGetUrl = new Uri("http://localhost:8001/servicemodelsamples");
            serviceHost.Description.Behaviors.Add(smb);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
        }

        public static void Snippet4()
        {
            // <Snippet4>
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            // Create a custom binding that contains two binding elements.
            ReliableSessionBindingElement reliableSession = new ReliableSessionBindingElement();
            reliableSession.Ordered = true;

            HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
            httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous;
            httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

            SynchronizedCollection<BindingElement> coll = new SynchronizedCollection<BindingElement>();
            coll.Add(reliableSession);
            coll.Add(httpTransport);

            CustomBinding binding = new CustomBinding(coll);
            // </Snippet4>

            // Add an endpoint using that binding.
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, "");

            // Add a MEX endpoint.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.HttpGetUrl = new Uri("http://localhost:8001/servicemodelsamples");
            serviceHost.Description.Behaviors.Add(smb);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
        }

        public static void Snippet5()
        {
            // <Snippet5>
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            // Create a custom binding that contains two binding elements.
            ReliableSessionBindingElement reliableSession = new ReliableSessionBindingElement();
            reliableSession.Ordered = true;

            HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
            httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous;
            httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

            BindingElement[] elements = new BindingElement[2];
            elements[0] = reliableSession;
            elements[1] = httpTransport;

            CustomBinding binding = new CustomBinding("MyCustomBinding", "http://localhost/service", elements);
            // </Snippet5>

            // Add an endpoint using that binding.
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, "");

            // Add a MEX endpoint.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.HttpGetUrl = new Uri("http://localhost:8001/servicemodelsamples");
            serviceHost.Description.Behaviors.Add(smb);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
        }
    }
}
