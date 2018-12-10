---
title: "sizeof - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "sizeof_CSharpKeyword"
  - "sizeof"
helpviewer_keywords: 
  - "sizeof keyword [C#]"
ms.assetid: c548592c-677c-4f40-a4ce-e613f7529141
---
# sizeof (C# Reference)

Used to obtain the size in bytes for an unmanaged type.

Unmanaged types include:

- The simple types that are listed in the following table:

   |Expression|Constant value|
   |----------------|--------------------|
   |`sizeof(sbyte)`|1|
   |`sizeof(byte)`|1|
   |`sizeof(short)`|2|
   |`sizeof(ushort)`|2|
   |`sizeof(int)`|4|
   |`sizeof(uint)`|4|
   |`sizeof(long)`|8|
   |`sizeof(ulong)`|8|
   |`sizeof(char)`|2 (Unicode)|
   |`sizeof(float)`|4|
   |`sizeof(double)`|8|
   |`sizeof(decimal)`|16|
   |`sizeof(bool)`|1|

- Enum types.

- Pointer types.

- User-defined structs that do not contain any instance fields or auto-implemented instance properties that are reference types or constructed types.

The following example shows how to retrieve the size of an `int`:

```csharp
// Constant value 4:
int intSize = sizeof(int);
```

## Remarks

Starting with version 2.0 of C#, applying `sizeof` to simple or enum types no longer requires that code be compiled in an [unsafe](unsafe.md) context.

The `sizeof` operator cannot be overloaded. The values returned by the `sizeof` operator are of type `int`. The previous table shows the constant values that are substituted for `sizeof` expressions that have certain simple types as operands.

For all other types, including structs, the `sizeof` operator can be used only in unsafe code blocks. Although you can use the <xref:System.Runtime.InteropServices.Marshal.SizeOf%2A?displayProperty=nameWithType> method, the value returned by this method is not always the same as the value returned by `sizeof`. <xref:System.Runtime.InteropServices.Marshal.SizeOf%2A?displayProperty=nameWithType> returns the size after the type has been marshaled, whereas `sizeof` returns the size as it has been allocated by the common language runtime, including any padding.

## Example

[!code-csharp[csrefKeywordsOperator#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#11)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Operator Keywords](operator-keywords.md)
- [enum](enum.md)
- [Unsafe Code and Pointers](../../programming-guide/unsafe-code-pointers/index.md)
- [Structs](../../programming-guide/classes-and-structs/structs.md)
- [Constants](../../programming-guide/classes-and-structs/constants.md)