---
title: "Custom Data Service Providers (WCF Data Services)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF Data Services, providers"
ms.assetid: e702ecdb-3419-4743-92a9-c3c0e7d44082
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Data Service Providers (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] includes a set of providers that enables you to define a data model based on late-bound data types.  
  
|Provider|Description|  
|--------------|-----------------|  
|Metadata provider|This is the core custom data service provider that enables you to define a custom data model at runtime by implementing the <xref:System.Data.Services.Providers.IDataServiceMetadataProvider> interface.|  
|Query provider|This provider enables you to execute queries against a custom data model that is defined by using the <xref:System.Data.Services.Providers.IDataServiceMetadataProvider> interface. The query provider is created by implementing the <xref:System.Data.Services.Providers.IDataServiceQueryProvider> interface.|  
|Update provider|This provider enables you to make updates to types that are exposed in a custom data service provider and to manage concurrency. An update provider is created by implementing the <xref:System.Data.Services.Providers.IDataServiceUpdateProvider> interface|  
|Paging provider|This provider is used with the custom data service provider to enable server-driven paging support. A paging provider for a custom data service is created by implementing the <xref:System.Data.Services.Providers.IDataServicePagingProvider> interface.|  
|Streaming provider|This provider enables you to expose binary large object data types as a stream. A streaming provider is created by implementing the <xref:System.Data.Services.Providers.IDataServiceStreamProvider> interface. The streaming provider can also be used with Entity Framework and reflection data source providers. For more information, see [Streaming Provider](../../../../docs/framework/data/wcf/streaming-provider-wcf-data-services.md).|  
  
 For more information, see the article [Custom Data Service Providers](http://go.microsoft.com/fwlink/?LinkID=186850) and the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] Provider Toolkit in the [OData SDK](http://go.microsoft.com/fwlink/?LinkId=186069).  
  
## See Also  
 [Data Services Providers](../../../../docs/framework/data/wcf/data-services-providers-wcf-data-services.md)  
 [Entity Framework Provider](../../../../docs/framework/data/wcf/entity-framework-provider-wcf-data-services.md)  
 [Reflection Provider](../../../../docs/framework/data/wcf/reflection-provider-wcf-data-services.md)
