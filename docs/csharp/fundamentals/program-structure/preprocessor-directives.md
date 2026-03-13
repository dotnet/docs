---
title: "Preprocessor directives"
description: Learn how to use the most common C# preprocessor directives—conditional compilation, regions, nullable context control, and warning suppression—in everyday development.
ms.date: 03/13/2026
ai-usage: ai-assisted
---
# Preprocessor directives

> [!TIP]
> **New to developing software?** You won't need preprocessor directives right away. Focus on the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first and come back here when your projects require conditional compilation or build configuration.
>
> **Experienced in another language?** If you're familiar with `#ifdef` in C/C++ or conditional compilation in other languages, C# preprocessor directives work similarly. Skim ahead to the syntax you need.

C# preprocessor directives tell the compiler what code to include, exclude, or treat differently when it builds your app. This guidance can change the resulting program. Preprocessor directives always start with `#` and must appear on their own line (ignoring leading whitespace). You can add a trailing comment after the directive. While the [language reference](../../language-reference/preprocessor-directives.md) documents all available directives, three groups cover everyday use:

- **File-based apps** (`#:`) - configure file-based apps.
- **Conditional compilation** (`#if` / `#elif` / `#else` / `#endif`) — include or exclude code based on build configuration or target framework.
- **Warning suppression** (`#pragma warning`) — suppress or restore specific compiler warnings.
- **Nullable context** (`#nullable`) — control nullable reference type analysis at a fine-grained level.

## File-based app directives

Starting with C# 14, [file-based apps](index.md) use two additional directives:

- `#!` — the *shebang* line that lets Unix shells run the file directly (for example, `#!/usr/bin/env dotnet run`).
- `#:` — build-system directives that configure packages, SDK settings, and other options for single-file programs.

Use `#:package` to add a NuGet package. For example, the following file-based app uses the `Spectre.Console` package to render styled output:

```csharp
#!/usr/bin/env dotnet run
#:package Spectre.Console@*

AnsiConsole.MarkupLine("[bold green]Hello[/] from a file-based app!");
```

You can specify an exact version with `@`, or use `@*` to pull the latest version. Add multiple `#:package` directives to include more packages:

```csharp
#:package Serilog@3.1.1
```

Other `#:` directives let you reference projects, set MSBuild properties, or change the SDK:

```csharp
#:project ../SharedLibrary/SharedLibrary.csproj
#:property PublishAot=false
#:sdk Microsoft.NET.Sdk.Web
```

For the full list of directives, see [File-based apps](../../../core/sdk/file-based-apps.md) and the [language reference](../../language-reference/preprocessor-directives.md#file-based-apps).

## Conditional compilation

Use `#if`, `#elif`, `#else`, and `#endif` to include or exclude code based on whether a symbol is defined. The most common symbols are `DEBUG` (set automatically for Debug builds) and target framework symbols like `NET10_0_OR_GREATER`:

:::code language="csharp" source="snippets/preprocessor-directives/Program.cs" id="ConditionalCompilation":::

The build system defines the `DEBUG` symbol when you build in the Debug configuration. You don't need to define it yourself. Target framework symbols like `NET10_0_OR_GREATER` and `NET8_0_OR_GREATER` let you write code that adapts to different .NET versions in multi-targeting projects.

You can combine symbols with logical operators: `&&` (and), `||` (or), and `!` (not):

:::code language="csharp" source="snippets/preprocessor-directives/Program.cs" id="CombinedConditions":::

Use `#define` at the top of a file to define your own symbols. You can also define symbols for the entire project by using the [`DefineConstants`](../../language-reference/compiler-options/language.md#defineconstants) property in your project file.

## Warning suppression

Use `#pragma warning disable` to suppress specific compiler warnings, and `#pragma warning restore` to re-enable them. Always scope the suppression as narrowly as possible:

:::code language="csharp" source="snippets/preprocessor-directives/PragmaWarning.cs" id="PragmaWarning":::

> [!TIP]
> Always specify the warning number, such as `CS0168`, rather than disabling all warnings. This approach keeps the suppression targeted and makes it clear *why* a warning is being suppressed.

## See also

- [C# preprocessor directives (language reference)](../../language-reference/preprocessor-directives.md) — complete reference for all preprocessor directives.
