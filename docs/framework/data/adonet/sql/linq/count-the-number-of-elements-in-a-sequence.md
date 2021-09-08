---
description: "Learn more about: Count the Number of Elements in a Sequence"
title: "Count the Number of Elements in a Sequence"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: ccbe5d54-c9eb-4b14-b0ab-f628483c5f99
---
# Count the Number of Elements in a Sequence

Use the <xref:System.Linq.Enumerable.Count%2A> operator to count the number of elements in a sequence.  
  
 Running this query against the Northwind sample database produces an output of `91`.  
  
## Example 1

 The following example counts the number of `Customers` in the database.  
  
 [!code-csharp[DLinqQueryExamples#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#4)]
 [!code-vb[DLinqQueryExamples#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#4)]  
  
## Example 2  

 The following example counts the number of products in the database that have not been discontinued.  
  
 Running this example against the Northwind sample database produces an output of `69`.  
  
 [!code-csharp[DLinqQueryExamples#5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#5)]
 [!code-vb[DLinqQueryExamples#5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#5)]  
  
## See also

- [Aggregate Queries](aggregate-queries.md)
- [Downloading Sample Databases](downloading-sample-databases.md)
