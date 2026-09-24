---
title: What's new in F# 11
description: Explore reflection-free string interpolation, record type and value spreads, direct delegates, and new asynchronous APIs in F# 11.
ms.topic: whats-new
ms.date: 09/24/2026
ai-usage: ai-generated
---

# What's new in F# 11

F# 11 removes reflection from common string interpolation, so a native command-line app can format its output without pulling in the reflection-based printf engine. Record spreads cut out repetitive field declarations and copying. Direct delegates let .NET frameworks see the handler you wrote, including the parameter metadata they need. New asynchronous APIs make cancellation, error handling, and bounded concurrency easier to express.

## Format output for native apps

For a small shipment-tracking utility, ordinary interpolation now produces output suitable for [Native AOT deployment](../../core/deploying/native-aot/index.md):

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Interpolation":::

Plain holes and .NET-format holes, such as `{weightKg:F2}`, no longer need reflection-based printf formatting. The new `printn` function writes the resulting string with a newline; `print` writes without one. Both also accept other values through F#'s `string` conversion.

This change doesn't make every printf format reflection-free. For supported formats, culture behavior, and the distinct `FormattableString` path, see [Interpolated strings](../language-reference/interpolated-strings.md#native-aot-and-string-valued-interpolation).

## Share record fields without repeating them

A shipping address belongs in several application models. **Record type spreads** let you declare those shared fields once while keeping a flat shipment model:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="RecordTypes":::

**Record expression spreads** fill those fields from existing values. They also work between named and anonymous records:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="RecordValues":::

`Shipment` is its own record type, not a subtype of `DeliveryAddress`. For projection into a smaller model, composition from multiple sources, field overrides, and compatibility considerations, see the new [Record spread operators](../language-reference/record-spreads.md) reference.

### Construct a record by its type name

When several records share field names, a constructor call identifies the intended type immediately and offers constructor completion:

> [!NOTE]
> Record constructor syntax requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="RecordConstructor":::

This syntax exposes the record's all-fields constructor to F#. It is separate from record spreads. See [Record constructors](../language-reference/records.md#record-constructors).

## Give .NET frameworks the original handler

ASP.NET Core Minimal APIs inspect a delegate's method parameters to bind route values, headers, and services. F# 11 **direct delegate construction** preserves that metadata when the delegate points directly at a compatible named function or method:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="Handler":::

Register the service and route in an ASP.NET Core app:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="App":::

A request to `/shipments/SHP-1042` with `X-Customer: Ada` returns `Ada: SHP-1042 is Dispatched`. The route parameter name, `[<FromServices>]`, and `[<FromHeader>]` come from `status`, rather than a generated wrapper method.

