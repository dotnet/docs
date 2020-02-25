---
title: "NAVIGATE (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: f107f29d-005f-4e39-a898-17f163abb1d0
---

# NAVIGATE (Entity SQL)

Navigates over the relationship established between entities.

## Syntax

```sql
navigate(instance-expression, [relationship-type], [to-end [, from-end] ])
```

## Arguments

`instance-expression`
An instance of an entity.

`relationship-type`
The type name of the relationship, from the conceptual schema definition language (CSDL) file. The `relationship-type` is qualified as \<namespace>.\<relationship type name>.

`to`
The end of the relationship.

`from`
The beginning of the relationship.

## Return Value

If the cardinality of the to end is 1, the return value will be `Ref<T>`. If the cardinality of the to end is n, the return value will be `Collection<Ref<T>>`.

## Remarks

Relationships are first-class constructs in the Entity Data Model (EDM). Relationships can be established between two or more entity types, and users can navigate over the relationship from one end (entity) to another. `from` and `to` are conditionally optional when there is no ambiguity in name resolution within the relationship.

NAVIGATE is valid in O and C space.

The general form of a navigation construct is the following:

navigate(`instance-expression`, `relationship-type`, [ `to-end` [, `from-end` ] ] )

For example:

```sql
Select o.Id, navigate(o, OrderCustomer, Customer, Order)
From LOB.Orders as o
```

Where OrderCustomer is the `relationship`, and Customer and Order are the `to-end` (customer) and `from-end` (order) of the relationship. If OrderCustomer was a n:1 relationship, then the result type of the navigate expression is Ref\<Customer>.

The simpler form of this expression is the following:

```sql
Select o.Id, navigate(o, OrderCustomer)
From LOB.Orders as o
```

Similarly, in a query of the following form, The navigate expression would produce a Collection<Ref\<Order>>.

```sql
Select c.Id, navigate(c, OrderCustomer, Order, Customer)
From LOB.Customers as c
```

The instance-expression must be an entity/ref type.

## Example

The following Entity SQL query uses the NAVIGATE operator to navigate over the relationship established between Address and SalesOrderHeader entity types. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts#NAVIGATE](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#navigate)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [How to: Navigate Relationships with Navigate Operator](navigate-entity-sql.md)
