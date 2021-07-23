---
description: "Learn more about: ISNULL (Entity SQL)"
title: "ISNULL (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: dc7a0173-3664-4c90-a57b-5cbb0a8ed7ee
---
# ISNULL (Entity SQL)

Determines if a query expression is null.

## Syntax

```sql
expression IS [ NOT ] NULL
```

## Arguments

 `expression`
 Any valid query expression. Cannot be a collection, have collection members, or a record type with collection type properties.

 NOT
 Negates the EDM.Boolean result of IS NULL.

## Return Value

 `true` if `expression` returns null; otherwise, `false`.

## Remarks

 Use `IS NULL` to determine if the element of an outer join is null:

```sql
select c
      from LOB.Customers as c left outer join LOB.Orders as o
                              on c.ID = o.CustomerID
      where o is not null and o.OrderQuantity = @x
```

 Use `IS NULL` to determine if a member has an actual value:

```sql
select c from LOB.Customer as c where c.DOB is not null
```

 The following table shows the behavior of `IS NULL` over some patterns. All exceptions are thrown from the client side before the provider gets invoked:

|Pattern|Behavior|
|-------------|--------------|
|null IS NULL|Returns `true`.|
|TREAT (null AS EntityType) IS NULL|Returns `true`.|
|TREAT (null AS ComplexType) IS NULL|Throws an error.|
|TREAT (null AS RowType) IS NULL|Throws an error.|
|EntityType IS NULL|Returns `true` or `false`.|
|ComplexType IS NULL|Throws an error.|
|RowType IS NULL|Throws an error.|

## Example

 The following Entity SQL query uses the IS NOT NULL operator to determine if a query expression is not null. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts#ISNULL](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#isnull)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
