---
title: What's new in F# 10 - F# Guide
description: Get an overview of the new features available in F# 10.
ms.date: 11/11/2025
ms.topic: whats-new
ai-usage: ai-assisted
---
# What's new in F# 10

F# 10 brings you several improvements to the F# language, FSharp.Core library, and tooling.
This version is a refinement release focused on clarity, consistency, and performance, with small but meaningful improvements that make your everyday code more legible and robust.
F# 10 ships with **.NET 10** and **Visual Studio 2026**.

You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download).

## Get started

F# 10 is available in all .NET Core distributions and Visual Studio tooling.
For more information, see [Get started with F#](../get-started/index.md).

## Scoped warning suppression

You can now suppress warnings in specific sections of your code using the new `#warnon` directive.
This pairs with the [existing `#nowarn` directive](../language-reference/compiler-directives.md#warn-directives) to give you precise control over which warnings apply where.

Previously, when you used `#nowarn`, it would disable a warning for the remainder of the file, which could suppress legitimate issues elsewhere.
Let's look at a motivating example:

```fsharp
// We know f is never called with None.
let f (Some a) =    // creates warning 25, which we want to suppress
    // 2000 loc, where the incomplete match warning is beneficial
```

If you add `#nowarn 25` above the function definition, it disables FS0025 for the entire remainder of the file.

With F# 10, you can now mark the exact section where you want the warning suppressed:

```fsharp
#nowarn 25
let f (Some x) =    // FS0025 suppressed
#warnon 25
    // FS0025 enabled again
```

Conversely, if a warning is disabled globally (for example, via a compiler flag), you can enable it locally with `#warnon`.
This directive will apply until a matching `#nowarn` or the end of the file.

**Important compatibility notes:**

This feature includes several changes that improve the consistency of `#nowarn`/`#warnon` directives.
These are breaking changes:

* The compiler no longer allows multiline and empty warn directives.
* The compiler no longer allows whitespace between `#` and `nowarn`.
* You cannot use triple-quoted, interpolated, or verbatim strings for warning numbers.

Script behavior has also changed.
Previously, when you added a `#nowarn` directive anywhere in a script, it applied to the whole compilation.
Now, its behavior in scripts matches that in `.fs` files, applying only until the end of the file or a corresponding `#warnon`.

This feature implements [RFC FS-1146](https://github.com/fsharp/fslang-design/blob/main/RFCs/FS-1146-scoped-nowarn.md).

## Access modifiers on auto property accessors

A common pattern in object-oriented programming is to create publicly readable but privately mutable state.
Before F# 10, you needed explicit [property syntax](../language-reference/members/properties.md) with backing fields (hidden variables that store the actual property values) to achieve this, which added repetitive code:

```fsharp
type Ledger() =
    [<DefaultValue>] val mutable private _Balance: decimal
    member this.Balance with public get() = this._Balance and private set v = this._Balance <- v
```

With F# 10, you can now apply different access modifiers to individual property accessors.
This lets you specify different access levels for the getter and setter of a property, making the pattern much simpler:

```fsharp
type Ledger() =
    member val Balance = 0m with public get, private set
```

You can place an access modifier either before the property name (applying to both accessors) or before individual accessors, but not both simultaneously.

Note that this feature does not extend to signature (`.fsi`) files.
The correct signature for the `Ledger` example above is:

```fsharp
type Ledger() =
    member Balance : decimal
    member private Balance : decimal with set
```

This feature implements [RFC FS-1141](https://github.com/fsharp/fslang-design/blob/main/RFCs/FS-1141-Allow-access-modifiers-to-auto-properties-getters-and-setters.md).

## ValueOption optional parameters

You can now use a struct-based [`ValueOption<'T>`](../language-reference/value-options.md) representation for [optional parameters](../language-reference/parameters-and-arguments.md#optional-parameters-f-native).
When you apply the `[<Struct>]` attribute to an optional parameter, the compiler uses `ValueOption<'T>` instead of the reference-based `option` type.
This avoids heap allocations (memory allocated on the managed heap that requires garbage collection) for the option wrapper, which is beneficial in performance-critical code.

Previously, F# always used the heap-allocated `option` type for optional parameters, even when the parameter was absent:

```fsharp
// Prior to F# 10: always uses reference option
type X() =
    static member M(?x : string) =
        match x with
        | Some v -> printfn "Some %s" v
        | None -> printfn "None"
```

In F# 10, you can use the `[<Struct>]` attribute to leverage the struct-backed `ValueOption`:

```fsharp
type X() =
    static member M([<Struct>] ?x : string) =
        match x with
        | ValueSome v -> printfn "ValueSome %s" v
        | ValueNone -> printfn "ValueNone"
```

This eliminates heap allocations when the argument is absent, which is beneficial in performance-critical code.

Choose this struct-based option for small values or frequently constructed types where allocation pressure matters.
Use the default reference-based `option` when you rely on existing pattern matching helpers, need reference semantics, or when the performance difference is negligible.
This feature strengthens parity with other F# language constructs that already support `ValueOption`.

## Tail-call support in computation expressions

F# 10 adds [tail-call](../language-reference/functions/recursive-functions-the-rec-keyword.md#tail-recursion) optimizations for [computation expressions](../language-reference/computation-expressions.md).
Computation-expression builders can now opt into these optimizations by implementing special methods.

When the compiler translates computation expressions into regular F# code (a process called desugaring), it recognizes when an expression like `return!`, `yield!`, or `do!` appears in a tail position.
If your builder provides the following methods, the compiler routes those calls to optimized entry points:

* `ReturnFromFinal` - called for a tail `return!` (falls back to `ReturnFrom` if absent)
* `YieldFromFinal` - called for a tail `yield!` (falls back to `YieldFrom` if absent)
* For a terminal `do!`, the compiler prefers `ReturnFromFinal`, then `YieldFromFinal`, before falling back to the normal `Bind` pathway

These `*Final` members are optional and exist purely to enable optimization.
Builders that do not provide these members keep their existing semantics unchanged.

For example:

```fsharp
coroutine {
    yield! subRoutine() // tail position -> YieldFromFinal if available
}
```

However, in a non-tail position:

```fsharp
coroutine {
    try
        yield! subRoutine() // not tail -> normal YieldFrom
    finally ()
}
```

**Important compatibility note:**

This change can be breaking if a computation expression builder already defines members with these names.
In most cases, existing builders continue to work without modification when compiled with F# 10.
Older compilers will ignore the new `*Final` methods, so builders that must remain compatible with earlier compiler versions should not assume the compiler will invoke these methods.

This feature implements [RFC FS-1330](https://github.com/fsharp/fslang-design/blob/main/RFCs/FS-1330-support-tailcalls-in-computation-expressions.md).

## Typed bindings in computation expressions without parentheses

F# 10 removes the requirement for parentheses when adding type annotations to computation expression bindings.
You can now add type annotations on `let!`, `use!`, and `and!` bindings using the same syntax as ordinary `let` bindings.

Previously, you had to use parentheses for type annotations:

```fsharp
async {
    let! (a: int) = fetchA()
    and! (b: int) = fetchB()
    use! (d: MyDisposable) = acquireAsync()
    return a + b
}
```

In F# 10, you can write type annotations without parentheses:

```fsharp
async {
    let! a: int = fetchA()
    and! b: int = fetchB()
    use! d: MyDisposable = acquireAsync()
    return a + b
}
```

## Allow `_` in `use!` bindings

You can now use the discard pattern (`_`) in `use!` bindings within computation expressions.
This aligns the behavior of `use!` with regular `use` bindings.

Previously, the compiler rejected the discard pattern in `use!` bindings, forcing you to create throwaway identifiers:

```fsharp
counterDisposable {
    use! _ignored = new Disposable()
    // logic
}
```

In F# 10, you can use the discard pattern directly:

```fsharp
counterDisposable {
    use! _ = new Disposable()
    // logic
}
```

This clarifies intent when binding asynchronous resources whose values are only needed for lifetime management.

## Rejecting pseudo-nested modules in types

The compiler now raises an error when you place a `module` declaration indented at the same structural level inside a type definition.
This tightens structural validation to reject misleading module placement within types.

Previously, the compiler accepted `module` declarations indented within type definitions, but it actually created these modules as siblings to the type rather than nesting them within it:

```fsharp
type U =
    | A
    | B
    module M = // Silently created a sibling module, not nested
        let f () = ()
```

With F# 10, this pattern raises error FS0058, forcing you to clarify your intent with proper module placement:

```fsharp
type U =
    | A
    | B

module M =
    let f () = ()
```

## Deprecation warning for omitted `seq`

The compiler now warns you about bare sequence expressions that omit the `seq` builder.
When you use bare range braces like `{ 1..10 }`, you'll see a deprecation warning encouraging you to use the explicit `seq { ... }` form.

Historically, F# allowed a special-case "sequence comprehension lite" syntax where you could omit the `seq` keyword:

```fsharp
{ 1..10 } |> List.ofSeq  // implicit sequence, warning FS3873 in F# 10
```

In F# 10, the compiler warns about this pattern and encourages the explicit form:

```fsharp
seq { 1..10 } |> List.ofSeq
```

This is currently a warning, not an error, giving you time to update your codebase.
If you want to suppress this warning, use the `NoWarn` property in your project file or `#nowarn` directive locally and pass it the warning number: 3873.

The explicit `seq` form improves code clarity and consistency with other computation expressions.
Future versions of F# may make this an error, so we recommend adopting the explicit syntax when you update your code.

This feature implements [RFC FS-1033](https://github.com/fsharp/fslang-design/blob/main/RFCs/FS-1033-Deprecate-places-where-seq-can-be-omitted.md).

## Attribute target enforcement

F# 10 enforces attribute target validation across all language constructs.
The compiler now validates that attributes are only applied to their intended targets by checking `AttributeTargets` across let-bound values, functions, union cases, implicit constructors, structs, and classes.

Previously, the compiler silently allowed you to misapply attributes to incompatible targets.
This caused subtle bugs, such as test attributes being ignored when you forgot `()` to make a function:

```fsharp
[<Fact>]
let ``this is not a function`` = // Silently ignored in F# 9, not a test!
    Assert.True(false)
```

In F# 10, the compiler enforces attribute targets and raises a warning when attributes are misapplied:

```fsharp
[<Fact>]
//^^^^ - warning FS0842: This attribute cannot be applied to property, field, return value. Valid targets are: method
let ``this is not a function`` =
    Assert.True(false)
```

**Important compatibility note:**

This is a breaking change that may reveal previously silent issues in your codebase.
The early errors prevent test discovery problems and ensure that attributes like analyzers and decorators take effect as intended.

## Support for `and!` in task expressions

You can now await multiple tasks concurrently using [`and!`](../language-reference/computation-expressions.md#and) in [task expressions](../language-reference/task-expressions.md).
Using `task` is a popular way to work with asynchronous workflows in F#, especially when you need interoperability with C#.
However, until now, there was no concise way to await multiple tasks concurrently in a computation expression.

Perhaps you started with code that awaited computations sequentially:

```fsharp
// Awaiting sequentially
task {
    let! a = fetchA()
    let! b = fetchB()
    return combineAB a b
}
```

If you then wanted to change it to await them concurrently, you would typically use `Task.WhenAll`:

```fsharp
// Use explicit Task combinator to await concurrently
task {
    let ta = fetchA()
    let tb = fetchB()
    let! results = Task.WhenAll([| ta; tb |])
    return combineAB ta.Result tb.Result
}
```

In F# 10, you can use `and!` for a more idiomatic approach:

```fsharp
task {
    let! a = fetchA()
    and! b = fetchB()
    return combineAB a b
}
```

This combines the semantics of the concurrent version with the simplicity of the sequential version.

This feature implements F# language suggestion [#1363](https://github.com/fsharp/fslang-suggestions/issues/1363), and it's implemented as an addition to the `FSharp.Core` library.
Most projects get the latest version of `FSharp.Core` automatically from the compiler, unless they explicitly pin a version.
In that case, you'll need to update it to use this feature.

## Better trimming by default

F# 10 removes a long-standing bit of friction with trimming F# assemblies.
Trimming is the process of removing unused code from your published application to reduce its size.
You no longer have to manually maintain an `ILLink.Substitutions.xml` file just to strip large F# metadata resource blobs (signature and optimization data that the compiler uses but your application doesn't need at runtime).

When you publish with trimming enabled (`PublishTrimmed=true`), the F# build now automatically generates an embedded substitutions file that targets these tooling-only F# resources.

Previously, you had to manually maintain this file to strip the metadata.
This added maintenance burden and was easy to forget.

The result is smaller output by default, less repetitive code to maintain, and one fewer maintenance hazard.
If you need full manual control, you can still add your own substitutions file.
You can turn off the auto-generation with the `<DisableILLinkSubstitutions>false</DisableILLinkSubstitutions>` property.

## Parallel compilation in preview

An exciting update for F# users looking to reduce compilation times: the parallel compilation features are stabilizing.
Starting with .NET 10, three features: graph-based type checking, parallel IL code generation, and parallel optimization, are grouped together under the `ParallelCompilation` project property.

F# 10 enables this setting by default for projects using `LangVersion=Preview`.
We plan to enable it for all projects in .NET 11.

Be sure to give it a try and see if it speeds up your compilation.
To enable parallel compilation in F# 10:

```xml
<PropertyGroup>
    <ParallelCompilation>true</ParallelCompilation>
    <Deterministic>false</Deterministic> <!-- Note: deterministic builds don't get the benefits of parallel compilation -->
</PropertyGroup>
```

If you want to opt out while still enjoying other preview features, set `ParallelCompilation` to false:

```xml
<PropertyGroup>
    <LangVersion>Preview</LangVersion>
    <ParallelCompilation>false</ParallelCompilation>
</PropertyGroup>
```

Parallel compilation can significantly reduce compilation times for projects with multiple files and dependencies.

## Type subsumption cache

The compiler now caches type relationship checks to speed up type inference and improve IDE performance, particularly when working with complex type hierarchies.
By storing and reusing results from previous subsumption checks, the compiler avoids redundant computations that previously slowed down compilation and IntelliSense.

**Managing the cache:**

In most cases, the type subsumption cache improves performance without any configuration.
However, if you experience increased memory footprint or increased CPU usage (due to cache maintenance workers), you can adjust the cache behavior:

* To disable the cache entirely, set `<LangVersion>9</LangVersion>` in your project file to fall back to F# 9 behavior.
* To turn off asynchronous cache eviction (which increases thread pressure) and use synchronous eviction instead, set the `FSharp_CacheEvictionImmediate=1` environment variable.
