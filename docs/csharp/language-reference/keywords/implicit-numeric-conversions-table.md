---
title: "Implicit numeric conversions table (C# Reference)"
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
|[sbyte](sbyte.md)|`short`, `int`, `long`, `float`, `double`, or `decimal`|  
|[byte](byte.md)|`short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[short](short.md)|`int`, `long`, `float`, `double`, or `decimal`|  
|[ushort](ushort.md)|`int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[int](int.md)|`long`, `float`, `double`, or `decimal`|  
|[uint](uint.md)|`long`, `ulong`, `float`, `double`, or `decimal`|  
|[long](long.md)|`float`, `double`, or `decimal`|  
|[char](char.md)|`ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|  
|[float](float.md)|`double`|  
|[ulong](ulong.md)|`float`, `double`, or `decimal`|  
  
## Remarks  

- Any [integral type](integral-types-table.md) is implicitly convertible to any [floating-point type](floating-point-types-table.md).

- Precision but not magnitude might be lost in the conversions from `int`, `uint`, `long`, or `ulong` to `float` and from `long` or `ulong` to `double`.  
  
- There are no implicit conversions to the `char` type.  
  
- There are no implicit conversions between the `float` and `double` types and the `decimal` type.  
  
- A value of a constant expression of type `int` (for example, a value represented by an integral literal) can be converted to `sbyte`, `byte`, `short`, `ushort`, `uint`, or `ulong`, provided it's within the range of the destination type:

  ```csharp
  byte a = 13;    // Compiles
  byte b = 300;   // CS0031: Constant value '300' cannot be converted to a 'byte'
  ```

For more information about implicit conversions, see the [Implicit conversions](/dotnet/csharp/language-reference/language-specification/conversions#implicit-conversions) section of the [C# language specification](../language-specification/index.md).
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Integral types table](integral-types-table.md)
- [Floating-point types table](floating-point-types-table.md)
- [Built-in types table](built-in-types-table.md)
- [Explicit numeric conversions table](explicit-numeric-conversions-table.md)
- [Casting and type conversions](../../programming-guide/types/casting-and-type-conversions.md)
