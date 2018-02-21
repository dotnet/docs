---
title: "Using Conversion Operators (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
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
---
# Using Conversion Operators (C# Programming Guide)
You can use `implicit` conversion operators, which are easier to use, or `explicit` conversion operators, which clearly indicate to anyone reading the code that you're converting a type. This topic demonstrates both types of conversion operator.  
  
> [!NOTE]
>  For information about simple type conversions, see [How to: Convert a String to a Number](../../../csharp/programming-guide/types/how-to-convert-a-string-to-a-number.md), [How to: Convert a byte Array to an int](../../../csharp/programming-guide/types/how-to-convert-a-byte-array-to-an-int.md), [How to: Convert Between Hexadecimal Strings and Numeric Types](../../../csharp/programming-guide/types/how-to-convert-between-hexadecimal-strings-and-numeric-types.md), or <xref:System.Convert>.  
  
## Example  
 This is an example of an explicit conversion operator. This operator converts from the type <xref:System.Byte> to a value type called `Digit`. Because not all bytes can be converted to a digit, the conversion is explicit, meaning that a cast must be used, as shown in the `Main` method.  
  
 [!code-csharp[csProgGuideStatements#11](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-conversion-operators_1.cs)]  
  
## Example  
 This example demonstrates an implicit conversion operator by defining a conversion operator that undoes what the previous example did: it converts from a value class called `Digit` to the integral <xref:System.Byte> type. Because any digit can be converted to a <xref:System.Byte>, there's no need to force users to be explicit about the conversion.  
  
 [!code-csharp[csProgGuideStatements#12](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-conversion-operators_2.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Conversion Operators](../../../csharp/programming-guide/statements-expressions-operators/conversion-operators.md)  
 [is](../../../csharp/language-reference/keywords/is.md)
