---
title: Write LINQ queries
description: Learn how to write LINQ queries in C#.
ms.date: 01/16/2025
ms.topic: how-to
---
# Write C# LINQ queries to query data

Most queries in the introductory Language Integrated Query (LINQ) documentation are written by using the LINQ declarative query syntax. The C# compiler translates query syntax into method calls. These method calls implement the standard query operators, and have names such as `Where`, `Select`, `GroupBy`, `Join`, `Max`, and `Average`. You can call them directly by using method syntax instead of query syntax.

Query syntax and method syntax are semantically identical, but query syntax is often simpler and easier to read. Some queries must be expressed as method calls. For example, you must use a method call to express a query that retrieves the number of elements that match a specified condition. You also must use a method call for a query that retrieves the element that has the maximum value in a source sequence. The reference documentation for the standard query operators in the <xref:System.Linq> namespace generally uses method syntax. You should become familiar with how to use method syntax in queries and in query expressions themselves.

## Standard query operator extension methods

The following example shows a simple *query expression* and the semantically equivalent query written as a *method-based query*.

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="MethodSyntax":::

The output from the two examples is identical. The type of the query variable is the same in both forms: <xref:System.Collections.Generic.IEnumerable%601>.

On the right side of the expression, notice that the `where` clause is now expressed as an instance method on the `numbers` object, which has a type of `IEnumerable<int>`. If you're familiar with the generic <xref:System.Collections.Generic.IEnumerable%601> interface, you know that it doesn't have a `Where` method. However, if you invoke the IntelliSense completion list in the Visual Studio IDE, you see not only a `Where` method, but many other methods such as `Select`, `SelectMany`, `Join`, and `Orderby`. These methods implement the standard query operators.

![Screenshot showing all the standard query operators in Intellisense.](./media/write-linq-queries/standard-query-operators.png)

Although it looks as if <xref:System.Collections.Generic.IEnumerable%601> includes more methods, it doesn't. The standard query operators are implemented as *extension methods*. Extensions methods "extend" an existing type; they can be called as if they were instance methods on the type. The standard query operators extend <xref:System.Collections.Generic.IEnumerable%601> and that is why you can write `numbers.Where(...)`. You bring extensions into scope with `using` directives before calling them.

