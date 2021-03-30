---
title: "Fixed Size Buffers - C# Programming Guide"
description: Learn about fixed size buffers. Fixed size buffers are used to write methods that interop with data sources from other languages.
ms.date: 04/23/2020
helpviewer_keywords:
  - "fixed size buffers [C#]"
  - "unsafe buffers [C#]"
  - "unsafe code [C#], fixed size buffers"
---
# Fixed Size Buffers (C# Programming Guide)

In C#, you can use the [fixed](../../language-reference/keywords/fixed-statement.md) statement to create a buffer with a fixed size array in a data structure. Fixed size buffers are useful when you write methods that interop with data sources from other languages or platforms. The fixed array can take any attributes or modifiers that are allowed for regular struct members. The only restriction is that the array type must be `bool`, `byte`, `char`, `short`, `int`, `long`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double`.

```csharp
private fixed char name[30];
```

## Remarks

In safe code, a C# struct that contains an array does not contain the array elements. Instead, the struct contains a reference to the elements. You can embed an array of fixed size in a [struct](../../language-reference/builtin-types/struct.md) when it is used in an [unsafe](../../language-reference/keywords/unsafe.md) code block.

Size of the following `struct` doesn't depend on the number of elements in the array, since `pathName` is a reference:

[!code-csharp[Struct with embedded array](snippets/FixedKeywordExamples.cs#6)]

A `struct` can contain an embedded array in unsafe code. In the following example, the `fixedBuffer` array has a fixed size. You use a `fixed` statement to establish a pointer to the first element. You access the elements of the array through this pointer. The `fixed` statement pins the `fixedBuffer` instance field to a specific location in memory.

[!code-csharp[Struct with embedded inline array](snippets/FixedKeywordExamples.cs#7)]

The size of the 128 element `char` array is 256 bytes. Fixed size [char](../../language-reference/builtin-types/char.md) buffers always take two bytes per character, regardless of the encoding. This is true even when char buffers are marshaled to API methods or structs with `CharSet = CharSet.Auto` or `CharSet = CharSet.Ansi`. For more information, see <xref:System.Runtime.InteropServices.CharSet>.

The  preceding example demonstrates accessing `fixed` fields without pinning, which is available starting with C# 7.3.

Another common fixed-size array is the [bool](../../language-reference/builtin-types/bool.md) array. The elements in a `bool` array are always one byte in size. `bool` arrays are not appropriate for creating bit arrays or buffers.

Fixed size buffers are compiled with the <xref:System.Runtime.CompilerServices.UnsafeValueTypeAttribute?displayProperty=nameWithType>, which instructs the common language runtime (CLR) that a type contains an unmanaged array that can potentially overflow. This is similar to memory created using [stackalloc](../../language-reference/operators/stackalloc.md), which automatically enables buffer overrun detection features in the CLR. The previous example shows how a fixed size buffer could exist in an `unsafe struct`.

```csharp
internal unsafe struct Buffer
{
    public fixed char fixedBuffer[128];
}
```

The compiler generated C# for `Buffer`, is attributed as follows:

```csharp
internal struct Buffer
{
    [StructLayout(LayoutKind.Sequential, Size = 256)]
    [CompilerGenerated]
    [UnsafeValueType]
    public struct <fixedBuffer>e__FixedBuffer
    {
        public char FixedElementField;
    }

    [FixedBuffer(typeof(char), 128)]
    public <fixedBuffer>e__FixedBuffer fixedBuffer;
}
```

Fixed size buffers differ from regular arrays in the following ways:

- May only be used in an [unsafe](../../language-reference/keywords/unsafe.md) context.
- May only be instance fields of structs.
- They're always vectors, or one-dimensional arrays.
- The declaration should include the length, such as `fixed char id[8]`. You cannot use `fixed char id[]`.

## See also

- [C# Programming Guide](../index.md)
- [Unsafe Code and Pointers](index.md)
- [fixed Statement](../../language-reference/keywords/fixed-statement.md)
- [Interoperability](../interop/index.md)