Direct construction also improves delegate equality and event-handler removal. Not every lambda or adapted function can become a direct delegate. See [Delegates](../language-reference/delegates.md#direct-construction-and-framework-metadata) for the runnable project, reflection checks, and the null-receiver compatibility change.

### Resolve common overloads with less help

Wrapping an existing task shouldn't require explaining that it isn't the result value itself. The **most-concrete tiebreaker** distinguishes generic wrapper overloads:

> [!NOTE]
> The most-concrete tiebreaker and `OverloadResolutionPriorityAttribute` support require `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Concrete":::

Library authors can also use `OverloadResolutionPriorityAttribute` to steer callers toward a preferred overload:

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Priority":::

Separately, `AllowOverloadOnReturnType` lets a library offer conversions selected by the expected result type:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="ReturnOverloads":::

See [Overload selection](../language-reference/parameters-and-arguments.md#overload-selection) for the scope of these rules.

### Make ambiguous-looking arguments explicit

Two Boolean arguments are easy to swap. API authors can require their callers to supply names:

> [!NOTE]
> Named-argument enforcement requires `<LangVersion>preview</LangVersion>` and a definition of `System.Diagnostics.CodeAnalysis.RequireNamedArgumentsAttribute`. The [complete example](../language-reference/parameters-and-arguments.md#require-named-arguments) supplies a compatibility definition for reference assemblies that don't contain it.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Named":::

## Use .NET conditional nullability contracts

[`NotNullIfNotNull`](../../csharp/language-reference/attributes/nullable-analysis.md#conditional-postconditions-notnullwhen-maybenullwhen-and-notnullifnotnull) is an existing .NET nullable contract, understood by C#, that promises a non-null result when the named input is non-null.

F# 11 uses that promise to avoid unnecessary null handling around APIs such as `Path.GetFileName` and `Path.GetExtension`:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Nullability":::

Null checking remains an independent opt-in with `<Nullable>enable</Nullable>`. A nullable input still needs nullable handling. See [Conditional return contracts](../language-reference/values/null-values.md#conditional-return-contracts).

## Control asynchronous work where it starts

To read many reports without opening them all at once, pass task **factories** to `Task.parallelLimit`. The helper starts at most four operations concurrently and returns results in input order:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Bounded":::

The token reaches each file operation. If one operation fails, the helper requests cancellation of sibling work. Already-started tasks can't be throttled retroactively.

To call a task-returning API from an async workflow, `Async.StartTaskImmediate` passes the workflow's cancellation token to the factory and awaits the result. Like the new `Async.Await`, it exposes a single task failure directly, so the handler can catch `FileNotFoundException`:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Await":::

### New FSharp.Core functions

The new helper modules use consistent names. In the following table, `M<'T>` means the corresponding `Async<'T>`, `Task<'T>`, or `ValueTask<'T>` result.

| Functions | Argument and result shape |
|---|---|
| `Async.result`, `Task.result`, `ValueTask.result` | `'T -> M<'T>` |
| `Async.map`, `Task.map`, `ValueTask.map` | `('T -> 'U) -> M<'T> -> M<'U>` |
| `Async.bind`, `Task.bind`, `ValueTask.bind` | `('T -> M<'U>) -> M<'T> -> M<'U>` |
| `Async.ignore`, `Task.ignore`, `ValueTask.ignore` | `M<'T> -> M<unit>` |
| `Async.catchWith`, `Task.catchWith`, `ValueTask.catchWith` | `(exn -> 'T) -> M<'T> -> M<'T>` |
| `Async.catch`, `Task.catch`, `ValueTask.catch` | `M<'T> -> M<Result<'T, exn>>` |
| `Async.empty`, `Task.empty`, `ValueTask.empty` | A computation with result `unit`. |

For example, turn a report read into a length calculation with a recoverable error value:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Pipeline":::

| Additional APIs | Purpose and result |
|---|---|
| `Task.parallelLimit`, `Async.parallelLimit` | Run with a positive concurrency limit; collect an ordered result array. |
| `Task.parallelDoLimit`, `Async.parallelDoLimit` | Run with a positive concurrency limit; return `unit`. |
| `Task.sequential`, `Task.sequentialDo`, `Async.sequentialDo` | Run one computation at a time; collect results or return `unit`. |
| `Task.startAsyncImmediate` | `CancellationToken -> Async<'T> -> Task<'T>` |
| `Task.ofValueTask`, `ValueTask.ofTask` | Convert between `ValueTask<'T>` and `Task<'T>`. |
| `Async.Await`, `Async.StartTaskImmediate` | Await task-like work, or start it with the ambient cancellation token. |
| `Async.RunSynchronouslyImmediate` | Run `Async<'T>` from the calling thread until the first suspension, then block for its result. |
| `ExtraTopLevelOperators.print`, `ExtraTopLevelOperators.printn` | `'T -> unit`; write a value to standard output. |
| `Operators.Unchecked.withNull` | Retype `'T` as `'T \| null` for unconstrained generic interop, without a runtime check. |

These additions require an FSharp.Core version that contains them. Cancellation still propagates through `catch` and `catchWith`; `ValueTask` still has single-consumption constraints. See [Async and task functions](../language-reference/async-task-functions.md) for signatures, exception behavior, and library-asset requirements.

### Report a failure without losing its origin

An async error handler can add context to a log and then propagate the original exception and stack trace:

> [!NOTE]
> `reraise` in computation-expression handlers requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Reraise":::

See [Rethrow from a computation expression](../language-reference/computation-expressions.md#rethrow-from-a-computation-expression).

### Experiment with runtime-managed suspension

Builder authors can explore .NET runtime async support, which lets the runtime manage suspension instead of a compiler-generated resumable state machine:

> [!NOTE]
> Runtime async is a prototype requiring `<LangVersion>preview</LangVersion>`, compatible runtime/reference metadata, and the FSharp.Core runtime-async intrinsic. It doesn't replace the standard `task` or `async` builders.

With the small application-defined builder in [Runtime async experiments](../language-reference/task-expressions.md#runtime-async-experiments), the call site is ordinary computation-expression code:

:::code language="fsharp" source="../language-reference/snippets/task-expressions/RuntimeAsync.fs" id="RuntimeUse":::

## Adapt existing types to generic inline code

An extension member can give a framework type the operation your generic code expects, without wrapping the type:

> [!NOTE]
> Extension members as statically resolved type parameter (SRTP) constraint solutions require `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Extensions":::

The same `resourceName` function accepts a `Uri` and an application record. Extensions must be in scope where the inline function is defined. See [Extension members and SRTP](../language-reference/generics/statically-resolved-type-parameters.md#extension-member-constraints).

## Reuse API documentation

To keep shared descriptions consistent, put them in an XML file and include them where needed:

:::code language="xml" source="../language-reference/snippets/xml-documentation/shared.xml":::

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Include":::

The compiler expands `<include>` into the generated XML documentation. For an override of a documented member, `<inheritdoc/>` lets compatible F# tooling display the inherited documentation:

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Inherit":::

The compiler preserves `<inheritdoc/>` for documentation consumers; it doesn't copy inherited prose into the XML output. See [Reuse and inherit documentation](../language-reference/xml-documentation.md#reuse-and-inherit-documentation) and the official [XML tag reference](../../csharp/language-reference/xmldoc/recommended-tags.md#reuse-documentation-text).

## Express build alternatives without nesting

A regional build can select one dispatch configuration from several alternatives with `#elif`:

:::code language="fsharp" source="../language-reference/snippets/compiler-directives/Region.fs" id="Region":::

Run the sample as `dotnet fsi --define:EU_WAREHOUSE Region.fs` or `dotnet fsi --define:US_WAREHOUSE Region.fs`. With neither symbol, it selects UTC. See [Conditional compilation directives](../language-reference/compiler-directives.md#conditional-compilation-directives) for first-match rules and host directive lines.

## Spend less time compiling and adapting code

Parallel compilation is on by default, combining graph-based checking with parallel optimization and code generation. Overload-resolution caching and improvements to pattern-match compilation reduce repeated compiler work. The [compiler options](../language-reference/compiler-options.md#parallel-compilation) reference explains how to compare sequential and parallel builds without disabling determinism.

Many `List` and `Array` higher-order functions now inline known callbacks to avoid per-call closure allocations. Library authors can apply the same approach with [`InlineIfLambda` and `OptimizeClosureIfNotInlined`](../language-reference/functions/inline-functions.md#optimize-curried-callbacks).

.NET interop also needs less scaffolding: [derived interfaces can cover inherited default implementations](../language-reference/interfaces.md#inherited-default-implementations), and [ordinary closures can read protected base fields](../language-reference/access-control.md#protected-base-fields-in-closures). Explicit generic arguments are checked in dependency order, avoiding spurious constraint failures.

When you upgrade existing code:

- Mirror compiler-semantic attributes in [signature files](../language-reference/signature-files.md#compiler-semantic-attributes). Omissions that can hide a contract are errors in F# 11.
- Use integral-backed enums for [bitwise operations](../language-reference/enumerations.md#bitwise-operations). Invalid backing types are rejected at compile time.
- Complete `let!` bindings with a body. Custom builder authors should review the [tail-operation contracts](../language-reference/computation-expressions.md#tail-operations-in-custom-builders), including terminal `do!`.
- Use a supported [language version](../language-reference/compiler-options.md#language-version-and-indentation). Numbered modes start at F# 8; the old non-strict indentation mode is removed.
