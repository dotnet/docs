---
title: "Canonical Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bbcc9928-36ea-4dff-9e31-96549ffed958
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Canonical Functions
This section discusses canonical functions that are supported by all data providers, and can be used by all querying technologies. Canonical functions cannot be extended by a provider.  
  
 These canonical functions will be translated to the corresponding data source functionality for the provider. This allows for function invocations expressed in a common form across data sources.  
  
 Because these canonical functions are independent of data sources, argument and return types of canonical functions are defined in terms of types in the conceptual model. However, some data sources might not support all types in the conceptual model.  
  
 When canonical functions are used in an [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query, the appropriate function will be called at the data source.  
  
 All canonical functions have both null-input behavior and error conditions explicitly specified. Store providers should comply with that behavior, but [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)] does not enforce this behavior.  
  
 For LINQ scenarios, queries against the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)] involve mapping CLR methods to methods in the underlying data source. The CLR methods map to canonical functions, so that a specific set of methods will correctly map, regardless of the data source.  
  
## Canonical Functions Namespace  
 The namespace for canonical function is <xref:System.Data.Metadata.Edm>. The <xref:System.Data.Metadata.Edm> namespace is automatically included in all queries. However, if another namespace is imported that contains a function with the same name as a canonical function (in the <xref:System.Data.Metadata.Edm> namespace), you must specify the namespace.  
  
## In This Section  
 [Aggregate Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/aggregate-canonical-functions.md)  
 Discusses aggregate [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.  
  
 [Math Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/math-canonical-functions.md)  
 Discusses math [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.  
  
 [String Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/string-canonical-functions.md)  
 Discusses string [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.  
  
 [Date and Time Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/date-and-time-canonical-functions.md)  
 Discusses date and time [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.  
  
 [Bitwise Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/bitwise-canonical-functions.md)  
 Discusses bitwise [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.  
  
 [Spatial Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/spatial-functions.md)  
 Discusses Spatial [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.  
  
 [Other Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/other-canonical-functions.md)  
 Discusses functions not classified as bitwise, date/time, string, math, or aggregate.  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Conceptual Model Canonical to SQL Server Functions Mapping](../../../../../../docs/framework/data/adonet/ef/conceptual-model-canonical-to-sql-server-functions-mapping.md)  
 [User-Defined Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/user-defined-functions-entity-sql.md)
