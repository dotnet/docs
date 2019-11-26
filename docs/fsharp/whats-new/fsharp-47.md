---
title: What's new in F# 4.7 - F# Guide
description: Get an overview of the new features available in F# 4.7.
ms.date: 11/27/2019
---
# What's new in F# 4.7

F# 4.7 adds multiple improvements to the F# language.

## Get started

F# 4.7 is available in all .NET Core distributions and Visual Studio tooling. [Get started with F#](../get-started/index.md) to learn more.

## Language version

The F# 4.7 compiler introduces the ability to set your effective language version via a property in your project file:

```xml
<PropertyGroup>
    <LangVersion>preview</LangVersion>
</PropertyGroup>
```

You can set it to the values `4.6`, `4.7`, `latest`, and `preview`. The default is `latest`.

If you set it to `preview`, your compiler will activate all F# preview features that are implemented in your compiler.

## Implicit yields

You no longer need to apply the `yield` keyword in arrays, lists, sequences, or computation expressions where the type can be inferred. In the following example, both expressions required the `yield` statement for each entry prior to F# 4.7:

```fsharp
let s = seq { 1; 2; 3; 4; 5 }

let daysOfWeek includeWeekend =
    [ 
        "Monday"
        "Tuesday"
        "Wednesday"
        "Thursday"
        "Friday"
        if includeWeekend then 
            "Saturday"
            "Sunday"
    ] 
```

If you introduce a single `yield` keyword, every other item must also have `yield` applied to it.

Implicit yields are not activated when used in an expression that also uses `yield!` to do something like flatten a sequence. You must continue to use `yield` today in these cases.

## Wildcard identifiers

In F# code involving classes, the self-identifier needs to always be explicit in member declarations. But in cases where the self-identifier is never used, it has traditionally been convention to use a double-underscore to indicate a nameless self-identifiers. You can now use a single underscore:

```fsharp
type C() =
    member _.M() = ()
```

This also applies for `for` loops:

```fsharp
for _ in 1..10 do printfn "Hello!"
```

## Indentation relaxations

Prior to F# 4.7, the indentation requirements for primary constructor and static member arguments required excessive indentation. They now only require a single indentation scope:

```fsharp
type OffsideCheck(a:int,
    b:int, c:int,
    d:int) = class end

type C() =
    static member M(a:int,
        b:int, c:int,
        d:int) = 1
```
