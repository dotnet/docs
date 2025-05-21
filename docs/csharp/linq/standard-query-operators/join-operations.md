---
title: "Join Operations"
description: A join of two data sources associates objects with objects that share an attribute across data sources. Learn about join methods in the LINQ framework in C#.
ms.date: 05/29/2024
no-loc: [Join, GroupJoin]
ms.topic: article
---
# Join Operations in LINQ

A *join* of two data sources is the association of objects in one data source with objects that share a common attribute in another data source.

[!INCLUDE [Prerequisites](../includes/linq-syntax.md)]

Joining is an important operation in queries that target data sources whose relationships to each other can't be followed directly. In object-oriented programming, joining could mean a correlation between objects that isn't modeled, such as the backwards direction of a one-way relationship. An example of a one-way relationship is a `Student` class that has a property of type `Department` that represents the major, but the `Department` class doesn't have a property that is a collection of `Student` objects. If you have a list of `Department` objects and you want to find all the students in each department, you could use a join operation to find them.

The join methods provided in the LINQ framework are <xref:System.Linq.Enumerable.Join%2A> and <xref:System.Linq.Enumerable.GroupJoin%2A>. These methods perform equijoins, or joins that match two data sources based on equality of their keys. (For comparison, Transact-SQL supports join operators other than `equals`, for example the `less than` operator.) In relational database terms, <xref:System.Linq.Enumerable.Join%2A> implements an inner join, a type of join in which only those objects that have a match in the other data set are returned. The <xref:System.Linq.Enumerable.GroupJoin%2A> method has no direct equivalent in relational database terms, but it implements a superset of inner joins and left outer joins. A left outer join is a join that returns each element of the first (left) data source, even if it has no correlated elements in the other data source.

The following illustration shows a conceptual view of two sets and the elements within those sets that are included in either an inner join or a left outer join.

:::image type="content" source="./media/join-operations/join-method-overlapping-circles.png" alt-text="Two overlapping circles showing inner&#47;outer.":::

## Methods

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|Join|Joins two sequences based on key selector functions and extracts pairs of values.|`join … in … on … equals …`|<xref:System.Linq.Enumerable.Join%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Join%2A?displayProperty=nameWithType>|
|GroupJoin|Joins two sequences based on key selector functions and groups the resulting matches for each element.|`join … in … on … equals … into …`|<xref:System.Linq.Enumerable.GroupJoin%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.GroupJoin%2A?displayProperty=nameWithType>|

[!INCLUDE [Datasources](../includes/data-sources-definition.md)]

The following example uses the `join … in … on … equals …` clause to join two sequences based on specific value:

:::code language="csharp" source="./snippets/standard-query-operators/JoinOverviewExamples.cs" id="JoinQuerySyntax":::

The preceding query can be expressed using method syntax as shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/JoinOverviewExamples.cs" id="JoinMethodSyntax":::

The following example uses the `join … in … on … equals … into …` clause to join two sequences based on specific value and groups the resulting matches for each element:

:::code language="csharp" source="./snippets/standard-query-operators/JoinOverviewExamples.cs" id="GroupJoinQuerySyntax":::

The preceding query can be expressed using method syntax as shown in the following example:
  
:::code language="csharp" source="./snippets/standard-query-operators/JoinOverviewExamples.cs" id="GroupJoinMethodSyntax":::

## Perform inner joins

In relational database terms, an *inner join* produces a result set in which each element of the first collection appears one time for every matching element in the second collection. If an element in the first collection has no matching elements, it doesn't appear in the result set. The <xref:System.Linq.Enumerable.Join%2A> method, which is called by the `join` clause in C#, implements an inner join. The following examples show you how to perform four variations of an inner join:

- A simple inner join that correlates elements from two data sources based on a simple key.
- An inner join that correlates elements from two data sources based on a *composite* key. A composite key, which is a key that consists of more than one value, enables you to correlate elements based on more than one property.
- A *multiple join* in which successive join operations are appended to each other.
- An inner join that is implemented by using a group join.

### Single key join

The following example matches `Teacher` objects with `Department` objects whose `TeacherId` matches that `Teacher`. The `select` clause in C# defines how the resulting objects look. In the following example, the resulting objects are anonymous types that consist of the department name and the name of the teacher that leads the department.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="SimpleInnerJoinQuery":::

You achieve the same results using the <xref:System.Linq.Enumerable.Join%2A> method syntax:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="SimpleInnerJoinMethod":::

The teachers who aren't department heads don't appear in the final results.

### Composite key join

Instead of correlating elements based on just one property, you can use a composite key to compare elements based on multiple properties. Specify the key selector function for each collection to return an anonymous type that consists of the properties you want to compare. If you label the properties, they must have the same label in each key's anonymous type. The properties must also appear in the same order.

The following example uses a list of `Teacher` objects and a list of `Student` objects to determine which teachers are also students. Both of these types have properties that represent the first and family name of each person. The functions that create the join keys from each list's elements return an anonymous type that consists of the properties. The join operation compares these composite keys for equality and returns pairs of objects from each list where both the first name and the family name match.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="CompositeKeyQuery":::

You can use the <xref:System.Linq.Enumerable.Join%2A> method, as shown in the following example:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="CompositeKeyMethod":::

### Multiple join

Any number of join operations can be appended to each other to perform a multiple join. Each `join` clause in C# correlates a specified data source with the results of the previous join.

The first `join` clause matches students and departments based on a `Student` object's `DepartmentID` matching a `Department` object's `ID`. It returns a sequence of anonymous types that contain the `Student` object and `Department` object.

