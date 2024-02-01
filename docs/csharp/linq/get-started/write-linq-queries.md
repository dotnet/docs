---
title: Use C# to write LINQ queries
description: Learn how to write LINQ queries in C#.
ms.date: 12/14/2023
---
# Write C# LINQ queries to query data

Most queries in the introductory Language Integrated Query (LINQ) documentation are written by using the LINQ declarative query syntax. However, the query syntax must be translated into method calls for the .NET common language runtime (CLR) when the code is compiled. These method calls invoke the standard query operators, which have names such as `Where`, `Select`, `GroupBy`, `Join`, `Max`, and `Average`. You can call them directly by using method syntax instead of query syntax.

Query syntax and method syntax are semantically identical, but query syntax is often simpler and easier to read. Some queries must be expressed as method calls. For example, you must use a method call to express a query that retrieves the number of elements that match a specified condition. You also must use a method call for a query that retrieves the element that has the maximum value in a source sequence. The reference documentation for the standard query operators in the <xref:System.Linq> namespace generally uses method syntax. You should become familiar with how to use method syntax in queries and in query expressions themselves.

## Standard query operator extension methods

The following example shows a simple *query expression* and the semantically equivalent query written as a *method-based query*.

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="MethodSyntax":::

The output from the two examples is identical. You can see that the type of the query variable is the same in both forms: <xref:System.Collections.Generic.IEnumerable%601>.

To understand the method-based query, let's examine it more closely. On the right side of the expression, notice that the `where` clause is now expressed as an instance method on the `numbers` object, which has a type of `IEnumerable<int>`. If you're familiar with the generic <xref:System.Collections.Generic.IEnumerable%601> interface, you know that it doesn't have a `Where` method. However, if you invoke the IntelliSense completion list in the Visual Studio IDE, you see not only a `Where` method, but many other methods such as `Select`, `SelectMany`, `Join`, and `Orderby`. These methods implement the standard query operators.

![Screenshot showing all the standard query operators in Intellisense.](./media/write-linq-queries/standard-query-operators.png)

Although it looks as if <xref:System.Collections.Generic.IEnumerable%601> includes additional methods, it doesn't. The standard query operators are implemented as *extension methods*. Extensions methods "extend" an existing type; they can be called as if they were instance methods on the type. The standard query operators extend <xref:System.Collections.Generic.IEnumerable%601> and that is why you can write `numbers.Where(...)`.

To use extension methods, you bring them into scope with `using` directives. From your application's point of view, an extension method and a regular instance method are the same.

For more information about extension methods, see [Extension Methods](../../programming-guide/classes-and-structs/extension-methods.md). For more information about standard query operators, see [Standard Query Operators Overview (C#)](../../programming-guide/concepts/linq/standard-query-operators-overview.md). Some LINQ providers, such as [Entity Framework](/ef/core/) and LINQ to XML, implement their own standard query operators and extension methods for other types besides <xref:System.Collections.Generic.IEnumerable%601>.

## Lambda expressions

In the previous example, notice that the conditional expression (`num % 2 == 0`) is passed as an in-line argument to the <xref:System.Linq.Enumerable.Where%2A?displayProperty=nameWithType> method: `Where(num => num % 2 == 0).` This inline expression is a [lambda expression](../../language-reference/operators/lambda-expressions.md). It's a convenient way to write code that would otherwise have to be written in more cumbersome form. The `num` on the left of the operator is the input variable, which corresponds to `num` in the query expression. The compiler can infer the type of `num` because it knows that `numbers` is a generic <xref:System.Collections.Generic.IEnumerable%601> type. The body of the lambda is just the same as the expression in query syntax or in any other C# expression or statement. It can include method calls and other complex logic. The return value is just the expression result. Certain queries can only be expressed in method syntax and some of those require lambda expressions. Lambda expressions are a powerful and flexible tool in your LINQ toolbox.

## Composability of queries

In the previous code example, the <xref:System.Linq.Enumerable.OrderBy%2A?displayProperty=nameWithType> method is invoked by using the dot operator on the call to `Where`. `Where` produces a filtered sequence, and then `Orderby` sorts the sequence produced by `Where`. Because queries return an `IEnumerable`, you compose them in method syntax by chaining the method calls together. The compiler does this composition when you write queries using query syntax. Because a query variable doesn't store the results of the query, you can modify it or use it as the basis for a new query at any time, even after you execute it.

The following examples demonstrate some simple LINQ queries by using each approach listed previously.

> [!NOTE]
> These queries operate on simple in-memory collections; however, the basic syntax is identical to that used in LINQ to Entities and LINQ to XML.

## Example - Query syntax

You write most queries with *query syntax* to create *query expressions*. The following example shows three query expressions. The first query expression demonstrates how to filter or restrict results by applying conditions with a `where` clause. It returns all elements in the source sequence whose values are greater than 7 or less than 3. The second expression demonstrates how to order the returned results. The third expression demonstrates how to group results according to a key. This query returns two groups based on the first letter of the word.

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_1":::

The type of the queries is <xref:System.Collections.Generic.IEnumerable%601>. All of these queries could be written using [`var`](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) as shown in the following example:

`var query = from num in numbers...`

In each previous example, the queries don't actually execute until you iterate over the query variable in a [`foreach`](../../language-reference/statements/iteration-statements.md#the-foreach-statement) statement or other statement.

## Example - Method syntax

Some query operations must be expressed as a method call. The most common such methods are those methods that return singleton numeric values, such as <xref:System.Linq.Enumerable.Sum%2A>, <xref:System.Linq.Enumerable.Max%2A>, <xref:System.Linq.Enumerable.Min%2A>, <xref:System.Linq.Enumerable.Average%2A>, and so on. These methods must always be called last in any query because they return a single value and can't serve as the source for an extra query operation. The following example shows a method call in a query expression:

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_2":::

If the method has <xref:System.Action?displayProperty=fullName> or <xref:System.Func%601?displayProperty=nameWithType> parameters, these arguments are provided in the form of a [lambda expression](../../language-reference/operators/lambda-expressions.md), as shown in the following example:

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_3":::

In the previous queries, only Query #4 executes immediately, because it returns a single value, and not a generic <xref:System.Collections.Generic.IEnumerable%601> collection. The method itself uses `foreach` or similar code in order to compute its value.

Each of the previous queries can be written by using implicit typing with [`var``](../../language-reference/statements/declarations.md#implicitly-typed-local-variables), as shown in the following example:

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_4":::

## Example - Mixed query and method syntax

This example shows how to use method syntax on the results of a query clause. Just enclose the query expression in parentheses, and then apply the dot operator and call the method. In the following example, query #7 returns a count of the numbers whose value is between 3 and 7. In general, however, it's better to use a second variable to store the result of the method call. In this manner, the query is less likely to be confused with the results of the query.

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_5":::

Because Query #7 returns a single value and not a collection, the query executes immediately.

The previous query can be written by using implicit typing with `var`, as follows:

```csharp
var numCount = (from num in numbers...
```

It can be written in method syntax as follows:

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_5a":::

It can be written by using explicit typing, as follows:

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_5b":::

## See also

- [Walkthrough: Writing Queries in C#](../../programming-guide/concepts/linq/walkthrough-writing-queries-linq.md)
- [where clause](../../language-reference/keywords/where-clause.md)
