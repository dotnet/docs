---
title: Introduction to delegates and events
description: The first in a series of articles about C# delegates and events. This article introduces basic concepts and discusses language design goals for delegates.
ms.date: 03/24/2022
ms.subservice: fundamentals
---

# Introduction to delegates and events in C\#

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

## Core terminology: methods, lambdas, and delegates

When working with late binding in C#, distinguishing between types, targets, and syntactic forms avoids confusion:

- **Delegate type** &mdash; A reference type that specifies a method signature (parameter types and return type). You define custom delegate types using the `delegate` keyword (such as `delegate int Comparison(Star x, Star y);`), or use built-in generic delegate types such as <xref:System.Func%602> and <xref:System.Action%601>.
- **Delegate instance** &mdash; An object created from a delegate type that holds a callable reference to one or more methods (along with their target object instances for instance methods).
- **Named method** &mdash; A standard declared method with an explicit identifier and body defined in a class, struct, or interface (for example, `static bool IsBright(Star s) => s.Magnitude < 2.0;`).
- **Method group** &mdash; The set of all methods bearing the same name in a type. When you pass a method name without parentheses (for example, `Sort(CompareStars)`), the compiler performs *method group conversion* by selecting the overload matching the target delegate signature.
- **Anonymous method (anonymous delegate)** &mdash; An inline method defined without a name using the `delegate` keyword and parameter list (such as `delegate(int x) { return x * 2; }`). Introduced in C# 2.0, anonymous methods are valid for backward compatibility.
- **Lambda expression** &mdash; A modern, compact syntax using the arrow operator `=>` (such as `x => x * 2`). Introduced in C# 3.0, lambda expressions supersede anonymous methods for nearly all scenarios because they provide clearer syntax and compiler type inference.

## Multicast delegate semantics and nuances

All delegate types in .NET inherit from <xref:System.MulticastDelegate?displayProperty=nameWithType>, which in turn derives from <xref:System.Delegate?displayProperty=nameWithType>. A delegate can hold a single callback target or chain multiple callbacks together into an *invocation list*.

When using multicast delegates, keep the following nuances in mind:

- **Combining and removing targets**: You combine callbacks using the addition operator (`+=`) or <xref:System.Delegate.Combine*?displayProperty=nameWithType>, and remove callbacks using the subtraction operator (`-=`) or <xref:System.Delegate.Remove*?displayProperty=nameWithType>.
- **Sequential invocation**: Callbacks in the invocation list are called synchronously in the exact order they were registered.
- **Return values**: If the delegate returns a value (such as `Func<int>`), invoking the multicast delegate returns the result of the **last** callback executed in the list. Results returned by earlier callbacks are discarded. For this reason, multicast delegates are most commonly used with `void` returns (such as `Action` delegates and event handlers).
- **Exception handling**: If any callback in the invocation list throws an unhandled exception, execution halts immediately and subsequent callbacks in the list are not invoked. To safely invoke all callbacks even if individual handlers fail, iterate the callbacks manually by calling <xref:System.Delegate.GetInvocationList*?displayProperty=nameWithType> within a `try/catch` loop.

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
