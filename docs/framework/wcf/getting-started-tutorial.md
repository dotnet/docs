---
title: "Getting Started Tutorial1"
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
  - "WCF [WCF], getting started"
  - "Windows Communication Foundation [WCF], getting started"
  - "getting started [WCF]"
ms.assetid: df939177-73cb-4440-bd95-092a421516a1
caps.latest.revision: 47
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Getting Started Tutorial
The topics contained in this section are intended to give you quick exposure to the [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] programming experience. They are designed to be completed in the order of the list at the bottom of this topic. Working through this tutorial gives you an introductory understanding of the steps required to create [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service and client applications. A service exposes one or more endpoints, each of which exposes one or more service operations. The *endpoint* of a service specifies an address where the service can be found, a binding that contains the information that describes how a client must communicate with the service, and a contract that defines the functionality provided by the service to its clients.  
  
 After you work through the sequence of topics in this tutorial, you will have a running service, and a client that calls the service. The first three topics describe how to define a service contract, how to implement the service contract, and how to host the service. The service that is created is self-hosted within a console application. Services can also be hosted under Internet Information Services (IIS). [!INCLUDE[crabout](../../../includes/crabout-md.md)] how to do this, see [How to: Host a WCF Service in IIS](../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-iis.md). The service is configured in code; however, services can also be configured within a configuration file. [!INCLUDE[crabout](../../../includes/crabout-md.md)] using a configuration file see [Configuring Services Using Configuration Files](../../../docs/framework/wcf/configuring-services-using-configuration-files.md).  
  
 The next three topics describe how to create a client proxy, configure the client application, and use the client proxy to call service operation exposed by the service. Services publish metadata that define the information a client application needs to communicate with the service. [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)] automates the process of accessing this metadata and uses it to construct and configure the client application for the service. If you are not using [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)], you can use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) to construct and configure the client application for the service.  
  
 All of the topics in this section assume you are using Visual Studio 2011 as the development environment. If you are using another development environment, ignore the [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)] specific instructions.  
  
> [!NOTE]
>  If you are running [!INCLUDE[wv](../../../includes/wv-md.md)] or later versions of the Windows operating system, you must start [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)] by going to the Start menu and right clicking Visual Studio 2011 and selecting **Run as Administrator**. To always launch Visual Studio 2011 as an administrator you can create a short cut, right click the short cut, select properties, select the **Compatibility** tab, and check the **Run this program as an administrator** checkbox. When you start Visual Studio 2011 with this shortcut, it will always run as administrator.  
  
 For sample applications that can be downloaded to your hard disk and run, see the topics in [Windows Communication Foundation Samples](http://msdn.microsoft.com/library/8ec9d192-5d81-4f64-bfd3-90c5e5858c91). For this topic, see, in particular, the [Getting Started](../../../docs/framework/wcf/samples/getting-started-sample.md).  
  
 For more in-depth information about creating services and clients, see [Basic WCF Programming](../../../docs/framework/wcf/basic-wcf-programming.md).  
  
## In This Section  
 [How to: Define a Service Contract](../../../docs/framework/wcf/how-to-define-a-wcf-service-contract.md)  
 Describes how to create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] contract using a user-defined interface. The contract defines the functionality exposed by the service.  
  
 [How to: Implement a Service Contract](../../../docs/framework/wcf/how-to-implement-a-wcf-contract.md)  
 Describes how to implement a service contract. Once a contract is define, it must be implemented with a service class.  
  
 [How to: Host and Run a Basic Service](../../../docs/framework/wcf/how-to-host-and-run-a-basic-wcf-service.md)  
 Describes how to configure an endpoint for the service in code and how to host the service in a console application. To become active, a service must be configured and hosted within a run-time environment. This environment creates the service and controls its context and lifetime.  
  
 [How to: Create a Client](../../../docs/framework/wcf/how-to-create-a-wcf-client.md)  
 Describes how to retrieve metadata used to create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client proxy from a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service. This process uses the Add Service Reference functionality within Visual Studio 2011.  
  
 [How to: Configure a Client](../../../docs/framework/wcf/how-to-configure-a-basic-wcf-client.md)  
 Describes how to configure a WCF client Configuring the client requires specifying the endpoint that the client uses to access the service.  
  
 [How to: Use a Client](../../../docs/framework/wcf/how-to-use-a-wcf-client.md)  
 Describes how to use the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client proxy to invoke service operations.  
  
## Reference  
 <xref:System.ServiceModel.ServiceContractAttribute>  
  
 <xref:System.ServiceModel.OperationContractAttribute>  
  
## Related Sections  
 [Windows Communication Foundation Samples](http://msdn.microsoft.com/library/8ec9d192-5d81-4f64-bfd3-90c5e5858c91)  
  
 [Basic Programming Lifecycle](../../../docs/framework/wcf/basic-programming-lifecycle.md)  
  
## See Also  
 [Conceptual Overview](../../../docs/framework/wcf/conceptual-overview.md)  
 [Guide to the Documentation](../../../docs/framework/wcf/guide-to-the-documentation.md)  
 [What Is Windows Communication Foundation](../../../docs/framework/wcf/whats-wcf.md)  
 [WCF Feature Details](../../../docs/framework/wcf/feature-details/index.md)
