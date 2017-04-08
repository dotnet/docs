using System;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace ServiceEndpointSnippets
{
    class MyEndpointBehavior : IEndpointBehavior
    {
        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

    class Snippet
    {
        public static void Snippet2()
        {
            // <Snippet2>
            string address = "http://localhost:8001/CalculatorService";

            ServiceEndpoint endpoint = new ServiceEndpoint(
                ContractDescription.GetContract(
                    typeof(ICalculator), 
                    typeof(CalculatorService)), 
                    new WSHttpBinding(), 
                    new EndpointAddress(address));
            // </Snippet2>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            ServiceEndpoint endpoint = serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            endpoint.Behaviors.Add(new MyEndpointBehavior());

            Console.WriteLine("List all behaviors:");
            foreach (IEndpointBehavior behavior in endpoint.Behaviors)
            {
                Console.WriteLine("Behavior: {0}", behavior.ToString());
            }
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            ServiceEndpoint endpoint = serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            Console.WriteLine("Service endpoint {0} contains the following:", endpoint.Name);
            Console.WriteLine("Binding: {0}", endpoint.Binding.ToString());
            Console.WriteLine("Contract: {0}", endpoint.Contract.ToString());
            Console.WriteLine("ListenUri: {0}", endpoint.ListenUri.ToString());
            Console.WriteLine("ListenUriMode: {0}", endpoint.ListenUriMode.ToString());
            // </Snippet5>
        }

    }
}