For more information about extension methods, see [Extension Methods](../../programming-guide/classes-and-structs/extension-methods.md). For more information about standard query operators, see [Standard Query Operators Overview (C#)](../standard-query-operators/index.md). Some LINQ providers, such as [Entity Framework](/ef/core/) and LINQ to XML, implement their own standard query operators and extension methods for other types besides <xref:System.Collections.Generic.IEnumerable%601>.

## Lambda expressions

In the preceding example, the conditional expression (`num % 2 == 0`) is passed as an in-line argument to the <xref:System.Linq.Enumerable.Where%2A?displayProperty=nameWithType> method: `Where(num => num % 2 == 0).` This inline expression is a [lambda expression](../../language-reference/operators/lambda-expressions.md). It's a convenient way to write code that would otherwise have to be written in more cumbersome form. The `num` on the left of the operator is the input variable, which corresponds to `num` in the query expression. The compiler can infer the type of `num` because it knows that `numbers` is a generic <xref:System.Collections.Generic.IEnumerable%601> type. The body of the lambda is the same as the expression in query syntax or in any other C# expression or statement. It can include method calls and other complex logic. The return value is the expression result. Certain queries can only be expressed in method syntax and some of those queries require lambda expressions. Lambda expressions are a powerful and flexible tool in your LINQ toolbox.

## Composability of queries

In the preceding code example, the <xref:System.Linq.Enumerable.OrderBy%2A?displayProperty=nameWithType> method is invoked by using the dot operator on the call to `Where`. `Where` produces a filtered sequence, and then `Orderby` sorts the sequence produced by `Where`. Because queries return an `IEnumerable`, you compose them in method syntax by chaining the method calls together. The compiler does this composition when you write queries using query syntax. Because a query variable doesn't store the results of the query, you can modify it or use it as the basis for a new query at any time, even after you execute it.

The following examples demonstrate some basic LINQ queries by using each approach listed previously.

> [!NOTE]
> These queries operate on in-memory collections; however, the syntax is identical to that used in LINQ to Entities and LINQ to XML.

## Example - Query syntax

You write most queries with *query syntax* to create *query expressions*. The following example shows three query expressions. The first query expression demonstrates how to filter or restrict results by applying conditions with a `where` clause. It returns all elements in the source sequence whose values are greater than 7 or less than 3. The second expression demonstrates how to order the returned results. The third expression demonstrates how to group results according to a key. This query returns two groups based on the first letter of the word.

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_1":::

The type of the queries is <xref:System.Collections.Generic.IEnumerable%601>. All of these queries could be written using [`var`](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) as shown in the following example:

`var query = from num in numbers...`

In each previous example, the queries don't actually execute until you iterate over the query variable in a [`foreach`](../../language-reference/statements/iteration-statements.md#the-foreach-statement) statement or other statement.

## Example - Method syntax

Some query operations must be expressed as a method call. The most common such methods are those methods that return singleton numeric values, such as <xref:System.Linq.Enumerable.Sum%2A>, <xref:System.Linq.Enumerable.Max%2A>, <xref:System.Linq.Enumerable.Min%2A>, <xref:System.Linq.Enumerable.Average%2A>, and so on. These methods must always be called last in any query because they return a single value and can't serve as the source for an additional query operation. The following example shows a method call in a query expression:

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_2":::

If the method has <xref:System.Action?displayProperty=fullName> or <xref:System.Func%601?displayProperty=nameWithType> parameters, these arguments are provided in the form of a [lambda expression](../../language-reference/operators/lambda-expressions.md), as shown in the following example:

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_3":::

In the previous queries, only Query #4 executes immediately, because it returns a single value, and not a generic <xref:System.Collections.Generic.IEnumerable%601> collection. The method itself uses `foreach` or similar code in order to compute its value.

Each of the previous queries can be written by using implicit typing with [`var`](../../language-reference/statements/declarations.md#implicitly-typed-local-variables), as shown in the following example:

:::code language="csharp" source="./snippets/SnippetApp/WriteLinqQueries.cs" id="write_linq_queries_4":::

## Example - Mixed query and method syntax

This example shows how to use method syntax on the results of a query clause. Just enclose the query expression in parentheses, and then apply the dot operator and call the method. In the following example, query #7 returns a count of the numbers whose value is between 3 and 7.

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

## Dynamically specify predicate filters at run time

In some cases, you don't know until run time how many predicates you have to apply to source elements in the `where` clause. One way to dynamically specify multiple predicate filters is to use the <xref:System.Linq.Enumerable.Contains%2A> method, as shown in the following example. The query returns different results based on the value of `id` when the query is executed.

:::code language="csharp" source="./snippets/SnippetApp/RuntimeFiltering.cs" id="runtime_filtering_1":::

> [!NOTE]
> This example uses the following data source and data:

:::code language="csharp" source="./snippets/SnippetApp/DataSources.cs" id="basics_datasource":::

:::code language="csharp" source="./snippets/SnippetApp/Basics.cs" id="SourceData":::

You can use control flow statements, such as `if... else` or `switch`, to select among predetermined alternative queries. In the following example, `studentQuery` uses a different `where` clause if the run-time value of `oddYear` is `true` or `false`.

:::code language="csharp" source="./snippets/SnippetApp/RuntimeFiltering.cs" id="runtime_filtering_2":::

## Handle null values in query expressions

This example shows how to handle possible null values in source collections. An object collection such as an <xref:System.Collections.Generic.IEnumerable%601> can contain elements whose value is [null](../../language-reference/keywords/null.md). If a source collection is `null` or contains an element whose value is `null`, and your query doesn't handle `null` values, a <xref:System.NullReferenceException> is thrown when you execute the query.

The following example uses these types and static data arrays:

:::code language="csharp" source="./snippets/SnippetApp/NullValues.cs" id="dataSourceTypes":::

:::code language="csharp" source="./snippets/SnippetApp/NullValues.cs" id="source":::

You can code defensively to avoid a null reference exception as shown in the following example:

:::code language="csharp" source="./snippets/SnippetApp/NullValues.cs" id="null_values_1":::

In the previous example, the `where` clause filters out all null elements in the categories sequence. This technique is independent of the null check in the join clause. The conditional expression with null in this example works because `Products.CategoryID` is of type `int?`, which is shorthand for `Nullable<int>`.

In a join clause, if only one of the comparison keys is a nullable value type, you can cast the other to a nullable value type in the query expression. In the following example, assume that `EmployeeID` is a column that contains values of type `int?`:

```csharp
var query =
    from o in db.Orders
    join e in db.Employees
        on o.EmployeeID equals (int?)e.EmployeeID
    select new { o.OrderID, e.FirstName };
```

In each of the examples, the `equals` query keyword is used. You can also use [pattern matching](../../language-reference/operators/patterns.md), which includes patterns for `is null` and `is not null`. These patterns aren't recommended in LINQ queries because query providers might not interpret the new C# syntax correctly. A query provider is a library that translates C# query expressions into a native data format, such as Entity Framework Core. Query providers implement the <xref:System.Linq.IQueryProvider?displayProperty=nameWithType> interface to create data sources that implement the <xref:System.Linq.IQueryable%601?displayProperty=nameWithType> interface.

## Handle exceptions in query expressions

It's possible to call any method in the context of a query expression. Don't call any method in a query expression that can create a side effect such as modifying the contents of the data source or throwing an exception. This example shows how to avoid raising exceptions when you call methods in a query expression without violating the general .NET guidelines on exception handling. Those guidelines state that it's acceptable to catch a specific exception when you understand why it was thrown in a given context. For more information, see [Best Practices for Exceptions](../../../standard/exceptions/best-practices-for-exceptions.md).

The final example shows how to handle those cases when you must throw an exception during execution of a query.

The following example shows how to move exception handling code outside a query expression. This refactoring is only possible when the method doesn't depend on any variables local to the query. It's easier to deal with exceptions outside of the query expression.

:::code language="csharp" source="./snippets/SnippetApp/Exceptions.cs" id="exceptions_1":::

In the `catch (InvalidOperationException)` block in the preceding example, handle (or don't handle) the exception in the way that is appropriate for your application.

In some cases, the best response to an exception that is thrown from within a query might be to stop the query execution immediately. The following example shows how to handle exceptions that might be thrown from inside a query body. Assume that `SomeMethodThatMightThrow` can potentially cause an exception that requires the query execution to stop.

The `try` block encloses the `foreach` loop, and not the query itself. The `foreach` loop is the point at which the query is executed. Run-time exceptions are thrown when the query is executed. Therefore they must be handled in the `foreach` loop.

:::code language="csharp" source="./snippets/SnippetApp/Exceptions.cs" id="exceptions_2":::

Remember to catch whatever exception you expect to raise and/or do any necessary cleanup in a `finally` block.

## See also

- [where clause](../../language-reference/keywords/where-clause.md)
- [Querying based on runtime state](../../advanced-topics/expression-trees/debugview-syntax.md)
- <xref:System.Nullable%601>
- [Nullable value types](../../language-reference/builtin-types/nullable-value-types.md)
