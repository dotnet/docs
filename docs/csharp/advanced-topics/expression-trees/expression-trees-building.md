---
title: Building Expression Trees
description: Learn about techniques for building expression trees.
ms.date: 03/07/2023
---
# Build expression trees

The C# compiler created all the expression trees you've seen so far. You created a lambda expression assigned to a variable typed as an `Expression<Func<T>>` or some similar type. For many scenarios, you build an expression in memory at run time.

Expression trees are immutable. Being immutable means that you must build the tree from the leaves up to the root. The APIs you use to build expression trees reflect this fact: The methods you use to build a node take all its children as arguments. Let's walk through a few examples to show you the techniques.

## Create nodes

You start with the addition expression you've been working with throughout these sections:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="AddExpression":::

To construct that expression tree, you first construct the leaf nodes. The leaf nodes are constants. Use the <xref:System.Linq.Expressions.Expression.Constant%2A> method to create the nodes:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="BuildConstantLeaves":::

Next, build the addition expression:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="BuildAdditionNode":::

Once you've built the addition expression, you create the lambda expression:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="BuildLambdaExpression":::

This lambda expression contains no arguments. Later in this section, you see how to map arguments to parameters and build more complicated expressions.

For expressions like this one, you may combine all the calls into a single statement:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="SingleExpression":::

## Build a tree

The previous section showed the basics of building an expression tree in memory. More complex trees generally mean more node types, and more nodes in the tree. Let's run through one more example and show two more node types that you typically build when you create expression trees: the argument nodes, and method call nodes. Let's build an expression tree to create this expression:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="SquareRootLambda":::

You start by creating parameter expressions for `x` and `y`:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="BuildParameters":::

Creating the multiplication and addition expressions follows the pattern you've already seen:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="BuildSumOfSquare":::

Next, you need to create a method call expression for the call to `Math.Sqrt`.

:::code language="csharp" source="snippets/BuildExpressions.cs" id="DistanceMethod":::

The `GetMethod` call could return `null` if the method isn't found. Most likely that's because you've mis-spelled the method name. Otherwise, it could mean the required assembly isn't loaded. Finally, you put the method call into a lambda expression, and make sure to define the arguments to the lambda expression:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="CreateLambda":::

In this more complicated example, you see a couple more techniques that you often need to create expression trees.

First, you need to create the objects that represent parameters or local variables before you use them. Once you've created those objects, you can use them in your expression tree wherever you need.

Second, you need to use a subset of the Reflection APIs to create a `MethodInfo` object so that you can create an expression tree to access that method. You must limit
yourself to the subset of the Reflection APIs that are available on the .NET Core platform. Again, these techniques extend to other expression trees.

## Build code in depth

You aren't limited in what you can build using these APIs. However, the more complicated expression tree that you want to build, the more difficult the code is to manage and to read.

Let's build an expression tree that is the equivalent of this code:

:::code language="csharp" source="snippets/BuildExpressions.cs" id="FactorialFunc":::

The preceding code didn't build the expression tree, but simply the delegate. Using the `Expression` class, you can't build statement lambdas. Here's the code that is required to build the same functionality. There isn't an API for building a `while` loop, instead you need to build a loop that contains a conditional test, and a label target to break out of the loop.

:::code language="csharp" source="snippets/BuildExpressions.cs" id="BuildFactorialFunc":::

The code to build the expression tree for the factorial function is quite a bit longer, more complicated, and it's riddled with labels and break statements and other elements we'd like to avoid in our everyday coding tasks.

For this section, I've also updated the visitor code to visit every node in this expression tree and write out information about the nodes that are created in this sample. You can [view or download the sample code](https://github.com/dotnet/samples/tree/main/csharp/expression-trees) at the dotnet/docs GitHub repository. Experiment for yourself by building and running the samples.

## Examine the APIs

The expression tree APIs are some of the more difficult to navigate in .NET Core, but that's fine. Their purpose is a rather complex undertaking: writing code that generates code at run time. They're necessarily complicated to provide a balance between supporting all the control structures available in the C# language and keeping the surface area of the APIs as small as reasonable. This balance means that many control structures aren't represented by their C# constructs, but by constructs that represent the underlying logic that the compiler generates from these higher level constructs.

Also, at this time, there are C# expressions that can't be built directly using `Expression` class methods. The list is included in the Overview article in the section on [restrictions on language syntax](./index.md#restrictions-on-language-syntax).
