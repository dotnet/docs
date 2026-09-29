---
title: What's new in F# 11
description: Explore record composition, extension-backed generic algorithms, direct delegates, async coordination, and deployment improvements in F# 11.
ms.topic: whats-new
ms.date: 09/29/2026
ai-usage: ai-generated
---

# What's new in F# 11

F# 11 lets you compose record models without repeating their fields and, in preview, adapt existing types to shared generic algorithms through extension members. Direct delegates preserve handler metadata for ASP.NET Core Minimal APIs, new async and task helpers coordinate cancellable work, and broader reflection-free interpolation helps trimming and Native AOT. Parallel compilation is now enabled by default.

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

A known target type selects the fields to keep. An anonymous record can then extend that projected value without declaring another named type. The example uses FSharp.Core 11's new `printn`, which writes a value using F#'s `string` conversion and adds a newline; `print` does the same without the newline:

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
> **Library and application settings:** The following library defines ordinary extensions and unresolved member constraints, so it can use `<LangVersion>11.0</LangVersion>`. The application makes the concrete calls that select extensions: it needs `<LangVersion>preview</LangVersion>` and `open Structural.Adapters`. A library that resolves extensions internally needs preview there, but a caller of an already-resolved API doesn't necessarily need it. Settings and `open` declarations aren't inherited through a library reference.

### One path algorithm over two framework types

`Complex` exposes real and imaginary components; `Vector2` exposes `X` and `Y`. In the **application**, the same compiled library function measures routes represented by either:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/consumer/Program.fs" id="Paths":::

The library's `Structural.Adapters` module supplies a common coordinate property:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="Coordinates":::

Its `Structural.Algorithms` module contains the member requirement and algorithm:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="PathLength":::

The constraint asks for a `Coordinates` property returning two floating-point values. `inline` lets the compiler select that property's implementation for the concrete point type. In earlier language modes, a direct `point.Coordinates` extension call can work while the same extension can't satisfy this generic requirement.

Passing a coordinate function explicitly remains a useful alternative. Extension-backed constraints let a library offer a member-based API that callers extend through adapters.

### Share transformations across lists and options

The same mechanism supports operations that change element types, not just arithmetic. In the **application**, a shared `map` function lets a name-cleaning operation work with a list, a present optional value, or an absent value:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/consumer/Program.fs" id="Mapping":::

In the **library's `Structural.Adapters` module**, the adapters delegate to the existing collection functions:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="MapAdapters":::

In the **library's `Structural.Algorithms` module**, the generic operation requests a static `Map` member:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="Map":::

Nested `map` composes the list and option operations while preserving `None`. The compiler selects members for concrete input and output types, rather than introducing a type parameter for an arbitrary container. Extensions don't make the adapted types implement a .NET interface.

See [Extension members for SRTP constraints](../language-reference/generics/extension-member-constraints.md) for the runnable projects, operator extensions, and library-boundary guidance.

