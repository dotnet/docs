---
title: What's new in F# 11
description: Explore record composition, extension-backed generic algorithms, direct delegates, async coordination, and deployment improvements in F# 11.
ms.topic: whats-new
ms.date: 09/29/2026
ai-usage: ai-generated
---

# What's new in F# 11

F# 11 lets you compose record models without repeating their fields and, in preview, adapt existing types to shared generic algorithms through extension members. Direct delegates bring F# handlers closer to .NET frameworks, new async and task helpers coordinate cancellable work, and broader reflection-free interpolation simplifies code for trimming and Native AOT.

## Record spreads: compose models and transformations

Record spreads work on both **types** and **values**. Use `...Type` to reuse field declarations and `...value` to copy field values. Unlike a same-type `{ record with ... }` update, a spread can compose several sources or construct a different record type.

### Strengthen a field after validation

A validated model often retains most of an incoming model's fields but gives one field a more precise type. For example, represent a positive quantity with a private union case so callers construct it through a check:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Quantity":::

The validated record reuses the incoming fields, replaces the quantity's type, and copies unchanged values only after validation succeeds:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Strengthen":::

`ValidatedOrderLine` is a distinct type, not a subtype of `OrderLine`. Its `Quantity` can't accidentally receive an unchecked `int`. The transformation specifies the meaningful change instead of repeating the product code and price:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="ValidationUse":::

### Combine data, then project a smaller view

Spreads also assemble a model from independent records. Here a listing combines product information and inventory, with an additional field computed at construction:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Compose":::

A known target type selects the fields to keep. An anonymous record can then extend that projected value without declaring another named type:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Project":::

For repeated fields, the **rightmost contribution wins**, in both declarations and expressions. Each source expression runs once, in source order. Adding fields to a spread source can also change the destination's public shape, so choose type spreads when shared evolution is intentional.

See [Record spread operators](../language-reference/record-spreads.md) for multiple-source overrides, nested updates, field attributes, and API compatibility.

