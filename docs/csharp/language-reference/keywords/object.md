---
title: "object (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "object_CSharpKeyword"
  - "object"
helpviewer_keywords: 
  - "object keyword [C#]"
ms.assetid: 93f60c0b-e17a-40a9-9362-cca5fb77b0e7
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# object (C# Reference)
The `object` type is an alias for <xref:System.Object> in the .NET Framework. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from <xref:System.Object>. You can assign values of any type to variables of type `object`. When a variable of a value type is converted to object, it is said to be *boxed*. When a variable of type object is converted to a value type, it is said to be *unboxed*. For more information, see [Boxing and Unboxing](../../../csharp/programming-guide/types/boxing-and-unboxing.md).  
  
## Example  
 The following sample shows how variables of type `object` can accept values of any data type and how variables of type `object` can use methods on <xref:System.Object> from the .NET Framework.  
  
 [!code-csharp[csrefKeywordsTypes#16](../../../csharp/language-reference/keywords/codesnippet/CSharp/object_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Reference Types](../../../csharp/language-reference/keywords/reference-types.md)  
 [Value Types](../../../csharp/language-reference/keywords/value-types.md)
