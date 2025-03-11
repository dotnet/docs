---
title: "sizeof operator - determine the storage needs for a type"
description: "Learn about the C# `sizeof` operator that returns the memory amount occupied by a variable of a given type."
ms.date: 02/06/2025
f1_keywords: 
  - "sizeof_CSharpKeyword"
  - "sizeof"
helpviewer_keywords: 
  - "sizeof keyword [C#]"
---
# sizeof operator - determine the memory needs for a given type

The `sizeof` operator returns the number of bytes occupied by a variable of a given type. In safe code, the argument to the `sizeof` operator must be the name of an [unmanaged type](../builtin-types/unmanaged-types.md) or a type parameter that is [constrained](../../programming-guide/generics/constraints-on-type-parameters.md#unmanaged-constraint) to be an unmanaged type. Unmanaged types include all numeric types, enum types, and tuple and struct types where all members are unmanaged types.

The expressions presented in the following table are evaluated in compile time to the corresponding constant values and don't require an unsafe context:

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

In unsafe code, the argument to `sizeof` can include pointer types and managed types, including unconstrained type parameters. Examples include `object` and `string`.

The following example demonstrates the usage of the `sizeof` operator:

:::code language="csharp" source="./snippets/shared/SizeOfOperator.cs":::

The `sizeof` operator returns the number of bytes allocated by the common language runtime in managed memory. For [struct](../builtin-types/struct.md) types, that value includes any padding, as the preceding example demonstrates. The result of the `sizeof` operator might differ from the result of the <xref:System.Runtime.InteropServices.Marshal.SizeOf%2A?displayProperty=nameWithType> method, which returns the size of a type in *unmanaged* memory.

In unsafe code, when the argument is a managed type, the `sizeof` operator returns the size of a reference, not the number of bytes allocated for an instance of that type.

> [!IMPORTANT]
>
> The value returned by `sizeof` can differ from the result of <xref:System.Runtime.InteropServices.Marshal.SizeOf(System.Object)?displayProperty=nameWithType>, which returns the size of the type in unmanaged memory.

## C# language specification

For more information, see [The sizeof operator](~/_csharpstandard/standard/unsafe-code.md#2369-the-sizeof-operator) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# operators and expressions](index.md)
- [Pointer related operators](pointer-related-operators.md)
- [Pointer types](../unsafe-code.md#pointer-types)
- [Memory and span-related types](../../../standard/memory-and-spans/index.md)
- [Generics in .NET](../../../standard/generics/index.md)
