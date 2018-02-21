---
title: "Writing an Entity Framework Data Provider"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 092e88c4-a301-453a-b5c3-5740c6575a9f
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Writing an Entity Framework Data Provider
This section discusses how to write an [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] provider to support a data source other than [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)]. The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] includes a provider that supports [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)].  
  
## Introducing the Entity Framework Provider Model  
 The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] is database independent, and you can write a provider by using the ADO.NET Provider Model to connect to a diverse set of data sources.  
  
 The Entity Framework data provider (built using the ADO.NET Data Provider model) performs the following functions:  
  
-   Maps Entity Data Model (EDM) primitive types to provider types.  
  
-   Exposes provider-specific functions.  
  
-   Generates provider-specific commands for a given DbQueryCommandTree to support [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] queries.  
  
-   Generates provider-specific update commands for a given DbModificationCommandTree to support updates through the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)].  
  
-   Exposes mapping files for the store schema definition, to support generation of a model based on a database.  
  
-   Exposes metadata (tables and views, for example) via a conceptual model.  
  
 ![b42a7a5c&#45;0ac0&#45;4911&#45;86be&#45;0460a78760ba](../../../../../docs/framework/data/adonet/ef/media/b42a7a5c-0ac0-4911-86be-0460a78760ba.gif "b42a7a5c-0ac0-4911-86be-0460a78760ba")  
  
## Sample  
 See the [Entity Framework Sample Provider](http://go.microsoft.com/fwlink/?LinkId=180616) for a sample of an [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] provider that supports a data source other than [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)].  
  
## In This Section  
 [SQL Generation](../../../../../docs/framework/data/adonet/ef/sql-generation.md)  
  
 [Modification SQL Generation](../../../../../docs/framework/data/adonet/ef/modification-sql-generation.md)  
  
 [Provider Manifest Specification](../../../../../docs/framework/data/adonet/ef/provider-manifest-specification.md)  
  
## See Also  
 [Working with Data Providers](../../../../../docs/framework/data/adonet/ef/working-with-data-providers.md)
