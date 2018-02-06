---
title: "Metadata Architecture Overview"
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
  - "metadata [WCF], overview"
ms.assetid: 1d37645e-086d-4d68-a358-f3c5b6e8205e
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Metadata Architecture Overview
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides a rich infrastructure for exporting, publishing, retrieving, and importing service metadata. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services use metadata to describe how to interact with the service's endpoints so that tools, such as Svcutil.exe, can automatically generate client code for accessing the service.  
  
 Most of the types that make up the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] metadata infrastructure reside in the <xref:System.ServiceModel.Description> namespace.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the <xref:System.ServiceModel.Description.ServiceEndpoint> class to describe endpoints in a service. You can use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to generate metadata for service endpoints or import service metadata to generate <xref:System.ServiceModel.Description.ServiceEndpoint> instances.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] represents the metadata for a service as an instance of the <xref:System.ServiceModel.Description.MetadataSet> type, the structure of which is strongly tied to the metadata serialization format defined in WS-MetadataExchange. The <xref:System.ServiceModel.Description.MetadataSet> type bundles the actual service metadata, such as Web Services Description Language (WSDL) documents, XML schema documents, or WS-Policy expressions, as a collection of <xref:System.ServiceModel.Description.MetadataSection> instances. Each <xref:System.ServiceModel.Description.MetadataSection?displayProperty=nameWithType> instance contains a specific metadata dialect and an identifier. A <xref:System.ServiceModel.Description.MetadataSection?displayProperty=nameWithType> can contain the following items in its <xref:System.ServiceModel.Description.MetadataSection.Metadata%2A?displayProperty=nameWithType> property:  
  
-   Raw metadata.  
  
-   A <xref:System.ServiceModel.Description.MetadataReference> instance.  
  
-   A <xref:System.ServiceModel.Description.MetadataLocation> instance.  
  
 A <xref:System.ServiceModel.Description.MetadataReference?displayProperty=nameWithType> instances  point to another metadata exchange (MEX) endpoint and <xref:System.ServiceModel.Description.MetadataLocation?displayProperty=nameWithType> instances point to a metadata document using an HTTP URL. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports using WSDL documents to describe service endpoints, service contracts, bindings, message exchange patterns, messages and fault messages implemented by a service. Data types used by the service are described in WSDL documents using XML schema. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Schema Import and Export](../../../../docs/framework/wcf/feature-details/schema-import-and-export.md). You can use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to export and import WSDL extensions for service behavior, contract behaviors, and binding elements that extend the functionality of a service. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Exporting Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/exporting-custom-metadata-for-a-wcf-extension.md).  
  
## Exporting Service Metadata  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], *metadata export* is the process of describing service endpoints and projecting them into a parallel, standardized representation that clients can use to understand how to use the service. To export metadata from <xref:System.ServiceModel.Description.ServiceEndpoint> instances, use an implementation of the <xref:System.ServiceModel.Description.MetadataExporter> abstract class. A <xref:System.ServiceModel.Description.MetadataExporter?displayProperty=nameWithType> implementation generates metadata that is encapsulated in a <xref:System.ServiceModel.Description.MetadataSet> instance.  
  
 The <xref:System.ServiceModel.Description.MetadataExporter?displayProperty=nameWithType> class provides a framework for generating policy expressions that describe the capabilities and requirements of an endpoint binding and its associated operations, messages, and faults. These policy expressions are captured in a <xref:System.ServiceModel.Description.PolicyConversionContext> instance. A <xref:System.ServiceModel.Description.MetadataExporter?displayProperty=nameWithType> implementation can then attach these policy expressions to the metadata it generates.  
  
 The <xref:System.ServiceModel.Description.MetadataExporter?displayProperty=nameWithType> calls into each <xref:System.ServiceModel.Channels.BindingElement?displayProperty=nameWithType> that implements the <xref:System.ServiceModel.Description.IPolicyExportExtension> interface in the binding of a <xref:System.ServiceModel.Description.ServiceEndpoint> when generating a <xref:System.ServiceModel.Description.PolicyConversionContext> object for the <xref:System.ServiceModel.Description.MetadataExporter?displayProperty=nameWithType> implementation to use. You can export new policy assertions by implementing the <xref:System.ServiceModel.Description.IPolicyExportExtension> interface on your custom implementations of the <xref:System.ServiceModel.Channels.BindingElement> type.  
  
 The <xref:System.ServiceModel.Description.WsdlExporter> type is the implementation of the <xref:System.ServiceModel.Description.MetadataExporter?displayProperty=nameWithType> abstract class included with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. The <xref:System.ServiceModel.Description.WsdlExporter> type generates WSDL metadata with attached policy expressions.  
  
 To export custom WSDL metadata or WSDL extensions for endpoint behaviors, contract behaviors, or binding elements in a service endpoint, you can implement the <xref:System.ServiceModel.Description.IWsdlExportExtension> interface. The <xref:System.ServiceModel.Description.WsdlExporter> looks at a <xref:System.ServiceModel.Description.ServiceEndpoint> instance for binding elements, operation behaviors, contract behaviors, and endpoint behaviors that implement the <xref:System.ServiceModel.Description.IWsdlExportExtension> interface when generating the WSDL document.  
  
