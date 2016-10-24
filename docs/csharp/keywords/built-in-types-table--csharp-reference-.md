---
title: "Built-In Types Table (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "types [C#], built-in"
  - "built-in C# types"
ms.assetid: 54f901f2-bf2f-472c-ae8d-73e8ecfc57fe
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Built-In Types Table (C# Reference)
The following table shows the keywords for built-in C# types, which are aliases of predefined types in the <xref:System> namespace.  
  
|C# Type|.NET Framework Type|  
|--------------|-------------------------|  
|[bool](../keywords/bool--csharp-reference-.md)|`System.Boolean`|  
|[byte](../keywords/byte--csharp-reference-.md)|`System.Byte`|  
|[sbyte](../keywords/sbyte--csharp-reference-.md)|`System.SByte`|  
|[char](../keywords/char--csharp-reference-.md)|`System.Char`|  
|[decimal](../keywords/decimal--csharp-reference-.md)|`System.Decimal`|  
|[double](../keywords/double--csharp-reference-.md)|`System.Double`|  
|[float](../keywords/float--csharp-reference-.md)|`System.Single`|  
|[int](../keywords/int--csharp-reference-.md)|`System.Int32`|  
|[uint](../keywords/uint--csharp-reference-.md)|`System.UInt32`|  
|[long](../keywords/long--csharp-reference-.md)|`System.Int64`|  
|[ulong](../keywords/ulong--csharp-reference-.md)|`System.UInt64`|  
|[object](../keywords/object--csharp-reference-.md)|`System.Object`|  
|[short](../keywords/short--csharp-reference-.md)|`System.Int16`|  
|[ushort](../keywords/ushort--csharp-reference-.md)|`System.UInt16`|  
|[string](../keywords/string--csharp-reference-.md)|`System.String`|  
  
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
  
 You can also use the [typeof](../keywords/typeof--csharp-reference-.md) operator.  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Value Types](../keywords/value-types--csharp-reference-.md)   
 [Default Values Table](../keywords/default-values-table--csharp-reference-.md)   
 [Formatting Numeric Results Table](../keywords/formatting-numeric-results-table--csharp-reference-.md)   
 [dynamic](../keywords/dynamic--csharp-reference-.md)   
 [Reference Tables for Types](../keywords/reference-tables-for-types--csharp-reference-.md)