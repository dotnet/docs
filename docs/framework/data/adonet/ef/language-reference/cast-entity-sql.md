---
description: "Learn more about: CAST (Entity SQL)"
title: "CAST (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 07b6d750-dfd4-48a9-b86c-3badcbba6f70
---
# CAST (Entity SQL)

Converts an expression of one data type to another.

## Syntax

```csharp
CAST ( expression AS data_type )
```

## Arguments

 `expression`
 Any valid expression that is convertible to `data_type`.

 `data_type`
 The target system-supplied data type. It must be a primitive (scalar) type. The `data_type` used depends on the query space. If a query is executed with the <xref:System.Data.EntityClient.EntityCommand>, the data type is a type defined in the conceptual model. For more information, see [CSDL Specification](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec). If a query is executed with <xref:System.Data.Objects.ObjectQuery%601>, the data type is a common language runtime (CLR) type.

## Return Value

 Returns the same value as `data_type`.

## Remarks

 The cast expression has similar semantics to the Transact-SQL CONVERT expression. The cast expression is used to convert a value of one type into a value of another type.

```csharp
CAST( e as T )
```

 If e is of some type S, and S is convertible to T, then the above expression is a valid cast expression. T must be a primitive (scalar) type.

 Values for the precision and scale facets may optionally be provided when casting to `Edm.Decimal`. If not explicitly provided, the default values for precision and scale are 18 and 0, respectively. Specifically, the following overloads are supported for `Decimal`:

- `CAST( d as Edm.Decimal );`

- `CAST( d as Edm.Decimal(precision) );`

- `CAST( d as Edm.Decimal(precision, scale) );`

 The use of a cast expression is considered an explicit conversion. Explicit conversions might truncate data or lose precision.

> [!NOTE]
> CAST is only supported over primitive types and enumeration member types.

## Example

 The following Entity SQL query uses the CAST operator to cast an expression of one data type to another. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../how-to-execute-a-query-that-returns-primitivetype-results.md).

2. Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:

 [!code-csharp[DP EntityServices Concepts 2#CAST](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#cast)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
