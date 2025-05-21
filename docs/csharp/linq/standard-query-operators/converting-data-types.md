---
title: "Converting Data Types"
description: Conversion methods change the type of input objects. See conversion operations in LINQ queries in C#, such as Enumerable.AsEnumerable and Enumerable.OfType.
ms.date: 05/29/2024
ms.topic: concept-article
---
# Converting Data Types (C#)

Conversion methods change the type of input objects.

[!INCLUDE [Prerequisites](../includes/linq-syntax.md)]

Conversion operations in LINQ queries are useful in various applications. Following are some examples:

- The <xref:System.Linq.Enumerable.AsEnumerable%2A?displayProperty=nameWithType> method can be used to hide a type's custom implementation of a standard query operator.
- The <xref:System.Linq.Enumerable.OfType%2A?displayProperty=nameWithType> method can be used to enable non-parameterized collections for LINQ querying.
- The <xref:System.Linq.Enumerable.ToArray%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.ToDictionary%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.ToList%2A?displayProperty=nameWithType>, and <xref:System.Linq.Enumerable.ToLookup%2A?displayProperty=nameWithType> methods can be used to force immediate query execution instead of deferring it until the query is enumerated.

## Methods

The following table lists the standard query operator methods that perform data-type conversions.

The conversion methods in this table whose names start with "As" change the static type of the source collection but don't enumerate it. The methods whose names start with "To" enumerate the source collection and put the items into the corresponding collection type.

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|AsEnumerable|Returns the input typed as <xref:System.Collections.Generic.IEnumerable%601>.|Not applicable.|<xref:System.Linq.Enumerable.AsEnumerable%2A?displayProperty=nameWithType>|
|AsQueryable|Converts a (generic) <xref:System.Collections.IEnumerable> to a (generic) <xref:System.Linq.IQueryable>.|Not applicable.|<xref:System.Linq.Queryable.AsQueryable%2A?displayProperty=nameWithType>|
|Cast|Casts the elements of a collection to a specified type.|Use an explicitly typed range variable. For example:<br /><br /> `from string str in words`|<xref:System.Linq.Enumerable.Cast%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Cast%2A?displayProperty=nameWithType>|
|OfType|Filters values, depending on their ability to be cast to a specified type.|Not applicable.|<xref:System.Linq.Enumerable.OfType%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.OfType%2A?displayProperty=nameWithType>|
|ToArray|Converts a collection to an array. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToArray%2A?displayProperty=nameWithType>|
|ToDictionary|Puts elements into a <xref:System.Collections.Generic.Dictionary%602> based on a key selector function. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToDictionary%2A?displayProperty=nameWithType>|
|ToList|Converts a collection to a <xref:System.Collections.Generic.List%601>. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToList%2A?displayProperty=nameWithType>|
|ToLookup|Puts elements into a <xref:System.Linq.Lookup%602> (a one-to-many dictionary) based on a key selector function. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToLookup%2A?displayProperty=nameWithType>|

[!INCLUDE [Datasources](../includes/data-sources-definition.md)]

## Query Expression Syntax Example

The following code example uses an explicitly typed range variable to cast a type to a subtype before accessing a member that is available only on the subtype.

:::code language="csharp" source="./snippets/standard-query-operators/ConversionExamples.cs" id="CastOperatorQuerySyntax":::

The equivalent query can be expressed using method syntax as shown in the following example:

:::code language="csharp" source="./snippets/standard-query-operators/ConversionExamples.cs" id="CastOperatorMethodSyntax":::

## See also

- <xref:System.Linq>
- [from clause](../../language-reference/keywords/from-clause.md)
