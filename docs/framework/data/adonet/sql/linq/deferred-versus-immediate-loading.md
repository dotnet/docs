---
title: "Deferred versus Immediate Loading"
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
ms.assetid: d1d7247f-a3b7-460b-b342-5c1a2365aa1a
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Deferred versus Immediate Loading
When you query for an object, you actually retrieve only the object you requested. The *related* objects are not automatically fetched at the same time. (For more information, see [Querying Across Relationships](../../../../../../docs/framework/data/adonet/sql/linq/querying-across-relationships.md).) You cannot see the fact that the related objects are not already loaded, because an attempt to access them produces a request that retrieves them.  
  
 For example, you might want to query for a particular set of orders and then only occasionally send an email notification to particular customers. You would not necessarily need initially to retrieve all customer data with every order. You can use deferred loading to defer retrieval of extra information until you absolutely have to. Consider the following example:  
  
 [!code-csharp[DLinqQueryConcepts#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#1)]
 [!code-vb[DLinqQueryConcepts#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#1)]  
  
 The opposite might also be true. You might have an application that has to view customer and order data at the same time. You know you need both sets of data. You know your application needs order information for each customer as soon as you get the results. You would not want to submit individual queries for orders for every customer. What you really want is to retrieve the order data together with the customers.  
  
 [!code-csharp[DLinqQueryConcepts#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#2)]
 [!code-vb[DLinqQueryConcepts#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#2)]  
  
 You can also join customers and orders in a query by forming the cross-product and retrieving all the relative bits of data as one large projection. But these results are not entities. (For more information, see [The LINQ to SQL Object Model](../../../../../../docs/framework/data/adonet/sql/linq/the-linq-to-sql-object-model.md)). Entities are objects that have identity and that you can modify, whereas these results would be projections that cannot be changed and persisted. Even worse, you would be retrieving lots of redundant data as each customer repeats for each order in the flattened join output.  
  
 What you really need is a way to retrieve a set of related objects at the same time. The set is a delineated section of a graph so that you would never be retrieving more or less than was necessary for your intended use. For this purpose, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provides <xref:System.Data.Linq.DataLoadOptions> for immediate loading of a region of your object model. Methods include:  
  
-   The  <xref:System.Data.Linq.DataLoadOptions.LoadWith%2A> method, to immediately load data related to the main target.  
  
-   The <xref:System.Data.Linq.DataLoadOptions.AssociateWith%2A> method, to filter objects retrieved for a particular relationship.  
  
## See Also  
 [Query Concepts](../../../../../../docs/framework/data/adonet/sql/linq/query-concepts.md)
