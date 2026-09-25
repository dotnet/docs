---
title: What's new in F# 11
description: Learn about record spreads, reflection-free string interpolation, direct delegates, async and task APIs, and compiler improvements in F# 11.
ms.topic: whats-new
ms.date: 09/25/2026
ai-usage: ai-generated
---

# What's new in F# 11

F# 11 makes common string interpolation reflection-free and suitable for Native AOT, reduces repetitive record code, and preserves handler metadata for ASP.NET Core Minimal APIs. New FSharp.Core functions simplify task interop and bounded concurrency. Parallel compilation is now the default.

## String interpolation without reflection

String-valued interpolation with plain or .NET-format holes no longer needs the reflection-based printf engine, including when the values aren't strings:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Interpolation":::

The compiler uses string conversions and concatenation for this form. The result is trimmable formatting code suitable for [Native AOT](../../core/deploying/native-aot/index.md), which compiles an application to native code ahead of time. FSharp.Core 11 also adds `print` and `printn`: both write a value using F#'s `string` conversion, and `printn` adds a newline.

Printf-specific formats such as `%A{value}` can still require reflection. .NET-format holes such as `{score:F1}` use invariant culture; review localized output when upgrading. See [Interpolated strings](../language-reference/interpolated-strings.md#native-aot-and-string-valued-interpolation) for format compatibility, explicit culture selection, and `FormattableString`.

Thanks to [@charlesroddie](https://github.com/dotnet/fsharp/pull/19971) for the interpolation implementation.

## Record type and expression spreads

Record spreads reuse fields across record types and combine values without a field-by-field copy. A **type spread** declares the fields of a new record:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="RecordTypes":::

An **expression spread** copies fields from a value. Named and anonymous records can both supply those fields:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="RecordValues":::

The rightmost contribution wins. Spreads also support multiple sources and projection into a smaller target record. `ClientOptions` is a distinct record type, not a subtype of `Endpoint`.

See [Record spread operators](../language-reference/record-spreads.md) for composition, projection, evaluation order, overlap warnings, and the API implications of shared field declarations.

Thanks to [@brianrourkeboll](https://github.com/dotnet/fsharp/pull/18927) for record spreads.

### Record constructors

Record constructors identify the record type at the call site and support named arguments:

> [!NOTE]
> Record constructor syntax requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="RecordConstructor":::

This syntax exposes a record's all-fields constructor to F#. It doesn't change record patterns or replace spread expressions. See [Record constructors](../language-reference/records.md#record-constructors) for field order and accessibility.

Thanks to [@charlesroddie](https://github.com/dotnet/fsharp/pull/19974) for record constructors.

## Direct delegates and ASP.NET Core Minimal APIs

Direct delegate construction lets a delegate point at a compatible named function or method instead of a generated wrapper. Frameworks that inspect the delegate can then see the original method and its parameter metadata.

[ASP.NET Core Minimal APIs](/aspnet/core/fundamentals/minimal-apis/parameter-binding) use that metadata to bind route values, services, and headers. This handler supplies all three:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="Handler":::

Register the service and pass the delegate to `MapGet`:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="App":::

```console
curl -H "X-Customer: Ada" http://127.0.0.1:5080/shipments/SHP-1042
```

The response is `Ada: SHP-1042 is Dispatched`. The framework reads `trackingId`, `[<FromServices>]`, and `[<FromHeader>]` from `status`.

Delegates with the same method and receiver also compare equal, so event-handler removal can match a newly constructed delegate. Captures and argument adaptations can still require wrappers. See [Delegates](../language-reference/delegates.md#direct-construction-and-framework-metadata) for the complete runnable project and the change in when null receivers fail.

Thanks to [@kerams](https://github.com/dotnet/fsharp/pull/19993) for direct delegate construction.

## Async and task APIs

FSharp.Core 11 adds cancellation-aware task interop, bounded concurrency, and matching helper functions for `Async`, `Task`, and `ValueTask`. These library additions work with the existing `async` and `task` builders.

### Task factories and bounded concurrency

`Task.parallelLimit` controls how many operations start at once. Pass factories, not already-running tasks:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Bounded":::

At most four file reads run concurrently, and their results retain the input order. Each read receives a cancellation token. If one operation fails, the helper requests cancellation of sibling work.

### Async task interop and exception handling

`Async.StartTaskImmediate` passes the workflow's ambient cancellation token to a task factory, then awaits its result. A single task failure propagates as its underlying exception:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Await":::

For an existing task or value task, use `Async.Await`. Both APIs let the handler catch `FileNotFoundException` directly, rather than an extra `AggregateException` wrapper. Existing `Async.AwaitTask` behavior is unchanged.

### Result transformations and API shapes

The helper modules in `Microsoft.FSharp.Control` share the following operations. In the table, `M<'T>` stands for the corresponding `Async<'T>`, `Task<'T>`, or `ValueTask<'T>`.

| Fully qualified functions | Argument and result shape |
|---|---|
| `Microsoft.FSharp.Control.Async.result`, `Microsoft.FSharp.Control.Task.result`, `Microsoft.FSharp.Control.ValueTask.result` | `'T -> M<'T>` |
| `Microsoft.FSharp.Control.Async.map`, `Microsoft.FSharp.Control.Task.map`, `Microsoft.FSharp.Control.ValueTask.map` | `('T -> 'U) -> M<'T> -> M<'U>` |
| `Microsoft.FSharp.Control.Async.bind`, `Microsoft.FSharp.Control.Task.bind`, `Microsoft.FSharp.Control.ValueTask.bind` | `('T -> M<'U>) -> M<'T> -> M<'U>` |
| `Microsoft.FSharp.Control.Async.ignore`, `Microsoft.FSharp.Control.Task.ignore`, `Microsoft.FSharp.Control.ValueTask.ignore` | `M<'T> -> M<unit>`; specify the input type argument. |
| `Microsoft.FSharp.Control.Async.catchWith`, `Microsoft.FSharp.Control.Task.catchWith`, `Microsoft.FSharp.Control.ValueTask.catchWith` | `(exn -> 'T) -> M<'T> -> M<'T>` |
| `Microsoft.FSharp.Control.Async.catch`, `Microsoft.FSharp.Control.Task.catch`, `Microsoft.FSharp.Control.ValueTask.catch` | `M<'T> -> M<Result<'T, exn>>` |
| `Microsoft.FSharp.Control.Async.empty`, `Microsoft.FSharp.Control.Task.empty`, `Microsoft.FSharp.Control.ValueTask.empty` | `M<unit>` |

For example, `map` transforms file contents into a length, and `catch` turns a non-cancellation failure into an `Error` value:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Pipeline":::

A file containing `Report 1` produces `Ok 8`; a missing file produces `Error` containing a `FileNotFoundException`. Cancellation still propagates instead of becoming an error value.

| Additional APIs | Argument and result shape |
|---|---|
| `Microsoft.FSharp.Control.Task.parallelLimit` | `int -> CancellationToken -> seq<CancellationToken -> Task<'T>> -> Task<'T[]>` |
| `Microsoft.FSharp.Control.Async.parallelLimit` | `int -> seq<Async<'T>> -> Async<'T[]>` |
| `Microsoft.FSharp.Control.Task.parallelDoLimit`, `Microsoft.FSharp.Control.Async.parallelDoLimit` | Corresponding bounded operations over unit computations, with a unit result. |
| `Microsoft.FSharp.Control.Task.sequential`, `Microsoft.FSharp.Control.Task.sequentialDo`, `Microsoft.FSharp.Control.Async.sequentialDo` | Run one computation at a time; collect results or return `unit`. |
| `Microsoft.FSharp.Control.Task.startAsyncImmediate` | `CancellationToken -> Async<'T> -> Task<'T>` |
| `Microsoft.FSharp.Control.Task.ofValueTask`, `Microsoft.FSharp.Control.ValueTask.ofTask` | `ValueTask<'T> -> Task<'T>` and `Task<'T> -> ValueTask<'T>`. |
| `Microsoft.FSharp.Control.Async.Await` | Await a `Task`, `ValueTask`, or supported task-like value as an async computation. |
| `Microsoft.FSharp.Control.Async.StartTaskImmediate` | Start a task-like value with the ambient cancellation token and await it. |
| `Microsoft.FSharp.Control.Async.RunSynchronouslyImmediate` | Start `Async<'T>` on the calling thread until its first suspension, then block for its result. |

See [Async and task functions](../language-reference/async-task-functions.md) for full overload shapes, cancellation and exception contracts, and library-asset requirements. Value tasks retain their single-consumption constraints.

Thanks to [@bartelink](https://github.com/dotnet/fsharp/pull/19844) for the async/task API contributions.

### Reraise in computation expressions

`reraise ()` can preserve the original exception and stack trace after a computation-expression handler logs a failure:

> [!NOTE]
> This use of `reraise` requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Reraise":::

Unlike `raise error`, a rethrow retains the failure's origin. See [Rethrow from a computation expression](../language-reference/computation-expressions.md#rethrow-from-a-computation-expression) for nested handlers and custom builders.

Thanks to [@xperiandri](https://github.com/dotnet/fsharp/pull/20405) for computation-expression rethrow support.

### Runtime async

F# 11 adds experimental support for .NET runtime async, where the runtime handles asynchronous methods that would otherwise require compiler-generated resumable state machines:

> [!NOTE]
> Runtime async requires `<LangVersion>preview</LangVersion>`, compatible runtime/reference metadata, and an FSharp.Core asset containing the runtime-async intrinsic. It doesn't replace the standard `task` or `async` builders.

The application-defined builder in [Runtime async experiments](../language-reference/task-expressions.md#runtime-async-experiments) supports this call site:

:::code language="fsharp" source="../language-reference/snippets/task-expressions/RuntimeAsync.fs" id="RuntimeUse":::

Thanks to [@majocha](https://github.com/dotnet/fsharp/pull/20235) for the runtime-async implementation.

## .NET nullability contracts

[`NotNullIfNotNull`](../../csharp/language-reference/attributes/nullable-analysis.md#conditional-postconditions-notnullwhen-maybenullwhen-and-notnullifnotnull) is a .NET attribute that describes a conditional return contract: a non-null input guarantees a non-null result. F# 11 recognizes common uses of that contract:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Nullability":::

With null checking enabled through `<Nullable>enable</Nullable>`, these assignments don't need redundant null handling. A nullable input still produces a nullable result. Null checking remains opt-in; see [Conditional return contracts](../language-reference/values/null-values.md#conditional-return-contracts) for supported cases.

For unconstrained generic interop, FSharp.Core also adds `Microsoft.FSharp.Core.Operators.Unchecked.withNull`, with shape `'T -> 'T | null`. It retypes a value without a runtime check; it doesn't prove the value is non-null. See [Unconstrained nullable generic interop](../language-reference/values/null-values.md#unconstrained-nullable-generic-interop).

## Overload resolution and named arguments

F# 11 adds ways to resolve generic overloads and express an API author's intended choice.

### Most-concrete tiebreaker and overload priority

The **most-concrete tiebreaker** resolves otherwise ambiguous generic wrapper overloads:

> [!NOTE]
> The tiebreaker and `OverloadResolutionPriorityAttribute` support require `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Concrete":::

The compiler prefers the `Task<'T>` constructor parameter over a bare `'T`. Library authors can separately use `OverloadResolutionPriorityAttribute` to prefer one applicable overload:

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Priority":::

See [Overload selection](../language-reference/parameters-and-arguments.md#overload-selection) for the order and scope of these rules.

### Return-type-directed overloads

`AllowOverloadOnReturnType` lets an expected result type select an overload:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="ReturnOverloads":::

See [Select by return type](../language-reference/parameters-and-arguments.md#select-by-return-type) for cases that still need an annotation.

### Required named arguments

API authors can require parameter names to make otherwise easy-to-swap arguments explicit:

> [!NOTE]
> Enforcement requires `<LangVersion>preview</LangVersion>` and a definition of `System.Diagnostics.CodeAnalysis.RequireNamedArgumentsAttribute`. The [complete example](../language-reference/parameters-and-arguments.md#require-named-arguments) includes a compatibility definition for reference assemblies that don't contain it.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Named":::

## Extension members for SRTP constraints

Extension members can supply operations required by generic inline code, even for types you don't own:

> [!NOTE]
> Extension members as statically resolved type parameter (SRTP) constraint solutions require `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Extensions":::

Extensions must be in scope where the inline function is defined. See [Extension member constraints](../language-reference/generics/statically-resolved-type-parameters.md#extension-member-constraints) for scope and compatibility rules.

Thanks to [@gusty](https://github.com/dotnet/fsharp/pull/19602) for extending SRTP support.

## XML documentation reuse

The compiler expands XML `<include>` tags so API members can share descriptions:

:::code language="xml" source="../language-reference/snippets/xml-documentation/shared.xml":::

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Include":::

F# tooling can also resolve `<inheritdoc/>` for an override:

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Inherit":::

The compiler retains `<inheritdoc/>` for documentation consumers rather than copying inherited prose into the output. See [Reuse and inherit documentation](../language-reference/xml-documentation.md#reuse-and-inherit-documentation) and the [XML tag reference](../../csharp/language-reference/xmldoc/recommended-tags.md#reuse-documentation-text).

## Conditional compilation with `#elif`

`#elif` expresses alternative build configurations without nested `#if` groups:

:::code language="fsharp" source="../language-reference/snippets/compiler-directives/Region.fs" id="Region":::

Run `dotnet fsi --define:EU_WAREHOUSE Region.fs` or `dotnet fsi --define:US_WAREHOUSE Region.fs` to select a branch. With neither symbol, the output is `UTC`; with both, the first match wins. See [Conditional compilation directives](../language-reference/compiler-directives.md#conditional-compilation-directives), including the separate support for host `#:` lines.

## Compiler and collection performance

Parallel compilation is enabled by default, including graph-based checking, optimization, and code generation. Overload-resolution caching and pattern-match compiler improvements reduce repeated work. See [Parallel compilation](../language-reference/compiler-options.md#parallel-compilation) to compare builds or investigate a regression without disabling determinism.

Many `List` and `Array` higher-order functions now inline known callbacks to avoid closure allocations. Library authors can use [`InlineIfLambda` with `OptimizeClosureIfNotInlined`](../language-reference/functions/inline-functions.md#optimize-curried-callbacks) to optimize a curried callback even when the caller passes it indirectly. Empty-result array operations can reuse a shared empty array.

Zero-based `Array2D` operations also improve Native AOT compatibility. The exact set depends on the FSharp.Core asset; see [Two-dimensional arrays and Native AOT](../language-reference/arrays.md#two-dimensional-arrays-and-native-aot) for supported operations and non-zero-based restrictions.

## Interop and upgrade guidance

- [Derived interfaces can cover inherited default implementations](../language-reference/interfaces.md#inherited-default-implementations), reducing redundant interface declarations.
- [Ordinary closures can read protected base fields](../language-reference/access-control.md#protected-base-fields-in-closures). Object expressions still need a workaround.
- Explicit generic arguments are checked in dependency order, avoiding spurious constraint failures.
- Mirror compiler-semantic attributes in [signature files](../language-reference/signature-files.md#compiler-semantic-attributes). Omissions that hide a contract are now errors.
- Use integral-backed enums for [bitwise operations](../language-reference/enumerations.md#bitwise-operations); invalid backing types are rejected.
- Complete `let!` bindings with a body. Custom builder authors should review [tail-operation contracts](../language-reference/computation-expressions.md#tail-operations-in-custom-builders), particularly terminal `do!`.
- Review [language version and indentation](../language-reference/compiler-options.md#language-version-and-indentation) when migrating older projects. Supported numbered modes start at F# 8; the non-strict indentation mode is removed.

## Acknowledgements

Thanks to [@charlesroddie](https://github.com/dotnet/fsharp/pull/19971), [@brianrourkeboll](https://github.com/dotnet/fsharp/pull/18927), [@kerams](https://github.com/dotnet/fsharp/pull/19993), [@bartelink](https://github.com/dotnet/fsharp/pull/19844), [@xperiandri](https://github.com/dotnet/fsharp/pull/20405), [@majocha](https://github.com/dotnet/fsharp/pull/20235), and [@gusty](https://github.com/dotnet/fsharp/pull/19602) for the contributions highlighted here.
