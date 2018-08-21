---
title: F# style guide
description: Learn the five principles of good F# code.
ms.date: 05/14/2018
---
# F# style guide

The following articles describe guidelines for formatting F# code and topical guidance for features of the language and how they should be used.

This guidance has been formulated based on the use of F# in large codebases with a diverse group of programmers. This guidance generally leads to successful use of F# and minimizes frustrations when requirements for programs change over time.

## Five principles of good F# code

You should keep the following principles in mind any time you write F# code, especially in systems that will change over time. Every piece of guidance in further articles stems from these five points.

1. **Good F# code is succinct and expressive**

    F# has many features that allow you to express actions in fewer lines of code and reuse generic functionality. The F# core library also contains many useful types and functions for working with common collections of data. As a general rule, if you can express a solution to a problem in fewer lines of code, other developers (or your future self) will be appreciative. It is also highly recommended that you use a library such as FSharp.Core, the [vast .NET libraries](https://docs.microsoft.com/dotnet/api/) that F# runs on, or a third-party package on [NuGet](https://www.nuget.org/) when you need to do a nontrivial task.

2. **Good F# code is interoperable**

    Interoperation can take multiple forms, including consuming code in different languages. The boundaries of your code that other callers interoperate with are critical pieces to get right. When writing F#, you should always be thinking about how other code will call into the code you are writing, including if they do so from another language like C#. The [F# Component Design Guidelines](component-design-guidelines.md) describe interoperability in detail.

3. **Good F# code makes use of object programming, not object orientation**

    F# has full support for programming with objects in .NET, including [classes](../language-reference/classes.md), [interfaces](../language-reference/interfaces.md), [access modifiers](../language-reference/access-control.md), [abstract classes](../language-reference/abstract-classes.md), and so on. For more complicated functional code, such as functions that must be context-aware, objects can easily encapsulate contextual information in ways that functions cannot. Features such as [optional parameters](../language-reference/members/methods.md#optional-arguments) and careful use of [overloading](../language-reference/members/methods.md#overloaded-methods) can make consumption of this functionality easier for callers.

4. **Good F# code performs well without exposing mutation**

    It's no secret that to write high-performance code, you must use mutation. It's how computers work, after all. Such code is often error-prone and difficult to get right. Avoid exposing mutation to callers. Instead, [build a functional interface that hides a mutation-based implementation](conventions.md#performance) when performance is critical.

5. **Good F# code is toolable**

    Tools are invaluable for working in large codebases, and you can write F# code such that it can be used more effectively with F# language tooling. One example is making sure you don't overdo it with a point-free style of programming, so that intermediate values can be inspected with a debugger. Another example is using [XML documentation comments](../language-reference/xml-documentation.md) describing constructs such that tooltips in editors can display those comments at the call site. Always think about how your code will be read, navigated, debugged, and manipulated by other programmers with their tools.

## Next steps

The [F# code formatting guidelines](formatting.md) provide guidance on how to format code so that it is easy to read.

The [F# coding conventions](conventions.md) provide guidance for F# programming idioms that will help the long-term maintenance of larger F# codebases.

The [F# component design guidelines](component-design-guidelines.md) provide guidance for authoring F# components, such as libraries.
