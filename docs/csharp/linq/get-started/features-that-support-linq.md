---
title: "C# Features That Support LINQ"
description: Learn about C# features to use with LINQ queries and in other contexts.
ms.date: 12/14/2023
helpviewer_keywords:
  - "LINQ [C#], features supporting LINQ"
---
# C# Features That Support LINQ

## Query Expressions

Query expressions use a declarative syntax similar to SQL or XQuery to query over <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> collections. At compile time, query syntax is converted to method calls to a LINQ provider's implementation of the standard query methods. Applications control the standard query operators that are in scope by specifying the appropriate namespace with a [`using`](../../language-reference/keywords/using-directive.md) directive. The following query expression takes an array of strings, groups them according to the first character in the string, and orders the groups.

```csharp
var query = from str in stringArray
            group str by str[0] into stringGroup
            orderby stringGroup.Key
            select stringGroup;
```

## Implicitly Typed Variables (var)

You can use the [var](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) modifier to instruct the compiler to infer and assign the type, as shown here:

```csharp
var number = 5;
var name = "Virginia";
var query = from str in stringArray
            where str[0] == 'm'
            select str;
```

Variables declared as `var` are strongly typed, just like variables whose type you specify explicitly. The use of `var` makes it possible to create anonymous types, but only for local variables. For more information, see [Implicitly Typed Local Variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md).

## Object and Collection Initializers

Object and collection initializers make it possible to initialize objects without explicitly calling a constructor for the object. Initializers are typically used in query expressions when they project the source data into a new data type. Assuming a class named `Customer` with public `Name` and `Phone` properties, the object initializer can be used as in the following code:

```csharp
var cust = new Customer { Name = "Mike", Phone = "555-1212" };
```

Continuing with your `Customer` class, assume that there's a data source called `IncomingOrders`, and that for each order with a large `OrderSize`, you would like to create a new `Customer` based off of that order. A LINQ query can be executed on this data source and use object initialization to fill a collection:

```csharp
var newLargeOrderCustomers = from o in IncomingOrders
                            where o.OrderSize > 5
                            select new Customer { Name = o.Name, Phone = o.Phone };
```

The data source might have more properties defined than the `Customer` class such as `OrderSize`, but with object initialization, the data returned from the query is molded into the desired data type; you choose the data that is relevant to your class. As a result, you now have an <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> filled with the new `Customer`s you wanted. The preceding example can also be written in LINQ's method syntax:

```csharp
var newLargeOrderCustomers = IncomingOrders.Where(x => x.OrderSize > 5).Select(y => new Customer { Name = y.Name, Phone = y.Phone });
```

Beginning with C# 12, you can use a [collection expression](../../language-reference/operators/collection-expressions.md) to initialize a collection.

For more information, see:

- [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md)
- [Query Expression Syntax for Standard Query Operators](../../programming-guide/concepts/linq/standard-query-operators-overview.md)

## Anonymous Types

The compiler constructs an [anonymous type](../../fundamentals/types/anonymous-types.md). The type name is only available to the compiler. Anonymous types provide a convenient way to group a set of properties temporarily in a query result without having to define a separate named type. Anonymous types are initialized with a new expression and an object initializer, as shown here:

```csharp
select new {name = cust.Name, phone = cust.Phone};
```

Beginning with C# 7, you can use [tuples](../../language-reference/builtin-types/value-tuples.md) to create unnamed types.

## Extension Methods

An [extension method](../../programming-guide/classes-and-structs/extension-methods.md) is a static method that can be associated with a type, so that it can be called as if it were an instance method on the type. This feature enables you to, in effect, "add" new methods to existing types without actually modifying them. The standard query operators are a set of extension methods that provide LINQ query functionality for any type that implements <xref:System.Collections.Generic.IEnumerable%601>.

## Lambda Expressions

A [lambda expressions](../../language-reference/operators/lambda-expressions.md) is an inline function that uses the `=>` operator to separate input parameters from the function body and can be converted at compile time to a delegate or an expression tree. In LINQ programming, you encounter lambda expressions when you make direct method calls to the standard query operators.
