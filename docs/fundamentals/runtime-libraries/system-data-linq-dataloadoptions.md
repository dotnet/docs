---
title: System.Data.Linq.DataLoadOptions class
description: Learn about the System.Data.Linq.DataLoadOptions class through these additional API remarks.
ms.date: 01/02/2024
---
# System.Data.Linq.DataLoadOptions class

[!INCLUDE [context](includes/context.md)]

The <Xref:System.Data.Linq.DataLoadOptions> class provides for immediate loading and filtering of related data.

When you query for an object, you actually retrieve only the object you requested. The *related* objects are not automatically fetched at the same time. (For more information, see [Querying Across Relationships](../../framework/data/adonet/sql/linq/querying-across-relationships.md).)

The <xref:System.Data.Linq.DataLoadOptions> class provides two methods to achieve immediate loading of specified related data. The <xref:System.Data.Linq.DataLoadOptions.LoadWith%2A> method allows for immediate loading of data related to the main target. The <xref:System.Data.Linq.DataLoadOptions.AssociateWith%2A> method allows for filtering related objects.

## Rules

Note the following rules regarding <xref:System.Data.Linq.DataLoadOptions> usage:

- Assigning a <xref:System.Data.Linq.DataLoadOptions> to a <xref:System.Data.Linq.DataContext> after the first query has been executed generates an exception.
- Modifying a <xref:System.Data.Linq.DataLoadOptions> after it has been assigned to a <xref:System.Data.Linq.DataContext> generates an exception.

## Handle cycles

<xref:System.Data.Linq.DataLoadOptions.LoadWith%2A> and <xref:System.Data.Linq.DataLoadOptions.AssociateWith%2A> directives must not create cycles. The following represent examples of such graphs:

- Example 1: Self recursive

  - `dlo.LoadWith<Employee>(e => e.Reports);`

- Example 2: Back-pointers

  - `dlo.LoadWith <Customer>(c => C.Orders);`
  - `dlo.LoadWith <Order>(o => o.Customer);`

- Example 3: Longer cycles

  Although this should not occur in a well-normalized model, it is possible.

  - `dlo.LoadWith <A>(a => a.Bs);`
  - `dlo.LoadWith <B>(b => b.Cs);`
  - `dlo.LoadWith <C>(c => c.As);`

- Example 4: Self recursive subQueries

  - `dlo.AssociateWith<A>(a=>a.As.Where(a=>a.Id=33));`

- Example 5: Longer recursive subqueries

  - `dlo.AssociateWith<A>(a=>a.Bs.Where(b=>b.Id==3));`

  - `dlo.AssociateWith<B>(b=>b.As.Where(a=>a.Id==3));`

The following general rules help you understand what occurs in these scenarios:

- <xref:System.Data.Linq.DataLoadOptions.LoadWith%2A>&mdash;Each call to <xref:System.Data.Linq.DataLoadOptions.LoadWith%2A> checks whether cycles have been introduced into the graph. If there are, as in Examples 1, 2, and 3, an exception is thrown.

- <xref:System.Data.Linq.DataLoadOptions.AssociateWith%2A>&mdash;At run time, the engine doesn't apply the existing SubQuery clauses to the relationship inside the expression.

  - In Example 4, the `Where` clause is executed against all `A`, not just the ones sub-filtered by the SubQuery expression itself (because that would be recursive).
  - In Example 5, the first `Where` clause is applied to all the `B`s, even though there are subqueries on `B`. The second `Where` clause is applied to all the `A`s even though there are subqueries on `A`.

## Examples

When you retrieve `Customers` from the Northwind sample database, you can use <xref:System.Data.Linq.DataLoadOptions> to specify that `Orders` is also to be retrieved. You can even specify which subset of `Orders` to retrieve.
