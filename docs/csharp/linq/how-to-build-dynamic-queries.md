---
title: "How to Build LINQ Queries based on run-time state"
description: Learn to query dynamically depending on run-time state, by varying either LINQ method calls or the expression trees passed into those methods.
ms.topic: how-to
ms.date: 04/22/2024
---
# Query based on run-time state

In most LINQ queries, the general shape of the query is set in code. You might filter items using a `where` clause, sort the output collection using `orderby`, group items, or perform some computation. Your code might provide parameters for the filter, or the sort key, or other expressions that are part of the query. However, the overall shape of the query can't change. In this article, you learn techniques to use <xref:System.Linq.IQueryable%601?displayProperty=fullName> interface and types that implement it to modify the shape of a query at run time.

You use these techniques to build queries at run time, where some user input or run-time state changes the query methods you want to use as part of the query. You want to edit the query by adding, removing, or modifying query clauses.

> [!NOTE]
> Make sure you add `using System.Linq.Expressions;` and `using static System.Linq.Expressions.Expression;` at the top of your *.cs* file.

Consider code that defines an <xref:System.Linq.IQueryable> or an <xref:System.Linq.IQueryable%601> against a data source:

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Initialize":::

Every time you run the preceding code, the same exact query is executed. Let's learn how to modify the query extend it or modify it. Fundamentally, an <xref:System.Linq.IQueryable> has two components:

- <xref:System.Linq.IQueryable.Expression>&mdash;a language-agnostic and datasource-agnostic representation of the current query's components, in the form of an expression tree.
- <xref:System.Linq.IQueryable.Provider>&mdash;an instance of a LINQ provider, which knows how to materialize the current query into a value or set of values.

In the context of dynamic querying, the provider usually remains the same; the expression tree of the query differs from query to query.

Expression trees are immutable; if you want a different expression tree&mdash;and thus a different query&mdash;you need to translate the existing expression tree to a new one. The following sections describe specific techniques for querying differently in response to run-time state:

