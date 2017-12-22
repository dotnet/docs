---
title: "How to: Use MetadataExchangeClient to Retrieve Metadata"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0754e9dc-13c5-45c2-81b5-f3da466e5a87
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Use MetadataExchangeClient to Retrieve Metadata
Use the <xref:System.ServiceModel.Description.MetadataExchangeClient> class to download metadata using the WS-MetadataExchange (MEX) protocol. The retrieved metadata files are returned as a <xref:System.ServiceModel.Description.MetadataSet> object. The returned <xref:System.ServiceModel.Description.MetadataSet> object contains a collection of <xref:System.ServiceModel.Description.MetadataSection> objects, each of which contains a specific metadata dialect and an identifier. You can write the returned metadata to files or, if the returned metadata contains Web Services Description Language (WSDL) documents, you can import the metadata using the <xref:System.ServiceModel.Description.WsdlImporter>.  
  
 The <xref:System.ServiceModel.Description.MetadataExchangeClient> constructors that take an address use the binding on the <xref:System.ServiceModel.Description.MetadataExchangeBindings> static class that matches the Uniform Resource Identifier (URI) scheme of the address. You can alternatively use the <xref:System.ServiceModel.Description.MetadataExchangeClient> constructor that allows you to explicitly specify the binding to use. The specified binding is used to resolve all metadata references.  
  
 Just like any other [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] client, the <xref:System.ServiceModel.Description.MetadataExchangeClient> type provides a constructor for loading client endpoint configurations using the endpoint configuration name. The specified endpoint configuration must specify the <xref:System.ServiceModel.Description.IMetadataExchange> contract. The address in the endpoint configuration is not loaded, so you must use one of the <xref:System.ServiceModel.Description.MetadataExchangeClient.GetMetadata%2A> overloads that take an address. When you specify the metadata address using an <xref:System.ServiceModel.EndpointAddress> instance, the <xref:System.ServiceModel.Description.MetadataExchangeClient> assumes that the address points to a MEX endpoint. If you specify the metadata address as a URL, then you need to also specify which <xref:System.ServiceModel.Description.MetadataExchangeClientMode> to use, MEX or HTTP GET.  
  
> [!IMPORTANT]
>  By default, the <xref:System.ServiceModel.Description.MetadataExchangeClient> resolves all references for you, including WSDL and XML Schema imports and includes. You can disable this functionality by setting the <xref:System.ServiceModel.Description.MetadataExchangeClient.ResolveMetadataReferences%2A> property to `false`. You can control the maximum number of references to resolve using the <xref:System.ServiceModel.Description.MetadataExchangeClient.MaximumResolvedReferences%2A> property. You can use this property in conjunction with the `MaxReceivedMessageSize` property on the binding to control how much metadata is retrieved.  
  
### To use MetadataExchangeClient to obtain metadata  
  
1.  Create a new <xref:System.ServiceModel.Description.MetadataExchangeClient> object by explicitly specifying a binding, an endpoint configuration name, or the address of the metadata.  
  
2.  Configure the <xref:System.ServiceModel.Description.MetadataExchangeClient> to suit your needs. For example, you can specify credentials to use when requesting metadata, control how metadata references are resolved, and set the <xref:System.ServiceModel.Description.MetadataExchangeClient.OperationTimeout%2A> property to control how long the metadata request has to return before it times out.  
  
3.  Obtain the <xref:System.ServiceModel.Description.MetadataSet> object that contains the retrieved metadata by calling one of the <xref:System.ServiceModel.Description.MetadataExchangeClient.GetMetadata%2A> methods. Note that you can only use the <xref:System.ServiceModel.Description.MetadataExchangeClient.GetMetadata%2A> overload that takes no arguments if you explicitly specified an address when constructing the <xref:System.ServiceModel.Description.MetadataExchangeClient>.  
  
## Example  
 The following code example shows how to use <xref:System.ServiceModel.Description.MetadataExchangeClient> to download and enumerate metadata files.  

 [!code-csharp[MetadataResolver#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/metadataresolver/cs/client.cs#3)]  

## Compiling the Code  
 To compile this code example, you must reference the System.ServiceModel.dll assembly and import the <xref:System.ServiceModel.Description> namespace.  
  
## See Also  
 <xref:System.ServiceModel.Description.MetadataResolver>  
 <xref:System.ServiceModel.Description.MetadataExchangeClient>  
 <xref:System.ServiceModel.Description.WsdlImporter>
