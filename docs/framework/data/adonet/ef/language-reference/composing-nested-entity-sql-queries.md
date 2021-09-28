---
description: "Learn more about: Composing Nested Entity SQL Queries"
title: "Composing Nested Entity SQL Queries"
ms.date: "03/30/2017"
ms.assetid: 685d4cd3-2c1f-419f-bb46-c9d97a351eeb
---
# Composing Nested Entity SQL Queries

Entity SQL is a rich functional language. The building block of Entity SQL is an expression. Unlike conventional SQL, Entity SQL is not limited to a tabular result set: Entity SQL supports composing complex expressions that can have literals, parameters, or nested expressions. A value in the expression can be parameterized or composed of some other expression.

## Nested Expressions

 A nested expression can be placed anywhere a value of the type it returns is accepted. For example:

```sql
-- Returns a hierarchical collection of three elements at top-level.
-- x must be passed in the parameter collection.
ROW(@x, {@x}, {@x, 4, 5}, {@x, 7, 8, 9})

-- Returns a hierarchical collection of one element at top-level.
-- x must be passed in the parameter collection.
{{{@x}}};
```

 A nested query can be placed in a projection clause. For example:

```sql
-- Returns a collection of rows where each row contains an Address entity.
-- and a collection of references to its corresponding SalesOrderHeader entities.
SELECT address, (SELECT DEREF(soh)
                    FROM NAVIGATE(address, AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) AS soh)
                    AS salesOrderHeader FROM AdventureWorksEntities.Address AS address
```

 In Entity SQL, nested queries must always be enclosed in parentheses:

```sql
-- Pseudo-Entity SQL
( SELECT …
FROM … )
UNION ALL
( SELECT …
FROM … );
```

 The following example demonstrates how to properly nest expressions in Entity SQL: [How to: Order the Union of Two Queries](/previous-versions/dotnet/netframework-4.0/bb896299(v=vs.100)).

## Nested Queries in Projection

 Nested queries in the project clause might get translated into Cartesian product queries on the server. In some backend servers, including SQL Server, this can cause the TempDB table to get very large, which can adversely affect server performance.

 The following is an example of such a query:

```sql
SELECT c, (SELECT c, (SELECT c FROM AdventureWorksModel.Vendor AS c  ) As Inner2 FROM AdventureWorksModel.JobCandidate AS c  ) As Inner1 FROM AdventureWorksModel.EmployeeDepartmentHistory AS c
```

## Ordering Nested Queries

 In the Entity Framework, a nested expression can be placed anywhere in the query. Because Entity SQL allows great flexibility in writing queries, it is possible to write a query that contains an ordering of nested queries. However, the order of a nested query is not preserved.

```sql
-- The following query will order the results by last name.
SELECT C1.FirstName, C1.LastName
        FROM AdventureWorksModel.Contact as C1
        ORDER BY C1.LastName
```

```sql
-- In the following query, ordering of the nested query is ignored.
SELECT C2.FirstName, C2.LastName
    FROM (SELECT C1.FirstName, C1.LastName
        FROM AdventureWorksModel.Contact as C1
        ORDER BY C1.LastName) as C2
```

## See also

- [Entity SQL Overview](entity-sql-overview.md)
