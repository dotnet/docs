---
description: "join clause - C# Reference"
title: "join clause"
ms.date: 01/21/2026
f1_keywords: 
  - "join"
  - "join_CSharpKeyword"
helpviewer_keywords: 
  - "join clause [C#]"
  - "join keyword [C#]"
---
# join clause (C# Reference)

Use the `join` clause to associate elements from different source sequences that have no direct relationship in the object model. The only requirement is that the elements in each source share some value that you can compare for equality. For example, a food distributor might have a list of suppliers of a certain product, and a list of buyers. You can use a `join` clause to create a list of the suppliers and buyers of that product who are all in the same specified region.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

A `join` clause takes two source sequences as input. The elements in each sequence must either be or contain a property that you can compare to a corresponding property in the other sequence. The `join` clause uses the special `equals` keyword to compare the specified keys for equality. All joins that the `join` clause performs are equijoins. The shape of the output of a `join` clause depends on the specific type of join you're performing. The following list shows the three most common join types:

- Inner join
- Group join
- Left outer join

## Inner join

The following example shows a simple inner equijoin. This query produces a flat sequence of "product name / category" pairs. The same category string appears in multiple elements. If an element from `categories` has no matching `products`, that category doesn't appear in the results.

:::code language="csharp" source="./snippets/join.cs" id="24":::

For more information, see [Perform inner joins](../../linq/standard-query-operators/join-operations.md).

## Group join

A `join` clause with an `into` expression is called a group join.

:::code language="csharp" source="./snippets/join.cs" id="25":::

A group join produces a hierarchical result sequence, which associates elements in the left source sequence with one or more matching elements in the right side source sequence. A group join has no equivalent in relational terms; it is essentially a sequence of object arrays.

If no elements from the right source sequence match an element in the left source, the `join` clause produces an empty array for that item. Therefore, the group join is still basically an inner-equijoin except that the result sequence is organized into groups.

If you just select the results of a group join, you can access the items, but you can't identify the key that they match on. Therefore, it's generally more useful to select the results of the group join into a new type that also has the key name, as shown in the previous example.

You can also, of course, use the result of a group join as the generator of another subquery:

:::code language="csharp" source="./snippets/join.cs" id="26":::

For more information, see [Perform grouped joins](../../linq/standard-query-operators/join-operations.md).

## Left outer join

In a left outer join, the query returns all the elements in the left source sequence, even if no matching elements are in the right sequence. To perform a left outer join in LINQ, use the `DefaultIfEmpty` method in combination with a group join to specify a default right-side element to produce if a left-side element has no matches. You can use `null` as the default value for any reference type, or you can specify a user-defined default type. In the following example, a user-defined default type is shown:

:::code language="csharp" source="./snippets/join.cs" id="27":::

For more information, see [Perform left outer joins](../../linq/standard-query-operators/join-operations.md).

## The equals operator

A `join` clause performs an equijoin. In other words, you can only base matches on the equality of two keys. Other types of comparisons such as "greater than" or "not equals" aren't supported. To make clear that all joins are equijoins, the `join` clause uses the `equals` keyword instead of the `==` operator. The `equals` keyword can only be used in a `join` clause and it differs from the `==` operator in some important ways. When comparing strings, `equals` has an overload to compare by value and the operator `==` uses reference equality. When both sides of comparison have identical string variables, `equals` and `==` reach the same result: true. That's because, when a program declares two or more equivalent string variables, the compiler stores all of them in the same location. This is known as *interning*. Another important difference is the null comparison: `null equals null` is evaluated as false with `equals` operator, instead of `==` operator that evaluates it as true. Lastly, the scoping behavior is different: with `equals`, the left key consumes the outer source sequence, and the right key consumes the inner source. The outer source is only in scope on the left side of `equals` and the inner source sequence is only in scope on the right side.

## Non-equijoins

You can perform non-equijoins, cross joins, and other custom join operations by using multiple `from` clauses to introduce new sequences independently into a query. For more information, see [Perform custom join operations](../../linq/index.md).

## Joins on object collections vs. relational tables

In a LINQ query expression, you perform join operations on object collections. You can't join object collections in exactly the same way as two relational tables. In LINQ, you only need explicit `join` clauses when two source sequences don't have any relationship. When you work with [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)], the object model represents foreign key tables as properties of the primary table. For example, in the Northwind database, the Customer table has a foreign key relationship with the Orders table. When you map the tables to the object model, the Customer class has an `Orders` property that contains the collection of `Orders` associated with that Customer. In effect, the join is already done for you.

For more information about querying across related tables in the context of [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)], see [How to: Map Database Relationships](../../../framework/data/adonet/sql/linq/how-to-map-database-relationships.md).

## Composite keys

You can test for equality of multiple values by using a composite key. For more information, see [Join by using composite keys](../../linq/standard-query-operators/join-operations.md). You can also use composite keys in a `group` clause.

## Example

The following example compares the results of an inner join, a group join, and a left outer join on the same data sources by using the same matching keys. Some extra code is added to these examples to clarify the results in the console display.

:::code language="csharp" source="./snippets/join.cs" id="23":::

## Remarks

A `join` clause that isn't followed by `into` translates into a <xref:System.Linq.Enumerable.Join%2A> method call. A `join` clause that is followed by `into` translates to a <xref:System.Linq.Enumerable.GroupJoin%2A> method call.

## See also

- [Query Keywords (LINQ)](query-keywords.md)
- [Language Integrated Query (LINQ)](../../linq/index.md)
- [Join Operations](../../linq/standard-query-operators/join-operations.md)
- [group clause](group-clause.md)
- [Perform left outer joins](../../linq/standard-query-operators/join-operations.md)
- [Perform inner joins](../../linq/standard-query-operators/join-operations.md)
- [Perform grouped joins](../../linq/standard-query-operators/join-operations.md)
- [Order the results of a join clause](../../linq/standard-query-operators/index.md)
- [Join by using composite keys](../../linq/standard-query-operators/join-operations.md)
- [Compatible database systems for Visual Studio](/visualstudio/data-tools/installing-database-systems-tools-and-samples)