The second `join` clause correlates the anonymous types returned by the first join with `Teacher` objects based on that teacher's ID matching the department head ID. It returns a sequence of anonymous types that contain the student's name, the department name, and the department leader's name. Because this operation is an inner join, only those objects from the first data source that have a match in the second data source are returned.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="MultipleJoinQuery":::

The equivalent using multiple <xref:System.Linq.Enumerable.Join%2A> method uses the same approach with the anonymous type:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="MultipleJoinMethod":::

### Inner join by using grouped join

The following example shows you how to implement an inner join by using a group join. The list of `Department` objects is group-joined to the list of `Student` objects based on the `Department.ID` matching the `Student.DepartmentID` property. The group join creates a collection of intermediate groups, where each group consists of a `Department` object and a sequence of matching `Student` objects. The second `from` clause combines (or flattens) this sequence of sequences into one longer sequence. The `select` clause specifies the type of elements in the final sequence. That type is an anonymous type that consists of the student's name and the matching department name.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="InnerGroupJoinQuery":::

The same results can be achieved using <xref:System.Linq.Enumerable.GroupJoin%2A> method, as follows:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="InnerGroupJoinMethod":::

The result is equivalent to the result set obtained by using the `join` clause without the `into` clause to perform an inner join. The following code demonstrates this equivalent query:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="InnerJoinQuery":::

To avoid chaining, the single <xref:System.Linq.Enumerable.Join%2A> method can be used as presented here:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="InnerJoinMethod":::

## Perform grouped joins

The group join is useful for producing hierarchical data structures. It pairs each element from the first collection with a set of correlated elements from the second collection.

> [!NOTE]
> Each element of the first collection appears in the result set of a group join regardless of whether correlated elements are found in the second collection. In the case where no correlated elements are found, the sequence of correlated elements for that element is empty. The result selector therefore has access to every element of the first collection. This differs from the result selector in a non-group join, which cannot access elements from the first collection that have no match in the second collection.

> [!WARNING]
> <xref:System.Linq.Enumerable.GroupJoin%2A?displayProperty=nameWithType> has no direct equivalent in traditional relational database terms. However, this method does implement a superset of inner joins and left outer joins. Both of these operations can be written in terms of a grouped join. For more information, see [Entity Framework Core, GroupJoin](/ef/core/querying/complex-query-operators#groupjoin).

The first example in this article shows you how to perform a group join. The second example shows you how to use a group join to create XML elements.

### Group join

The following example performs a group join of objects of type `Department` and `Student` based on the `Department.ID` matching the `Student.DepartmentID` property. Unlike a non-group join, which produces a pair of elements for each match, the group join produces only one resulting object for each element of the first collection, which in this example is a `Department` object. The corresponding elements from the second collection, which in this example are `Student` objects, are grouped into a collection. Finally, the result selector function creates an anonymous type for each match that consists of `Department.Name` and a collection of `Student` objects.

:::code language="csharp" source="./snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinQuery":::

In the above example, `query` variable contains the query that creates a list where each element is an anonymous type that contains the department's name and a collection of students that study in that department.

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinMethod":::

### Group join to create XML

Group joins are ideal for creating XML by using LINQ to XML. The following example is similar to the previous example except that instead of creating anonymous types, the result selector function creates XML elements that represent the joined objects.

:::code language="csharp" source="./snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinToXmlQuery":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinToXmlMethod":::

## Perform left outer joins

A left outer join is a join in which each element of the first collection is returned, regardless of whether it has any correlated elements in the second collection. You can use LINQ to perform a left outer join by calling the <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> method on the results of a group join.

The following example demonstrates how to use the <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> method on the results of a group join to perform a left outer join.

The first step in producing a left outer join of two collections is to perform an inner join by using a group join. (See [Perform inner joins](#perform-inner-joins) for an explanation of this process.) In this example, the list of `Department` objects is inner-joined to the list of `Student` objects based on a `Department` object's ID that matches the student's `DepartmentID`.

The second step is to include each element of the first (left) collection in the result set even if that element has no matches in the right collection. This is accomplished by calling <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> on each sequence of matching elements from the group join. In this example, <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> is called on each sequence of matching `Student` objects. The method returns a collection that contains a single, default value if the sequence of matching `Student` objects is empty for any `Department` object, ensuring that each `Department` object is represented in the result collection.

> [!NOTE]
> The default value for a reference type is `null`; therefore, the example checks for a null reference before accessing each element of each `Student` collection.

:::code source="./snippets/standard-query-operators/LeftOuterJoins.cs" id="LeftOuterJoinQuery":::

The equivalent query using method syntax is shown in the following code:

:::code source="./snippets/standard-query-operators/LeftOuterJoins.cs" id="LeftOuterJoinMethod":::

## See also

- <xref:System.Linq.Enumerable.Join%2A>
- <xref:System.Linq.Enumerable.GroupJoin%2A>
- [Anonymous types](../../fundamentals/types/anonymous-types.md)
- [Formulate Joins and Cross-Product Queries](../../../framework/data/adonet/sql/linq/formulate-joins-and-cross-product-queries.md)
- [join clause](../../language-reference/keywords/join-clause.md)
- [group clause](../../language-reference/keywords/group-clause.md)
- [How to join content from dissimilar files (LINQ) (C#)](../how-to-query-files-and-directories.md)
- [How to populate object collections from multiple sources (LINQ) (C#)](../how-to-query-collections.md)
