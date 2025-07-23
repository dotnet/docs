---
title: "Top-level statements - programs without Main methods"
description: Learn about top-level statements. You can create programs without the ceremony of a Program class and a Main method.
ms.date: 06/23/2025
helpviewer_keywords:
  - "C# language, top-level statements"
  - "C# language, Main method"
---
# Top-level statements - programs without `Main` methods

You don't have to explicitly include a `Main` method in a console application project. Instead, you can use the *top-level statements* feature to minimize the code you have to write.

Top-level statements allow you to write executable code directly at the root of a file, eliminating the need for wrapping your code in a class or method.
This means you can create programs without the ceremony of a `Program` class and a `Main` method.
In this case, the compiler generates a `Program` class with an entry point method for the application. The name of the generated method isn't `Main`, it's an implementation detail that your code can't reference directly.

Here's a *Program.cs* file that is a complete C# program:

```csharp
Console.WriteLine("Hello World!");
```

Top-level statements let you write simple programs for small utilities such as Azure Functions and GitHub Actions. They also make it simpler for new C# programmers to get started learning and writing code.

The following sections explain the rules on what you can and can't do with top-level statements.

## Only one top-level file

An application must have only one entry point. A project can have only one file with top-level statements. Putting top-level statements in more than one file in a project results in the following compiler error:

> CS8802 Only one compilation unit can have top-level statements.

A project can have any number of source code files that don't have top-level statements.

## No other entry points

You can write a `Main` method explicitly, but it can't function as an entry point. The compiler issues the following warning:

> CS7022 The entry point of the program is global code; ignoring 'Main()' entry point.

In a project with top-level statements, you can't use the [-main](../../language-reference/compiler-options/advanced.md#mainentrypoint-or-startupobject) compiler option to select the entry point, even if the project has one or more `Main` methods.

## `using` directives

For the single file containing top-level statements `using` directives must come first in that file, as in this example:

:::code language="csharp" source="snippets/top-level-statements-1/Program.cs":::

## Global namespace

Top-level statements are implicitly in the global namespace.

## Namespaces and type definitions

A file with top-level statements can also contain namespaces and type definitions, but they must come after the top-level statements. For example:

:::code language="csharp" source="snippets/top-level-statements-2/Program.cs":::

## `args`

Top-level statements can reference the `args` variable to access any command-line arguments that were entered. The `args` variable is never null but its `Length` is zero if no command-line arguments were provided. For example:

:::code language="csharp" source="snippets/top-level-statements-3/Program.cs":::

## `await`

You can call an async method by using `await`. For example:

:::code language="csharp" source="snippets/top-level-statements-4/Program.cs":::

## Exit code for the process

To return an `int` value when the application ends, use the `return` statement as you would in a `Main` method that returns an `int`. For example:

:::code language="csharp" source="snippets/top-level-statements-5/Program.cs":::

## Implicit entry point method

The compiler generates a method to serve as the program entry point for a project with top-level statements. The signature of the method depends on whether the top-level statements contain the `await` keyword or the `return` statement. The following table shows what the method signature would look like, using the method name `Main` in the table for convenience.

| Top-level code contains | Implicit `Main` signature                    |
|-------------------------|----------------------------------------------|
| `await` and `return`    | `static async Task<int> Main(string[] args)` |
| `await`                 | `static async Task Main(string[] args)`      |
| `return`                | `static int Main(string[] args)`             |
| No `await` or `return`  | `static void Main(string[] args)`            |

Beginning with C# 14, programs can be [*file based programs*](./index.md#building-and-running-c-programs), where a single file contains the program. You run *file based programs* with the command `dotnet run <file.cs>`, or using the `#!/usr/local/share/dotnet/dotnet run` directive as the first line (unix shells only).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]
[Feature specification - Top-level statements](~/_csharplang/proposals/csharp-9.0/top-level-statements.md)
