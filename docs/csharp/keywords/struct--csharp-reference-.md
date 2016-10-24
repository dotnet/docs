---
title: "struct (C# Reference)"
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
  - "struct_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "struct keyword [C#]"
  - "structs [C#], struct keyword"
ms.assetid: ff3dd9b7-dc93-4720-8855-ef5558f65c7c
caps.latest.revision: 23
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
# struct (C# Reference)
A `struct` type is a value type that is typically used to encapsulate small groups of related variables, such as the coordinates of a rectangle or the characteristics of an item in an inventory. The following example shows a simple struct declaration:  
  
```  
public struct Book  
{  
    public decimal price;  
    public string title;  
    public string author;  
}  
```  
  
## Remarks  
 Structs can also contain [constructors](../classes-and-structs/constructors--csharp-programming-guide-.md), [constants](../classes-and-structs/constants--csharp-programming-guide-.md), [fields](../classes-and-structs/fields--csharp-programming-guide-.md), [methods](../classes-and-structs/methods--csharp-programming-guide-.md), [properties](../classes-and-structs/properties--csharp-programming-guide-.md), [indexers](../indexers/indexers--csharp-programming-guide-.md), [operators](../statements-expressions-operators/operators--csharp-programming-guide-.md), [events](../events/events--csharp-programming-guide-.md), and [nested types](../classes-and-structs/nested-types--csharp-programming-guide-.md), although if several such members are required, you should consider making your type a class instead.  
  
 For examples, see [Using Structs](../classes-and-structs/using-structs--csharp-programming-guide-.md).  
  
 Structs can implement an interface but they cannot inherit from another struct. For that reason, struct members cannot be declared as `protected`.  
  
 For more information, see [Structs](../classes-and-structs/structs--csharp-programming-guide-.md).  
  
## Examples  
 For examples and more information, see [Using Structs](../classes-and-structs/using-structs--csharp-programming-guide-.md).  
  
## C# Language Specification  
 For examples, see [Using Structs](../classes-and-structs/using-structs--csharp-programming-guide-.md).  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Default Values Table](../keywords/default-values-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [Value Types](../keywords/value-types--csharp-reference-.md)   
 [class](../keywords/class--csharp-reference-.md)   
 [interface](../keywords/interface--csharp-reference-.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)