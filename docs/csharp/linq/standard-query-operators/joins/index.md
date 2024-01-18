---
title: "Join Operations (C#)"
description: A join of two data sources associates objects with objects that share an attribute across data sources. Learn about join methods in the LINQ framework in C#.
ms.date: 01/22/2024
no-loc: [Join, GroupJoin]
---
# Join Operations (C#)

A *join* of two data sources is the association of objects in one data source with objects that share a common attribute in another data source.

Joining is an important operation in queries that target data sources whose relationships to each other cannot be followed directly. In object-oriented programming, this could mean a correlation between objects that is not modeled, such as the backwards direction of a one-way relationship. An example of a one-way relationship is a Customer class that has a property of type City, but the City class does not have a property that is a collection of Customer objects. If you have a list of City objects and you want to find all the customers in each city, you could use a join operation to find them.

The join methods provided in the LINQ framework are <xref:System.Linq.Enumerable.Join%2A> and <xref:System.Linq.Enumerable.GroupJoin%2A>. These methods perform equijoins, or joins that match two data sources based on equality of their keys. (For comparison, Transact-SQL supports join operators other than 'equals', for example the 'less than' operator.) In relational database terms, <xref:System.Linq.Enumerable.Join%2A> implements an inner join, a type of join in which only those objects that have a match in the other data set are returned. The <xref:System.Linq.Enumerable.GroupJoin%2A> method has no direct equivalent in relational database terms, but it implements a superset of inner joins and left outer joins. A left outer join is a join that returns each element of the first (left) data source, even if it has no correlated elements in the other data source.

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [the overview article](../index.md).

The following illustration shows a conceptual view of two sets and the elements within those sets that are included in either an inner join or a left outer join.

:::image type="content" source="./media/index/join-method-overlapping-circles.png" alt-text="Two overlapping circles showing inner&#47;outer.":::

## Methods

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|Join|Joins two sequences based on key selector functions and extracts pairs of values.|`join … in … on … equals …`|<xref:System.Linq.Enumerable.Join%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Join%2A?displayProperty=nameWithType>|
|GroupJoin|Joins two sequences based on key selector functions and groups the resulting matches for each element.|`join … in … on … equals … into …`|<xref:System.Linq.Enumerable.GroupJoin%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.GroupJoin%2A?displayProperty=nameWithType>|

### Join

The following example uses the `join … in … on … equals …` clause to join two sequences based on specific value:

:::code language="csharp" source="../snippets/standard-query-operators/JoinOverviewExamples.cs" id="JoinQuerySyntax":::

The preceding query can be expressed using method syntax as shown in the following code:

:::code language="csharp" source="../snippets/standard-query-operators/JoinOverviewExamples.cs" id="JoinMethodSyntax":::

### GroupJoin

The following example uses the `join … in … on … equals … into …` clause to join two sequences based on specific value and groups the resulting matches for each element:

:::code language="csharp" source="../snippets/standard-query-operators/JoinOverviewExamples.cs" id="GroupJoinQuerySyntax":::

The preceding query can be expressed using method syntax as shown in the following example:
  
:::code language="csharp" source="../snippets/standard-query-operators/JoinOverviewExamples.cs" id="GroupJoinMethodSyntax":::

## See also

- <xref:System.Linq>
- [Anonymous Types](../../../fundamentals/types/anonymous-types.md)
- [Formulate Joins and Cross-Product Queries](../../../../framework/data/adonet/sql/linq/formulate-joins-and-cross-product-queries.md)
- [join clause](../../../language-reference/keywords/join-clause.md)
- [Join by using composite keys](../../../linq/join-by-using-composite-keys.md)
- [How to join content from dissimilar files (LINQ) (C#)](../../../programming-guide/concepts/linq/how-to-join-content-from-dissimilar-files-linq.md)
- [How to populate object collections from multiple sources (LINQ) (C#)](../../../programming-guide/concepts/linq/how-to-populate-object-collections-from-multiple-sources-linq.md)
