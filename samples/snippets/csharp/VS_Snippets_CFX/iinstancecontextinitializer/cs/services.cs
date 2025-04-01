using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Microsoft.WCF.Documentation
{
    [ServiceContractAttribute(Namespace = "http://microsoft.wcf.documentation")]
    public interface ISampleService
    {

        [OperationContractAttribute]
        [FaultContractAttribute(typeof(SampleFault))]
        string SampleMethod(string msg);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    class SampleService : ISampleService, IDisposable
    {
        Guid _id;

        public SampleService()
        {
            _id = Guid.NewGuid();
        }

        [OperationBehavior()]
        public string SampleMethod(string msg)
        {
            InstanceContext ic = OperationContext.Current.InstanceContext;

            //Retrieve the InstanceContext extension you added during creation time.
            MyInstanceContextExtension extension = ic.Extensions.Find<MyInstanceContextExtension>();
            Console.WriteLine("InstanceContext ID : " + extension.InstanceId);
            Console.WriteLine("Service object ID : " + _id);

            // Retrieve the ChannelDispatcher IContextChannel extension.
            ChannelTrackerExtension channelExtension = OperationContext.Current.Channel.Extensions.Find<ChannelTrackerExtension>();
            Console.WriteLine($"Channel tracker says the channel hash code: {channelExtension.ChannelHashCode}.");

            // Retrieve the service host custom context:
            ServiceHostContext srvContext = OperationContext.Current.Host.Extensions.Find<ServiceHostContext>();
            if (srvContext != null)
                Console.WriteLine("ServiceHost object hash: " + srvContext.ID);
            //you have the state object and can retrieve whatever info you need
            Console.WriteLine($"The caller said: \"{msg}\"");
            return "The service greets you: " + msg;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Object destroyed:" + this._id);
            Console.ResetColor();
        }

        #endregion
    }

    // The detail type of the specified SOAP fault.
    [DataContractAttribute(Namespace = "http://microsoft.wcf.documentation")]
    public class SampleFault
    {
        [DataMemberAttribute(Name = "FaultMessage")]
        public string FaultMessage { get; set; }
    }
}
