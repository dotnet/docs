---
title: "General structure of a C# program"
description: Learn how C# programs are structured, including the choice between file-based and project-based apps, top-level statements and Main method entry points, and the building blocks that make up every program.
ms.date: 03/11/2026
ai-usage: ai-assisted
helpviewer_keywords:
  - "C# language, program structure"
---
# General structure of a C# program

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. They walk you through writing your first C# programs before you learn about program structure.
>
> **Experienced in another language?** You might want to skim the [Get started](../../tour-of-csharp/tutorials/index.md) section for C#-specific syntax, then come back here.

You build C# programs from these core building blocks: namespaces organize your types, types (classes, structs, interfaces, enums, and delegates) define behavior and data, and statements and expressions perform work at run time. The way you structure the entry point depends on which application style you choose.

## Choosing your application style

When you create a C# program, make two independent choices about how to structure it:

- **File-based or project-based?**
  - A file-based app runs from a single `.cs` file with no project file.
  - A project-based app uses a `.csproj` file and can span multiple source files.
- **Top-level statements or `Main` method?**
  - Top-level statements let you write executable code directly at the top of a file.
  - A `Main` method wraps the entry point in an explicit static method.

Both project-based apps and file-based apps support either entry-point style.

### File-based apps vs. project-based apps

Starting with C# 14 and .NET 10, *file-based apps* let you run a program contained in a single `*.cs` file without a project file. Store the following code in a file named `hello-world.cs` and run it with `dotnet run hello-world.cs` or `dotnet hello-world.cs`:

:::code language="csharp" source="./snippets/file-based-program/hello-world.cs":::

> [!NOTE]
> The `#!` line enables Unix shells to run the file directly. On any Unix system, set the *execute* (`+x`) permission and run the file from the command line:

File-based apps support all C# syntax and can use [preprocessor directives](../../language-reference/preprocessor-directives.md#file-based-apps) to configure the build system. Use file-based apps for small command-line utilities, prototypes, and experiments. A file-based app consists of a single file in a directory:

```
my-app/
└── hello-world.cs
```

*Project-based apps* use a `.csproj` file and the [.NET CLI commands](../../../core/tools/index.md) `dotnet new`, `dotnet build`, and `dotnet run` workflow. Choose project-based apps when your program spans multiple files or needs fine-grained build configuration. A project-based app includes a project file alongside one or more source files:

```
my-app/
├── my-app.csproj
├── Program.cs
├── Models/
│   └── Person.cs
└── Services/
    └── GreetingService.cs
```

If your file-based app grows, you can easily convert it to a project-based app. Run [`dotnet project convert`](../../../core/tools/dotnet-project-convert.md) to generate a project file from your existing source file.

If you know your app needs multiple source files from the start, begin with a project-based app. You avoid the conversion step and can organize your code into separate files right away.

### Top-level statements vs. `Main` method

By using [top-level statements](top-level-statements.md), you can write executable code directly in one file without wrapping it in a class and `Main` method. This style is the default when you create a new console app with `dotnet new console`. The following example shows a modern C# program that uses [top-level statements](top-level-statements.md):

:::code language="csharp" source="snippets/toplevel-structure/Program.cs":::

Only one file in a project can have top-level statements, and the entry point is the first line of program text in that file. As you build larger programs, you include more program elements.

You can also define an explicit static [`Main`](main-command-line.md) method as the program's entry point:

:::code language="csharp" source="snippets/structure/Program.cs":::

Both entry-point styles work with file-based and project-based apps. Both styles support the same features.

## Building and running C# programs

C# is a *compiled* language. For project-based apps, use the [`dotnet build`](../../../core/tools/dotnet-build.md) command to compile source files into a binary package. Use [`dotnet run`](../../../core/tools/dotnet-run.md) to build and run in one step. The `dotnet` CLI, included in the .NET SDK, provides many [tools](../../../core/tools/index.md) to create, build, and manage C# projects.

For file-based apps, `dotnet run hello-world.cs` compiles and runs the single file directly - no project file required.

## Expressions and statements

If you followed the [Get started](../../tour-of-csharp/overview.md) tutorials, you already wrote expressions and statements. Every line of code you typed was one or the other (or both). Now let's define those terms.

Expressions and statements are the fundamental building blocks of a C# program. An *expression* produces a value. A *statement* performs an action and typically ends in a semicolon.

The following are expressions:

- `42` (literal value)
- `x + y` (arithmetic operation)
- `Math.Max(a, b)` (method call that produces a value)
- `condition ? trueValue : falseValue` (conditional expression)
- `new Person("John")` (object creation)

A *statement* performs an action. Statements control program flow, declare variables, or invoke operations. The following are statements:

- `int x;` (declaration statement)
- `int x = 42;` (declaration statement with initialization)
- `Console.WriteLine("Hello");` (method call statement)
- `if (condition) { /* code */ }` (conditional statement)
- `return result;` (return statement)

Statements often contain expressions, and expressions can nest inside other expressions. For example, the following declaration statement assigns `f` to the result of an addition expression. That addition expression adds the results of two method call expressions:

```csharp
var f = Math.Max(a, b) + Math.Max(c, d);
```

For detailed information about statements, see [Statements](../../programming-guide/statements-expressions-operators/statements.md). For information about expression-bodied members, see [Expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).

## Related sections

Learn about these program elements in the [types](../types/index.md) section of the fundamentals guide:

- [Classes](../types/classes.md)
- [Structs](../../language-reference/builtin-types/struct.md)
- [Namespaces](namespaces.md)
- [Interfaces](../types/interfaces.md)
- [Enums](../../language-reference/builtin-types/enum.md)
- [Delegates](../../delegates-overview.md)

## C# language specification

For more information, see [Basic concepts](~/_csharpstandard/standard/basic-concepts.md) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
