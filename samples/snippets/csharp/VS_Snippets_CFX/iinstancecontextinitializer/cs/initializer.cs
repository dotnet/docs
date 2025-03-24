// <snippet1>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.WCF.Documentation
{
    public class MyInstanceContextInitializer : IInstanceContextInitializer
    {
        public void Initialize(InstanceContext instanceContext, Message message)
        {
            MyInstanceContextExtension extension = new MyInstanceContextExtension();

            //Add your custom InstanceContext extension that will let you associate state with this instancecontext
            instanceContext.Extensions.Add(extension);
        }
    }

    //Create an Extension that will attach to each InstanceContext and let it retrieve the Id or whatever state you want to associate
    public class MyInstanceContextExtension : IExtension<InstanceContext>
    {

        //Associate an Id with each Instance Created.
        string _instanceId;

        public MyInstanceContextExtension()
        { _instanceId = Guid.NewGuid().ToString(); }

        public string InstanceId => _instanceId;

        public void Attach(InstanceContext owner)
        {
            Console.WriteLine("Attached to new InstanceContext.");
        }

        public void Detach(InstanceContext owner)
        {
            Console.WriteLine("Detached from InstanceContext.");
        }
    }

    public class InstanceInitializerBehavior : IEndpointBehavior
    {

        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters)
        { }

        //Apply the custom IInstanceContextProvider to the EndpointDispatcher.DispatchRuntime
        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
        {
            MyInstanceContextInitializer extension = new MyInstanceContextInitializer();
            endpointDispatcher.DispatchRuntime.InstanceContextInitializers.Add(extension);
        }

        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
        { }

        public void Validate(ServiceEndpoint endpoint)
        { }
    }

    public class InstanceInitializerBehaviorExtensionElement : BehaviorExtensionElement
    {

        public override Type BehaviorType
        {
            get { return typeof(InstanceInitializerBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new InstanceInitializerBehavior();
        }
    }
}
// </snippet1>
