---
title: "Query Results"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: bcd7b699-4e50-4523-8c33-2f54a103d94e
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Query Results
After a [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] query is converted to command trees and executed, the query results are usually returned as one of the following:  
  
-   A collection of zero or more typed entity objects or a projection of complex types in the conceptual model.  
  
-   CLR types supported by the conceptual model.  
  
-   Inline collections.  
  
-   Anonymous types.  
  
 When the query has executed against the data source, the results are materialized into CLR types and returned to the client. All object materialization is performed by the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)]. Any errors that result from an inability to map between the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)] and the CLR will cause exceptions to be thrown during object materialization.  
  
 If the query execution returns primitive conceptual model types, the results consist of CLR types that are stand-alone and disconnected from the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)]. However, if the query returns a collection of typed entity objects, represented by <xref:System.Data.Objects.ObjectQuery%601>, those types are tracked by the object context. All object behavior (such as child/parent collections, change tracking, polymorphism, and so on) are as defined in the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)]. This functionality can be used in its capacity, as defined in the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)]. For more information, see [Working with Objects](../../../../../../docs/framework/data/adonet/ef/working-with-objects.md).  
  
 Struct types returned from queries (such as anonymous types and nullable complex types) can be of `null` value. An <xref:System.Data.Objects.DataClasses.EntityCollection%601> property of a returned entity can also be of `null` value. This can result from projecting the collection property of an entity that is of `null` value, such as calling <xref:System.Linq.Queryable.FirstOrDefault%2A> on an <xref:System.Data.Objects.ObjectQuery%601> that has no elements.  
  
 In certain situations, a query might appear to generate a materialized result during its execution, but the query will be executed on the server and the entity object will never be materialized in the CLR. This can cause problems if you are depending on side effects of object materialization.  
  
 The following example contains a custom class, `MyContact`, with a `LastName` property. When the `LastName` property is set, a `count` variable is incremented. If you execute the two following queries, the first query will increment `count` while the second query will not. This is because in the second query the `LastName` property is projected from the results and the `MyContact` class is never created, because it is not required to execute the query on the store.  
  
 [!code-csharp[DP L2E Materialization Example#MaterializationSideEffects](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Materialization Example/CS/Program.cs#materializationsideeffects)]
 [!code-vb[DP L2E Materialization Example#MaterializationSideEffects](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Materialization Example/VB/Module1.vb#materializationsideeffects)]  
  
 [!code-csharp[DP L2E Materialization Example#MyContactClass](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Materialization Example/CS/Program.cs#mycontactclass)]
 [!code-vb[DP L2E Materialization Example#MyContactClass](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Materialization Example/VB/Module1.vb#mycontactclass)]