Thanks to [@brianrourkeboll](https://github.com/dotnet/fsharp/pull/18927) for record spreads.

### Record constructors

For type-directed construction, record constructors offer positional or named arguments:

> [!NOTE]
> Record constructor syntax requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="RecordConstructor":::

Named arguments avoid depending on field order. Constructors don't replace spreads or change record patterns. See [Record constructors](../language-reference/records.md#record-constructors) for accessibility and ordering.

Thanks to [@charlesroddie](https://github.com/dotnet/fsharp/pull/19974) for record constructors.

## Extension members for statically resolved generic algorithms

An ordinary generic function can't assume that every input type has a particular property or operation. F# **statically resolved type parameters (SRTP)** let an inline function state that requirement: for each concrete type used, the compiler finds a member with the required name and signature. The `^T` notation below denotes such a type parameter.

F# 11 preview lets **extension members** satisfy these requirements. A library can define an algorithm in terms of the operations it needs, and an application can adapt a type from another assembly without wrapping or changing that type.

> [!NOTE]
> Use `<LangVersion>preview</LangVersion>` in a project that resolves these constraints through extensions. The following examples use a separately compiled F# 11 library and a preview consumer. The consumer must open the adapter module; a library's `open` declarations and language settings aren't inherited by its callers.

### One path algorithm over two framework types

`Complex` exposes real and imaginary components; `Vector2` exposes `X` and `Y`. With the adapters and `pathLength` implementation below, the same compiled function measures routes represented by either:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/consumer/Program.fs" id="Paths":::

The library's `Structural.Adapters` module supplies a common coordinate property:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="Coordinates":::

Its `Structural.Algorithms` module contains the member requirement and algorithm:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="PathLength":::

The constraint asks for a `Coordinates` property returning two floating-point values. `inline` lets the compiler select that property's implementation for the concrete point type. In earlier language modes, a direct `point.Coordinates` extension call can work while the same extension can't satisfy this generic requirement.

Passing a coordinate function explicitly remains a useful alternative. Extension-backed constraints let a library offer a member-based API that callers extend through adapters.

### Share transformations across lists and options

The same mechanism supports operations that change element types, not just arithmetic. A shared `map` function lets a name-cleaning operation work with a list, a present optional value, or an absent value:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/consumer/Program.fs" id="Mapping":::

The adapters delegate to the existing collection functions:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="MapAdapters":::

The generic operation requests a static `Map` member:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="Map":::

`map String.length` changes strings to integers. Nested `map` composes the list and option operations while preserving `None`. The compiler resolves complete input and output types; this isn't a new higher-kinded type parameter that stands for an arbitrary container. Extensions also don't make the adapted types implement a .NET interface.

The library above only exports ordinary extensions and unresolved member constraints, so its own compilation doesn't need preview. A library that resolves an extension internally needs preview there; a caller of an already-resolved API doesn't necessarily need it. Some inferred inline signatures also change in preview. See [Extension members for SRTP constraints](../language-reference/generics/extension-member-constraints.md) for runnable projects, operator extensions, and the precise library/consumer rules.

Thanks to [@gusty](https://github.com/dotnet/fsharp/pull/19602) for extending SRTP support.

## Direct delegates and ASP.NET Core Minimal APIs

A .NET delegate records a method and, for an instance method, a receiver. Frameworks can inspect that method's parameters and attributes. F# 11 directly targets compatible named functions and methods instead of hiding them behind generated wrappers.

[ASP.NET Core Minimal APIs](/aspnet/core/fundamentals/minimal-apis/parameter-binding) use this metadata to bind route values, services, and headers. This named handler supplies all three:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="Handler":::

Register the service and pass the delegate to `MapGet`:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="App":::

```console
curl -H "X-Customer: Ada" http://127.0.0.1:5080/shipments/SHP-1042
```

The response is `Ada: SHP-1042 is Dispatched`. ASP.NET Core sees the handler's `trackingId` parameter and its `[<FromServices>]` and `[<FromHeader>]` attributes.

Delegates that directly target the same method and receiver also compare equal, which supports matching event subscriptions for removal. Not every construction uses the direct form: captures and argument adaptations can still require wrappers. See [Delegates](../language-reference/delegates.md#direct-construction-and-framework-metadata) for the complete project, construction shapes, and null-receiver compatibility.

Thanks to [@kerams](https://github.com/dotnet/fsharp/pull/19993) for direct delegates.

## Async and task coordination

FSharp.Core 11 adds cancellation-aware bridges and matching transformation functions for `Async`, `Task`, and `ValueTask`. Use them with the existing `async` and `task` builders.

### Bound a batch of I/O operations

An `Async` value describes work that hasn't started; a task usually represents work already underway. To control task concurrency, supply **factories** that start operations when called:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Bounded":::

`Task.parallelLimit` runs at most four reads concurrently and returns their contents in input order, regardless of completion order. If one fails, it requests cancellation of sibling work. Passing each supplied token to the actual I/O lets that cancellation reach the operation.

The limit controls concurrent operations, not requests per second. Existing `Async.Parallel` already supports bounded concurrency; the new helpers provide a consistent task-factory API and unit-result variants.

### Carry cancellation across an async/task boundary

`Async.StartTaskImmediate` starts a task factory with the workflow's ambient cancellation token and awaits it. A single task failure reaches the handler as its underlying exception:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Await":::

Expose the same workflow to task-based .NET code without manually bridging cancellation:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="AsyncBoundary":::

`Task.startAsyncImmediate` starts on the calling thread until the first asynchronous suspension, not necessarily for the whole operation. For an existing task or value task, use `Async.Await`; the older `Async.AwaitTask` keeps its exception-wrapping behavior.

### Transform results and represent failures

The qualified modules in `Microsoft.FSharp.Control` share these operations. `M<'T>` below means the corresponding `Async<'T>`, `Task<'T>`, or `ValueTask<'T>`, not a type you declare.

| Qualified functions | Argument and result shape |
|---|---|
| `Async.result`, `Task.result`, `ValueTask.result` | `'T -> M<'T>` |
| `Async.map`, `Task.map`, `ValueTask.map` | `('T -> 'U) -> M<'T> -> M<'U>` |
| `Async.bind`, `Task.bind`, `ValueTask.bind` | `('T -> M<'U>) -> M<'T> -> M<'U>` |
| `Async.catch`, `Task.catch`, `ValueTask.catch` | `M<'T> -> M<Result<'T, exn>>` |
| `Async.catchWith`, `Task.catchWith`, `ValueTask.catchWith` | `(exn -> 'T) -> M<'T> -> M<'T>` |

For example, transform file contents to a length and return a non-cancellation failure as an `Error`:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Pipeline":::

A file containing `Report 1` gives `Ok 8`; a missing file gives `Error` containing a `FileNotFoundException`. Cancellation still propagates.

See [Async and task functions](../language-reference/async-task-functions.md) for the full API tables, including `ignore`, `empty`, sequential and unit-result coordination, value-task conversions, and `Async.RunSynchronouslyImmediate`. The reference also covers multiple faults, calling-thread behavior, and library-asset availability. Value tasks retain their single-consumption contract.

Thanks to [@bartelink](https://github.com/dotnet/fsharp/pull/19844) for async/task API contributions.

### Reraise from a computation-expression handler

After you log a failure, `reraise ()` preserves the exception's original stack trace:

> [!NOTE]
> This use of `reraise` requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Reraise":::

See [Rethrow from a computation expression](../language-reference/computation-expressions.md#rethrow-from-a-computation-expression) for nested handlers and custom builders.

Thanks to [@xperiandri](https://github.com/dotnet/fsharp/pull/20405) for computation-expression rethrow support.

## Reflection-free interpolation and Native AOT

More ordinary interpolated strings avoid the reflection-based printf engine. Numeric values and supported .NET-format holes can use conversions and concatenation directly:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Report":::

The broader fast path helps [trimming](../../core/deploying/trimming/trim-self-contained.md), which removes unused code, and [Native AOT](../../core/deploying/native-aot/index.md), which compiles an application to native code ahead of execution. Earlier F# versions already optimized some string-only interpolation; F# 11 extends that benefit to more value and format combinations. FSharp.Core 11's `print` and `printn` write a value using F#'s `string` conversion; `printn` adds a newline.

Printf-specific formats such as `%A{value}` can still need reflection. .NET-format holes such as `{total:F2}` use invariant culture, so review localized output when upgrading. See [Interpolated strings](../language-reference/interpolated-strings.md#native-aot-and-string-valued-interpolation) for supported formats and explicit culture selection.

FSharp.Core also broadens Native AOT support for zero-based two-dimensional arrays. For example, a .NET-targeted asset supports initialization, mapping, and copying:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Grid":::

See [Two-dimensional arrays and Native AOT](../language-reference/arrays.md#two-dimensional-arrays-and-native-aot) for the operation set in each asset and non-zero-based restrictions. These improvements don't make arbitrary reflection or an entire application's dependencies AOT-compatible.

Thanks to [@charlesroddie](https://github.com/dotnet/fsharp/pull/19971) for the interpolation implementation.

## Runtime async for library-defined builders

F# 11 adds experimental support for .NET runtime async. Instead of requiring the F# compiler to express every suspension as a resumable state machine, a builder can mark asynchronous methods for runtime handling. `Task<'T>` still carries the result.

> [!NOTE]
> Runtime async requires `<LangVersion>preview</LangVersion>`, compatible runtime/reference metadata, and an FSharp.Core asset containing the runtime-async intrinsic. It doesn't replace the standard `task` or `async` builders.

A library-defined `runtimeTask` builder can present familiar task-consuming code:

:::code language="fsharp" source="../language-reference/snippets/task-expressions/RuntimeAsync.fs" id="RuntimeUse":::

Here is the small builder used by that example:

:::code language="fsharp" source="../language-reference/snippets/task-expressions/RuntimeAsync.fs" id="RuntimeBuilder":::

`Delay` defers the body. `Run` uses the compiler-recognized runtime-async return intrinsic, and `Bind` connects a task await to the next computation. The methods are inline so the compiler can recognize the resulting asynchronous method.

This is infrastructure for builder authors, not a new general-purpose FSharp.Core builder. The example supports the `let!` and `return` forms shown; it doesn't implement a full builder's loops, resource management, or exception handling. See [Runtime async experiments](../language-reference/task-expressions.md#runtime-async-experiments) for requirements and a runnable example.

Thanks to [@majocha](https://github.com/dotnet/fsharp/pull/20235) for runtime async.

## More precise .NET API contracts

F# 11 improves how callers use nullable results and how library authors guide overload selection.

### Conditional nullability

A type such as `string | null` permits a null value. The .NET [`NotNullIfNotNull` attribute](../../csharp/language-reference/attributes/nullable-analysis.md#conditional-postconditions-notnullwhen-maybenullwhen-and-notnullifnotnull) can promise that a method returns a non-null result when a particular input is non-null. F# 11 recognizes common forms of that contract:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Nullability":::

With `<Nullable>enable</Nullable>`, these assignments don't require redundant null handling. A nullable input still produces a nullable result. Null checking remains opt-in; see [Conditional return contracts](../language-reference/values/null-values.md#conditional-return-contracts).

For unconstrained generic interop, `Microsoft.FSharp.Core.Operators.Unchecked.withNull` has shape `'T -> 'T | null`. It retypes a value without checking it; it doesn't establish non-nullness. See [Unconstrained nullable generic interop](../language-reference/values/null-values.md#unconstrained-nullable-generic-interop).

### Return-directed overloads

`AllowOverloadOnReturnType` lets an expected result type select an overload, without an extra dummy argument:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="ReturnOverloads":::

The attribute is supplied by FSharp.Core 11. See [Select by return type](../language-reference/parameters-and-arguments.md#select-by-return-type) for annotation and ambiguity rules.

### Generic overloads and required names

The **most-concrete tiebreaker** resolves otherwise ambiguous generic wrapper overloads:

> [!NOTE]
> The tiebreaker and `OverloadResolutionPriorityAttribute` support require `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Concrete":::

The compiler prefers the constructor parameter `Task<'T>` over a bare `'T`. Separately, library authors can use `OverloadResolutionPriorityAttribute` to prefer one applicable overload. See [Overload selection](../language-reference/parameters-and-arguments.md#overload-selection) for an example and the order of these rules.

To distinguish parameters that would otherwise be easy to swap, an API can require argument names:

> [!NOTE]
> Enforcement requires `<LangVersion>preview</LangVersion>` and a definition of `System.Diagnostics.CodeAnalysis.RequireNamedArgumentsAttribute`. The [complete example](../language-reference/parameters-and-arguments.md#require-named-arguments) supplies a compatibility definition when reference assemblies lack the attribute.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Named":::

## Collection and compiler performance

Selected `List` and `Array` higher-order functions inline known callbacks, reducing closure overhead in ordinary collection code:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Collection":::

The predicate captures `limit`; inlining lets the compiler place that comparison in the array traversal instead of retaining a separate capturing callback. Other operations can still allocate their result collections. Library authors can use [`InlineIfLambda` with `OptimizeClosureIfNotInlined`](../language-reference/functions/inline-functions.md#optimize-curried-callbacks) to adapt an opaque curried callback once rather than repeatedly inside a loop. Some empty-result array operations also reuse a shared empty array.

Parallel compilation is enabled by default, including graph-based checking, optimization, and code generation. Overload-resolution caching and pattern-match compiler improvements reduce repeated work; parallel-build fixes improve correctness and reproducibility. See [Parallel compilation](../language-reference/compiler-options.md#parallel-compilation) for controls to compare builds while keeping determinism enabled.

## XML documentation and conditional compilation

API authors can share documentation text through XML `<include>`:

:::code language="xml" source="../language-reference/snippets/xml-documentation/shared.xml":::

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Include":::

The compiler expands the selected XML into its documentation output. F# tooling can also resolve `<inheritdoc/>` for overrides; the compiler retains that tag for documentation consumers rather than copying the inherited prose. See [Reuse and inherit documentation](../language-reference/xml-documentation.md#reuse-and-inherit-documentation) for both forms.

For conditional source, `#elif` avoids nested `#if` groups:

:::code language="fsharp" source="../language-reference/snippets/compiler-directives/Region.fs" id="Region":::

Define `EU_WAREHOUSE` or `US_WAREHOUSE` to choose a branch; if both are defined, the first match wins. With neither, the output is `UTC`. F# also ignores host `#:` lines; that doesn't implement C# file-based application tooling. See [Compiler directives](../language-reference/compiler-directives.md) and F# Interactive's new [`#version` directive](../tools/fsharp-interactive/index.md#display-version-information).

## Interop and upgrade guidance

Smaller changes remove .NET interop obstacles: [derived interfaces can cover inherited default implementations](../language-reference/interfaces.md#inherited-default-implementations), [ordinary closures can read protected base fields](../language-reference/access-control.md#protected-base-fields-in-closures), and explicit generic arguments are checked in dependency order to avoid spurious constraint failures.

Keep these consequential changes in mind when upgrading:

| Affected code | Action |
|---|---|
| Libraries with `.fsi` files | Mirror [compiler-semantic attributes](../language-reference/signature-files.md#compiler-semantic-attributes) in the signature. Omissions that hide a contract are now errors. |
| Extension-backed inline libraries | Review inferred signatures and [producer/consumer requirements](../language-reference/generics/extension-member-constraints.md#compile-libraries-and-consumers). Preview can retain more general constraints. |
| Code that inspects or compares delegates | Review changed method/receiver identity and [null-receiver failure timing](../language-reference/delegates.md#direct-construction-and-framework-metadata). |
| Localized interpolated output | Choose an explicit culture when invariant .NET-format output isn't intended. |
| Custom computation-expression builders | Review [tail-operation contracts](../language-reference/computation-expressions.md#tail-operations-in-custom-builders), particularly terminal `do!`. Complete `let!` bindings with a body. |
| Older language settings | Supported numbered modes start at F# 8; non-strict indentation mode is removed. See [Language version and indentation](../language-reference/compiler-options.md#language-version-and-indentation). |
| Enum bitwise operations | Use [integral-backed enums](../language-reference/enumerations.md#bitwise-operations); invalid backing types are rejected. |

## Acknowledgements

Thanks to [@brianrourkeboll](https://github.com/dotnet/fsharp/pull/18927), [@gusty](https://github.com/dotnet/fsharp/pull/19602), [@kerams](https://github.com/dotnet/fsharp/pull/19993), [@bartelink](https://github.com/dotnet/fsharp/pull/19844), [@charlesroddie](https://github.com/dotnet/fsharp/pull/19971), [@majocha](https://github.com/dotnet/fsharp/pull/20235), and [@xperiandri](https://github.com/dotnet/fsharp/pull/20405) for the contributions highlighted here.
