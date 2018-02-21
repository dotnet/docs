---
title: "Messaging Activities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8498f215-1823-4aba-a6e1-391407f8c273
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Messaging Activities
Messaging activities allow workflows to send and receive WCF messages. By adding messaging activities to a workflow you can model any arbitrarily complex message exchange patterns (MEP).  
  
## Message Exchange Patterns  
 There are three basic message exchange patterns:  
  
-   **Datagram** - When using the datagram MEP the client sends a message to the service, but the service does not respond. This is sometimes called "fire and forget". A fire and forget exchange is one that requires out-of-band confirmation of successful delivery. The message might be lost in transit and never reach the service. If the client successfully sends a message, it does not guarantee that the service has received the message. The datagram is a fundamental building block for messaging, as you can build your own MEPs on top of it.  
  
-   **Request-Response** - When using the request-response MEP the client sends a message to the service, the service does the required processing, and then sends a response back to the client. The pattern consists of request-response pairs. Examples of request-response calls are remote procedure calls (RPC) and browser GET requests. This pattern is also known as half-duplex.  
  
-   **Duplex** - When using the duplex MEP the client and service can send messages to each other in any order. The duplex MEP is like a phone conversation, where each word being spoken is a message.  
  
 The messaging activities allow you to implement any of these basic MEPs as well as any arbitrarily complex MEP.  
  
## Messaging Activities  
 The [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] defines the following messaging activities:  
  
-   <xref:System.ServiceModel.Activities.Send>- Use the <xref:System.ServiceModel.Activities.Send> activity to send a message.  
  
-   <xref:System.ServiceModel.Activities.SendReply> - Use the <xref:System.ServiceModel.Activities.SendReply> activity to send a response to a received message. This activity is used by workflow services when implementing a request/reply MEP.  
  
-   <xref:System.ServiceModel.Activities.Receive>- Use the <xref:System.ServiceModel.Activities.Receive> activity to receive a message.  
  
-   <xref:System.ServiceModel.Activities.ReceiveReply> - Use the <xref:System.ServiceModel.Activities.ReceiveReply> activity to receive a reply message. This activity is used by workflow service clients when implementing a request/reply MEP.  
  
## Messaging Activities and Message Exchange Patterns  
 A datagram MEP involves a client sending a message and a service receiving the message. If the client is a workflow use a <xref:System.ServiceModel.Activities.Send> activity to send the message. To receive that message in a workflow, use a <xref:System.ServiceModel.Activities.Receive> activity. The <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.Receive> activities each have a property named `Content`. This property contains the data being sent or received. When implementing the request-response MEP both the client and the service use pairs of activities. The client uses a <xref:System.ServiceModel.Activities.Send> activity to send the message and a <xref:System.ServiceModel.Activities.ReceiveReply> activity to receive the response from the service. These two activities are associated with each other by the <xref:System.ServiceModel.Activities.ReceiveReply.Request%2A> property. This property is set to the <xref:System.ServiceModel.Activities.Send> activity that sent the original message. The service also uses a pair of associated activities: <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply>. These two activities are associated by the <xref:System.ServiceModel.Activities.SendReply.Request%2A> property. This property is set to the <xref:System.ServiceModel.Activities.Receive> activity that received the original message. The <xref:System.ServiceModel.Activities.ReceiveReply> and <xref:System.ServiceModel.Activities.SendReply> activities, like <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.Receive> allow you to send a <xref:System.ServiceModel.Channels.Message> instance or a message contract type.  
  
 Because of the long-running nature of workflows, it is important for the duplex pattern of communication to also support long-running conversations. To support long-running conversations, clients who initiate the conversation must provide the service with an opportunity to call it back at a later time when the data becomes available. For example, a purchase order request is submitted for manager approval, but it might not be processed for a day, a week, or even a year; the workflow that manages the purchase order approval must know to resume after the approval is given. This pattern of duplex communication is supported in workflows using correlation. To implement a duplex pattern, use <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.Receive> activities. On the <xref:System.ServiceModel.Activities.Receive> activity, initialize a correlation using the special key value of <!--zz <xref:System.ServiceModel.Activities.CorrelationHandle.CallbackHandleName%2A>-->`System.ServiceModel.Activities.CorrelationHandle.CallbackHandleName`. On the <xref:System.ServiceModel.Activities.Send> activity set that correlation handle as the <xref:System.ServiceModel.Activities.Send.CorrelatesWith%2A> property value. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Durable Duplex](../../../../docs/framework/wcf/feature-details/durable-duplex-correlation.md).  
  
