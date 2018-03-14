// <snippet5>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.WCF.Documentation
{

  public class EnforceGreetingFaultBehavior : BehaviorExtensionElement, IErrorHandler, IServiceBehavior
  {
    public EnforceGreetingFaultBehavior()
    { Console.WriteLine("EnforceGreetingFaultBehavior created."); }

    protected override object CreateBehavior()
    { return this; }

    public override Type BehaviorType
    {
      get { return typeof(EnforceGreetingFaultBehavior); }
    }

    // <snippet6>
    #region IErrorHandler Members
    public bool HandleError(Exception error)
    {
      Console.WriteLine("HandleError called.");
      // Returning true indicates you performed your behavior.
      return true;
    }

    // This is a trivial implementation that converts Exception to FaultException<GreetingFault>.
    public void ProvideFault(
      Exception error,
      MessageVersion ver,
      ref Message msg
    )
    {
      Console.WriteLine("ProvideFault called. Converting Exception to GreetingFault....");
      FaultException<GreetingFault> fe 
        = new FaultException<GreetingFault>(new GreetingFault(error.Message));
      MessageFault fault = fe.CreateMessageFault();
      msg = Message.CreateMessage(
        ver, 
        fault, 
        "http://microsoft.wcf.documentation/ISampleService/SampleMethodGreetingFaultFault"
      );
    }
    #endregion
    // </snippet6>

    // <snippet7>
    // This behavior modifies no binding parameters.
    #region IServiceBehavior Members
    public void AddBindingParameters(
      ServiceDescription description, 
      ServiceHostBase serviceHostBase, 
      System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, 
      System.ServiceModel.Channels.BindingParameterCollection parameters
    )
    {
      return;
    }

    // This behavior is an IErrorHandler implementation and 
    // must be applied to each ChannelDispatcher.
    public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
    {
      Console.WriteLine("The EnforceGreetingFaultBehavior has been applied.");
      foreach(ChannelDispatcher chanDisp in serviceHostBase.ChannelDispatchers)
      {
        chanDisp.ErrorHandlers.Add(this);      
      }
    }

    // This behavior requires that the contract have a SOAP fault with a detail type of GreetingFault.
    public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
    {
      Console.WriteLine("Validate is called.");
      foreach (ServiceEndpoint se in description.Endpoints)
      {
        // Must not examine any metadata endpoint.
        if (se.Contract.Name.Equals("IMetadataExchange")
          && se.Contract.Namespace.Equals("http://schemas.microsoft.com/2006/04/mex"))
          continue;
        foreach (OperationDescription opDesc in se.Contract.Operations)
        {
          if (opDesc.Faults.Count == 0)
            throw new InvalidOperationException(String.Format(
              "EnforceGreetingFaultBehavior requires a "  
              + "FaultContractAttribute(typeof(GreetingFault)) in each operation contract.  "
              + "The \"{0}\" operation contains no FaultContractAttribute.",
              opDesc.Name)
            );
          bool gfExists = false;
          foreach (FaultDescription fault in opDesc.Faults)
          {
            if (fault.DetailType.Equals(typeof(GreetingFault)))
            {
              gfExists = true;
              continue;
            }
          }
          if (gfExists == false)
          {
            throw new InvalidOperationException(
    "EnforceGreetingFaultBehavior requires a FaultContractAttribute(typeof(GreetingFault)) in an operation contract."
            );
          }
        }
      }
    }
    #endregion
    // </snippet7>
  }
}
// </snippet5>
