---
title: Value Options (F#)
description: Learn about the F# Value Option type, which is a struct version of the Option type.
ms.date: 06/16/2018
---

# Value Options

The Value Option type in F# is used when the following two circumstances hold:

1. A scenario is appropriate for an [F# Option](options.md).
2. Using a struct provides a performance benefit in your scenario.

Not all performance-sensitive scenarios are "solved" by using structs. You must consider the additional cost of copying when using them instead of reference types. However, large F# programs commonly instantiate many optional types that flow through hot paths, because structs can sometimes yield better overall performance over the lifetime of a program.

## Definition

Value Option is defined as a [struct discriminated union](discriminated-unions.md#struct-discriminated-unions) that is similar to the reference option type:

```fsharp
[<StructuralEquality; StructuralComparison>]
[<CompiledName("FSharpValueOption`1")>]
[<Struct>]
type ValueOption<'T> =
    | ValueNone: 'T voption
    | ValueSome: 'T -> 'T voption

    member Value : 'T

and 'T voption = ValueOption<'T>
```

Value Option conforms to structural equality and comparison. The main difference is that the compiled name, type name, and case names all indicate that it is a value type.

## Using Value Options

Value Options are used just like [Options](options.md). `ValueSome` is used to indicate that a value is present, and `ValueNone` is used when a value is not present:

```fsharp
let tryParseDateTime (s: string) =
    match System.DateTime.TryParse(s) with
    | (true, dt) -> ValueSome dt
    | (false, _) -> ValueNone

let possibleDateString1 = "1990-12-25"
let possibleDateString2 = "This is not a date"

let result1 = tryParseDateTime possibleDateString1
let result2 = tryParseDateTime possibleDateString2

match (result1, result2) with
| ValueSome d1, ValueSome d2 -> printfn "Both are dates!"
| ValueSome d1, ValueNone -> printfn "Only the first is a date!"
| ValueNone, ValueSome d2 -> printfn "Only the second is a date!"
| ValueNone, ValueNone -> printfn "None of them are dates!"
```

As with [Options](options.md), the naming convention for a function that returns `ValueOption` is to prefix it with `try`.

## Value Option properties and methods

There is one property for Value Options at this time: `Value`. An <xref:System.InvalidOperationException> is raised if no value is present when this property is invoked.

## Value Option functions

There is currently one module-bound function for Value Options, `defaultValueArg`:

```fsharp
val defaultValueArg : arg:'T voption -> defaultValue:'T -> 'T 
```

As with the `defaultArg` function, `defaultValueArg` returns the underlying value of the given Value Option if it exists; otherwise, it returns the specified default value.

At this time, there are no other module-bound functions for Value Options.

## See also

- [Options](options.md)