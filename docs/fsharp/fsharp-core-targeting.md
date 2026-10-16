---
title: FSharp.Core target frameworks
description: Understand how FSharp.Core selects a target-specific build and how modern .NET APIs affect library availability and runtime requirements.
ms.date: 09/30/2026
ai-usage: ai-generated
---

# FSharp.Core target frameworks

A library can't directly use APIs absent from its compilation target. FSharp.Core 11 adds a `net10.0` build alongside `netstandard2.0` and `netstandard2.1` so it can use modern .NET APIs without dropping older targets.

## Target-specific APIs and behavior

The builds can expose different APIs and implementations. The [targeting decision](https://github.com/dotnet/fsharp/pull/20229) selects the modern target explicitly; it doesn't automatically follow the compiler's development target.

## Which build your project uses

NuGet selects the nearest compatible asset for each project target. .NET 10 and later projects can select `lib/net10.0/FSharp.Core.dll`; older compatible targets select a .NET Standard asset.

To diagnose availability:

1. Check the resolved FSharp.Core package version.
1. Inspect the selected compile and runtime assets in `obj/project.assets.json`.
1. Check the runtime that executes the application, not only its reference assemblies.

`<LangVersion>preview</LangVersion>` enables compiler behavior. It doesn't add missing Core members, select a different package asset, or provide runtime support.

## Examples of the differences

| Area | Availability in Core 11 |
|---|---|
| ValueTask helpers and related overloads | Available in `netstandard2.1` and `net10.0`, not `netstandard2.0`. |
| Bounds-preserving `Array2D.map`, `mapi`, and `copy` | The `net10.0` build uses a newer .NET allocation API; .NET Standard builds retain their fallback. |
| Runtime-async return intrinsics | Exposed by the `net10.0` build; [compiler, language, reference, and runtime requirements](language-reference/task-expressions.md#runtime-async-experiments) also apply. |

For details, see [Async and task functions](language-reference/async-task-functions.md) and [Array2D and Native AOT](language-reference/arrays.md#two-dimensional-arrays-and-native-aot). Ordinary Async/Task helpers and `print`/`printn` are available across all three builds.

## F# Interactive and asynchronous disposal

F# task expressions already support `IAsyncDisposable` resources in compatible compiled projects. The [F# 11 packaging fix](https://github.com/dotnet/fsharp/pull/20555) supplies the modern Core build to F# Interactive so equivalent `use` and `use!` code also works there. Update the toolset, not only an application's package reference.

## Runtime async is a separate runtime contract

The Core build's `net10.0` target doesn't establish runtime-async support. Follow the separate compiler, reference, and runtime requirements in [Runtime async experiments](language-reference/task-expressions.md#runtime-async-experiments).

## See also

- [What's new in F# 11](whats-new/fsharp-11.md)
- [F# compiler options](language-reference/compiler-options.md)
- [.NET target frameworks](../standard/frameworks.md)
