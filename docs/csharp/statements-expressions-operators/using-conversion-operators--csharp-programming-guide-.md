---
title: "Using Conversion Operators (C# Programming Guide)"
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
  - "conversions [C#], operators"
  - "conversion operators [C#]"
  - "operators [C#], conversion"
  - "user-defined conversions [C#]"
  - "implicit conversion operators [C#]"
  - "explicit conversion operators [C#]"
ms.assetid: caf36e89-c6c0-4b87-9f9e-85780a45c9a4
caps.latest.revision: 20
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
# Using Conversion Operators (C# Programming Guide)
You can use `implicit` conversion operators, which are easier to use, or `explicit` conversion operators, which clearly indicate to anyone reading the code that you're converting a type. This topic demonstrates both types of conversion operator.  
  
> [!NOTE]
>  For information about simple type conversions, see [How to: Convert a String to a Number](../types/how-to--convert-a-string-to-a-number--csharp-programming-guide-.md), [How to: Convert a byte Array to an int](../types/how-to--convert-a-byte-array-to-an-int--csharp-programming-guide-.md), [How to: Convert Between Hexadecimal Strings and Numeric Types](../types/7115c49f-7d1d-40c3-8bd9-aae0cc1d46b6.md), or <xref:System.Convert>.  
  
## Example  
 This is an example of an explicit conversion operator. This operator converts from the type <xref:System.Byte> to a value type called `Digit`. Because not all bytes can be converted to a digit, the conversion is explicit, meaning that a cast must be used, as shown in the `Main` method.  
  
 [!code[csProgGuideStatements#11](../classes-and-structs/codesnippet/CSharp/using-conversion-operators--csharp-programming-guide-_1.cs)]  
  
## Example  
 This example demonstrates an implicit conversion operator by defining a conversion operator that undoes what the previous example did: it converts from a value class called `Digit` to the integral <xref:System.Byte> type. Because any digit can be converted to a <xref:System.Byte>, there's no need to force users to be explicit about the conversion.  
  
 [!code[csProgGuideStatements#12](../classes-and-structs/codesnippet/CSharp/using-conversion-operators--csharp-programming-guide-_2.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Conversion Operators](../statements-expressions-operators/conversion-operators--csharp-programming-guide-.md)   
 [is](../keywords/is--csharp-reference-.md)