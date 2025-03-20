---
title: Tips for JavaScript and TypeScript Developers
description: "New to C#, but know JavaScript or TypeScript? Here's a roadmap of what's familiar, features in C# that aren't in JavaScript or TypeScript, and alternatives for features you use that aren't in C#"
ms.date: 03/17/2025
---
# Roadmap for JavaScript and TypeScript developers learning C\#

C#, TypeScript and JavaScript are all members of the C family of languages. The similarities between the languages help you quickly become productive in C#.

1. ***Similar syntax***: JavaScript, TypeScript, and C# are in the C family of languages. That similarity means you can already read and understand C#. There are some differences, but most of the syntax is the same as JavaScript, and C. The curly braces and semicolons are familiar. The control statements like `if`, `else`, `switch` are the same. The looping statements of `for`, `while`, and `do`...`while` are same. The same keywords for `class` and `interface` are in both C# and TypeScript. The access modifiers in TypeScript and C#, from `public` to `private`, are the same.
1. ***The `=>` token***: All languages support lightweight function definitions. In C#, they're referred to as [*lambda expressions*](../language-reference/operators/lambda-expressions.md), in JavaScript, they're typically called *arrow functions*.
1. ***Function hierarchies***: All three languages support [local functions](../programming-guide/classes-and-structs/local-functions.md), which are functions defined in other functions.
1. ***Async / Await***: All three languages share the same `async` and `await` keywords for asynchronous programming.
1. ***Garbage collection***: All three languages rely on a garbage collector for automatic memory management.
1. ***Event model***: C#'s [`event`](../events-overview.md) syntax is similar to JavaScript's model for document object model (DOM) events.
1. ***Package manager***: [NuGet](https://nuget.org) is the most common package manager for C# and .NET, similar to npm for JavaScript applications. C# libraries are delivered in [assemblies](../../standard/assembly/index.md).

As you learn C#, you learn concepts that aren't part of JavaScript. Some of these concepts might be familiar to you if you use TypeScript:

1. [***C# Type System***](../fundamentals/types/index.md): C# is a strongly typed language. Every variable has a type, and that type can't change. You define `class` or `struct` types. You can define [`interface`](../fundamentals/types/interfaces.md) definitions that define behavior implemented by other types. TypeScript includes many of these concepts, but because TypeScript is built on JavaScript, the type system isn't as strict.
1. [***Pattern matching***](../fundamentals/functional/pattern-matching.md): Pattern matching enables concise conditional statements and expressions based on the shape of complex data structures. The [`is` expression](../language-reference/operators/is.md) checks if a variable "is" some pattern. The pattern-based [`switch` expression](../language-reference/operators/switch-expression.md) provides a rich syntax to inspect a variable and make decisions based on its characteristics.
1. [***String interpolation***](../language-reference/tokens/interpolated.md) and [***raw string literals***](../language-reference/builtin-types/reference-types.md#string-literals): String interpolation enables you to insert evaluated expressions in a string, rather than using positional identifiers. Raw string literals provide a way to minimize escape sequences in text.
1. [***Nullable and non-nullable types***](../nullable-references.md): C# supports *nullable value types*, and *nullable reference types* by appending the `?` suffix to a type. For nullable types, the compiler warns you if you don't check for `null` before dereferencing the expression. For non-nullable types, the compiler warns you if you might be assigning a `null` value to that variable. These features can minimize your application throwing a <xref:System.NullReferenceException?displayProperty=nameWithType>. The syntax might be familiar from TypeScript's use of `?` for optional properties.
1. [***LINQ***](../linq/index.md): Language integrated query (LINQ) provides a common syntax to query and transform data, regardless of its storage.

As you learn more other differences become apparent, but many of those differences are smaller in scope.

Some familiar features and idioms from JavaScript and TypeScript aren't available in C#:

1. ***dynamic types***: C# uses static typing. A variable declaration includes the type, and that type can't change. There's a [`dynamic`](../language-reference/builtin-types/reference-types.md#the-dynamic-type) type in C# that provides runtime binding.
1. ***Prototypal inheritance***: C# inheritance is part of the type declaration. A C# `class` declaration states any base class. In JavaScript, you can set the `__proto__` property to set the base type on any instance.
1. ***Interpreted language***: C# code must be compiled before you run it. JavaScript code can be run directly in the browser.

In addition, a few more TypeScript features aren't available in C#:

1. ***Union types***: C# doesn't support union types. However, design proposals are in progress.
1. ***Decorators***: C# doesn't have decorators. Some common decorators, such as `@sealed` are reserved keywords in C#. Other common decorators might have corresponding [Attributes](../language-reference/attributes/general.md). For other decorators, you can create your own attributes.
1. ***More forgiving syntax***: The C# compiler parses code more strictly than JavaScript requires.

If you're building a web application, you should consider using [Blazor](/aspnet/core/blazor/index) to build your application. Blazor is a full-stack web framework built for .NET and C#. Blazor components can run on the server, as .NET assemblies, or on the client using WebAssembly. Blazor supports interop with your favorite JavaScript or TypeScript libraries.