## Publishing Service Metadata  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services publish metadata by exposing one or more metadata endpoints. Publishing service metadata makes service metadata available using standardized protocols, such as MEX and HTTP/GET requests. Metadata endpoints are similar to other service endpoints in that they have an address, a binding, and a contract. You can add metadata endpoints to a service host in configuration or in code.  
  
 To publish metadata endpoints for a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service, you must first add an instance of the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> service behavior to the service. Adding a <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> instance to your service augments your service with the ability to publish metadata by exposing one or more metadata endpoints. Once you add the <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> service behavior you can then expose metadata endpoints that support the MEX protocol or metadata endpoints that respond to HTTP/GET requests.  
  
 To add metadata endpoints that use the MEX protocol, add service endpoints to your service host that use the service contract named IMetadataExchange.[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] defines the <xref:System.ServiceModel.Description.IMetadataExchange> interface that has this service contract name. WS-MetadataExchange endpoints, or MEX endpoints, can use one of the four default bindings exposed by the static factory methods on the <xref:System.ServiceModel.Description.MetadataExchangeBindings> class to match the default bindings used by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] tools, such as Svcutil.exe. You can also configure MEX metadata endpoints using a custom binding.  
  
 The <xref:System.ServiceModel.Description.ServiceMetadataBehavior> uses a <xref:System.ServiceModel.Description.WsdlExporter?displayProperty=nameWithType> to export metadata for all service endpoints in your service. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] exporting metadata from a service, see [Exporting and Importing Metadata](../../../../docs/framework/wcf/feature-details/exporting-and-importing-metadata.md).  
  
 The <xref:System.ServiceModel.Description.ServiceMetadataBehavior> augments your service host by adding a <xref:System.ServiceModel.Description.ServiceMetadataExtension> instance as an extension to your service host. The <xref:System.ServiceModel.Description.ServiceMetadataExtension?displayProperty=nameWithType> provides the implementation for the metadata publishing protocols. You can also use the <xref:System.ServiceModel.Description.ServiceMetadataExtension?displayProperty=nameWithType> to get the service's metadata at runtime by accessing the <xref:System.ServiceModel.Description.ServiceMetadataExtension.Metadata%2A> property.  
  
> [!CAUTION]
>  If you add a MEX endpoint in your application configuration file and then attempt to add the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> to your service host in code you get the following exception:  
>   
>  System.InvalidOperationException: The contract name 'IMetadataExchange' could not be found in the list of contracts implemented by the service Service1. Add a ServiceMetadataBehavior to the configuration file or to the ServiceHost directly to enable support for this contract.  
>   
>  You can work around this issue by either adding the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> in the configuration file or adding both the endpoint and <xref:System.ServiceModel.Description.ServiceMetadataBehavior> in code.  
>   
>  For an example of adding <xref:System.ServiceModel.Description.ServiceMetadataBehavior> in an application configuration file, see the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md). For an example of adding <xref:System.ServiceModel.Description.ServiceMetadataBehavior> in code, see the [Self-Host](../../../../docs/framework/wcf/samples/self-host.md) sample.  
  
> [!CAUTION]
>  When publishing metadata for a service that exposes two different service contracts in which each contain an operation of the same name an exception is thrown. For example, if you have a service that exposes a service contract called ICarService that has an operation Get(Car c) and the same service exposes a service contract called IBookService that has an operation Get(Book b), an exception is thrown or an error message is displayed when generating the service's metadata. To work around this issue do one of the following:  
>   
>  -   Rename one of the operations.  
> -   Set the <xref:System.ServiceModel.OperationContractAttribute.Name%2A> to a different name.  
> -   Set one of the operations' namespaces to a different namespace using the <xref:System.ServiceModel.ServiceContractAttribute.Namespace%2A> property.  
  
