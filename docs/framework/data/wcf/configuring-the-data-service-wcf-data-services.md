---
title: "Configuring the Data Service (WCF Data Services)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF Data Services, configuring"
ms.assetid: 59efd4c8-cc7a-4800-a0a4-d3f8abe6c55c
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuring the Data Service (WCF Data Services)
With [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], you can create data services that expose [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] feeds. Data in these feeds can come from a variety of data sources. [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] uses data providers to expose this data as an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed. These providers include an [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] provider, a reflection provider, and a set of custom data service provider interfaces. The provider implementation defines the data model for the service. For more information, see [Data Services Providers](../../../../docs/framework/data/wcf/data-services-providers-wcf-data-services.md).  
  
 In [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], a data service is a class that inherits from the <xref:System.Data.Services.DataService%601> class, where the type of the data service is the entity container of the data model. This entity container has one or more properties that return an <xref:System.Linq.IQueryable%601>, which are used to access entity sets in the data model.  
  
 The behaviors of the data service are defined by the members of the <xref:System.Data.Services.DataServiceConfiguration> class, and by members of the <xref:System.Data.Services.DataServiceBehavior> class, which is accessed from the <xref:System.Data.Services.DataServiceConfiguration.DataServiceBehavior%2A> property of the <xref:System.Data.Services.DataServiceConfiguration> class. The <xref:System.Data.Services.DataServiceConfiguration> class is supplied to the `InitializeService` method that is implemented by the data service, as in the following implementation of a Northwind data service:  
  
