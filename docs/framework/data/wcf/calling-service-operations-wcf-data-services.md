---
title: "Calling Service Operations (WCF Data Services)"
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
ms.assetid: 1767f3a7-29d2-4834-a763-7d169693fa8b
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Calling Service Operations (WCF Data Services)
The [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] defines service operations for a data service. [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] enables you to define such operations as methods on the data service. Like other data service resources, these service operations are addressed by using URIs. A service operation can return collections of entity types, single entity type instances, and primitive types, such as integer and string. A service operation can also return `null` (`Nothing` in Visual Basic). The [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library can be used to access service operations that support HTTP GET requests. These kinds of service operations are defined as methods that have the <xref:System.ServiceModel.Web.WebGetAttribute> applied. For more information, see [Service Operations](../../../../docs/framework/data/wcf/service-operations-wcf-data-services.md).  
  
 Service operations are exposed in the metadata returned by a data service that implements the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)]. In the metadata, service operations are represented as `FunctionImport` elements. When generating the strongly-typed <xref:System.Data.Services.Client.DataServiceContext>, the Add Service Reference and DataSvcUtil.exe tools ignore this element. Because of this, you will not find a method on the context that can be used to call a service operation directly. However, you can still use the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client to call service operations in one of these two ways:  
  
-   By calling the <xref:System.Data.Services.Client.DataServiceContext.Execute%2A> method on the <xref:System.Data.Services.Client.DataServiceContext>, supplying the URI of the service operation, along with any parameters. This method is used to call any GET service operation.  
  
-   By using the <xref:System.Data.Services.Client.DataServiceContext.CreateQuery%2A> method on the <xref:System.Data.Services.Client.DataServiceContext> to create a <xref:System.Data.Services.Client.DataServiceQuery%601> object. When calling <xref:System.Data.Services.Client.DataServiceContext.CreateQuery%2A>, the name of the service operation is supplied to the `entitySetName` parameter. This method returns a <xref:System.Data.Services.Client.DataServiceQuery%601> object that calls the service operation when enumerated or when the <xref:System.Data.Services.Client.DataServiceQuery%601.Execute%2A> method is called. This method is used to call GET service operations that return a collection. A single parameter can be supplied by using the <xref:System.Data.Services.Client.DataServiceQuery%601.AddQueryOption%2A> method. The <xref:System.Data.Services.Client.DataServiceQuery%601> object returned by this method can be further composed against like any query object. For more information, see [Querying the Data Service](../../../../docs/framework/data/wcf/querying-the-data-service-wcf-data-services.md).  
  
## Considerations for Calling Service Operations  
 The following considerations apply when using the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client to call service operations.  
  
-   When accessing the data service asynchronously, you must use the equivalent asynchronous <xref:System.Data.Services.Client.DataServiceContext.BeginExecute%2A>/<xref:System.Data.Services.Client.DataServiceContext.EndExecute%2A> methods on <xref:System.Data.Services.Client.DataServiceContext> or the <xref:System.Data.Services.Client.DataServiceQuery%601.BeginExecute%2A>/<xref:System.Data.Services.Client.DataServiceQuery%601.EndExecute%2A> methods on <xref:System.Data.Services.Client.DataServiceQuery%601>.  
  
