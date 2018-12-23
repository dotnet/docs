---
title: "Integral types table - C# Reference"
ms.custom: seodec18

description: "Overview of the built-in C# integral types"
ms.date: 08/20/2018
helpviewer_keywords: 
  - "integral types, C#"
  - "Visual C#, integral types"
  - "types [C#], integral types"
  - "ranges of integral types [C#]"
ms.assetid: 62e86126-46ff-40b0-9028-e61d7558268c
---
# Integral types table (C# Reference)

The following table shows the sizes and ranges of the integral types, which constitute a subset of simple types.  
  
|Type|Range|Size|  
|----------|-----------|----------|  
|[sbyte](sbyte.md)|-128 to 127|Signed 8-bit integer|  
|[byte](byte.md)|0 to 255|Unsigned 8-bit integer|  
|[char](char.md)|U+0000 to U+ffff|Unicode 16-bit character|  
|[short](short.md)|-32,768 to 32,767|Signed 16-bit integer|  
|[ushort](ushort.md)|0 to 65,535|Unsigned 16-bit integer|  
|[int](int.md)|-2,147,483,648 to 2,147,483,647|Signed 32-bit integer|  
|[uint](uint.md)|0 to 4,294,967,295|Unsigned 32-bit integer|  
|[long](long.md)|-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807|Signed 64-bit integer|  
|[ulong](ulong.md)|0 to 18,446,744,073,709,551,615|Unsigned 64-bit integer|  

## Remarks
  
If the value represented by an integer literal exceeds <xref:System.UInt64.MaxValue?displayProperty=nameWithType>, a compiler error [CS1021](../../misc/cs1021.md) occurs.

Use the <xref:System.Numerics.BigInteger?displayProperty=nameWithType> structure to represent an arbitrarily large signed integer.
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Reference tables for types](reference-tables-for-types.md)
- [Floating-point types table](floating-point-types-table.md)
- [Default values table](default-values-table.md)
- [Formatting numeric results table](formatting-numeric-results-table.md)
- [Built-in types table](built-in-types-table.md)
- [Numerics in .NET](../../../standard/numerics.md)
