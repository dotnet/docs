---
title: "Built-in types table - C# Reference"
ms.custom: seodec18

description: "Keywords for built-in C# types"
ms.date: 08/17/2018
helpviewer_keywords: 
  - "types [C#], built-in"
  - "built-in C# types"
ms.assetid: 54f901f2-bf2f-472c-ae8d-73e8ecfc57fe
---
# Built-in types table (C# Reference)

The following table shows the keywords for built-in C# types, which are aliases of predefined types in the <xref:System> namespace:

|C# type|.NET type|  
|--------------|-------------------------|  
|[bool](bool.md)|<xref:System.Boolean?displayProperty=nameWithType>|  
|[byte](../builtin-types/integral-numeric-types.md)|<xref:System.Byte?displayProperty=nameWithType>|  
|[sbyte](../builtin-types/integral-numeric-types.md)|<xref:System.SByte?displayProperty=nameWithType>|  
|[char](char.md)|<xref:System.Char?displayProperty=nameWithType>|  
|[decimal](../builtin-types/floating-point-numeric-types.md)|<xref:System.Decimal?displayProperty=nameWithType>|  
|[double](../builtin-types/floating-point-numeric-types.md)|<xref:System.Double?displayProperty=nameWithType>|  
|[float](../builtin-types/floating-point-numeric-types.md)|<xref:System.Single?displayProperty=nameWithType>|  
|[int](../builtin-types/integral-numeric-types.md)|<xref:System.Int32?displayProperty=nameWithType>|  
|[uint](../builtin-types/integral-numeric-types.md)|<xref:System.UInt32?displayProperty=nameWithType>|  
|[long](../builtin-types/integral-numeric-types.md)|<xref:System.Int64?displayProperty=nameWithType>|  
|[ulong](../builtin-types/integral-numeric-types.md)|<xref:System.UInt64?displayProperty=nameWithType>|  
|[object](object.md)|<xref:System.Object?displayProperty=nameWithType>|  
|[short](../builtin-types/integral-numeric-types.md)|<xref:System.Int16?displayProperty=nameWithType>|  
|[ushort](../builtin-types/integral-numeric-types.md)|<xref:System.UInt16?displayProperty=nameWithType>|  
|[string](string.md)|<xref:System.String?displayProperty=nameWithType>|  
  
## Remarks

All of the types in the table, except `object` and `string`, are referred to as simple types.

The .NET types and their C# type keyword aliases are interchangeable. For example, you can declare an integer variable by using either of the following declarations:

```csharp
int x = 123;
System.Int32 y = 123;
```

Use the [typeof](../operators/type-testing-and-cast.md#typeof-operator) operator to get the <xref:System.Type?displayProperty=nameWithType> instance that represents the specified type:

```csharp
Type stringType = typeof(string);
Console.WriteLine(stringType.FullName);

Type doubleType = typeof(System.Double);
Console.WriteLine(doubleType.FullName);

// Output:
// System.String
// System.Double
```

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Value types](value-types.md)
- [Reference types](reference-types.md)
- [Default values table](default-values-table.md)
- [dynamic](dynamic.md)
