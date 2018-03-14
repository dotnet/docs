---
title: "Query Plan Caching (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 90b0c685-5ef2-461b-98b4-c3c0a2b253c7
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Query Plan Caching (Entity SQL)
Whenever an attempt to execute a query is made, the query pipeline looks up its query plan cache to see whether the exact query is already compiled and available. If so, it reuses the cached plan rather than building a new one. If a match is not found in the query plan cache, the query is compiled and cached. A query is identified by its [!INCLUDE[esql](../../../../../../includes/esql-md.md)] text and parameter collection (names and types). All text comparisons are case-sensitive.  
  
## Configuration  
 Query plan caching is configurable through the <xref:System.Data.EntityClient.EntityCommand>.  
  
 To enable or disable query plan caching through <xref:System.Data.EntityClient.EntityCommand.EnablePlanCaching%2A?displayProperty=nameWithType>, set this property to `true` or `false`. Disabling plan caching for individual dynamic queries that are unlikely to be used more then once improves performance.  
  
 You can enable query plan caching through <xref:System.Data.Objects.ObjectQuery.EnablePlanCaching%2A>.  
  
## Recommended Practice  
 Dynamic queries should be avoided, in general. The following dynamic query example is vulnerable to SQL injection attacks, because it takes user input directly without any validation.  
  
 `"SELECT sp.SalesYTD FROM AdventureWorksEntities.SalesPerson as sp WHERE sp.EmployeeID = " + employeeTextBox.Text;`  
  
 If you do use dynamically generated queries, consider disabling query plan caching to avoid unnecessary memory consumption for cache entries that are unlikely to be reused.  
  
 Query plan caching on static queries and parameterized queries can provide performance benefits. The following is an example of a static query:  
  
```  
"SELECT sp.SalesYTD FROM AdventureWorksEntities.SalesPerson as sp";  
```  
  
 For queries to be matched properly by the query plan cache, they should comply with the following requirements:  
  
-   Query text should be a constant pattern, preferably a constant string or a resource.  
  
-   <xref:System.Data.EntityClient.EntityParameter> or <xref:System.Data.Objects.ObjectParameter> should be used wherever a user-supplied value must be passed.  
  
 You should avoid the following query patterns, which unnecessarily consume slots in the query plan cache:  
  
-   Changes to letter case in the text.  
  
-   Changes to white space.  
  
-   Changes to literal values.  
  
-   Changes to text inside comments.  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
