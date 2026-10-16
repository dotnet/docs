---
title: FSharp.Core target frameworks
description: Understand how FSharp.Core selects a target-specific build and how modern .NET APIs affect library availability and runtime requirements.
ms.date: 09/30/2026
ai-usage: ai-generated
---

# FSharp.Core target frameworks

A core library compiled only against .NET Standard can't directly use newer .NET APIs, even when its application runs on a newer runtime. Starting with FSharp.Core 11, the package includes a `net10.0` build alongside `netstandard2.0` and `netstandard2.1`. The additional build lets F# library implementations and APIs use modern .NET capabilities without requiring every application to move to that target.

## Target-specific APIs and behavior

The [targeting decision](https://github.com/dotnet/fsharp/pull/20229) explicitly permits target-specific APIs and behavior. Conditional compilation can select implementations or expose functionality that relies on newer .NET APIs. Don't assume that the three assemblies have identical public APIs.

The shipped .NET target is deliberately configured rather than automatically following the compiler product's development target. For example, the F# 11 product can ship a Core assembly targeting .NET 10. Advancing that target is an explicit decision. This change neither removes the two .NET Standard builds nor promises permanent retention of any target.

## Which build your project uses

NuGet selects the nearest compatible asset for the project's target framework. A project targeting .NET 10 or later can select `lib/net10.0/FSharp.Core.dll`; older compatible targets select a .NET Standard asset. A multi-targeted library can therefore compile against different Core surfaces for different targets.

To diagnose availability:

1. Check the resolved FSharp.Core package version, not only the compiler's language version.
2. Inspect the Core compile and runtime entries for your target in `obj/project.assets.json`. Don't infer selection merely because a package contains a `net10.0` directory.
3. For framework-dependent applications, check the runtime that executes the result. Reference assemblies describe APIs at compile time; they aren't an implementation.

`<LangVersion>preview</LangVersion>` enables compiler behavior. It doesn't add missing Core members, select a different package asset, or provide runtime support.

## Examples of the differences

| Area | Availability in Core 11 |
|---|---|
| `print` and `printn` | Available across the three builds; they aren't modern-target-only APIs. |
| Ordinary `Async` and `Task` helpers | Available without the runtime-async experiment. |
| ValueTask helpers and related overloads | Available in `netstandard2.1` and `net10.0`, not `netstandard2.0`. |
| Zero-based `Array2D.create`, `init`, and `rebase` | Improved zero-based allocation paths across builds. |
| Bounds-preserving `Array2D.map`, `mapi`, and `copy` | The `net10.0` build uses a newer .NET allocation API; .NET Standard builds retain their fallback. |
| Runtime-async return intrinsics | Exposed by the `net10.0` build; compiler, reference, runtime, and preview requirements also apply. |

For operation semantics, see [Async and task functions](language-reference/async-task-functions.md) and [Array2D and Native AOT](language-reference/arrays.md#two-dimensional-arrays-and-native-aot). String-interpolation lowering is a compiler change, not a new target-specific Core concatenation API.

## F# Interactive and asynchronous disposal

F# task expressions already support `IAsyncDisposable` resources in compatible compiled projects. Older FSI tool packaging could select a Core build without the necessary task-builder overload, so equivalent `use` or `use!` code failed interactively.

The [F# 11 toolset packaging fix](https://github.com/dotnet/fsharp/pull/20555) supplies the modern Core build with the tools and preserves SDK reference resolution. Use a toolset containing that fix; a separately updated package reference doesn't establish that an existing FSI host selects it. See [F# Interactive](tools/fsharp-interactive/index.md).

## Runtime async is a separate runtime contract

The modern Core build supplies compiler-recognized intrinsics for runtime async, but its target name isn't sufficient evidence that a resulting method can execute. The [experimental builder example](language-reference/task-expressions.md#runtime-async-experiments) requires preview at definition and inline expansion, appropriate reference APIs, and runtime support.

## See also

- [What's new in F# 11](whats-new/fsharp-11.md)
- [F# compiler options](language-reference/compiler-options.md)
- [.NET target frameworks](../standard/frameworks.md)
