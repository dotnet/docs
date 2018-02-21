---
title: "decimal (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "decimal_CSharpKeyword"
  - "decimal"
helpviewer_keywords: 
  - "decimal keyword [C#]"
ms.assetid: b6522132-b5ee-4be3-ad13-3adfdb7de7a1
caps.latest.revision: 32
author: "BillWagner"
ms.author: "wiwagn"
---
# decimal (C# Reference)
The `decimal` keyword indicates a 128-bit data type. Compared to other floating-point types, the `decimal` type has more precision and a smaller range, which makes it appropriate for financial and monetary calculations. The approximate range and precision for the `decimal` type are shown in the following table.  
  
|Type|Approximate Range|Precision|.NET Framework type|  
|----------|-----------------------|---------------|-------------------------|  
|`decimal`|(-7.9 x 10<sup>28</sup> to 7.9 x 10<sup>28</sup>) / (10<sup>0</sup> to 10<sup>28</sup>)|28-29 significant digits|<xref:System.Decimal?displayProperty=nameWithType>|  

The default value of a `decimal` is 0m.
  
## Literals  
 If you want a numeric real literal to be treated as `decimal`, use the suffix m or M, for example:  
  
```csharp
decimal myMoney = 300.5m;  
```  
  
 Without the suffix m, the number is treated as a [double](../../../csharp/language-reference/keywords/double.md) and generates a compiler error.  
  
## Conversions  
 The integral types are implicitly converted to `decimal` and the result evaluates to `decimal`. Therefore you can initialize a decimal variable using an integer literal, without the suffix, as follows:  
  
```csharp
decimal myMoney = 300;  
```  
  
 There is no implicit conversion between other floating-point types and the `decimal` type; therefore, a cast must be used to convert between these two types. For example:  
  
```csharp
decimal myMoney = 99.9m;  
double x = (double)myMoney;  
myMoney = (decimal)x;  
```  
  
 You can also mix `decimal` and numeric integral types in the same expression. However, mixing `decimal` and other floating-point types without a cast causes a compilation error.  
  
 For more information about implicit numeric conversions, see [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md).  
  
 For more information about explicit numeric conversions, see [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md).  
  
## Formatting Decimal Output  
 You can format the results by using the `String.Format` method, or through the <xref:System.Console.Write%2A?displayProperty=nameWithType> method, which calls `String.Format()`. The currency format is specified by using the standard currency format string "C" or "c," as shown in the second example later in this article. For more information about the `String.Format` method, see <xref:System.String.Format%2A?displayProperty=nameWithType>.  
  
## Example  
 The following example causes a compiler error by trying to add [double](../../../csharp/language-reference/keywords/double.md) and `decimal` variables.  
  
```csharp  
decimal dec = 0m;
double dub = 9;  
// The following line causes an error that reads "Operator '+' cannot be applied to   
// operands of type 'double' and 'decimal'"  
Console.WriteLine(dec + dub);   
  
// You can fix the error by using explicit casting of either operand.  
Console.WriteLine(dec + (decimal)dub);  
Console.WriteLine((double)dec + dub);  
```  
  
 The result is the following error:  
  
 `Operator '+' cannot be applied to operands of type 'double' and 'decimal'`  
  
 In this example, a `decimal` and an [int](../../../csharp/language-reference/keywords/int.md) are mixed in the same expression. The result evaluates to the `decimal` type.  
  
 [!code-csharp[csrefKeywordsTypes#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/decimal_1.cs)]  
  
## Example  
 In this example, the output is formatted by using the currency format string. Notice that `x` is rounded because the decimal places exceed $0.99. The variable `y`, which represents the maximum exact digits, is displayed exactly in the correct format.  
  
 [!code-csharp[csrefKeywordsTypes#7](../../../csharp/language-reference/keywords/codesnippet/CSharp/decimal_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Decimal>  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)  
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)  
 [Standard Numeric Format Strings](../../../standard/base-types/standard-numeric-format-strings.md)
