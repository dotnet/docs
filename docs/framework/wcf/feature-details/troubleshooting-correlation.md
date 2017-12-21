---
title: "Troubleshooting Correlation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 98003875-233d-4512-a688-4b2a1b0b5371
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Troubleshooting Correlation
Correlation is used to relate workflow service messages to each other and to the correct workflow instance, but if it is not configured correctly, messages will not be received and applications will not work correctly. This topic provides an overview of several methods for troubleshooting correlation issues, and also lists some common issues that can occur when you use correlation.  
  
## Handle the UnknownMessageReceived Event  
 The <xref:System.ServiceModel.ServiceHostBase.UnknownMessageReceived> event occurs when an unknown message is received by a service, including messages that cannot be correlated to an existing instance. For self-hosted services, this event can be handled in the host application.  
  
```csharp  
host.UnknownMessageReceived += delegate(object sender, UnknownMessageReceivedEventArgs e)  
{  
    Console.WriteLine("Unknown Message Received:");  
    Console.WriteLine(e.Message);  
};  
```  
  
 For Web-hosted services, this event can be handled by deriving a class from <xref:System.ServiceModel.Activities.Activation.WorkflowServiceHostFactory> and overriding <xref:System.ServiceModel.Activities.Activation.WorkflowServiceHostFactory.CreateWorkflowServiceHost%2A>.  
  
```csharp  
class CustomFactory : WorkflowServiceHostFactory  
{  
    protected override WorkflowServiceHost CreateWorkflowServiceHost(Activity activity, Uri[] baseAddresses)  
    {  
        // Create the WorkflowServiceHost.  
        WorkflowServiceHost host = new WorkflowServiceHost(activity, baseAddresses);  
  
        // Handle the UnknownMessageReceived event.  
        host.UnknownMessageReceived += delegate(object sender, UnknownMessageReceivedEventArgs e)  
        {  
            Console.WriteLine("Unknown Message Received:");  
            Console.WriteLine(e.Message);  
        };  
  
        return host;  
    }  
}  
```  
  
 This custom <xref:System.ServiceModel.Activities.Activation.WorkflowServiceHostFactory> can then be specified in the `svc` file for the service.  
  
```  
<% @ServiceHost Language="C#" Service="OrderServiceWorkflow" Factory="CustomFactory" %>  
```  
  
 When this handler is invoked, the message can be retrieved by using the <xref:System.ServiceModel.UnknownMessageReceivedEventArgs.Message%2A> property of the <xref:System.ServiceModel.UnknownMessageReceivedEventArgs>, and will resemble the following message.  
  
```Output  
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">  
  <s:Header>  
    <To s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://localhost:8080/OrderService</To>  
    <Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService/AddItem</Action>  
  </s:Header>  
  <s:Body>  
    <AddItem xmlns="http://tempuri.org/">  
      <Item>Books</Item>  
    </AddItem>  
  </s:Body>  
</s:Envelope>  
```  
  
 Inspecting messages dispatched to the <xref:System.ServiceModel.ServiceHostBase.UnknownMessageReceived> handler may provide clues about why the message did not correlate to an instance of the workflow service.  
  
## Use Tracking to Monitor the Progress of the Workflow  
 Tracking provides a way to monitor the progress of a workflow. By default, tracking records are emitted for workflow life-cycle events, activity life-cycle events, fault propagation, and bookmark resumption. Additionally, custom tracking records can be emitted by custom activities. When troubleshooting correlation, the activity tracking records, the bookmark resumption records, and the fault propagation records are the most useful. The activity tracking records can be used to determine the current progress of the workflow and can help identify which messaging activity is currently waiting for messages. Bookmark resumption records are useful because they indicate that a message was received by the workflow, and fault propagation records provide a record of any faults in the workflow. To enable tracking, specify the desired <xref:System.Activities.Tracking.TrackingParticipant> in the <xref:System.ServiceModel.Activities.WorkflowServiceHost.WorkflowExtensions%2A> of the <xref:System.ServiceModel.Activities.WorkflowServiceHost>. In the following example, the `ConsoleTrackingParticipant` (from the [Custom Tracking](../../../../docs/framework/windows-workflow-foundation/samples/custom-tracking.md) sample) is configured by using the default tracking profile.  
  
