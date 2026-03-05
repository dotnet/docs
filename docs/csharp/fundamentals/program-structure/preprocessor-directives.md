---
title: "Preprocessor directives"
description: Learn how to use the most common C# preprocessor directives—conditional compilation, regions, nullable context control, and warning suppression—in everyday development.
ms.date: 03/04/2026
ai-usage: ai-assisted
helpviewer_keywords:
  - "preprocessor directives [C#]"
  - "#if directive [C#]"
  - "#region directive [C#]"
  - "#nullable directive [C#]"
  - "#pragma warning [C#]"
---
# Preprocessor directives

C# preprocessor directives are instructions to the compiler that affect compilation without changing your program's run-time behavior. They always start with `#` and must be the only instruction on a line. While the [language reference](../../language-reference/preprocessor-directives.md) documents all available directives, four groups cover the vast majority of everyday use:

- **Conditional compilation** (`#if` / `#elif` / `#else` / `#endif`) — include or exclude code based on build configuration or target framework.
- **Regions** (`#region` / `#endregion`) — mark collapsible sections in your editor.
- **Nullable context** (`#nullable`) — control nullable reference type analysis at a fine-grained level.
- **Warning suppression** (`#pragma warning`) — suppress or restore specific compiler warnings.

## Conditional compilation

Use `#if`, `#elif`, `#else`, and `#endif` to include or exclude code based on whether a symbol is defined. The most common symbols are `DEBUG` (set automatically for Debug builds) and target framework symbols like `NET10_0_OR_GREATER`:

:::code language="csharp" source="snippets/preprocessor-directives/Program.cs" id="ConditionalCompilation":::

The build system defines the `DEBUG` symbol when you build in the Debug configuration. You don't need to define it yourself. Target framework symbols like `NET10_0_OR_GREATER` and `NET8_0_OR_GREATER` let you write code that adapts to different .NET versions in multi-targeting projects.

You can combine symbols with logical operators: `&&` (and), `||` (or), and `!` (not):

:::code language="csharp" source="snippets/preprocessor-directives/Program.cs" id="CombinedConditions":::

Use `#define` at the top of a file to define your own symbols. You can also define symbols for the entire project by using the [`DefineConstants`](../../language-reference/compiler-options/language.md#defineconstants) property in your project file.

## Regions

Use `#region` and `#endregion` to mark collapsible sections of code in your editor. Regions don't affect compilation—they're purely an organizational tool:

:::code language="csharp" source="snippets/preprocessor-directives/Regions.cs" id="RegionExample":::

Use regions to group related members. For example, you might use regions to define members of an interface when a type implements multiple interfaces.

## Nullable context

The `#nullable` directive controls nullable reference type analysis within a file. While you typically enable nullable analysis project-wide in your `.csproj` file by using `<Nullable>enable</Nullable>`, use the `#nullable` directive to fine-tune the setting for specific sections of code:

:::code language="csharp" source="snippets/preprocessor-directives/NullableContext.cs" id="NullableDirective":::

The three forms are:

- `#nullable enable` — turn on nullable warnings and annotations.
- `#nullable disable` — turn off nullable warnings and annotations.
- `#nullable restore` — revert to the project-level setting.

This directive is especially useful when you're incrementally migrating a large codebase to nullable reference types. Enable it file by file or section by section, fixing warnings as you go.

## Warning suppression

Use `#pragma warning disable` to suppress specific compiler warnings, and `#pragma warning restore` to re-enable them. Always scope the suppression as narrowly as possible:

:::code language="csharp" source="snippets/preprocessor-directives/PragmaWarning.cs" id="PragmaWarning":::

> [!TIP]
> Always specify the warning number, such as `CS0168`, rather than disabling all warnings. This approach keeps the suppression targeted and makes it clear *why* a warning is being suppressed.

## File-based app directives

Starting with C# 14, [file-based apps](index.md) use two additional directives:

- `#!` — the *shebang* line that lets Unix shells run the file directly (for example, `#!/usr/bin/env dotnet run`).
- `#:` — build-system directives that configure packages, SDK settings, and other options for single-file programs.

For details on these directives, see [File-based apps](../../../core/sdk/file-based-apps.md) and the [language reference](../../language-reference/preprocessor-directives.md#file-based-apps).

## See also

- [C# preprocessor directives (language reference)](../../language-reference/preprocessor-directives.md) — complete reference for all preprocessor directives.
- [Nullable reference types](../../nullable-references.md) — learn about the nullable reference type system.
