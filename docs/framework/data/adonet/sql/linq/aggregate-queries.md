---
title: "Aggregate Queries"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 13ec5580-05ce-4a1f-9d3d-8660be7891a2
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Aggregate Queries
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports the `Average`, `Count`, `Max`, `Min`, and `Sum` aggregate operators. Note the following characteristics of aggregate operators in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]:  
  
-   Aggregate queries are executed immediately.  
  
     For more information, see [Introduction to LINQ Queries (C#)](~/docs/csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).  
  
-   Aggregate queries typically return a number instead of a collection.  
  
     For more information, see [Aggregation Operations](http://msdn.microsoft.com/library/36d97c83-5de5-457d-971d-10a69365e7c4).  
  
-   You cannot call aggregates against anonymous types.  
  
 The examples in the following topics derive from the Northwind sample database. For more information, see [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md).  
  
## In This Section  
 [Return the Average Value From a Numeric Sequence](../../../../../../docs/framework/data/adonet/sql/linq/return-the-average-value-from-a-numeric-sequence.md)  
 Demonstrates how to use the <xref:System.Linq.Enumerable.Average%2A> operator.  
  
 [Count the Number of Elements in a Sequence](../../../../../../docs/framework/data/adonet/sql/linq/count-the-number-of-elements-in-a-sequence.md)  
 Demonstrates how to use the <xref:System.Linq.Enumerable.Count%2A> operator.  
  
 [Find the Maximum Value in a Numeric Sequence](../../../../../../docs/framework/data/adonet/sql/linq/find-the-maximum-value-in-a-numeric-sequence.md)  
 Demonstrates how to use the <xref:System.Linq.Enumerable.Max%2A> operator.  
  
 [Find the Minimum Value in a Numeric Sequence](../../../../../../docs/framework/data/adonet/sql/linq/find-the-minimum-value-in-a-numeric-sequence.md)  
 Demonstrates how to use the <xref:System.Linq.Enumerable.Min%2A> operator.  
  
 [Compute the Sum of Values in a Numeric Sequence](../../../../../../docs/framework/data/adonet/sql/linq/compute-the-sum-of-values-in-a-numeric-sequence.md)  
 Demonstrates how to use the <xref:System.Linq.Enumerable.Sum%2A> operator.  
  
## Related Sections  
 [Query Examples](../../../../../../docs/framework/data/adonet/sql/linq/query-examples.md)  
 Provides links to [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] queries in Visual Basic and C#.  
  
 [Query Concepts](../../../../../../docs/framework/data/adonet/sql/linq/query-concepts.md)  
 Provides links to topics that explain concepts for designing [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)] queries in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].  
  
 [Introduction to LINQ Queries (C#)](~/docs/csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md)  
 Explains how queries work in [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)].
