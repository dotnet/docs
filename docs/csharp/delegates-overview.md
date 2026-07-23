---
title: Introduction to delegates and events
description: The first in a series of articles about C# delegates and events. This article introduces basic concepts and discusses language design goals for delegates.
ms.date: 03/24/2022
ms.subservice: fundamentals
---
# Introduction to delegates and events

## Preface

According to the Copilot research; a delegate is someone authorized to represent others. To paraphrase this definition, in terms of a programming language, the delegate is a construct representing another language construct. Consequently, using object-oriented programming terminology, a delegate is an object wrapping a reference to a method (an action that happens). The method is invoked while the delegate is triggered. Simplifying, delegate represents an activity.

Continuing the Copilot research; “event” refers to an occurrence or happening that involves one or more entities and can be described by a verb or action. To paraphrase this definition, in terms of a programming language, the event is an action (block of statements) invoked and executed using a computer machine. Consequently, using object-oriented programming terminology, an event may be recognized as an object wrapping a reference to a method (an action that happens). The method is invoked while the event is triggered. Simplifying, an event represents activity.

Hence, in the context of program engineering, despite the meanings of both terms being completely different it seems that both terms can be implemented similarly. However, before implementation, we must learn more details concerning both terms. The most important thing is the difference between them, which helps address the problem of why we need both terms.

## Introduction to delegates in C\#

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
like this is type safe. The compiler ensures that the types match for arguments and return types.

[Function pointers](language-reference/unsafe-code.md#function-pointers) support similar scenarios, where you need more control over the calling convention. The code associated with a delegate is invoked using a virtual method added to a delegate type. Using function pointers, you can specify different conventions.

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
where delegates, or any late binding algorithm, is useful. The team
wanted to ensure the code for delegates could provide the basis for
the .NET event pattern.

The result of all that work was the delegate and event support in C# and
.NET.

The remaining articles in this series will cover language
features, library support, and common idioms used
when you work with delegates and events.
You'll learn about:

* The `delegate` keyword and what code it generates.
* The features in the `System.Delegate` class, and how those features are used.
* How to create type-safe delegates.
* How to create methods that can be invoked through delegates.
* How to work with delegates and events by using lambda expressions.
* How delegates become one of the building blocks for LINQ.
* How delegates are the basis for the .NET event pattern, and how they're different.

Let's get started.

[Next](delegate-class.md)