- Use run-time state from within the expression tree
- Call more LINQ methods
- Vary the expression tree passed into the LINQ methods
- Construct an <xref:System.Linq.Expressions.Expression%601> expression tree using the factory methods at <xref:System.Linq.Expressions.Expression>
- Add method call nodes to an <xref:System.Linq.IQueryable>'s expression tree
- Construct strings, and use the [Dynamic LINQ library](https://dynamic-linq.net/)

Each of techniques enables more capabilities, but at a cost of increased complexity.

## Use run-time state from within the expression tree

The simplest way to query dynamically is to reference the run-time state directly in the query via a closed-over variable, such as `length` in the following code example:

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Runtime_state_from_within_expression_tree":::

The internal expression tree&mdash;and thus the query&mdash;isn't modified; the query returns different values only because the value of `length` changed.

## Call more LINQ methods

Generally, the [built-in LINQ methods](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Linq.Queryable/src/System/Linq/Queryable.cs) at <xref:System.Linq.Queryable> perform two steps:

- Wrap the current expression tree in a <xref:System.Linq.Expressions.MethodCallExpression> representing the method call.
- Pass the wrapped expression tree back to the provider, either to return a value via the provider's <xref:System.Linq.IQueryProvider.Execute%2A?displayProperty=nameWithType> method; or to return a translated query object via the <xref:System.Linq.IQueryProvider.CreateQuery%2A?displayProperty=nameWithType> method.

You can replace the original query with the result of an <xref:System.Linq.IQueryable%601?displayProperty=nameWithType>-returning method, to get a new query. You can use run-time state, as in the following example:

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Added_method_calls":::

## Vary the expression tree passed into the LINQ methods

You can pass in different expressions to the LINQ methods, depending on run-time state:

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Varying_expressions":::

You might also want to compose the various subexpressions using another library such as [LinqKit](http://www.albahari.com/nutshell/linqkit.aspx)'s [PredicateBuilder](http://www.albahari.com/nutshell/predicatebuilder.aspx):

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Compose_expressions":::

## Construct expression trees and queries using factory methods

In all the examples up to this point, you know the element type at compile time&mdash;`string`&mdash;and thus the type of the query&mdash;`IQueryable<string>`. You might add components to a query of any element type, or to add different components, depending on the element type. You can create expression trees from the ground up, using the factory methods at <xref:System.Linq.Expressions.Expression?displayProperty=fullName>, and thus tailor the expression at run time to a specific element type.

## Constructing an Expression\<TDelegate>

When you construct an expression to pass into one of the LINQ methods, you're actually constructing an instance of <xref:System.Linq.Expressions.Expression%601?displayProperty=nameWithType>, where `TDelegate` is some delegate type such as `Func<string, bool>`, `Action`, or a custom delegate type.

<xref:System.Linq.Expressions.Expression%601?displayProperty=nameWithType> inherits from <xref:System.Linq.Expressions.LambdaExpression>, which represents a complete lambda expression like the following example:

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Compiler_generated_expression_tree":::

A <xref:System.Linq.Expressions.LambdaExpression> has two components:

1. A parameter list&mdash;`(string x)`&mdash;represented by the <xref:System.Linq.Expressions.LambdaExpression.Parameters> property.
1. A body&mdash;`x.StartsWith("a")`&mdash;represented by the <xref:System.Linq.Expressions.LambdaExpression.Body> property.

The basic steps in constructing an <xref:System.Linq.Expressions.Expression%601> are as follows:

1. Define <xref:System.Linq.Expressions.ParameterExpression> objects for each of the parameters (if any) in the lambda expression, using the <xref:System.Linq.Expressions.Expression.Parameter%2A> factory method.
   :::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Factory_method_expression_tree_parameter":::
1. Construct the body of your <xref:System.Linq.Expressions.LambdaExpression>, using the <xref:System.Linq.Expressions.ParameterExpression> defined, and the factory methods at <xref:System.Linq.Expressions.Expression>. For instance, an expression representing `x.StartsWith("a")` could be constructed like this:
   :::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Factory_method_expression_tree_body":::
1. Wrap the parameters and body in a compile-time-typed [Expression\<TDelegate>](xref:System.Linq.Expressions.Expression%601), using the appropriate <xref:System.Linq.Expressions.Expression.Lambda%2A> factory method overload:
   :::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Factory_method_expression_tree_lambda":::

The following sections describe a scenario in which you might want to construct an <xref:System.Linq.Expressions.Expression%601> to pass into a LINQ method. It provides a complete example of how to do so using the factory methods.

## Construct a full query at run time

You want to write queries that work with multiple entity types:

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Entities":::

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

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Factory_methods_expression_of_tdelegate":::

Because the `TextFilter` function takes and returns an <xref:System.Linq.IQueryable%601> (and not just an <xref:System.Linq.IQueryable>), you can add further compile-time-typed query elements after the text filter.

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Factory_methods_expression_of_tdelegate_usage":::

### Add method call nodes to the IQueryable\<TDelegate>'s expression tree

If you have an <xref:System.Linq.IQueryable> instead of an <xref:System.Linq.IQueryable%601>, you can't directly call the generic LINQ methods. One alternative is to build the inner expression tree as shown in the previous example, and use reflection to invoke the appropriate LINQ method while passing in the expression tree.

You could also duplicate the LINQ method's functionality, by wrapping the entire tree in a <xref:System.Linq.Expressions.MethodCallExpression> that represents a call to the LINQ method:

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Factory_methods_lambdaexpression":::

In this case, you don't have a compile-time `T` generic placeholder, so you use the <xref:System.Linq.Expressions.Expression.Lambda%2A> overload that doesn't require compile-time type information, and which produces a <xref:System.Linq.Expressions.LambdaExpression> instead of an <xref:System.Linq.Expressions.Expression%601>.

### The Dynamic LINQ library

Constructing expression trees using factory methods is relatively complex; it's easier to compose strings. The [Dynamic LINQ library](https://dynamic-linq.net/) exposes a set of extension methods on <xref:System.Linq.IQueryable> corresponding to the standard LINQ methods at <xref:System.Linq.Queryable>, and which accept strings in a [special syntax](https://dynamic-linq.net/expression-language) instead of expression trees. The library generates the appropriate expression tree from the string, and can return the resultant translated <xref:System.Linq.IQueryable>.

For instance, the previous example could be rewritten as follows:

:::code language="csharp" source="./snippets/HowToBuildDynamicQueries/Program.cs" id="Dynamic_linq":::
