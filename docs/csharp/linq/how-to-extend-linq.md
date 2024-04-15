---
title: Group results by contiguous keys (LINQ in C#)
description: How to group results by contiguous keys using LINQ in C#.
ms.date: 04/12/2024
---
# How to extend LINQ

LINQ libraries are extensible.

## Querying based on runtime state (C#)

> [!NOTE]
> Make sure you add `using System.Linq.Expressions;` and `using static System.Linq.Expressions.Expression;` at the top of your *.cs* file.

Consider code that defines an <xref:System.Linq.IQueryable> or an [IQueryable\<T>](<xref:System.Linq.IQueryable%601>) against a data source:

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Initialize":::

Every time you run this code, the same exact query will be executed. This is frequently not very useful, as you may want your code to execute different queries depending on conditions at run time. This article describes how you can execute a different query based on runtime state.

### IQueryable / IQueryable\<T> and expression trees

Fundamentally, an <xref:System.Linq.IQueryable> has two components:

- <xref:System.Linq.IQueryable.Expression>&mdash;a language- and datasource-agnostic representation of the current query's components, in the form of an expression tree.
- <xref:System.Linq.IQueryable.Provider>&mdash;an instance of a LINQ provider, which knows how to materialize the current query into a value or set of values.

In the context of dynamic querying, the provider will usually remain the same; the expression tree of the query will differ from query to query.

Expression trees are immutable; if you want a different expression tree&mdash;and thus a different query&mdash;you'll need to translate the existing expression tree to a new one, and thus to a new <xref:System.Linq.IQueryable>.

The following sections describe specific techniques for querying differently in response to runtime state:

- Use runtime state from within the expression tree
- Call additional LINQ methods
- Vary the expression tree passed into the LINQ methods
- Construct an [Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601) expression tree using the factory methods at <xref:System.Linq.Expressions.Expression>
- Add method call nodes to an <xref:System.Linq.IQueryable>'s expression tree
- Construct strings, and use the [Dynamic LINQ library](https://dynamic-linq.net/)

#### Use runtime state from within the expression tree

Assuming the LINQ provider supports it, the simplest way to query dynamically is to reference the runtime state directly in the query via a closed-over variable, such as `length` in the following code example:

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Runtime_state_from_within_expression_tree":::

The internal expression tree&mdash;and thus the query&mdash;haven't been modified; the query returns different values only because the value of `length` has been changed.

#### Call additional LINQ methods

Generally, the [built-in LINQ methods](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Linq.Queryable/src/System/Linq/Queryable.cs) at <xref:System.Linq.Queryable> perform two steps:

- Wrap the current expression tree in a <xref:System.Linq.Expressions.MethodCallExpression> representing the method call.
- Pass the wrapped expression tree back to the provider, either to return a value via the provider's <xref:System.Linq.IQueryProvider.Execute%2A?displayProperty=nameWithType> method; or to return a translated query object via the <xref:System.Linq.IQueryProvider.CreateQuery%2A?displayProperty=nameWithType> method.

You can replace the original query with the result of an [IQueryable\<T>](xref:System.Linq.IQueryable%601)-returning method, to get a new query. You can do this conditionally based on runtime state, as in the following example:

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Added_method_calls":::

### Vary the expression tree passed into the LINQ methods

You can pass in different expressions to the LINQ methods, depending on runtime state:

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Varying_expressions":::

You might also want to compose the various subexpressions using a third-party library such as [LinqKit](http://www.albahari.com/nutshell/linqkit.aspx)'s [PredicateBuilder](http://www.albahari.com/nutshell/predicatebuilder.aspx):

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Compose_expressions":::

#### Construct expression trees and queries using factory methods

In all the examples up to this point, we've known the element type at compile time&mdash;`string`&mdash;and thus the type of the query&mdash;`IQueryable<string>`. You may need to add components to a query of any element type, or to add different components, depending on the element type. You can create expression trees from the ground up, using the factory methods at <xref:System.Linq.Expressions.Expression?displayProperty=fullName>, and thus tailor the expression at run time to a specific element type.

#### Constructing an [Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601)

When you construct an expression to pass into one of the LINQ methods, you're actually constructing an instance of [Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601), where `TDelegate` is some delegate type such as `Func<string, bool>`, `Action`, or a custom delegate type.

[Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601) inherits from <xref:System.Linq.Expressions.LambdaExpression>, which represents a complete lambda expression like the following:

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Compiler_generated_expression_tree":::

A <xref:System.Linq.Expressions.LambdaExpression> has two components:

- A parameter list&mdash;`(string x)`&mdash;represented by the <xref:System.Linq.Expressions.LambdaExpression.Parameters> property.
- A body&mdash;`x.StartsWith("a")`&mdash;represented by the <xref:System.Linq.Expressions.LambdaExpression.Body> property.

The basic steps in constructing an [Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601) are as follows:

- Define <xref:System.Linq.Expressions.ParameterExpression> objects for each of the parameters (if any) in the lambda expression, using the <xref:System.Linq.Expressions.Expression.Parameter%2A> factory method.

    :::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Factory_method_expression_tree_parameter":::

- Construct the body of your <xref:System.Linq.Expressions.LambdaExpression>, using the <xref:System.Linq.Expressions.ParameterExpression>(s) you've defined, and the factory methods at <xref:System.Linq.Expressions.Expression>. For instance, an expression representing `x.StartsWith("a")` could be constructed like this:

    :::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Factory_method_expression_tree_body":::

- Wrap the parameters and body in a compile-time-typed [Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601), using the appropriate <xref:System.Linq.Expressions.Expression.Lambda%2A> factory method overload:

    :::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Factory_method_expression_tree_lambda":::

The following sections describe a scenario in which you might want to construct an [Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601) to pass into a LINQ method, and provide a complete example of how to do so using the factory methods.

#### Scenario

Let's say you have multiple entity types:

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Entities":::

For any of these entity types, you want to filter and return only those entities that have a given text inside one of their `string` fields. For `Person`, you'd want to search the `FirstName` and `LastName` properties:

```csharp
string term = /* ... */;
var personsQry = new List<Person>()
    .AsQueryable()
    .Where(x => x.FirstName.Contains(term) || x.LastName.Contains(term));
```

But for `Car`, you'd want to search only the `Model` property:

```csharp
string term = /* ... */;
var carsQry = new List<Car>()
    .AsQueryable()
    .Where(x => x.Model.Contains(term));
```

While you could write one custom function for `IQueryable<Person>` and another for `IQueryable<Car>`, the following function adds this filtering to any existing query, irrespective of the specific element type.

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Factory_methods_expression_of_tdelegate":::

Because the `TextFilter` function takes and returns an [IQueryable\<T>](xref:System.Linq.IQueryable%601) (and not just an <xref:System.Linq.IQueryable>), you can add further compile-time-typed query elements after the text filter.

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Factory_methods_expression_of_tdelegate_usage":::

### Add method call nodes to the <xref:System.Linq.IQueryable>'s expression tree

If you have an <xref:System.Linq.IQueryable> instead of an [IQueryable\<T>](xref:System.Linq.IQueryable%601), you can't directly call the generic LINQ methods. One alternative is to build the inner expression tree as above, and use reflection to invoke the appropriate LINQ method while passing in the expression tree.

You could also duplicate the LINQ method's functionality, by wrapping the entire tree in a <xref:System.Linq.Expressions.MethodCallExpression> that represents a call to the LINQ method:

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Factory_methods_lambdaexpression":::

In this case, you don't have a compile-time `T` generic placeholder, so you'll use the <xref:System.Linq.Expressions.Expression.Lambda%2A> overload that doesn't require compile-time type information, and which produces a <xref:System.Linq.Expressions.LambdaExpression> instead of an [Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601).

### The Dynamic LINQ library

Constructing expression trees using factory methods is relatively complex; it is easier to compose strings. The [Dynamic LINQ library](https://dynamic-linq.net/) exposes a set of extension methods on <xref:System.Linq.IQueryable> corresponding to the standard LINQ methods at <xref:System.Linq.Queryable>, and which accept strings in a [special syntax](https://dynamic-linq.net/expression-language) instead of expression trees. The library generates the appropriate expression tree from the string, and can return the resultant translated <xref:System.Linq.IQueryable>.

For instance, the previous example could be rewritten as follows:

:::code language="csharp" source="../../../samples/snippets/csharp/programming-guide/dynamic-linq-expression-trees/Program.cs" id="Dynamic_linq":::

## How to add custom methods for LINQ queries

You extend the set of methods that you use for LINQ queries by adding extension methods to the <xref:System.Collections.Generic.IEnumerable%601> interface. For example, in addition to the standard average or maximum operations, you create a custom aggregate method to compute a single value from a sequence of values. You also create a method that works as a custom filter or a specific data transform for a sequence of values and returns a new sequence. Examples of such methods are <xref:System.Linq.Enumerable.Distinct%2A>, <xref:System.Linq.Enumerable.Skip%2A>, and <xref:System.Linq.Enumerable.Reverse%2A>.

When you extend the <xref:System.Collections.Generic.IEnumerable%601> interface, you can apply your custom methods to any enumerable collection. For more information, see [Extension Methods](../programming-guide/classes-and-structs/extension-methods.md).

### Add an aggregate method

An aggregate method computes a single value from a set of values. LINQ provides several aggregate methods, including <xref:System.Linq.Enumerable.Average%2A>, <xref:System.Linq.Enumerable.Min%2A>, and <xref:System.Linq.Enumerable.Max%2A>. You can create your own aggregate method by adding an extension method to the <xref:System.Collections.Generic.IEnumerable%601> interface.

The following code example shows how to create an extension method called `Median` to compute a median for a sequence of numbers of type `double`.

:::code language="csharp" source="./snippets/extensions/LinqExtensions.cs" ID="LinqExtensionClass":::

You call this extension method for any enumerable collection in the same way you call other aggregate methods from the <xref:System.Collections.Generic.IEnumerable%601> interface.

The following code example shows how to use the `Median` method for an array of type `double`.

:::code language="csharp" source="./snippets/extensions/Program.cs" ID="MedianUsage":::

#### Overload an aggregate method to accept various types

You can overload your aggregate method so that it accepts sequences of various types. The standard approach is to create an overload for each type. Another approach is to create an overload that will take a generic type and convert it to a specific type by using a delegate. You can also combine both approaches.

##### Create an overload for each type

You can create a specific overload for each type that you want to support. The following code example shows an overload of the `Median` method for the `int` type.

:::code language="csharp" source="./snippets/extensions/LinqExtensions.cs" ID="IntOverload":::

You can now call the `Median` overloads for both `integer` and `double` types, as shown in the following code:

:::code language="csharp" source="./snippets/extensions/Program.cs" ID="OverloadUsage":::

##### Create a generic overload

You can also create an overload that accepts a sequence of generic objects. This overload takes a delegate as a parameter and uses it to convert a sequence of objects of a generic type to a specific type.

The following code shows an overload of the `Median` method that takes the <xref:System.Func%602> delegate as a parameter. This delegate takes an object of generic type T and returns an object of type `double`.

:::code language="csharp" source="./snippets/extensions/LinqExtensions.cs" ID="GenericOverload":::

You can now call the `Median` method for a sequence of objects of any type. If the type doesn't have its own method overload, you have to pass a delegate parameter. In C#, you can use a lambda expression for this purpose. Also, in Visual Basic only, if you use the `Aggregate` or `Group By` clause instead of the method call, you can pass any value or expression that is in the scope this clause.

The following example code shows how to call the `Median` method for an array of integers and an array of strings. For strings, the median for the lengths of strings in the array is calculated. The example shows how to pass the <xref:System.Func%602> delegate parameter to the `Median` method for each case.

:::code language="csharp" source="./snippets/extensions/Program.cs" ID="GenericUsage":::

### Add a method that returns a sequence

You can extend the <xref:System.Collections.Generic.IEnumerable%601> interface with a custom query method that returns a sequence of values. In this case, the method must return a collection of type <xref:System.Collections.Generic.IEnumerable%601>. Such methods can be used to apply filters or data transforms to a sequence of values.

The following example shows how to create an extension method named `AlternateElements` that returns every other element in a collection, starting from the first element.

:::code language="csharp" source="./snippets/extensions/LinqExtensions.cs" ID="SequenceElement":::

You can call this extension method for any enumerable collection just as you would call other methods from the <xref:System.Collections.Generic.IEnumerable%601> interface, as shown in the following code:

:::code language="csharp" source="./snippets/extensions/Program.cs" ID="SequenceUsage":::

## Group results by contiguous keys

The following example shows how to group elements into chunks that represent subsequences of contiguous keys. For example, assume that you are given the following sequence of key-value pairs:

|Key | Value |
|---------|-----------|
| A | We |
| A | think |
| A | that |
| B | Linq |
| C | is |
| A | really |
| B | cool |
| B | ! |

The following groups will be created in this order:

1. We, think, that
1. Linq
1. is
1. really
1. cool, !

The solution is implemented as an extension method that is thread-safe and that returns its results in a streaming manner. In other words, it produces its groups as it moves through the source sequence. Unlike the `group` or `orderby` operators, it can begin returning groups to the caller before all of the sequence has been read.

Thread-safety is accomplished by making a copy of each group or chunk as the source sequence is iterated, as explained in the source code comments. If the source sequence has a large sequence of contiguous items, the common language runtime may throw an <xref:System.OutOfMemoryException>.

The following example shows both the extension method and the client code that uses it:

:::code language="csharp" source="./snippets/linq-index/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_chunkextensions":::

:::code language="csharp" source="./snippets/linq-index/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_client_code":::

### `ChunkExtensions` class

In the presented code, of `ChunkExtensions` class implementation, the `while(true)`, loop in the `ChunkBy` method, iterates through source sequence and create a copy of each Chunk. On each pass, the iterator advances to the first element of the next "Chunk"
<br/>(The chunk is represented by [`Chunk`](#chunk-class) class.)
<br/>in the source sequence. This loop corresponds to the outer foreach loop that executes the query.
What happens in that loop is:

1. Get the key for the current Chunk, by assigning it to `key` variable: `var key = keySelector(enumerator.Current);`. The source iterator will churn through the source sequence until it finds an element with a key that doesn't match.
1. Make a new Chunk (group) object, and store it in `current` variable, that initially has one GroupItem, which is a copy of the current source element.
1. Return that Chunk. A Chunk is an `IGrouping<TKey,TSource>`, which is the return value of the [`ChunkBy`](#chunk-class) method. At this point the Chunk only has the first element in its source sequence. The remaining elements will be returned only when the client code foreach's over this chunk. See `Chunk.GetEnumerator` for more info.
1. Check to see whether
<br/>(a) the chunk has made a copy of all its source elements or
<br/>(b) the iterator has reached the end of the source sequence.
<br/>If the caller uses an inner foreach loop to iterate the chunk items, and that loop ran to completion, then the `Chunk.GetEnumerator` method will already have made copies of all chunk items before we get here. If the `Chunk.GetEnumerator` loop did not enumerate all elements in the chunk, we need to do it here to avoid corrupting the iterator for clients that may be calling us on a separate thread.

### `Chunk` class

The `Chunk` class is a contiguous group of one or more source elements that have the same key. A Chunk has a key and a list of ChunkItem objects, which are copies of the elements in the source sequence:

:::code language="csharp" source="./snippets/linq-index/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_chunk_class":::

A Chunk has a linked list of `ChunkItem`s, which represent the elements in the current chunk. Each `ChunkItem` (represented by `ChunkItem` class) has a reference to the next `ChunkItem` in the list.
The list consists of it's `head` - which stores the contents of the first source element that belongs with this chunk, and it's `tail` - which is an end of the list. It is repositioned each time a new `ChunkItem` is added.
<br/>The `Chunk` class contains the private boolean field: `DoneCopyingChunk`, which indicates that all chunk elements have been copied to the list of ChunkItems, and the source enumerator is either at the end, or else on an element with a new key.
The tail of the linked list is set to `null` in the `CopyNextChunkElement` method if the key of the next element does not match the current chunk's key, or there are no more elements in the source.

The `CopyNextChunkElement` method of the `Chunk` class adds one `ChunkItem` to the current group of items.
<br/>By using `enumerator.MoveNext()` method, it tries to advance the iterator on the source sequence. If `MoveNext()` method returns `false` it means that iteration is at the end, and `isLastSourceElement` is set to `true`.
Then, if iteration is at the end of the source, or at the end of the current chunk then the `enumerator` and `predicate` is null out for reuse with the next chunk.

The `CopyAllChunkElements` method is called after the end of the last chunk was reached. It first checks whether there are more elements in the source sequence. If there are, it returns `true` if enumerator for this chunk was exhausted. In this method, when private `DoneCopyingChunk` field is checked for `true`, if isLastSourceElement is `false`, it signals to the outer iterator to continue iterating.

The `GetEnumerator` method of the `Chunk` class is invoked by the inner foreach loop. This method stays just one step ahead of the client requests. It adds the next element of the chunk only after the clients requests the last element in the list so far.

## See also

- [Execute expression trees](../advanced-topics/expression-trees/expression-trees-execution.md)
- <xref:System.Collections.Generic.IEnumerable%601>
- [Extension Methods](../programming-guide/classes-and-structs/extension-methods.md)
