---
title: "Ordered Processing of Messages in Single Concurrency Mode"
ms.date: "03/30/2017"
ms.assetid: a90f5662-a796-46cd-ae33-30a4072838af
---
# Ordered Processing of Messages in Single Concurrency Mode
WCF makes no guarantees about the order in which messages are processed, unless the underlying channel is sessionful.  For instance, a WCF service that uses MsmqInputChannel, which is not a sessionful channel, will fail to process messages in order. There are some circumstances where a developer may want the in order processing behavior but not want to use sessions. This topic describes how to configure this behavior when a service is running in Single Concurrency Mode.  
  
## In-order Message Processing  
 A new attribute called <xref:System.ServiceModel.ServiceBehaviorAttribute.EnsureOrderedDispatch%2A> has been added to the <xref:System.ServiceModel.ServiceBehaviorAttribute>. When <xref:System.ServiceModel.ServiceBehaviorAttribute.EnsureOrderedDispatch%2A> is set to true and <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A> is set to <xref:System.ServiceModel.ConcurrencyMode.Single> messages sent to the service will be processed in order. The following code snippet illustrates how to set these attributes.  
  
```csharp
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, EnsureOrderedDispatch = true )]  
    class Service : IService  
    {  
         // ...  
    }  
```  
  
 If <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A> is set to any other value, an <xref:System.InvalidOperationException> is thrown.  
  
## See also

- [Sessions, Instancing, and Concurrency](../../../../docs/framework/wcf/feature-details/sessions-instancing-and-concurrency.md)
- [Concurrency](../../../../docs/framework/wcf/samples/concurrency.md)
