---
title: Span (F#)
description: Learn how to create and use Span types in the F# programming language.
ms.date: 07/23/2018
---
# Span<'T>

## What is Span<'T>?

`Span<'T>` is a value type that holds a pointer and a length value. It represents a slice/range of memory that a developer wants to work with in a type safe manner. The memory can be stack allocated, managed or unmanaged/native memory on the heap. It also has the same performance characterstics as an array.

The type argument, `'T`, is the type of data we want to operate on from a `Span`.

## Creating a Span<'T>

A few typical ways of creating a `Span<'T>` are either by a managed array or a pointer.

For example:
```fsharp
// Creates an int array.
let xs = [|1;2;3;4;5|]

// Essentially wraps the array in a Span, covers the entire array for its range.
// Creates a Span<int>.
let s = Span(xs)

// Wraps the array, but its range starts at index 0 and spans a length of 2.
// Accessing elements outside of a range results in an exception.
// Creates a Span<int>.
let s2 = Span(xs, 0, 2)


// Allocate 5 bytes of memory on the current stack frame.
let stackPtr = 
    NativePtr.stackalloc<byte> 5
    |> NativePtr.toVoidPtr

// Wraps a the pointer that points to stack allocated memory. Spans a length of 5.
let s3 = Span<byte>(stackPtr, 5)


// Creates an empty Span<byte>.
let s4 = Span<byte>.Empty
```

## Accessing Elements

Similar to F# arrays, you can access an element from a `Span<'T>` by using a dot operator (`.`) and brackets (`[` and `]`).

For example:
```fsharp
let getFirstItem (s: Span<byte>) = s.[0]
```

The difference with `Span<'T>` is that its indexer returns a `byref<'T>`. Because F# implicitly dereferences a byref returned from a function, the return value from the indexer will be `'T`, unless explicit using `&`, e.g. `&s.[0]`. See more about byref rules here: ????

## Why use Span<'T>?

Since it is a built-in type for .NET Core, a typical reason to use `Span<'T>` is simply needing to consume APIs that use it.

Otherwise, it depends on what the developer needs. If a developer find themselves using only segments of an array a lot, `Span<'T>` might be a good fit. For example:

```fsharp
let numBytesRead = udpSocket.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, &endPoint)
let spanBuffer = Span(buffer, 0, numBytesRead)
```

Normally, a developer would have to manage iterating through the buffer for a certain number of bytes that were read from the socket. `Span<byte>` can now 





