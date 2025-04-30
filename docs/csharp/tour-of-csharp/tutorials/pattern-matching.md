---
title: Pattern matching
description: In this tutorial about pattern matching, you use your browser to learn C# interactively. You're going to write C# code and see the results of compiling and running your code directly in the browser.
ms.date: 04/30/2025
---
# Matching data against patterns

This tutorial teaches you how to use pattern matching to inspect data in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore different kinds of types in C#. These lessons teach you the fundamentals of the C# language.

> [!TIP]
> When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

The preceding tutorials demonstrated built in types and types you define as tuples or records. Instances of these types can be checked against a *pattern*. Whether an instance matches a pattern determines the actions your program takes. Let's start to explore how you can use patterns.

All the examples in this tutorial use the following data. Select "Run" to start the interactive window and copy this data into the window:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/PatternMatching/Program.cs" id="InputData":::

## Match a value with `is`

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/PatternMatching/Program.cs" id="IsOnTextValue":::

## Match on types

> [!WARNING]
> Don't copy and paste. The interactive window must be reset to run the following sample. If you make a mistake, the window hangs, and you need to refresh the page to continue.

:::code language="csharp" interactive="try-dotnet" source="./snippets/PatternMatching/FirstEnumExample.cs" id="IsEnumValue":::

## Exhaustive matches with `switch`

:::code language="csharp" interactive="try-dotnet" source="./snippets/PatternMatching/EnumSwitchExample.cs" id="SwitchEnumValue":::

The following code declares and uses a `record` type to represent a `Point`, and then uses that `Point` structure in the `Main` method:

:::code language="csharp" interactive="try-dotnet" source="./snippets/PatternMatching/FinalExampleProgram.cs" id="FinalProgram":::

You completed the "Introduction to pattern matching C#" interactive tutorial. You can visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding.

You can learn more about pattern matching in C# in the following articles:

- [Pattern matching in C#](../../fundamentals/functional/pattern-matching.md)
- [Explore pattern matching tutorial](../../tutorials/patterns-objects.md)
- [Pattern matching scenario](../../fundamentals/tutorials/pattern-matching.md)
