---
title: "How to: Define a Service Operation (WCF Data Services)"
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
  - "Service Operations [WCF Data Services]"
  - "WCF Data Services, service operations"
ms.assetid: dfcd3cb1-2f07-4d0b-b16a-6b056c4f45fa
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Define a Service Operation (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] expose methods that are defined on the server as service operations. Service operations allow a data service to provide access through a URI to a method that is defined on the server. To define a service operation, apply the [`WebGet]` or `[WebInvoke]` attribute to the method. To support query operators, the service operation must return an <xref:System.Linq.IQueryable%601> instance. Service operations may access the underlying data source through the <xref:System.Data.Services.DataService%601.CurrentDataSource%2A> property on the <xref:System.Data.Services.DataService%601>. For more information, see [Service Operations](../../../../docs/framework/data/wcf/service-operations-wcf-data-services.md).  
  
 The example in this topic defines a service operation named `GetOrdersByCity` that returns a filtered <xref:System.Linq.IQueryable%601> instance of `Orders` and related `Order_Details` objects. The example accesses the <xref:System.Data.Objects.ObjectContext> instance that is the data source for the Northwind sample data service. This service is created when you complete the [WCF Data Services quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md).  
  
### To define a service operation in the Northwind data service  
  
1.  In the Northwind data service project, open the Northwind.svc file.  
  
2.  In the `Northwind` class, define a service operation method named `GetOrdersByCity` as follows:  
  
     [!code-csharp[Astoria Northwind Service#ServiceOperationDef](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#serviceoperationdef)]
     [!code-vb[Astoria Northwind Service#ServiceOperationDef](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#serviceoperationdef)]  
  
3.  In the `InitializeService` method of the `Northwind` class, add the following code to enable access to the service operation:  
  
     [!code-csharp[Astoria Northwind Service#ServiceOperationConfig](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#serviceoperationconfig)]
     [!code-vb[Astoria Northwind Service#ServiceOperationConfig](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#serviceoperationconfig)]  
  
### To query the GetOrdersByCity service operation  
  
-   In a Web browser, enter one of the following URIs to invoke the service operation that is defined in the following example:  
  
    -   `http://localhost:12345/Northwind.svc/GetOrdersByCity?city='London'`  
  
    -   `http://localhost:12345/Northwind.svc/GetOrdersByCity?city='London'&$top=2`  
  
    -   `http://localhost:12345/Northwind.svc/GetOrdersByCity?city='London'&$expand=Order_Details&$orderby=RequiredDate desc`  
  
## Example  
 The following example implements a service operation named `GetOrderByCity` on the Northwind data service. This operation uses the ADO.NET Entity Framework to return a set of `Orders` and related `Order_Details` objects as an <xref:System.Linq.IQueryable%601> instance based on the provided city name.  
  
> [!NOTE]
>  Query operators are supported on this service operation endpoint because the method returns an <xref:System.Linq.IQueryable%601> instance.  
  
 [!code-csharp[Astoria Northwind Service#ServiceOperation](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#serviceoperation)]
 [!code-vb[Astoria Northwind Service#ServiceOperation](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#serviceoperation)]  
  
## See Also  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)