-   The [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library cannot materialize the results from a service operation that returns a collection of primitive types.  
  
-   The [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library does not support calling POST service operations. Service operations that are called by an HTTP POST are defined by using the <xref:System.ServiceModel.Web.WebInvokeAttribute> with the `Method="POST"` parameter. To call a service operation by using an HTTP POST request, you must instead use an <xref:System.Net.HttpWebRequest>.  
  
-   You cannot use <xref:System.Data.Services.Client.DataServiceContext.CreateQuery%2A> to call a GET service operation that returns a single result, of either entity or primitive type, or that requires more than one input parameter. You must instead call the <xref:System.Data.Services.Client.DataServiceContext.Execute%2A> method.  
  
-   Consider creating an extension method on the strongly-typed <xref:System.Data.Services.Client.DataServiceContext> partial class, which is generated by the tools, that uses either the <xref:System.Data.Services.Client.DataServiceContext.CreateQuery%2A> or the <xref:System.Data.Services.Client.DataServiceContext.Execute%2A> method to call a service operation. This enables you to call service operations directly from the context. For more information, see the blog post [Service Operations and the WCF Data Services Client](http://go.microsoft.com/fwlink/?LinkId=215668).  
  
-   When you use <xref:System.Data.Services.Client.DataServiceContext.CreateQuery%2A> to call a service operation, the client library automatically escapes characters supplied to the <xref:System.Data.Services.Client.DataServiceQuery%601.AddQueryOption%2A> by performing percent-encoding of reserved characters, such as ampersand (&), and escaping of single-quotes in strings. However, when you call one of the *Execute* methods to call a service operation, you must remember to perform this escaping of any user-supplied string values. Single-quotes in URIs are escaped as pairs of single-quotes.  
  
## Examples of Calling Service Operations  
 This section contains the following examples of how to call service operations by using the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library:  
  
-   [Calling Execute&lt;T&gt; to Return a Collection of Entities](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md#ExecuteIQueryable)  
  
-   [Using CreateQuery&lt;T&gt; to Return a Collection of Entities](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md#CreateQueryIQueryable)  
  
-   [Calling Execute&lt;T&gt; to Return a Single Entity](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md#ExecuteSingleEntity)  
  
-   [Calling Execute&lt;T&gt; to Return a Collection of Primitive Values](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md#ExecutePrimitiveCollection)  
  
-   [Calling Execute&lt;T&gt; to Return a Single Primitive Value](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md#ExecutePrimitiveValue)  
  
-   [Calling a Service Operation that Returns No Data](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md#ExecuteVoid)  
  
-   [Calling a Service Operation Asynchronously](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md#ExecuteAsync)  
  
<a name="ExecuteIQueryable"></a>   
### Calling Execute\<T> to Return a Collection of Entities  
 The following example calls a service operation named GetOrdersByCity, which takes a string parameter of `city` and returns an <xref:System.Linq.IQueryable%601>:  
  
 [!code-csharp[Astoria Northwind Client#CallServiceOperationIQueryable](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#callserviceoperationiqueryable)]
 [!code-vb[Astoria Northwind Client#CallServiceOperationIQueryable](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#callserviceoperationiqueryable)]  
  
 In this example, the service operation returns a collection of `Order` objects with related `Order_Detail` objects.  
  
<a name="CreateQueryIQueryable"></a>   
### Using CreateQuery\<T> to Return a Collection of Entities  
 The following example uses the <xref:System.Data.Services.Client.DataServiceContext.CreateQuery%2A> to return a <xref:System.Data.Services.Client.DataServiceQuery%601> that is used to call the same GetOrdersByCity service operation:  
  
 [!code-csharp[Astoria Northwind Client#CallServiceOperationCreateQuery](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#callserviceoperationcreatequery)]
 [!code-vb[Astoria Northwind Client#CallServiceOperationCreateQuery](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#callserviceoperationcreatequery)]  
  
 In this example, the <xref:System.Data.Services.Client.DataServiceQuery%601.AddQueryOption%2A> method is used to add the parameter to the query, and the <xref:System.Data.Services.Client.DataServiceQuery%601.Expand%2A> method is used to include related Order_Details objects in the results.  
  
<a name="ExecuteSingleEntity"></a>   
### Calling Execute\<T> to Return a Single Entity  
 The following example calls a service operation named GetNewestOrder that returns only a single Order entity:  
  
 [!code-csharp[Astoria Northwind Client#CallServiceOperationSingleEntity](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#callserviceoperationsingleentity)]
 [!code-vb[Astoria Northwind Client#CallServiceOperationSingleEntity](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#callserviceoperationsingleentity)]  
  
 In this example, the <xref:System.Linq.Enumerable.FirstOrDefault%2A> method is used to request only a single Order entity on execution.  
  
<a name="ExecutePrimitiveCollection"></a>   
### Calling Execute\<T> to Return a Collection of Primitive Values  
 The following example calls a service operation that returns a collection of string values:  
  
 [!code-csharp[Astoria Northwind Client#CallServiceOperationEnumString](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#callserviceoperationenumstring)]  
  
<a name="ExecutePrimitiveValue"></a>   
### Calling Execute\<T> to Return a Single Primitive Value  
 The following example calls a service operation that returns a single string value:  
  
 [!code-csharp[Astoria Northwind Client#CallServiceOperationSingleInt](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#callserviceoperationsingleint)]
 [!code-vb[Astoria Northwind Client#CallServiceOperationSingleInt](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#callserviceoperationsingleint)]  
  
 Again in this example, the <xref:System.Linq.Enumerable.FirstOrDefault%2A> method is used to request only a single integer value on execution.  
  
<a name="ExecuteVoid"></a>   
### Calling a Service Operation that Returns No Data  
 The following example calls a service operation that returns no data:  
  
 [!code-csharp[Astoria Northwind Client#CallServiceOperationVoid](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#callserviceoperationvoid)]
 [!code-vb[Astoria Northwind Client#CallServiceOperationVoid](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#callserviceoperationvoid)]  
  
 Because not data is returned, the value of the execution is not assigned. The only indication that the request has succeeded is that no <xref:System.Data.Services.Client.DataServiceQueryException> is raised.  
  
<a name="ExecuteAsync"></a>   
### Calling a Service Operation Asynchronously  
 The following example calls a service operation asynchronously by calling <xref:System.Data.Services.Client.DataServiceContext.BeginExecute%2A> and <xref:System.Data.Services.Client.DataServiceContext.EndExecute%2A>:  
  
 [!code-csharp[Astoria Northwind Client#CallServiceOperationAsync](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#callserviceoperationasync)]
 [!code-vb[Astoria Northwind Client#CallServiceOperationAsync](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#callserviceoperationasync)]  
  
 [!code-csharp[Astoria Northwind Client#OnAsyncExecutionComplete](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#onasyncexecutioncomplete)]
 [!code-vb[Astoria Northwind Client#OnAsyncExecutionComplete](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#onasyncexecutioncomplete)]  
  
 Because no data is returned, the value returned by the execution is not assigned. The only indication that the request has succeeded is that no <xref:System.Data.Services.Client.DataServiceQueryException> is raised.  
  
 The following example calls the same service operation asynchronously by using <xref:System.Data.Services.Client.DataServiceContext.CreateQuery%2A>:  
  
 [!code-csharp[Astoria Northwind Client#CallServiceOperationQueryAsync](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#callserviceoperationqueryasync)]
 [!code-vb[Astoria Northwind Client#CallServiceOperationQueryAsync](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#callserviceoperationqueryasync)]  
  
 [!code-csharp[Astoria Northwind Client#OnAsyncQueryExecutionComplete](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/source.cs#onasyncqueryexecutioncomplete)]
 [!code-vb[Astoria Northwind Client#OnAsyncQueryExecutionComplete](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/source.vb#onasyncqueryexecutioncomplete)]  
  
## See Also  
 [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md)