## Retrieving Service Metadata  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can retrieve service metadata using standardized protocols such as WS-MetadataExchange and HTTP. Both of these protocols are supported by the <xref:System.ServiceModel.Description.MetadataExchangeClient> type. You retrieve service metadata using the <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> type by providing an address and an optional binding. The binding used by a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> instance can be one of the default bindings from the <xref:System.ServiceModel.Description.MetadataExchangeBindings> static class, a user-supplied binding, or a binding loaded from an endpoint configuration for the `IMetadataExchange` contract. The <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> can also resolve HTTP URL references to metadata using the <xref:System.Net.HttpWebRequest> type.  
  
 By default, a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> instance is tied to a single <xref:System.ServiceModel.Channels.ChannelFactoryBase> instance. You can change or replace the <xref:System.ServiceModel.Channels.ChannelFactoryBase> instance used by a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> by overriding the <xref:System.ServiceModel.Description.MetadataExchangeClient.GetChannelFactory%2A> virtual method. Similarly, you can change or replace the <xref:System.Net.HttpWebRequest?displayProperty=nameWithType> instance used by a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> to make HTTP/GET requests by overriding the <xref:System.ServiceModel.Description.MetadataExchangeClient.GetWebRequest%2A?displayProperty=nameWithType> virtual method.  
  
 You can retrieve service metadata using WS-MetadataExchange or HTTP/GET requests by using the Svcutil.exe tool and passing the **/target:metadata** switch and an address. Svcutil.exe downloads the metadata at the specified address and saves the files to disk. Svcutil.exe uses a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> instance internally and loads an MEX endpoint configuration (from the application configuration file) whose name matches the scheme of the address passed to Svcutil.exe, if one exists. Otherwise, Svcutil.exe defaults to using one of the bindings defined by the <xref:System.ServiceModel.Description.MetadataExchangeBindings> static factory type.  
  
## Importing Service Metadata  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], metadata import is the process of generating an abstract representation of a service or its component parts from its metadata. For example, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can import <xref:System.ServiceModel.Description.ServiceEndpoint> instances, <xref:System.ServiceModel.Channels.Binding> instances or <xref:System.ServiceModel.Description.ContractDescription> instances from a WSDL document for a service. To import service metadata in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], use an implementation of the <xref:System.ServiceModel.Description.MetadataImporter> abstract class. Types that derive from the <xref:System.ServiceModel.Description.MetadataImporter?displayProperty=nameWithType> class implement support for importing metadata formats that take advantage of the WS-Policy import logic in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 A <xref:System.ServiceModel.Description.MetadataImporter?displayProperty=nameWithType> implementation collects the policy expressions attached to the service metadata in a <xref:System.ServiceModel.Description.PolicyConversionContext> object. The <xref:System.ServiceModel.Description.MetadataImporter?displayProperty=nameWithType> then processes the policies as part of importing the metadata by calling the implementations of the <xref:System.ServiceModel.Description.IPolicyImportExtension> interface in the <xref:System.ServiceModel.Description.MetadataImporter.PolicyImportExtensions%2A> property.  
  
 You can add support for importing new policy assertions to a <xref:System.ServiceModel.Description.MetadataImporter?displayProperty=nameWithType> by adding your own implementation of the <xref:System.ServiceModel.Description.IPolicyImportExtension> interface to the <xref:System.ServiceModel.Description.MetadataImporter.PolicyImportExtensions%2A> collection on a <xref:System.ServiceModel.Description.MetadataImporter?displayProperty=nameWithType> instance. Alternatively, you can register your policy import extension in your client application configuration file.  
  
 The <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType> type is the implementation of the <xref:System.ServiceModel.Description.MetadataImporter?displayProperty=nameWithType> abstract class included with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. The <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType> type imports WSDL metadata with attached policies that are bundled in a <xref:System.ServiceModel.Description.MetadataSet> object.  
  
 You can add support for importing WSDL extensions by implementing the <xref:System.ServiceModel.Description.IWsdlImportExtension> interface and then adding your implementation to the <xref:System.ServiceModel.Description.WsdlImporter.WsdlImportExtensions%2A> property on your <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType> instance. The <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType> can also load implementations of the <xref:System.ServiceModel.Description.IWsdlImportExtension?displayProperty=nameWithType> interface registered in your client application configuration file.  
  
## Dynamic Bindings  
 You can dynamically update the binding that you use to create a channel to a service endpoint in the event that the binding for the endpoint changes or you want to create a channel to an endpoint that uses the same contract but has a different binding. You can use the <xref:System.ServiceModel.Description.MetadataResolver> static class to retrieve and import metadata at runtime for service endpoints that implement a specific contract. You can then use the imported <xref:System.ServiceModel.Description.ServiceEndpoint?displayProperty=nameWithType> objects to create a client or channel factory to the desired endpoint.  
  
## See Also  
 <xref:System.ServiceModel.Description>  
 [Metadata Formats](../../../../docs/framework/wcf/feature-details/metadata-formats.md)  
 [Exporting and Importing Metadata](../../../../docs/framework/wcf/feature-details/exporting-and-importing-metadata.md)  
 [Publishing Metadata](../../../../docs/framework/wcf/feature-details/publishing-metadata.md)  
 [Retrieving Metadata](../../../../docs/framework/wcf/feature-details/retrieving-metadata.md)  
 [Using Metadata](../../../../docs/framework/wcf/feature-details/using-metadata.md)  
 [Security Considerations with Metadata](../../../../docs/framework/wcf/feature-details/security-considerations-with-metadata.md)  
 [Extending the Metadata System](../../../../docs/framework/wcf/extending/extending-the-metadata-system.md)
