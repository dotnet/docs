---
title: Introduction to Delegates
description: Learn about delegates in this overview article that introduces basic concepts and discusses language design goals for delegates.
ms.date: 02/02/2021
ms.technology: csharp-fundamentals
ms.assetid: 59b61d77-84e5-457b-8da5-fb5f24ca6ed6
---

# Introduction to Delegates

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
like this is type safe, and uses the language rules and the compiler to
ensure that the types match for arguments and return types.

[Function pointers](language-reference/unsafe-code.md#function-pointers) were added to C# 9 for similar scenarios, where you need more control over the calling convention. The code associated with a delegate is invoked using a virtual method added to a delegate type. Using function pointers, you can specify different conventions.

## Language Design Goals for Delegates

The language designers enumerated several goals for the feature that
eventually became delegates.

The team wanted a common language construct that could be used for
any late binding algorithms. Delegates enable developers to learn one
concept, and use that same concept across many different software
problems.

Second, the team wanted to support both single and multicast method
calls. (Multicast delegates are delegates that chain together multiple method calls.
You'll see examples
[later in this series](delegate-class.md).)

The team wanted delegates to support the same type safety that developers
expect from all C# constructs.

Finally, the team recognized an event pattern is one specific pattern
where delegates, or any late binding algorithm, is very useful. The team
wanted to ensure the code for delegates could provide the basis for
the .NET event pattern.

The result of all that work was the delegate and event support in C# and
.NET. The remaining articles in this section will cover language
features, library support, and common idioms used
when you work with delegates.

You'll learn about the `delegate` keyword and what code it generates. You'll
learn about the features in the `System.Delegate` class, and how those features
are used. You'll learn how to create type safe delegates, and how to create methods
that can be invoked through delegates. You'll also learn how to work with delegates
and events by using Lambda expressions. You'll see where delegates become one of the
building blocks for LINQ. You'll learn how delegates are the basis for the .NET
event pattern, and how they're different.

Let's get started.

[Next](delegate-class.md)
