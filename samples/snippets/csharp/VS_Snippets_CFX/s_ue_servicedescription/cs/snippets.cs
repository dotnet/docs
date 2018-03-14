using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServiceDescriptionSnippet
{
    class MyCustomBehavior : IServiceBehavior
    {
        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

    class Snippets
    {
        public void Snippet3()
        {
            // <Snippet3>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            // Enable Mex
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);

            ServiceDescription sd = serviceHost.Description;
            sd.Behaviors.Add(new MyCustomBehavior());

            serviceHost.Open();
            // </Snippet3>

        }

        public void Snippet9()
        {
            // <Snippet9>
            ServiceDescription d = ServiceDescription.GetService(typeof(CalculatorService));
            foreach (IServiceBehavior isb in d.Behaviors)
            {
                Console.WriteLine(isb.GetType());
            }
            Console.WriteLine();
            // </Snippet9>
        }

        public void Snippet10()
        {
            // <Snippet10>
            ServiceDescription d = ServiceDescription.GetService(new CalculatorService());
            foreach (IServiceBehavior isb in d.Behaviors)
            {
                Console.WriteLine(isb.GetType());
            }
            Console.WriteLine();
            // </Snippet10>
        }
    }
}
