---
description: "Learn more about: Constant Expressions"
title: "Constant Expressions"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 9d98a7be-b110-4edb-8eba-bed10f250b6d
---
# Constant Expressions

A constant expression consists of a constant value. Constant values are directly converted to constant command tree expressions, without any translation on the client. This includes expressions that result in a constant value. Therefore, data source behavior should be expected for all expressions involving constants. This can result in behavior that differs from CLR behavior.  
  
 The following example shows a constant expression that is evaluated on the server.  
  
 [!code-csharp[DP L2E Conceptual Examples#ConstantExpression](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#constantexpression)]
 [!code-vb[DP L2E Conceptual Examples#ConstantExpression](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#constantexpression)]  
  
 LINQ to Entities does not support using a user class as a constant. However, a property reference on a user class is considered a constant, and will be converted to a command tree constant expression and executed on the data source.  
  
## See also

- [Expressions in LINQ to Entities Queries](expressions-in-linq-to-entities-queries.md)
