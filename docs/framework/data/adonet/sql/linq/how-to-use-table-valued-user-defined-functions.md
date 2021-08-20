---
title: "How to: Use Table-Valued User-Defined Functions"
description: Use these examples to learn how to create a table-valued function, which returns a single rowset. Use such a table-valued function just like a table. 
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 5a4ae2b4-3290-4aa1-bc95-fc70c51b54cf
---
# How to: Use Table-Valued User-Defined Functions

A table-valued function returns a single rowset (unlike stored procedures, which can return multiple result shapes). Because the return type of a table-valued function is `Table`, you can use a table-valued function anywhere in SQL that you can use a table. You can also treat the table-valued function just as you would a table.  
  
## Example 1

 The following SQL function explicitly states that it returns a `TABLE`. Therefore, the returned rowset structure is implicitly defined.  
  
```sql
CREATE FUNCTION ProductsCostingMoreThan(@cost money)  
RETURNS TABLE  
AS  
RETURN  
    SELECT ProductID, UnitPrice  
    FROM Products  
    WHERE UnitPrice > @cost  
```  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] maps the function as follows:  
  
 [!code-csharp[DLinqUDFS#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqUDFS/cs/northwind-tfunc.cs#1)]
 [!code-vb[DLinqUDFS#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqUDFS/vb/northwind-tfunc.vb#1)]  
  
## Example 2  

 The following SQL code shows that you can join to the table that the function returns and otherwise treat it as you would any other table:  
  
```sql
SELECT p2.ProductName, p1.UnitPrice  
FROM dbo.ProductsCostingMoreThan(80.50)  
AS p1 INNER JOIN Products AS p2 ON p1.ProductID = p2.ProductID  
```  
  
 In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], the query would be rendered as follows:  
  
 [!code-csharp[DLinqUDFS#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqUDFS/cs/Program.cs#2)]
 [!code-vb[DLinqUDFS#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqUDFS/vb/Module1.vb#2)]  
  
## See also

- [User-Defined Functions](user-defined-functions.md)
