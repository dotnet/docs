---
title: "Endpoints: Addresses, Bindings, and Contracts"
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
  - "endpoints [WCF]"
  - "Windows Communication Foundation [WCF], endpoints"
  - "WCF [WCF], endpoints"
ms.assetid: 9ddc46ee-1883-4291-9926-28848c57e858
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Endpoints: Addresses, Bindings, and Contracts
All communication with a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service occurs through the *endpoints* of the service. Endpoints provide clients access to the functionality offered by a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 Each endpoint consists of four properties:  
  
-   An address that indicates where the endpoint can be found.  
  
-   A binding that specifies how a client can communicate with the endpoint.  
  
-   A contract that identifies the operations available.  
  
-   A set of behaviors that specify local implementation details of the endpoint.  
  
 This topic discusses this endpoint structure and explains how it is represented in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] object model.  
  
## The Structure of an Endpoint  
 Each endpoint consists of the following:  
  
-   Address: The address uniquely identifies the endpoint and tells potential consumers of the service where it is located. It is represented in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] object model by the <xref:System.ServiceModel.EndpointAddress> class. An <xref:System.ServiceModel.EndpointAddress> class contains:  
  
    -   A <xref:System.ServiceModel.EndpointAddress.Uri%2A> property, which represents the address of the service.  
  
    -   An <xref:System.ServiceModel.EndpointAddress.Identity%2A> property, which represents the security identity of the service and a collection of optional message headers. The optional message headers are used to provide additional and more detailed addressing information to identify or interact with the endpoint.  
  
     [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Specifying an Endpoint Address](../../../../docs/framework/wcf/specifying-an-endpoint-address.md).  
  
-   Binding: The binding specifies how to communicate with the endpoint. This includes:  
  
    -   The transport protocol to use (for example, TCP or HTTP).  
  
    -   The encoding to use for the messages (for example, text or binary).  
  
    -   The necessary security requirements (for example, SSL or SOAP message security).  
  
     [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [WCF Bindings Overview](../../../../docs/framework/wcf/bindings-overview.md). A binding is represented in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] object model by the abstract base class <xref:System.ServiceModel.Channels.Binding>. For most scenarios, users can use one of the system-provided bindings. For more information, see [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md).  
  
-   Contracts: The contract outlines what functionality the endpoint exposes to the client. A contract specifies:  
  
    -   What operations can be called by a client.  
  
    -   The form of the message.  
  
    -   The type of input parameters or data required to call the operation.  
  
    -   What type of processing or response message the client can expect.  
  
     For more information about defining a contract, see [Designing Service Contracts](../../../../docs/framework/wcf/designing-service-contracts.md).  
  
-   Behaviors: You can use endpoint behaviors to customize the local behavior of the service endpoint. Endpoint behaviors achieve this by participating in the process of building a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]runtime. An example of an endpoint behavior is the <xref:System.ServiceModel.Description.ServiceEndpoint.ListenUri%2A> property, which allows you to specify a different listening address than the SOAP or Web Services Description Language (WSDL) address. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [ClientViaBehavior](../../../../docs/framework/wcf/diagnostics/wmi/clientviabehavior.md).  
  
## Defining Endpoints  
 You can specify the endpoint for a service either imperatively using code or declaratively through configuration. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Create a Service Endpoint in Configuration](../../../../docs/framework/wcf/feature-details/how-to-create-a-service-endpoint-in-configuration.md) and [How to: Create a Service Endpoint in Code](../../../../docs/framework/wcf/feature-details/how-to-create-a-service-endpoint-in-code.md).  
  
## In This Section  
 This section explains the purpose of bindings, endpoints, and addresses; shows how to configure a binding and an endpoint; and demonstrates how to use the `ClientVia` behavior and `ListenUri` property.  
  
 [Addresses](../../../../docs/framework/wcf/feature-details/endpoint-addresses.md)  
 Describes how endpoints are addressed in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 [Bindings](../../../../docs/framework/wcf/feature-details/bindings.md)  
 Describes how bindings are used to specify the transport, encoding, and protocol details required for clients and services to communicate with each other.  
  
 [Contracts](../../../../docs/framework/wcf/feature-details/contracts.md)  
 Describes how contracts define the methods of a service.  
  
 [How to: Create a Service Endpoint in Configuration](../../../../docs/framework/wcf/feature-details/how-to-create-a-service-endpoint-in-configuration.md)  
 Describes how to create a service endpoint in configuration.  
  
 [How to: Create a Service Endpoint in Code](../../../../docs/framework/wcf/feature-details/how-to-create-a-service-endpoint-in-code.md)  
 Describes how to create a service endpoint in code.  
  
 [How to: Use Svcutil.exe to Validate Compiled Service Code](../../../../docs/framework/wcf/feature-details/how-to-use-svcutil-exe-to-validate-compiled-service-code.md)  
 Describes how to detect errors in service implementations and configurations without hosting the service using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md).  
  
## See Also  
 [Configuring Services](../../../../docs/framework/wcf/configuring-services.md)  
 [Extending Bindings](../../../../docs/framework/wcf/extending/extending-bindings.md)
