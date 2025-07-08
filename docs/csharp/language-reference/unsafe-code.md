---
title: "Unsafe code"
description: Learn about unsafe code, pointers, and function pointers. C# requires you to declare an unsafe context to use these features to directly manipulate memory or function pointers (unmanaged delegates).
ms.date: 07/07/2025
f1_keywords:
  - "functionPointer_CSharpKeyword"
helpviewer_keywords: 
  - "security [C#], type safety"
  - "C# language, unsafe code"
  - "type safety [C#]"
  - "unsafe keyword [C#]"
  - "unsafe code [C#]"
  - "C# language, pointers"
  - "pointers [C#], about pointers"
---

# Unsafe code

C#'s unsafe code feature enables direct memory manipulation using pointers and other low-level constructs. These capabilities are essential for interop with native libraries and high-performance scenarios. However, unsafe code bypasses C#'s safety guarantees, so it's up to you, the author, to ensure correctness. Bugs like reading uninitialized/incorrect memory, buffer overruns, and use-after-free become possible. Unsafe code must appear within an [`unsafe`](keywords/unsafe.md) context and requires the [`AllowUnsafeBlocks`](compiler-options/language.md#allowunsafeblocks) compiler option.

Most C# code is safe code, where the compiler and .NET runtime enforce memory safety.

## Pointer types

In an unsafe context, C# supports **pointer types**. Pointers let you work with memory addresses directly, which is necessary for many interop scenarios and advanced optimizations.

A pointer type declaration looks like:

```csharp
type* identifier;
```

For example:

```csharp
int number = 42;
int numberAgain = 0;
bool same = false;

unsafe
{
    int* pointer = &number; // Assigns the address of number
    numberAgain = *pointer;   // Retrieves the value at that address (42)
    same = number == numberAgain; // Will resolve to true
    PrintAddress(pointer); // Prints the address of the pointer
    Console.WriteLine($"Pointer value: {*pointer}");
}

Console.WriteLine($"NumberAgain: {numberAgain}; Same: {same}");

unsafe void PrintAddress(int* pointer) =>
    Console.WriteLine($"Pointer address: 0x{(nuint)p:X}");

/* Example output (pointer address will vary each run):
Pointer address: 0x16F279F64
Pointer value: 42
NumberAgain: 42; Same: True
*/
```

### Declaring and using pointers

You can declare multiple pointers in one statement:

```csharp
int* p1, p2, p3;   // All are int pointers
```

Common pointer types:

- `int* p`: pointer to `int`
- `int** p`: pointer to pointer to `int`
- `int*[] p`: array of `int` pointers
- `char* p`: pointer to `char`
- `void* p`: pointer to unknown type

### Pointer operations

Pointers don't inherit from [`object`](builtin-types/reference-types.md). You can't box or unbox pointers, and there's no conversion between pointers and `object`. However, you can cast between pointer types and between pointers and integral types (with an explicit cast).

The garbage collector doesn't track references from pointers. If you're pointing to a managed object, you must [pin](./statements/fixed.md) it for as long as the pointer is used.

The following operators and statements work with pointers in an unsafe context:

| Operator/Statement                       | Use                                                            |
|------------------------------------------|----------------------------------------------------------------|
| `*`                                      | Dereference (pointer indirection).                             |
| `->`                                     | Access struct member through a pointer.                        |
| `[]`                                     | Index a pointer.                                               |
| `&`                                      | Take the address of a variable.                                |
| `++` and `--`                            | Increment/decrement pointer.                                   |
| `+` and `-`                              | Pointer arithmetic.                                            |
| `==`, `!=`, `<`, `>`, `<=`, and `>=`     | Pointer comparison.                                            |
| [`stackalloc`](operators/stackalloc.md)  | Allocate memory on the stack.                                  |
| [`fixed` statement](statements/fixed.md) | Pin a variable so its address can be taken.                    |

See [Pointer-related operators](operators/pointer-related-operators.md) for details.

### Pointer conversions and Interop

- Any pointer type can be implicitly converted to `void*`.
- Any pointer type can be set to `null`.
- You can explicitly cast between pointer types and between pointers and integral types (integral types must be at least the size of a pointer: `nint`, `nuint`, `IntPtr`, `UIntPtr`, or — on 64-bit — `long`/`ulong`).
- You can't dereference a `void*` directly, but you can cast it to another pointer type.

For example, converting an `int*` to a `byte*` lets you examine individual bytes:

:::code language="csharp" source="snippets/unsafe-code/Conversions.cs" ID="Conversion":::

### Pointer safety reminders

- Dereferencing a null pointer is implementation-defined and may crash your program.
- Passing pointers to or from methods, especially if they refer to stack or pinned data, can cause undefined behavior if the referent is no longer valid.
- Never store a pointer to stack memory outside the current method.

## Fixed-size buffers

