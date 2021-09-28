---
description: "Learn more about: DEREF (Entity SQL)"
title: "DEREF (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 4c78e833-b260-453d-9bf4-eb39857dd0fa
---
# DEREF (Entity SQL)

Dereferences a reference value and produces the result of that dereference.

## Syntax

```sql
SELECT DEREF ( o.expression ) FROM Table AS o;
```

## Arguments

 `expression`
 Any valid query expression that returns a collection.

## Return Value

 The value of the entity that is referenced.

## Remarks

 The DEREF operator dereferences a reference value and produces the result of that dereference. For example, if `r` is a reference of type ref\<T>, `Deref(r)` is an expression of type `T` that yields the entity referenced by `r`. If the reference value is null, or is dangling (that is, the target of the reference does not exist), the result of the DEREF operator is null.

## Example

 The following Entity SQL query uses the DEREF operator to dereference a reference value and produce the result of that dereference. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../how-to-execute-a-query-that-returns-primitivetype-results.md).

2. Pass the following query as an argument to the ExecutePrimitiveTypeQuery method:

 [!code-sql[DP EntityServices Concepts#DEREF](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#deref)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [REF](ref-entity-sql.md)
- [CREATEREF](createref-entity-sql.md)
- [KEY](key-entity-sql.md)
- [Nullable Structured Types](nullable-structured-types-entity-sql.md)
