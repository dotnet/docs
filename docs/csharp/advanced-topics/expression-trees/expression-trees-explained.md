---
title: Expression tree data structures
description: Learn about expression trees and how they're useful in translating algorithms for external execution and inspecting code before executing it.
ms.date: 03/06/2023
---
# Expression trees - data that defines code

An Expression Tree is a data structure that defines code. Expression trees are based on the same structures that a compiler uses to analyze code and generate the compiled output. As you read this article, you notice quite a bit of similarity between Expression Trees and the types used in the Roslyn APIs to build [Analyzers and CodeFixes](https://github.com/dotnet/roslyn-analyzers). (Analyzers and CodeFixes are NuGet packages that perform static analysis on code and suggest potential fixes for a developer.) The concepts are similar, and the end result is a data structure that allows examination of the source code in a meaningful way. However, Expression Trees are based on a different set of classes and APIs than the Roslyn APIs. Here's a line of code:

```csharp
var sum = 1 + 2;
```

If you  analyze the preceding code as an expression tree, the tree contains several nodes. The outermost node is a variable declaration statement with assignment (`var sum = 1 + 2;`) That outermost node contains several child nodes: a variable declaration, an assignment operator, and an expression representing the right hand side of the equals sign. That expression is further subdivided into expressions that represent the addition operation, and left and right operands of the addition.

Let's drill down a bit more into the expressions that make up the right side of the equals sign. The expression is `1 + 2`, a binary expression. More specifically, it's a binary addition expression. A binary addition expression has two children, representing the left and right nodes of the addition expression. Here, both nodes are constant expressions: The left operand is the value `1`, and the right operand is the value `2`.

Visually, the entire statement is a tree: You could start at the root node, and travel to each node in the tree to see the code that makes up the statement:

- Variable declaration statement with assignment (`var sum = 1 + 2;`)
  - Implicit variable type declaration (`var sum`)
    - Implicit var keyword (`var`)
    - Variable name declaration (`sum`)
  - Assignment operator (`=`)
  - Binary addition expression (`1 + 2`)
    - Left operand (`1`)
    - Addition operator (`+`)
    - Right operand (`2`)

The preceding tree may look complicated, but it's very powerful. Following the same process, you decompose much more complicated expressions. Consider this expression:

```csharp
var finalAnswer = this.SecretSauceFunction(
    currentState.createInterimResult(), currentState.createSecondValue(1, 2),
    decisionServer.considerFinalOptions("hello")) +
    MoreSecretSauce('A', DateTime.Now, true);
```

The preceding expression is also a variable declaration with an assignment. In this instance, the right hand side of the assignment is a much more complicated tree. You're not going to decompose this expression, but consider what the different nodes might be. There are method calls using the current object as a receiver, one that has an explicit `this` receiver, one that doesn't. There are method calls using other receiver objects, there are constant arguments of different types. And finally, there's a binary addition operator. Depending on the return type of `SecretSauceFunction()` or `MoreSecretSauce()`, that binary addition operator may be a method call to an overridden addition operator, resolving to a static method call to the binary addition operator defined for a class.

Despite this perceived complexity, the preceding expression creates a tree structure navigated as easily as the first sample. You keep traversing child nodes to find leaf nodes in the expression. Parent nodes have references to their children, and each node has a property that describes what kind of node it is.

The structure of an expression tree is very consistent. Once you've learned the basics, you understand even the most complex code when it's represented
as an expression tree. The elegance in the data structure explains how the C# compiler analyzes the most complex C# programs and creates proper output from that complicated source code.

Once you become familiar with the structure of expression trees, you find that knowledge you've gained quickly enables you to work with many more advanced scenarios. There's incredible power to expression trees.

In addition to translating algorithms to execute in other environments, expression trees make it easier to write algorithms that inspect code before executing it. You write a method whose arguments are expressions and then examine those expressions before executing the code. The Expression Tree is a full representation of the code: you see values of any subexpression. You see method and property names. You see the value of any constant expressions. You convert an expression tree into an executable delegate, and execute the code.

The APIs for Expression Trees enable you to create trees that represent almost any valid code construct. However, to keep things as simple as possible, some C# idioms can't be created in an expression tree. One example is asynchronous expressions (using the `async` and `await` keywords). If your needs require asynchronous algorithms, you would need to manipulate the `Task` objects directly, rather than rely on the compiler support. Another is in creating loops. Typically, you create these loops by using `for`, `foreach`, `while` or `do` loops. As you see [later in this series](expression-trees-building.md), the APIs for expression trees support a single loop expression, with `break` and `continue` expressions that control repeating the loop.

The one thing you can't do is modify an expression tree.  Expression Trees are immutable data structures. If you want to mutate (change) an expression tree, you must create a new tree that is a copy of the original, but with your desired changes.
