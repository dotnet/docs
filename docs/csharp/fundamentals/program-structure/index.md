---
title: "General structure of a C# program"
description: Learn how C# programs are structured, including the choice between file-based and project-based apps, top-level statements and Main method entry points, and the building blocks that make up every program.
ms.date: 03/04/2026
ai-usage: ai-assisted
helpviewer_keywords:
  - "C# language, program structure"
---
# General structure of a C# program

You build C# programs from these core building blocks: namespaces organize your types, types (classes, structs, interfaces, enums, and delegates) define behavior and data, and statements and expressions perform work at run time. The way you structure the entry point - where your program starts running - depends on which application style you choose.

The following example shows a modern C# program that uses [file-scoped namespaces](namespaces.md), [top-level statements](top-level-statements.md), and everyday C# features:

:::code language="csharp" source="snippets/toplevel-structure/Program.cs":::

This example uses *top-level statements* for the program's entry point. Only one file in a project can have top-level statements, and the entry point is the first line of program text in that file. File-scoped namespaces (the `namespace YourNamespace;` syntax) reduce nesting by applying the namespace to the entire file.

## Choosing your application style

When you create a C# program, make two independent choices about how to structure it:

1. **File-based or project-based?** A file-based app runs from a single `.cs` file with no project file. A project-based app uses a `.csproj` file and can span multiple source files.
1. **Top-level statements or `Main` method?** Top-level statements let you write executable code directly at the top of a file. A `Main` method wraps the entry point in an explicit static method.

Both project-based apps and file-based apps support either entry-point style.

### File-based apps vs. project-based apps

Starting with C# 14 and .NET 10, *file-based apps* let you run a program contained in a single `*.cs` file without a project file. Store the following code in a file named `hello-world.cs` and run it with `dotnet run hello-world.cs`:

:::code language="csharp" source="./snippets/file-based-program/hello-world.cs":::

The `#!` line enables Unix shells to run the file directly. On any Unix system, set the *execute* (`+x`) permission and run the file from the command line:

```bash
./hello-world.cs
```

File-based apps support all C# syntax and can use [preprocessor directives](../../language-reference/preprocessor-directives.md#file-based-apps) to configure the build system. Use file-based apps for small command-line utilities, prototypes, and experiments.

*Project-based apps* use a `.csproj` file and the [.NET CLI commands](../../../core/tools/index.md) `dotnet new`, `dotnet build`, and `dotnet run` workflow. Choose project-based apps when your program spans multiple files or needs fine-grained build configuration.

### Top-level statements vs. `Main` method

[Top-level statements](top-level-statements.md) let you write executable code directly in one file, without wrapping it in a class and `Main` method. This style is the default when you create a new console app with `dotnet new console`. The first code example in this article uses this style.

You can also define an explicit static [`Main`](main-command-line.md) method as the program's entry point:

:::code language="csharp" source="snippets/structure/Program.cs":::

Either entry-point style works with both file-based and project-based apps. Both styles support the same features.

## Building and running C# programs

C# is a *compiled* language. For project-based apps, use the [`dotnet build`](../../../core/tools/dotnet-build.md) command to compile source files into a binary package and [`dotnet run`](../../../core/tools/dotnet-run.md) to build and run in one step. The `dotnet` CLI, included in the .NET SDK, provides many [tools](../../../core/tools/index.md) to create, build, and manage C# projects.

For file-based apps, `dotnet run hello-world.cs` compiles and runs the single file directly - no project file required.

## Expressions and statements

C# programs use *expressions* and *statements*.

An *expression* produces a single value. The following are expressions:

- `42` (literal value)
- `x + y` (arithmetic operation)
- `Math.Max(a, b)` (method call)
- `condition ? trueValue : falseValue` (conditional expression)
- `new Person("John")` (object creation)

A *statement* performs an action. Statements control program flow, declare variables, or invoke operations. The following are statements:

- `int x = 42;` (declaration statement)
- `Console.WriteLine("Hello");` (expression statement—wraps a method call expression)
- `if (condition) { /* code */ }` (conditional statement)
- `return result;` (return statement)

Some constructs serve both roles. For example, `Math.Max(a, b)` is an expression when used in `int result = Math.Max(a, b);`, but becomes an expression statement when written alone as `Math.Max(a, b);`.

For detailed information about statements, see [Statements](../../programming-guide/statements-expressions-operators/statements.md). For information about expression-bodied members, see [Expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).

## Related sections

Learn about these program elements in the [types](../types/index.md) section of the fundamentals guide:

- [Classes](../types/classes.md).
- [Structs](../../language-reference/builtin-types/struct.md).
- [Namespaces](namespaces.md).
- [Interfaces](../types/interfaces.md).
- [Enums](../../language-reference/builtin-types/enum.md).
- [Delegates](../../delegates-overview.md).

## C# language specification

For more information, see [Basic concepts](~/_csharpstandard/standard/basic-concepts.md) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