You can use the `fixed` keyword to create a buffer with a fixed-size array in a data structure. Fixed-size buffers are useful when you write methods that interoperate with data sources from other languages or platforms. The fixed-size buffer can take any attributes or modifiers that are allowed for regular struct members. The only restriction is that the array type must be `bool`, `byte`, `char`, `short`, `int`, `long`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double`.

```csharp
private fixed char name[30];
```

In safe code, a C# struct that contains an array doesn't contain the array elements. The struct contains a reference to the elements instead. You can embed an array of fixed size in a [struct](builtin-types/struct.md) when it's used in an [unsafe](keywords/unsafe.md) code block.

The size of the following `struct` doesn't depend on the number of elements in the array, since `pathName` is a reference:

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="6":::

A struct can contain an embedded array in unsafe code. In the following example, the `fixedBuffer` array has a fixed size. You use a [`fixed` statement](statements/fixed.md) to get a pointer to the first element. You access the elements of the array through this pointer. The `fixed` statement pins the `fixedBuffer` instance field to a specific location in memory.

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="7":::

The size of the 128 element `char` array is 256 bytes. Fixed-size [char](builtin-types/char.md) buffers always take 2 bytes per character, regardless of the encoding. This array size is the same even when char buffers are marshaled to API methods or structs with `CharSet = CharSet.Auto` or `CharSet = CharSet.Ansi`. For more information, see <xref:System.Runtime.InteropServices.CharSet>.

The  preceding example demonstrates accessing `fixed` fields without pinning. Another common fixed-size array is the [bool](builtin-types/bool.md) array. The elements in a `bool` array are always 1 byte in size. `bool` arrays aren't appropriate for creating bit arrays or buffers.

Fixed-size buffers are compiled with the <xref:System.Runtime.CompilerServices.UnsafeValueTypeAttribute?displayProperty=nameWithType>, which instructs the .NET runtime that a type contains an unmanaged array that can potentially overflow. Memory allocated using [stackalloc](operators/stackalloc.md) also automatically enables buffer overrun detection features in the CLR. The previous example shows how a fixed-size buffer could exist in an `unsafe struct`.

```csharp
internal unsafe struct Buffer
{
    public fixed char fixedBuffer[128];
}
```

The compiler-generated C# for `Buffer` is attributed as follows:

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

Fixed-size buffers differ from regular arrays in the following ways:

- May only be used in an `unsafe` context.
- May only be instance fields of structs.
- They're always vectors, or one-dimensional arrays.
- The declaration should include the length, such as `fixed char id[8]`. You can't use `fixed char id[]`.

## Function pointers

C# provides [`delegate`](builtin-types/reference-types.md#the-delegate-type) types to define safe function pointer objects. Invoking a delegate involves instantiating a type derived from <xref:System.Delegate?displayProperty=nameWithType> and making a virtual method call to its `Invoke` method. This virtual call uses the `callvirt` IL instruction. In performance critical code paths, using the `calli` IL instruction is more efficient.

You can define a function pointer using the `delegate*` syntax. The compiler calls the function using the `calli` instruction rather than instantiating a `delegate` object and calling `Invoke`. The following code declares two methods that use a `delegate` or a `delegate*` to combine two objects of the same type. The first method uses a <xref:System.Func%603?displayProperty=nameWithType> delegate type. The second method uses a `delegate*` declaration with the same parameters and return type:

:::code language="csharp" source="snippets/unsafe-code/FunctionPointers.cs" ID="UseDelegateOrPointer":::

The following code shows how you would declare a static local function and invoke the `UnsafeCombine` method using a pointer to that local function:

:::code language="csharp" source="snippets/unsafe-code/FunctionPointers.cs" ID="InvokeViaFunctionPointer":::

The preceding code illustrates several of the rules on the function accessed as a function pointer:

- Function pointers can only be declared in an `unsafe` context.
- Methods that take a `delegate*` (or return a `delegate*`) can only be called in an `unsafe` context.
- The `&` operator to obtain the address of a function is allowed only on `static` functions. (This rule applies to both member functions and local functions).

The syntax has parallels with declaring `delegate` types and using pointers. The `*` suffix on `delegate` indicates the declaration is a *function pointer*. The `&` when assigning a method group to a function pointer indicates the operation takes the address of the method.

You can specify the calling convention for a `delegate*` using the keywords `managed` and `unmanaged`. In addition, for `unmanaged` function pointers, you can specify the calling convention. The following declarations show examples of each. The first declaration uses the `managed` calling convention, which is the default. The next four use an `unmanaged` calling convention. Each specifies one of the ECMA 335 calling conventions: `Cdecl`, `Stdcall`, `Fastcall`, or `Thiscall`. The last declaration uses the `unmanaged` calling convention, instructing the CLR to pick the default calling convention for the platform. The CLR chooses the calling convention at run time.

:::code language="csharp" source="snippets/unsafe-code/FunctionPointers.cs" ID="UnmanagedFunctionPointers":::

You can learn more about function pointers in the [Function pointer](~/_csharplang/proposals/csharp-9.0/function-pointers.md) feature spec.

## C# language specification

For more information, see the [Unsafe code](~/_csharpstandard/standard/unsafe-code.md) chapter of the [C# language specification](~/_csharpstandard/standard/README.md).
