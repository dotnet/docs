---
title: F# tooling performance
description: Understand F# compiler and language-service improvements, imported-library sharing, editor workload controls, and meaningful performance comparisons.
ms.date: 09/30/2026
ai-usage: ai-generated
---

# F# tooling performance

Large solutions can spend substantial time and memory on work that isn't application execution: importing the same DLLs for many projects, rechecking unchanged documents, and answering overlapping navigation requests. F# 11 reduces several of these costs. The affected component and workload matter more than a single release-wide percentage.

## Imported binary-library sharing

FSharp.Compiler.Service can share eligible imported library graphs across projects that use the same binary dependencies. `FSharpChecker.Create` exposes `shareImportedAssemblies`, enabled by default. This avoids retaining a complete independent imported graph for each project.

The shared graph is keyed by its resolved dependency closure and import configuration, not simply an assembly name. Framework imports were already shared. Project references, type-provider assemblies, multi-module assemblies, and ambiguous dependency closures are excluded from this additional sharing.

Entries use weak references, and `ClearCaches` clears the shared cache. Don't treat that as a guarantee that every object becomes immediately collectible: active projects and other caches may still hold references.

The [implementing PR](https://github.com/dotnet/fsharp/pull/20296) measured retained memory after checking and holding all projects. Its ten-project ReSharper.FSharp workload used 1,547.2 MB without this sharing and 1,002.2 MB with it. Its compiler-solution workload changed by only 0.1%. These are change-specific experiments, not universal upgrade savings. Overlap in large **binary** references explains much of the difference.

## Retained metadata versus temporary allocations

An analysis-only host doesn't need every code-generation cache or every member's metadata. F# 11 delays unused metadata objects, sizes reader tables more conservatively, and reuses equivalent imported references and attributes. These changes reduce the live graph while projects remain open.

Other changes create less temporary garbage: the metadata-only reader can map a DLL instead of allocating a full managed copy, and inline specialization combines previously repeated tree traversals. Reduced allocation volume doesn't imply an equal reduction in the live heap or process working set. Memory mapping also isn't zero process-memory use.

See [metadata retention](https://github.com/dotnet/fsharp/pull/20286) and [metadata-reader allocation](https://github.com/dotnet/fsharp/pull/20489) for separate workload evidence. Don't add their figures to the imported-graph experiment: their baselines and objects overlap.

## Editor analysis and navigation

The following improvements apply to different layers:

| Component | Work avoided or bounded |
|---|---|
| Visual Studio diagnostics | Reuses unchanged-document diagnostics with text and project versions, paths, and options considered. This targets repeated idle analysis, not arbitrary stale-result reuse. |
| Visual Studio Find All References and Rename | Limits concurrent typechecks rather than launching one for every document at once, while retaining cancellation. |
| External-symbol reference search | Skips projects that don't reference the symbol's binary assembly. |
| FCS incremental analysis | Synchronizes builder state so overlapping requests don't construct duplicate analysis chains for the same change. |

The FCS [concurrent-check regression](https://github.com/dotnet/fsharp/pull/20481) uses 50 requests after changing the first of five files, asserting one check per file for the tested incremental implementation. This isn't a promise that every language-service implementation or request checks each file only once.

The [navigation fix](https://github.com/dotnet/fsharp/pull/20503) also avoids a metadata Peek deadlock. Peek stops at existing documents; use Go To Definition for a generated metadata signature. This doesn't add general Peek-into-metadata support.

These claims are grounded in implementation, regression tests, and reported editor traces. They don't imply that every editor using an older bundled FCS acquires the behavior merely by updating an application's Core package.

## Compilation and build-task concurrency

[Parallel compilation](../language-reference/compiler-options.md#parallel-compilation) uses independent file and compiler-phase work by default in F# 11. Source ordering remains part of the language; parallelism doesn't legalize forward dependencies.

Separately, F# build tasks use MSBuild's per-task environment and path facilities so concurrently hosted tasks needn't change process-global state. This supports isolation when MSBuild runs tasks in a shared process; it doesn't enable every MSBuild concurrency mode for the user.

Overload caching helps repeated calls with the same applicable types, such as large assertion-heavy test files. The guarded-pattern compiler also avoids explosive duplication in certain disjunction/guard shapes. Neither improvement means every overload is cached or every pattern match becomes faster.

## Compare the metric you need

- For build latency, compare equivalent full builds with identical optimization, deterministic-output, reference, and cache settings. Use `--parallelcompilation-` for a controlled comparison.
- For retained analysis memory, keep the same projects alive and distinguish live managed memory from allocation volume and process memory.
- For responsiveness, reproduce the editor action or idle workload. A console program's output doesn't measure an editor's work.
- For stepping through inline code, use a non-optimized build and its symbols. See [Debug inline functions](../language-reference/functions/inline-functions.md#debug-inline-functions).

## See also

- [What's new in F# 11](../whats-new/fsharp-11.md)
- [Compiler options](../language-reference/compiler-options.md)
- [FSharp.Core target frameworks](../fsharp-core-targeting.md)
