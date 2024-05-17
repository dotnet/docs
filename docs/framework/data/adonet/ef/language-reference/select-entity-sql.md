---
description: "Learn more about: SELECT (Entity SQL)"
title: "SELECT (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 9a33bd0d-ded1-41e7-ba3c-305502755e3b
---
# SELECT (Entity SQL)

Specifies the elements returned by a query.

## Syntax

```sql
SELECT [ ALL | DISTINCT ] [ topSubclause ] aliasedExpr
      [{ , aliasedExpr }] FROM fromClause [ WHERE whereClause ] [ GROUP BY groupByClause [ HAVING havingClause ] ] [ ORDER BY orderByClause ]
-- or
SELECT VALUE [ ALL | DISTINCT ] [ topSubclause ] expr FROM fromClause [ WHERE whereClause ] [ GROUP BY groupByClause [ HAVING havingClause ] ] [ ORDER BY orderByClause
```

## Arguments

 ALL
 Specifies that duplicates can appear in the result set. ALL is the default.

 DISTINCT
 Specifies that only unique results can appear in the result set.

 VALUE
 Allows only one item to be specified, and does not add on a row wrapper.

 `topSubclause`
 Any valid expression that indicates the number of first results to return from the query, of the form `top(expr)`.

 The LIMIT parameter of the [ORDER BY](order-by-entity-sql.md) operator also lets you select the first n items in the result set.

 `aliasedExpr`
 An expression of the form:

 `expr` as `identifier` &#124; `expr`

 `expr`
 A literal or expression.

## Remarks

 The SELECT clause is evaluated after the [FROM](from-entity-sql.md), [GROUP BY](group-by-entity-sql.md), and [HAVING](having-entity-sql.md) clauses have been evaluated. The SELECT clause can only refer to items currently in-scope (from the FROM clause, or from outer scopes). If a GROUP BY clause has been specified, the SELECT clause is only allowed to reference the aliases for the GROUP BY keys. Referring to the FROM clause items is only permitted in aggregate functions.

 The list of one or more query expressions following the SELECT keyword is known as the select list, or more formally as the projection. The most general form of projection is a single query expression. If you select a member `member1` from a collection `collection1`, you will produce a new collection of all the `member1` values for each object in `collection1`, as illustrated in the following example.

```sql
SELECT collection1.member1 FROM collection1
```

 For example, if `customers` is a collection of type `Customer` that has a property `Name` that is of type `string`, selecting `Name` from `customers` will yield a collection of strings, as illustrated in the following example.

```sql
SELECT customers.Name FROM customers AS c
```

 It is also possible to use JOIN syntax (FULL, INNER, LEFT, OUTER, ON, and RIGHT). ON is required for inner joins and is nto allowed for cross joins.

## Row and Value Select Clauses

 Entity SQL supports two variants of the SELECT clause. The first variant, row select, is identified by the SELECT keyword, and can be used to specify one or more values that should be projected out. Because a row wrapper is implicitly added around the values returned, the result of the query expression is always a multiset of rows.

 Each query expression in a row select must specify an alias. If no alias is specified,Entity SQL attempts to generate an alias by using the alias generation rules.

 The other variant of the SELECT clause, value select, is identified by the SELECT VALUE keyword. It allows only one value to be specified, and does not add a row wrapper.

 A row select is always expressible in terms of VALUE SELECT, as illustrated in the following example.

```sql
SELECT 1 AS a, "abc" AS b FROM C
SELECT VALUE ROW(1 AS a, "abc" AS b) FROM C
```

## All and Distinct Modifiers

 Both variants of SELECT in Entity SQL allow the specification of an ALL or DISTINCT modifier. If the DISTINCT modifier is specified, duplicates are eliminated from the collection produced by the query expression (up to and including the SELECT clause). If the ALL modifier is specified, no duplicate elimination is performed; ALL is the default.

## Differences from Transact-SQL

 Unlike Transact-SQL, Entity SQL does not support use of the * argument in the SELECT clause.  Instead, Entity SQL allows queries to project out entire records by referencing the collection aliases from the FROM clause, as illustrated in the following example.

```sql
SELECT * FROM T1, T2
```

 The previous Transact-SQL query expression is expressed in Entity SQL in the following way.

```sql
SELECT a1, a2 FROM T1 AS a1, T2 AS a2
```

## Example

 The following Entity SQL query uses the SELECT operator to specify the elements to be returned by a query. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts#LESS](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#less)]

## See also

- [Query Expressions](query-expressions-entity-sql.md)
- [Entity SQL Reference](entity-sql-reference.md)
- [TOP](top-entity-sql.md)
