using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  public class Inspector : IDispatchMessageInspector, IParameterInspector, IClientMessageInspector
  {
    // <snippet7>
    #region IDispatchMessageInspector Members
    public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
    {
      Console.WriteLine("IDispatchMessageInspector.AfterReceiveRequest called.");
      return null;
    }

    public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
    {
      Console.WriteLine("IDispatchMessageInspector.BeforeSendReply called.");
    }
    #endregion
    // </snippet7>

    // <snippet4>
    #region IParameterInspector Members
    public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
    {
      Console.WriteLine($"IParameterInspector.AfterCall called for {operationName} with return value {returnValue.ToString()}.");
    }

    public object BeforeCall(string operationName, object[] inputs)
    {
      Console.WriteLine($"IParameterInspector.BeforeCall called for {operationName}.");
      return null;
    }
    // </snippet4>

    #endregion

    //<snippet1>
    #region IClientMessageInspector Members
    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
    {
      Console.WriteLine("IClientMessageInspector.AfterReceiveReply called.");
      Console.WriteLine($"Message: {reply.ToString()}");
    }

    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
    {
      Console.WriteLine("IClientMessageInspector.BeforeSendRequest called.");
      return null;
    }
    //</snippet1>
    #endregion
  }
}
