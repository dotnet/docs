---
title: "Entity Framework Provider (WCF Data Services)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF Data Services, providers"
ms.assetid: 650b5eb6-c71d-4dc1-8b64-b6beaf752114
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Entity Framework Provider (WCF Data Services)
Like [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], the ADO.NET Entity Framework is based on the Entity Data Model, which is a type of entity-relationship model. The Entity Framework translates operations against its implementation of the Entity Data Model, which is called the *conceptual model*, into equivalent operations against a data source. This makes the Entity Framework an ideal provider for data services that are based on relational data, and any database that has a data provider that supports the Entity Framework can be used with [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)]. For a list of the data sources that currently support the Entity Framework, see [Third-Party Providers for the Entity Framework](http://go.microsoft.com/fwlink/?LinkId=143699).  
  
 In a conceptual model, the entity container is the root of the service. You must define a conceptual model in the Entity Framework before the data can be exposed by a data service. For more information, see [How to: Create a Data Service Using an ADO.NET Entity Framework Data Source](../../../../docs/framework/data/wcf/create-a-data-service-using-an-adonet-ef-data-wcf.md).  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] supports the optimistic concurrency model by enabling you to define a concurrency token for an entity. This concurrency token, which includes one or more properties of the entity, is used by the data service to determine whether a change has occurred in the data that is being requested, updated, or deleted. When token values obtained from the eTag in the request differ from the current values of the entity, an exception is raised by the data service. To indicate that a property is part of the concurrency token, you must apply the attribute `ConcurrencyMode="Fixed"` in the data model defined by the [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] provider. The concurrency token cannot include a key property or a navigation property. For more information, see [Updating the Data Service](../../../../docs/framework/data/wcf/updating-the-data-service-wcf-data-services.md).  
  
 To learn more about the Entity Framework, see [Entity Framework Overview](../../../../docs/framework/data/adonet/ef/overview.md).  
  
## See Also  
 [Data Services Providers](../../../../docs/framework/data/wcf/data-services-providers-wcf-data-services.md)  
 [Reflection Provider](../../../../docs/framework/data/wcf/reflection-provider-wcf-data-services.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)
