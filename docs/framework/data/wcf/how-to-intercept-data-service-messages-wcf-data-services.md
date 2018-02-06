---
title: "How to: Intercept Data Service Messages (WCF Data Services)"
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
  - "WCF Data Services, customizing"
  - "query interceptors [WCF Data Services]"
ms.assetid: 24b9df1b-b54b-4795-a033-edf333675de6
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Intercept Data Service Messages (WCF Data Services)
With [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], you can intercept request messages so that you can add custom logic to an operation. To intercept a message, you use specially attributed methods in the data service. For more information, see [Interceptors](../../../../docs/framework/data/wcf/interceptors-wcf-data-services.md).  
  
 The example in this topic uses the Northwind sample data service. This service is created when you complete the [WCF Data Services quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md).  
  
### To define a query interceptor for the Orders entity set  
  
1.  In the Northwind data service project, open the Northwind.svc file.  
  
2.  In the code page for the `Northwind` class, add the following `using` statement (`Imports` in Visual Basic).  
  
     [!code-csharp[Astoria Northwind Service#UsingLinqExpressions](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#usinglinqexpressions)]
     [!code-vb[Astoria Northwind Service#UsingLinqExpressions](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#usinglinqexpressions)]  
  
3.  In the `Northwind` class, define a service operation method named `OnQueryOrders` as follows:  
  
     [!code-csharp[Astoria Northwind Service#QueryInterceptorDef](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#queryinterceptordef)]
     [!code-vb[Astoria Northwind Service#QueryInterceptorDef](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#queryinterceptordef)]  
  
### To define a change interceptor for the Products entity set  
  
1.  In the Northwind data service project, open the Northwind.svc file.  
  
2.  In the `Northwind` class, define a service operation method named `OnChangeProducts` as follows:  
  
     [!code-csharp[Astoria Northwind Service#ChangeInterceptorDef](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#changeinterceptordef)]
     [!code-vb[Astoria Northwind Service#ChangeInterceptorDef](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#changeinterceptordef)]  
  
## Example  
 This example defines a query interceptor method for the `Orders` entity set that returns a lambda expression. This expression contains a delegate that filters the requested `Orders` based on related `Customers` that have a specific contact name. The name is in turn determined based on the requesting user. This example assumes that the data service is hosted within an ASP.NET Web application that uses WCF, and that authentication is enabled. The <xref:System.Web.HttpContext> class is used to retrieve the principle of the current request.  
  
 [!code-csharp[Astoria Northwind Service#QueryInterceptor](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#queryinterceptor)]
 [!code-vb[Astoria Northwind Service#QueryInterceptor](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#queryinterceptor)]  
  
## Example  
 This example defines a change interceptor method for the `Products` entity set. This method validates input to the service for an <xref:System.Data.Services.UpdateOperations.Add> or <xref:System.Data.Services.UpdateOperations.Change> operation and raises an exception if a change is being made to a discontinued product. It also blocks the deletion of products as an unsupported operation.  
  
 [!code-csharp[Astoria Northwind Service#ChangeInterceptor](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#changeinterceptor)]
 [!code-vb[Astoria Northwind Service#ChangeInterceptor](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#changeinterceptor)]  
  
## See Also  
 [How to: Define a Service Operation](../../../../docs/framework/data/wcf/how-to-define-a-service-operation-wcf-data-services.md)  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)
