---
title: Perform grouped joins (LINQ in C#)
description: Learn how to perform grouped joins using LINQ in C#.
ms.date: 01/22/2024
---
# Perform grouped joins

The group join is useful for producing hierarchical data structures. It pairs each element from the first collection with a set of correlated elements from the second collection.

For example, a class or a relational database table named `Student` might contain two fields: `Id` and `Name`. A second class or relational database table named `Course` might contain two fields: `StudentId` and `CourseTitle`. A group join of these two data sources, based on matching `Student.Id` and `Course.StudentId`, would group each `Student` with a collection of `Course` objects (which might be empty).

> [!NOTE]
> Each element of the first collection appears in the result set of a group join regardless of whether correlated elements are found in the second collection. In the case where no correlated elements are found, the sequence of correlated elements for that element is empty. The result selector therefore has access to every element of the first collection. This differs from the result selector in a non-group join, which cannot access elements from the first collection that have no match in the second collection.

> [!WARNING]
> <xref:System.Linq.Enumerable.GroupJoin%2A?displayProperty=nameWithType> has no direct equivalent in traditional relational database terms. However, this method does implement a superset of inner joins and left outer joins. Both of these operations can be written in terms of a grouped join. For more information, see [Entity Framework Core, GroupJoin](/ef/core/querying/complex-query-operators#groupjoin).

The first example in this article shows you how to perform a group join. The second example shows you how to use a group join to create XML elements.

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [the overview article](../index.md).

## Group join

The following example performs a group join of objects of type `Person` and `Pet` based on the `Person` matching the `Pet.Owner` property. Unlike a non-group join, which would produce a pair of elements for each match, the group join produces only one resulting object for each element of the first collection, which in this example is a `Person` object. The corresponding elements from the second collection, which in this example are `Pet` objects, are grouped into a collection. Finally, the result selector function creates an anonymous type for each match that consists of `Person.FirstName` and a collection of `Pet` objects.

:::code language="csharp" source="../snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinQuery":::

In the above example, `query` variable contains the query that creates a list where each element is an anonymous type that contains the person's first name and a collection of pets that are owned by them.

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="../snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinMethod":::

## Example - Group join to create XML

Group joins are ideal for creating XML by using LINQ to XML. The following example is similar to the previous example except that instead of creating anonymous types, the result selector function creates XML elements that represent the joined objects.

:::code language="csharp" source="../snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinToXmlQuery":::

The equivalent query using method syntax is shown in the followingcode:

:::code language="csharp" source="../snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinToXmlMethod":::

## See also

- <xref:System.Linq.Enumerable.Join%2A>
- <xref:System.Linq.Enumerable.GroupJoin%2A>
- [Anonymous types](../../../fundamentals/types/anonymous-types.md)
