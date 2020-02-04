---
title: "Custom Data Service Providers (WCF Data Services)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WCF Data Services, providers"
ms.assetid: e702ecdb-3419-4743-92a9-c3c0e7d44082
---
# Custom Data Service Providers (WCF Data Services)
WCF Data Services includes a set of providers that enables you to define a data model based on late-bound data types.  
  
|Provider|Description|  
|--------------|-----------------|  
|Metadata provider|This is the core custom data service provider that enables you to define a custom data model at runtime by implementing the <xref:System.Data.Services.Providers.IDataServiceMetadataProvider> interface.|  
|Query provider|This provider enables you to execute queries against a custom data model that is defined by using the <xref:System.Data.Services.Providers.IDataServiceMetadataProvider> interface. The query provider is created by implementing the <xref:System.Data.Services.Providers.IDataServiceQueryProvider> interface.|  
|Update provider|This provider enables you to make updates to types that are exposed in a custom data service provider and to manage concurrency. An update provider is created by implementing the <xref:System.Data.Services.Providers.IDataServiceUpdateProvider> interface|  
|Paging provider|This provider is used with the custom data service provider to enable server-driven paging support. A paging provider for a custom data service is created by implementing the <xref:System.Data.Services.Providers.IDataServicePagingProvider> interface.|  
|Streaming provider|This provider enables you to expose binary large object data types as a stream. A streaming provider is created by implementing the <xref:System.Data.Services.Providers.IDataServiceStreamProvider> interface. The streaming provider can also be used with Entity Framework and reflection data source providers. For more information, see [Streaming Provider](streaming-provider-wcf-data-services.md).|  
  
## See also

- [Data Services Providers](data-services-providers-wcf-data-services.md)
- [Entity Framework Provider](entity-framework-provider-wcf-data-services.md)
- [Reflection Provider](reflection-provider-wcf-data-services.md)
