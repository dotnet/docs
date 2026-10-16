---
title: F# tooling performance
description: Understand F# compiler and language-service improvements, imported-library sharing, editor workload controls, and meaningful performance comparisons.
ms.date: 09/30/2026
ai-usage: ai-generated
---

# F# tooling performance

To reduce build and editor costs, F# 11 shares imported libraries and avoids repeated analysis. Measure the affected workload rather than assuming a release-wide speed or memory improvement.

## Imported binary-library sharing

FSharp.Compiler.Service can share eligible imported library graphs across projects that use the same binary dependencies. `FSharpChecker.Create` exposes `shareImportedAssemblies`, enabled by default. This avoids retaining a complete independent imported graph for each project.

Sharing requires matching resolved dependencies and import settings. Project references, type providers, multi-module assemblies, and ambiguous dependency closures are excluded. Framework imports were already shared.

The [implementing PR](https://github.com/dotnet/fsharp/pull/20296) measured retained memory after checking and holding all projects. Its ten-project ReSharper.FSharp workload used 1,547.2 MB without this sharing and 1,002.2 MB with it. Its compiler-solution workload changed by only 0.1%. These are change-specific experiments, not universal upgrade savings. Overlap in large **binary** references explains much of the difference.

## Retained metadata versus temporary allocations

F# 11 reduces [retained metadata](https://github.com/dotnet/fsharp/pull/20286) through lazy creation, smaller tables, and reuse. Separately, [metadata reading](https://github.com/dotnet/fsharp/pull/20489) and inline specialization allocate less temporary data. Retained heap, allocation volume, and process memory are different metrics; don't add results from these overlapping experiments.

## Editor analysis and navigation

The following improvements apply to different layers:

| Component | Work avoided or bounded |
|---|---|
| Visual Studio diagnostics | Reuses unchanged-document diagnostics with text and project versions, paths, and options considered. This targets repeated idle analysis, not arbitrary stale-result reuse. |
| Visual Studio Find All References and Rename | Limits concurrent typechecks rather than launching one for every document at once, while retaining cancellation. |
| External-symbol reference search | Skips projects that don't reference the symbol's binary assembly. |
| FCS incremental analysis | Synchronizes builder state so overlapping requests don't construct duplicate analysis chains for the same change. |

The [Peek fix](https://github.com/dotnet/fsharp/pull/20503) avoids a metadata-navigation deadlock. Use Go To Definition for generated metadata signatures; Peek stops at existing documents. These improvements require updated editor/FCS components, not just an application's Core package.

## Compilation and build-task concurrency

[Parallel compilation](../language-reference/compiler-options.md#parallel-compilation) uses independent file and compiler-phase work by default in F# 11. Source ordering remains part of the language; parallelism doesn't legalize forward dependencies.

Build tasks also use MSBuild's per-task environment and path facilities instead of changing process-global state. Overload caching reduces repeated resolution, and guarded-pattern compilation avoids explosive duplication in some disjunction/guard combinations.

## Compare the metric you need

- For build latency, compare equivalent full builds with identical optimization, deterministic-output, reference, and cache settings. Use `--parallelcompilation-` for a controlled comparison.
- For retained analysis memory, keep the same projects alive and distinguish live managed memory from allocation volume and process memory.
- For responsiveness, reproduce the editor action or idle workload. A console program's output doesn't measure an editor's work.

## See also

- [What's new in F# 11](../whats-new/fsharp-11.md)
- [Compiler options](../language-reference/compiler-options.md)
- [FSharp.Core target frameworks](../fsharp-core-targeting.md)
