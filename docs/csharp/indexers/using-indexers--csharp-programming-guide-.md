---
title: "Using Indexers (C# Programming Guide)"
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
  - "indexers [C#], about indexers"
ms.assetid: df70e1a2-3ce3-4aba-ad80-4b2f3538699f
caps.latest.revision: 30
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
# Using Indexers (C# Programming Guide)
Indexers are a syntactic convenience that enable you to create a [class](../keywords/class--csharp-reference-.md), [struct](../keywords/struct--csharp-reference-.md), or [interface](../keywords/interface--csharp-reference-.md) that client applications can access just as an array. Indexers are most frequently implemented in types whose primary purpose is to encapsulate an internal collection or array. For example, suppose you have a class named TempRecord that represents the temperature in Farenheit as recorded at 10 different times during a 24 hour period. The class contains an array named "temps" of type float to represent the temperatures, and a <xref:System.DateTime> that represents the date the temperatures were recorded. By implementing an indexer in this class, clients can access the temperatures in a TempRecord instance as `float temp = tr[4]` instead of as `float temp = tr.temps[4]`. The indexer notation not only simplifies the syntax for client applications; it also makes the class and its purpose more intuitive for other developers to understand.  
  
 To declare an indexer on a class or struct, use the [this](../keywords/this--csharp-reference-.md) keyword, as in this example:  
  
```  
public int this[int index]    // Indexer declaration  
{  
    // get and set accessors  
}  
  
```  
  
## Remarks  
 The type of an indexer and the type of its parameters must be at least as accessible as the indexer itself. For more information about accessibility levels, see [Access Modifiers](../keywords/access-modifiers--csharp-reference-.md).  
  
 For more information about how to use indexers with an interface, see [Interface Indexers](../indexers/indexers-in-interfaces--csharp-programming-guide-.md).  
  
 The signature of an indexer consists of the number and types of its formal parameters. It does not include the indexer type or the names of the formal parameters. If you declare more than one indexer in the same class, they must have different signatures.  
  
 An indexer value is not classified as a variable; therefore, you cannot pass an indexer value as a [ref](../keywords/ref--csharp-reference-.md) or [out](../keywords/out--csharp-reference-.md) parameter.  
  
 To provide the indexer with a name that other languages can use, use a `name` attribute in the declaration. For example:  
  
```  
[System.Runtime.CompilerServices.IndexerName("TheItem")]  
public int this [int index]   // Indexer declaration  
{  
}  
```  
  
 This indexer will have the name `TheItem`. Not providing the name attribute would make `Item` the default name.  
  
## Example 1  
  
### Description  
 The following example shows how to declare a private array field, `temps`, and an indexer. The indexer enables direct access to the instance `tempRecord[i]`. The alternative to using the indexer is to declare the array as a [public](../keywords/public--csharp-reference-.md) member and access its members, `tempRecord.temps[i]`, directly.  
  
 Notice that when an indexer's access is evaluated, for example, in a `Console.Write` statement, the [get](../keywords/get--csharp-reference-.md) accessor is invoked. Therefore, if no `get` accessor exists, a compile-time error occurs.  
  
### Code  
 [!code[csProgGuideIndexers#1](../classes-and-structs/codesnippet/CSharp/using-indexers--csharp-programming-guide-_1.cs)]  
  
## Indexing Using Other Values  
 C# does not limit the index type to integer. For example, it may be useful to use a string with an indexer. Such an indexer might be implemented by searching for the string in the collection, and returning the appropriate value. As accessors can be overloaded, the string and integer versions can co-exist.  
  
## Example 2  
  
### Description  
 In this example, a class is declared that stores the days of the week. A `get` accessor is declared that takes a string, the name of a day, and returns the corresponding integer. For example, Sunday will return 0, Monday will return 1, and so on.  
  
### Code  
 [!code[csProgGuideIndexers#2](../classes-and-structs/codesnippet/CSharp/using-indexers--csharp-programming-guide-_2.cs)]  
  
## Robust Programming  
 There are two main ways in which the security and reliability of indexers can be improved:  
  
-   Be sure to incorporate some type of error-handling strategy to handle the chance of client code passing in an invalid index value. In the first example earlier in this topic, the TempRecord class provides a Length property that enables the client code to verify the input before passing it to the indexer. You can also put the error handling code inside the indexer itself. Be sure to document for users any exceptions that you throw inside an indexer accessor.  
  
-   Set the accessibility of the `get` and [set](../keywords/set--csharp-reference-.md) accessors to be as restrictive as is reasonable. This is important for the `set` accessor in particular. For more information, see [Restricting Accessor Accessibility](../classes-and-structs/restricting-accessor-accessibility--csharp-programming-guide-.md).  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Indexers](../indexers/indexers--csharp-programming-guide-.md)   
 [Properties](../classes-and-structs/properties--csharp-programming-guide-.md)