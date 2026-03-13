---
title: "Main() and command-line arguments"
description: Learn about Main() and command-line arguments. The 'Main' method is the entry point of an executable program.
ms.date: 03/13/2026
---
# Main() and command-line arguments

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. Those tutorials use [top-level statements](top-level-statements.md), which is simpler for new apps.
>
> **Working with an existing codebase?** Many existing applications use an explicit `Main` method. This article explains how it works and how to use it effectively.

When you start a C# application, the runtime calls the `Main` method. The `Main` method is the entry point of a C# application.

A C# program can have only one entry point. If you have more than one class with a `Main` method, you must use the **StartupObject** compiler option when you compile your program to specify which `Main` method serves as the entry point. For more information, see [**StartupObject** (C# Compiler Options)](../../language-reference/compiler-options/advanced.md#startupobject). The following example displays the number of command-line arguments as its first action:

:::code language="csharp" source="snippets/main-command-line/TestClass.cs":::

## Overview

- The `Main` method is the entry point of an executable program. It's where the program control starts and ends.
- You must declare `Main` inside a class or struct. The enclosing `class` can be `static`.
- `Main` must be [`static`](../../language-reference/keywords/static.md).
- `Main` can have any [access modifier](../../programming-guide/classes-and-structs/access-modifiers.md).
- `Main` can return `void`, `int`, `Task`, or `Task<int>`.
- If and only if `Main` returns a `Task` or `Task<int>`, the declaration of `Main` can include the [`async`](../../language-reference/keywords/async.md) modifier. This rule specifically excludes an `async void Main` method.
- You can declare the `Main` method with or without a `string[]` parameter that contains command-line arguments. When you use Visual Studio to create Windows applications, you can add the parameter manually or else use the <xref:System.Environment.GetCommandLineArgs> method to obtain the command-line arguments. Parameters are zero-indexed command-line arguments. Unlike C and C++, the name of the program isn't treated as the first command-line argument in the `args` array, but it's the first element of the <xref:System.Environment.GetCommandLineArgs> method.

The following list shows permutations of `Main` declarations:

```csharp
static void Main() { }
static int Main() { }
static void Main(string[] args) { }
static int Main(string[] args) { }
static async Task Main() { }
static async Task<int> Main() { }
static async Task Main(string[] args) { }
static async Task<int> Main(string[] args) { }
```

The preceding examples don't specify an access modifier, so they're implicitly `private` by default. You can specify any explicit access modifier.

The following table summarizes all valid `Main` signatures and when to use each one:

| `Main` declaration                           | Uses `args` | Uses `await` | Returns exit code |
|----------------------------------------------|-------------|--------------|-------------------|
| `static void Main()`                         | No          | No           | No                |
| `static int Main()`                          | No          | No           | Yes               |
| `static void Main(string[] args)`            | Yes         | No           | No                |
| `static int Main(string[] args)`             | Yes         | No           | Yes               |
| `static async Task Main()`                   | No          | Yes          | No                |
| `static async Task<int> Main()`              | No          | Yes          | Yes               |
| `static async Task Main(string[] args)`      | Yes         | Yes          | No                |
| `static async Task<int> Main(string[] args)` | Yes         | Yes          | Yes               |

Choose the simplest signature that fits your needs. If you don't need command-line arguments, omit the `string[] args` parameter. If you don't need to return an exit code, use `void` or `Task`. If you need to call asynchronous methods, use `async` with a `Task` or `Task<int>` return type.

## Main() return values

When you return `int` or `Task<int>`, your program can send status information to other programs or scripts that run the executable. A return value of `0` usually means success, and a nonzero value means there's an error.

The following example returns an exit code:

:::code language="csharp" source="snippets/main-command-line/MainReturnValTest.cs":::

After running the program, you can check the exit code. In PowerShell, use `$LastExitCode`. In a batch file, use `ERRORLEVEL`.

If your `Main` method uses `await`, declare it as `async` with a `Task` or `Task<int>` return type:

:::code language="csharp" source="snippets/main-arguments/Program.cs" id="AsyncMain":::

## Command-line arguments

Include a `string[] args` parameter in your `Main` declaration to accept command-line arguments. If you don't need them, omit the parameter. The `args` parameter is a <xref:System.String> array that's never null—if no arguments are provided, its `Length` is zero.

You can convert string arguments to other types by using `Parse` or <xref:System.Convert>:

```csharp
long num = long.Parse(args[0]);
```

> [!TIP]
> Parsing command-line arguments can be complex. Consider using the [System.CommandLine](../../../standard/commandline/index.md) library to simplify the process.

For a working example, see [How to display command-line arguments](../tutorials/how-to-display-command-line-arguments.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- <xref:System.Environment?displayProperty=nameWithType>
- [How to display command line arguments](../tutorials/how-to-display-command-line-arguments.md)
