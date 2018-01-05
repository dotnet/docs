---
title: Expression Trees Summary
description: Recaps how you can use expression trees to create dynamic programs that interpret code as data and build new functionality based on that code.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: eb687ebd-1149-4453-9fc1-12a084495a66
---

# Expression Trees Summary

[Previous -- Translating Expressions](expression-trees-translating.md)

In this series, you've seen how you can use *expression trees* to
create dynamic programs that interpret code as data and build
new functionality based on that code.

You can examine expression trees to understand the intent of
an algorithm. You can not only examine that code. You can build new
expression trees that represent modified versions of the original code.

You can also use expression trees to look at an algorithm, and
translate that algorithm into another language or environment. 

## Limitations

There are some newer C# language elements that don't translate
well into expression trees. Expression trees cannot contain
`await` expressions, or `async` lambda expressions. Many of the
features added in the C# 6 release don't appear exactly as written
in expression trees. Instead, newer features will be exposed
in expressions trees in the equivalent, earlier syntax. This
may not be as much of a limitation as you might think. In fact,
it means that your code that interprets expression trees will likely
still work the same when new language features are introduced.

Even with these limitations, expression trees do enable you to
create dynamic algorithms that rely on interpreting and modifying
code that is represented as a data structure. It's a powerful
tool, and it's one of the features of the .NET ecosystem that
enables rich libraries such as Entity Framework to accomplish
what they do.

