---
title: What's new in F# 11
description: Explore F# 11 language features, expanded FSharp.Core APIs, better .NET integration, and compiler performance and memory improvements.
ms.topic: whats-new
ms.date: 10/16/2026
ai-usage: ai-generated
---

# What's new in F# 11

Welcome to F# 11! This release helps you keep domain models distinct, reuse generic algorithms, coordinate asynchronous work, and reduce compiler memory use.

- [Record spreads](#record-spreads-distinct-models-without-repetitive-mappings) reuse fields without forcing storage and application models to share a type.
- [Extension members in generic algorithms](#extension-members-for-generic-algorithms-operators-and-tuples) let existing types share operations without wrappers.
- [.NET integration](#net-integration-and-the-development-experience) preserves delegate metadata and reuses API documentation.
- [Async and task helpers](#async-and-task-coordination) carry cancellation across API boundaries and limit concurrent work.
- [Compiler and library improvements](#less-retained-memory-and-less-repeated-work) reduce repeated analysis and avoid some allocations.

Thank you to the F# community for the proposals, implementations, reviews, and tests behind these changes. Contributor links accompany the features below.

> [!NOTE]
> The examples require an F# 11 compiler and FSharp.Core 11 with the features shown. Preview features also require `<LangVersion>preview</LangVersion>`. The runtime-async example has [additional runtime requirements](#runtime-async-for-builder-authors); an earlier .NET 11 SDK alone might not contain every change.

## Record spreads: distinct models without repetitive mappings

To keep storage and application models distinct, record spreads reuse their shared fields without repeated declarations. Here the models share customer details but use different identifier types:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Models":::

`...CustomerDetails` contributes field declarations. At the boundary, `...row` copies values while the conversion parses the identifier:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Mapping":::

The destination keeps the shared details, replaces `Id`, and excludes `InternalNote`. `Guid.TryParse`, not the spread, validates the identifier; malformed input produces `Error`.

This addresses the [application-layer mapping problem](https://github.com/fsharp/fslang-design/discussions/806#discussioncomment-14516027). Value spreads also combine named and anonymous records; type spreads create named records only. Later fields win, and sources run once in order. See [Record spread operators](../language-reference/record-spreads.md) for composition examples and shared-evolution risks.

Thanks to [@brianrourkeboll](https://github.com/dotnet/fsharp/pull/18927) for record spreads.

## Extension members for generic algorithms, operators, and tuples

To share an algorithm across existing types, F# 11 preview lets **extension members satisfy statically resolved type parameter (SRTP) constraints**. For example, one transformation can handle lists and options without wrapper types.

> [!NOTE]
> Enable `<LangVersion>preview</LangVersion>` where extensions are resolved and open their module. See [library requirements](../language-reference/generics/extension-member-constraints.md#compile-libraries-and-consumers).

### Share a transformation across lists and options

With the library's `map` in scope, the application can clean either representation, change element types, and compose transformations:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/consumer/Program.fs" id="Mapping":::

The adapters in `Structural.Adapters` use familiar operations, rather than imposing new containers:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="MapAdapters":::

The shared function in `Structural.Algorithms` asks the input type for a static `Map` member:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="Map":::

`^Input` and `^Output` are statically resolved types. At each concrete call, the compiler selects the member with the required signature. The extensions don't add an interface implementation. The [complete application](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/extension-member-constraints/consumer/Program.fs) opens both modules.

### Operators, context, and output types

The same mechanism supports [tuple operators and context propagation](../language-reference/generics/extension-member-constraints.md#tuple-operators-and-context) and [output-directed construction](../language-reference/generics/extension-member-constraints.md#return-directed-construction). Native tuple headers require preview at their declarations as well as at extension-solving call sites.

A **separate** addition, `AllowOverloadOnReturnType`, lets one factory declare overloads distinguished by their returns:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="ReturnOverloads":::

This Core 11 attribute doesn't require preview. The result annotation selects an overload; without it the call remains ambiguous. See [Select by return type](../language-reference/parameters-and-arguments.md#select-by-return-type).

Thanks to [@gusty](https://github.com/dotnet/fsharp/pull/19602) for extending generic programming support.

## .NET integration and the development experience

### Direct delegates preserve the handler's real contract

To expose handler names and binding attributes to frameworks, F# 11 can target a compatible named function directly instead of a wrapper. [ASP.NET Core Minimal APIs](/aspnet/core/fundamentals/minimal-apis/parameter-binding) can then read the route, service, and header contract:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="Handler":::

See the [runnable project](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/delegates/ShipmentApi.fsproj) and [construction/compatibility rules](../language-reference/delegates.md#direct-construction-and-framework-metadata). Captures and argument adaptation can still require wrappers.

Thanks to [@kerams](https://github.com/dotnet/fsharp/pull/19993) for direct delegates.

### Reuse XML documentation

To maintain shared API remarks once, place them in `shared.xml`:

:::code language="xml" source="../language-reference/snippets/xml-documentation/shared.xml":::

With `GenerateDocumentationFile` enabled, F# 11 expands `<include>` into the emitted member entries:

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Include":::

The [include implementation](https://github.com/dotnet/fsharp/pull/19186) updates both descriptions from one fragment. Separately, the [tooling resolver](https://github.com/dotnet/fsharp/pull/19188) exposes base descriptions for `<inheritdoc/>`; the compiler leaves that tag for documentation consumers. See [XML documentation](../language-reference/xml-documentation.md#reuse-and-inherit-documentation) for examples and resolution rules.

Thanks to [@T-Gro](https://github.com/dotnet/fsharp/pull/20231) for shared XML documentation in FSharp.Core.

### Debug inline functions in non-optimized builds

To inspect inline helper arguments, set a breakpoint on `let total` in a non-optimized build and step into `addFee`. F# 11 now prefers callable methods in these builds:

:::code language="fsharp" source="../language-reference/snippets/inline-functions/DebugInline.fs" id="DebugInline":::

Optimized builds retain inlining. Some constructs must still expand. See [Debug inline functions](../language-reference/functions/inline-functions.md#debug-inline-functions) for those limits and the `--always-inline` control.

## Async and task coordination

To connect F# workflows with task-based APIs, FSharp.Core 11 adds cancellation-aware bridges, bounded batches, and result transformations.

### Bound outstanding I/O, not just the result collection

A large batch of reads can start more work than an application should have outstanding. To decide when task-based work begins, a coordinator needs **factories**, not tasks that have already started:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Bounded":::

At most four reads run concurrently; results retain input order. A failure requests sibling cancellation through the supplied tokens. This limits concurrency, not requests per second. See [Async and task functions](../language-reference/async-task-functions.md) for sequential and unit-result variants.

### Keep cancellation and the underlying exception across the boundary

When a workflow starts external work, its token should travel with that work. `Async.StartTaskImmediate` passes the running workflow's token to the task factory and waits for completion:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Await":::

A single task failure reaches this handler as the underlying `FileNotFoundException`. For an already-created task or value task, use `Async.Await`; the older `Async.AwaitTask` retains its exception-wrapping behavior.

For task-based callers, `Task.startAsyncImmediate token workflow` provides the reverse bridge. It starts on the calling thread until the first asynchronous suspension.

### Use matching helpers for short transformations

To transform one result without a full computation expression, use the matching helpers in `Microsoft.FSharp.Control`. For example, read a file, obtain its length, and return an ordinary failure as `Error`:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Pipeline":::

A file containing `Report 1` gives `Ok 8`; a missing file gives an `Error` containing `FileNotFoundException`. Cancellation still propagates. `Async` and `ValueTask` offer matching `map`, `bind`, and error helpers; see [Async and task functions](../language-reference/async-task-functions.md). Use a computation expression for branches or several dependent values.

ValueTask helpers require Core's `netstandard2.1` or `net10.0` build and [single consumption](../language-reference/async-task-functions.md#valuetask-and-library-availability).

Thanks to [@bartelink](https://github.com/dotnet/fsharp/pull/19844) for async/task API contributions.

### Reraise after asynchronous failure reporting

Operational logging should add information without changing what the caller catches or hiding where the failure began. Computation-expression handlers can now use `reraise ()` even after they await the logger:

> [!NOTE]
> Computation-expression rethrow requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Reraise":::

After successful logging, the same exception and original throw-site information propagate. A logger failure can replace the original. This addresses the [async observability request](https://github.com/fsharp/fslang-suggestions/issues/660) without runtime async. See [Rethrow from a computation expression](../language-reference/computation-expressions.md#rethrow-from-a-computation-expression).

Thanks to [@xperiandri](https://github.com/dotnet/fsharp/pull/20405) for this support.

## FSharp.Core can build on modern .NET

To use modern APIs without dropping older targets, FSharp.Core adds **`net10.0` alongside `netstandard2.0` and `netstandard2.1`**. NuGet selects the compatible build. Updated tool packaging also enables task-based asynchronous disposal in F# Interactive, as in compiled projects. See [FSharp.Core target frameworks](../fsharp-core-targeting.md).

Thanks to @T-Gro for [modern Core targeting](https://github.com/dotnet/fsharp/pull/20229) and [SDK tool packaging](https://github.com/dotnet/fsharp/pull/20555).

### Runtime async for builder authors

Builder authors can let the runtime suspend and resume marked methods instead of using compiler-generated state machines. An experimental library-defined builder exposes the mechanism as a computation expression:

:::code language="fsharp" source="../language-reference/snippets/task-expressions/RuntimeAsync.fs" id="RuntimeUse":::

> [!NOTE]
> This experimental builder requires preview where its inline implementation is defined or expanded, Core 11's `net10.0` build, and references and a runtime with runtime-async support. The verified runtime/reference combination here is .NET 11 RC1. Targeting .NET 10 alone isn't sufficient. See [Runtime async experiments](../language-reference/task-expressions.md#runtime-async-experiments).

FSharp.Core doesn't ship this sample as a general-purpose builder. Ordinary `task` and `async` code doesn't automatically switch to it, and callers of an already-compiled ordinary task-returning API don't inherently need preview.

Thanks to [@majocha](https://github.com/dotnet/fsharp/pull/20235) for runtime async.

## Native AOT-friendly text and two-dimensional arrays

To support [Native AOT](../../core/deploying/native-aot/index.md), F# 11 removes reflection-based formatting and dynamic allocation requirements from more common text and array operations.

### Print values and build strings without a redundant format layer

When you already have a string, you don't need a `"%s"` format just to write it. New Core functions `print` and `printn` accept values through F#'s `string` conversion; `printn` appends a newline:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Report":::

String interpolation uses direct conversion and `String.Concat` in more cases. .NET-format holes such as `{total:F2}` use invariant formatting and box the value; `%A` and precision-bearing printf forms can still need printf formatting. Select an explicit culture for localized output.

With `--reflectionfree`, records and unions also gain generated `ToString` output. See [Interpolation and Native AOT](../language-reference/interpolated-strings.md#native-aot-and-string-valued-interpolation) for culture examples and supported paths.

Thanks to [@bbatsov](https://github.com/dotnet/fsharp/pull/19265) for the print functions and [@charlesroddie](https://github.com/dotnet/fsharp/pull/19971) for the interpolation implementation.

### Keep ordinary zero-based grid operations

A zero-based grid shouldn't require a replacement Array2D module just to avoid a dynamic-code allocation path. Updated Core implementations support familiar initialization and transformation:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Grid":::

`Array2D.create`, `init`, and `rebase` use the zero-based allocation path across Core builds. Bounds-preserving `map`, `mapi`, and `copy` can use a newer .NET allocation API in the `net10.0` build; the .NET Standard builds retain their fallback. Non-zero-based arrays aren't deprecated, but their native allocation restrictions remain.

See [Two-dimensional arrays and Native AOT](../language-reference/arrays.md#two-dimensional-arrays-and-native-aot) for allocation paths and remaining restrictions. Check the complete application's publish diagnostics.

Thanks to [@T-Gro](https://github.com/dotnet/fsharp/pull/20338) for the Array2D improvements.

## Less retained memory and less repeated work

F# 11 reduces repeated compiler analysis and some application allocations. These affect different workloads.

### Share referenced libraries across projects

To avoid repeated copies of shared binary dependencies, the language service can share eligible imported library graphs across projects.

In [the implementing PR's retained-memory experiment](https://github.com/dotnet/fsharp/pull/20296), the ten-project ReSharper.FSharp solution fell from 1,547.2 MB to 1,002.2 MB with sharing enabled. That is an off/on measurement for that workload, not a general F# 10-to-11 reduction. Solutions dominated by project references rather than shared binary references can see much smaller gains.

Metadata reading and inline specialization also reduce temporary allocations, a separate metric. See [Tooling performance](../tools/tooling-performance.md) for scope and controls.

Thanks to [@auduchinok](https://github.com/dotnet/fsharp/pull/20296) for shared library imports.

### Compile independent work in parallel by default

[Parallel compilation](../language-reference/compiler-options.md#parallel-compilation) is now enabled by default, with deterministic output and source-order rules preserved. Overload caching and guarded-pattern improvements avoid other repeated work. Visual Studio/FCS also reduce unchanged-document analysis and bound concurrent checks; see [Tooling performance](../tools/tooling-performance.md).

### Avoid callback and empty-result allocation overhead

Selected `List` and `Array` functions now inline callbacks. For your own inline helpers, `OptimizeClosureIfNotInlined` adapts an opaque curried callback once:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Closure":::

Other allocations can remain. See [Optimize curried callbacks](../language-reference/functions/inline-functions.md#optimize-curried-callbacks) for requirements.

Empty results are another common case of successful work. [FSharpLint's motivating workload](https://github.com/dotnet/fsharp/issues/20382) repeatedly combined rules that found **no warnings**. Core now reuses shared empty arrays in more operations:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="EmptyResults":::

The change removes redundant empty-array objects, not every allocation in the pipeline. Don't rely on separate empty results having distinct reference identities.

Thanks to @T-Gro for [inline collection callbacks](https://github.com/dotnet/fsharp/pull/20422) and [shared empty arrays](https://github.com/dotnet/fsharp/pull/20388).

## More precise API calls and everyday conveniences

### Require names when generated parameter order can change

To protect generated APIs from silent parameter-order changes, an author can require named arguments:

> [!NOTE]
> Enforcement requires preview and an available `System.Diagnostics.CodeAnalysis.RequireNamedArgumentsAttribute` definition. The [complete sample](../language-reference/parameters-and-arguments.md#require-named-arguments) supplies a compatibility definition for references that lack it.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Named":::

Reordering the declaration preserves the named call's result, `0.75M`; a positional call is rejected. For the [generated-API use case](https://github.com/fsharp/fslang-suggestions/issues/414), the provider must emit the annotation.

### Recognize an already-wrapped generic argument

To avoid wrapping an existing task as a plain result value, a new last-resort overload rule prefers `Task<'T>` over bare `'T`:

> [!NOTE]
> The most-concrete tiebreaker and overload-priority behavior require preview.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Concrete":::

The result is `ValueTask<int>`, not `ValueTask<Task<int>>`. See [Overload selection](../language-reference/parameters-and-arguments.md#overload-selection) for the rule's limits.

### Prefer a new overload without removing the old entry point

A library might keep an old diagnostic method for existing binaries while adding an overload that includes the caller's source location. `OverloadResolutionPriorityAttribute` makes that preference explicit for newly compiled callers:

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Priority":::

The unchanged call selects the line-aware overload. See [Overload selection](../language-reference/parameters-and-arguments.md#overload-selection) for scope and compatibility rules.

### Use .NET's conditional nullability promises

If your file path is non-null, a Path API's nullable result shouldn't force a check that its own contract rules out. F# 11 consumes the existing .NET [`NotNullIfNotNull`](../../csharp/language-reference/attributes/nullable-analysis.md#conditional-postconditions-notnullwhen-maybenullwhen-and-notnullifnotnull) promise: a non-null named input implies a non-null result.

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Nullability":::

Enable `<Nullable>enable</Nullable>`. Nullable inputs still need nullable handling; see [Conditional return contracts](../language-reference/values/null-values.md#conditional-return-contracts). For unconstrained C# `T?` APIs, use the separate [`Unchecked.withNull` helper](../language-reference/values/null-values.md#unconstrained-nullable-generic-interop).

Thanks to [@kerams](https://github.com/dotnet/fsharp/pull/19977) for conditional nullability support.

### Smaller language improvements

To call a record type with .NET constructor syntax, use preview [record constructors](../language-reference/records.md#record-constructors):

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="RecordConstructor":::

Named arguments avoid dependence on field order. Thanks to [@charlesroddie](https://github.com/dotnet/fsharp/pull/19974) for this feature.

For conditional source, `#elif` avoids nested `#if` groups:

:::code language="fsharp" source="../language-reference/snippets/compiler-directives/Region.fs" id="Region":::

The first matching branch wins. The sample project defines `EU_WAREHOUSE` and prints `Europe/Paris`; with neither symbol defined, the output is `UTC`.

For related tooling and interop cases:

- To identify your interactive toolchain, use [`#version`](../tools/fsharp-interactive/index.md#display-version-information).
- To share source with an external host, F# accepts [`#:` host-directive lines](../language-reference/compiler-directives.md#host-directive-lines) without interpreting them as package or build instructions.
- To avoid redundant interface declarations, use a [derived interface's default implementation](../language-reference/interfaces.md#inherited-default-implementations).
- To read inherited state inside an ordinary closure, use the new support for [protected base fields](../language-reference/access-control.md#protected-base-fields-in-closures).

## Before upgrading

Keep these consequential changes in mind when upgrading:

| Affected code | Action |
|---|---|
| Libraries with `.fsi` files | Copy [enforced contract attributes](../language-reference/signature-files.md#compiler-semantic-attributes) to signatures; omissions are now FS3888 errors. |
| Extension-backed inline libraries | Review inferred signatures and [producer/consumer requirements](../language-reference/generics/extension-member-constraints.md#compile-libraries-and-consumers). Preview can retain more general constraints. |
| Instance-method delegates | Validate receivers before [direct construction](../language-reference/delegates.md#direct-construction-and-framework-metadata), when null-receiver failures now occur. |
| Localized interpolated output | .NET-format holes use invariant culture. Choose an explicit culture when localized output is intended. |
| Custom builders with final `do!` | Supply [binding and unit completion](../language-reference/computation-expressions.md#tail-operations-in-custom-builders); final `do!` no longer selects final-forwarding members. |
| Unfinished `let!` | Add the following computation body; an incomplete binding now has a more direct diagnostic. |
| Older language settings | Supported numbered modes start at F# 8; non-strict indentation mode is removed. See [Language version and indentation](../language-reference/compiler-options.md#language-version-and-indentation). |
| Enum bitwise operations | Use [integral-backed enums](../language-reference/enumerations.md#bitwise-operations); invalid backing types are rejected. |
