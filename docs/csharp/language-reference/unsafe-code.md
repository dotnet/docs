---
title: "Unsafe code, pointers to data and function pointers"
description: Learn about unsafe code, pointers, and function pointers. C# requires you to declare an unsafe context to use these features to directly manipulate memory or function pointers.
ms.date: 04/01/2021
helpviewer_keywords: 
  - "security [C#], type safety"
  - "C# language, unsafe code"
  - "type safety [C#]"
  - "unsafe keyword [C#]"
  - "unsafe code [C#]"
  - "C# language, pointers"
  - "pointers [C#], about pointers"
ms.assetid: b0fcca10-a92d-4f2a-835b-b0ccae6739ee
---
# Unsafe code and pointer types

Most of the C# code you write is "verifiably safe code". *Verifiably safe code* means that .NET tools can verify that the code is safe. In general, safe code doesn't access memory directly using pointers. It also doesn't allocate raw memory; instead it creates managed objects.

C# supports an [`unsafe`](../keywords/unsafe.md) context, in which you may write *unverifiable* code. In an `unsafe` context, code may use pointers, allocate and free blocks of memory, and call methods using function pointers. Unsafe code in C# isn't necessarily dangerous; it's just code whose safety cannot be verified.

Unsafe code has the following properties:

- Methods, types, and code blocks can be defined as unsafe.
- In some cases, unsafe code may increase an application's performance by removing array bounds checks.
- Unsafe code is required when you call native functions that require pointers.
- Using unsafe code introduces security and stability risks.
- The code that contains unsafe blocks must be compiled with the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option.

## Pointer types

In an unsafe context, a type may be a pointer type, in addition to a value type, or a reference type. A pointer type declaration takes one of the following forms:

``` csharp
type* identifier;
void* identifier; //allowed but not recommended
```

The type specified before the `*` in a pointer type is called the **referent type**. Only an [unmanaged type](../builtin-types/unmanaged-types.md) can be a referent type.

Pointer types do not inherit from [object](../builtin-types/reference-types.md) and no conversions exist between pointer types and `object`. Also, boxing and unboxing do not support pointers. However, you can convert between different pointer types and between pointer types and integral types.

When you declare multiple pointers in the same declaration, the asterisk (*) is written together with the underlying type only; it is not used as a prefix to each pointer name. For example:

```csharp
int* p1, p2, p3;   // Ok
int *p1, *p2, *p3;   // Invalid in C#
```

A pointer cannot point to a reference or to a [struct](../builtin-types/struct.md) that contains references, because an object reference can be garbage collected even if a pointer is pointing to it. The garbage collector does not keep track of whether an object is being pointed to by any pointer types.

The value of the pointer variable of type `MyType*` is the address of a variable of type `MyType`. The following are examples of pointer type declarations:

- `int* p`: `p` is a pointer to an integer.
- `int** p`: `p` is a pointer to a pointer to an integer.
- `int*[] p`: `p` is a single-dimensional array of pointers to integers.
- `char* p`: `p` is a pointer to a char.
- `void* p`: `p` is a pointer to an unknown type.

The pointer indirection operator `*` can be used to access the contents at the location pointed to by the pointer variable. For example, consider the following declaration:

```csharp
int* myVariable;
```

The expression `*myVariable` denotes the `int` variable found at the address contained in `myVariable`.

