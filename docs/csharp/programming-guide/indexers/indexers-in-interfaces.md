---
title: "Indexers in Interfaces (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "indexers [C#], in interfaces"
  - "accessors [C#], indexers"
ms.assetid: e16b54bd-4a83-4f52-bd75-65819fca79e8
caps.latest.revision: 18
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
# Indexers in Interfaces (C# Programming Guide)
Indexers can be declared on an [interface](../../../csharp/language-reference/keywords/interface.md). Accessors of interface indexers differ from the accessors of [class](../../../csharp/language-reference/keywords/class.md) indexers in the following ways:  
  
-   Interface accessors do not use modifiers.  
  
-   An interface accessor does not have a body.  
  
 Thus, the purpose of the accessor is to indicate whether the indexer is read-write, read-only, or write-only.  
  
 The following is an example of an interface indexer accessor:  
  
 [!code-cs[csProgGuideIndexers#3](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/indexers-in-interfaces_1.cs)]  
  
 The signature of an indexer must differ from the signatures of all other indexers declared in the same interface.  
  
## Example  
 The following example shows how to implement interface indexers.  
  
 [!code-cs[csProgGuideIndexers#4](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/indexers-in-interfaces_2.cs)]  
  
 In the preceding example, you could use the explicit interface member implementation by using the fully qualified name of the interface member. For example:  
  
```  
public string ISomeInterface.this   
{   
}   
```  
  
 However, the fully qualified name is only needed to avoid ambiguity when the class is implementing more than one interface with the same indexer signature. For example, if an `Employee` class is implementing two interfaces, `ICitizen` and `IEmployee`, and both interfaces have the same indexer signature, the explicit interface member implementation is necessary. That is, the following indexer declaration:  
  
```  
public string IEmployee.this   
{   
}   
```  
  
 implements the indexer on the `IEmployee` interface, while the following declaration:  
  
```  
public string ICitizen.this   
{   
}   
```  
  
 implements the indexer on the `ICitizen` interface.  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Indexers](../../../csharp/programming-guide/indexers/index.md)   
 [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)   
 [Interfaces](../../../csharp/programming-guide/interfaces/index.md)