> [!NOTE]
>  Workflow’s implementation of duplex using a callback correlation ("Durable Duplex") is intended for long-running conversations. This is not the same as WCF duplex with callback contracts where the conversation is short-running (the lifetime of the channel).  
  
## Message Formatting and Messaging Activities  
 The <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.ReceiveReply> activities have a property named `Content`. This property is of type <xref:System.ServiceModel.Activities.ReceiveContent> and represents data the <xref:System.ServiceModel.Activities.Receive> or <xref:System.ServiceModel.Activities.ReceiveReply> activity receives. The .NET Framework defines two related classes called <xref:System.ServiceModel.Activities.ReceiveMessageContent> and <xref:System.ServiceModel.Activities.ReceiveParametersContent> both of which are derived from <xref:System.ServiceModel.Activities.ReceiveContent>. Set the <xref:System.ServiceModel.Activities.Receive> or <xref:System.ServiceModel.Activities.ReceiveReply> activity’s `Content` property to an instance of one of these types to receive data into a workflow service. The type to use depends upon the type of data the activity receives. If the activity receives a `Message` object or a message contract type, use <xref:System.ServiceModel.Activities.ReceiveMessageContent>. If the activity receives a set of data contract or XML types that can be serialized, use <xref:System.ServiceModel.Activities.ReceiveParametersContent>. <xref:System.ServiceModel.Activities.ReceiveParametersContent> allows you to send multiple parameters, whereas <xref:System.ServiceModel.Activities.ReceiveMessageContent> only allows you to send one object, the message (or message contract type).  
  
> [!NOTE]
>  <xref:System.ServiceModel.Activities.ReceiveMessageContent> can also be used with a single data contract or XML type that can be serialized. The difference between using <xref:System.ServiceModel.Activities.ReceiveParametersContent> with a single parameter and the object passed directly to <xref:System.ServiceModel.Activities.ReceiveMessageContent> is the wire-format. The parameter’s content is wrapped in an XML element that corresponds to the operation name and the serialized object is wrapped in an XML element using the parameter name (for example, `<Echo><msg>Hello, World</msg></Echo>`). The message content is not wrapped by the operation name. Instead, the serialized object is placed within an XML element using the XML-qualified type name (for example, `<string>Hello, World</string>`).  
  
 The <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.SendReply> activities also have a property named `Content`. This property is of type <xref:System.ServiceModel.Activities.SendContent> and represents data the <xref:System.ServiceModel.Activities.Send> or <xref:System.ServiceModel.Activities.SendReply> activity sends. The .NET Framework defines two related types called <xref:System.ServiceModel.Activities.SendMessageContent> and <xref:System.ServiceModel.Activities.SendParametersContent> both of which are derived from <xref:System.ServiceModel.Activities.SendContent>. Set the <xref:System.ServiceModel.Activities.Send> or <xref:System.ServiceModel.Activities.SendReply> activity’s `Content` property to an instance of one of these types to send data from a workflow service. The type to use depends upon the type of data the activity sends. If the activity sends a `Message` object or a message contract type, use <xref:System.ServiceModel.Activities.SendMessageContent>. If the activity sends a data contract type use <xref:System.ServiceModel.Activities.SendParametersContent>. <xref:System.ServiceModel.Activities.SendParametersContent> allows you to send multiple parameters, whereas <xref:System.ServiceModel.Activities.SendMessageContent> only allows you to send one object, the message (or the message contract type).  
  
 When programming imperatively with the messaging activities, you use the generic <xref:System.Activities.InArgument%601> and <xref:System.Activities.OutArgument%601> to wrap the objects you assign to the message or parameters properties of the <xref:System.ServiceModel.Activities.Send>, <xref:System.ServiceModel.Activities.SendReply>, <xref:System.ServiceModel.Activities.Receive>, and <xref:System.ServiceModel.Activities.ReceiveReply> activities. Use <xref:System.Activities.InArgument%601> for the <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.SendReply> activities and <xref:System.Activities.OutArgument%601> for <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.ReceiveReply> activities. `In` arguments are used with the send activities because the data is being passed into the activities. `Out` arguments are used with the receive activities because data is being passed out of the activities, as shown in the following example.  
  
