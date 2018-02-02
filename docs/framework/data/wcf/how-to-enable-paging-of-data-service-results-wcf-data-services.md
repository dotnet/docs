---
title: "How to: Enable Paging of Data Service Results (WCF Data Services)"
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
  - "paging output [WCF Data Services]"
ms.assetid: 9a316cbd-9612-4482-a541-a10bc78b2635
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Enable Paging of Data Service Results (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] enables you to limit the number of entities returned by a data service query. Page limits are defined in the method that is called when the service is initialized and can be set separately for each entity set.  
  
 When paging is enabled, the final entry in the feed contains a link to the next page of data. For more information, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md).  
  
 This topic shows how to modify a data service to enable paging of returned `Customers` and `Orders` entity sets. The example in this topic uses the Northwind sample data service. This service is created when you complete the [WCF Data Services quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md).  
  
### How to enable paging of returned Customers and Orders entity sets  
  
-   In the code for the data service, replace the placeholder code in the `InitializeService` function with the following:  
  
     [!code-csharp[Astoria Northwind Service#DataServiceConfigPaging](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind service/cs/northwind.svc.cs#dataserviceconfigpaging)]
     [!code-vb[Astoria Northwind Service#DataServiceConfigPaging](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind service/vb/northwind.svc.vb#dataserviceconfigpaging)]  
  
## See Also  
 [Loading Deferred Content](../../../../docs/framework/data/wcf/loading-deferred-content-wcf-data-services.md)  
 [How to: Load Paged Results](../../../../docs/framework/data/wcf/how-to-load-paged-results-wcf-data-services.md)
