---
title: "Value types table - C# Reference"
ms.custom: seodec18

ms.date: 08/24/2018
helpviewer_keywords: 
  - "value types [C#], table"
  - "types [C#], value types"
  - "types [C#], suffixes"
ms.assetid: 67d8f631-b6e3-4d83-9910-5ec497f8c5f3
---
# Value types table (C# Reference)

The following table shows the C# value types:

|Value type|Category|Type suffix|
|----------------|--------------|-----------------|
|[bool](bool.md)|Boolean||
|[byte](byte.md)|Unsigned, numeric, [integral](integral-types-table.md)||
|[char](char.md)|Unsigned, numeric, [integral](integral-types-table.md)||
|[decimal](decimal.md)|Numeric, [floating-point](floating-point-types-table.md)|M or m|
|[double](double.md)|Numeric, [floating-point](floating-point-types-table.md)|D or d|
|[enum](enum.md)|Enumeration||
|[float](float.md)|Numeric, [floating-point](floating-point-types-table.md)|F or f|
|[int](int.md)|Signed, numeric, [integral](integral-types-table.md)||
|[long](long.md)|Signed, numeric, [integral](integral-types-table.md)|L or l|
|[sbyte](sbyte.md)|Signed, numeric, [integral](integral-types-table.md)||
|[short](short.md)|Signed, numeric, [integral](integral-types-table.md)||
|[struct](struct.md)|User-defined structure||
|[uint](uint.md)|Unsigned, numeric, [integral](integral-types-table.md)|U or u|
|[ulong](ulong.md)|Unsigned, numeric, [integral](integral-types-table.md)|UL, Ul, uL, ul, LU, Lu, lU, or lu|
|[ushort](ushort.md)|Unsigned, numeric, [integral](integral-types-table.md)||

## Remarks

You use a type suffix to specify a type of a numerical literal. For example:

```csharp
decimal a = 0.1M;
```

If an [integer numerical literal](~/_csharplang/spec/lexical-structure.md#integer-literals) has no suffix, it has the first of the following types in which its value can be represented: `int`, `uint`, `long`, `ulong`.

If a [real numerical literal](~/_csharplang/spec/lexical-structure.md#real-literals) has no suffix, it's of type `double`.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Reference tables for types](reference-tables-for-types.md)
- [Default values table](default-values-table.md)
- [Value types](value-types.md)
- [Formatting numeric results table](formatting-numeric-results-table.md)