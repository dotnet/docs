---
title: "How to: Customize Feeds with the Reflection Provider (WCF Data Services)"
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
  - "WCF Data Services, customizing feeds"
ms.assetid: 00c23dcf-9bb8-459a-a012-6c4d9bcad7e9
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Customize Feeds with the Reflection Provider (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] enables you to customize the Atom serialization in a data service response so that properties of an entity may be mapped to unused elements that are defined in the AtomPub protocol. This topic shows how to define mapping attributes for the entity types in a data model that is defined by using the reflection provider. For more information, see [Feed Customization](../../../../docs/framework/data/wcf/feed-customization-wcf-data-services.md).  
  
 The data model for this example is defined in the topic [How to: Create a Data Service Using the Reflection Provider](../../../../docs/framework/data/wcf/create-a-data-service-using-rp-wcf-data-services.md)  
  
## Example  
 In the following example, both properties of the `Order` type are mapped to existing Atom elements. The `Product` property of the `Item` type is mapped to a custom feed attribute in a separate namespace.  
  
 [!code-csharp[Astoria Custom Feeds#CustomIQueryableFeeds](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria custom feeds/cs/orderitems.svc.cs#customiqueryablefeeds)]
 [!code-vb[Astoria Custom Feeds#CustomIQueryableFeeds](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria custom feeds/vb/orderitems.svc.vb#customiqueryablefeeds)]  
  
## Example  
 The previous example returns the following result for the URI `http://myservice/OrderItems.svc/Orders(0)?$expand=Items`.  
  
 [!code-xml[Astoria Custom Feeds#IQueryableFeedResultInline](../../../../samples/snippets/xml/VS_Snippets_Misc/astoria custom feeds/xml/iqueryablefeedresultinline.xml#iqueryablefeedresultinline)]  
  
## See Also  
 [Reflection Provider](../../../../docs/framework/data/wcf/reflection-provider-wcf-data-services.md)
