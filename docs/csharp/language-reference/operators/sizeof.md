---
title: "sizeof operator - determine the storage needs for a type"
description: "Learn about the C# `sizeof` operator that returns the memory amount occupied by a variable of a given type."
ms.date: 01/20/2026
f1_keywords: 
  - "sizeof_CSharpKeyword"
  - "sizeof"
helpviewer_keywords: 
  - "sizeof keyword [C#]"
---
# sizeof operator - determine the memory needs for a given type

The `sizeof` operator returns the number of bytes occupied by a variable of a given type. In safe code, the argument to the `sizeof` operator must be the name of a built-in [unmanaged type](../builtin-types/unmanaged-types.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The expressions presented in the following table are evaluated at compile time to the corresponding constant values and don't require an unsafe context:

| Expression        | Constant value |
|-------------------|----------------|
| `sizeof(sbyte)`   |  1             |
| `sizeof(byte)`    |  1             |
| `sizeof(short)`   |  2             |
| `sizeof(ushort)`  |  2             |
| `sizeof(int)`     |  4             |
| `sizeof(uint)`    |  4             |
| `sizeof(long)`    |  8             |
| `sizeof(ulong)`   |  8             |
| `sizeof(char)`    |  2             |
| `sizeof(float)`   |  4             |
| `sizeof(double)`  |  8             |
| `sizeof(decimal)` | 16             |
| `sizeof(bool)`    |  1             |

The size of a built-in, unmanaged type is a compile-time constant.

In [unsafe](../keywords/unsafe.md) code, you can use `sizeof` as follows:

- A type parameter that is [constrained](../../programming-guide/generics/constraints-on-type-parameters.md#unmanaged-constraint) to be an unmanaged type returns the size of that unmanaged type at runtime.
- A managed type or a pointer type returns the size of the reference or pointer, not the size of the object it refers to.

The following example demonstrates the usage of the `sizeof` operator:

:::code language="csharp" source="./snippets/shared/SizeOfOperator.cs":::

The `sizeof` operator returns the number of bytes allocated by the common language runtime in managed memory. For [struct](../builtin-types/struct.md) types, that value includes any padding, as the preceding example demonstrates. The result of the `sizeof` operator might differ from the result of the <xref:System.Runtime.InteropServices.Marshal.SizeOf%2A?displayProperty=nameWithType> method, which returns the size of a type in *unmanaged* memory.

> [!IMPORTANT]
>
> The value returned by `sizeof` can differ from the result of <xref:System.Runtime.InteropServices.Marshal.SizeOf(System.Object)?displayProperty=nameWithType>, which returns the size of the type in unmanaged memory.

## C# language specification

For more information, see [The sizeof operator](~/_csharpstandard/standard/unsafe-code.md#2469-the-sizeof-operator) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# operators and expressions](index.md)
- [Pointer related operators](pointer-related-operators.md)
- [Pointer types](../unsafe-code.md#pointer-types)
- [Memory and span-related types](../../../standard/memory-and-spans/index.md)
- [Generics in .NET](../../../standard/generics/index.md)