[!code-csharp[Astoria Northwind Service#DataServiceConfigComplete](../../../../samples/snippets/csharp/VS_Snippets_Misc/Astoria Northwind Service/cs/northwind.svc.cs#dataserviceconfigcomplete)]  
[!code-vb[Astoria Northwind Service#DataServiceConfigComplete](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/Astoria Northwind Service/vb/northwind.svc.vb#dataserviceconfigcomplete)]  
  
## Data Service Configuration Settings  
 The <xref:System.Data.Services.DataServiceConfiguration> class enables you to specify the following data service behaviors:  
  
|Member|Behavior|  
|------------|--------------|  
|<xref:System.Data.Services.DataServiceBehavior.AcceptCountRequests%2A>|Enables you to disable count requests that are submitted to the data service by using the `$count` path segment and the `$inlinecount` query option. For more information, see [OData: URI Conventions](http://go.microsoft.com/fwlink/?LinkId=185564).|  
|<xref:System.Data.Services.DataServiceBehavior.AcceptProjectionRequests%2A>|Enables you to disable support for data projection in requests that are submitted to the data service by using the `$select` query option. For more information, see [OData: URI Conventions](http://go.microsoft.com/fwlink/?LinkId=185564).|  
|<xref:System.Data.Services.DataServiceConfiguration.EnableTypeAccess%2A>|Enables a data type to be exposed in the metadata for a dynamic metadata provider defined by using the <xref:System.Data.Services.Providers.IDataServiceMetadataProvider> interface.|  
|<xref:System.Data.Services.DataServiceConfiguration.EnableTypeConversion%2A>|Enables you to specify whether the data service runtime should convert the type that is contained in the payload to the actual property type that is specified in the request.|  
|<xref:System.Data.Services.DataServiceBehavior.InvokeInterceptorsOnLinkDelete%2A>|Enables you to specify whether or not registered change interceptors are invoked on the related entities when a relationship link between two entities is deleted.|  
|<xref:System.Data.Services.DataServiceConfiguration.MaxBatchCount%2A>|Enables you to limit the number of change sets and query operations that are allowed in a single batch. For more information, see [OData: Batch](http://go.microsoft.com/fwlink/?LinkId=185602) and [Batching Operations](../../../../docs/framework/data/wcf/batching-operations-wcf-data-services.md).|  
|<xref:System.Data.Services.DataServiceConfiguration.MaxChangesetCount%2A>|Enables you to limit the number of changes that can be included in a single change set. For more information, see [How to: Enable Paging of Data Service Results](../../../../docs/framework/data/wcf/how-to-enable-paging-of-data-service-results-wcf-data-services.md).|  
|<xref:System.Data.Services.DataServiceConfiguration.MaxExpandCount%2A>|Enables you to limit the size of a response by limiting the number of related entities that can be included in a single request by using the `$expand` query operator. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] see [OData: URI Conventions](http://go.microsoft.com/fwlink/?LinkId=185564) and [Loading Deferred Content](../../../../docs/framework/data/wcf/loading-deferred-content-wcf-data-services.md).|  
|<xref:System.Data.Services.DataServiceConfiguration.MaxExpandDepth%2A>|Enables you to limit the size of a response by limiting the depth of the graph of related entities that can be included in a single request by using the `$expand` query operator. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] see [OData: URI Conventions](http://go.microsoft.com/fwlink/?LinkId=185564) and [Loading Deferred Content](../../../../docs/framework/data/wcf/loading-deferred-content-wcf-data-services.md).|  
|<xref:System.Data.Services.DataServiceConfiguration.MaxObjectCountOnInsert%2A>|Enables you to limit the number of entities to be inserted that can be contained in a single POST request.|  
|<xref:System.Data.Services.DataServiceBehavior.MaxProtocolVersion%2A>|Defines the version of the Atom protocol that is used by the data service. When the value of the <xref:System.Data.Services.DataServiceBehavior.MaxProtocolVersion%2A> is set to a value less than the maximum value of <xref:System.Data.Services.Common.DataServiceProtocolVersion>, the latest functionality of [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] is not available to clients accessing the data service. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Service Versioning](../../../../docs/framework/data/wcf/data-service-versioning-wcf-data-services.md).|  
|<xref:System.Data.Services.DataServiceConfiguration.MaxResultsPerCollection%2A>|Enables you to limit the size of a response by limiting the number of entities in each entity set that is returned as a data feed.|  
|<xref:System.Data.Services.DataServiceConfiguration.RegisterKnownType%2A>|Adds a data type to the list of types that are recognized by the data service.|  
|<xref:System.Data.Services.DataServiceConfiguration.SetEntitySetAccessRule%2A>|Sets the access rights for entity set resources that are available on the data service. An asterisk (`*`) value can be supplied for the name parameter to set access for all remaining entity sets to the same level. We recommend that you set access to entity sets to provide the least privilege access to data service resources that are required by client applications. For more information, see [Securing WCF Data Services](../../../../docs/framework/data/wcf/securing-wcf-data-services.md). For examples of the minimum access rights required for a given URI and HTTP action, see the table in the [Minimum Resource Access Requirements](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md#accessRequirements) section.|  
|<xref:System.Data.Services.DataServiceConfiguration.SetEntitySetPageSize%2A>|Sets the maximum page size for an entity set resource. For more information, see [How to: Enable Paging of Data Service Results](../../../../docs/framework/data/wcf/how-to-enable-paging-of-data-service-results-wcf-data-services.md).|  
|<xref:System.Data.Services.DataServiceConfiguration.SetServiceOperationAccessRule%2A>|Sets the access rights for service operations that are defined on the data service. For more information, see [Service Operations](../../../../docs/framework/data/wcf/service-operations-wcf-data-services.md). An asterisk (`*`) value can be supplied for the name parameter to set access for all service operations to the same level. We recommend that you set access to service operations to provide the least privilege access to data service resources that are required by client applications. For more information, see [Securing WCF Data Services](../../../../docs/framework/data/wcf/securing-wcf-data-services.md).|  
|<xref:System.Data.Services.DataServiceConfiguration.UseVerboseErrors%2A>|This configuration property enables you to more easily troubleshoot a data service by returning more information in the error response message. This option is not intended to be used in a production environment. For more information, see [Developing and Deploying WCF Data Services](../../../../docs/framework/data/wcf/developing-and-deploying-wcf-data-services.md).|  
  
<a name="accessRequirements"></a>   
## Minimum Resource Access Requirements  
 The following table details the minimum entity set rights that must be granted to execute a specific operation. Path examples are based on the Northwind data service that is created when you complete the [quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md). Because both the <xref:System.Data.Services.EntitySetRights> enumeration and the <xref:System.Data.Services.ServiceOperationRights> enumeration are defined by using the <xref:System.FlagsAttribute>, you can use a logical OR operator to specify multiple permissions for a single entity set or operation. For more information, see [How to: Enable Access to the Data Service](../../../../docs/framework/data/wcf/how-to-enable-access-to-the-data-service-wcf-data-services.md).  
  
|Path/Action|`GET`|`DELETE`|`MERGE`|`POST`|`PUT`|  
|------------------|-----------|--------------|-------------|------------|-----------|  
|`/Customers`|<xref:System.Data.Services.EntitySetRights.ReadMultiple>|Not supported|Not supported|<xref:System.Data.Services.EntitySetRights.WriteAppend>|Not supported|  
|`/Customers('ALFKI')`|<xref:System.Data.Services.EntitySetRights.ReadSingle>|<xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteDelete>|<xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteMerge>|n/a|<xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteReplace>|  
|`/Customers('ALFKI')/Orders`|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadMultiple>|Not supported|Not supported|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteMerge> or <xref:System.Data.Services.EntitySetRights.WriteReplace><br /><br /> -and-<br /><br /> `Orders` `:` and <xref:System.Data.Services.EntitySetRights.WriteAppend>|Not supported|  
|`/Customers('ALFKI')/Orders(10643)`|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle>|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteDelete>|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteMerge>|Not supported|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteReplace>|  
|`/Orders(10643)/Customer`|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle>|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteDelete><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle>|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteMerge>;<br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle>|`Customers`: <xref:System.Data.Services.EntitySetRights.WriteAppend><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.WriteAppend> and <xref:System.Data.Services.EntitySetRights.ReadSingle>|Not supported|  
|`/Customers('ALFKI')/$links/Orders`|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadMultiple>|Not supported|Not supported|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteMerge> or <xref:System.Data.Services.EntitySetRights.WriteReplace><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle>|Not supported|  
|`/Customers('ALFKI')/$links/Orders(10643)`|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle>|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteMerge> or <xref:System.Data.Services.EntitySetRights.WriteReplace><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle>|Not supported|Not supported|Not supported|  
|`/Orders(10643)/$links/Customer`|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle>|`Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteMerge> or <xref:System.Data.Services.EntitySetRights.WriteReplace>|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteMerge>|Not supported|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle>;<br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteReplace>|  
|`/Customers/$count`|<xref:System.Data.Services.EntitySetRights.ReadMultiple>|Not supported|Not supported|Not supported|Not supported|  
|`/Customers('ALFKI')/ContactName`|<xref:System.Data.Services.EntitySetRights.ReadSingle>|Not supported|<xref:System.Data.Services.EntitySetRights.WriteMerge>|Not supported|<xref:System.Data.Services.EntitySetRights.WriteReplace>|  
|`/Customers('ALFKI')/Address/StreetAddress/$value` <sup>1</sup>|<xref:System.Data.Services.EntitySetRights.ReadSingle>|<xref:System.Data.Services.EntitySetRights.WriteDelete>|Not supported|Not supported|Not supported|  
|`/Customers('ALFKI')/ContactName/$value`|<xref:System.Data.Services.EntitySetRights.ReadSingle>|<xref:System.Data.Services.EntitySetRights.ReadSingle> and <xref:System.Data.Services.EntitySetRights.WriteDelete>|<xref:System.Data.Services.EntitySetRights.WriteMerge>|Not supported|<xref:System.Data.Services.EntitySetRights.WriteReplace>|  
|`/Customers('ALFKI')/$value` <sup>2</sup>|<xref:System.Data.Services.EntitySetRights.ReadSingle>|Not supported|Not supported|Not supported|<xref:System.Data.Services.EntitySetRights.WriteReplace>|  
|`/Customers?$select=Orders/*&$expand=Orders`|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadMultiple>|Not supported|Not supported|`Customers`: <xref:System.Data.Services.EntitySetRights.WriteAppend>|Not supported|  
|`/Customers('ALFKI')?$select=Orders/*&$expand=Orders`|`Customers`: <xref:System.Data.Services.EntitySetRights.ReadSingle><br /><br /> -and-<br /><br /> `Orders`: <xref:System.Data.Services.EntitySetRights.ReadMultiple>|Not supported|Not supported|Not supported|Not supported|  
  
 <sup>1</sup> In this example, `Address` represents a complex type property of the `Customers` entity that has a property named `StreetAddress`. The model used by the Northwind data services does not explicitly define this complex type. When the data model is defined by using the [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] provider, you can use the [!INCLUDE[adonet_edm](../../../../includes/adonet-edm-md.md)] tools to define such a complex type. For more information, see [How to: Create and Modify Complex Types](http://msdn.microsoft.com/library/afb8e206-0ffe-4597-b6d4-6ab566897e1d).  
  
 <sup>2</sup> This URI is supported when a property that returns a binary large object (BLOB) is defined as the media resource that belongs to an entity that is a media link entry, which in this case, is `Customers`. For more information, see [Streaming Provider](../../../../docs/framework/data/wcf/streaming-provider-wcf-data-services.md).  
  
<a name="versioning"></a>   
## Versioning Requirements  
 The following data service configuration behaviors require version 2 of the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] protocol, or later versions:  
  
-   Support for count requests.  
  
-   Support for the $select query option for projection.  
  
 For more information, see [Data Service Versioning](../../../../docs/framework/data/wcf/data-service-versioning-wcf-data-services.md).  
  
## See Also  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)  
 [Hosting the Data Service](../../../../docs/framework/data/wcf/hosting-the-data-service-wcf-data-services.md)
