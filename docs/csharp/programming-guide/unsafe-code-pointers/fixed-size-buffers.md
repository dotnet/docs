---
title: "Fixed Size Buffers - C# Programming Guide"
ms.date: 04/20/2018
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

In safe code, a C# struct that contains an array does not contain the array elements. Instead, the struct contains a reference to the elements. You can embed an array of fixed size in a [struct](../../language-reference/keywords/struct.md) when it is used in an [unsafe](../../language-reference/keywords/unsafe.md) code block.

The following `struct` is 8 bytes in size. The `pathName` array is a reference:

[!code-csharp[Struct with embedded array](../../../../samples/snippets/csharp/keywords/FixedKeywordExamples.cs#6)]

A `struct` can contain an embedded array in unsafe code. In the following example, the `fixedBuffer` array has a fixed size. You use a `fixed` statement to establish a pointer to the first element. You access the elements of the array through this pointer. The `fixed` statement pins the `fixedBuffer` instance field to a specific location in memory.

[!code-csharp[Struct with embedded inline array](../../../../samples/snippets/csharp/keywords/FixedKeywordExamples.cs#7)]

The size of the 128 element `char` array is 256 bytes. Fixed size [char](../../language-reference/builtin-types/char.md) buffers always take two bytes per character, regardless of the encoding. This is true even when char buffers are marshaled to API methods or structs with `CharSet = CharSet.Auto` or `CharSet = CharSet.Ansi`. For more information, see <xref:System.Runtime.InteropServices.CharSet>.

The  preceding example demonstrates accessing `fixed` fields without pinning, which is available starting with C# 7.3.

Another common fixed-size array is the [bool](../../language-reference/builtin-types/bool.md) array. The elements in a `bool` array are always one byte in size. `bool` arrays are not appropriate for creating bit arrays or buffers.

> [!NOTE]
> Except for memory created by using [stackalloc](../../language-reference/operators/stackalloc.md), the C# compiler and the common language runtime (CLR) do not perform any security buffer overrun checks. As with all unsafe code, use caution.

Unsafe buffers differ from regular arrays in the following ways:

- You can only use unsafe buffers in an unsafe context.
- Unsafe buffers are always vectors, or one-dimensional arrays.
- The declaration of the array should include a count, such as `char id[8]`. You cannot use `char id[]`.
- Unsafe buffers can only be instance fields of structs in an unsafe context.

## See also

- [C# Programming Guide](../index.md)
- [Unsafe Code and Pointers](index.md)
- [fixed Statement](../../language-reference/keywords/fixed-statement.md)
- [Interoperability](../interop/index.md)
