---
title: "Distinct Clause (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.QueryDistinct"
helpviewer_keywords: 
  - "Distinct clause [Visual Basic]"
  - "Distinct statement [Visual Basic]"
  - "queries [Visual Basic], Distinct"
ms.assetid: 86f42614-0d8f-4ffc-b888-ce8a37a8d36a
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# Distinct Clause (Visual Basic)
Restricts the values of the current range variable to eliminate duplicate values in subsequent query clauses.  
  
## Syntax  
  
```  
Distinct  
```  
  
## Remarks  
 You can use the `Distinct` clause to return a list of unique items. The `Distinct` clause causes the query to ignore duplicate query results. The `Distinct` clause applies to duplicate values for all return fields specified by the `Select` clause. If no `Select` clause is specified, the `Distinct` clause is applied to the range variable for the query identified in the `From` clause. If the range variable is not an immutable type, the query will only ignore a query result if all members of the type match an existing query result.  
  
## Example  
 The following query expression joins a list of customers and a list of customer orders. The `Distinct` clause is included to return a list of unique customer names and order dates.  
  
 [!code-vb[VbSimpleQuerySamples#20](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/distinct-clause_1.vb)]  
  
## See Also  
 [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [Queries](../../../visual-basic/language-reference/queries/queries.md)  
 [From Clause](../../../visual-basic/language-reference/queries/from-clause.md)  
 [Select Clause](../../../visual-basic/language-reference/queries/select-clause.md)  
 [Where Clause](../../../visual-basic/language-reference/queries/where-clause.md)
