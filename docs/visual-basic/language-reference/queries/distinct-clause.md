---
description: "Learn more about: Distinct Clause (Visual Basic)"
title: "Distinct Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.QueryDistinct"
helpviewer_keywords: 
  - "Distinct clause [Visual Basic]"
  - "Distinct statement [Visual Basic]"
  - "queries [Visual Basic], Distinct"
ms.assetid: 86f42614-0d8f-4ffc-b888-ce8a37a8d36a
---
# Distinct Clause (Visual Basic)

Restricts the values of the current range variable to eliminate duplicate values in subsequent query clauses.  
  
## Syntax  
  
```vb  
Distinct  
```  
  
## Remarks  

 You can use the `Distinct` clause to return a list of unique items. The `Distinct` clause causes the query to ignore duplicate query results. The `Distinct` clause applies to duplicate values for all return fields specified by the `Select` clause. If no `Select` clause is specified, the `Distinct` clause is applied to the range variable for the query identified in the `From` clause. If the range variable is not an immutable type, the query will only ignore a query result if all members of the type match an existing query result.  
  
## Example  

 The following query expression joins a list of customers and a list of customer orders. The `Distinct` clause is included to return a list of unique customer names and order dates.  
  
 [!code-vb[VbSimpleQuerySamples#20](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#20)]  
  
## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](index.md)
- [From Clause](from-clause.md)
- [Select Clause](select-clause.md)
- [Where Clause](where-clause.md)