There are several examples of pointers in the topics [fixed Statement](../keywords/fixed-statement.md) and [Pointer Conversions](./pointer-conversions.md). The following example uses the `unsafe` keyword and the `fixed` statement, and shows how to increment an interior pointer.  You can paste this code into the Main function of a console application to run it. These examples must be compiled with the [**AllowUnsafeBlocks**](../../language-reference/compiler-options/language.md#allowunsafeblocks) compiler option set.

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="5":::

You cannot apply the indirection operator to a pointer of type `void*`. However, you can use a cast to convert a void pointer to any other pointer type, and vice versa.

A pointer can be `null`. Applying the indirection operator to a null pointer causes an implementation-defined behavior.

Passing pointers between methods can cause undefined behavior. Consider a method that returns a pointer to a local variable through an `in`, `out`, or `ref` parameter or as the function result. If the pointer was set in a fixed block, the variable to which it points may no longer be fixed.

The following table lists the operators and statements that can operate on pointers in an unsafe context:

|Operator/Statement|Use|
|-------------------------|---------|
|`*`|Performs pointer indirection.|
|`->`|Accesses a member of a struct through a pointer.|
|`[]`|Indexes a pointer.|
|`&`|Obtains the address of a variable.|
|`++` and `--`|Increments and decrements pointers.|
|`+` and `-`|Performs pointer arithmetic.|
|`==`, `!=`, `<`, `>`, `<=`, and `>=`|Compares pointers.|
|[`stackalloc`](../operators/stackalloc.md)|Allocates memory on the stack.|
|[`fixed` statement](../keywords/fixed-statement.md)|Temporarily fixes a variable so that its address may be found.|

For more information about pointer related operators, see [Pointer related operators](../operators/pointer-related-operators.md).

### Implicit pointer conversions REWRITE

|From|To|
|----------|--------|
|Any pointer type|void*|
|null|Any pointer type|

Explicit pointer conversion is used to perform conversions, for which there is no implicit conversion, by using a cast expression. The following table shows these conversions.

### Explicit pointer conversions REWRITE

|From|To|
|----------|--------|
|Any pointer type|Any other pointer type|
|sbyte, byte, short, ushort, int, uint, long, or ulong|Any pointer type|
|Any pointer type|sbyte, byte, short, ushort, int, uint, long, or ulong|

### Example REWRITE

In the following example, a pointer to `int` is converted to a pointer to `byte`. Notice that the pointer points to the lowest addressed byte of the variable. When you successively increment the result, up to the size of `int` (4 bytes), you can display the remaining bytes of the variable.

:::code language="csharp" source="snippets/unsafe-code/Conversions.cs" ID="Conversion":::

## Fixed Size Buffers

In C#, you can use the [fixed](../keywords/fixed-statement.md) statement to create a buffer with a fixed size array in a data structure. Fixed size buffers are useful when you write methods that interop with data sources from other languages or platforms. The fixed array can take any attributes or modifiers that are allowed for regular struct members. The only restriction is that the array type must be `bool`, `byte`, `char`, `short`, `int`, `long`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double`.

```csharp
private fixed char name[30];
```

In safe code, a C# struct that contains an array does not contain the array elements. Instead, the struct contains a reference to the elements. You can embed an array of fixed size in a [struct](../builtin-types/struct.md) when it is used in an [unsafe](../keywords/unsafe.md) code block.

Size of the following `struct` doesn't depend on the number of elements in the array, since `pathName` is a reference:

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="6":::

A `struct` can contain an embedded array in unsafe code. In the following example, the `fixedBuffer` array has a fixed size. You use a `fixed` statement to establish a pointer to the first element. You access the elements of the array through this pointer. The `fixed` statement pins the `fixedBuffer` instance field to a specific location in memory.

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="7":::

The size of the 128 element `char` array is 256 bytes. Fixed size [char](../builtin-types/char.md) buffers always take two bytes per character, regardless of the encoding. This is true even when char buffers are marshaled to API methods or structs with `CharSet = CharSet.Auto` or `CharSet = CharSet.Ansi`. For more information, see <xref:System.Runtime.InteropServices.CharSet>.

The  preceding example demonstrates accessing `fixed` fields without pinning, which is available starting with C# 7.3.

Another common fixed-size array is the [bool](../builtin-types/bool.md) array. The elements in a `bool` array are always one byte in size. `bool` arrays are not appropriate for creating bit arrays or buffers.

Fixed size buffers are compiled with the <xref:System.Runtime.CompilerServices.UnsafeValueTypeAttribute?displayProperty=nameWithType>, which instructs the common language runtime (CLR) that a type contains an unmanaged array that can potentially overflow. This is similar to memory created using [stackalloc](../operators/stackalloc.md), which automatically enables buffer overrun detection features in the CLR. The previous example shows how a fixed size buffer could exist in an `unsafe struct`.

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

- May only be used in an `unsafe` context.
- May only be instance fields of structs.
- They're always vectors, or one-dimensional arrays.
- The declaration should include the length, such as `fixed char id[8]`. You cannot use `fixed char id[]`.

## How to use pointers to copy an array of bytes

The following example uses pointers to copy bytes from one array to another.

This example uses the [unsafe](../keywords/unsafe.md) keyword, which enables you to use pointers in the `Copy` method. The [fixed](../keywords/fixed-statement.md) statement is used to declare pointers to the source and destination arrays. The `fixed` statement *pins* the location of the source and destination arrays in memory so that they will not be moved by garbage collection. The memory blocks for the arrays are unpinned when the `fixed` block is completed. Because the `Copy` method in this example uses the `unsafe` keyword, it must be compiled with the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option.

This example accesses the elements of both arrays using indices rather than a second unmanaged pointer. The declaration of the `pSource` and `pTarget` pointers pins the arrays. This feature is available starting with C# 7.3.

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="8":::

## C# language specification

For more information, see the [Unsafe code](~/_csharplang/spec/unsafe-code.md) topic of the [C# language specification](~/_csharplang/spec/introduction.md).