```csharp  
host.WorkflowExtensions.Add(new ConsoleTrackingParticipant());  
```  
  
 A tracking participant such as the ConsoleTrackingParticipant is useful for self-hosted workflow services that have a console window. For a Web-hosted service, a tracking participant that logs the tracking information to a durable store should be used, such as the built-in <xref:System.Activities.Tracking.EtwTrackingParticipant>, or a custom tracking participant that logs the information to a file, such as the `TextWriterTrackingParticpant` from the [Tracking Using a Text File](../../../../docs/framework/windows-workflow-foundation/samples/tracking-using-a-text-file.md) sample.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] tracking and configuring tracking for a Web-hosted workflow service, see [Workflow Tracking and Tracing](../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md), [Configuring Tracking for a Workflow](../../../../docs/framework/windows-workflow-foundation/configuring-tracking-for-a-workflow.md), and the [Tracking &#91;WF Samples&#93;](../../../../docs/framework/windows-workflow-foundation/samples/tracking.md) samples.  
  
## Use WCF Tracing  
 WCF tracing provides tracing of the flow of messages to and from a workflow service. This tracing information is useful when troubleshooting correlation issues, especially for content-based correlation. To enable tracing, specify the desired trace listeners in the `system.diagnostics` section of the `web.config` file if the workflow service is Web-hosted, or the `app.config` file if the workflow service is self-hosted. To include the contents of the messages in the trace file, specify `true` for `logEntireMessage` in the `messageLogging` element in the `diagnostics` section of `system.serviceModel`. In the following example, tracing information, including the content of the messages, is configured to be written to a file that is named `service.svclog`.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  <system.diagnostics>  
    <sources>  
      <source name="System.ServiceModel" switchValue="Information" propagateActivity="true">  
        <listeners>  
          <add name="corr"/>  
        </listeners>  
      </source>  
      <source name="System.ServiceModel.MessageLogging">  
        <listeners>  
          <add name="corr"/>  
        </listeners>  
      </source>  
    </sources>  
  
    <sharedListeners>  
      <add name="corr" type="System.Diagnostics.XmlWriterTraceListener" initializeData="c:\logs\service.svclog">  
      </add>  
    </sharedListeners>  
  </system.diagnostics>  
  
  <system.serviceModel>  
    <diagnostics>  
      <messageLogging logEntireMessage="true" logMalformedMessages="false"  
         logMessagesAtServiceLevel="false" logMessagesAtTransportLevel="true" maxSizeOfMessageToLog="2147483647">  
      </messageLogging>  
    </diagnostics>  
  </system.serviceModel>  
</configuration>  
```  
  
 To view the trace information that is contained in `service.svclog`, the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) is used. This is especially useful when troubleshooting content-based correlation issues because you can view the message contents and see exactly what is being passed, and whether it matches the <xref:System.ServiceModel.CorrelationQuery> for the content-based correlation. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] WCF tracing, see [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md), [Configuring Tracing](../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md), and [Using Tracing to Troubleshoot Your Application](../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md).  
  
## Common Context Exchange Correlation Issues  
 Certain types of correlation require that a specific type of binding is used for the correlation to work correctly. Examples include request-reply correlation, which requires a two-way binding such as <xref:System.ServiceModel.BasicHttpBinding>, and context exchange correlation, which requires a context-based binding such as <xref:System.ServiceModel.BasicHttpContextBinding>. Most bindings support two-way operations so this is not a common issue for request-reply correlation, but there are only a handful of context-based bindings including <xref:System.ServiceModel.BasicHttpContextBinding>, <xref:System.ServiceModel.WSHttpContextBinding>, and <xref:System.ServiceModel.NetTcpContextBinding>. If one of these bindings is not used, the initial call to a workflow service will succeed, but subsequent calls will fail with the following <xref:System.ServiceModel.FaultException>.  
  
```Output  
There is no context attached to the incoming message for the service   
and the current operation is not marked with "CanCreateInstance = true".   
In order to communicate with this service check whether the incoming binding   
supports the context protocol and has a valid context initialized.  
```  
  
 The context information that is used for context correlation can be returned by the <xref:System.ServiceModel.Activities.SendReply> to the <xref:System.ServiceModel.Activities.Receive> activity that initializes the context correlation when using a two-way operation, or it can be specified by the caller if the operation is one-way. If the context is not sent by the caller or returned by the workflow service, then the same <xref:System.ServiceModel.FaultException> described previously will be returned when a subsequent operation is invoked.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Context Exchange](../../../../docs/framework/wcf/feature-details/context-exchange-correlation.md).  
  
## Common Request-Reply Correlation Issues  
 Request-reply correlation is used with a <xref:System.ServiceModel.Activities.Receive>/<xref:System.ServiceModel.Activities.SendReply> pair to implement a two-way operation in a workflow service and with a <xref:System.ServiceModel.Activities.Send>/<xref:System.ServiceModel.Activities.ReceiveReply> pair that invokes a two-way operation in another Web service. When invoking a two-way operation in a WCF service, the service can be either a traditional imperative code-based [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service or it can be a workflow service. To use request-reply correlation a two-way binding must be used, such as <xref:System.ServiceModel.BasicHttpBinding>, and the operations must be two-way.  
  
 If the workflow service has two-way operations in parallel, or overlapping <xref:System.ServiceModel.Activities.Receive>/<xref:System.ServiceModel.Activities.SendReply> or <xref:System.ServiceModel.Activities.Send>/<xref:System.ServiceModel.Activities.ReceiveReply> pairs, then the implicit correlation handle management provided by <xref:System.ServiceModel.Activities.WorkflowServiceHost> may not be sufficient, especially in high-stress scenarios, and messages may not be correctly routed. To prevent this issue from occurring, we recommend that you always explicitly specify a <xref:System.ServiceModel.Activities.CorrelationHandle> when using request-reply correlation. When using the **SendAndReceiveReply** and **ReceiveAndSendReply** templates from the Messaging section of the **Toolbox** in the workflow designer, a <xref:System.ServiceModel.Activities.CorrelationHandle> is explicitly configured by default. When building a workflow by using code, the <xref:System.ServiceModel.Activities.CorrelationHandle> is specified in the <xref:System.ServiceModel.Activities.Receive.CorrelationInitializers%2A> of the first activity in the pair. In the following example, a <xref:System.ServiceModel.Activities.Receive> activity is configured with an explicit <xref:System.ServiceModel.Activities.CorrelationInitializer.CorrelationHandle%2A> specified in the <xref:System.ServiceModel.Activities.RequestReplyCorrelationInitializer>.  
  
```csharp  
Variable<CorrelationHandle> RRHandle = new Variable<CorrelationHandle>();  
  
Receive StartOrder = new Receive  
{  
    CanCreateInstance = true,  
    ServiceContractName = OrderContractName,  
    OperationName = "StartOrder",  
    CorrelationInitializers =  
    {  
        new RequestReplyCorrelationInitializer  
        {  
            CorrelationHandle = RRHandle  
        }  
    }  
};  
  
SendReply ReplyToStartOrder = new SendReply  
{  
    Request = StartOrder,  
    Content = ... // Contains the return value, if any.  
};  
  
// Construct a workflow using StartOrder and ReplyToStartOrder.  
```  
  
 Persistence is not permitted between a <xref:System.ServiceModel.Activities.Receive>/<xref:System.ServiceModel.Activities.SendReply> pair or a <xref:System.ServiceModel.Activities.Send>/<xref:System.ServiceModel.Activities.ReceiveReply> pair. A no-persist zone is created that lasts until both activities have completed. If an activity, such as a delay activity, is in this no-persist zone and causes the workflow to become idle, the workflow will not persist even if it the host is configured to persist workflows when they become idle. If an activity, such as a persist activity, attempts to explicitly persist in the no-persist zone, a fatal exception is thrown, the workflow aborts, and a <xref:System.ServiceModel.FaultException> is returned to the caller. The fatal exception message is "System.InvalidOperationException: Persist activities cannot be contained within no persistence blocks.". This exception is not returned to the caller but can be observed if tracking is enabled. The message for the <xref:System.ServiceModel.FaultException> returned to the caller is "The operation could not be performed because WorkflowInstance '5836145b-7da2-49d0-a052-a49162adeab6' has completed".  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] request-reply correlation, see [Request-Reply](../../../../docs/framework/wcf/feature-details/request-reply-correlation.md).  
  
## Common Content Correlation Issues  
 Content-based correlation is used when a workflow service receives multiple messages and a piece of data in the exchanged messages identifies the desired instance. Content-based correlation uses this data in the message, such as a customer number or order ID, to route messages to the correct workflow instance. This section describes several common issues that may occur when using content-based correlation.  
  
### Ensure the Identifying Data Is Unique  
 The data that is used to identify the instance is hashed into a correlation key. Care must be taken to guarantee that the data that is used for correlation is unique or else collisions in the hashed key might occur and cause messages to be misrouted. For example, a correlation based only on a customer name may cause a collision because there may be multiple customers who have the same name. The colon (:) should not be used as part of the data that is used to correlate the message because it is already used to delimit the message query’s key and value to form the string that is subsequently hashed. If persistence is being used, make sure that the current identifying data has not been used by a previously persisted instance. Temporarily disabling persistence can help identify this issue. WCF tracing can be used to view the calculated correlation key and is useful for debugging this kind of issue.  
  
### Race Conditions  
 There is a small gap in time between the service receiving a message and the correlation actually being initialized, during which follow-up messages will be ignored. If a workflow service initializes the content-based correlation by using data passed from the client over a one-way operation, and the caller sends immediate follow-up messages, these messages will be ignored during this interval. This can be avoided by using a two-way operation to initialize the correlation, or by using a <xref:System.ServiceModel.Activities.TransactedReceiveScope>.  
  
### Correlation Query Issues  
 Correlation queries are used to specify what data in a message is used to correlate the message. This data is specified by using an XPath query. If messages to a service are not being dispatched even though everything appears to be correct, one strategy for troubleshooting is to specify a literal value that matches the value of the message data instead of an XPath query. To specify a literal value, use the `string` function. In the following example, a <xref:System.ServiceModel.MessageQuerySet> is configured to use a literal value of `11445` for the `OrderId` and the XPath query is commented out.  
  
```csharp  
MessageQuerySet = new MessageQuerySet  
{  
    {  
        "OrderId",   
        //new XPathMessageQuery("sm:body()/tempuri:StartOrderResponse/tempuri:OrderId")  
        new XPathMessageQuery("string('11445')")  
    }  
}  
```  
  
 If an XPath query is configured incorrectly such that no correlation data is retrieved, a fault is returned with the following message: "A correlation query yielded an empty result set. Please ensure correlation queries for the endpoint are correctly configured." One quick way to troubleshoot this is to replace the XPath query with a literal value as described in the previous section. This issue can occur if you use the XPath query builder in the **Add Correlation Initializers** or **CorrelatesOn Definition** dialog boxes and your workflow service uses message contracts. In the following example, a message contract class is defined.  
  
```csharp  
[MessageContract]  
public class AddItemMessage  
{  
    [MessageHeader]  
    public string CartId;  
  
    [MessageBodyMember]  
    public string Item;  
}  
```  
  
 This message contract is used by a <xref:System.ServiceModel.Activities.Receive> activity in a workflow. The `CartId` in the header of the message is used to correlate the message to the correct instance. If the XPath query that retrieves the `CartId` is created using the correlation dialogs in the workflow designer, the following incorrect XPath query is generated.  
  
```  
sm:body()/xg0:AddItemMessage/xg0:CartId  
```  
  
 This XPath query would be correct if the <xref:System.ServiceModel.Activities.Receive> activity used parameters for the data, but since it is using a message contract it is incorrect. The following XPath query is the correct XPath query to retrieve the `CartId` from the header.  
  
```  
sm:header()/tempuri:CartId  
```  
  
 This can be confirmed by examining the body of the message.  
  
```xml  
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">  
  <s:Header>  
    <Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService/AddItem</Action>  
    <h:CartId xmlns:h="http://tempuri.org/">80c95b41-c98d-4660-a6c1-99412206e54c</h:CartId>  
  </s:Header>  
  <s:Body>  
    <AddItemMessage xmlns="http://tempuri.org/">  
      <Item>Books</Item>  
    </AddItemMessage>  
  </s:Body>  
</s:Envelope>  
```  
  
 The following example shows a <xref:System.ServiceModel.Activities.Receive> activity configured for an `AddItem` operation that uses the previous message contract to receive data. The XPath query is correctly configured.  
  
```xaml  
<Receive CorrelatesWith="[CCHandle] OperationName="AddItem" ServiceContractName="p:IService">  
  <Receive.CorrelatesOn>  
    <XPathMessageQuery x:Key="key1">  
      <XPathMessageQuery.Namespaces>  
        <ssx:XPathMessageContextMarkup>  
          <x:String x:Key="xg0">http://schemas.datacontract.org/2004/07/MessageContractWFService</x:String>  
        </ssx:XPathMessageContextMarkup>  
      </XPathMessageQuery.Namespaces>sm:header()/tempuri:CartId</XPathMessageQuery>  
  </Receive.CorrelatesOn>  
  <ReceiveMessageContent DeclaredMessageType="m:AddItemMessage">  
    <p1:OutArgument x:TypeArguments="m:AddItemMessage">[AddItemMessage]</p1:OutArgument>  
  </ReceiveMessageContent>  
</Receive>  
```  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] content-based correlation, see [Content Based](../../../../docs/framework/wcf/feature-details/content-based-correlation.md) and the [Correlated Calculator](../../../../docs/framework/windows-workflow-foundation/samples/correlated-calculator.md) sample.
