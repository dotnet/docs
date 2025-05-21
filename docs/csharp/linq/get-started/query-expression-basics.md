---
title: Query expression basics (LINQ)
description: Introduces concepts related to query expressions
ms.date: 01/16/2025
ms.topic: article
---
# Query expression basics

This article introduces the basic concepts related to query expressions in C#.

## What is a query and what does it do?

A *query* is a set of instructions that describes what data to retrieve from a given data source (or sources) and what shape and organization the returned data should have. A query is distinct from the results that it produces.

Generally, the source data is organized logically as a sequence of elements of the same kind. For example, an SQL database table contains a sequence of rows. In an XML file, there's a "sequence" of XML elements (although XML elements are organized hierarchically in a tree structure). An in-memory collection contains a sequence of objects.

From an application's viewpoint, the specific type and structure of the original source data isn't important. The application always sees the source data as an <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Linq.IQueryable%601> collection. For example, in LINQ to XML, the source data is made visible as an `IEnumerable`\<<xref:System.Xml.Linq.XElement>>.

Given this source sequence, a query might do one of three things:

- Retrieve a subset of the elements to produce a new sequence without modifying the individual elements. The query might then sort or group the returned sequence in various ways, as shown in the following example (assume `scores` is an `int[]`):

  :::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics1":::

- Retrieve a sequence of elements as in the previous example but transform them to a new type of object. For example, a query might retrieve only the family names from certain customer records in a data source. Or it might retrieve the complete record and then use it to construct another in-memory object type or even XML data before generating the final result sequence. The following example shows a projection from an `int` to a `string`. Note the new type of `highScoresQuery`.

  :::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics2":::

- Retrieve a singleton value about the source data, such as:

  - The number of elements that match a certain condition.

  - The element that has the greatest or least value.

  - The first element that matches a condition, or the sum of particular values in a specified set of elements. For example, the following query returns the number of scores greater than 80 from the `scores` integer array:

    :::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics3":::

    In the previous example, note the use of parentheses around the query expression before the call to the <xref:System.Linq.Enumerable.Count%2A?displayProperty=nameWithType> method. You can also use a new variable to store the concrete result.

    :::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics4":::

In the previous example, the query is executed in the call to `Count`, because `Count` must iterate over the results in order to determine the number of elements returned by `highScoresQuery`.

## What is a query expression?

A *query expression* is a query expressed in query syntax. A query expression is a first-class language construct. It's just like any other expression and can be used in any context in which a C# expression is valid. A query expression consists of a set of clauses written in a declarative syntax similar to SQL or XQuery. Each clause in turn contains one or more C# expressions, and these expressions might themselves be either a query expression or contain a query expression.

A query expression must begin with a [from](../../language-reference/keywords/from-clause.md) clause and must end with a [select](../../language-reference/keywords/select-clause.md) or [group](../../language-reference/keywords/group-clause.md) clause. Between the first `from` clause and the last `select` or `group` clause, it can contain one or more of these optional clauses: [where](../../language-reference/keywords/where-clause.md), [orderby](../../language-reference/keywords/orderby-clause.md), [join](../../language-reference/keywords/join-clause.md), [let](../../language-reference/keywords/let-clause.md) and even another [from](../../language-reference/keywords/from-clause.md) clauses. You can also use the [`into`](../../language-reference/keywords/into.md) keyword to enable the result of a `join` or `group` clause to serve as the source for more query clauses in the same query expression.

### Query variable

In LINQ, a query variable is any variable that stores a *query* instead of the *results* of a query. More specifically, a query variable is always an enumerable type that produces a sequence of elements when iterated over in a `foreach` statement or a direct call to its <xref:System.Collections.IEnumerator.MoveNext?displayProperty=nameWithType> method.

> [!NOTE]
> Examples in this article use the following data source and sample data.

:::code language="csharp" source="./snippets/SnippetApp/DataSources.cs" id="basics_datasource":::

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="SourceData":::

The following code example shows a simple query expression with one data source, one filtering clause, one ordering clause, and no transformation of the source elements. The `select` clause ends the query.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics5":::

In the previous example, `scoreQuery` is a *query variable,* which is sometimes referred to as just a *query*. The query variable stores no actual result data, which is produced in the `foreach` loop. And when the `foreach` statement executes, the query results aren't returned through the query variable `scoreQuery`. Rather, they're returned through the iteration variable `testScore`. The `scoreQuery` variable can be iterated in a second `foreach` loop. It produces the same results as long as neither it nor the data source was modified.

A query variable might store a query that is expressed in query syntax or method syntax, or a combination of the two. In the following examples, both `queryMajorCities` and `queryMajorCities2` are query variables:

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics6":::

On the other hand, the following two examples show variables that aren't query variables even though each is initialized with a query. They aren't query variables because they store results:

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics7":::

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics7a":::

#### Explicit and implicit typing of query variables

This documentation usually provides the explicit type of the query variable in order to show the type relationship between the query variable and the [select clause](../../language-reference/keywords/select-clause.md). However, you can also use the [var](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) keyword to instruct the compiler to infer the type of a query variable (or any other local variable) at compile time. For example, the query example that was shown previously in this article can also be expressed by using implicit typing:

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics8":::

