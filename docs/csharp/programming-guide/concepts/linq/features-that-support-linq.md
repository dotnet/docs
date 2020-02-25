---
title: "C# Features That Support LINQ"
ms.date: 07/20/2015
helpviewer_keywords:
  - "LINQ [C#], features supporting LINQ"
ms.assetid: 524b0078-ebfd-45a7-b390-f2ceb9d84797
---
# C# Features That Support LINQ

The following section introduces new language constructs introduced in C# 3.0. Although these new features are all used to a degree with LINQ queries, they are not limited to LINQ and can be used in any context where you find them useful.

## Query Expressions

Query expressions use a declarative syntax similar to SQL or XQuery to query over IEnumerable collections. At compile time query syntax is converted to method calls to a LINQ provider's implementation of the standard query operator extension methods. Applications control the standard query operators that are in scope by specifying the appropriate namespace with a `using` directive. The following query expression takes an array of strings, groups them according to the first character in the string, and orders the groups.

```csharp
var query = from str in stringArray
            group str by str[0] into stringGroup
            orderby stringGroup.Key
            select stringGroup;
```

For more information, see [LINQ Query Expressions](../../../linq/index.md).

## Implicitly Typed Variables (var)

Instead of explicitly specifying a type when you declare and initialize a variable, you can use the [var](../../../language-reference/keywords/var.md) modifier to instruct the compiler to infer and assign the type, as shown here:

```csharp
var number = 5;
var name = "Virginia";
var query = from str in stringArray
            where str[0] == 'm'
            select str;
```

Variables declared as `var` are just as strongly-typed as variables whose type you specify explicitly. The use of `var` makes it possible to create anonymous types, but it can be used only for local variables. Arrays can also be declared with implicit typing.

For more information, see [Implicitly Typed Local Variables](../../classes-and-structs/implicitly-typed-local-variables.md).

## Object and Collection Initializers

Object and collection initializers make it possible to initialize objects without explicitly calling a constructor for the object. Initializers are typically used in query expressions when they project the source data into a new data type. Assuming a class named `Customer` with public `Name` and `Phone` properties, the object initializer can be used as in the following code:

```csharp
var cust = new Customer { Name = "Mike", Phone = "555-1212" };
```

Continuing with our `Customer` class, assume that there is a data source called `IncomingOrders`, and that for each order with a large `OrderSize`, we would like to create a new `Customer` based off of that order. A LINQ query can be executed on this data source and use object initialization to fill a collection:

```csharp
var newLargeOrderCustomers = from o in IncomingOrders
                            where o.OrderSize > 5
                            select new Customer { Name = o.Name, Phone = o.Phone };
```

The data source may have more properties lying under the hood than the `Customer` class such as `OrderSize`, but with object initialization, the data returned from the query is molded into the desired data type; we choose the data that is relevant to our class. As a result, we now have an `IEnumerable` filled with the new `Customer`s we wanted. The above can also be written in LINQ's method syntax:

```csharp
var newLargeOrderCustomers = IncomingOrders.Where(x => x.OrderSize > 5).Select(y => new Customer { Name = y.Name, Phone = y.Phone });
```

For more information, see:

- [Object and Collection Initializers](../../classes-and-structs/object-and-collection-initializers.md)

- [Query Expression Syntax for Standard Query Operators](./query-expression-syntax-for-standard-query-operators.md)

## Anonymous Types

An anonymous type is constructed by the compiler and the type name is only available to the compiler. Anonymous types provide a convenient way to group a set of properties temporarily in a query result without having to define a separate named type. Anonymous types are initialized with a new expression and an object initializer, as shown here:

```csharp
select new {name = cust.Name, phone = cust.Phone};
```

For more information, see [Anonymous Types](../../classes-and-structs/anonymous-types.md).

## Extension Methods

An extension method is a static method that can be associated with a type, so that it can be called as if it were an instance method on the type. This feature enables you to, in effect, "add" new methods to existing types without actually modifying them. The standard query operators are a set of extension methods that provide LINQ query functionality for any type that implements <xref:System.Collections.Generic.IEnumerable%601>.

For more information, see [Extension Methods](../../classes-and-structs/extension-methods.md).

## Lambda Expressions

A lambda expression is an inline function that uses the => operator to separate input parameters from the function body and can be converted at compile time to a delegate or an expression tree. In LINQ programming, you will encounter lambda expressions when you make direct method calls to the standard query operators.

For more information, see:

- [Anonymous Functions](../../statements-expressions-operators/anonymous-functions.md)

- [Lambda Expressions](../../statements-expressions-operators/lambda-expressions.md)

- [Expression Trees (C#)](../expression-trees/index.md)

## See also

- [Language-Integrated Query (LINQ) (C#)](./index.md)
