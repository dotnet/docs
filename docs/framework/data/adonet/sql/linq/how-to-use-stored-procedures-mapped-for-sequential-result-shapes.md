---
description: "Learn more about: How to: Use Stored Procedures Mapped for Sequential Result Shapes"
title: "How to: Use Stored Procedures Mapped for Sequential Result Shapes"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: a73530de-5a4e-4d9c-8d66-abb19c225b11
---
# How to: Use Stored Procedures Mapped for Sequential Result Shapes

This kind of stored procedure can generate more than one result shape, but you know in what order the results are returned. Contrast this scenario with the scenario where you do not know the sequence of the returns. For more information, see [How to: Use Stored Procedures Mapped for Multiple Result Shapes](how-to-use-stored-procedures-mapped-for-multiple-result-shapes.md).  
  
## Example 1

 Here is the T-SQL of a stored procedure that returns multiple result shapes sequentially:  
  
```sql
CREATE PROCEDURE MultipleResultTypesSequentially  
AS  
select * from products  
select * from customers  
```  
  
 [!code-csharp[DLinqSprox#6](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSprox/cs/northwind-sprox.cs#6)]
 [!code-vb[DLinqSprox#6](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSprox/vb/northwind-sprox.vb#6)]  
  
## Example 2  

 You would use code similar to the following to execute this stored procedure.  
  
 [!code-csharp[DLinqSprox#7](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSprox/cs/Program.cs#7)]
 [!code-vb[DLinqSprox#7](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSprox/vb/Module1.vb#7)]  
  
## See also

- [Stored Procedures](stored-procedures.md)
