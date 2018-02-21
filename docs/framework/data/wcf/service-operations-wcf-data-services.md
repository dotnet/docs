---
title: "Service Operations (WCF Data Services)"
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
  - "service operations [WCF Data Services]"
  - "WCF Data Services, service operations"
ms.assetid: 583a690a-e60f-4990-8991-d6efce069d76
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service Operations (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] enables you to define service operations on a data service to expose methods on the server. Like other data service resources, service operations are addressed by URIs. Service operations enable you to expose business logic in a data service, such as to implement validation logic, to apply role-based security, or to expose specialized querying capabilities. Service operations are methods added to the data service class that derives from <xref:System.Data.Services.DataService%601>. Like all other data service resources, you can supply parameters to the service operation method. For example, the following service operation URI (based on the [quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md) data service) passes the value `London` to the `city` parameter:  
  
```  
http://localhost:12345/Northwind.svc/GetOrdersByCity?city='London'  
```  
  
 The definition for this service operation is as follows:  
  
 [!code-csharp[Astoria Northwind Service#ServiceOperationDef](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#serviceoperationdef)]
 [!code-vb[Astoria Northwind Service#ServiceOperationDef](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#serviceoperationdef)]  
  
 You can use the <xref:System.Data.Services.DataService%601.CurrentDataSource%2A> of the <xref:System.Data.Services.DataService%601> to directly access the data source that the data service is using. For more information, see [How to: Define a Service Operation](../../../../docs/framework/data/wcf/how-to-define-a-service-operation-wcf-data-services.md).  
  
 For information on how to call a service operation from a .NET Framework client application, see [Calling Service Operations](../../../../docs/framework/data/wcf/calling-service-operations-wcf-data-services.md).  
  
## Service Operation Requirements  
 The following requirements apply when defining service operations on the data service. If a method does not meet these requirements, it will not be exposed as a service operation for the data service.  
  
-   The operation must be a public instance method that is a member of the data service class.  
  
-   The operation method may only accept input parameters. Data sent in the message body cannot be accessed by the data service.  
  
-   If parameters are defined, the type of each parameter must be a primitive type. Any data of a non-primitive type must be serialized and passed into a string parameter.  
  
-   The method must return one of the following:  
  
    -   `void` (`Nothing` in Visual Basic)  
  
    -   <xref:System.Collections.Generic.IEnumerable%601>  
  
    -   <xref:System.Linq.IQueryable%601>  
  
    -   An entity type in the data model that the data service exposes.  
  
    -   A primitive class such as integer or string.  
  
-   In order to support query options such as sorting, paging, and filtering, service operation methods should return <xref:System.Linq.IQueryable%601>. Requests to service operations that include query options are rejected for operations that only return <xref:System.Collections.Generic.IEnumerable%601>.  
  
-   In order to support accessing related entities by using navigation properties, the service operation must return <xref:System.Linq.IQueryable%601>.  
  
-   The method must be annotated with the `[WebGet]` or `[WebInvoke]` attribute.  
  
    -   `[WebGet]` enables the method to be invoked by using a GET request.  
  
    -   `[WebInvoke(Method = "POST")]` enables the method to be invoked by using a POST request. Other <xref:System.ServiceModel.Web.WebInvokeAttribute> methods are not supported.  
  
-   A service operation may be annotated with the <xref:System.Data.Services.SingleResultAttribute> that specifies that the return value from the method is a single entity rather than a collection of entities. This distinction dictates the resulting serialization of the response and the manner in which additional navigation property traversals are represented in the URI. For example, when using AtomPub serialization, a single resource type instance is represented as an entry element and a set of instances as a feed element.  
  
## Addressing Service Operations  
 You can address service operations by placing the name of the method in the first path segment of a URI. As an example, the following URI accesses a `GetOrdersByState` operation that returns an <xref:System.Linq.IQueryable%601> collection of `Orders` objects.  
  
```  
http://localhost:12345/Northwind.svc/GetOrdersByState?state='CA'&includeItems=true  
```  
  
 When calling a service operation, parameters are supplied as query options. The previous service operation accepts both a string parameter `state` and a Boolean parameter `includeItems` that indicates whether to include related `Order_Detail` objects in the response.  
  
 The following are valid return types for a service operation:  
  
|Valid Return Types|URI Rules|  
|------------------------|---------------|  
|`void` (`Nothing` in Visual Basic)<br /><br /> -or-<br /><br /> Entity types<br /><br /> -or-<br /><br /> Primitive types|The URI must be a single path segment that is the name of the service operation. Query options are not allowed.|  
|<xref:System.Collections.Generic.IEnumerable%601>|The URI must be a single path segment that is the name of the service operation. Because the result type is not an <xref:System.Linq.IQueryable%601> type, query options are not allowed.|  
|<xref:System.Linq.IQueryable%601>|Query path segments in addition to the path that is the name of the service operation are allowed. Query options are also allowed.|  
  
 Additional path segments or query options may be added to the URI depending on the return type of the service operation. For example, the following URI accesses a `GetOrdersByCity` operation that returns an <xref:System.Linq.IQueryable%601> collection of `Orders` objects, ordered by `RequiredDate` in descending order, along with the related `Order_Details` objects:  
  
```  
http://localhost:12345/Northwind.svc/GetOrdersByCity?city='London'&$expand=Order_Details&$orderby=RequiredDate desc  
```  
  
## Service Operations Access Control  
 Service-wide visibility of service operations is controlled by the <xref:System.Data.Services.IDataServiceConfiguration.SetServiceOperationAccessRule%2A> method on the <xref:System.Data.Services.IDataServiceConfiguration> class in much the same way that entity set visibility is controlled by using the <xref:System.Data.Services.IDataServiceConfiguration.SetEntitySetAccessRule%2A> method. For example, the following line of code in the data service definition enables access to the `CustomersByCity` service operation.  
  
 [!code-csharp[Astoria Northwind Service#ServiceOperationConfig](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#serviceoperationconfig)]
 [!code-vb[Astoria Northwind Service#ServiceOperationConfig](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#serviceoperationconfig)]  
  
> [!NOTE]
>  If a service operation has a return type that has been hidden by restricting access on the underlying entity sets, then the service operation will not be available to client applications.  
  
 For more information, see [How to: Define a Service Operation](../../../../docs/framework/data/wcf/how-to-define-a-service-operation-wcf-data-services.md).  
  
## Raising Exceptions  
 We recommend that you use the <xref:System.Data.Services.DataServiceException> class whenever you raise an exception in the data service execution. This is because the data service runtime knows how to map properties of this exception object correctly to the HTTP response message. When you raise a <xref:System.Data.Services.DataServiceException> in a service operation, the returned exception is wrapped in a <xref:System.Reflection.TargetInvocationException>. To return the base <xref:System.Data.Services.DataServiceException> without the enclosing <xref:System.Reflection.TargetInvocationException>, you must override the <xref:System.Data.Services.DataService%601.HandleException%2A> method in the <xref:System.Data.Services.DataService%601>, extract the <xref:System.Data.Services.DataServiceException> from the <xref:System.Reflection.TargetInvocationException>, and return it as the top-level error, as in the following example:  
  
 [!code-csharp[Astoria Northwind Service#HandleExceptions](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#handleexceptions)]
 [!code-vb[Astoria Northwind Service#HandleExceptions](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#handleexceptions)]  
  
## See Also  
 [Interceptors](../../../../docs/framework/data/wcf/interceptors-wcf-data-services.md)
