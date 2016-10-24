---
title: "interface (C# Reference)"
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
  - "interface_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "interface keyword [C#]"
ms.assetid: 7da38e81-4f99-4bc5-b07d-c986b687eeba
caps.latest.revision: 29
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
# interface (C# Reference)
An interface contains only the signatures of [methods](../classes-and-structs/methods--csharp-programming-guide-.md), [properties](../classes-and-structs/properties--csharp-programming-guide-.md), [events](../events/events--csharp-programming-guide-.md) or [indexers](../indexers/indexers--csharp-programming-guide-.md). A class or struct that implements the interface must implement the members of the interface that are specified in the interface definition. In the following example, class `ImplementationClass` must implement a method named `SampleMethod` that has no parameters and returns `void`.  
  
 For more information and examples, see [Interfaces](../interfaces/interfaces--csharp-programming-guide-.md).  
  
## Example  
 [!code[csrefKeywordsTypes#14](../keywords/codesnippet/CSharp/interface--csharp-reference-_1.cs)]  
  
 An interface can be a member of a namespace or a class and can contain signatures of the following members:  
  
-   [Methods](../classes-and-structs/methods--csharp-programming-guide-.md)  
  
-   [Properties](../classes-and-structs/using-properties--csharp-programming-guide-.md)  
  
-   [Indexers](../indexers/using-indexers--csharp-programming-guide-.md)  
  
-   [Events](../keywords/event--csharp-reference-.md)  
  
 An interface can inherit from one or more base interfaces.  
  
 When a base type list contains a base class and interfaces, the base class must come first in the list.  
  
 A class that implements an interface can explicitly implement members of that interface. An explicitly implemented member cannot be accessed through a class instance, but only through an instance of the interface.  
  
 For more details and code examples on explicit interface implementation, see [Explicit Interface Implementation](../interfaces/explicit-interface-implementation--csharp-programming-guide-.md).  
  
## Example  
 The following example demonstrates interface implementation. In this example, the interface contains the property declaration and the class contains the implementation. Any instance of a class that implements `IPoint` has integer properties `x` and `y`.  
  
 [!code[csrefKeywordsTypes#15](../keywords/codesnippet/CSharp/interface--csharp-reference-_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Reference Types](../keywords/reference-types--csharp-reference-.md)   
 [Interfaces](../interfaces/interfaces--csharp-programming-guide-.md)   
 [Using Properties](../classes-and-structs/using-properties--csharp-programming-guide-.md)   
 [Using Indexers](../indexers/using-indexers--csharp-programming-guide-.md)   
 [class](../keywords/class--csharp-reference-.md)   
 [struct](../keywords/struct--csharp-reference-.md)   
 [Interfaces](../interfaces/interfaces--csharp-programming-guide-.md)