---
title: "Querying the Data Service (WCF Data Services)"
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
  - "WCF Data Services, querying"
  - "WCF Data Services, accessing data"
ms.assetid: 823e9444-27aa-4f1f-be8e-0486d67f54c0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Querying the Data Service (WCF Data Services)
The [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library enables you to execute queries against a data service by using familiar [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] programming patterns, including using language integrated query (LINQ). The client library translates a query, which is defined on the client as an instance of the <xref:System.Data.Services.Client.DataServiceQuery%601> class, into an HTTP GET request message. The library receives the response message and translates it into instances of client data service classes. These classes are tracked by the <xref:System.Data.Services.Client.DataServiceContext> to which the <xref:System.Data.Services.Client.DataServiceQuery%601> belongs.  
  
## Data Service Queries  
 The <xref:System.Data.Services.Client.DataServiceQuery%601> generic class represents a query that returns a collection of zero or more entity type instances. A data service query always belongs to an existing data service context. This context maintains the service URI and metadata information that is required to compose and execute the query.  
  
 When you use the **Add Service Reference** dialog to add a data service to a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]-based client application, an entity container class is created that inherits from the <xref:System.Data.Services.Client.DataServiceContext> class. This class includes properties that return typed <xref:System.Data.Services.Client.DataServiceQuery%601> instances. There is one property for each entity set that the data service exposes. These properties make it easier to create an instance of a typed <xref:System.Data.Services.Client.DataServiceQuery%601>.  
  
 A query is executed in the following scenarios:  
  
