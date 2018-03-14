---
title: "Interceptors (WCF Data Services)"
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
ms.assetid: e33ae8dc-8069-41d0-99a0-75ff28db7050
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Interceptors (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] enables an application to intercept request messages so that you can add custom logic to an operation. You can use this custom logic to validate data in incoming messages. You can also use it to further restrict the scope of a query request, such as to insert a custom authorization policy on a per request basis.  
  
 Interception is performed by specially attributed methods in the data service. These methods are called by [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] at the appropriate point in message processing. Interceptors are defined on a per-entity set basis, and interceptor methods cannot accept parameters from the request like service operations can. Query interceptor methods, which are called when processing an HTTP GET request, must return a lambda expression that determines whether an instance of the interceptor's entity set should be returned by the query results. This expression is used by the data service to further refine the requested operation. The following is an example definition of a query interceptor.  
  
 [!code-csharp[Astoria Northwind Service#QueryInterceptorDef](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#queryinterceptordef)]
 [!code-vb[Astoria Northwind Service#QueryInterceptorDef](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#queryinterceptordef)]  
  
 For more information, see [How to: Intercept Data Service Messages](../../../../docs/framework/data/wcf/how-to-intercept-data-service-messages-wcf-data-services.md).  
  
 Change interceptors, which are called when processing non-query operations, must return `void` (`Nothing` in Visual Basic). Change interceptor methods must accept the following two parameters:  
  
1.  A parameter of a type that is compatible with the entity type of the entity set. When the data service invokes the change interceptor, the value of this parameter will reflect the entity information that is sent by the request.  
  
2.  A parameter of type <xref:System.Data.Services.UpdateOperations>. When the data service invokes the change interceptor, the value of this parameter will reflect the operation that the request is trying to perform.  
  
 The following is an example definition of a change interceptor.  
  
 [!code-csharp[Astoria Northwind Service#ChangeInterceptorDef](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind2.svc.cs#changeinterceptordef)]
 [!code-vb[Astoria Northwind Service#ChangeInterceptorDef](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind2.svc.vb#changeinterceptordef)]  
  
 For more information, see [How to: Intercept Data Service Messages](../../../../docs/framework/data/wcf/how-to-intercept-data-service-messages-wcf-data-services.md).  
  
 The following attributes are supported for interception.  
  
 **[QueryInterceptor(** *EnitySetName* **)]**  
 Methods with the <xref:System.Data.Services.QueryInterceptorAttribute> attribute applied are called when an HTTP GET request is received for the targeted entity set resource. These methods must always return a lambda expression in the form of `Expression<Func<T,bool>>`.  
  
 **[ChangeInterceptor(** *EnitySetName* **)]**  
 Methods with the <xref:System.Data.Services.ChangeInterceptorAttribute> attribute applied are called when an HTTP request other than HTTP GET request is received for the targeted entity set resource. These methods must always return `void` (`Nothing` in Visual Basic).  
  
 For more information, see [How to: Intercept Data Service Messages](../../../../docs/framework/data/wcf/how-to-intercept-data-service-messages-wcf-data-services.md).  
  
## See Also  
 [Service Operations](../../../../docs/framework/data/wcf/service-operations-wcf-data-services.md)
