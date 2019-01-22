---
title: "Out-of-Order Message Processing"
ms.date: "03/30/2017"
ms.assetid: 33fc62a5-5d59-461c-a37a-0e1b51ac763d
---
# Out-of-Order Message Processing
Workflow services may depend on messages being sent in a specific order. A workflow service contains one or more <xref:System.ServiceModel.Activities.Receive> activities and each <xref:System.ServiceModel.Activities.Receive> activity is expecting a specific message. Without particular transport delivery guarantees, messages sent by clients may be delayed and therefore delivered in an order the workflow service may not expect. Implementing a workflow service that does not require messages be sent in a specific order is normally done using a Parallel activity. For a more complicated application protocol, the workflow would become very complex very quickly.  The out-of-order message processing feature in Windows Communication Foundation (WCF) allows you to create such a workflow without all of the complexity of nested Parallel activities. Out-of-order message processing is only supported on channels that support <xref:System.ServiceModel.Channels.ReceiveContext> such as the WCF MSMQ bindings.  
  
## Enabling Out-Of-Order Message Processing  
 Out-of-order message processing is enabled by setting the <xref:System.ServiceModel.Activities.WorkflowService.AllowBufferedReceive%2A> property to `true` on the WorkflowService. The following example shows how to set the <xref:System.ServiceModel.Activities.WorkflowService.AllowBufferedReceive%2A> property in code.  
  
```csharp  
// Code: Opt-in to Buffered Receive processing...  
WorkflowService service = new WorkflowService  
{  
    Name="MyService",  
    Body = workflow,  
    AllowBufferedReceive = true  
};  
```  
  
 You can also apply the `AllowBufferedReceive` attribute to a workflow service in XAML as shown in the following example.  
  
```xaml  
// Xaml: Opt-in to Buffered Receive processing...  
<WorkflowService AllowBufferedReceive="True">  
   <!--the actual children activities -->  
</Sequence>  
```  
  
## See also
 <xref:System.ServiceModel.Channels.ReceiveContext>  
 [Workflow Services](../../../../docs/framework/wcf/feature-details/workflow-services.md)  
 [Queues and Reliable Sessions](../../../../docs/framework/wcf/feature-details/queues-and-reliable-sessions.md)
