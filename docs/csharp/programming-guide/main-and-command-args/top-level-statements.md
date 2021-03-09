---
title: "Top-level statements - C# Programming Guide"
description: Learn about top-level statements in C# 9 and later.
ms.date: 03/08/2021
helpviewer_keywords:
  - "C# language, top-level statements"
  - "C# language, Main method"
---
# Top-level statements (C# Programming Guide)

Starting in C# 9, you don't have to explicitly include a `Main` method in a console application project. Instead, you can use the *top-level statements* feature to minimize the code you have to write. In this case, the compiler provides an implicit class and `Main` method entry point for the application.

Here's a *Program.cs* file that is a complete C# program in C# 9:

:::code language="csharp" source="snippets/top-level-statements-1/Program.cs":::

Top-level statements simplify the code that you write for small utilities such as Azure Functions and GitHub Actions. They also make it simpler for new C# programmers to get started learning and writing code.

## Rules for top-level statements.

The following sections explain the rules on what you can and can't do with top-level statements.

### Only one file can have top-level statements

An application must have only one entry point, so it can only have one file with top-level statements. Putting top-level statements in more than one file in a project results in the following compiler error:

> CS8802 Only one compilation unit can have top-level statements.

### No other entry points

You can write a `Main` method explicitly, but it can't function as an entry point. The compiler issues the following warning:

> CS7022 The entry point of the program is global code; ignoring 'Main()' entry point.

In a project with top-level statements, you can't use the [-main](../../language-reference/compiler-options/main-compiler-option.md) compiler option to select the application's entry point.

### `Using` directives are allowed

If you include using directives, they must come first in the file, as in this example:

:::code language="csharp" source="snippets/top-level-statements-1/Program.cs":::

### Global namespace

Top-level statements are implicitly in the global namespace. A class and a `Main` method are implicitly generated, but there is no implicitly generated namespace.

### Namespaces and type definitions are allowed

A file with top-level statements can also contain namespaces and type definitions, but they must come after the top-level statements. Here's an example:

:::code language="csharp" source="snippets/top-level-statements-2/Program.cs":::

### `args` is available.

Top-level statements can reference the args variable, which contains any command-line arguments that were entered. The args variable is never null but has `Length` 0 if no command-line arguments were provided.

:::code language="csharp" source="snippets/top-level-statements-3/Program.cs":::

You can test this application with multiple arguments by running the following commands:

```dotnetcli
dotnet run <app name> -- Argument1 Argument2
```

### `await` is available

You can call an async method by using `await`. For example:

:::code language="csharp" source="snippets/top-level-statements-4/Program.cs":::

### The app can return an `int`

To return an `int` value when the application ends, use the return statement as you would in a Main method that return an int. For example:

:::code language="csharp" source="snippets/top-level-statements-4/Program.cs":::

## Implicit `Main` method signature

The compiler generates an implicit `Main` method with a signature that depends on what code is found within the top-level statements.

| Top-level code               | Implicit signature                           |
|------------------------------|----------------------------------------------|
| Neither `await` nor `return` | `static void Main(string[] args)`            |
| `await`                      | `static async Task Main(string[] args)`      |
| `await` and `return`         | `static async Task<int> Main(string[] args)` |
| `return`                     | `static int Main(string[] args)`             |

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Programming Guide](../index.md)
- [Methods](../classes-and-structs/methods.md)
- [Inside a C# Program](../inside-a-program/index.md)