In the preceding example, the use of var is optional. `queryCities` is an `IEnumerable<City>` whether implicitly or explicitly typed.

### Starting a query expression

A query expression must begin with a `from` clause. It specifies a data source together with a range variable. The range variable represents each successive element in the source sequence as the source sequence is being traversed. The range variable is strongly typed based on the type of elements in the data source. In the following example, because `countries` is an array of `Country` objects, the range variable is also typed as `Country`. Because the range variable is strongly typed, you can use the dot operator to access any available members of the type.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics9":::

The range variable is in scope until the query is exited either with a semicolon or with a [continuation](#continuations-with-into) clause.

A query expression might contain multiple `from` clauses. Use more `from` clauses when each element in the source sequence is itself a collection or contains a collection. For example, assume that you have a collection of `Country` objects, each of which contains a collection of `City` objects named `Cities`. To query the `City` objects in each `Country`, use two `from` clauses as shown here:

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics10":::

For more information, see [from clause](../../language-reference/keywords/from-clause.md).

### Ending a query expression

A query expression must end with either a `group` clause or a `select` clause.

#### The group clause

Use the `group` clause to produce a sequence of groups organized by a key that you specify. The key can be any data type. For example, the following query creates a sequence of groups that contains one or more `Country` objects and whose key is a `char` type with value being the first letter of countries' names.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics11":::

For more information about grouping, see [group clause](../../language-reference/keywords/group-clause.md).

#### select clause

Use the `select` clause to produce all other types of sequences. A simple `select` clause just produces a sequence of the same type of objects as the objects that are contained in the data source. In this example, the data source contains `Country` objects. The `orderby` clause just sorts the elements into a new order and the `select` clause produces a sequence of the reordered `Country` objects.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics12":::

The `select` clause can be used to transform source data into sequences of new types. This transformation is also named a *projection*. In the following example, the `select` clause *projects* a sequence of anonymous types that contains only a subset of the fields in the original element. The new objects are initialized by using an object initializer.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics13":::

So in this example, the [`var`](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) is required because the query produces an anonymous type.

For more information about all the ways that a `select` clause can be used to transform source data, see [select clause](../../language-reference/keywords/select-clause.md).

#### Continuations with _into_

You can use the `into` keyword in a `select` or `group` clause to create a temporary identifier that stores a query. Use the `into` clause when you must perform extra query operations on a query after a grouping or select operation. In the following example, `countries` are grouped according to population in ranges of 10 million. After these groups are created, more clauses filter out some groups, and then to sort the groups in ascending order. To perform those extra operations, the continuation represented by `countryGroup` is required.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics14":::

For more information, see [`into`](../../language-reference/keywords/into.md).

### Filtering, ordering, and joining

Between the starting `from` clause, and the ending `select` or `group` clause, all other clauses (`where`, `join`, `orderby`, `from`, `let`) are optional. Any of the optional clauses might be used zero times or multiple times in a query body.

#### The where clause

Use the `where` clause to filter out elements from the source data based on one or more predicate expressions. The `where` clause in the following example has one predicate with two conditions.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics15":::

For more information, see [where clause](../../language-reference/keywords/where-clause.md).

#### The orderby clause

Use the `orderby` clause to sort the results in either ascending or descending order. You can also specify secondary sort orders. The following example performs a primary sort on the `country` objects by using the `Area` property. It then performs a secondary sort by using the `Population` property.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics16":::

The `ascending` keyword is optional; it's the default sort order if no order is specified. For more information, see [orderby clause](../../language-reference/keywords/orderby-clause.md).

#### The join clause

Use the `join` clause to associate and/or combine elements from one data source with elements from another data source based on an equality comparison between specified keys in each element. In LINQ, join operations are performed on sequences of objects whose elements are different types. After you join two sequences, you must use a `select` or `group` statement to specify which element to store in the output sequence. You can also use an anonymous type to combine properties from each set of associated elements into a new type for the output sequence. The following example associates `prod` objects whose `Category` property matches one of the categories in the `categories` string array. Products whose `Category` doesn't match any string in `categories` are filtered out. The `select` statement projects a new type whose properties are taken from both `cat` and `prod`.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics17":::

You can also perform a group join by storing the results of the `join` operation into a temporary variable by using the [`into`](../../language-reference/keywords/into.md) keyword. For more information, see [join clause](../../language-reference/keywords/join-clause.md).

#### The let clause

Use the `let` clause to store the result of an expression, such as a method call, in a new range variable. In the following example, the range variable `firstName` stores the first element of the array of strings returned by `Split`.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics18":::

For more information, see [let clause](../../language-reference/keywords/let-clause.md).

### Subqueries in a query expression

A query clause might itself contain a query expression, which is sometimes referred to as a *subquery*. Each subquery starts with its own `from` clause that doesn't necessarily point to the same data source in the first `from` clause. For example, the following query shows a query expression that is used in the select statement to retrieve the results of a grouping operation.

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="basics19":::

For more information, see [Perform a subquery on a grouping operation](../standard-query-operators/grouping-data.md).

## See also

- [Query keywords (LINQ)](../../language-reference/keywords/query-keywords.md)
- [Standard query operators overview](../standard-query-operators/index.md)
