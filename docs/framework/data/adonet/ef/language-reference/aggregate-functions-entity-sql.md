---
description: "Learn more about: Aggregate Functions (Entity SQL)"
title: "Aggregate Functions (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: acfd3149-f519-4c6e-8fe1-b21d243a0e58
---
# Aggregate Functions (Entity SQL)

An aggregate is a language construct that condenses a collection into a scalar as a part of a group operation. Entity SQL aggregates come in two forms:

- Entity SQL collection functions that may be used anywhere in an expression. This includes using aggregate functions in projections and predicates that act on collections. Collection functions are the preferred mode of specifying aggregates in Entity SQL.

- Group aggregates in query expressions that have a GROUP BY clause. As in Transact-SQL, group aggregates accept DISTINCT and ALL as modifiers to the aggregate input.

 Entity SQL first tries to interpret an expression as a collection function and if the expression is in the context of a SELECT expression it interprets it as a group aggregate.

 Entity SQL defines a special aggregate operator called [GROUPPARTITION](grouppartition-entity-sql.md). This operator enables you to get a reference to the grouped input set. This allows more advanced grouping queries, where the results of the GROUP BY clause can be used in places other than group aggregate or collection functions.

## Collection Functions

 Collection functions operate on collections and return a scalar value. For example, if `orders` is a collection of all `orders`, you can calculate the earliest ship date with the following expression:

 `min(select value o.ShipDate from LOB.Orders as o)`

## Group Aggregates

 Group aggregates are calculated over a group result as defined by the GROUP BY clause. The GROUP BY clause partitions data  into groups. For each group in the result, the aggregate function is applied and a separate aggregate is calculated by using the elements in each group as inputs to the aggregate calculation. When a GROUP BY clause is used in a SELECT expression, only grouping expression names, aggregates, or constant expressions may be present in the projection, HAVING, or ORDER BY clause.

 The following example calculates the average quantity ordered for each product.

 `select p, avg(ol.Quantity) from LOB.OrderLines as ol`

 `group by ol.Product as p`

 It is possible to have a group aggregate without an explicit GROUP BY clause in the SELECT expression. All elements will be treated as a single group, equivalent to the case of specifying a grouping based on a constant.

 `select avg(ol.Quantity) from LOB.OrderLines as ol`

 `select avg(ol.Quantity) from LOB.OrderLines as ol group by 1`

 Expressions used in the GROUP BY clause are evaluated by using the same name-resolution scope that would be visible to the WHERE clause expression.

## See also

- [Functions](functions-entity-sql.md)
