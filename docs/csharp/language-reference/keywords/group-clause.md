---
description: "group clause - C# Reference"
title: "group clause"
ms.date: 01/21/2026
f1_keywords: 
  - "group"
  - "group_CSharpKeyword"
helpviewer_keywords: 
  - "group keyword [C#]"
  - "group clause [C#]"
---
# group clause (C# Reference)

The `group` clause returns a sequence of <xref:System.Linq.IGrouping%602> objects. The sequence contains zero or more items that match the key value for the group. For example, you can group a sequence of strings according to the first letter in each string. In this case, the first letter is the key and has a type [char](../builtin-types/char.md). Each <xref:System.Linq.IGrouping%602> object stores this key in its `Key` property. The compiler infers the type of the key.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

You can end a query expression with a `group` clause, as shown in the following example:

:::code language="csharp" source="./snipets/group.cs" id="10":::

If you want to perform additional query operations on each group, specify a temporary identifier by using the [into](into.md) contextual keyword. When you use `into`, you must continue with the query, and eventually end it with either a `select` statement or another `group` clause, as shown in the following excerpt:

:::code language="csharp" source="./snippets/group.cs" id="11":::

More complete examples of the use of `group` with and without `into` are provided in the Example section of this article.

## Enumerating the results of a group query

Because the <xref:System.Linq.IGrouping%602> objects that a `group` query produces are essentially a list of lists, you must use a nested [foreach](../statements/iteration-statements.md#the-foreach-statement) loop to access the items in each group. The outer loop iterates over the group keys, and the inner loop iterates over each item in the group itself. A group can have a key but no elements. The following `foreach` loop executes the query in the previous code examples:

:::code language="csharp" source="./snippets/group.cs" id="12":::

## Key types

Group keys can be any type, such as a string, a built-in numeric type, or a user-defined named type or anonymous type.

### Grouping by string

The previous code examples used a `char`. You can also specify a string key, such as the complete last name:

:::code language="csharp" source="./snippets/group.cs" id="13":::

### Grouping by bool

The following example uses a bool value for a key to divide the results into two groups. The value comes from a sub-expression in the `group` clause.

:::code language="csharp" source="./snippets/group.cs" id="14":::

### Grouping by numeric range

The next example uses an expression to create numeric group keys that represent a percentile range. It uses [`let`](let-clause.md) to store a method call result, so you don't have to call the method twice in the `group` clause. For more information about how to safely use methods in query expressions, see [Handle exceptions in query expressions](../../linq/get-started/write-linq-queries.md).

:::code language="csharp" source="./snippets/group.cs" id="15":::

### Grouping by composite keys

Use a composite key when you want to group elements by more than one key. Create a composite key by using an anonymous type or a named type to hold the key element. In the following example, assume that a class `Person` has members named `surname` and `city`. The `group` clause creates a separate group for each set of persons with the same last name and the same city.

```csharp
group person by new {name = person.surname, city = person.city};
```

Use a named type if you need to pass the query variable to another method. Create a special class with automatically implemented properties for the keys, and then override the <xref:System.Object.Equals%2A> and <xref:System.Object.GetHashCode%2A> methods. You can also use a struct, which doesn't strictly require those method overrides. For more information, see [How to implement a lightweight class with automatically implemented properties](../../programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties.md) and [How to query for duplicate files in a directory tree](../../linq/how-to-query-files-and-directories.md). The latter article has a code example that demonstrates how to use a composite key with a named type.

## Examples

The following example shows the standard pattern for ordering source data into groups when you don't apply any extra query logic to the groups. This pattern is called grouping without a continuation. The example groups the elements in an array of strings according to their first letter. The result of the query is an <xref:System.Linq.IGrouping%602> type that contains a public `Key` property of type `char` and an <xref:System.Collections.Generic.IEnumerable%601> collection that contains each item in the grouping.

The result of a `group` clause is a sequence of sequences. To access the individual elements within each returned group, use a nested `foreach` loop inside the loop that iterates the group keys, as shown in the following example.

:::code language="csharp" source="./snippets/group.cs" id="16":::

The following example shows how to perform extra logic on the groups after you create them, by using a *continuation* with `into`. For more information, see [`into`](into.md). The following example queries each group to select only those whose key value is a vowel.

:::code language="csharp" source="./snippets/group.cs" id="17":::

At compile time, the compiler translates `group` clauses into calls to the <xref:System.Linq.Enumerable.GroupBy%2A> method.

The syntax of `group` clause query doesn't support custom equality comparer. If you want to use <xref:System.Collections.IEqualityComparer> in your query, explicitly use the <xref:System.Linq.Enumerable.GroupBy%2A> method.

## See also

- <xref:System.Linq.IGrouping%602>
- <xref:System.Linq.Enumerable.GroupBy%2A>
- <xref:System.Linq.Enumerable.ThenBy%2A>
- <xref:System.Linq.Enumerable.ThenByDescending%2A>
- [Query Keywords](query-keywords.md)
- [Language Integrated Query (LINQ)](../../linq/index.md)
- [Create a nested group](../../linq/standard-query-operators/grouping-data.md)
- [Group query results](../../linq/standard-query-operators/grouping-data.md)
- [Perform a subquery on a grouping operation](../../linq/standard-query-operators/grouping-data.md)
