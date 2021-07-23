---
description: "Learn more about: ORDER BY (Entity SQL)"
title: "ORDER BY (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: c0b61572-ecee-41eb-9d7f-74132ec8a26c
---
# ORDER BY (Entity SQL)

Specifies the sort order used on objects returned in a SELECT statement.

## Syntax

```sql
[ ORDER BY
   {
      order_by_expression [SKIP n] [LIMIT n]
      [ COLLATE collation_name ]
      [ ASC | DESC ]
   }
   [ ,…n ]
]
```

## Arguments

 `order_by_expression`
 Any valid query expression specifying a property on which to sort. Multiple sort expressions can be specified. The sequence of the sort expressions in the ORDER BY clause defines the organization of the sorted result set.

 COLLATE {collation_name}
 Specifies that the ORDER BY operation should be performed according to the collation specified in `collation_name`. COLLATE is applicable only for string expressions.

 ASC
 Specifies that the values in the specified property should be sorted in ascending order, from lowest value to highest value. This is the default.

 DESC
 Specifies that the values in the specified property should be sorted in descending order, from highest value to lowest value.

 LIMIT `n`
 Only the first `n` items will be selected.

 SKIP `n`
 Skips the first `n` items.

## Remarks

 The ORDER BY clause is logically applied to the result of the SELECT clause. The ORDER BY clause can reference items in the select list by using their aliases. The ORDER BY clause can also reference other variables that are currently in-scope. However, if the SELECT clause has been specified with a DISTINCT modifier, the ORDER BY clause can only reference aliases from the SELECT clause.

 `SELECT c AS c1 FROM cs AS c ORDER BY c1.e1, c.e2`

 Each expression in the ORDER BY clause must evaluate to some type that can be compared for ordered inequality (less than or greater than, and so on). These types are generally scalar primitives such as numbers, strings, and dates. RowTypes of comparable types are also order comparable.

 If your code iterates over an ordered set, other than for a top-level projection, the output is not guaranteed to have its order preserved.

In the following sample, order is guaranteed to be preserved:

```sql
SELECT C1.FirstName, C1.LastName
        FROM AdventureWorks.Contact as C1
        ORDER BY C1.LastName
```

In the following query, ordering of the nested query is ignored:

```sql
SELECT C2.FirstName, C2.LastName
    FROM (SELECT C1.FirstName, C1.LastName
        FROM AdventureWorks.Contact as C1
        ORDER BY C1.LastName) as C2
```

 To have an ordered UNION, UNION ALL, EXCEPT, or INTERSECT operation, use the following pattern:

```sql
SELECT ...
FROM ( UNION/EXCEPT/INTERSECT operation )
ORDER BY ...
```

## Restricted keywords

 The following keywords must be enclosed in quotation marks when used in an `ORDER BY` clause:

- CROSS

- FULL

- KEY

- LEFT

- ORDER

- OUTER

- RIGHT

- ROW

- VALUE

## Ordering Nested Queries

 In the Entity Framework, a nested expression can be placed anywhere in the query; the order of a nested query is not preserved.

The following query will order the results by the last name:

```sql
SELECT C1.FirstName, C1.LastName
        FROM AdventureWorks.Contact as C1
        ORDER BY C1.LastName
```

In the following query, ordering of the nested query is ignored:

```sql
SELECT C2.FirstName, C2.LastName
    FROM (SELECT C1.FirstName, C1.LastName
        FROM AdventureWorks.Contact as C1
        ORDER BY C1.LastName) as C2
```

## Example

 The following Entity SQL query uses the ORDER BY operator to specify the sort order used on objects returned in a SELECT statement. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts#ORDERBY](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#orderby)]

## See also

- [Query Expressions](query-expressions-entity-sql.md)
- [Entity SQL Reference](entity-sql-reference.md)
- [SKIP](skip-entity-sql.md)
- [LIMIT](limit-entity-sql.md)
- [TOP](top-entity-sql.md)
