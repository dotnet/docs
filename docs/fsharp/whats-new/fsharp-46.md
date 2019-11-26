---
title: What's new in F# 4.6 - F# Guide
description: Get an overview of the new features available in F# 4.6.
ms.date: 11/27/2019
---
# What's new in F# 4.6

F# 4.6 adds multiple improvements to the F# language.

## Get started

F# 4.6 is available in all .NET Core distributions and Visual Studio tooling. [Get started with F#](../get-started/index.md) to learn more.

## Anonymous records

[Anonymous records](../language-reference/anonymous-records) are a new kind of F# type introduced in F# 4.6. They are simple aggregates of named values that don't need to be declared before use. You can declare them as either structs or reference types. They're reference types by default.

```fsharp
open System

let getCircleStats radius =
    let d = radius * 2.0
    let a = Math.PI * (radius ** 2.0)
    let c = 2.0 * Math.PI * radius

    {| Diameter = d; Area = a; Circumference = c |}

let r = 2.0
let stats = getCircleStats r
printfn "Circle with radius: %f has diameter %f, area %f, and circumference %f"
    r stats.Diameter stats.Area stats.Circumference
```

They can also be declared as structs for when you want to group value types and are operating in performance-sensitive scenarios:

```fsharp
open System

let getCircleStats radius =
    let d = radius * 2.0
    let a = Math.PI * (radius ** 2.0)
    let c = 2.0 * Math.PI * radius

    struct {| Diameter = d; Area = a; Circumference = c |}

let r = 2.0
let stats = getCircleStats r
printfn "Circle with radius: %f has diameter %f, area %f, and circumference %f"
    r stats.Diameter stats.Area stats.Circumference
```

They're quite powerful and can be used in numerous scenarios. Learn more at [Anonymous records](../language-reference/anonymous-records).

## ValueOption functions

The ValueOption type added in F# 4.5 now has "module-bound function parity" with the Option type. The functions are defined as such:

```fsharp
module ValueOption =
    [<CompiledName("IsSome")>]
    val inline isSome: voption:'T voption -> bool

    [<CompiledName("IsNone")>]
    val inline isNone: voption:'T voption -> bool

    [<CompiledName("DefaultValue")>]
    val defaultValue: value:'T -> voption:'T voption -> 'T

    [<CompiledName("DefaultWith")>]
    val defaultWith: defThunk:(unit -> 'T) -> voption:'T voption -> 'T

    [<CompiledName("OrElse")>]
    val orElse: ifNone:'T voption -> voption:'T voption -> 'T voption

    [<CompiledName("OrElseWith")>]
    val orElseWith: ifNoneThunk:(unit -> 'T voption) -> voption:'T voption -> 'T voption

    [<CompiledName("GetValue")>]
    val get: voption:'T voption -> 'T

    [<CompiledName("Count")>]
    val count: voption:'T voption -> int

    [<CompiledName("Fold")>]
    val fold<'T,'State> : folder:('State -> 'T -> 'State) -> state:'State -> voption:'T voption -> 'State

    [<CompiledName("FoldBack")>]
    val foldBack<'T,'State> : folder:('T -> 'State -> 'State) -> voption:'T voption -> state:'State -> 'State

    [<CompiledName("Exists")>]
    val exists: predicate:('T -> bool) -> voption:'T voption -> bool

    [<CompiledName("ForAll")>]
    val forall: predicate:('T -> bool) -> voption:'T voption -> bool

    [<CompiledName("Contains")>]
    val inline contains: value:'T -> voption:'T voption -> bool when 'T : equality

    [<CompiledName("Iterate")>]
    val iter: action:('T -> unit) -> voption:'T voption -> unit

    [<CompiledName("Map")>]
    val map: mapping:('T -> 'U) -> voption:'T voption -> 'U voption

    [<CompiledName("Map2")>]
    val map2: mapping:('T1 -> 'T2 -> 'U) -> voption1: 'T1 voption -> voption2: 'T2 voption -> 'U voption

    [<CompiledName("Map3")>]
    val map3: mapping:('T1 -> 'T2 -> 'T3 -> 'U) -> 'T1 voption -> 'T2 voption -> 'T3 voption -> 'U voption

    [<CompiledName("Bind")>]
    val bind: binder:('T -> 'U voption) -> voption:'T voption -> 'U voption

    [<CompiledName("Flatten")>]
    val flatten: voption:'T voption voption -> 'T voption

    [<CompiledName("Filter")>]
    val filter: predicate:('T -> bool) -> voption:'T voption -> 'T voption

    [<CompiledName("ToArray")>]
    val toArray: voption:'T voption -> 'T[]

    [<CompiledName("ToList")>]
    val toList: voption:'T voption -> 'T list

    [<CompiledName("ToNullable")>]
    val toNullable: voption:'T voption -> Nullable<'T>

    [<CompiledName("OfNullable")>]
    val ofNullable: value:Nullable<'T> -> 'T voption

    [<CompiledName("OfObj")>]
    val ofObj: value: 'T -> 'T voption  when 'T : null

    [<CompiledName("ToObj")>]
    val toObj: value: 'T voption -> 'T when 'T : null
```

This allows for ValueOption to be used just like Option in scenarios where having a value type improves performance.
