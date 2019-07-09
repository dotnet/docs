---
title: "Implicit numeric conversions table - C# Reference"
ms.custom: seodec18
ms.date: 09/05/2018
helpviewer_keywords: 
  - "conversions [C#], implicit numeric"
  - "implicit numeric conversions [C#]"
  - "numeric conversions [C#], implicit"
  - "types [C#], implicit numeric conversions"
ms.assetid: 72eb5a94-0491-48bf-8032-d7ebfdfeb8d8
---
# Implicit numeric conversions table (C# Reference)

The following table shows the predefined implicit conversions between .NET numeric types.
  
|From|To|  
|----------|--------|  
|[sbyte](../builtin-types/integral-numeric-types.md)|`short`, `int`, `long`, `float`, `double`, or `decimal`|  
|[byte](../builtin-types/integral-numeric-types.md)|`short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[char](char.md)|`ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[short](../builtin-types/integral-numeric-types.md)|`int`, `long`, `float`, `double`, or `decimal`|  
|[ushort](../builtin-types/integral-numeric-types.md)|`int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[int](../builtin-types/integral-numeric-types.md)|`long`, `float`, `double`, or `decimal`|  
|[uint](../builtin-types/integral-numeric-types.md)|`long`, `ulong`, `float`, `double`, or `decimal`|  
|[long](../builtin-types/integral-numeric-types.md)|`float`, `double`, or `decimal`|  
|[ulong](../builtin-types/integral-numeric-types.md)|`float`, `double`, or `decimal`|  
|[float](../builtin-types/floating-point-numeric-types.md)|`double`|  
  
## Remarks  

- Any [integral type](../builtin-types/integral-numeric-types.md) is implicitly convertible to any [floating-point type](../builtin-types/floating-point-numeric-types.md).

- Precision but not magnitude might be lost in the conversions from `int`, `uint`, `long`, or `ulong` to `float` and from `long` or `ulong` to `double`.  
  
- There are no implicit conversions to the `char`, `byte`, and `sbyte` types.  

- There are no implicit conversions from the `double` and `decimal` types.
  
- There are no implicit conversions between the `decimal` type and the `float` or `double` types.  
  
- A value of a constant expression of type `int` (for example, a value represented by an integral literal) can be converted to `sbyte`, `byte`, `short`, `ushort`, `uint`, or `ulong`, provided it's within the range of the destination type:

  ```csharp
  byte a = 13;    // Compiles
  byte b = 300;   // CS0031: Constant value '300' cannot be converted to a 'byte'
  ```

For more information about implicit conversions, see the [Implicit conversions](~/_csharplang/spec/conversions.md#implicit-conversions) section of the [C# language specification](../language-specification/index.md).
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Integral types](../builtin-types/integral-numeric-types.md)
- [Floating-point types table](../builtin-types/floating-point-numeric-types.md)
- [Built-in types table](built-in-types-table.md)
- [Explicit numeric conversions table](explicit-numeric-conversions-table.md)
- [Casting and type conversions](../../programming-guide/types/casting-and-type-conversions.md)
