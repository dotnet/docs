---
title: A tour of C# - Overview
description: New to C#? Learn the basics of the language. Start with this overview.
ms.date: 03/14/2022
---

# A tour of the C# language

## Hello world

The "Hello, World" program is traditionally used to introduce a programming language. Here it is in C#:

:::code language="csharp" interactive="try-dotnet" source="./snippets/shared/HelloWorld.cs":::

The "Hello, World" program starts with a `using` directive that references the `System` namespace. Namespaces provide a hierarchical means of organizing C# programs and libraries. Namespaces contain types and other namespaces—for example, the `System` namespace contains a number of types, such as the `Console` class referenced in the program, and many other namespaces, such as `IO` and `Collections`. A `using` directive that references a given namespace enables unqualified use of the types that are members of that namespace. Because of the `using` directive, the program can use `Console.WriteLine` as shorthand for `System.Console.WriteLine`.

The `Hello` class declared by the "Hello, World" program has a single member, the method named `Main`. The `Main` method is declared with the `static` modifier. While instance methods can reference a particular enclosing object instance using the keyword `this`, static methods operate without reference to a particular object. By convention, a static method named `Main` serves as the entry point of a C# program.

The line starting with `//` is a *single line comment*. C# single line comments start with  `//` and continue to the end of the current line. C# also supports *multi-line comments*. Multi-line comments start with `/*` and end with `*/`. The output of the program is produced by the `WriteLine` method of the `Console` class in the `System` namespace. This class is provided by the standard class libraries, which, by default, are automatically referenced by the compiler.

You use the [.NET SDK](https://dotnet.microsoft.com/download) to build your own "Hello, World" program. Once you install the SDK, you run `dotnet new console` to create a basic "Hello, World" program that you can modify. For more information, see the [Hello, World tutorial](../../core/get-started.md) in the .NET Get started section.

## New outline

- Basic structure
- Foundations
- Learning roadmap
  - Tips for devs with other language experience.