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

:::image type="content" source="./media/join-operations/join-method-overlapping-circles.png" alt-text="Two overlapping circles showing inner&#47;outer.":::

## Methods

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|Join|Joins two sequences based on key selector functions and extracts pairs of values.|`join … in … on … equals …`|<xref:System.Linq.Enumerable.Join%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Join%2A?displayProperty=nameWithType>|
|GroupJoin|Joins two sequences based on key selector functions and groups the resulting matches for each element.|`join … in … on … equals … into …`|<xref:System.Linq.Enumerable.GroupJoin%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.GroupJoin%2A?displayProperty=nameWithType>|

### Join

The following example uses the `join … in … on … equals …` clause to join two sequences based on specific value:

:::code language="csharp" source="./snippets/standard-query-operators/JoinOverviewExamples.cs" id="JoinQuerySyntax":::

The preceding query can be expressed using method syntax as shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/JoinOverviewExamples.cs" id="JoinMethodSyntax":::

### GroupJoin

The following example uses the `join … in … on … equals … into …` clause to join two sequences based on specific value and groups the resulting matches for each element:

:::code language="csharp" source="./snippets/standard-query-operators/JoinOverviewExamples.cs" id="GroupJoinQuerySyntax":::

The preceding query can be expressed using method syntax as shown in the following example:
  
:::code language="csharp" source="./snippets/standard-query-operators/JoinOverviewExamples.cs" id="GroupJoinMethodSyntax":::

## Perform inner joins

In relational database terms, an *inner join* produces a result set in which each element of the first collection appears one time for every matching element in the second collection. If an element in the first collection has no matching elements, it doesn't appear in the result set. The <xref:System.Linq.Enumerable.Join%2A> method, which is called by the `join` clause in C#, implements an inner join.

This article shows you how to perform four variations of an inner join:

- A simple inner join that correlates elements from two data sources based on a simple key.
- An inner join that correlates elements from two data sources based on a *composite* key. A composite key, which is a key that consists of more than one value, enables you to correlate elements based on more than one property.
- A *multiple join* in which successive join operations are appended to each other.
- An inner join that is implemented by using a group join.

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [the overview article](../index.md).

### Simple key join

The following example creates two collections that contain objects of two user-defined types, `Person` and `Pet`. The query uses the `join` clause in C# to match `Person` objects with `Pet` objects whose `Owner` is that `Person`. The `select` clause in C# defines how the resulting objects will look. In this example, the resulting objects are anonymous types that consist of the owner's first name and the pet's name.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="SimpleInnerJoinQuery":::

You achieve the same results using the <xref:System.Linq.Enumerable.Join%2A> method syntax:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="SimpleInnerJoinMethod":::

The `Person` object whose `LastName` is "Huff" doesn't appear in the result set because there's no `Pet` object that has `Pet.Owner` equal to that `Person`.

### Composite key join

Instead of correlating elements based on just one property, you can use a composite key to compare elements based on multiple properties. To do this, specify the key selector function for each collection to return an anonymous type that consists of the properties you want to compare. If you label the properties, they must have the same label in each key's anonymous type. The properties must also appear in the same order.

The following example uses a list of `Employee` objects and a list of `Student` objects to determine which employees are also students. Both of these types have a `FirstName` and a `LastName` property of type <xref:System.String>. The functions that create the join keys from each list's elements return an anonymous type that consists of the `FirstName` and `LastName` properties of each element. The join operation compares these composite keys for equality and returns pairs of objects from each list where both the first name and the last name match.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="CompositeKeyQuery":::

You can use the <xref:System.Linq.Enumerable.Join%2A> method, as shown in the following example:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="CompositeKeyMethod":::

### Multiple join

Any number of join operations can be appended to each other to perform a multiple join. Each `join` clause in C# correlates a specified data source with the results of the previous join.

The following example creates three collections: a list of `Person` objects, a list of `Cat` objects, and a list of `Dog` objects.

