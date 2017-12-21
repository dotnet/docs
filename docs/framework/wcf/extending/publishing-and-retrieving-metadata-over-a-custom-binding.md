---
title: "Publishing and Retrieving Metadata Over a Custom Binding"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 904e11b4-d90e-45c6-9ee5-c3472c90008c
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Publishing and Retrieving Metadata Over a Custom Binding
The <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> provides support for adding metadata endpoint to a service. These metadata endpoints can respond to HTTP GET requests at a URL that has a `?wsdl` querystring and to WS-Transfer GET requests as defined in the WS-MetadataExchange (MEX) specification. MEX endpoints implement the <xref:System.ServiceModel.Description.IMetadataExchange?displayProperty=nameWithType> contract.  
  
## Publishing Metadata Over a Custom Binding  
 The HTTP GET metadata endpoints and HTTPS GET metadata endpoints are enabled by setting the <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpGetEnabled%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetEnabled%2A?displayProperty=nameWithType> properties to `true`. The bindings for these endpoints cannot be configured.  
  
 The <xref:System.ServiceModel.Description.IMetadataExchange> contract, however, can be used with any endpoint, including those that use custom bindings, because <xref:System.ServiceModel.Description.IMetadataExchange> endpoints are identical to any other [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service endpoint. If you know how to modify the configuration of a system-provided binding, or you know how to configure a <xref:System.ServiceModel.Channels.CustomBinding?displayProperty=nameWithType>, then you can configure a binding for use with an <xref:System.ServiceModel.Description.IMetadataExchange> endpoint.  
  
## Retrieving Metadata Over a Custom Binding  
 Metadata can be retrieved from HTTP Get and HTTPS Get metadata endpoints using standard HTTP or HTTPS GET requests.  
  
 To retrieve metadata from a MEX metadata endpoint you can generally use one of the standard MEX bindings supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.Description.MetadataExchangeBindings?displayProperty=nameWithType>. The <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> type and the Svcutil.exe tool automatically select one of these standard MEX bindings based on the address of the specified metadata endpoint.  
  
 If a MEX metadata endpoint uses a different binding than one of the standard MEX bindings, you can configure the binding used by the <xref:System.ServiceModel.Description.MetadataExchangeClient> using code or by providing an <xref:System.ServiceModel.Description.IMetadataExchange> client endpoint configuration. The Svcutil.exe tool automatically loads from its configuration file an <xref:System.ServiceModel.Description.IMetadataExchange> client endpoint configuration that has the same name as the URI scheme for the metadata endpoint address.  
  
## Security  
 When publishing metadata over a custom binding, ensure that the binding provides the security support that your metadata requires. For example, to prevent information disclosure and ensure your client has the right to obtain the metadata, you can make your metadata and your application more secure by configuring your <xref:System.ServiceModel.Description.IMetadataExchange> endpoint to require authentication and encryption. The sample [Custom Secure Metadata Endpoint](../../../../docs/framework/wcf/samples/custom-secure-metadata-endpoint.md) demonstrates this scenario.  
  
## See Also  
 [Securing Services](../../../../docs/framework/wcf/securing-services.md)  
 [WS-MetadataExchange Bindings](../../../../docs/framework/wcf/extending/ws-metadataexchange-bindings.md)  
 [How to: Configure a Custom WS-Metadata Exchange Binding](../../../../docs/framework/wcf/extending/how-to-configure-a-custom-ws-metadata-exchange-binding.md)  
 [How to: Retrieve Metadata Over a non-MEX Binding](../../../../docs/framework/wcf/extending/how-to-retrieve-metadata-over-a-non-mex-binding.md)
