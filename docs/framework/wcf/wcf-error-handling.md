---
title: "WCF Error Handling"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1e4b1e0f-9598-449d-9d73-90bda62305b8
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Error Handling
The errors encountered by a WCF application belong to one of three groups:  
  
1.  Communication Errors  
  
2.  Proxy/Channel Errors  
  
3.  Application Errors  
  
 Communication errors occur when a network is unavailable, a client uses an incorrect address, or the service host is not listening for incoming messages. Errors of this type are returned to the client as <xref:System.ServiceModel.CommunicationException> or <xref:System.ServiceModel.CommunicationException>-derived classes.  
  
 Proxy/Channel errors are errors that occur within the channel or proxy itself. Errors of this type include: attempting to use a proxy or channel that has been closed, a contract mismatch exists between the client and service, or the client’s credentials are rejected by the service. There are many different types of errors in this category, too many to list here. Errors of this type are returned to the client as-is (no transformation is performed on the exception objects).  
  
 Application errors occur during the execution of a service operation. Errors of this kind are sent to the client as <xref:System.ServiceModel.FaultException> or <xref:System.ServiceModel.FaultException%601>.  
  
 Error handling in WCF is performed by one or more of the following:  
  
-   Directly handling the exception thrown. This is only done for communication and proxy/channel errors.  
  
-   Using fault contracts  
  
-   Implementing the <xref:System.ServiceModel.Dispatcher.IErrorHandler> interface  
  
-   Handling <xref:System.ServiceModel.ServiceHost> events  
  
## Fault Contracts  
 Fault contracts allow you to define the errors that can occur during service operation in a platform independent way. By default all exceptions thrown from within a service operation will be returned to the client as a <xref:System.ServiceModel.FaultException> object. The <xref:System.ServiceModel.FaultException> object will contain very little information. You can control the information sent to the client by defining a fault contract and returning the error as a <xref:System.ServiceModel.FaultException%601>. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md).  
  
## IErrorHandler  
 The <xref:System.ServiceModel.Dispatcher.IErrorHandler> interface allows you more control over how your WCF application responds to errors.  It gives you full control over the fault message that is returned to the client and allows you to perform custom error processing such as logging.  [!INCLUDE[crdefault](../../../includes/crabout-md.md)] <xref:System.ServiceModel.Dispatcher.IErrorHandler> and [Extending Control Over Error Handling and Reporting](../../../docs/framework/wcf/samples/extending-control-over-error-handling-and-reporting.md)  
  
## ServiceHost Events  
 The <xref:System.ServiceModel.ServiceHost> class hosts services and defines several events that may be needed for handling errors. For example:  
  
1.  <!--zz <xref:System.ServiceModel.ServiceHost.Faulted>-->  `System.ServiceModel.ServiceHost.Faulted`
  
2. <!--zz  <xref:System.ServiceModel.ServiceHost.UnknownMessageReceived>  --> `System.ServiceModel.ServiceHost.UnknownMessageReceived`
  
 [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] <xref:System.ServiceModel.ServiceHost>
