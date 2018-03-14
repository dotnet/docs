---
title: Introduction to Delegates
description: Learn about delegates in this overview topic that introduces basic concepts and discusses language design goals for delegates.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 59b61d77-84e5-457b-8da5-fb5f24ca6ed6
---

# Introduction to Delegates

[Previous](delegates-events.md)

Delegates provide a *late binding* mechanism in .NET. Late Binding
means that you create an algorithm where the caller also supplies
at least one method that implements part of the algorithm.

For example, consider sorting a list of stars in an astronomy application.
You may choose to sort those stars by their distance from the earth, or the
magnitude of the star, or their perceived brightness.

In all those cases, the Sort() method does essentially the same thing:
arranges the items in the list based on some comparison. The code that
compares two stars is different for each of the sort orderings.

These kinds of solutions have been used in software for half a century.
The C# language delegate concept provides first class language support,
and type safety around the concept.

As you'll see later in this series, the C# code you write for algorithms
like this is type safe, and leverages the language and the compiler to
ensure that the types match for arguments and return types.

## Language Design Goals for Delegates

The language designers enumerated several goals for the feature that
eventually became delegates.

The team wanted a common language construct that could be used for
any late binding algorithms. That enables developers to learn one
concept, and use that same concept across many different software
problems.

Second, the team wanted to support both single and multi-cast method
calls. (Multicast delegates are delegates where multiple methods have
been chained together. You'll see examples
[later in this series](delegate-class.md). 

The team wanted delegates to support the same type safety that developers
expect from all C# constructs. 

Finally, the team recognized that an event pattern is one specific pattern
where delegates, or any late binding algorithm) is very useful. The team
wanted to ensure that the code for delegates could provide the basis for
the .NET event pattern.

The result of all that work was the delegate and event support in C# and
.NET. The remaining articles in this section will cover the language
features, the library support, and the common idioms that are used
when you work with delegates.

You'll learn about the `delegate` keyword and what code it generates. You'll
learn about the features in the `System.Delegate` class, and how those features
are used. You'll learn how to create type safe delegates, and how to create methods
that can be invoked through delegates. You'll also learn how to work with delegates
and events by using Lambda expressions. You'll see where delegates become one of the
building blocks for LINQ. You'll learn how delegates are the basis for the .NET
event pattern, and how they are different.

Overall, you'll see how delegates are an integral part of programming in .NET
and working with the framework APIs.

Let's get started.

[Next](delegate-class.md)
