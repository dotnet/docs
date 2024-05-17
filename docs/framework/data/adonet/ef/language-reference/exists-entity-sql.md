---
description: "Learn more about: EXISTS (Entity SQL)"
title: "EXISTS (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: d28ead43-4afb-4bdc-af64-efd2e05005d7
---
# EXISTS (Entity SQL)

Determines if a collection is empty.

## Syntax

```sql
[NOT] EXISTS ( expression )
```

## Arguments

 `expression`
 Any valid expression that returns a collection.

 NOT
 Specifies that the result of EXISTS be negated.

## Return Value

 `true` if the collection is not empty; otherwise, `false`.

## Remarks

 EXISTS is one of the Entity SQL set operators. All Entity SQL set operators are evaluated from left to right. For precedence information for the Entity SQL set operators, see [EXCEPT](except-entity-sql.md).

## Example

 The following Entity SQL query uses the EXISTS operator to determine whether the collection is empty. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts#EXISTS](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#exists)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