The first `join` clause in C# matches people and cats based on a `Person` object matching `Cat.Owner`. It returns a sequence of anonymous types that contain the `Person` object and `Cat.Name`.

The second `join` clause in C# correlates the anonymous types returned by the first join with `Dog` objects in the supplied list of dogs, based on a composite key that consists of the `Owner` property of type `Person`, and the first letter of the animal's name. It returns a sequence of anonymous types that contain the `Cat.Name` and `Dog.Name` properties from each matching pair. Because this is an inner join, only those objects from the first data source that have a match in the second data source are returned.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="MultipleJoinQuery":::

The equivalent using multiple <xref:System.Linq.Enumerable.Join%2A> method uses the same approach with the anonymous type (in the example below it's named `commonOwner`):

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="MultipleJoinMethod":::

### Inner join by using grouped join

The following example shows you how to implement an inner join by using a group join.

In `query1`, the list of `Person` objects is group-joined to the list of `Pet` objects based on the `Person` matching the `Pet.Owner` property. The group join creates a collection of intermediate groups, where each group consists of a `Person` object and a sequence of matching `Pet` objects.

By adding a second `from` clause to the query, this sequence of sequences is combined (or flattened) into one longer sequence. The type of the elements of the final sequence is specified by the `select` clause. In this example, that type is an anonymous type that consists of the `Person.FirstName` and `Pet.Name` properties for each matching pair.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="InnerGroupJoinQuery":::

The result of `query1` is equivalent to the result set that would have been obtained by using the `join` clause without the `into` clause to perform an inner join. The `query2` variable demonstrates this equivalent query.

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="InnerJoinQuery":::

The same results can be achieved using <xref:System.Linq.Enumerable.GroupJoin%2A> method, as follows:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="InnerGroupJoinMethod":::

This approach requires chaining the query results with <xref:System.Linq.Enumerable.SelectMany%2A> to create the final list of Owner - Pet relation based on the results of group join. To avoid chaining, the single <xref:System.Linq.Enumerable.Join%2A> method can be used as presented here:

:::code language="csharp" source="./snippets/standard-query-operators/InnerJoins.cs" id="InnerJoinMethod":::

## Perform grouped joins

The group join is useful for producing hierarchical data structures. It pairs each element from the first collection with a set of correlated elements from the second collection.

For example, a class or a relational database table named `Student` might contain two fields: `Id` and `Name`. A second class or relational database table named `Course` might contain two fields: `StudentId` and `CourseTitle`. A group join of these two data sources, based on matching `Student.Id` and `Course.StudentId`, would group each `Student` with a collection of `Course` objects (which might be empty).

> [!NOTE]
> Each element of the first collection appears in the result set of a group join regardless of whether correlated elements are found in the second collection. In the case where no correlated elements are found, the sequence of correlated elements for that element is empty. The result selector therefore has access to every element of the first collection. This differs from the result selector in a non-group join, which cannot access elements from the first collection that have no match in the second collection.

> [!WARNING]
> <xref:System.Linq.Enumerable.GroupJoin%2A?displayProperty=nameWithType> has no direct equivalent in traditional relational database terms. However, this method does implement a superset of inner joins and left outer joins. Both of these operations can be written in terms of a grouped join. For more information, see [Entity Framework Core, GroupJoin](/ef/core/querying/complex-query-operators#groupjoin).

The first example in this article shows you how to perform a group join. The second example shows you how to use a group join to create XML elements.

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [the overview article](../index.md).

### Group join

The following example performs a group join of objects of type `Person` and `Pet` based on the `Person` matching the `Pet.Owner` property. Unlike a non-group join, which would produce a pair of elements for each match, the group join produces only one resulting object for each element of the first collection, which in this example is a `Person` object. The corresponding elements from the second collection, which in this example are `Pet` objects, are grouped into a collection. Finally, the result selector function creates an anonymous type for each match that consists of `Person.FirstName` and a collection of `Pet` objects.

:::code language="csharp" source="./snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinQuery":::

In the above example, `query` variable contains the query that creates a list where each element is an anonymous type that contains the person's first name and a collection of pets that are owned by them.

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinMethod":::

### Example - Group join to create XML

Group joins are ideal for creating XML by using LINQ to XML. The following example is similar to the previous example except that instead of creating anonymous types, the result selector function creates XML elements that represent the joined objects.

:::code language="csharp" source="./snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinToXmlQuery":::

The equivalent query using method syntax is shown in the followingcode:

:::code language="csharp" source="./snippets/standard-query-operators/GroupJoins.cs" id="GroupJoinToXmlMethod":::

## Perform left outer joins

A left outer join is a join in which each element of the first collection is returned, regardless of whether it has any correlated elements in the second collection. You can use LINQ to perform a left outer join by calling the <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> method on the results of a group join.

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [the overview article](../index.md).

The following example demonstrates how to use the <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> method on the results of a group join to perform a left outer join.

The first step in producing a left outer join of two collections is to perform an inner join by using a group join. (See [Perform inner joins](#perform-inner-joins) for an explanation of this process.) In this example, the list of `Person` objects is inner-joined to the list of `Pet` objects based on a `Person` object that matches `Pet.Owner`.

The second step is to include each element of the first (left) collection in the result set even if that element has no matches in the right collection. This is accomplished by calling <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> on each sequence of matching elements from the group join. In this example, <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> is called on each sequence of matching `Pet` objects. The method returns a collection that contains a single, default value if the sequence of matching `Pet` objects is empty for any `Person` object, thereby ensuring that each `Person` object is represented in the result collection.

> [!NOTE]
> The default value for a reference type is `null`; therefore, the example checks for a null reference before accessing each element of each `Pet` collection.

:::code source="./snippets/standard-query-operators/LeftOuterJoins.cs" id="LeftOuterJoinQuery":::

The equivalent query using method syntax is shown in the following code:

:::code source="./snippets/standard-query-operators/LeftOuterJoins.cs" id="LeftOuterJoinMethod":::

## Join by using composite keys

This example shows how to perform join operations in which you want to use more than one key to define a match. This is accomplished by using a composite key. You create a composite key as an anonymous type or named typed with the values that you want to compare. If the query variable will be passed across method boundaries, use a named type that overrides <xref:System.Object.Equals%2A> and <xref:System.Object.GetHashCode%2A> for the key. The names of the properties, and the order in which they occur, must be identical in each key.

The following example demonstrates how to use a composite key to join data from three tables:

```csharp
var query = from o in db.Orders
    from p in db.Products
    join d in db.OrderDetails
        on new {o.OrderID, p.ProductID} equals new {d.OrderID, d.ProductID} into details
        from d in details
        select new {o.OrderID, p.ProductID, d.UnitPrice};
```

Type inference on composite keys depends on the names of the properties in the keys, and the order in which they occur. If the properties in the source sequences don't have the same names, you must assign new names in the keys. For example, if the `Orders` table and `OrderDetails` table each used different names for their columns, you could create composite keys by assigning identical names in the anonymous types:

```csharp
join...on new {Name = o.CustomerName, ID = o.CustID} equals
    new {Name = d.CustName, ID = d.CustID }
```

Composite keys can be also used in a `group` clause.

## See also

- <xref:System.Linq.Enumerable.Join%2A>
- <xref:System.Linq.Enumerable.GroupJoin%2A>
- [Anonymous types](../../fundamentals/types/anonymous-types.md)
- [Formulate Joins and Cross-Product Queries](../../../framework/data/adonet/sql/linq/formulate-joins-and-cross-product-queries.md)
- [join clause](../../language-reference/keywords/join-clause.md)
- [group clause](../../language-reference/keywords/group-clause.md)
- [How to join content from dissimilar files (LINQ) (C#)](../../programming-guide/concepts/linq/how-to-join-content-from-dissimilar-files-linq.md)
- [How to populate object collections from multiple sources (LINQ) (C#)](../../programming-guide/concepts/linq/how-to-populate-object-collections-from-multiple-sources-linq.md)
