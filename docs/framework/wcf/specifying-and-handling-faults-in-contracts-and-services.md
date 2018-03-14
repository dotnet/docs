---
title: "Specifying and Handling Faults in Contracts and Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "handling faults [WCF]"
ms.assetid: a9696563-d404-4905-942d-1e0834c26dea
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Specifying and Handling Faults in Contracts and Services
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] applications handle error situations by mapping managed exception objects to SOAP fault objects and SOAP fault objects to managed exception objects. The topics in this section discuss how to design contracts to expose error conditions as custom SOAP faults, how to return such faults as part of service implementation, and how clients catch such faults.  
  
## Error Handling Overview  
 In all managed applications, processing errors are represented by <xref:System.Exception> objects. In SOAP-based applications such as [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications, service methods communicate processing error information using SOAP fault messages. SOAP faults are message types that are included in the metadata for a service operation and therefore create a fault contract that clients can use to make their operation more robust or interactive. In addition, because SOAP faults are expressed to clients in XML form, it is a highly interoperable type system that clients on any SOAP platform can use, increasing the reach of your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] application.  
  
 Because [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications run under both types of error systems, any managed exception information that is sent to the client must be converted from exceptions into SOAP faults on the service, sent, and converted from SOAP faults to fault exceptions in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients. In the case of duplex clients, client contracts can also send SOAP faults back to a service. In either case, you can use the default service exception behaviors, or you can explicitly control whether—and how—exceptions are mapped to fault messages.  
  
 Two types of SOAP faults can be sent: *declared* and *undeclared*. Declared SOAP faults are those in which an operation has a <xref:System.ServiceModel.FaultContractAttribute?displayProperty=nameWithType> attribute that specifies a custom SOAP fault type. *Undeclared* SOAP faults are not specified in the contract for an operation.  
  
 It is strongly recommended that service operations declare their faults by using the <xref:System.ServiceModel.FaultContractAttribute> attribute to formally specify all SOAP faults that a client can expect to receive in the normal course of an operation. It is also recommended that you return in a SOAP fault only the information that a client must know to minimize information disclosure.  
  
 Typically, services (and duplex clients) take the following steps to successfully integrate error handling into their applications:  
  
-   Map exception conditions to custom SOAP faults.  
  
-   Clients and services send and receive SOAP faults as exceptions.  
  
 In addition, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients and services can use undeclared soap faults for debugging purposes and can extend the default error behavior. The following sections discuss these tasks and concepts.  
  
## Map Exceptions to SOAP Faults  
 The first step in creating an operation that handles error conditions is to decide under what conditions a client application should be informed about errors. Some operations have error conditions specific to their functionality. For example, a `PurchaseOrder` operation might return specific information to customers who are no longer permitted to initiate a purchase order. In other cases, such as a `Calculator` service, a more general `MathFault` SOAP fault may be able to describe all error conditions across an entire service. Once the error conditions of clients of your service are identified, a custom SOAP fault can be constructed and the operation can be marked as returning that SOAP fault when its corresponding error condition arises.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] this step of developing your service or client, see [Defining and Specifying Faults](../../../docs/framework/wcf/defining-and-specifying-faults.md).  
  
## Clients and Services Handle SOAP Faults as Exceptions  
 Identifying operation error conditions, defining custom SOAP faults, and marking those operations as returning those faults are the first steps in successful error handling in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications. The next step is to properly implement the sending and receiving of these faults. Typically services send faults to inform client applications about error conditions, but duplex clients can also send SOAP faults to services.  
  
 [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Sending and Receiving Faults](../../../docs/framework/wcf/sending-and-receiving-faults.md).  
  
## Undeclared SOAP Faults and Debugging  
 Declared SOAP faults are extremely useful for building robust, interoperable, distributed applications. However, in some cases it is useful for a service (or duplex client) to send an undeclared SOAP fault, one that is not mentioned in the Web Services Description Language (WSDL) for that operation. For example, when developing a service, unexpected situations can occur in which it is useful for debugging purposes to send information back to the client. In addition, you can set the <xref:System.ServiceModel.ServiceBehaviorAttribute.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> property or the <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> property to `true` to permit [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients to obtain information about internal service operation exceptions. Both sending individual faults and setting the debugging behavior properties are described in [Sending and Receiving Faults](../../../docs/framework/wcf/sending-and-receiving-faults.md).  
  
> [!IMPORTANT]
>  Because managed exceptions can expose internal application information, setting <xref:System.ServiceModel.ServiceBehaviorAttribute.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> to `true` can permit [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients to obtain information about internal service operation exceptions, including personally identifiable or other sensitive information.  
>   
>  Therefore, setting <xref:System.ServiceModel.ServiceBehaviorAttribute.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A?displayProperty=nameWithType> to `true` is recommended only as a way to temporarily debug a service application. In addition, the WSDL for a method that returns unhandled managed exceptions in this way does not contain the contract for the <xref:System.ServiceModel.FaultException%601> of type <xref:System.ServiceModel.ExceptionDetail>. Clients must expect the possibility of an unknown SOAP fault (returned to [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] clients as <xref:System.ServiceModel.FaultException?displayProperty=nameWithType> objects) to obtain the debugging information properly.  
  
## Customizing Error Handling with IErrorHandler  
 If you have special requirements to either customize the response message to the client when an application-level exception happens or perform some custom processing after the response message is returned, implement the <xref:System.ServiceModel.Dispatcher.IErrorHandler?displayProperty=nameWithType> interface.  
  
## Fault Serialization Issues  
 When deserializing a fault contract, WCF first attempts to match the fault contract name in the SOAP message with the fault contract type. If it cannot find an exact match it will then search the list of available fault contracts in alphabetical order for a compatible type. If two fault contracts are compatible types (one is a subclass of another, for example) the wrong type may be used to de-serialize the fault. This only occurs if the fault contract does not specify a name, namespace, and action. To prevent this issue from occurring, always fully qualify fault contracts by specifying the name, namespace, and action attributes. Additionally if you have defined a number of related fault contracts derived from a shared base class, make sure to mark any new members with `[DataMember(IsRequired=true)]`. For more information on this `IsRequired` attribute see, <xref:System.Runtime.Serialization.DataMemberAttribute>. This will prevent a base class from being a compatible type and force the fault to be deserialized into the correct derived type.  
  
## See Also  
 <xref:System.ServiceModel.FaultException>  
 <xref:System.ServiceModel.FaultContractAttribute>  
 <xref:System.ServiceModel.FaultException>  
 <xref:System.Xml.Serialization.XmlSerializer>  
 <xref:System.ServiceModel.XmlSerializerFormatAttribute>  
 <xref:System.ServiceModel.FaultContractAttribute>  
 <xref:System.ServiceModel.CommunicationException>  
 <xref:System.ServiceModel.FaultContractAttribute.Action%2A>  
 <xref:System.ServiceModel.FaultException.Code%2A>  
 <xref:System.ServiceModel.FaultException.Reason%2A>  
 <xref:System.ServiceModel.FaultCode.SubCode%2A>  
 <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A>  
 [Defining and Specifying Faults](../../../docs/framework/wcf/defining-and-specifying-faults.md)
