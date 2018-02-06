---
title: "Synchronous and Asynchronous Operations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "service contracts [WCF], synchronous operations"
  - "service contracts [WCF], asynchronous operations"
ms.assetid: db8a51cb-67e6-411b-9035-e5821ed350c9
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Synchronous and Asynchronous Operations
This topic discusses implementing and calling asynchronous service operations.  
  
 Many applications call methods asynchronously because it enables the application to continue doing useful work while the method call runs. [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] services and clients can participate in asynchronous operation calls at two distinct levels of the application, which provide [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications even more flexibility to maximize throughput balanced against interactivity.  
  
## Types of Asynchronous Operations  
 All service contracts in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], no matter the parameters types and return values, use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] attributes to specify a particular message exchange pattern between client and service. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] automatically routes inbound and outbound messages to the appropriate service operation or running client code.  
  
 The client possesses only the service contract, which specifies the message exchange pattern for a particular operation. Clients can offer the developer any programming model they choose, so long as the underlying message exchange pattern is observed. So, too, can services implement operations in any manner, so long as the specified message pattern is observed.  
  
 The independence of the service contract from either the service or client implementation enables the following forms of asynchronous execution in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications:  
  
-   Clients can invoke request/response operations asynchronously using a synchronous message exchange.  
  
-   Services can implement a request/response operation asynchronously using a synchronous message exchange.  
  
-   Message exchanges can be one-way, regardless of the implementation of the client or service.  
  
### Suggested Asynchronous Scenarios  
 Use an asynchronous approach in a service operation implementation if the operation service implementation makes a blocking call, such as doing I/O work. When you are in an asynchronous operation implementation, try to call asynchronous operations and methods to extend the asynchronous call path as far as possible. For example, call a `BeginOperationTwo()` from within `BeginOperationOne()`.  
  
-   Use an asynchronous approach in a client or calling application in the following cases:  
  
-   If you are invoking operations from a middle-tier application. ([!INCLUDE[crabout](../../../includes/crabout-md.md)] such scenarios, see [Middle-Tier Client Applications](../../../docs/framework/wcf/feature-details/middle-tier-client-applications.md).)  
  
-   If you are invoking operations within an ASP.NET page, use asynchronous pages.  
  
-   If you are invoking operations from any application that is single threaded, such as Windows Forms or [!INCLUDE[avalon1](../../../includes/avalon1-md.md)]. When using the event-based asynchronous calling model, the result event is raised on the UI thread, adding responsiveness to the application without requiring you to handle multiple threads yourself.  
  
-   In general, if you have a choice between a synchronous and asynchronous call, choose the asynchronous call.  
  
### Implementing an Asynchronous Service Operation  
 Asynchronous operations can be implemented by using one of the three following methods:  
  
1.  The task-based asynchronous pattern  
  
2.  The event-based asynchronous pattern  
  
3.  The IAsyncResult asynchronous pattern  
  
#### Task-Based Asynchronous Pattern  
 The task-based asynchronous pattern is the preferred way to implement asynchronous operations because it is the easiest and most straight forward. To use this method simply implement your service operation and specify a return type of Task\<T>, where T is the type returned by the logical operation. For example:  
  