-   When results are enumerated implicitly, such as:  
  
    -   When a property on the <xref:System.Data.Services.Client.DataServiceContext> that represents and entity set is enumerated, such as during a `foreach` (C#) or `For Each` ([!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)]) loop.  
  
    -   When the query is assigned to a `List` collection.  
  
-   When the <xref:System.Data.Services.Client.DataServiceQuery%601.Execute%2A> or <xref:System.Data.Services.Client.DataServiceQuery%601.BeginExecute%2A> method is explicitly called.  
  
-   When a LINQ query execution operator, such as <xref:System.Linq.Enumerable.First%2A> or <xref:System.Linq.Enumerable.Single%2A> is called.  
  
 The following query, when it is executed, returns all `Customers` entities in the Northwind data service:  
  
 [!code-csharp[Astoria Northwind Client#GetAllCustomersSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#getallcustomersspecific)]  
 [!code-vb[Astoria Northwind Client#GetAllCustomersSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#getallcustomersspecific)]  
  
 For more information, see [How to: Execute Data Service Queries](../../../../docs/framework/data/wcf/how-to-execute-data-service-queries-wcf-data-services.md).  
  
 The [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client supports queries for late-bound objects, such as when you use the *dynamic* type in C#. However, for performance reasons you should always compose strongly-typed queries against the data service. The <xref:System.Tuple> type and dynamic objects are not supported by the client.  
  
## LINQ Queries  
 Because the <xref:System.Data.Services.Client.DataServiceQuery%601> class implements the <xref:System.Linq.IQueryable%601> interface defined by LINQ, the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library is able to transform LINQ queries against entity set data into a URI that represents a query expression evaluated against a data service resource. The following example is a LINQ query that is equivalent to the previous <xref:System.Data.Services.Client.DataServiceQuery%601> that returns `Orders` that have a freight cost of more than $30 and orders the results by the freight cost:  
  
 [!code-csharp[Astoria Northwind Client#AddQueryOptionsLinqSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#addqueryoptionslinqspecific)]  
 [!code-vb[Astoria Northwind Client#AddQueryOptionsLinqSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#addqueryoptionslinqspecific)]  
  
 This LINQ query is translated into the following query URI that is executed against the Northwind-based [quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md) data service:  
  
```  
http://localhost:12345/Northwind.svc/Orders?Orderby=ShippedDate&?filter=Freight gt 30  
```  
  
> [!NOTE]
>  The set of queries expressible in the LINQ syntax is broader than those enabled in the representational state transfer (REST)-based URI syntax that is used by data services. A <xref:System.NotSupportedException> is raised when the query cannot be mapped to a URI in the target data service.  
  
 For more information, see [LINQ Considerations](../../../../docs/framework/data/wcf/linq-considerations-wcf-data-services.md).  
  
## Adding Query Options  
 Data service queries support all the query options that [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)]s provides. You call the <xref:System.Data.Services.Client.DataServiceQuery%601.AddQueryOption%2A> method to append query options to a <xref:System.Data.Services.Client.DataServiceQuery%601> instance. <xref:System.Data.Services.Client.DataServiceQuery%601.AddQueryOption%2A> returns a new <xref:System.Data.Services.Client.DataServiceQuery%601> instance that is equivalent to the original query but with the new query option set. The following query, when executed, returns `Orders` that are filtered by the `Freight` value and ordered by the `OrderID`, descending:  
  
 [!code-csharp[Astoria Northwind Client#AddQueryOptionsSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#addqueryoptionsspecific)]  
 [!code-vb[Astoria Northwind Client#AddQueryOptionsSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#addqueryoptionsspecific)]  
  
 You can use the `$orderby` query option to both order and filter a query based on a single property, as in the following example that filters and orders the returned `Orders` objects based on the value of the `Freight` property:  
  
 [!code-csharp[Astoria Northwind Client#OrderWithFilter](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#orderwithfilter)]
 [!code-vb[Astoria Northwind Client#OrderWithFilter](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#orderwithfilter)]  
  
 You can call the <xref:System.Data.Services.Client.DataServiceQuery%601.AddQueryOption%2A> method consecutively to construct complex query expressions. For more information, see [How to: Add Query Options to a Data Service Query](../../../../docs/framework/data/wcf/how-to-add-query-options-to-a-data-service-query-wcf-data-services.md).  
  
 Query options give you another way to express the syntactic components of a LINQ query. For more information, see [LINQ Considerations](../../../../docs/framework/data/wcf/linq-considerations-wcf-data-services.md).  
  
> [!NOTE]
>  The `$select` query option cannot be added to a query URI by using the <xref:System.Data.Services.Client.DataServiceQuery%601.AddQueryOption%2A> method. We recommend that you use the LINQ <xref:System.Linq.Enumerable.Select%2A> method to have the client generate the `$select` query option in the request URI.  
  
<a name="executingQueries"></a>   
## Client versus Server Execution  
 The client executes a query in two parts. Whenever possible, expressions in a query are first evaluated on the client, and then a URI-based query is generated and sent to the data service for evaluation against data in the service. Consider the following LINQ query:  
  
 [!code-csharp[Astoria Northwind Client#LinqQueryClientEvalSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#linqqueryclientevalspecific)]  
 [!code-vb[Astoria Northwind Client#LinqQueryClientEvalSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#linqqueryclientevalspecific)]  
  
 In this example, the expression `(basePrice – (basePrice * discount))` is evaluated on the client. Because of this, the actual query URI `http://localhost:12345/northwind.svc/Products()?$filter=(UnitPrice gt 90.00M) and substringof('bike',ProductName)` that is sent to the data service contains the already calculated decimal value of `90` in the filter clause. The other parts of the filtering expression, including the substring expression, are evaluated by the data service. Expressions that are evaluated on the client follow common language runtime (CLR) semantics, while expressions sent to the data service rely on the data service implementation of the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] Protocol. You should also be aware of scenarios where this separate evaluation may cause unexpected results, such as when both the client and service perform time-based evaluations in different time zones.  
  
## Query Responses  
 When executed, the <xref:System.Data.Services.Client.DataServiceQuery%601> returns an <xref:System.Collections.Generic.IEnumerable%601> of the requested entity type. This query result can be cast to a <xref:System.Data.Services.Client.QueryOperationResponse%601> object, as in the following example:  
  
 [!code-csharp[Astoria Northwind Client#GetResponseSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#getresponsespecific)]
 [!code-vb[Astoria Northwind Client#GetResponseSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#getresponsespecific)]  
  
 The entity type instances that represent entities in the data service are created on the client by a process called object materialization. For more information, see [Object Materialization](../../../../docs/framework/data/wcf/object-materialization-wcf-data-services.md). The <xref:System.Data.Services.Client.QueryOperationResponse%601> object implements <xref:System.Collections.Generic.IEnumerable%601> to provide access to the results of the query.  
  
 The <xref:System.Data.Services.Client.QueryOperationResponse%601> also has the following members that enable you to access additional information about a query result:  
  
-   <xref:System.Data.Services.Client.OperationResponse.Error%2A> - gets an error thrown by the operation, if any has occurred.  
  
-   <xref:System.Data.Services.Client.OperationResponse.Headers%2A> - contains the collection of HTTP response headers associated with the query response.  
  
-   <xref:System.Data.Services.Client.QueryOperationResponse.Query%2A> - gets the original <xref:System.Data.Services.Client.DataServiceQuery%601> that generated the <xref:System.Data.Services.Client.QueryOperationResponse%601>.  
  
-   <xref:System.Data.Services.Client.OperationResponse.StatusCode%2A> - gets the HTTP response code for the query response.  
  
-   <xref:System.Data.Services.Client.QueryOperationResponse%601.TotalCount%2A> - gets the total number of entities in the entity set when the <xref:System.Data.Services.Client.DataServiceQuery%601.IncludeTotalCount%2A> method was called on the <xref:System.Data.Services.Client.DataServiceQuery%601>.  
  
-   <xref:System.Data.Services.Client.QueryOperationResponse.GetContinuation%2A> - returns a <xref:System.Data.Services.Client.DataServiceQueryContinuation> object that contains the URI of the next page of results.  
  
 By default, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] only returns data that is explicitly selected by the query URI. This gives you the option to explicitly load additional data from the data service when it is needed. A request is sent to the data service each time you explicitly load data from the data service. Data that can be explicitly loaded includes related entities, paged response data, and binary data streams.  
  
> [!NOTE]
>  Because a data service may return a paged response, we recommend that your application use the programming pattern to handle a paged data service response. For more information, see [Loading Deferred Content](../../../../docs/framework/data/wcf/loading-deferred-content-wcf-data-services.md).  
  
 The amount of data returned by a query can also be reduced by specifying that only certain properties of an entity are returned in the response. For more information, see [Query Projections](../../../../docs/framework/data/wcf/query-projections-wcf-data-services.md).  
  
## Getting a Count of the Total Number of Entities in the Set  
 In some scenarios, it is helpful to know the total number of entities in an entity set and not merely the number returned by the query. Call the <xref:System.Data.Services.Client.DataServiceQuery%601.IncludeTotalCount%2A> method on the <xref:System.Data.Services.Client.DataServiceQuery%601> to request that this total count of entities in the set be included with the query result. In this case, the <xref:System.Data.Services.Client.QueryOperationResponse%601.TotalCount%2A> property of the returned <xref:System.Data.Services.Client.QueryOperationResponse%601> returns the total number of entities in the set.  
  
 You can also get only the total count of entities in the set either as an <xref:System.Int32> or as a <xref:System.Int64> value by calling the <xref:System.Linq.Enumerable.Count%2A> or <xref:System.Linq.Enumerable.LongCount%2A> methods respectively. When these methods are called, a <xref:System.Data.Services.Client.QueryOperationResponse%601> is not returned; only the count value is returned. For more information, see [How to: Determine the Number of Entities Returned by a Query](../../../../docs/framework/data/wcf/number-of-entities-returned-by-a-query-wcf.md).  
  
## In This Section  
 [Query Projections](../../../../docs/framework/data/wcf/query-projections-wcf-data-services.md)  
  
 [Object Materialization](../../../../docs/framework/data/wcf/object-materialization-wcf-data-services.md)  
  
 [LINQ Considerations](../../../../docs/framework/data/wcf/linq-considerations-wcf-data-services.md)  
  
 [How to: Execute Data Service Queries](../../../../docs/framework/data/wcf/how-to-execute-data-service-queries-wcf-data-services.md)  
  
 [How to: Add Query Options to a Data Service Query](../../../../docs/framework/data/wcf/how-to-add-query-options-to-a-data-service-query-wcf-data-services.md)  
  
 [How to: Determine the Number of Entities Returned by a Query](../../../../docs/framework/data/wcf/number-of-entities-returned-by-a-query-wcf.md)  
  
 [How to: Specify Client Credentials for a Data Service Request](../../../../docs/framework/data/wcf/specify-client-creds-for-a-data-service-request-wcf.md)  
  
 [How to: Set Headers in the Client Request](../../../../docs/framework/data/wcf/how-to-set-headers-in-the-client-request-wcf-data-services.md)  
  
 [How to: Project Query Results](../../../../docs/framework/data/wcf/how-to-project-query-results-wcf-data-services.md)  
  
## See Also  
 [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md)
