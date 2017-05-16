using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Service
{
    [ServiceContract()]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);

        [OperationContract]
        double Subtract(double n1, double n2);

        [OperationContract]
        double Multiply(double n1, double n2);

        [OperationContract]
        double Divide(double n1, double n2);
    }
     public class CalculatorService: ICalculator
    {
        public double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public double Divide(double n1, double n2)
        {
            return n1 / n2;
        }

        public static void Main()
        {
            // <Snippet0>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            // Enable MEX.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);

            serviceHost.Open();        

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            Console.WriteLine("servicehost has {0} ChannelDispatchers", serviceHost.ChannelDispatchers.Count);
            ChannelDispatcherCollection dispatchers = serviceHost.ChannelDispatchers;

            foreach (ChannelDispatcher disp in dispatchers)
            {
                Console.WriteLine("Binding name: " + disp.BindingName);
            }

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
            // </Snippet0>
        }
    }
}
