---
title: "SqlClient for the Entity Framework"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9a5d6d39-d955-43a5-a5c2-931c239398f1
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SqlClient for the Entity Framework
This section describes the .NET Framework Data Provider for SQL Server (SqlClient), which enables the Entity Framework to work over Microsoft SQL Server.  
  
## Provider Schema Attribute  
 `Provider` is an attribute of the `Schema` element in store schema definition language (SSDL).  
  
 To use SqlClient, assign the string "System.Data.SqlClient" to the `Provider` attribute of the `Schema` element.  
  
## ProviderManifestToken Schema Attribute  
 `ProviderManifestToken` is a required attribute of the `Schema` element in SSDL. This token is used to load the provider manifest for offline scenarios. For more information about `ProviderManifestToken` attribute, see [Schema Element (SSDL)](http://msdn.microsoft.com/library/fec75ae4-7f16-4421-9265-9dac61509222).  
  
 SqlClient can be used as a data provider for different versions of [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)]. These versions have different capabilities. For example, [!INCLUDE[ssVersion2000](../../../../../includes/ssversion2000-md.md)] does not support `varchar(max)` and `nvarchar(max)` types that were introduced with [!INCLUDE[ssVersion2005](../../../../../includes/ssversion2005-md.md)].  
  
 SqlClient produces and accepts the following provider manifest tokens for different versions of SQL Server.  
  
|SQL Server 2000|SQL Server 2005|SQL Server 2008|  
|-|-|-|  
|2000|2005|2008|  
  
> [!NOTE]
>  Starting with [!INCLUDE[vsprvs](../../../../../includes/vsprvs-md.md)] 2010, the [ADO.NET Entity Data Model  Tools](http://msdn.microsoft.com/library/91076853-0881-421b-837a-f582f36be527) do not support SQL Server 2000.  
  
## Provider Namespace Name  
 All providers must specify a namespace. This property tells the Entity Framework which prefix is used by the provider for specific constructs, such as types and functions. The namespace for SqlClient provider manifests is `SqlServer`. For more information about namespaces, see [Namespaces](../../../../../docs/framework/data/adonet/ef/language-reference/namespaces-entity-sql.md).  
  
## Types  
 The SqlClient provider for the Entity Framework provides mapping information between conceptual model types and SQL Server types. For more information, see [SqlClient for Entity FrameworkTypes](../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-types.md).  
  
## Functions  
 The SqlClient provider for the Entity Framework defines the list of functions supported by the provider. For a list of the supported functions, see [SqlClient for Entity Framework Functions](../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md).  
  
## In This Section  
 [SqlClient for Entity Framework Functions](../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md)  
  
 [SqlClient for Entity FrameworkTypes](../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-types.md)  
  
 [Known Issues in SqlClient for Entity Framework](../../../../../docs/framework/data/adonet/ef/known-issues-in-sqlclient-for-entity-framework.md)  
  
## See Also  
 [Entity SQL Language](../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-language.md)  
 [Language Reference](../../../../../docs/framework/data/adonet/ef/language-reference/index.md)  
 [Known Issues in SqlClient Provider for Entity Framework](../../../../../docs/framework/data/adonet/ef/sqlclient-for-the-entity-framework.md)
