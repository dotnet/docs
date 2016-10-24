---
title: "sizeof (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "sizeof_CSharpKeyword"
  - "sizeof"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "sizeof keyword [C#]"
ms.assetid: c548592c-677c-4f40-a4ce-e613f7529141
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
# sizeof (C# Reference)
Used to obtain the size in bytes for an unmanaged type. Unmanaged types include the built-in types that are listed in the table that follows, and also the following:  
  
-   Enum types  
  
-   Pointer types  
  
-   User-defined structs that do not contain any fields or properties that are reference types  
  
 The following example shows how to retrieve the size of an `int`:  
  
```c#  
// Constant value 4:  
int intSize = sizeof(int);   
```  
  
## Remarks  
 Starting with version 2.0 of C#, applying `sizeof` to built-in types no longer requires that [unsafe](../keywords/unsafe--csharp-reference-.md) mode be used.  
  
 The `sizeof` operator cannot be overloaded. The values returned by the `sizeof` operator are of type `int`. The following table shows the constant values that are substituted for `sizeof` expressions that have certain built-in types as operands.  
  
|Expression|Constant value|  
|----------------|--------------------|  
|`sizeof(sbyte)`|1|  
|`sizeof(byte)`|1|  
|`sizeof(short)`|2|  
|`sizeof(ushort)`|2|  
|`sizeof(int)`|4|  
|`sizeof(uint)`|4|  
|`sizeof(long)`|8|  
|`sizeof(ulong)`|8|  
|`sizeof(char)`|2 (Unicode)|  
|`sizeof(float)`|4|  
|`sizeof(double)`|8|  
|`sizeof(decimal)`|16|  
|`sizeof(bool)`|1|  
  
 For all other types, including structs, the `sizeof` operator can be used only in unsafe code blocks. Although you can use the <xref:System.Runtime.InteropServices.Marshal.SizeOf*?displayProperty=fullName> method, the value returned by this method is not always the same as the value returned by `sizeof`. <xref:System.Runtime.InteropServices.Marshal.SizeOf*?displayProperty=fullName> returns the size after the type has been marshaled, whereas `sizeof` returns the size as it has been allocated by the common language runtime, including any padding.  
  
## Example  
 [!code[csrefKeywordsOperator#11](../keywords/codesnippet/CSharp/sizeof--csharp-reference-_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Operator Keywords](../keywords/operator-keywords--csharp-reference-.md)   
 [enum](../keywords/enum--csharp-reference-.md)   
 [Unsafe Code and Pointers](../unsafe-code-pointers/unsafe-code-and-pointers--csharp-programming-guide-.md)   
 [Structs](../classes-and-structs/structs--csharp-programming-guide-.md)   
 [Constants](../classes-and-structs/constants--csharp-programming-guide-.md)