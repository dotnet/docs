---
title: "Language features that support LINQ"
description: Learn about C# features to use with LINQ queries and in other contexts.
ms.date: 12/01/2025
ai-usage: ai-assisted
helpviewer_keywords:
  - "LINQ [C#], features supporting LINQ"
---
# C# features that support LINQ

## Query expressions

Query expressions use a declarative syntax similar to SQL or XQuery to query over <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> collections. At compile time, the compiler converts query syntax to method calls to a LINQ provider's implementation of the standard query methods. Applications control the standard query operators that are in scope by specifying the appropriate namespace with a [`using`](../../language-reference/keywords/using-directive.md) directive. The following query expression takes an array of strings, groups them according to the first character in the string, and orders the groups.

```csharp
var query = from str in stringArray
            group str by str[0] into stringGroup
            orderby stringGroup.Key
            select stringGroup;
```

## Implicitly typed variables (var)

You can use the [var](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) modifier to instruct the compiler to infer and assign the type, as shown here:

```csharp
var number = 5;
var name = "Virginia";
var query = from str in stringArray
            where str[0] == 'm'
            select str;
```

Variables declared as `var` are strongly typed, just like variables whose type you specify explicitly. Using `var` makes it possible to create anonymous types, but only for local variables. For more information, see [Implicitly Typed Local Variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md).

## Object and collection initializers

Object and collection initializers make it possible to initialize objects without explicitly calling a constructor for the object. You typically use initializers in query expressions when they project the source data into a new data type. Assuming a class named `Customer` with public `Name` and `Phone` properties, you can use the object initializer as in the following code:

```csharp
var cust = new Customer { Name = "Mike", Phone = "555-1212" };
```

Continuing with your `Customer` class, assume that there's a data source called `IncomingOrders`, and that for each order with a large `OrderSize`, you want to create a new `Customer` based off of that order. You can execute a LINQ query on this data source and use object initialization to fill a collection:

```csharp
var newLargeOrderCustomers = from o in IncomingOrders
                            where o.OrderSize > 5
                            select new Customer { Name = o.Name, Phone = o.Phone };
```

The data source might have more properties defined than the `Customer` class such as `OrderSize`, but with object initialization, the data returned from the query is molded into the desired data type; you choose the data that's relevant to your class. As a result, you now have an <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> filled with the new `Customer`s you wanted. You can also write the preceding example in LINQ's method syntax:

```csharp
var newLargeOrderCustomers = IncomingOrders.Where(x => x.OrderSize > 5).Select(y => new Customer { Name = y.Name, Phone = y.Phone });
```

Beginning with C# 12, you can use a [collection expression](../../language-reference/operators/collection-expressions.md) to initialize a collection.

For more information, see:

- [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md)
- [Query Expression Syntax for Standard Query Operators](../standard-query-operators/index.md)

## Anonymous types

The compiler constructs an [anonymous type](../../fundamentals/types/anonymous-types.md). Only the compiler can access the type name. Anonymous types provide a convenient way to group a set of properties temporarily in a query result without having to define a separate named type. You initialize anonymous types with a new expression and an object initializer, as shown here:

```csharp
select new {name = cust.Name, phone = cust.Phone};
```

Beginning with C# 7, you can use [tuples](../../language-reference/builtin-types/value-tuples.md) to create unnamed types.

## Extension members

An [extension member](../../programming-guide/classes-and-structs/extension-methods.md) is a static member of a static class associated with a type called the *receiver type*. You can call an extension member as if it were a member of the receiver type. This feature enables you to "add" new members to existing types without actually modifying them. The standard query operators are a set of extension methods that provide LINQ query functionality for any type that implements <xref:System.Collections.Generic.IEnumerable%601>.

## Lambda expressions

A [lambda expression](../../language-reference/operators/lambda-expressions.md) is an inline function that uses the `=>` operator to separate input parameters from the function body and can be converted at compile time to a delegate or an expression tree. In LINQ programming, you encounter lambda expressions when you make direct method calls to the standard query operators.

## Expressions as data

Query objects are composable, meaning that you can return a query from a method. Objects that represent queries don't store the resulting collection, but rather the steps to produce the results when needed. The advantage of returning query objects from methods is that you can further compose or modify them. Therefore, any return value or `out` parameter of a method that returns a query must also have that type. If a method materializes a query into a concrete <xref:System.Collections.Generic.List%601> or <xref:System.Array> type, it returns the query results instead of the query itself. You can still compose or modify a query variable that's returned from a method.
  
In the following example, the first method `QueryMethod1` returns a query as a return value, and the second method `QueryMethod2` returns a query as an `out` parameter (`returnQ` in the example). In both cases, it's a query that's returned, not query results.

:::code language="csharp" source="./snippets/SnippetApp/ReturnQueryFromMethod.cs" id="return_query_from_method_1":::

The following `foreach` loop executes query `myQuery1`.

:::code language="csharp" source="./snippets/SnippetApp/ReturnQueryFromMethod.cs" id="return_query_from_method_2":::

Rest the mouse pointer over `myQuery1` to see its type.

You can also execute the query returned from `QueryMethod1` directly, without using `myQuery1`.

:::code language="csharp" source="./snippets/SnippetApp/ReturnQueryFromMethod.cs" id="return_query_from_method_3":::

Rest the mouse pointer over the call to `QueryMethod1` to see its return type.

`QueryMethod2` returns a query as the value of its `out` parameter:

:::code language="csharp" source="./snippets/SnippetApp/ReturnQueryFromMethod.cs" id="return_query_from_method_4":::

You can modify a query by using query composition. In this case, the previous query object is used to create a new query object. This new object returns different results than the original query object.

:::code language="csharp" source="./snippets/SnippetApp/ReturnQueryFromMethod.cs" id="return_query_from_method_5":::
