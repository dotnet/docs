---
title: .NET Runtime support for expression trees
description: Learn about .NET runtime types supporting expression trees, creating expression trees, and techniques for working with expression tree APIs.
ms.date: 03/06/2023
ms.topic: article
---

# .NET Runtime support for expression trees

There's a large list of classes in the .NET runtime that work with Expression Trees. You can see the full list at <xref:System.Linq.Expressions>. Rather than enumerate the full list, let's understand how the runtime classes have been designed.

In language design, an expression is a body of code that evaluates and returns a value. Expressions may be simple: the constant expression `1` returns the constant value of 1. They may be more complicated: The expression `(-B + Math.Sqrt(B*B - 4 * A * C)) / (2 * A)` returns one root for a quadratic equation (in the case where the equation has a solution).

## System.Linq.Expression and derived types

One of the complexities of working with expression trees is that many different kinds of expressions are valid in many places in programs. Consider an assignment expression. The right hand side of an assignment could be a constant value, a variable, a method call expression, or others. That language flexibility means that you may encounter many different expression types anywhere in the nodes of a tree when you traverse an expression tree. Therefore, when you work with the base expression type, that's the simplest way to work. However, sometimes you need to know more. The base Expression class contains a `NodeType` property for this purpose. It returns an `ExpressionType`, which is an enumeration of possible expression types. Once you know the type of the node, you cast it to that type, and perform specific actions knowing the type of the expression node. You can search for certain node types, and then work with the specific properties of that kind of expression.

For example, this code prints the name of a variable for a variable access expression. The following code shows the practice of checking the node type, then casting to a variable access expression and then checking the properties of the specific expression type:

```csharp
Expression<Func<int, int>> addFive = (num) => num + 5;

if (addFive is LambdaExpression lambdaExp)
{
    var parameter = lambdaExp.Parameters[0];  -- first

    Console.WriteLine(parameter.Name);
    Console.WriteLine(parameter.Type);
}
```

## Create expression trees

The `System.Linq.Expression` class also contains many static methods to create expressions. These methods create an expression node using the arguments supplied for its children. In this way, you build up an expression from its leaf nodes. For example, this code builds an Add expression:

```csharp
// Addition is an add expression for "1 + 2"
var one = Expression.Constant(1, typeof(int));
var two = Expression.Constant(2, typeof(int));
var addition = Expression.Add(one, two);
```

You can see from this simple example that many types are involved in creating and working with expression trees. That complexity is necessary to provide the capabilities of the rich vocabulary provided by the C# language.

## Navigate the APIs

There are Expression node types that map to almost all of the syntax elements of the C# language. Each type has specific methods for that type of language element. It's a lot to keep in your head at one time. Rather than try to memorize everything, here are the techniques you use to work with Expression trees:

1. Look at the members of the `ExpressionType` enum to determine possible nodes you should be examining. This list helps when you want to traverse and understand an expression tree.
1. Look at the static members of the `Expression` class to build an expression. Those methods can build any expression type from a set of its child nodes.
1. Look at the `ExpressionVisitor` class to build a modified expression tree.

You find more as you look at each of those three areas. Invariably, you find what you need when you start with one of those three steps.
