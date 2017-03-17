---
title: "Indexers (C# Programming Guide) | Microsoft Docs"

ms.date: "2017-03-10"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "cs.indexers"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "indexers [C#]"
  - "C# language, indexers"
ms.assetid: 022cd27d-d5e0-4cfe-8b97-dc018cc3355d
caps.latest.revision: 29
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
# Indexers (C# Programming Guide)

Indexers allow instances of a class or struct to be indexed just like arrays. The indexed value can be set or retrieved without explicitly specifying a type or instance member. Indexers resemble [properties](../../../csharp/programming-guide/classes-and-structs/properties.md) except that their accessors take parameters.  
 
 The following example defines a generic class with simple [get](../../../csharp/language-reference/keywords/get.md) and [set](../../../csharp/language-reference/keywords/set.md) accessor methods to assign and retrieve values. The `Program` class creates an instance of this class for storing strings.  
  
 [!code-cs[indexers#1](../../../../samples/snippets/csharp/programming-guide/indexers/indexer-1.cs)]  
  
> [!NOTE]
>  For more examples, see [Related Sections](../../../csharp/programming-guide/indexers/index.md#BKMK_RelatedSections).  
  
## Expression Body Definitions  
 
It is common for an indexer's get or set accessor to consist of a single statement that either returns or sets a value. Expression-bodied members provide a simplified syntax to support this scenario. Starting with C# 6, a read-only indexer can be implemented as an expression-bodied member, as the following example shows.

[!code-cs[indexers#2](../../../../samples/snippets/csharp/programming-guide/indexers/indexer-2.cs)]  

Note that `=>` introduces the expression body, and that the `get` keyword is not used. 

Starting with C# 7, both the get and set accessor can be an implemented as expression-bodied members. In this case, both `get` and `set` keywords must be used. For example:

[!code-cs[indexers#3](../../../../samples/snippets/csharp/programming-guide/indexers/indexer-3.cs)]  
  
## Indexers Overview  
  
-   Indexers enable objects to be indexed in a similar manner to arrays.  
  
-   A `get` accessor returns a value. A `set` accessor assigns a value.  
  
-   The [this](../../../csharp/language-reference/keywords/this.md) keyword is used to define the indexer.  
  
-   The [value](../../../csharp/language-reference/keywords/value.md) keyword is used to define the value being assigned by the `set` indexer.  
  
-   Indexers do not have to be indexed by an integer value; it is up to you how to define the specific look-up mechanism.  
  
-   Indexers can be overloaded.  
  
-   Indexers can have more than one formal parameter, for example, when accessing a two-dimensional array.  
  
##  <a name="BKMK_RelatedSections"></a> Related Sections  
  
-   [Using Indexers](../../../csharp/programming-guide/indexers/using-indexers.md)  
  
-   [Indexers in Interfaces](../../../csharp/programming-guide/indexers/indexers-in-interfaces.md)  
  
-   [Comparison Between Properties and Indexers](../../../csharp/programming-guide/indexers/comparison-between-properties-and-indexers.md)  
  
-   [Restricting Accessor Accessibility](../../../csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)