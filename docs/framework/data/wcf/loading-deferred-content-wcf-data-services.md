---
title: "Loading Deferred Content (WCF Data Services)"
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
  - "WCF Data Services, client library"
  - "WCF Data Services, deferred content"
  - "WCF Data Services, loading data"
ms.assetid: 32f9b588-c832-44c4-a7e0-fcce635df59a
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Loading Deferred Content (WCF Data Services)
By default, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] limits the amount of data that a query returns. However, you can explicitly load additional data, including related entities, paged response data, and binary data streams, from the data service when it is needed. This topic describes how to load such deferred content into your application.  
  
## Related Entities  
 When you execute a query, only entities in the addressed entity set are returned. For example, when a query against the Northwind data service returns `Customers` entities, by default the related `Orders` entities are not returned, even though there is a relationship between `Customers` and `Orders`. Also, when paging is enabled in the data service, you must explicitly load subsequent data pages from the service. There are two ways to load related entities:  
  
-   **Eager loading**: You can use the `$expand` query option to request that the query return entities that are related by an association to the entity set that the query requested. Use the <xref:System.Data.Services.Client.DataServiceQuery%601.Expand%2A> method on the <xref:System.Data.Services.Client.DataServiceQuery%601> to add the `$expand` option to the query that is sent to the data service. You can request multiple related entity sets by separating them by a comma, as in the following example. All entities requested by the query are returned in a single response. The following example returns `Order_Details` and `Customers` together with the `Orders` entity set:  
  
     [!code-csharp[Astoria Northwind Client#ExpandOrderDetailsSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#expandorderdetailsspecific)]
     [!code-vb[Astoria Northwind Client#ExpandOrderDetailsSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#expandorderdetailsspecific)]  
  
     [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] limits to 12 the number of entity sets that can be included in a single query by using the `$expand` query option.  
  
-   **Explicit loading**: You can call the <xref:System.Data.Services.Client.DataServiceContext.LoadProperty%2A> method on the <xref:System.Data.Services.Client.DataServiceContext> instance to explicitly load related entities. Each call to the <xref:System.Data.Services.Client.DataServiceContext.LoadProperty%2A> method creates a separate request to the data service. The following example explicitly loads `Order_Details` for an `Orders` entity:  
  
     [!code-csharp[Astoria Northwind Client#LoadRelatedOrderDetailsSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#loadrelatedorderdetailsspecific)]
     [!code-vb[Astoria Northwind Client#LoadRelatedOrderDetailsSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#loadrelatedorderdetailsspecific)]  
  
 When you consider which option to use, realize that there is a tradeoff between the number of requests to the data service and the amount of data that is returned in a single response. Use eager loading when your application requires associated objects and you want to avoid the added latency of additional requests to explicitly retrieve them. However, if there are cases when the application only needs the data for specific related entity instances, you should consider explicitly loading those entities by calling the <xref:System.Data.Services.Client.DataServiceContext.LoadProperty%2A> method. For more information, see [How to: Load Related Entities](../../../../docs/framework/data/wcf/how-to-load-related-entities-wcf-data-services.md).  
  
## Paged Content  
 When paging is enabled in the data service, the number of entries in the feed that the data service returns is limited by the configuration of the data service. Page limits can be set separately for each entity set. For more information, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md). When paging is enabled, the final entry in the feed contains a link to the next page of data. This link is contained in a <xref:System.Data.Services.Client.DataServiceQueryContinuation%601> object. You obtain the URI to the next page of data by calling the <xref:System.Data.Services.Client.QueryOperationResponse%601.GetContinuation%2A> method on the <xref:System.Data.Services.Client.QueryOperationResponse%601> returned when the <xref:System.Data.Services.Client.DataServiceQuery%601> is executed. The returned <xref:System.Data.Services.Client.DataServiceQueryContinuation%601> object is then used to load the next page of results. You must enumerate the query result before you call the <xref:System.Data.Services.Client.QueryOperationResponse%601.GetContinuation%2A> method. Consider using a `do…while` loop to first enumerate the query result and then check for a `non-null` next link value. When the <xref:System.Data.Services.Client.QueryOperationResponse%601.GetContinuation%2A> method returns `null` (`Nothing` in Visual Basic), there are no additional result pages for the original query. The following example shows a `do…while` loop that loads paged customer data from the Northwind sample data service.  
  
 [!code-csharp[Astoria Northwind Client#LoadNextLink](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#loadnextlink)]
 [!code-vb[Astoria Northwind Client#LoadNextLink](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#loadnextlink)]  
  
 When a query requests that related entities are returned in a single response together with the requested entity set, paging limits may affect nested feeds that are included inline with the response. For example, when a paging limit is set in the Northwind sample data service for the `Customers` entity set, an independent paging limit can also be set for the related `Orders` entity set, as in the following example from the Northwind.svc.cs file that defines the Northwind sample data service.  
  
 [!code-csharp[Astoria Northwind Service#DataServiceConfigPaging](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind.svc.cs#dataserviceconfigpaging)]
 [!code-vb[Astoria Northwind Service#DataServiceConfigPaging](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind.svc.vb#dataserviceconfigpaging)]  
  
 In this case, you must implement paging for both the top-level `Customers` and the nested `Orders` entity feeds. The following example shows the `while` loop used to load pages of `Orders` entities related to a selected `Customers` entity.  
  
 [!code-csharp[Astoria Northwind Client#LoadNextOrdersLink](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#loadnextorderslink)]
 [!code-vb[Astoria Northwind Client#LoadNextOrdersLink](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#loadnextorderslink)]  
  
 For more information, see [How to: Load Paged Results](../../../../docs/framework/data/wcf/how-to-load-paged-results-wcf-data-services.md).  
  
## Binary Data Streams  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] enables you to access binary large object (BLOB) data as a data stream. Streaming defers the loading of binary data until it is needed, and the client can more efficiently process this data. In order to take advantage of this functionality, the data service must implement the <xref:System.Data.Services.Providers.IDataServiceStreamProvider> provider. For more information, see [Streaming Provider](../../../../docs/framework/data/wcf/streaming-provider-wcf-data-services.md). When streaming is enabled, entity types are returned without the related binary data. In this case, you must use the <xref:System.Data.Services.Client.DataServiceContext.GetReadStream%2A> method of the <xref:System.Data.Services.Client.DataServiceContext> class to access the data stream for the binary data from the service. Similarly, use the <xref:System.Data.Services.Client.DataServiceContext.SetSaveStream%2A> method to add or change binary data for an entity as a stream. For more information, see [Working with Binary Data](../../../../docs/framework/data/wcf/working-with-binary-data-wcf-data-services.md).  
  
## See Also  
 [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md)  
 [Querying the Data Service](../../../../docs/framework/data/wcf/querying-the-data-service-wcf-data-services.md)
