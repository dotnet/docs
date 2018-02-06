---
title: "uint (C# Reference)"
ms.date: 03/14/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "uint"
  - "uint_CSharpKeyword"
helpviewer_keywords: 
  - "uint keyword [C#]"
ms.assetid: e93e42c6-ec72-4b0b-89df-2fd8d36f7a7b
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# uint (C# Reference)

The `uint` keyword signifies an integral type that stores values according to the size and range shown in the following table.  
  
|Type|Range|Size|.NET Framework type|  
|----------|-----------|----------|-------------------------|  
|`uint`|0 to 4,294,967,295|Unsigned 32-bit integer|<xref:System.UInt32?displayProperty=nameWithType>|  
  
 **Note** The `uint` type is not CLS-compliant. Use `int` whenever possible.  
  
## Literals  

You can declare and initialize a `uint` variable by assigning a decimal literal, a hexadecimal literal, or (starting with C# 7) a binary literal to it. If the integer literal is outside the range of `uint` (that is, if it is less than <xref:System.UInt32.MinValue?displayProperty=nameWithType> or greater than <xref:System.UInt32.MaxValue?displayProperty=nameWithType>), a compilation error occurs.

In the following example, integers equal to 3,000,000,000 that are represented as decimal, hexadecimal, and binary literals are assigned to `uint` values.  
  
[!code-csharp[uint](../../../../samples/snippets/csharp/language-reference/keywords/numeric-literals.cs#UInt)]  

> [!NOTE] 
> You use the prefix `0x` or `0X` to denote a hexadecimal literal and the prefix `0b` or `0B` to denote a binary literal. Decimal literals have no prefix. 

Starting with C# 7, a couple of features have been added to enhance readability. 
 - C# 7.0 allows the usage of the underscore character, `_`, as a digit separator.
 - C# 7.2 allows `_` to be used as a digit separator for a binary or hexadecimal literal, after the prefix. A decimal literal isn't permitted to have a leading underscore.

Some examples are shown below.

[!code-csharp[uint](../../../../samples/snippets/csharp/language-reference/keywords/numeric-literals.cs#UIntS)]  
 
 Integer literals can also include a suffix that denotes the type. The suffix `U` or 'u' denotes either a `uint` or a `ulong`, depending on the numeric value of the literal. The following example uses the `u` suffix to denote an unsigned integer of both types. Note that the first literal is a `uint` because its value is less than <xref:System.UInt32.MaxValue?displayProperty=nameWithType>, while the second is a `ulong` because its value is greater than <xref:System.UInt32.MaxValue?displayProperty=nameWithType>.

[!code-csharp[usuffix](../../../../samples/snippets/csharp/language-reference/keywords/numeric-suffixes.cs#1)]  
 
If an integer literal has no suffix, its type is the first of the following types in which its value can be represented: 

1. [int](int.md)
2. `uint`
3. [long](../../../csharp/language-reference/keywords/long.md)
4. [ulong](../../../csharp/language-reference/keywords/ulong.md) 
  
## Conversions  
 There is a predefined implicit conversion from `uint` to [long](../../../csharp/language-reference/keywords/long.md), [ulong](../../../csharp/language-reference/keywords/ulong.md), [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), or [decimal](../../../csharp/language-reference/keywords/decimal.md). For example:  
  
```csharp  
float myFloat = 4294967290;   // OK: implicit conversion to float  
```  
  
 There is a predefined implicit conversion from [byte](../../../csharp/language-reference/keywords/byte.md), [ushort](../../../csharp/language-reference/keywords/ushort.md), or [char](../../../csharp/language-reference/keywords/char.md) to `uint`. Otherwise you must use a cast. For example, the following assignment statement will produce a compilation error without a cast:  
  
```csharp  
long aLong = 22;  
// Error -- no implicit conversion from long:  
uint uInt1 = aLong;   
// OK -- explicit conversion:  
uint uInt2 = (uint)aLong;  
```  
  
 Notice also that there is no implicit conversion from floating-point types to `uint`. For example, the following statement generates a compiler error unless an explicit cast is used:  
  
```csharp  
// Error -- no implicit conversion from double:  
uint x = 3.0;  
// OK -- explicit conversion:  
uint y = (uint)3.0;   
```  
  
 For information about arithmetic expressions with mixed floating-point types and integral types, see [float](../../../csharp/language-reference/keywords/float.md) and [double](../../../csharp/language-reference/keywords/double.md).  
  
 For more information about implicit numeric conversion rules, see the [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.UInt32>  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)  
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)
