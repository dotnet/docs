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

To keep storage details out of your application model, give each model its own type. Record spreads reuse the fields those types share without repeating field declarations and assignments.

### Separate storage representation from domain meaning

These records deliberately share customer details, but give the identifier different types. Only the storage row carries an internal note:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Models":::

In a type declaration, `...CustomerDetails` contributes its field declarations to a new named record. `Customer` and `CustomerRow` remain distinct types; neither is a subtype of the other.

At the boundary, the conversion says what matters: parse the identifier and choose the destination model. The value spread, `...row`, supplies its unchanged fields:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Mapping":::

`Guid.TryParse` performs the check; spreading doesn't validate data. The destination's declared shape keeps `Name` and `PreferredLanguage`, replaces `Id`, and excludes `InternalNote`. A malformed identifier produces `Error`, not a partially converted customer.

The example addresses the [application-layer mapping problem behind the design](https://github.com/fsharp/fslang-design/discussions/806#discussioncomment-14516027). Use type spreads when fields should evolve together; use value spreads even when you declare the source and destination types independently.

### Assemble a frontend model from named and anonymous records

A product card needs public product details and stock counts, not the complete persistence model. Its fields can combine a named source type and an anonymous one:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="ComposeTypes":::

The value construction combines independently obtained data and computes availability. Local UI state can then use an anonymous record:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Compose":::

`InternalCost` isn't a field of `ProductCard` or the resulting view state. An independently declared destination also makes a smaller projection explicit:

:::code language="fsharp" source="snippets/fsharp-11/Records.fs" id="Project":::

Value spreads work between named and anonymous records in all four source/destination combinations. **Type** spreads produce named records only. They don't introduce implicit conversions, an omission operator, or database-side projection.

For repeated fields, the rightmost contribution wins; source expressions run once in source order. Unlike a same-type `{ record with ... }` update, spreads can construct a different record or combine several sources. See [Record spread operators](../language-reference/record-spreads.md) for field-type replacement, evaluation, and shared-evolution guidance.

Thanks to [@brianrourkeboll](https://github.com/dotnet/fsharp/pull/18927) for record spreads.

## Extension members for generic algorithms, operators, and tuples

A reusable transformation might need to work on both a batch and a single optional value. Instead of separate algorithms or wrapper types, extension members let each existing type supply the operations a shared algorithm needs.

F# 11 preview lets **extension members satisfy statically resolved type parameter (SRTP) constraints**. An extension that works in a direct call can now also supply the required member in a generic operation.

> [!NOTE]
> Extension-based constraint solving requires `<LangVersion>preview</LangVersion>` where the compiler selects the extensions. Open their module at the call site. Library requirements depend on whether it merely exports a constraint or also resolves it; [the reference explains the producer/consumer cases](../language-reference/generics/extension-member-constraints.md#compile-libraries-and-consumers).

### Share a transformation across lists and options

With the library's `map` in scope, the application can clean either representation, change element types, and compose transformations:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/consumer/Program.fs" id="Mapping":::

The adapters in `Structural.Adapters` use familiar operations, rather than imposing new containers:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="MapAdapters":::

The shared function in `Structural.Algorithms` asks the input type for a static `Map` member:

:::code language="fsharp" source="../language-reference/snippets/extension-member-constraints/library/Library.fs" id="Map":::

`^Input` and `^Output` are statically resolved types. At each concrete call, the compiler selects the member with the required signature. The extensions don't add an interface implementation. The [complete application](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/extension-member-constraints/consumer/Program.fs) opens both modules.

The same capability reaches beyond collections: [a path-length example](../language-reference/generics/extension-member-constraints.md#adapt-a-property-for-a-shared-algorithm) adapts the different coordinate APIs of `Complex` and `Vector2` to one algorithm.

### Operators, context, and output types

The same mechanism supports these capabilities:

- [Operator composition](../language-reference/generics/extension-member-constraints.md#tuple-operators-and-context) combines counts, observations, and tuple components without wrappers.
- [Context propagation](../language-reference/generics/extension-member-constraints.md#tuple-operators-and-context) carries an audit trail alongside a calculation.
- [Return-directed construction](../language-reference/generics/extension-member-constraints.md#return-directed-construction) uses the expected output type to select a container without a dummy argument. See the [return-overloading proposal](https://github.com/fsharp/fslang-suggestions/issues/820#issuecomment-568313755) for the original problem.

Native reference and struct tuple headers support two through seven elements and require preview where declared. Callers also need preview to resolve extension operators. These headers don't enable tuple instance-dot calls or function-type headers.

A **separate** addition, `AllowOverloadOnReturnType`, lets one factory declare overloads distinguished by their returns:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="ReturnOverloads":::

This attribute comes from FSharp.Core 11 and doesn't itself require preview. The expected result type disambiguates the call; remove it and these overloads are ambiguous. Structural return-directed construction instead selects a member on the supporting output type. See [Select by return type](../language-reference/parameters-and-arguments.md#select-by-return-type).

Thanks to [@gusty](https://github.com/dotnet/fsharp/pull/19602) for extending generic programming support.

## .NET integration and the development experience

### Direct delegates preserve the handler's real contract

Named handlers are easier to reuse and test, but a web framework also needs their parameter names and binding attributes. Previously, a generated delegate wrapper could hide that metadata. F# 11 can point the delegate directly at the compatible named function, so [ASP.NET Core Minimal APIs](/aspnet/core/fundamentals/minimal-apis/parameter-binding) see the contract you wrote.

This handler takes a route value, a service, and a named header:

:::code language="fsharp" source="../language-reference/snippets/delegates/Program.fs" id="Handler":::

The framework binds `trackingId` from the route, resolves the service, and reads the `X-Customer` header. For the runnable application, see the [complete project](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/delegates/ShipmentApi.fsproj).

Direct construction also exposes the original method/receiver identity. Captures, argument adaptation, and other expression shapes can still require wrappers; this isn't delegate caching. See [Delegates](../language-reference/delegates.md#direct-construction-and-framework-metadata) for construction rules and null-receiver compatibility.

Thanks to [@kerams](https://github.com/dotnet/fsharp/pull/19993) for direct delegates.

### XML include: one maintenance point for shared text

Related API members often need the same important remarks but different summaries. Copying those remarks leaves several places to update when the contract changes. XML [`<include>`](../../csharp/language-reference/xmldoc/recommended-tags.md#include) lets you maintain the common text once and put it into each member's generated documentation.

Here `shared.xml` holds the policy for an unknown shipment:

:::code language="xml" source="../language-reference/snippets/xml-documentation/shared.xml":::

Both APIs include that policy while keeping their own summaries:

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Include":::

With `GenerateDocumentationFile` enabled, both emitted member entries contain the shared `remarks`. Change the fragment and regenerate to update both. See the [include implementation](https://github.com/dotnet/fsharp/pull/19186) and [Include resolution](../language-reference/xml-documentation.md#reuse-and-inherit-documentation) for paths, XPath, and diagnostics.

Thanks to [@T-Gro](https://github.com/dotnet/fsharp/pull/20231) for applying shared XML documentation in FSharp.Core.

### XML inheritdoc: find the abstraction's contract on its implementation

When a base API already documents an operation, repeating that text on every override risks drift. F# tooling can now show the inherited description when you ask for help on the implementing member:

:::code language="fsharp" source="../language-reference/snippets/xml-documentation/Tracking.fs" id="Inherit":::

Help for `TrackingService.Status` exposes “Find the latest status of a shipment.” The compiler still emits [`<inheritdoc/>`](../../csharp/language-reference/xmldoc/recommended-tags.md#inheritdoc); the [new resolver](https://github.com/dotnet/fsharp/pull/19188) belongs to F# tooling and FSharp.Compiler.Service, not to XML emission. Downstream documentation generators need their own inheritance support. See [Inherited documentation in tooling](../language-reference/xml-documentation.md#inherited-documentation-in-tooling).

### Debug inline functions in non-optimized builds

An inline helper shouldn't force you to choose between efficient Release code and useful breakpoints during development. In non-optimized builds, the compiler now prefers callable methods for inline functions, with source sequence points that support stepping into their bodies and inspecting arguments.

Set a breakpoint on `let total` in a non-optimized build, then step into `addFee`:

:::code language="fsharp" source="../language-reference/snippets/inline-functions/DebugInline.fs" id="DebugInline":::

Optimized builds retain inlining. Some constructs must still expand. See [Debug inline functions](../language-reference/functions/inline-functions.md#debug-inline-functions) for those limits and the `--always-inline` control.

## Async and task coordination

File and HTTP APIs return tasks; F# workflows carry cancellation and handle exceptions. Bridging the two shouldn't require each project to rediscover the same helpers. FSharp.Core 11 brings coordinated operations for short transformations, cancellation-aware startup, and bounded batches, alongside the existing `async` and `task` builders.

### Bound outstanding I/O, not just the result collection

A large batch of reads can start more work than an application should have outstanding. To decide when task-based work begins, a coordinator needs **factories**, not tasks that have already started:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Bounded":::

`Task.parallelLimit` runs at most four reads concurrently and returns contents in input order, regardless of completion order. If one fails, it requests cancellation of sibling work. Passing the supplied token into the I/O lets that request reach the operation.

The limit controls concurrency, not requests per second. Existing `Async.Parallel` already supports bounded concurrency; the new task-factory API and unit-result variants make this coordination more consistent. See [Async and task functions](../language-reference/async-task-functions.md) for sequential variants and a controlled out-of-order completion example.

### Keep cancellation and the underlying exception across the boundary

When a workflow starts external work, its token should travel with that work. `Async.StartTaskImmediate` passes the running workflow's token to the task factory and waits for completion:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Await":::

A single task failure reaches this handler as the underlying `FileNotFoundException`. For an already-created task or value task, use `Async.Await`; the older `Async.AwaitTask` retains its exception-wrapping behavior.

The reverse boundary also makes cancellation explicit:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="AsyncBoundary":::

`Task.startAsyncImmediate` starts the workflow on the calling thread until its first asynchronous suspension. It doesn't force uncooperative I/O to cancel.

For debugging or tests that need a blocking entry point, `Async.RunSynchronouslyImmediate` starts directly on the calling thread for a simpler initial call stack. It remains a blocking boundary, with different synchronization-context behavior from `RunSynchronously`; it isn't a general replacement.

### Use matching helpers for short transformations

To transform one result without a full computation expression, use the matching helpers in `Microsoft.FSharp.Control`. For example, read a file, obtain its length, and return an ordinary failure as `Error`:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Pipeline":::

A file containing `Report 1` gives `Ok 8`; a missing file gives an `Error` containing `FileNotFoundException`. Cancellation still propagates. `Async` and `ValueTask` offer matching `map`, `bind`, and error helpers; see [Async and task functions](../language-reference/async-task-functions.md). Use a computation expression for branches or several dependent values.

`ValueTask<'T>` can hold a result directly or represent asynchronous work. Consume each value task only once, including copies and separate transformation pipelines. If you need repeated awaits, convert once with `Task.ofValueTask` and reuse only the resulting task. ValueTask helpers are in Core's `netstandard2.1` and `net10.0` builds, not `netstandard2.0`.

Thanks to [@bartelink](https://github.com/dotnet/fsharp/pull/19844) for async/task API contributions.

### Reraise after asynchronous failure reporting

Operational logging should add information without changing what the caller catches or hiding where the failure began. Computation-expression handlers can now use `reraise ()` even after they await the logger:

> [!NOTE]
> Computation-expression rethrow requires `<LangVersion>preview</LangVersion>`.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Reraise":::

If the logger completes successfully, the caller receives the same exception object with its original throw-site information preserved. Exception-dispatch frames can be added; the stack needn't be byte-for-byte identical. If logging itself fails, that failure can replace the original.

This addresses the [long-standing async observability request](https://github.com/fsharp/fslang-suggestions/issues/660), without a custom exception-dispatch helper. It doesn't require runtime async. See [Rethrow from a computation expression](../language-reference/computation-expressions.md#rethrow-from-a-computation-expression).

Thanks to [@xperiandri](https://github.com/dotnet/fsharp/pull/20405) for this support.

## FSharp.Core can build on modern .NET

Running on a newer runtime doesn't let a library directly call APIs absent from its compilation target. FSharp.Core now ships a **`net10.0` build alongside `netstandard2.0` and `netstandard2.1`**, so it can use modern .NET APIs while retaining the older-target builds.

NuGet selects the compatible build for your project. The modern target permits target-specific APIs and behavior without removing the .NET Standard builds. The target version advances through an explicit release decision, not an automatic “always latest .NET” policy.

The SDK toolset also uses the modern Core build so task-based asynchronous disposal works in F# Interactive as it already did in compiled projects. The change fixes tool packaging; it doesn't introduce `IAsyncDisposable` support to task expressions. See [FSharp.Core target frameworks](../fsharp-core-targeting.md).

Thanks to @T-Gro for [modern Core targeting](https://github.com/dotnet/fsharp/pull/20229) and [SDK tool packaging](https://github.com/dotnet/fsharp/pull/20555).

### Runtime async for builder authors

Builder authors can explore a further consequence of modern runtime support: let the runtime suspend and resume a marked method instead of having the language compiler generate the usual async state machine. A library-defined builder can expose that mechanism through familiar computation-expression use:

:::code language="fsharp" source="../language-reference/snippets/task-expressions/RuntimeAsync.fs" id="RuntimeUse":::

> [!NOTE]
> This experimental builder requires preview where its inline implementation is defined or expanded, Core 11's `net10.0` build, and references and a runtime with runtime-async support. The verified runtime/reference combination here is .NET 11 RC1. Targeting .NET 10 alone isn't sufficient. See [Runtime async experiments](../language-reference/task-expressions.md#runtime-async-experiments).

FSharp.Core doesn't ship this sample as a general-purpose builder. Ordinary `task` and `async` code doesn't automatically switch to it, and callers of an already-compiled ordinary task-returning API don't inherently need preview.

Thanks to [@majocha](https://github.com/dotnet/fsharp/pull/20235) for runtime async.

## Native AOT-friendly text and two-dimensional arrays

Small command-line tools and services still need status messages and ordinary data structures when deployed with [Native AOT](../../core/deploying/native-aot/index.md). Familiar F# operations shouldn't unnecessarily pull in reflection-based formatting or allocation paths that native deployment can't support. F# 11 improves those paths without asking applications to replace everyday reporting and grid code.

### Print values and build strings without a redundant format layer

When you already have a string, you don't need a `"%s"` format just to write it. New Core functions `print` and `printn` accept values through F#'s `string` conversion; `printn` appends a newline:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Report":::

Ordinary-string interpolation now supports more direct conversions and `System.String.Concat` lowering. Concatenation here is a compiler implementation improvement, not a new Core `Concat` API. Earlier releases already optimized some string-only cases.

Plain values, and bare supported printf specifiers such as `%d`, can take direct paths. .NET-format holes such as `{total:F2}` use invariant `String.Format` and box the formatted value; `%A` and precision-bearing printf forms can still fall back to printf formatting. Don't infer that all formatting, boxing, or temporary allocations disappear.

To display localized numbers, select the culture explicitly:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Culture":::

Neither the new print functions nor these interpolation improvements universally require the modern Core build. Their value conversions still matter: `printn` isn't `%A` pretty-printing. With `--reflectionfree`, newly compiled records and unions can also receive meaningful generated `ToString` implementations, provided their inner types' conversions are suitable. See [Interpolation and Native AOT](../language-reference/interpolated-strings.md#native-aot-and-string-valued-interpolation).

Thanks to [@bbatsov](https://github.com/dotnet/fsharp/pull/19265) for the print functions and [@charlesroddie](https://github.com/dotnet/fsharp/pull/19971) for the interpolation implementation.

### Keep ordinary zero-based grid operations

A zero-based grid shouldn't require a replacement Array2D module just to avoid a dynamic-code allocation path. Updated Core implementations support familiar initialization and transformation:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Grid":::

`Array2D.create`, `init`, and `rebase` use the zero-based allocation path across Core builds. Bounds-preserving `map`, `mapi`, and `copy` can use a newer .NET allocation API in the `net10.0` build; the .NET Standard builds retain their fallback. Non-zero-based arrays aren't deprecated, but their native allocation restrictions remain.

See [Two-dimensional arrays and Native AOT](../language-reference/arrays.md#two-dimensional-arrays-and-native-aot) for the operation table. Managed execution of this calculation isn't proof that an entire application and its dependencies publish natively.

Thanks to [@T-Gro](https://github.com/dotnet/fsharp/pull/20338) for the Array2D improvements.

## Less retained memory and less repeated work

Large solutions can repeat analysis of the same code. Collection operations can allocate an object on every call. F# 11 reduces both costs; compiler memory savings and application allocation savings are separate results.

### Share referenced libraries across projects

A multi-project solution often references the same large DLLs many times. Its language service can now share eligible imported library graphs instead of retaining a separate copy for each project. Analysis also creates less unused metadata and reuses repeated references.

In [the implementing PR's retained-memory experiment](https://github.com/dotnet/fsharp/pull/20296), the ten-project ReSharper.FSharp solution fell from 1,547.2 MB to 1,002.2 MB with sharing enabled. That is an off/on measurement for that workload, not a general F# 10-to-11 reduction. Solutions dominated by project references rather than shared binary references can see much smaller gains.

Separate improvements reduce **temporary allocations** while reading DLL metadata and specializing inline code. Those savings aren't the same as memory retained while projects remain open, and measurements from different changes shouldn't be added. See [Tooling performance](../tools/tooling-performance.md) for scope and FCS controls.

Thanks to [@auduchinok](https://github.com/dotnet/fsharp/pull/20296) for shared library imports.

### Compile independent work in parallel by default

Projects with independent source-file branches can use available cores without opting into experimental switches. Parallel compilation is enabled by default for checking and supported optimization/code-generation work, while deterministic output and source-file ordering rules remain intact.

Repeated overloaded calls also benefit from cached resolution—for example, thousands of assertions with the same argument types. Pattern-heavy transformation code avoids a pathological expansion of guarded alternatives that could previously cause extreme compile time, memory use, or stack overflow. These are different sources of wasted work, not new overload-selection rules.

See [Parallel compilation](../language-reference/compiler-options.md#parallel-compilation) for comparison controls. The build tasks also support MSBuild's per-task environment and path isolation when concurrent tasks share a process; this is separate from parallel work inside the compiler.

To reduce repeated editor work, Visual Studio reuses diagnostics for unchanged documents, Find All References limits concurrent checks, and FCS avoids duplicate analysis from overlapping requests. These changes target editor responsiveness, not application runtime speed. See [F# tooling performance](../tools/tooling-performance.md).

### Avoid callback and empty-result allocation overhead

A collection predicate often captures a threshold from its caller. Newly inline operations such as `List.exists`, `List.fold`, and `Array.fold` let optimized code avoid some callback objects without rewriting the traversal:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Collection":::

For your own inline helpers, `OptimizeClosureIfNotInlined` prepares a curried callback's calling convention once when the compiler doesn't know its body:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Closure":::

Result collections and callback internals can still allocate. The earlier Boolean output isn't a speed measurement. See [Optimize curried callbacks](../language-reference/functions/inline-functions.md#optimize-curried-callbacks) for the attribute's requirements.

Empty results are another common case of successful work. [FSharpLint's motivating workload](https://github.com/dotnet/fsharp/issues/20382) repeatedly combined rules that found **no warnings**. Core now reuses shared empty arrays in more operations:

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="EmptyResults":::

The change removes redundant empty-array objects, not every allocation in the pipeline. Don't rely on separate empty results having distinct reference identities.

Thanks to @T-Gro for [inline collection callbacks](https://github.com/dotnet/fsharp/pull/20422) and [shared empty arrays](https://github.com/dotnet/fsharp/pull/20388).

## More precise API calls and everyday conveniences

### Require names when generated parameter order can change

A generated method can change parameter order when its SQL or metadata changes. If the arguments share a type, positional calls can keep compiling while silently changing meaning. An API author can now require names as part of the call-site contract:

> [!NOTE]
> Enforcement requires preview and an available `System.Diagnostics.CodeAnalysis.RequireNamedArgumentsAttribute` definition. The [complete sample](../language-reference/parameters-and-arguments.md#require-named-arguments) supplies a compatibility definition for references that lack it.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Named":::

Reverse the declaration to `Execute(denominator: decimal, numerator: decimal)` and the named call still computes `0.75M`. The positional call is rejected. This compact example simulates the [generated-API ordering problem](https://github.com/fsharp/fslang-suggestions/issues/414); existing type providers benefit only if they emit the annotation. Renaming a parameter still changes the source contract.

### Recognize an already-wrapped generic argument

An API can accept either a plain value or a task that will produce one. Callers shouldn't need extra annotations just to prevent an existing task from becoming the plain value inside another wrapper:

> [!NOTE]
> The most-concrete tiebreaker and overload-priority behavior require preview.

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Concrete":::

The new last-resort tiebreaker prefers the generic parameter shape `Task<'T>` over a bare `'T` in this case. It compares ordinary generic shapes and excludes candidates with SRTP constraints; it isn't a universal “most specific wins” replacement for overload resolution.

### Prefer a new overload without removing the old entry point

A library might keep an old diagnostic method for existing binaries while adding an overload that includes the caller's source location. `OverloadResolutionPriorityAttribute` makes that preference explicit for newly compiled callers:

:::code language="fsharp" source="snippets/fsharp-11/preview/Preview.fs" id="Priority":::

The unchanged call chooses the richer overload. Priority applies among applicable members of the same declaring type before normal betterness; it doesn't rank arbitrary extension modules. See [Overload selection](../language-reference/parameters-and-arguments.md#overload-selection) for the rules and compatibility tradeoffs.

### Use .NET's conditional nullability promises

If your file path is non-null, a Path API's nullable result shouldn't force a check that its own contract rules out. F# 11 consumes the existing .NET [`NotNullIfNotNull`](../../csharp/language-reference/attributes/nullable-analysis.md#conditional-postconditions-notnullwhen-maybenullwhen-and-notnullifnotnull) promise: a non-null named input implies a non-null result.

:::code language="fsharp" source="snippets/fsharp-11/Stable.fs" id="Nullability":::

Enable null checking separately with `<Nullable>enable</Nullable>`. Non-null inputs allow these assignments and the instance call without a redundant suppression; nullable inputs still require nullable handling. See [Conditional return contracts](../language-reference/values/null-values.md#conditional-return-contracts).

For a separate problem—unconstrained C# `T?` APIs—see [Generic nullable interop](../language-reference/values/null-values.md#unconstrained-nullable-generic-interop). `Unchecked.withNull` changes the static type without checking the value; it doesn't establish non-nullness.

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
| Libraries with `.fsi` files | Repeat enforced implementation attributes on the corresponding signature declaration. Examples include `RequiresExplicitTypeArguments` on values and `Struct` on types. Missing required attributes now produce FS3888 errors. See the [declaration-specific list](../language-reference/signature-files.md#compiler-semantic-attributes); this isn't a rule to copy every .NET attribute. |
| Extension-backed inline libraries | Review inferred signatures and [producer/consumer requirements](../language-reference/generics/extension-member-constraints.md#compile-libraries-and-consumers). Preview can retain more general constraints. |
| Delegates constructed from instance methods | A direct target on a null object fails at construction rather than invocation: typically `ArgumentException` for non-virtual targets or `NullReferenceException` for virtual targets. Validate the receiver and adjust exception handling. See [delegate compatibility](../language-reference/delegates.md#direct-construction-and-framework-metadata). |
| Localized interpolated output | .NET-format holes use invariant culture. Choose an explicit culture when localized output is intended. |
| Custom builders relying on a final `do!` selecting `ReturnFromFinal` or `YieldFromFinal` | Final `do!` binds and completes with unit: usually `Bind` then `Return(())`, or `Zero()` without `Return`. Supply those operations, or use explicit `return!` or `yield!` for forwarding. See [translation details](../language-reference/computation-expressions.md#tail-operations-in-custom-builders). |
| Computation expressions ending in an unfinished `let!` | Provide the rest of the computation. For example, replace `async { let! value = work }` with `async { let! value = work in return value }` when the value is the intended result. |
| Older language settings | Supported numbered modes start at F# 8; non-strict indentation mode is removed. See [Language version and indentation](../language-reference/compiler-options.md#language-version-and-indentation). |
| Enum bitwise operations | Use [integral-backed enums](../language-reference/enumerations.md#bitwise-operations); invalid backing types are rejected. |
