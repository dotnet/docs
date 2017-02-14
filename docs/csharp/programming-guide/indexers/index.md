---
title: "Indexers (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
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
Indexers allow instances of a class or struct to be indexed just like arrays. Indexers resemble [properties](../../../csharp/programming-guide/classes-and-structs/properties.md) except that their accessors take parameters.  
  
 In the following example, a generic class is defined and provided with simple [get](../../../csharp/language-reference/keywords/get.md) and [set](../../../csharp/language-reference/keywords/set.md) accessor methods as a means of assigning and retrieving values. The `Program` class creates an instance of this class for storing strings.  
  
 [!code-cs[csProgGuideIndexers#9](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/index_1.cs)]  
  
> [!NOTE]
>  For more examples, see [Related Sections](../../../csharp/programming-guide/indexers/index.md#BKMK_RelatedSections).  
  
## Expression Body Definitions  
 It is common to have indexers that simply return immediately with the result of an expression.  There is a syntax shortcut for defining these indexers using `=>`:  
  
```cs  
public Customer this[long id] => store.LookupCustomer(id);  
```  
  
 The indexer must be read only, and you do not use the `get` accessor keyword.  
  
## Indexers Overview  
  
-   Indexers enable objects to be indexed in a similar manner to arrays.  
  
-   A `get` accessor returns a value. A `set` accessor assigns a value.  
  
-   The [this](../../../csharp/language-reference/keywords/this.md) keyword is used to define the indexers.  
  
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