```  
Receive reserveSeat = new Receive  
{   
    ...   
    Content = new ReceiveParametersContent  
    {  
        Parameters =  
        {  
            { "ReservationInfo", new OutArgument<ReservationRequest>(reservationInfo) }  
        }  
    }  
};  
SendReply reserveSeat = new SendReply  
{   
    ...   
    Request = reserveSeat,  
    Content = new SendParametersContent  
    {  
        Parameters =  
        {  
            { "ReservationId", new InArgument<string>(reservationId) }  
        }  
    },  
};  
```  
  
 When implementing a workflow service that defines a request/response operation that returns void, you must instantiate a <xref:System.ServiceModel.Activities.SendReply> activity and set the <xref:System.ServiceModel.Activities.SendReply.Content%2A> property to an empty instance of one of the content types (<xref:System.ServiceModel.Activities.SendMessageContent> or <xref:System.ServiceModel.Activities.SendParametersContent>) as shown in the following example.  
  
```  
Receive rcv = new Receive()  
{  
ServiceContractName = "IService",  
OperationName = "NullReturningContract",  
Content = new ReceiveParametersContent( new Dictionary<string, OutArgument>() { { "message", new OutArgument<string>() } } )  
};  
SendReply sr = new SendReply()  
{  
Request = rcv  
   Content = new SendParametersContent();  
};  
```  
  
## Add Service Reference  
 When calling a workflow service from a workflow application, [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] generates custom messaging activities that encapsulate the usual <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.ReceiveReply> activities used in a request/reply MEP. To use this feature right-click the client project in [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] and select **Add Service Reference**. Type the base address of the service in the address box and click Go. The available services are displayed in the **Services:** box. Expand the service node to display the contracts supported. Select the contract you want to call and the list of available operations is displayed in the **Operations** box. You can then specify the namespace for the generated activity and click **OK**. You then see a dialog that says the operation completed successfully and that the generated custom activities are in the toolbox after you have rebuilt the project. There is one activity for each operation defined on the service contract. After rebuilding the project you can drag and drop the custom activities onto your workflow and set any required properties in the properties window.  
  
<!--## Messaging Activity Templates  
 To make setting up a request/response MEP on the client and service easier, [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] provides two messaging activity templates. <xref:System.ServiceModel.Activities.Design.ReceiveAndSendReply> is used on the service and <xref:System.ServiceModel.Activities.Design.SendAndReceiveReply> is used on the client. In both cases the templates add the appropriate messaging activities to your workflow. On the service, the <xref:System.ServiceModel.Activities.Design.ReceiveAndSendReply> adds a <xref:System.ServiceModel.Activities.Receive> activity followed by a <xref:System.ServiceModel.Activities.SendReply> activity. The <xref:System.ServiceModel.Activities.SendReply.Request> property is automatically set to the <xref:System.ServiceModel.Activities.Receive> activity. On the client, the <xref:System.ServiceModel.Activities.Design.SendAndReceiveReply> adds a <xref:System.ServiceModel.Activities.Send> activity followed by a <xref:System.ServiceModel.Activities.ReceiveReply>. The <xref:System.ServiceModel.Activities.ReceiveReply.Request%2A> property is automatically set to the <xref:System.ServiceModel.Activities.Send> activity. To use these templates, just drag and drop the appropriate template onto your workflow.  
-->
## Messaging Activities and Transactions  
 When a call is made to a workflow service you may want to flow a transaction to the service operation. To do this place the <xref:System.ServiceModel.Activities.Receive> activity within a <xref:System.ServiceModel.Activities.TransactedReceiveScope> activity. The <xref:System.ServiceModel.Activities.TransactedReceiveScope> activity contains a `Receive` activity and a body. The transaction flowed to the service remains ambient throughout the execution of the body of the <xref:System.ServiceModel.Activities.TransactedReceiveScope>. The transaction is completed when the body finishes executing. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] workflows and transactions see [Workflow Transactions](../../../../docs/framework/windows-workflow-foundation/workflow-transactions.md).  
  
## See Also  
 [How to Send and Receive Faults in Workflow Services](http://go.microsoft.com/fwlink/?LinkId=189151)  
 [Creating a Long-running Workflow Service](../../../../docs/framework/wcf/feature-details/creating-a-long-running-workflow-service.md)
