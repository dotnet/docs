---
title: Byrefs (F#)
description: Learn about byref and byref-like types in F#, which are used for low-level programming.
ms.date: 09/02/2018
---

# Byrefs

F# has two major feature areas that deal in the space of low-level programming:

* The `byref`/`inref`/`outref` types, which are a managed pointers. They have restrictions on usage so that you cannot compile a program that is invalid at runtime.
* A `byref`-like struct, which is a [structure](structures.md) that has similar semantics and the same compile-time restrictions as `byref<'T>`. One example is <xref:System.Span%601>.

## Syntax

```fsharp
// Byref types as parameters
let f (x: byref<'T>) = ()
let g (x: inref<'T>) = ()
let h (x: outref<'T>) = ()

// Calling a function with a byref parameter
let mutable x = 3
f &x

// Declaring a byref-like struct
open System.Runtime.CompilerServices

[<Struct; IsByRefLike>]
type S(count1: int, count2: int) =
    member x.Count1 = count1
    member x.Count2 = count2
```

## Byref, inref, and outref

There are three forms of `byref`:

* `inref<'T>`, a managed pointer for reading the underlying value.
* `outref<'T>`, a managed pointer for writing to the underlying value.
* `byref<'T>`, a managed pointer for reading and writing the underlying value.

A `byref<'T>` can be passed where an `inref<'T>` is expected. Similarly, a `byref<'T>` can be passed where an `outref<'T>` is expected.

## Using byrefs

To use a `inref<'T>`, you need to get a pointer value with `&`:

```fsharp
open System

let f (dt: inref<DateTime>) =
    printfn "Now: %s" (dt.ToString())

let dt = DateTime.Now
f &dt // Pass a pointer to 'dt'
```

To write to the pointer by using an `outref<'T>` or `byref<'T>`, you must also make the value you grab a pointer to `mutable`.

```fsharp
open System

let f (dt: byref<DateTime>) =
    printfn "Now: %s" (dt.ToString())
    dt <- DateTime.Now

// Make 'dt' mutable
let mutable dt = DateTime.Now

// Now you can pass the pointer to 'dt'
f &dt
```

If you are only writing the pointer instead of reading it, consider using `outref<'T>` instead of `byref<'T>`.

### Inref semantics

Consider the following code:

```fsharp
let f (x: inref<SomeStruct>) = s.SomeField
```

Semantically, this means the following:

* The holder of the `x` pointer may only use it to read the value.
* Any pointer acquired to `struct` fields nested within `SomeStruct` are given type `inref<_>`.

The following is also true:

* There is no implication that other threads or aliases do not have write access to `x`.
* There is no implication that `SomeStruct` is immutable by virtue of `x` being an `inref`.

However, for F# value types that **are** immutable, the `this` pointer is inferred to be an `inref`.

All of these rules together mean that the holder of an `inref` pointer may not modify the immediate contents of the memory being pointed to.

### Outref semantics

The purpose of `outref<'T>` is to indicate that the pointer should only be read from. Unexpectedly, `outref<'T>` permits reading the underlying value despite its name. This is for compatibility purposes. Semantically, `outref<'T>` is no different than `byref<'T>`.

### Interop with C #

C# supports the `in ref` and `out ref` keywords, in addition to `ref` returns. The following table shows how F# interprets what C# emits:

|C# construct|F# infers|
|------------|---------|
|`ref` return value|`outref<'T>`|
|`ref readonly` return value|`inref<'T>`|
|`in ref` parameter|`inref<'T>`|
|`out ref` parameter|`outref<'T>`|

The following table shows what F# emits:

|F# construct|Emitted construct|
|------------|-----------------|
|`inref<'T>` argument|`[In]` attribute on argument|
|`inref<'T>` return|`modreq` attribute on value|
|`inref<'T>` in abstract slot or implementation|`modreq` on argument or return|
|`outref<'T>` argument|`[Out]` attribute on argument|

### Type inference and overloading rules

An `inref<'T>` type is inferred by the F# compiler in the following cases:

1. A .NET parameter or return type that has an `IsReadOnly` attribute.
2. The `this` pointer on a struct type that has no mutable fields.
3. The address of a memory location derived from another `inref<_>` pointer.

When an implicit address of an `inref` is being taken, an overload with an argument of type `SomeType` is preferred to an overload with an argument of type `inref<SomeType>`. For example:

```fsharp
type C() =
    static member M(x: System.DateTime) = x.AddDays(1.0)
    static member M(x: inref<System.DateTime>) = x.AddDays(2.0)
    static member M2(x: System.DateTime, y: int) = x.AddDays(1.0)
    static member M2(x: inref<System.DateTime>, y: int) = x.AddDays(2.0)

let res = System.DateTime.Now
let v =  C.M(res)
let v2 =  C.M2(res, 4)
```

In both cases, the overloads taking `System.DateTime` are resolved rather than the overloads taking `inref<System.DateTime>`.

## Byref-like structs

In addition to the `byref`/`inref`/`outref` trio, you can define your own structs that can adhere to `byref`-like semantics. This is done with the <xref:System.Runtime.CompilerServices.IsByRefLikeAttribute> attribute:

```fsharp
open System
open System.Runtime.CompilerServices

[<IsByRefLike; Struct>]
type S(count1: Span<int>, count2: Span<int>) =
    member x.Count1 = count1
    member x.Count2 = count2
```

`IsByRefLike` does not imply `Struct`. Both must be present on the type.

A "`byref`-like" struct in F# is a stack-bound value type. It is never allocated on the managed heap. A `byref`-like struct is useful for high-performance programming, as it is enforced with set of strong checks about lifetime and non-capture. The rules are:

* They can be used as function parameters, method parameters, local variables, method returns.
* They cannot be static or instance members of a class or normal struct.
* They cannot be captured by any closure construct (`async` methods or lambda expressions).
* They cannot be used as a generic parameter.

This last point is crucial for F# pipeline-style programming, as `|>` is a generic function that parameterizes its input types. This restriction may be relaxed for `|>` in the future, as it is inline and does not make any calls to non-inlined generic functions in its body.

Although these rules very strongly restrict usage, they do so to fulfill the promise of high-performance computing in a safe manner.

## Byref returns

Byref returns from F# functions or members can be produced and consumed. When consuming a `byref`-returning method, the value is implicitly dereferenced. For example:

```fsharp
let safeSum(bytes: Span<byte>) =
    let mutable sum = 0
    for i in 0 .. bytes.Length - 1 do
        sum <- sum + int bytes.[i]
    sum

let sum = safeSum(mySpanOfBytes)
printfn "%d" sum // 'sum' is of type 'int'
```

To avoid the implicit dereference, such as passing a reference through multiple chained calls, use `&x` (where `x` is the value).

You can also directly assign to a return `byref`. Consider the following (highly imperative) program:

```fsharp
ype C() =
    let mutable nums = [| 1; 3; 7; 15; 31; 63; 127; 255; 511; 1023 |]

    override __.ToString() = String.Join(' ', nums)

    member __.FindLargestSmallerThan(target: int) =
        let mutable ctr = nums.Length - 1

        while ctr > 0 && nums.[ctr] >= target do ctr <- ctr - 1

        if ctr > 0 then &nums.[ctr] else &nums.[0]

[<EntryPoint>]
let main argv =
    let c = C()
    printfn "Original sequence: %s" (c.ToString())

    let v = &c.FindLargestSmallerThan 16

    v <- v*2 // Directly assign to the byref return

    printfn "New sequence:      %s" (c.ToString())

    0 // return an integer exit code
```

This is the output:

```console
Original sequence: 1 3 7 15 31 63 127 255 511 1023
New sequence:      1 3 7 30 31 63 127 255 511 1023
```

## Scoping for byrefs

A `let`-bound value cannot have its reference exceed the scope in which it was defined. For example, the following is disallowed:

```fsharp
let test2 () =
    let x = 12
    &x // Error: 'x' exceeds its defined scope!

let test () =
    let x =
        let y = 1
        &y // Error: `y` exceeds its defined scope!
    ()
```

This prevents you from getting different results depending on if you compile with optimizations on or off.