```csharp  
public class SampleService:ISampleService   
{   
   // ...  
   public async Task<string> SampleMethodTaskAsync(string msg)   
   {   
      return Task<string>.Factory.StartNew(() =>   
      {   
         return msg;   
      });   
   }  
   // ...  
}  
```  
  
 The SampleMethodTaskAsync operation returns Task\<string> because the logical operation returns a string. For more information about the task-based asynchronous pattern, see [The Task-Based Asynchronous Pattern](http://go.microsoft.com/fwlink/?LinkId=232504).  
  
> [!WARNING]
>  When using the task-based asynchronous pattern, a T:System.AggregateException may be thrown if an exception occurs while waiting on the completion of the operation. This exception may occur on the client or services  
  
#### Event-Based Asynchronous Pattern  
 A service that supports the Event-based Asynchronous Pattern will have one or more operations named MethodNameAsync. These methods may mirror synchronous versions, which perform the same operation on the current thread. The class may also have a MethodNameCompleted event and it may have a MethodNameAsyncCancel (or simply CancelAsync) method. A client wishing to call the operation will define an event handler to be called when the operation completes,  
  
 The following code snippet illustrates how to declare asynchronous operations using the event-based asynchronous pattern.  
  
```csharp  
public class AsyncExample  
{  
    // Synchronous methods.  
    public int Method1(string param);  
    public void Method2(double param);  
  
    // Asynchronous methods.  
    public void Method1Async(string param);  
    public void Method1Async(string param, object userState);  
    public event Method1CompletedEventHandler Method1Completed;  
  
    public void Method2Async(double param);  
    public void Method2Async(double param, object userState);  
    public event Method2CompletedEventHandler Method2Completed;  
  
    public void CancelAsync(object userState);  
  
    public bool IsBusy { get; }  
  
    // Class implementation not shown.  
}  
```  
  
 For more information about the Event-based Asynchronous Pattern, see [The Event-Based Asynchronous Pattern](http://go.microsoft.com/fwlink/?LinkId=232515).  
  
#### IAsyncResult Asynchronous Pattern  
 A service operation can be implemented in an asynchronous fashion using the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] asynchronous programming pattern and marking the `<Begin>` method with the <xref:System.ServiceModel.OperationContractAttribute.AsyncPattern%2A> property set to `true`. In this case, the asynchronous operation is exposed in metadata in the same form as a synchronous operation: It is exposed as a single operation with a request message and a correlated response message. Client programming models then have a choice. They can represent this pattern as a synchronous operation or as an asynchronous one, so long as when the service is invoked a request-response message exchange takes place.  
  
 In general, with the asynchronous nature of the systems, you should not take a dependency on the threads.  The most reliable way of passing data to various stages of operation dispatch processing is to use extensions.  
  
 For an example, see [How to: Implement an Asynchronous Service Operation](../../../docs/framework/wcf/how-to-implement-an-asynchronous-service-operation.md).  
  
 To define a contract operation `X` that is executed asynchronously regardless of how it is called in the client application:  
  
-   Define two methods using the pattern `BeginOperation` and `EndOperation`.  
  
-   The `BeginOperation` method includes `in` and `ref` parameters for the operation and returns an <xref:System.IAsyncResult> type.  
  
-   The `EndOperation` method includes an <xref:System.IAsyncResult> parameter as well as the `out` and `ref` parameters and returns the operations return type.  
  
 For example, see the following method.  
  
```csharp  
int DoWork(string data, ref string inout, out string outonly)  
```  
  
```vb  
Function DoWork(ByVal data As String, ByRef inout As String, _out outonly As out) As Integer  
```  
  
 To create an asynchronous operation, the two methods would be:  
  
```csharp  
[OperationContract(AsyncPattern=true)]IAsyncResult BeginDoWork(string data,                           ref string inout,                           AsyncCallback callback,                           object state);int EndDoWork(ref string inout, out string outonly, IAsyncResult result);  
```  
  
```vb  
<OperationContract(AsyncPattern := True)>  _Function BeginDoWork(ByVal data As String, _                 ByRef inout As String, _                 ByVal callback As AsyncCallback, _                 ByVal state As Object) _As IAsyncResult Function EndDoWork(ByRef inout As String, _        ByRef outonly As String, _        ByVal result As IAsyncResult) _As Integer  
```  
  
> [!NOTE]
>  The <xref:System.ServiceModel.OperationContractAttribute> attribute is applied only to the `BeginDoWork` method. The resulting contract has one WSDL operation named `DoWork`.  
  
### Client-Side Asynchronous Invocations  
 A [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client application can use any of three asynchronous calling models described previously  
  
 When using the task-based model, simply call the operation using the await keyword as shown in the following code snippet.  
  
```  
await simpleServiceClient.SampleMethodTaskAsync("hello, world");  
```  
  
 Using the event-based asynchronous pattern only requires adding an event handler to receive a notification of the response -- and the resulting event is raised on the user interface thread automatically. To use this approach, specify both the **/async** and **/tcv:Version35** command options with the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md), as in the following example.  
  
```  
svcutil http://localhost:8000/servicemodelsamples/service/mex /async /tcv:Version35  
```  
  
 When this is done, Svcutil.exe generates a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client class with the event infrastructure that enables the calling application to implement and assign an event handler to receive the response and take the appropriate action. For a complete example, see [How to: Call Service Operations Asynchronously](../../../docs/framework/wcf/feature-details/how-to-call-wcf-service-operations-asynchronously.md).  
  
 The event-based asynchronous model, however, is only available in [!INCLUDE[netfx35_long](../../../includes/netfx35-long-md.md)]. In addition, it is not supported even in [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] when a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client channel is created by using a <xref:System.ServiceModel.ChannelFactory%601?displayProperty=nameWithType>. With [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client channel objects, you must use <xref:System.IAsyncResult?displayProperty=nameWithType> objects to invoke your operations asynchronously. To use this approach, specify the **/async** command option with the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md), as in the following example.  
  
```  
svcutil http://localhost:8000/servicemodelsamples/service/mex /async   
```  
  
 This generates a service contract in which each operation is modeled as a `<Begin>` method with the <xref:System.ServiceModel.OperationContractAttribute.AsyncPattern%2A> property set to `true` and a corresponding `<End>` method. For a complete example using a <xref:System.ServiceModel.ChannelFactory%601>, see [How to: Call Operations Asynchronously Using a Channel Factory](../../../docs/framework/wcf/feature-details/how-to-call-operations-asynchronously-using-a-channel-factory.md).  
  
 In either case, applications can invoke an operation asynchronously even if the service is implemented synchronously, in the same way that an application can use the same pattern to invoke asynchronously a local synchronous method. How the operation is implemented is not significant to the client; when the response message arrives, its content is dispatched to the client's asynchronous <`End`> method and the client retrieves the information.  
  
### One-Way Message Exchange Patterns  
 You can also create an asynchronous message exchange pattern in which one-way operations (operations for which the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A?displayProperty=nameWithType> is `true` have no correlated response) can be sent in either direction by the client or service independently of the other side. (This uses the duplex message exchange pattern with one-way messages.) In this case, the service contract specifies a one-way message exchange that either side can implement as asynchronous calls or implementations, or not, as appropriate. Generally, when the contract is an exchange of one-way messages, the implementations can largely be asynchronous because once a message is sent the application does not wait for a reply and can continue doing other work.  
  
### Event-based Asynchronous Clients and Message Contracts  
 The design guidelines for the event-based asynchronous model state that if more than one value is returned, one value is returned as the `Result` property and the others are returned as properties on the <xref:System.EventArgs> object. One result of this is that if a client imports metadata using the event-based asynchronous command options and the operation returns more than one value, the default <xref:System.EventArgs> object returns one value as the `Result` property and the remainder are properties of the <xref:System.EventArgs> object.  
  
 If you want to receive the message object as the `Result` property and have the returned values as properties on that object, use the **/messageContract** command option. This generates a signature that returns the response message as the `Result` property on the <xref:System.EventArgs> object. All internal return values are then properties of the response message object.  
  
## See Also  
 <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A>  
 <xref:System.ServiceModel.OperationContractAttribute.AsyncPattern%2A>