Thanks to [@gusty](https://github.com/dotnet/fsharp/pull/19602) for extending SRTP support.

## Direct delegates and ASP.NET Core Minimal APIs

A .NET delegate records a method and, for an instance method, the object on which to call it—the receiver. Frameworks can inspect that method's parameters and attributes. F# 11 directly targets compatible named functions and methods instead of hiding them behind generated wrappers.

[ASP.NET Core Minimal APIs](/aspnet/core/fundamentals/minimal-apis/parameter-binding) use this metadata to bind route values, services, and headers. This named handler supplies all three:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="Handler":::

In an F# ASP.NET Core application, register the service and pass the delegate to `MapGet`:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="App":::

Run the [complete project](../language-reference/snippets/delegates/ShipmentApi.fsproj) from its directory with `dotnet run -- --urls http://127.0.0.1:5080`. Then send the request:

```console
curl -H "X-Customer: Ada" http://127.0.0.1:5080/shipments/SHP-1042
```

The response is `Ada: SHP-1042 is Dispatched`. ASP.NET Core sees the handler's `trackingId` parameter and its `[<FromServices>]` and `[<FromHeader>]` attributes.

Constructing another delegate for this handler also gives the same method/receiver identity:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="Identity":::

Not every construction uses the direct form: captures and argument adaptations can still require wrappers. For reliable event removal regardless of construction shape, retain the delegate used for subscription. See [Delegates](../language-reference/delegates.md#direct-construction-and-framework-metadata) for construction rules and null-receiver compatibility.

Thanks to [@kerams](https://github.com/dotnet/fsharp/pull/19993) for direct delegates.

## Async and task coordination

FSharp.Core 11 adds cancellation-aware bridges and matching transformation functions for `Async`, `Task`, and `ValueTask`. Use them with the existing `async` and `task` builders.

`ValueTask<'T>` is a struct that can hold a result directly or represent an asynchronous operation. Consume a given value task only once: don't await it repeatedly or feed the same value into separate transformation pipelines. If repeated awaits are necessary, convert it once with `Task.ofValueTask` and reuse only the resulting `Task`.

### Bound a batch of I/O operations

An `Async` value describes work that hasn't started; a task usually represents work already underway. To control task concurrency, supply **factories** that start operations when called:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Bounded":::

`Task.parallelLimit` runs at most four reads concurrently and returns their contents in input order, regardless of completion order. If one fails, it requests cancellation of sibling work. Passing each supplied token to the actual I/O lets that cancellation reach the operation.

The limit controls concurrent operations, not requests per second. Existing `Async.Parallel` already supports bounded concurrency; the new helpers provide a consistent task-factory API and unit-result variants.

A small controlled example makes the result ordering visible. `TaskCompletionSource<'T>` stands in for an operation whose result you can supply explicitly:

:::code language="fsharp" source="snippets/fsharp-11/Coordination.fs" id="Ordering":::

The second task is completed first, but the result array follows the factories' input order. The example doesn't assume a worker start order or elapsed time.

### Carry cancellation across an async/task boundary

`Async.StartTaskImmediate` starts a task factory with the running workflow's cancellation token and awaits it. That token comes from how the caller starts the workflow; it isn't a global setting. A single task failure reaches the handler as its underlying exception:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Await":::

Expose the same workflow to task-based .NET code without manually bridging cancellation:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="AsyncBoundary":::

`Task.startAsyncImmediate` starts on the calling thread until the first asynchronous suspension, not necessarily for the whole operation. For an existing task or value task, use `Async.Await`; the older `Async.AwaitTask` keeps its exception-wrapping behavior.

### Transform results and represent failures

The qualified modules in `Microsoft.FSharp.Control` share these operations. `M<'T>` below means the corresponding `Async<'T>`, `Task<'T>`, or `ValueTask<'T>`, not a type you declare.

| Qualified functions | Argument and result shape | Purpose |
|---|---|---|
| `Async.result`, `Task.result`, `ValueTask.result` | `'T -> M<'T>` | Wrap an existing result value. |
| `Async.map`, `Task.map`, `ValueTask.map` | `('T -> 'U) -> M<'T> -> M<'U>` | Transform a successful result. |
| `Async.bind`, `Task.bind`, `ValueTask.bind` | `('T -> M<'U>) -> M<'T> -> M<'U>` | Use the result to start the next computation. |
| `Async.catch`, `Task.catch`, `ValueTask.catch` | `M<'T> -> M<Result<'T, exn>>` | Represent success or a non-cancellation failure as `Result`. |
| `Async.catchWith`, `Task.catchWith`, `ValueTask.catchWith` | `(exn -> 'T) -> M<'T> -> M<'T>` | Replace a non-cancellation failure with a value. |

For example, transform file contents to a length and return a non-cancellation failure as an `Error`:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Pipeline":::

A file containing `Report 1` gives `Ok 8`; a missing file gives `Error` containing a `FileNotFoundException`. Cancellation still propagates.

See [Async and task functions](../language-reference/async-task-functions.md) for the full API, coordination options, and error-handling rules. The ValueTask helpers are included in FSharp.Core's `netstandard2.1` and `net10.0` builds, not its `netstandard2.0` build; your project's target framework determines which build NuGet selects.

Thanks to [@bartelink](https://github.com/dotnet/fsharp/pull/19844) for async/task API contributions.

### Reraise from a computation-expression handler

After you log a failure, `reraise ()` preserves the exception's original stack trace:

> [!NOTE]
> This use of `reraise` requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Reraise":::

See [Rethrow from a computation expression](../language-reference/computation-expressions.md#rethrow-from-a-computation-expression) for nested handlers and custom builders.

Thanks to [@xperiandri](https://github.com/dotnet/fsharp/pull/20405) for computation-expression rethrow support.

## Reflection-free interpolation and Native AOT

More ordinary interpolated strings avoid the reflection-based printf engine. Familiar reporting code benefits from new compiler output, not new syntax. Numeric values and supported .NET-format holes such as `{total:F2}`—where `F2` requests two decimal places—can use conversions and concatenation directly:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Report":::

The broader fast path helps [trimming](../../core/deploying/trimming/trim-self-contained.md), which removes unused code, and [Native AOT](../../core/deploying/native-aot/index.md), which compiles an application to native code ahead of execution. Earlier F# versions already optimized some string-only interpolation; F# 11 extends that benefit to more value and format combinations.

Printf-specific formats such as `%A{value}` can still need reflection. .NET-format holes use invariant culture: locale-independent formatting, such as a decimal point rather than the user's locale-specific decimal separator. Review localized output when upgrading. See [Interpolated strings](../language-reference/interpolated-strings.md#native-aot-and-string-valued-interpolation) for supported formats and explicit culture selection.

FSharp.Core also broadens Native AOT support for zero-based two-dimensional arrays. Its `net10.0` build, selected for projects targeting .NET 10 or later, supports the following initialization, mapping, and copying workload:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Grid":::

The calculation uses familiar array APIs; the change is their AOT support, not the printed result. See [Two-dimensional arrays and Native AOT](../language-reference/arrays.md#two-dimensional-arrays-and-native-aot) for the target-specific operation table. Running these examples as managed code doesn't establish that an entire application and its dependencies can be published with Native AOT.

Thanks to [@charlesroddie](https://github.com/dotnet/fsharp/pull/19971) for the interpolation implementation.

## Parallel compilation by default and less callback overhead

Parallel compilation is enabled by default. The compiler uses dependencies between source files to determine which files it can type-check in parallel, and also parallelizes optimization and code generation. Overload-resolution caching and pattern-match compiler improvements reduce repeated work. See [Parallel compilation](../language-reference/compiler-options.md#parallel-compilation) for controls to compare builds while keeping deterministic output.

Selected `List` and `Array` higher-order functions inline known callbacks, reducing closure overhead in familiar collection code:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Collection":::

Inlining can place the comparison that captures `limit` directly in the traversal. Other operations can still allocate their result collections; the Boolean output isn't a speed measurement. Library authors can use [`InlineIfLambda` with `OptimizeClosureIfNotInlined`](../language-reference/functions/inline-functions.md#optimize-curried-callbacks) to prepare a curried callback once for repeated calls when its body can't be inlined. Some empty-result array operations also reuse a shared empty array.

## Runtime async for builder authors

Builder authors can experiment with .NET runtime async in F# 11. Normally, the F# compiler generates a state machine that remembers where an asynchronous method should continue after an await. Runtime async lets the runtime pause and resume the marked method instead. `Task<'T>` still carries the result; FSharp.Core doesn't provide a new general-purpose builder for this mechanism.

> [!NOTE]
> The example uses an F# 11 compiler with runtime-async support, `<LangVersion>preview</LangVersion>`, .NET 11 RC1 (`11.0.0-rc.1.26425.128`) runtime and reference assemblies, and FSharp.Core `11.0.101-rc2.26473.112`'s `net10.0` build. Reference assemblies describe APIs to the compiler; the runtime must implement them. The required APIs are `MethodImplOptions.Async`, which marks runtime-async methods, and `AsyncHelpers.Await`, which supplies suspension points. The Core build provides the compiler-recognized return operation below. Targeting .NET 10 alone isn't sufficient. See [Runtime async experiments](../language-reference/task-expressions.md#runtime-async-experiments) for the exact compiler and project requirements.

A library-defined `runtimeTask` builder can present familiar task-consuming code:

:::code language="fsharp" source="../language-reference/snippets/task-expressions/RuntimeAsync.fs" id="RuntimeUse":::

Here is the small builder used by that example:

:::code language="fsharp" source="../language-reference/snippets/task-expressions/RuntimeAsync.fs" id="RuntimeBuilder":::

`Delay` defers the body. `Run` uses `__runtimeAsyncReturn`, an operation the compiler handles specially to mark the method for runtime async; it isn't an ordinary function to call directly. Inside that method, `AsyncHelpers.Await` can pause execution when a task is unfinished and let the method return a pending task to its caller. After the awaited task completes, execution resumes with its result. This isn't a blocking `.Result` call: the helper is only valid inside runtime-async methods.

The inline methods let the compiler recognize this structure after it expands the builder calls. The example supports the `let!` and `return` forms shown, not a full builder's loops, resource management, or exception handling. Ordinary `task` and `async` builders are unchanged.

Thanks to [@majocha](https://github.com/dotnet/fsharp/pull/20235) for runtime async.

## More precise .NET API contracts

F# 11 improves how callers use nullable results and how library authors guide overload selection.

### Conditional nullability

A type such as `string | null` permits a null value. The .NET [`NotNullIfNotNull` attribute](../../csharp/language-reference/attributes/nullable-analysis.md#conditional-postconditions-notnullwhen-maybenullwhen-and-notnullifnotnull) can promise that a method returns a non-null result when a particular input is non-null. F# 11 recognizes common forms of that contract:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Nullability":::

With `<Nullable>enable</Nullable>`, these assignments don't require redundant null handling. A nullable input still produces a nullable result. Null checking remains opt-in; see [Conditional return contracts](../language-reference/values/null-values.md#conditional-return-contracts).

A separate library-author addition, `Microsoft.FSharp.Core.Operators.Unchecked.withNull`, helps implement C# generic APIs whose unconstrained `T?` result permits null. It gives an unconstrained value the static type `'T | null` without a runtime check. Use it for that interop boundary, not to establish non-nullness; see the [generic interop example](../language-reference/values/null-values.md#unconstrained-nullable-generic-interop).

### Return-directed overloads

`AllowOverloadOnReturnType` lets an expected result type select an overload, without an extra dummy argument:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="ReturnOverloads":::

The attribute is supplied by FSharp.Core 11. See [Select by return type](../language-reference/parameters-and-arguments.md#select-by-return-type) for annotation and ambiguity rules.

### Generic overloads and required names

The **most-concrete tiebreaker** resolves otherwise ambiguous generic wrapper overloads:

> [!NOTE]
> The tiebreaker and `OverloadResolutionPriorityAttribute` support require `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Concrete":::

The compiler prefers the constructor parameter `Task<'T>` over a bare `'T`. A separate library-author feature, `OverloadResolutionPriorityAttribute`, lets an API keep older overloads while directing new compilations toward a preferred applicable overload. The example above demonstrates only the tiebreaker; see [Overload selection](../language-reference/parameters-and-arguments.md#overload-selection) for the priority attribute's own example and rules.

To distinguish parameters that would otherwise be easy to swap, an API can require argument names:

> [!NOTE]
> Enforcement requires `<LangVersion>preview</LangVersion>` and a definition of `System.Diagnostics.CodeAnalysis.RequireNamedArgumentsAttribute`. The [complete example](../language-reference/parameters-and-arguments.md#require-named-arguments) supplies a compatibility definition when reference assemblies lack the attribute.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Named":::

## XML documentation and conditional compilation

API authors can maintain documentation in an external file and include selected text with XML `<include>`. This example reads `shared.xml`:

:::code language="xml" source="../language-reference/snippets/xml-documentation/shared.xml":::

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Include":::

The compiler expands the selected XML into its documentation output. F# tooling can also resolve `<inheritdoc/>` for overrides; the compiler retains that tag for documentation consumers rather than copying the inherited prose. See [Reuse and inherit documentation](../language-reference/xml-documentation.md#reuse-and-inherit-documentation) for both forms.

For conditional source, `#elif` avoids nested `#if` groups:

:::code language="fsharp" source="../language-reference/snippets/compiler-directives/Region.fs" id="Region":::

Define `EU_WAREHOUSE` or `US_WAREHOUSE` to choose a branch; if both are defined, the first match wins. With neither, the output is `UTC`.

Other directive changes include F# Interactive's [`#version`](../tools/fsharp-interactive/index.md#display-version-information) command and tolerance for [`#:` lines](../language-reference/compiler-directives.md#host-directive-lines). F# ignores the latter so an external tool can interpret them; F# itself doesn't restore packages or apply build settings from their contents.

Smaller .NET interop changes let a class rely on a [derived interface's default implementation of an inherited member](../language-reference/interfaces.md#inherited-default-implementations) without redundant interface declarations, and let [ordinary closures read protected base fields](../language-reference/access-control.md#protected-base-fields-in-closures). Explicit generic arguments are checked in dependency order when one argument's constraint depends on another.

## Before upgrading

Keep these consequential changes in mind when upgrading:

| Affected code | Action |
|---|---|
| Libraries with `.fsi` files | Repeat enforced implementation attributes on the corresponding signature declaration. Examples include `RequiresExplicitTypeArguments` (callers must supply type arguments) on values, and `Struct` (value-type representation) on types. Missing required attributes now produce FS3888 errors. See the [declaration-specific list and matching examples](../language-reference/signature-files.md#compiler-semantic-attributes); this isn't a rule to copy every .NET attribute. |
| Extension-backed inline libraries | Review inferred signatures and [producer/consumer requirements](../language-reference/generics/extension-member-constraints.md#compile-libraries-and-consumers). Preview can retain more general constraints. |
| Delegates constructed from instance methods | When construction directly targets a method on a null object, failure moves from invocation to construction: typically `ArgumentException` for a non-virtual target or `NullReferenceException` for a virtual target. Validate the object before constructing the delegate, and move any relevant exception handling around construction. See [delegate compatibility](../language-reference/delegates.md#direct-construction-and-framework-metadata) for identity changes too. |
| Localized interpolated output | Choose an explicit culture when invariant .NET-format output isn't intended. |
| Custom builders that rely on a final `do!` choosing `ReturnFromFinal` or `YieldFromFinal` | A final `do!` now binds the operation and completes with unit: usually `Bind` then `Return(())`, or `Zero()` when no `Return` is available. Supply these operations, or write explicit `return!` or `yield!` when forwarding is intended. See [translation details, optimizations, and examples](../language-reference/computation-expressions.md#tail-operations-in-custom-builders). |
| Any computation expression ending in an unfinished `let!` | Provide the rest of the computation. For example, replace `async { let! value = work }` with `async { let! value = work in return value }` when the bound value is the intended result. |
| Older language settings | Supported numbered modes start at F# 8; non-strict indentation mode is removed. See [Language version and indentation](../language-reference/compiler-options.md#language-version-and-indentation). |
| Enum bitwise operations | Use [integral-backed enums](../language-reference/enumerations.md#bitwise-operations); invalid backing types are rejected. |
