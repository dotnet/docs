---
title: Expression Trees
description: Learn about expression trees in .NET Core and how to use them to represent code as structures that you can examine, modify, and execute.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: aceb4719-0d5a-4b19-b01f-b51063bcc54f
---

# Expression Trees

If you have used LINQ, you have experience with a rich library
where the `Func` types are part of the API set. (If you are not familiar
with LINQ, you probably want to read [the LINQ tutorial](linq/index.md) and
the tutorial on [lambda expressions](lambda-expressions.md) before this one.)
*Expression Trees* provide richer interaction with the arguments that
are functions.

You write function arguments, typically using Lambda Expressions, when
you create LINQ queries. In a typical LINQ query, those function arguments are
transformed into a delegate the compiler creates. 

When you want to have a richer interaction, you need to use *Expression Trees*.
Expression Trees represent code as a structure that you can examine,
modify, or execute. These tools give you the power to manipulate code during
run time. You can write code that examines running algorithms, or injects new
capabilities. In more advanced scenarios, you can modify running algorithms,
and even translate C# expressions into another form for execution in another
environment.

You've likely already written code that uses Expression Trees. Entity Framework's
LINQ APIs accept Expression Trees as the arguments for the LINQ Query Expression Pattern.
That enables [Entity Framework](http://docs.efproject.net/en/latest/) to translate the query you wrote in C# into SQL
that executes in the database engine. Another example is [Moq](https://github.com/Moq/moq),
which is a popular mocking framework for .NET.

The remaining sections of this tutorial will explore what Expression Trees are,
examine the framework classes that support expression trees, and show you how to work
with expression trees. You'll learn how to read expression trees, how to create
expression trees, how to create modified expression trees, and how to execute the
code represented by expression trees. After reading, you will be ready to use these
structures to create rich adaptive algorithms.

1. [Expression Trees Explained](expression-trees-explained.md)

    Understand the structure and concepts behind *Expression Trees*.
    
2. [Framework Types Supporting Expression Trees](expression-classes.md)
    
    Learn about the structures and classes that define and manipulate expression trees.
    
3. [Executing Expressions](expression-trees-execution.md)

    Learn how to convert an expression tree represented as a Lambda Expression into a delegate and execute the resulting delegate.

4. [Interpreting Expressions](expression-trees-interpreting.md)

    Learn how to traverse and examine *expression trees* to understand what code the expression tree represents.

5. [Building Expressions](expression-trees-building.md)

    Learn how to construct the nodes for an expression tree and build expression trees.

6. [Translating Expressions](expression-trees-translating.md)

    Learn how to build a modified copy of an expression tree, or translate an expression tree into a different format.

7. [Summing up](expression-trees-summary.md)

    Review the information on expression trees.
    
