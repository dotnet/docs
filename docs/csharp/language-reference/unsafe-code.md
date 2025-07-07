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

Unsafe code is a dialect of C# that unlocks powerful capabilities often needed for interoperability with native libraries, high-performance algorithms, and other low-level programming needs. However, these capabilities bypass C#'s usual safety checks, placing the responsibility for correctness squarely on the unsafe code author. Mistakes in unsafe code can lead to bugs like buffer overruns and use-after-free errors. To help isolate risks, unsafe code must appear within an [`unsafe`](keywords/unsafe.md) context, keeping it clearly separated from regular safe code and making it easier to audit.

In contrast, most C# code is safe code. Safe code always accesses, uses, and releases memory in ways that are proven correct by the C# compiler and .NET runtime.

Within an `unsafe` context, you can use pointers, manually allocate and free blocks of memory, and call methods through function pointers.

Unsafe code has the following characteristics:

- Methods, types, and code blocks can be marked as unsafe.
- Removing array bounds checks in unsafe code can, in some cases, improve performance.
- Unsafe code is required for calling native functions that use pointers.
- Using unsafe code introduces security and stability risks.
- Code containing unsafe blocks must be compiled with the [`AllowUnsafeBlocks`](compiler-options/language.md#allowunsafeblocks) compiler option.

## Pointer types

In an unsafe context, a type can be a pointer type, in addition to a value type, or a reference type. A pointer type declaration takes the following forms (with the `*` being the key syntax difference):

``` csharp
type* identifier;
```

The pointer indirection operator `*` can be used to access the contents at the location pointed to by the pointer variable. For example, consider the following declaration:

The following example demonstrates a complete example of using pointer types.

```csharp
int number = 42;
int numberAgain = 0;
bool same = false;

unsafe
{
    int* pointer = &number; // Assigns the address of number
    numberAgain = *pointer; // Retrieves the value at that address (42)
    same = number == numberAgain; // Will resolve to true
    Console.WriteLine($"Pointer (address): {(ulong)pointer}; Pointer value: {*pointer}");
}

Console.WriteLine($"NumberAgain: {numberAgain}; Same: {same}");

/* Example output (pointer address will vary each run):
Pointer (address): 6127673188; Pointer value: 42
NumberAgain: 42; Same: True
*/
```

The example also demonstrates how safe and unsafe code can interact. The first call to `Console.WriteLine` must be within the unsafe block because `pointer` can only be used in the `unsafe` context given its `int*` definition.

### Defining pointer types

When you declare multiple pointers in the same declaration, you write the asterisk (`*`) together with the underlying type only. For example:

```csharp
int* p1, p2, p3;     // Ok
int *p1, *p2, *p3;   // Invalid
```

The value of the pointer variable of type `MyType*` is the address of a variable of type `MyType`. The following are examples of pointer type declarations:

- `int* p`: `p` is a pointer to an integer.
- `int** p`: `p` is a pointer to a pointer to an integer.
- `int*[] p`: `p` is a single-dimensional array of pointers to integers.
- `char* p`: `p` is a pointer to a char.
- `void* p`: `p` is a pointer to an unknown type.


There are several examples of pointers in the articles on the [`fixed` statement](statements/fixed.md). The following example uses the `unsafe` keyword and the `fixed` statement, and shows how to increment an interior pointer. You can paste this code into the Main function of a console application to run it. These examples must be compiled with the [**AllowUnsafeBlocks**](compiler-options/language.md#allowunsafeblocks) compiler option set.

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="5":::

### Using pointer types

Pointer types don't inherit from [object](builtin-types/reference-types.md) and no conversions exist between pointer types and `object`. Also, boxing and unboxing don't support pointers. However, you can convert between different pointer types and between pointer types and integral types.

The garbage collector doesn't keep track of whether an object is being pointed to by any pointer types. If the referrant is an object in the managed heap (including local variables captured by lambda expressions or anonymous delegates), the object must be [pinned](./statements/fixed.md) for as long as the pointer is used.

You can't apply the indirection operator to a pointer of type `void*`. However, you can use a cast to convert a void pointer to any other pointer type, and vice versa.

A pointer can be `null`. Applying the indirection operator to a null pointer causes an implementation-defined behavior.

Passing pointers between methods can cause undefined behavior. Consider a method that returns a pointer to a local variable through an `in`, `out`, or `ref` parameter or as the function result. If the pointer was set in a fixed block, the variable to which it points might no longer be fixed.

The following table lists the operators and statements that can operate on pointers in an unsafe context:

| Operator/Statement                       | Use                                                            |
|------------------------------------------|----------------------------------------------------------------|
| `*`                                      | Performs pointer indirection.                                  |
| `->`                                     | Accesses a member of a struct through a pointer.               |
| `[]`                                     | Indexes a pointer.                                             |
| `&`                                      | Obtains the address of a variable.                             |
| `++` and `--`                            | Increments and decrements pointers.                            |
| `+` and `-`                              | Performs pointer arithmetic.                                   |
| `==`, `!=`, `<`, `>`, `<=`, and `>=`     | Compares pointers.                                             |
| [`stackalloc`](operators/stackalloc.md)  | Allocates memory on the stack.                                 |
| [`fixed` statement](statements/fixed.md) | Temporarily fixes a variable so that its address can be found. |

For more information about pointer-related operators, see [Pointer-related operators](operators/pointer-related-operators.md).

Any pointer type can be implicitly converted to a `void*` type. Any pointer type can be assigned the value `null`. Any pointer type can be explicitly converted to any other pointer type using a cast expression. You can also convert any integral type to a pointer type, or any pointer type to an integral type. These conversions require an explicit cast.

The following example converts an `int*` to a `byte*`. Notice that the pointer points to the lowest addressed byte of the variable. When you successively increment the result, up to the size of `int` (4 bytes), you can display the remaining bytes of the variable.

:::code language="csharp" source="snippets/unsafe-code/Conversions.cs" ID="Conversion":::

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

Fixed-size buffers are compiled with the <xref:System.Runtime.CompilerServices.UnsafeValueTypeAttribute?displayProperty=nameWithType>, which instructs the common language runtime (CLR) that a type contains an unmanaged array that can potentially overflow. Memory allocated using [stackalloc](operators/stackalloc.md) also automatically enables buffer overrun detection features in the CLR. The previous example shows how a fixed-size buffer could exist in an `unsafe struct`.

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

## How to use pointers to copy an array of bytes

The following example uses pointers to copy bytes from one array to another.

This example uses the [unsafe](keywords/unsafe.md) keyword, which enables you to use pointers in the `Copy` method. The [fixed](statements/fixed.md) statement is used to declare pointers to the source and destination arrays. The `fixed` statement *pins* the location of the source and destination arrays in memory so that garbage collection doesn't move the arrays. The memory blocks for the arrays are unpinned when the `fixed` block is completed. Because the `Copy` method in this example uses the `unsafe` keyword, it must be compiled with the [**AllowUnsafeBlocks**](compiler-options/language.md#allowunsafeblocks) compiler option.

This example accesses the elements of both arrays using indices rather than a second unmanaged pointer. The declaration of the `pSource` and `pTarget` pointers pins the arrays.

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="8":::

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
