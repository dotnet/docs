---
title: Nullable value types
description: Learn how to use nullable value types, a way to represent value types that can also be null, in F#.
ms.date: 11/19/2020
---

# Nullable value types

A _nullable value type_ `Nullable<'T>` represents any [struct](structs.md) type that could also be `null`. This is helpful when interacting with libraries and components that may choose to represent these kinds of types, like integers, with a `null` value for efficiency reasons. The underlying type that backs this construct is <xref:System.Nullable%601?displayProperty=nameWithType>.

## Syntax

```fsharp
Nullable<'T>
Nullable value
```

## Declare and assign with values

Declaring a nullable value type is just like declaring any wrapper-like type in F#:

```fsharp
open System

let x = 12
let nullableX = Nullable<int> x
```

You can also elide the generic type parameter and allow type inference to resolve it:

```fsharp
open System

let x = 12
let nullableX = Nullable x
```

To assign to a nullable value type, you'll need to also be explicit. There is no implicit conversion for F#-defined nullable value types:

```fsharp
open System

let mutable x = Nullable 12
x <- Nullable 13
```

## Assign null

You cannot directly assign `null` to a nullable value type. Use `Nullable()` instead:

```fsharp
let mutable a = Nullable 42
a <- Nullable()
```

This is because `Nullable<'T>` does not have `null` as a proper value.

## Pass and assign to members

A key difference between working with members and F# values is that nullable value types can be implicitly inferred when you're working with members. Consider the following method that takes a nullable value type as input:

```fsharp
type C() =
    member _.M(x: Nullable<int>) = x.HasValue
    member val NVT = Nullable 12 with get, set

let c = C()
c.M(12)
c.NVT <- 12
```

In the previous example, you can pass `12` to the method `M`. You can also assign `12` to the auto property `NVT`. If the input can be constructed as a nullable value type and it matches the target type, the F# compiler will implicitly convert such calls or assignments.

## Examine a nullable value type instance

Unlike [Options](options.md), which are a generalized construct for representing a possible value, nullable value types are not used with pattern matching. Instead, you need to use an [`if`](conditional-expressions-if-then-else.md) expression and check the `HasValue` property.

To get the underlying value, use the `Value` property after a `HasValue` check, like so:

```fsharp
open System

let a = Nullable 42

if a.HasValue then
    printfn $"{a} is {a.Value}"
else
    printfn $"{a} has no value."
```

## Nullable operators

Operations on nullable value types, such as arithmetic or comparison, can require the use of [nullable operators](symbol-and-operator-reference/nullable-operators.md).

You can convert from one nullable value type to another using conversion operators from the `FSharp.Linq` namespace:

```fsharp
open System
open FSharp.Linq

let nullableInt = Nullable 10
let nullableFloat = Nullable.float nullableInt
```

You can also use an appropriate non-nullable operator to convert to a primitive type, risking an exception if it has no value:

```fsharp
open System
open FSharp.Linq

let nullableInt = Nullable 10
let nullableFloat = Nullable.float nullableInt

printfn $"value is %f{float nullableFloat}"
```

You can also use nullable operators as a short-hand for checking `HasValue` and `Value`:

```fsharp
open System
open FSharp.Linq

let nullableInt = Nullable 10
let nullableFloat = Nullable.float nullableInt

let isBigger = nullableFloat ?> 1.0
let isBiggerLongForm = nullableFloat.HasValue && nullableFloat.Value > 1.0
```

The `?>` comparison checks if the left-hand side is nullable and only succeeds if it has a value. It is equivalent to the line that follows it.

## See also

- [Structs](structs.md)
- [F# Options](options.md)
