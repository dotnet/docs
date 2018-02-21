---
title: "Sending and Receiving Faults"
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
  - "handling faults [WCF], sending"
ms.assetid: 7be6fb96-ce2a-450b-aebe-f932c6a4bc5d
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Sending and Receiving Faults
SOAP faults convey error condition information from a service to a client and in the duplex case from a client to a service in an interoperable way. Typically a service defines custom fault content and specifies which operations can return them. (For more information, see [Defining and Specifying Faults](../../../docs/framework/wcf/defining-and-specifying-faults.md).) This topic discusses how a service or duplex client can send those faults when the corresponding error condition has occurred and how a client or service application handles these faults. For an overview of error handling in [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] applications, see [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md).  
  
## Sending SOAP Faults  
 Declared SOAP faults are those in which an operation has a <xref:System.ServiceModel.FaultContractAttribute?displayProperty=nameWithType> that specifies a custom SOAP fault type. Undeclared SOAP faults are those that are not specified in the contract for an operation.  
  
### Sending Declared Faults  
 To send a declared SOAP fault, detect the error condition for which the SOAP fault is appropriate and throw a new <xref:System.ServiceModel.FaultException%601?displayProperty=nameWithType> where the type parameter is a new object of the type specified in the <xref:System.ServiceModel.FaultContractAttribute> for that operation. The following code example shows the use of <xref:System.ServiceModel.FaultContractAttribute> to specify that the `SampleMethod` operation can return a SOAP fault with the detail type of `GreetingFault`.  
  
 [!code-csharp[FaultContractAttribute#4](../../../samples/snippets/csharp/VS_Snippets_CFX/faultcontractattribute/cs/services.cs#4)]
 [!code-vb[FaultContractAttribute#4](../../../samples/snippets/visualbasic/VS_Snippets_CFX/faultcontractattribute/vb/services.vb#4)]  
  
 To convey the `GreetingFault` error information to the client, catch the appropriate error condition and throw a new <xref:System.ServiceModel.FaultException%601?displayProperty=nameWithType> of type `GreetingFault` with a new `GreetingFault` object as the argument, as in the following code example. If the client is an [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client application, it experiences this as a managed exception where the type is <xref:System.ServiceModel.FaultException%601?displayProperty=nameWithType> of type `GreetingFault`.  
  
 [!code-csharp[FaultContractAttribute#5](../../../samples/snippets/csharp/VS_Snippets_CFX/faultcontractattribute/cs/services.cs#5)]
 [!code-vb[FaultContractAttribute#5](../../../samples/snippets/visualbasic/VS_Snippets_CFX/faultcontractattribute/vb/services.vb#5)]  
  
### Sending Undeclared Faults  
 Sending undeclared faults can be very useful to quickly diagnose and debug problems in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications, but its usefulness as a debugging tool is limited. More generally, when debugging it is recommended that you use the <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> property. When you set this value to true, clients experience such faults as <xref:System.ServiceModel.FaultException%601> exceptions of type <xref:System.ServiceModel.ExceptionDetail>.  
  
> [!IMPORTANT]
>  Because managed exceptions can expose internal application information, setting <xref:System.ServiceModel.ServiceBehaviorAttribute.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> to `true` can permit [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients to obtain information about internal service operation exceptions, including personally identifiable or other sensitive information.  
>   
>  Therefore, setting <xref:System.ServiceModel.ServiceBehaviorAttribute.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> to `true` is only recommended as a way of temporarily debugging a service application. In addition, the WSDL for a method that returns unhandled managed exceptions in this way does not contain the contract for the <xref:System.ServiceModel.FaultException%601> of type <xref:System.ServiceModel.ExceptionDetail>. Clients must expect the possibility of an unknown SOAP fault (returned to [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients as <xref:System.ServiceModel.FaultException?displayProperty=nameWithType> objects) to obtain the debugging information properly.  
  
 To send an undeclared SOAP fault, throw a <xref:System.ServiceModel.FaultException?displayProperty=nameWithType> object (that is, not the generic type <xref:System.ServiceModel.FaultException%601>) and pass the string to the constructor. This is exposed to the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client applications as a thrown <xref:System.ServiceModel.FaultException?displayProperty=nameWithType> exception where the string is available by calling the <xref:System.ServiceModel.FaultException%601.ToString%2A?displayProperty=nameWithType> method.  
  
> [!NOTE]
>  If you declare a SOAP fault of type string, and then throw this in your service as a <xref:System.ServiceModel.FaultException%601> where the type parameter is a <xref:System.String?displayProperty=nameWithType> the string value is assigned to the <xref:System.ServiceModel.FaultException%601.Detail%2A?displayProperty=nameWithType> property, and is not available from <xref:System.ServiceModel.FaultException%601.ToString%2A?displayProperty=nameWithType>.  
  
## Handling Faults  
 In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients, SOAP faults that occur during communication that are of interest to client applications are raised as managed exceptions. While there are many exceptions that can occur during the execution of any program, applications using the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client programming model can expect to handle exceptions of the following two types as a result of communication.  
  
-   <xref:System.TimeoutException>  
  
-   <xref:System.ServiceModel.CommunicationException>  
  
 <xref:System.TimeoutException> objects are thrown when an operation exceeds the specified timeout period.  
  
 <xref:System.ServiceModel.CommunicationException> objects are thrown when there is some recoverable communication error condition on either the service or the client.  
  
 The <xref:System.ServiceModel.CommunicationException> class has two important derived types, <xref:System.ServiceModel.FaultException> and the generic <xref:System.ServiceModel.FaultException%601> type.  
  
 <xref:System.ServiceModel.FaultException> exceptions are thrown when a listener receives a fault that is not expected or specified in the operation contract; usually this occurs when the application is being debugged and the service has the <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> property set to `true`.  
  
 <xref:System.ServiceModel.FaultException%601> exceptions are thrown on the client when a fault that is specified in the operation contract is received in response to a two-way operation (that is, a method with an <xref:System.ServiceModel.OperationContractAttribute> attribute with <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> set to `false`).  
  
> [!NOTE]
>  When an [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service has the <xref:System.ServiceModel.ServiceBehaviorAttribute.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> property set to `true` the client experiences this as an undeclared <xref:System.ServiceModel.FaultException%601> of type <xref:System.ServiceModel.ExceptionDetail>. Clients can either catch this specific fault or handle the fault in a catch block for <xref:System.ServiceModel.FaultException>.  
  
 Typically, only <xref:System.ServiceModel.FaultException%601>, <xref:System.TimeoutException>, and <xref:System.ServiceModel.CommunicationException> exceptions are of interest to clients and services.  
  
> [!NOTE]
>  Other exceptions, of course, do occur. Unexpected exceptions include catastrophic failures like <xref:System.OutOfMemoryException?displayProperty=nameWithType>; typically applications should not catch such methods.  
  
### Catch Fault Exceptions in the Correct Order  
 Because <xref:System.ServiceModel.FaultException%601> derives from <xref:System.ServiceModel.FaultException>, and <xref:System.ServiceModel.FaultException> derives from <xref:System.ServiceModel.CommunicationException>, it is important to catch these exceptions in the proper order. If, for example, you have a try/catch block in which you first catch <xref:System.ServiceModel.CommunicationException>, all specified and unspecified SOAP faults are handled there; any subsequent catch blocks to handle a custom <xref:System.ServiceModel.FaultException%601> exception are never invoked.  
  
 Remember that one operation can return any number of specified faults. Each fault is a unique type and must be handled separately.  
  
### Handle Exceptions When Closing the Channel  
 Most of the preceding discussion has to do with faults sent in the course of processing application messages, that is, messages explicitly sent by the client when the client application calls operations on the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object.  
  
 Even with local objects disposing the object can either raise or mask exceptions that occur during the recycling process. Something similar can occur when you use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client objects. When you call operations you are sending messages over an established connection. Closing the channel can throw exceptions if the connection cannot be cleanly closed or is already closed, even if all the operations returned properly.  
  
 Typically, client object channels are closed in one of the following ways:  
  
-   When the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object is recycled.  
  
-   When the client application calls <xref:System.ServiceModel.ClientBase%601.Close%2A?displayProperty=nameWithType>.  
  
-   When the client application calls <xref:System.ServiceModel.ICommunicationObject.Close%2A?displayProperty=nameWithType>.  
  
-   When the client application calls an operation that is a terminating operation for a session.  
  
 In all cases, closing the channel instructs the channel to begin closing any underlying channels that may be sending messages to support complex functionality at the application level. For example, when a contract requires sessions a binding attempts to establish a session by exchanging messages with the service channel until a session is established. When the channel is closed, the underlying session channel notifies the service that the session is terminated. In this case, if the channel has already aborted, closed, or is otherwise unusable (for example, when a network cable is unplugged), the client channel cannot inform the service channel that the session is terminated and an exception can result.  
  
### Abort the Channel If Necessary  
 Because closing the channel can also throw exceptions, then, it is recommended that in addition to catching fault exceptions in the correct order, it is important to abort the channel that was used in making the call in the catch block.  
  
 If the fault conveys error information specific to an operation and it remains possible that others can use it, there is no need to abort the channel (although these cases are rare). In all other cases, it is recommended that you abort the channel. For a sample that demonstrates all of these points, see [Expected Exceptions](../../../docs/framework/wcf/samples/expected-exceptions.md).  
  
 The following code example shows how to handle SOAP fault exceptions in a basic client application, including a declared fault and an undeclared fault.  
  
> [!NOTE]
>  This sample code does not use the `using` construct. Because closing channels can throw exceptions, it is recommended that applications create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client first, and then open, use, and close the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client in the same try block. For details, see [WCF Client Overview](../../../docs/framework/wcf/wcf-client-overview.md) and [Avoiding Problems with the Using Statement](../../../docs/framework/wcf/samples/avoiding-problems-with-the-using-statement.md).  
  
 [!code-csharp[FaultContractAttribute#3](../../../samples/snippets/csharp/VS_Snippets_CFX/faultcontractattribute/cs/client.cs#3)]
 [!code-vb[FaultContractAttribute#3](../../../samples/snippets/visualbasic/VS_Snippets_CFX/faultcontractattribute/vb/client.vb#3)]  
  
## See Also  
 <xref:System.ServiceModel.FaultException>  
 <xref:System.ServiceModel.FaultException%601>  
 <xref:System.ServiceModel.CommunicationException?displayProperty=nameWithType>  
 [Expected Exceptions](../../../docs/framework/wcf/samples/expected-exceptions.md)  
 [Avoiding Problems with the Using Statement](../../../docs/framework/wcf/samples/avoiding-problems-with-the-using-statement.md)
