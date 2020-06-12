---
title: "Query Expressions (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: c36f327b-e230-48d4-bbd5-78dc6478c447
---
# Query Expressions (Entity SQL)
A query expression combines many different query operators into a single syntax. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides various kinds of expressions, including the following: [literals](literals-entity-sql.md), [parameters](parameters-entity-sql.md), [variables](variables-entity-sql.md), operators, [functions](functions-entity-sql.md), set operators, and so on. For more information, see [Entity SQL Reference](entity-sql-reference.md).  
  
## Clauses  
 A query expression is composed of a series of clauses that apply successive operations to a collection of objects. They are based on the same clauses found in standard a SQL select statement: [SELECT](select-entity-sql.md), [FROM](from-entity-sql.md), [WHERE](where-entity-sql.md), [GROUP BY](group-by-entity-sql.md), [HAVING](having-entity-sql.md), and [ORDER BY](order-by-entity-sql.md).  
  
## Scope  
 Names defined in the FROM clause are introduced into the FROM scope in order of appearance, left to right. In the JOIN list, expressions can refer to names defined earlier in the list. Public properties of elements identified in the FROM clause are not added to the FROM scope: They must be always referenced through the alias-qualified name. Normally, all parts of the select expression are considered within the FROM scope.  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
