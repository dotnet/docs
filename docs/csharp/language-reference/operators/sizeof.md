---
title: "sizeof operator - C# reference"
description: "Learn about the C# sizeof operator that returns the memory amount occupied by a variable of a given type."
ms.date: 07/25/2019
f1_keywords: 
  - "sizeof_CSharpKeyword"
  - "sizeof"
helpviewer_keywords: 
  - "sizeof keyword [C#]"
ms.assetid: c548592c-677c-4f40-a4ce-e613f7529141
---
# sizeof operator (C# reference)

The `sizeof` operator returns the number of bytes occupied by a variable of a given type. The argument to the `sizeof` operator must be the name of an [unmanaged type](../builtin-types/unmanaged-types.md) or a type parameter that is [constrained](../../programming-guide/generics/constraints-on-type-parameters.md#unmanaged-constraint) to be an unmanaged type.

The `sizeof` operator requires an [unsafe](../keywords/unsafe.md) context. However, the expressions presented in the following table are evaluated in compile time to the corresponding constant values and don't require an unsafe context:

|Expression|Constant value|
|---------|---------------|
|`sizeof(sbyte)`|1|
|`sizeof(byte)`|1|
|`sizeof(short)`|2|
|`sizeof(ushort)`|2|
|`sizeof(int)`|4|
|`sizeof(uint)`|4|
|`sizeof(long)`|8|
|`sizeof(ulong)`|8|
|`sizeof(char)`|2|
|`sizeof(float)`|4|
|`sizeof(double)`|8|
|`sizeof(decimal)`|16|
|`sizeof(bool)`|1|

You also don't need to use an unsafe context when the operand of the `sizeof` operator is the name of an [enum](../builtin-types/enum.md) type.

The following example demonstrates the usage of the `sizeof` operator:

[!code-csharp[sizeof examples](snippets/shared/SizeOfOperator.cs)]

The `sizeof` operator returns a number of bytes that would be allocated by the common language runtime in managed memory. For [struct](../builtin-types/struct.md) types, that value includes any padding, as the preceding example demonstrates. The result of the `sizeof` operator might differ from the result of the <xref:System.Runtime.InteropServices.Marshal.SizeOf%2A?displayProperty=nameWithType> method, which returns the size of a type in *unmanaged* memory.

## C# language specification

For more information, see [The sizeof operator](~/_csharplang/spec/unsafe-code.md#the-sizeof-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Pointer related operators](pointer-related-operators.md)
- [Pointer types](../unsafe-code.md#pointer-types)
- [Memory and span-related types](../../../standard/memory-and-spans/index.md)
- [Generics in .NET](../../../standard/generics/index.md)
