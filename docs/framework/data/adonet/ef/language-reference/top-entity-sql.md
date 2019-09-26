---
title: "TOP (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 4a4a0954-82e2-4eae-bcaf-7c4552f3532d
---

# TOP (Entity SQL)

The SELECT clause can have an optional TOP sub-clause following the optional ALL/DISTINCT modifier. The TOP sub-clause specifies that only the first set of rows will be returned from the query result.

## Syntax

```sql
[ TOP (n) ]
```

## Arguments

`n`
The numeric expression that specifies the number of rows to be returned. `n` could be a single numeric literal or a single parameter.

## Remarks

The TOP expression must be either a single numeric literal or a single parameter. If a constant literal is used, the literal type must be implicitly promotable to Edm.Int64 (byte, int16, int32 or int64 or any provider type that maps to a type that is promotable to Edm.Int64) and its value must be greater than or equal to zero. Otherwise an exception will be raised. If a parameter is used as an expression, the parameter type must also be implicitly promotable to Edm.Int64, but there will be no validation of the actual parameter value during compilation because the parameter values are late bounded.

The following is an example of constant TOP expression:

```sql
select distinct top(10) c.a1, c.a2 from T as a
```

The following is an example of parameterized TOP expression:

```sql
select distinct top(@topParam) c.a1, c.a2 from T as a
```

TOP is non-deterministic unless the query is sorted. If you require a deterministic result, use the [SKIP](skip-entity-sql.md) and [LIMIT](limit-entity-sql.md) sub-clauses in the [ORDER BY](order-by-entity-sql.md) clause. The TOP and SKIP/LIMIT are mutually exclusive.

## Example

The following [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query uses the TOP to specify the top one row to be returned from the query result. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

    [!code-csharp[DP EntityServices Concepts 2#TOP](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#top)]

## See also

- [SELECT](select-entity-sql.md)
- [SKIP](skip-entity-sql.md)
- [LIMIT](limit-entity-sql.md)
- [ORDER BY](order-by-entity-sql.md)
- [Entity SQL Reference](entity-sql-reference.md)
