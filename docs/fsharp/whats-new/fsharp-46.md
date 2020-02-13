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

[Anonymous records](../language-reference/anonymous-records.md) are a new kind of F# type introduced in F# 4.6. They are simple aggregates of named values that don't need to be declared before use. You can declare them as either structs or reference types. They're reference types by default.

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

They're quite powerful and can be used in numerous scenarios. Learn more at [Anonymous records](../language-reference/anonymous-records.md).

## ValueOption functions

The ValueOption type added in F# 4.5 now has "module-bound function parity" with the Option type. Some of the more commonly-used examples are as follows:

```fsharp
// Multiply a value option by 2 if it has  value
let xOpt = ValueSome 99
let result = xOpt |> ValueOption.map (fun v -> v * 2)

// Reverse a string if it exists
let strOpt = ValueSome "Mirror image"
let reverse (str: string) =
    match str with
    | null
    | "" -> None
    | s ->
        str.ToCharArray()
        |> Array.rev
        |> string
        |> Some

let reversedString = strOpt |> Option.bind reverse
```

This allows for ValueOption to be used just like Option in scenarios where having a value type improves performance.
