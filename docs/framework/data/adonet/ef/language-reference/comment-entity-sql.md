---
title: "-- (Comment) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 5d9de735-2099-47f1-b7e7-60856f494924
---
# -- (Comment) (Entity SQL)
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] queries can contain comments. Two dashes (`--`) start a comment line.  
  
## Syntax  
  
```  
-- text_of_comment  
```  
  
## Arguments  
 `text_of_comment`  
 Is the character string that contains the text of the comment.  
  
## Example  
 The following Entity SQL query demonstrates how to use comments. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#COMMENT](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#comment)]  
  
## See also

- [Entity SQL Overview](entity-sql-overview.md)
- [Entity SQL Reference](entity-sql-reference.md)
