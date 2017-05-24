---
title: "set (C# Reference) | Microsoft Docs"
ms.date: "2017-03-10"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "set"
  - "set_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "set keyword [C#]"
ms.assetid: 30d7e4e5-cc2e-4635-a597-14a724879619
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
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
# set (C# Reference)
The `set` keyword defines an *accessor* method in a property or indexer that assigns a value to the property or the indexer element. For more information and examples, see [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md), [Auto-Implemented Properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md), and [Indexers](../../../csharp/programming-guide/indexers/index.md).  
  
The following example defines both a `get` and a `set` accessor for a property named `Seconds`. It uses a private field named `_seconds` to back the property value.  
 
 [!code-cs[set#1](../../../../samples/snippets/csharp/language-reference/keywords/get/get-1.cs)]  

Often, the `set` accessor consists of a single statement that returns a value, as it did in the previous example. Starting with C# 7, you can implement the `set` accessor as an expression-bodied member. The following example implements both the `get` and the `set` accessors as expression-bodied members.

 [!code-cs[set#3](../../../../samples/snippets/csharp/language-reference/keywords/get/get-3.cs)]   
    
For simple cases in which a property's `get` and `set` accessors perform no other operation than setting or retrieving a value in a private backing field, you can take advantage of the C# compiler's support for auto-implemented properties. The following example implements `Hours` as an auto-implemented property. 
  
 [!code-cs[set#2](../../../../samples/snippets/csharp/language-reference/keywords/get/get-2.cs)]  
    
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)