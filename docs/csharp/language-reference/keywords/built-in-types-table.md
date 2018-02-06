---
title: "Built-In Types Table (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "types [C#], built-in"
  - "built-in C# types"
ms.assetid: 54f901f2-bf2f-472c-ae8d-73e8ecfc57fe
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
---
# Built-In Types Table (C# Reference)
The following table shows the keywords for built-in C# types, which are aliases of predefined types in the <xref:System> namespace.  
  
|C# Type|.NET Framework Type|  
|--------------|-------------------------|  
|[bool](../../../csharp/language-reference/keywords/bool.md)|`System.Boolean`|  
|[byte](../../../csharp/language-reference/keywords/byte.md)|`System.Byte`|  
|[sbyte](../../../csharp/language-reference/keywords/sbyte.md)|`System.SByte`|  
|[char](../../../csharp/language-reference/keywords/char.md)|`System.Char`|  
|[decimal](../../../csharp/language-reference/keywords/decimal.md)|`System.Decimal`|  
|[double](../../../csharp/language-reference/keywords/double.md)|`System.Double`|  
|[float](../../../csharp/language-reference/keywords/float.md)|`System.Single`|  
|[int](../../../csharp/language-reference/keywords/int.md)|`System.Int32`|  
|[uint](../../../csharp/language-reference/keywords/uint.md)|`System.UInt32`|  
|[long](../../../csharp/language-reference/keywords/long.md)|`System.Int64`|  
|[ulong](../../../csharp/language-reference/keywords/ulong.md)|`System.UInt64`|  
|[object](../../../csharp/language-reference/keywords/object.md)|`System.Object`|  
|[short](../../../csharp/language-reference/keywords/short.md)|`System.Int16`|  
|[ushort](../../../csharp/language-reference/keywords/ushort.md)|`System.UInt16`|  
|[string](../../../csharp/language-reference/keywords/string.md)|`System.String`|  
  
## Remarks  
 All of the types in the table, except `object` and `string`, are referred to as simple types.  
  
 The C# type keywords and their aliases are interchangeable. For example, you can declare an integer variable by using either of the following declarations:  
  
```  
int x = 123;  
System.Int32 x = 123;  
```  
  
 To display the actual type for any C# type, use the system method `GetType()`. For example, the following statement displays the system alias that represents the type of `myVariable`:  
  
```  
Console.WriteLine(myVariable.GetType());  
```  
  
 You can also use the [typeof](../../../csharp/language-reference/keywords/typeof.md) operator.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Value Types](../../../csharp/language-reference/keywords/value-types.md)  
 [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md)  
 [Formatting Numeric Results Table](../../../csharp/language-reference/keywords/formatting-numeric-results-table.md)  
 [dynamic](../../../csharp/language-reference/keywords/dynamic.md)  
 [Reference Tables for Types](../../../csharp/language-reference/keywords/reference-tables-for-types.md)
