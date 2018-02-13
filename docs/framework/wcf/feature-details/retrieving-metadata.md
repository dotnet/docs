---
title: "Retrieving Metadata"
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
  - "metadata [WCF], retrieving"
ms.assetid: 18d8ba4c-af0f-4827-a50b-4202d767bacc
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Retrieving Metadata
Metadata retrieval is the process of requesting and retrieving metadata from a metadata endpoint, such as a WS-MetadataExchange (MEX) metadata endpoint or an HTTP/GET metadata endpoint.  
  
## Retrieving Metadata from the Command Line Using Svcutil.exe  
 You can retrieve service metadata using WS-MetadataExchange or HTTP/GET requests by using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool and passing the `/target:metadata` switch and an address. Svcutil.exe downloads the metadata at the specified address and saves the file to disk. Svcutil.exe uses a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> instance internally and loads from configuration the <xref:System.ServiceModel.Description.IMetadataExchange> endpoint configuration whose name matches the scheme of the address passed to Svcutil.exe as input.  
  
## Retrieving Metadata Programmatically Using the MetadataExchangeClient  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] can retrieve service metadata using standardized protocols such as WS-MetadataExchange and HTTP/GET requests. Both of these protocols are supported by the <xref:System.ServiceModel.Description.MetadataExchangeClient> type. You retrieve service metadata using the <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> type by providing an address for the metadata endpoint and an optional binding. The binding used by a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> instance can be one of the default bindings from the <xref:System.ServiceModel.Description.MetadataExchangeBindings> static class, a user-supplied binding, or a binding loaded from an endpoint configuration for the `IMetadataExchange` contract. The <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> can also resolve HTTP URL references to metadata using the <xref:System.Net.HttpWebRequest> type.  
  
 By default, a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> instance is tied to a single <xref:System.ServiceModel.ChannelFactory> instance. You can change or replace the <xref:System.ServiceModel.ChannelFactory?displayProperty=nameWithType> instance used by a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> by overriding the <xref:System.ServiceModel.Description.MetadataExchangeClient.GetChannelFactory%2A> virtual method. Similarly, you can change or replace the <xref:System.Net.HttpWebRequest> instance used by a <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> to make HTTP/GET requests by overriding the <xref:System.ServiceModel.Description.MetadataExchangeClient.GetWebRequest%2A?displayProperty=nameWithType> virtual method.  
  
## In This Section  
 [How to: Use Svcutil.exe to Download Metadata Documents](../../../../docs/framework/wcf/feature-details/how-to-use-svcutil-exe-to-download-metadata-documents.md)  
 Demonstrates how to use Svcutil.exe to download metadata documents.  
  
 [How to: Use MetadataResolver to Obtain Binding Metadata Dynamically](../../../../docs/framework/wcf/feature-details/how-to-use-metadataresolver-to-obtain-binding-metadata-dynamically.md)  
 Demonstrates how to use the <xref:System.ServiceModel.Description.MetadataResolver?displayProperty=nameWithType> to obtain binding metadata dynamically at runtime.  
  
 [How to: Use MetadataExchangeClient to Retrieve Metadata](../../../../docs/framework/wcf/feature-details/how-to-use-metadataexchangeclient-to-retrieve-metadata.md)  
 Demonstrates how to use the <xref:System.ServiceModel.Description.MetadataExchangeClient?displayProperty=nameWithType> class to download metadata files into a <xref:System.ServiceModel.Description.MetadataSet?displayProperty=nameWithType> object that contains <xref:System.ServiceModel.Description.MetadataSection?displayProperty=nameWithType> objects to write to files or for other uses.  
  
## See Also  
 <xref:System.ServiceModel.Description.MetadataExchangeClient>
