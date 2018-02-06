---
title: "How to: Inspect or Modify Messages on the Client"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b8256335-f1c2-419f-b862-9f220ccad84c
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Inspect or Modify Messages on the Client
You can inspect or modify the incoming or outgoing messages across a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client by implementing a <xref:System.ServiceModel.Dispatcher.IClientMessageInspector?displayProperty=nameWithType> and inserting it into the client runtime. For more information, see [Extending Clients](../../../../docs/framework/wcf/extending/extending-clients.md). The equivalent feature on the service is the <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector?displayProperty=nameWithType>. For a complete code example see the [Message Inspectors](../../../../docs/framework/wcf/samples/message-inspectors.md) sample.  
  
### To inspect or modify messages  
  
1.  Implement the <xref:System.ServiceModel.Dispatcher.IClientMessageInspector?displayProperty=nameWithType> interface.  
  
2.  Implement a <xref:System.ServiceModel.Description.IEndpointBehavior?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.IContractBehavior?displayProperty=nameWithType> depending upon the scope at which you want to insert the client message inspector. <xref:System.ServiceModel.Description.IEndpointBehavior?displayProperty=nameWithType> allows you to change behavior at the endpoint level. <xref:System.ServiceModel.Description.IContractBehavior?displayProperty=nameWithType> allows you to change behavior at the contract level.  
  
3.  Insert the behavior prior to calling the <xref:System.ServiceModel.ClientBase%601.Open%2A?displayProperty=nameWithType> or the <xref:System.ServiceModel.ICommunicationObject.Open%2A?displayProperty=nameWithType> method on the <xref:System.ServiceModel.ChannelFactory%601?displayProperty=nameWithType>. For details, see [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md).  
  
## Example  
 The following code examples show, in order:  
  
-   A client inspector implementation.  
  
-   An endpoint behavior that inserts the inspector.  
  
-   A <xref:System.ServiceModel.Configuration.BehaviorExtensionElement>- derived class that allows you to add the behavior in a configuration file.  
  
-   A configuration file that adds the endpoint behavior which inserts the client message inspector into the client runtime.  
  
```csharp  
// Client message inspector  
public class SimpleMessageInspector : IClientMessageInspector  
{  
    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)  
    {  
        // Implement this method to inspect/modify messages after a message  
        // is received but prior to passing it back to the client   
        Console.WriteLine("AfterReceiveReply called");  
    }  
  
    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)  
    {  
        // Implement this method to inspect/modify messages before they   
        // are sent to the service  
        Console.WriteLine("BeforeSendRequest called");  
        return null;  
    }  
}  
```  
  
```csharp  
// Endpoint behavior  
public class SimpleEndpointBehavior : IEndpointBehavior  
{  
    public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)  
    {  
         // No implementation necessary  
    }  
  
    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)  
    {  
        clientRuntime.MessageInspectors.Add(new SimpleMessageInspector());  
    }  
  
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)  
    {  
         // No implementation necessary  
    }  
  
    public void Validate(ServiceEndpoint endpoint)  
    {  
         // No implementation necessary  
    }  
}  
```  
  
```csharp  
// Configuration element   
public class SimpleBehaviorExtensionElement : BehaviorExtensionElement  
{  
    public override Type BehaviorType  
    {  
        get { return typeof(SimpleEndpointBehavior); }  
    }  
  
    protected override object CreateBehavior()  
    {  
         // Create the  endpoint behavior that will insert the message  
         // inspector into the client runtime  
        return new SimpleEndpointBehavior();  
    }  
}  
```  
  
```xml
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
    <system.serviceModel>  
        <client>  
            <endpoint address="http://localhost:8080/SimpleService/"   
                      binding="wsHttpBinding"  
                      contract="ServiceReference1.IService1"  
                      name="WSHttpBinding_IService1"/>  
        </client>  
  
      <behaviors>  
        <endpointBehaviors>  
          <behavior name="clientInspectorsAdded">  
            <simpleBehaviorExtension />  
          </behavior>  
        </endpointBehaviors>  
      </behaviors>  
      <extensions>  
        <behaviorExtensions>  
          <add  
            name="simpleBehaviorExtension"  
            type="SimpleServiceLib.SimpleBehaviorExtensionElement, Host, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null"/>  
        </behaviorExtensions>  
      </extensions>  
    </system.serviceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.Dispatcher.IClientMessageInspector?displayProperty=nameWithType>  
 <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector?displayProperty=nameWithType>  
 [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md)
