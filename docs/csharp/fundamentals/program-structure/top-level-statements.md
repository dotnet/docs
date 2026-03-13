---
title: "Top-level statements - programs without Main methods"
description: Learn about top-level statements. You can create programs without the ceremony of a Program class and a Main method.
ms.date: 03/13/2026
---
# Top-level statements - programs without `Main` methods

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. Those tutorials use top-level statements, so you'll already be familiar with the basics.
>
> **Looking for the `Main` method alternative?** See [Main method entry point](main-command-line.md) for the explicit `Main` method approach.

Use *top-level statements* for new apps. By using top-level statements, you can write executable code directly at the root of a file.

Here's a *Program.cs* file that is a complete C# program:

```csharp
Console.WriteLine("Hello World!");
```

When you create a new console app by using `dotnet new console`, it uses top-level statements by default. They work well for programs of any size - from small utilities and Azure Functions to full applications. If you have an existing application that uses an explicit `Main` method, there's no need to convert it. Both styles compile to equivalent code.

The following sections explain the rules on what you can and can't do with top-level statements.

## `using` directives

For the single file containing top-level statements, `using` directives must come first in that file, as in the following example:

:::code language="csharp" source="snippets/top-level-statements-1/Program.cs":::

## Namespaces and type definitions

Top-level statements are implicitly in the global namespace. A file with top-level statements can also contain namespaces and type definitions, but they must come after the top-level statements. For example:

:::code language="csharp" source="snippets/top-level-statements-2/Program.cs":::

## `args`

Top-level statements can reference the `args` variable to access any command-line arguments that you enter. The `args` variable is never `null`, but its `Length` is zero if you don't provide any command-line arguments. For example:

:::code language="csharp" source="snippets/top-level-statements-3/Program.cs":::

## `await` and exit code

Use `await` to call an async method. For example:

:::code language="csharp" source="snippets/top-level-statements-4/Program.cs":::

To return an `int` value when the application ends, use the `return` statement as you would in a `Main` method that returns an `int`. For example:

:::code language="csharp" source="snippets/top-level-statements-5/Program.cs":::

## Entry point rules

An application must have only one entry point. A project can have only one file with top-level statements, but it can have any number of source code files that don't have top-level statements. You can explicitly write a `Main` method, but it can't function as an entry point. In a project with top-level statements, you can't use the [-main](../../language-reference/compiler-options/advanced.md#startupobject) compiler option to select the entry point, even if the project has one or more `Main` methods.

The compiler generates a method to serve as the program entry point for a project with top-level statements. The signature of the method depends on whether the top-level statements contain the `await` keyword or the `return` statement. The following table shows what the method signature looks like, using the method name `Main` in the table for convenience.

| Top-level code contains | Implicit `Main` signature                    |
|-------------------------|----------------------------------------------|
| `await` and `return`    | `static async Task<int> Main(string[] args)` |
| `await`                 | `static async Task Main(string[] args)`      |
| `return`                | `static int Main(string[] args)`             |
| No `await` or `return`  | `static void Main(string[] args)`            |

Starting with C# 14, programs can be [*file-based apps*](./index.md#building-and-running-c-programs), where a single file contains the program. You run *file-based apps* by using the command `dotnet <file.cs>`, or by using the `#!/usr/bin/env dotnet` directive as the first line (Unix shells only).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]
[Feature specification - Top-level statements](~/_csharplang/proposals/csharp-9.0/top-level-statements.md)
