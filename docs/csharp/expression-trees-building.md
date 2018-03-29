---
title: Building Expression Trees
description: Learn about techniques for building expression trees.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 542754a9-7f40-4293-b299-b9f80241902c
---

# Building Expression Trees

[Previous -- Interpreting Expressions](expression-trees-interpreting.md)

All the expression trees you've seen so far have been created
by the C# compiler. All you had to do was create a lambda expression
that was assigned to a variable typed as an `Expression<Func<T>>` or
some similar type. That's not the only way to create an expression
tree. For many scenarios you may find that you need to build an
expression in memory at runtime. 

Building Expression Trees is complicated by the fact that those
expression trees are immutable. Being immutable means that you must
build the tree from the leaves up to the root. The APIs you'll use to
build expression trees reflect this fact: The methods you'll use to
build a node take all its children as arguments. Let's walk through
a few examples to show you the techniques.

## Creating Nodes

Let's start relatively simply again. We'll use the addition
expression I've been working with throughout these sections:

```csharp
Expression<Func<int>> sum = () => 1 + 2;
```

To construct that expression tree, you must construct the leaf nodes.
The leaf nodes are constants, so you can use the `Expression.Constant`
method to create the nodes:

```csharp
var one = Expression.Constant(1, typeof(int));
var two = Expression.Constant(2, typeof(int));
```

Next, you'll build the addition expression:

```csharp
var addition = Expression.Add(one, two);
```

Once you've got the addition expression, you can create the lambda
expression:

```csharp
var lamdba = Expression.Lambda(addition);
```

This is a very simple LambdaExpression, because it contains no arguments.
Later in this section, you'll see how to map arguments to parameters
and build more complicated expressions.

For expressions that are as simple as this one, you may combine all the
calls into a single statement:

```csharp
var lambda = Expression.Lambda(
    Expression.Add(
        Expression.Constant(1, typeof(int)),
        Expression.Constant(2, typeof(int))
    )
);
```

## Building a Tree

That's the basics of building an expression tree in memory. More
complex trees generally mean more node types, and more nodes in the
tree. Let's run through one more example and show two more node types
that you will typically build when you create expression trees:
the argument nodes, and method call nodes.

Let's build an expression tree to create this expression:

```csharp
Expression<Func<double, double, double>> distanceCalc =
    (x, y) => Math.Sqrt(x * x + y * y);
```
 
You'll start by creating parameter expressions for `x` and `y`:

```csharp
var xParameter = Expression.Parameter(typeof(double), "x");
var yParameter = Expression.Parameter(typeof(double), "y");
```

Creating the multiplication and addition expressions follows the pattern
you've already seen:

```csharp
var xSquared = Expression.Multiply(xParameter, xParameter);
var ySquared = Expression.Multiply(yParameter, yParameter);
var sum = Expression.Add(xSquared, ySquared);
```

Next, you need to create a method call expression for the call to
`Math.Sqrt`.

```csharp
var sqrtMethod = typeof(Math).GetMethod("Sqrt", new[] { typeof(double) });
var distance = Expression.Call(sqrtMethod, sum);
```

And  then finally, you put the method call into a lambda expression,
and make sure to define the arguments to the lambda expression:

```csharp
var distanceLambda = Expression.Lambda(
    distance,
    xParameter,
    yParameter);
```

In this more complicated example, you see a couple more techniques that
you will often need to create expression trees.

First, you need to create the objects that represent parameters or
local variables before you use them. Once you've created those objects,
you can use them in your expression tree wherever you need.

Second, you need to use a subset of the Reflection APIs to create a `MethodInfo` object
so that you can create an expression tree to access that method. You must limit
yourself to the subset of the Reflection APIs that are available on the .NET Core platform. Again,
these techniques will extend to other expression trees.

## Building Code In Depth

You aren't limited in what you can build using these APIs. However, the more
complicated expression tree that you want to build, the more difficult
the code is to manage and to read. 

Let's build an expression tree that is the equivalent of this code:

```csharp
Func<int, int> factorialFunc = (n) =>
{
    var res = 1;
    while (n > 1)
    {
        res = res * n;
        n--;
    }
    return res;
};
```

Notice above that I did not build the expression tree, but simply the delegate. Using
the `Expression` class, you can't build statement lambdas. Here's the code that is required
to build the same functionality. It's complicated by the fact that there isn't an API to build
a `while` loop, instead you need to build a loop that contains a conditional test, and a label
target to break out of the loop. 

```csharp
var nArgument = Expression.Parameter(typeof(int), "n");
var result = Expression.Variable(typeof(int), "result");

// Creating a label that represents the return value
LabelTarget label = Expression.Label(typeof(int));

var initializeResult = Expression.Assign(result, Expression.Constant(1));

// This is the inner block that performs the multiplication,
// and decrements the value of 'n'
var block = Expression.Block(
    Expression.Assign(result,
        Expression.Multiply(result, nArgument)),
    Expression.PostDecrementAssign(nArgument)
);

// Creating a method body.
BlockExpression body = Expression.Block(
    new[] { result },
    initializeResult,
    Expression.Loop(
        Expression.IfThenElse(
            Expression.GreaterThan(nArgument, Expression.Constant(1)),
            block,
            Expression.Break(label, result)
        ),
        label
    )
);
```

The code to build the expression tree for the factorial function is quite a bit longer,
more complicated, and it's riddled with labels and break statements and other elements
we'd like to avoid in our everyday coding tasks. 

For this section, I've also updated the visitor code to visit every node in this expression tree and write out information about the nodes that are created in this sample. You can [view or download the sample code](https://github.com/dotnet/samples/tree/master/csharp/expression-trees) at the dotnet/docs GitHub repository. Experiment for yourself by building and running the samples. For download instructions, see [Samples and Tutorials](../samples-and-tutorials/index.md#viewing-and-downloading-samples).

## Examining the APIs

The expression tree APIs are some of the more difficult to navigate in
.NET Core, but that's fine. Their purpose is a rather complex undertaking: writing code that generates
code at runtime. They are necessarily complicated to provide a balance between supporting
all the control structures available in the C# language and keeping the surface area
of the APIs as small as reasonable. This balance means that many control structures are
represented not by their C# constructs, but by constructs that represent the underlying
logic that the compiler generates from these higher level constructs. 

Also, at this time, there are C# expressions that cannot be built directly
using `Expression` class methods. In general, these will be the newest operators
and expressions added in C# 5 and C# 6. (For example, `async` expressions cannot be built, and
the new `?.` operator cannot be directly created.)

[Next -- Translating Expressions](expression-trees-translating.md)
