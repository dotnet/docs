---
title: What's new in F# 4.5 - F# Guide
description: Get an overview of the new features available in F# 4.5.
ms.date: 11/27/2019
---
# What's new in F# 4.5

F# 4.5 adds multiple improvements to the F# language. Many of these features were added together to enable you to write efficient code in F# while also ensuring this code is safe. Doing so means adding a few concepts to the language and a significant amount of compiler analysis when using these constructs.

## Get started

F# 4.5 is available in all .NET Core distributions and Visual Studio tooling. [Get started with F#](../get-started/index.md) to learn more.

## Span and byref-like structs

The <xref:System.Span%601> type introduced in .NET Core allows you to represent buffers in memory in a strongly-typed manner, which is now allowed in F# starting with F# 4.5. The following example shows how you can re-use a function operating on a <xref:System.Span%601> with different buffer representations:

```fsharp
let safeSum (bytes: Span<byte>) =
    let mutable sum = 0
    for i in 0 .. bytes.Length - 1 do 
        sum <- sum + int bytes.[i]
    sum

// managed memory
let arrayMemory = Array.zeroCreate<byte>(100)
let arraySpan = new Span<byte>(arrayMemory)

safeSum(arraySpan) |> printfn "res = %d"

// native memory
let nativeMemory = Marshal.AllocHGlobal(100);
let nativeSpan = new Span<byte>(nativeMemory.ToPointer(), 100)

safeSum(nativeSpan) |> printfn "res = %d"
Marshal.FreeHGlobal(nativeMemory)

// stack memory
let mem = NativePtr.stackalloc<byte>(100)
let mem2 = mem |> NativePtr.toVoidPtr
let stackSpan = Span<byte>(mem2, 100)

safeSum(stackSpan) |> printfn "res = %d"
```

An important aspect to this is that Span and other [byref-like structs](../language-reference/structures.md#byreflike-structs) have very rigid static analysis performed by the compiler that restrict their usage in ways you might find to be unexpected. This is the fundamental tradeoff between performance, expressiveness, and safety that is introduced in F# 4.5.

## Revamped byrefs

Prior to F# 4.5, [Byrefs](../language-reference/byrefs.md) in F# were unsafe and unsound for numerous applications. Soundness issues around byrefs have been addressed in F# 4.5 and the same static analysis done for span and byref-like structs was also applied.

### inref<'T> and outref<'T>

To represent the notion of a read-only, write-only, and read/write managed pointer, F# 4.5 introduces the `inref<'T>`, `outref<'T>` types to represent read-only and write-only pointers, respectively. Each have different semantics. For example, you cannot write to an `inref<'T>`:

```fsharp
let f (dt: inref<DateTime>) =
    dt <- DateTime.Now // ERROR - cannot write to an inref!
```

By default, type inference will infer managed pointers as `inref<'T>` to be in line with the immutable nature of F# code, unless something has already been declared as mutable. To make something writable, you'll need to declare a type as `mutable` before passing its address to a function or member that manipulates it. To learn more, see [Byrefs](../language-reference/byrefs.md).

## Readonly structs

Starting with F# 4.5, you can annotate a struct with <xref:System.Runtime.CompilerServices.IsReadOnlyAttribute> as such:

```fsharp
[<IsReadOnly; Struct>]
type S(count1: int, count2: int) =
    member x.Count1 = count1
    member x.Count2 = count2
```

This disallows you from declaring a mutable member in the struct and emits metadata that allows F# and C# to treat it as readonly when consumed from an assembly. To learn more, see [ReadOnly structs](../language-reference/structures.md#readonly-structs).

## Void pointers

The `voidptr` type is added to F# 4.5, as are the following functions:

* `NativePtr.ofVoidPtr` to convert a void pointer into a native int pointer
* `NativePtr.toVoidPtr` to convert a native int pointer to a void pointer

This is helpful when interoperating with a native component that makes use of void pointers.

## The `match!` keyword

The `match!` keyword enhances pattern matching when inside a computation expression:

```fsharp
// Code that returns an asynchronous option
let checkBananaAsync (s: string) =
    async {
        if s = "banana" then
            return Some s
        else
            return None
    }
    
// Now you can use 'match!'
let funcWithString (s: string) =
    async { 
        match! checkBananaAsync s with
        | Some bananaString -> printfn "It's banana!"
        | None -> printfn "%s" s
}
```

This allows you to shorten code that often involves mixing options (or other types) with computation expressions such as async. To learn more, see [match!](../language-reference/computation-expressions.md#match).

## Relaxed upcasting requirements in array, list, and sequence expressions

Mixing types where one may inherit from another inside of array, list, and sequence expressions has traditionally required you to upcast any derived type to its parent type with `:>` or `upcast`. This is now relaxed, demonstrated as follows:

```fsharp
let x0 : obj list  = [ "a" ] // ok pre-F# 4.5
let x1 : obj list  = [ "a"; "b" ] // ok pre-F# 4.5
let x2 : obj list  = [ yield "a" :> obj ] // ok pre-F# 4.5

let x3 : obj list  = [ yield "a" ] // Now ok for F# 4.5, and can replace x2
```

## Indentation relaxation for array and list expressions

Prior to F# 4.5, you needed to excessively indent array and list expressions when passed as arguments to method calls. This is no longer required:

```fsharp
module NoExcessiveIndenting = 
    System.Console.WriteLine(format="{0}", arg = [| 
        "hello"
    |])
    System.Console.WriteLine([|
        "hello"
    |])
```
