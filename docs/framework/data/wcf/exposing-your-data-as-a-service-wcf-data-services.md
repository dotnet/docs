---
title: "Exposing Your Data as a Service (WCF Data Services)"
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
  - "WCF Data Services, configuring"
  - "getting started, WCF Data Services"
  - "WCF Data Services, getting started"
ms.assetid: df0bbcee-f66f-4a88-abb4-4e73c8b9c908
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Exposing Your Data as a Service (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] integrates with Visual Studio to enable you to more easily define services to expose your data as [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] feeds. Creating a data service that exposes an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed involves the following basic steps:  
  
1.  **Define** **the data model**. [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] natively supports data models that are based on the [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md). For more information, see [How to: Create a Data Service Using an ADO.NET Entity Framework Data Source](../../../../docs/framework/data/wcf/create-a-data-service-using-an-adonet-ef-data-wcf.md).  
  
     [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] also supports data models that are based on common language runtime (CLR) objects that return an instance of the <xref:System.Linq.IQueryable%601> interface. This enables you to deploy data services that are based on lists, arrays, and collections in the .NET Framework. To enable create, update, and delete operations over these data structures, you must also implement the <xref:System.Data.Services.IUpdatable> interface. For more information, see [How to: Create a Data Service Using the Reflection Provider](../../../../docs/framework/data/wcf/create-a-data-service-using-rp-wcf-data-services.md).  
  
     For more advanced scenarios, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] includes a set of providers that enable you to define a data model based on late-bound data types. For more information, see [Custom Data Service Providers](../../../../docs/framework/data/wcf/custom-data-service-providers-wcf-data-services.md).  
  
2.  **Create the data service.** The most basic data service exposes a class that inherits from the <xref:System.Data.Services.DataService%601> class, with a type `T` that is the namespace-qualified name of the entity container. For more information, see [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md).  
  
3.  **Configure the data service.** By default, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] disables access to resources that are exposed by an entity container. The <xref:System.Data.Services.DataServiceConfiguration> interface enables you to configure access to resources and service operations, specify the supported version of [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)], and to define other service-wide behaviors, such as batching behaviors or the maximum number of entities that can be returned in a single response. For more information, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md).  
  
 For an example of how to create a simple data service that is based on the Northwind sample database, see [Quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md).  
  
## See Also  
 [Getting Started](../../../../docs/framework/data/wcf/getting-started-with-wcf-data-services.md)  
 [Overview](../../../../docs/framework/data/wcf/wcf-data-services-overview.md)
