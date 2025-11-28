---
title: What's new in F# 8 - F# Guide
description: Find information on the new features available in F# 8.
ms.date: 11/17/2023
ms.topic: whats-new
ai-usage: ai-assisted
---
# What's new in F# 8

F# 8 brings in many features to make F# programs simpler, more uniform, and more performant. This article highlights the major changes in F# 8, developed in the [F# open source code repository](https://github.com/dotnet/fsharp).

F# 8 is released as part of .NET 8. You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download/dotnet/8.0).

For the full announcement with in-depth details and community contributions, see [Announcing F# 8](https://devblogs.microsoft.com/dotnet/announcing-fsharp-8).

## F# language changes

### `_.Property` shorthand for simple lambda functions

F# 8 introduces a succinct notation for simple lambda functions that access properties or members. Instead of writing `(fun x -> x.Property)`, you can now write `_.Property`.

**Before F# 8:**

:::code language="fsharp" source="snippets/fsharp-8/PropertyShorthand.fsx" id="Types":::

:::code language="fsharp" source="snippets/fsharp-8/PropertyShorthand.fsx" id="Before":::

**With F# 8:**

:::code language="fsharp" source="snippets/fsharp-8/PropertyShorthand.fsx" id="After":::

This shorthand works for property access, nested property access, method calls, and indexers. You can also define standalone lambda functions:

:::code language="fsharp" source="snippets/fsharp-8/PropertyShorthand.fsx" id="Standalone":::

### Nested record field copy and update

F# 8 extends the copy-and-update syntax for nested records, eliminating the need for multiple nested `with` keywords.

**Before F# 8:**

:::code language="fsharp" source="snippets/fsharp-8/NestedRecordUpdate.fsx" id="Types":::

:::code language="fsharp" source="snippets/fsharp-8/NestedRecordUpdate.fsx" id="Before":::

**With F# 8:**

:::code language="fsharp" source="snippets/fsharp-8/NestedRecordUpdate.fsx" id="After":::

This syntax also works for anonymous records:

:::code language="fsharp" source="snippets/fsharp-8/NestedRecordUpdate.fsx" id="Anonymous":::

### while!

The `while!` (while bang) feature simplifies computation expressions by eliminating boilerplate when looping over a boolean condition that must be evaluated by the computation expression.

**Before F# 8:**

```fsharp
let mutable count = 0
let asyncCondition = async {
    return count < 10
}

let doStuffBeforeThisFeature = 
    async {
       let! firstRead = asyncCondition
       let mutable read = firstRead
       while read do
         count <- count + 2
         let! nextRead = asyncCondition
         read <- nextRead
       return count
    }
```

**With F# 8:**

```fsharp
let doStuffWithWhileBang =
    async {
        while! asyncCondition do
            count <- count + 2
        return count
    }
```

For more details, see [Simplifying F# computations with the new while! keyword](https://devblogs.microsoft.com/dotnet/simplifying-fsharp-computations-with-the-new-while-keyword/).

### Extended string interpolation syntax

F# 8 improves support for interpolated strings, taking inspiration from C# interpolated raw string literals. You can now use multiple `$` signs at the beginning of an interpolated string to define how many braces are needed to enter interpolation mode.

**Before F# 8:**

:::code language="fsharp" source="snippets/fsharp-8/StringInterpolation.fsx" id="Before":::

**With F# 8:**

:::code language="fsharp" source="snippets/fsharp-8/StringInterpolation.fsx" id="After":::

This is especially useful for HTML templating languages:

:::code language="fsharp" source="snippets/fsharp-8/StringInterpolation.fsx" id="Template":::

For more details, see [New syntax for string interpolation in F# 8](https://devblogs.microsoft.com/dotnet/new-syntax-for-string-interpolation-in-fsharp/).

### Use and compose string literals for printf

String literals can now be used and composed for `printf` and related functions. Format specifiers defined as literals can be reused as patterns.

```fsharp
[<Literal>] 
let formatBody = "(%f,%f)"
[<Literal>] 
let formatPrefix = "Person at coordinates"
[<Literal>] 
let fullFormat = formatPrefix + formatBody

let renderedCoordinates = sprintf formatBody 0.25 0.75
let renderedText = sprintf fullFormat 0.25 0.75
```

### Arithmetic operators in literals

Numeric literals can now be expressed using existing operators and other literals. The compiler evaluates the expression at compile time.

:::code language="fsharp" source="snippets/fsharp-8/LiteralArithmetic.fsx" id="Literals":::

Supported operators:

- Numeric types: `+`, `-`, `*`, `/`, `%`, `&&&`, `|||`, `<<<`, `>>>`, `^^^`, `~~~`, `**`
- Booleans: `not`, `&&`, `||`

The feature also works for enum values:

:::code language="fsharp" source="snippets/fsharp-8/LiteralArithmetic.fsx" id="Enums":::

### Type constraint intersection syntax

F# 8 simplifies defining multiple intersected generic constraints using flexible types with the `&` character.

**Before F# 8:**

```fsharp
let beforeThis(arg1 : 't 
    when 't:>IDisposable 
    and 't:>IEx 
    and 't:>seq<int>) =
    arg1.h(arg1)
    arg1.Dispose()
    for x in arg1 do
        printfn "%i" x
```

**With F# 8:**

```fsharp
let withNewFeature (arg1: 't & #IEx & #IDisposable & #seq<int>) =
    arg1.h(arg1)
    arg1.Dispose()
    for x in arg1 do
        printfn "%i" x
```

### Extended fixed bindings

The `fixed` keyword, used for pinning memory in low-level programming, now supports:

- `byref<'t>`
- `inref<'t>`
- `outref<'t>`
- Types with `GetPinnableReference` method returning `byref<'t>` or `inref<'t>`

This is especially relevant for types like `ReadOnlySpan<'T>` and `Span<'T>`.

```fsharp
open System
open FSharp.NativeInterop

#nowarn "9"

let pinIt (span: Span<char>, byRef: byref<int>, inRef: inref<int>) =
    use ptrSpan = fixed span
    use ptrByRef = fixed &byRef
    use ptrInref = fixed &inRef

    NativePtr.copyBlock ptrByRef ptrInref 1
```

### Easier `[<Extension>]` method definition

The `[<Extension>]` attribute no longer needs to be applied to both the type and the member. The compiler automatically adds the type-level attribute.

**Before F# 8:**

```fsharp
open System.Runtime.CompilerServices
[<Extension>]
type Foo =
    [<Extension>]
    static member PlusOne (a:int) : int = a + 1
```

**With F# 8:**

```fsharp
open System.Runtime.CompilerServices
type Foo =
    [<Extension>]
    static member PlusOne (a:int) : int = a + 1
```

## Making F# more uniform

### Static members in interfaces

Interfaces can now declare and implement concrete static members (not to be confused with static abstract members from F# 7).

**With F# 8:**

:::code language="fsharp" source="snippets/fsharp-8/StaticInInterfaces.fsx" id="Interface":::

### Static let in discriminated unions, records, structs, and types without primary constructors

F# 8 enables `static let`, `static let mutable`, `static do`, and `static member val` in:

- Discriminated unions
- Records
- Structs (including `[<Struct>]` unions and records)
- Types without primary constructors

:::code language="fsharp" source="snippets/fsharp-8/StaticLetInDU.fsx" id="StaticLet":::

### `try-with` within `seq{}`, `[]`, and `[||]` collection expressions

Exception handling is now supported within collection builders.

:::code language="fsharp" source="snippets/fsharp-8/TryWithInCollections.fsx" id="TryWith":::

This yields the list `[1;1000;1;10;100]`, which sums to 1112.

## New diagnostics

F# 8 adds many new and improved diagnostic messages.

### TailCall attribute

Use the `[<TailCall>]` attribute to explicitly state your intention of defining a tail-recursive function. The compiler warns you if your function makes non-tail-recursive calls.

:::code language="fsharp" source="snippets/fsharp-8/TailCallAttribute.fsx" id="Classic":::

:::code language="fsharp" source="snippets/fsharp-8/TailCallAttribute.fsx" id="Accumulator":::

### Diagnostics on static classes

New warnings detect invalid scenarios on sealed abstract classes (static classes):

- Instance let bindings aren't allowed
- Implementing interfaces isn't allowed
- Explicit field declarations aren't allowed
- Constructor with arguments isn't allowed
- Additional constructor isn't allowed
- Abstract member declarations aren't allowed

### Diagnostics on `[<Obsolete>]` usage

Detection of obsolete members has been improved:

- Enum value usage
- Event usage
- Record copy-and-update syntax when the obsolete field is part of the update

```fsharp
open System
type Color =
    | [<Obsolete("Use B instead")>] Red = 0
    | Green = 1

let c = Color.Red // warning at this line
```

### Optional warning when `obj` is inferred

A new information-level diagnostic (FS3559) warns when type inference infers `obj` instead of a generic type, which might be unintended.

```fsharp
([] = [])  // triggers the warning
```

Enable with `<WarnOn>FS3559</WarnOn>` in your project file.

### Optional warning when copy and update changes all fields

A warning (FS3560) detects when copy-and-update syntax changes all fields of a record. It's more efficient to create a new record directly.

Enable with `<WarnOn>FS3560</WarnOn>` in your project file.

## Quality of life improvements

### Trimmability for compiler-generated code

F# 8 improves support for [.NET trimming](../../core/deploying/trimming/trim-self-contained.md):

- Discriminated unions are now trimmable
- Anonymous records are now trimmable
- Code using `printfn "%A"` for trimmed records is now trimmable

### Parser recovery

Parser recovery has been vastly improved. IDE features like coloring and navigation now continue working even when code has syntactical errors or is incomplete.

For more details, watch [Parser Recovery in F#](https://amplifying-fsharp.github.io/sessions/2023/07/07/).

### Strict indentation rules

F# 8 turns on strict indentation mode by default for projects targeting F# 8 and newer. This mode respects language rules for indentation and reports errors instead of warnings.

Configure using `--strict-indentation[+|-]` or in your project file:

```xml
<OtherFlags>--strict-indentation-</OtherFlags>
```

### Autocomplete improvements

Autocomplete scenarios have been improved:

- Record completions in patterns
- Union fields in patterns
- Return type annotations
- Method completions for overrides
- Constant value completions in pattern matching
- Expressions in enum values
- Names based on labels of union-case fields
- Collections of anonymous records
- Settable properties in attribute completions

### `[<Struct>]` unions can now have > 49 cases

The limitation on struct unions with more than 49 cases has been removed, making them suitable for longer definitions.

## Compiler performance

### Reference assemblies

[Reference assemblies](../../standard/assembly/reference-assemblies.md) are now better utilized for F# projects, improving incremental build times by reducing unnecessary rebuilds when only implementation details change.

### Switches for compiler parallelization

Three experimental features enable parallelization of different compilation stages:

- `--test:GraphBasedChecking` - Enables graph-based type checking for parallel processing
- `--test:ParallelOptimization` - Parallelizes the optimization phase
- `--test:ParallelIlxGen` - Parallelizes IL code generation

Read more in [Graph-based type-checking](https://devblogs.microsoft.com/dotnet/a-new-fsharp-compiler-feature-graphbased-typechecking/).

Enable all features using the `FSHARP_EXPERIMENTAL_FEATURES` environment variable:

```powershell
$env:FSHARP_EXPERIMENTAL_FEATURES = '1'
```

## Enhancements to FSharp.Core

### Inlining improvements

F# 8 adds inlining optimizations to the `Option` and `ValueOption` modules, reducing allocations and improving performance. For example, mapping `None` now takes 0.17ns instead of 2.77ns (16× improvement).

### `Array.Parallel.*` APIs

The `Array.Parallel` module has been expanded with many new functions:

- `exists`, `forAll`, `tryFindIndex`, `tryFind`, `tryPick`
- `reduceBy`, `reduce`
- `minBy`, `min`, `sumBy`, `sum`, `maxBy`, `max`, `averageBy`, `average`
- `zip`, `groupBy`, `filter`
- `sortInPlaceWith`, `sortInPlaceBy`, `sortInPlace`
- `sortWith`, `sortBy`, `sort`, `sortByDescending`, `sortDescending`

These functions are useful for CPU-intensive processing on large arrays and utilize all available logical processors.

### `async` improvements

- `Bind` of `Async<>` within `task{}` now starts on the same thread
- `MailBoxProcessor` has a public `.Dispose()` member
- `MailBoxProcessor` now has `StartImmediate` to start on the calling thread

## See also

- [F# Language Reference](../language-reference/index.md)
- [What's new in F# 9](fsharp-9.md)
- [What's new in F# 7](fsharp-7.md)
