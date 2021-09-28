---
description: "Learn more about: SKIP (Entity SQL)"
title: "SKIP (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: e2139412-8ea4-451b-8f10-91af18dfa3ec
---
# SKIP (Entity SQL)

You can perform physical paging by using the SKIP sub-clause in the ORDER BY clause. SKIP cannot be used separately from the ORDER BY clause.

## Syntax

```sql
[ SKIP n ]
```

## Arguments

`n` \
The number of items to skip.

## Remarks

If a SKIP expression sub-clause is present in an ORDER BY clause, the results will be sorted according the sort specification and the result set will include rows starting from the next row immediately after the SKIP expression. For example, SKIP 5 will skip the first five rows and return from the sixth row forward.

> [!NOTE]
> An Entity SQL query is invalid if both the TOP modifier and the SKIP sub-clause are present in the same query expression. The query should be rewritten by changing the TOP expression to the LIMIT expression.

> [!NOTE]
> In SQL Server 2000, using SKIP with ORDER BY on non-key columns might return incorrect results. More than the specified number of rows might be skipped if the non-key column has duplicate data in it. This is due to how SKIP is translated for SQL Server 2000. For example, in the following code more than five rows might be skipped if `E.NonKeyColumn` has duplicate values:
>
> ```sql
> SELECT [E] FROM Container.EntitySet AS [E] ORDER BY [E].[NonKeyColumn] DESC SKIP 5L
> ```

The Entity SQL query in [How to: Page Through Query Results](/previous-versions/dotnet/netframework-4.0/bb738702(v=vs.100)) uses the ORDER BY operator with SKIP to specify the sort order used on objects returned in a SELECT statement.

## See also

- [ORDER BY](order-by-entity-sql.md)
- [How to: Page Through Query Results](/previous-versions/dotnet/netframework-4.0/bb738702(v=vs.100))
- [Paging](paging-entity-sql.md)
- [TOP](top-entity-sql.md)
