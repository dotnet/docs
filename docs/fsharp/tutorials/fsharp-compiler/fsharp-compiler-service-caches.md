---
title: F# compiler service caches
description: Learn about the various caches the F# compiler service maintains while hosted in F# tooling.
ms.date: 8/6/2020
---

# F# compiler service caches

This is a design note on the `FSharpChecker` component and its caches. Each FSharpChecker object maintains a set of caches.

## FSharpChecker caches

The following are the various caches an instance of an `FSharpChecker` maintains in F# tooling.

* `scriptClosureCache` - an MRU cache of default size `projectCacheSize` that caches the computation of GetProjectOptionsFromScript. This computation can be lengthy as it can involve processing the transitive closure of all `#load` directives, which in turn can mean parsing an unbounded number of script files.

* `incrementalBuildersCache` - an MRU cache of projects where a handle is being kept to their incremental checking state, of default size `projectCacheSize` (200 by default, unless explicitly set as a parameter). The "current background project" (see the [FSharpChecker operations queue](queue.html)) will be one of these projects. When analyzing large collections of projects, this cache usually occupies by far the most memory. Decreasing the size of this cache can dramatically increase cache thrasing for larger solutions, leading to significant CPU and memory consumption in editor tooling.

* `braceMatchCache` - an MRU cache of size `braceMatchCacheSize` (default = 5) keeping the results of calls to MatchBraces, keyed by filename, source hash, and project options.

* `parseFileCache` - an MRU cache of size `parseFileCacheSize` (default = 2) keeping the results of ParseFile, keyed by filename, source hash, and project options.

* `checkFileInProjectCache` - an MRU cache of size `incrementalTypeCheckCacheSize` (default = 5) keeping the results of `ParseAndCheckFileInProject`, `CheckFileInProject` and/or `CheckFileInProjectIfReady`.This is keyed by filename, file source hash, and project options. The results held in this cache are only returned if they would reflect an accurate parse and check of the file.

* `getToolTipTextCache` - an aged lookup cache of strong size `getToolTipTextSize` (default = 5) computing the results of GetToolTipText.

* `ilModuleReaderCache` - an aged lookup of weak references to "readers" for references .NET binaries. Because these are all weak references, you can generally ignore this cache, since its entries will be automatically collected. Strong references to binary readers will be kept by other FCS data structures, for example, any project checkers, symbols or project checking results. In more detail, the bytes for referenced .NET binaries are read into memory all at once, eagerly. Files are not left open or memory-mapped when using `FSharpChecker` (as opposed to `FsiEvaluationSession`, which loads assemblies using reflection). The purpose of this cache is mainly to ensure that while setting up compilation, the reads of `mscorlib`, `FSharp.Core` and so on amortize cracking the DLLs.

* `frameworkTcImportsCache` - an aged lookup of strong size 8 which caches the process of setting up type checking against a set of system components (for example, a particular version of mscorlib, `FSharp.Core` and other system DLLs).  These resources are automatically shared between multiple project checkers which happen to reference the same set of system assemblies.

Profiling the memory used by the various caches can be done by looking for the corresponding static roots in memory profiling traces.
The sizes of some of these caches can be adjusted by giving parameters to `FSharpChecker`.  Unless otherwise noted, the cache sizes above indicate the "strong" size of the cache, where memory is held regardless of the memory pressure on the system. Some of the caches can also hold "weak" references which can be collected at will by the GC.

Because of these caches, you should generally use one global, shared FSharpChecker for any application that hosts the F# compiler service.

## Low-Memory Condition

There is a "maximum memory" limit specified by the `MaxMemory` property on FSharpChecker (in MB). If an FCS project operation is performed (see `CheckMaxMemoryReached` in `service.fs`) and `System.GC.GetTotalMemory(false)` reports a figure greater than this, then the strong sizes of all FCS caches are reduced to either 0 or 1.  This happens for the remainder of the lifetime of the FSharpChecker object. By default the maximum memory trigger is disabled, see `maxMBDefault` in `service.fs`. Reducing the FCS strong cache sizes does not guarantee there will be enough memory to continue operations - even holding one project strongly may exceed a process memory budget. It just means FCS may hold less memory strongly. If you do not want the maximum memory limit to apply then set MaxMemory to `System.Int32.MaxValue`.

## Attribution

This guide is based on an [original document](https://fsharp.github.io/FSharp.Compiler.Service/caches.html) written by the F# community.