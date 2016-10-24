---
title: "class (C# Reference)"
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
  - "class_CSharpKeyword"
  - "class"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "class keyword [C#]"
ms.assetid: b95d8815-de18-4c3f-a8cc-a0a53bdf8690
caps.latest.revision: 30
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# class (C# Reference)
Classes are declared using the keyword `class`, as shown in the following example:  
  
```  
  
      class TestClass  
{  
    // Methods, properties, fields, events, delegates   
    // and nested classes go here.  
}  
```  
  
## Remarks  
 Only single inheritance is allowed in C#. In other words, a class can inherit implementation from one base class only. However, a class can implement more than one interface. The following table shows examples of class inheritance and interface implementation:  
  
|Inheritance|Example|  
|-----------------|-------------|  
|None|`class ClassA { }`|  
|Single|`class DerivedClass: BaseClass { }`|  
|None, implements two interfaces|`class ImplClass: IFace1, IFace2 { }`|  
|Single, implements one interface|`class ImplDerivedClass: BaseClass, IFace1 { }`|  
  
 Classes that you declare directly within a namespace, not nested within other classes, can be either [public](../keywords/public--csharp-reference-.md) or [internal](../keywords/internal--csharp-reference-.md). Classes are `internal` by default.  
  
 Class members, including nested classes, can be [public](../keywords/public--csharp-reference-.md), `protected internal`, [protected](../keywords/protected--csharp-reference-.md), [internal](../keywords/internal--csharp-reference-.md), or [private](../keywords/private--csharp-reference-.md). Members are [private](../keywords/private--csharp-reference-.md) by default.  
  
 For more information, see [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md).  
  
 You can declare generic classes that have type parameters. For more information, see [Generic Classes](../generics/generic-classes--csharp-programming-guide-.md).  
  
 A class can contain declarations of the following members:  
  
-   [Constructors](../classes-and-structs/constructors--csharp-programming-guide-.md)  
  
-   [Destructors](../classes-and-structs/destructors--csharp-programming-guide-.md)  
  
-   [Constants](../classes-and-structs/constants--csharp-programming-guide-.md)  
  
-   [Fields](../classes-and-structs/fields--csharp-programming-guide-.md)  
  
-   [Methods](../classes-and-structs/methods--csharp-programming-guide-.md)  
  
-   [Properties](../classes-and-structs/properties--csharp-programming-guide-.md)  
  
-   [Indexers](../indexers/indexers--csharp-programming-guide-.md)  
  
-   [Operators](../statements-expressions-operators/operators--csharp-programming-guide-.md)  
  
-   [Events](../events/events--csharp-programming-guide-.md)  
  
-   [Delegates](../delegates/delegates--csharp-programming-guide-.md)  
  
-   [Classes](../classes-and-structs/classes--csharp-programming-guide-.md)  
  
-   [Interfaces](../interfaces/interfaces--csharp-programming-guide-.md)  
  
-   [Structs](../classes-and-structs/structs--csharp-programming-guide-.md)  
  
## Example  
 The following example demonstrates declaring class fields, constructors, and methods. It also demonstrates object instantiation and printing instance data. In this example, two classes are declared, the `Child` class, which contains two private fields (`name` and `age`) and two public methods. The second class, `StringTest`, is used to contain `Main`.  
  
 [!code[csrefKeywordsTypes#5](../keywords/codesnippet/CSharp/class--csharp-reference-_1.cs)]  
  
## Comments  
 Notice, in the preceding example, that the private fields (`name` and `age`) can only be accessed through the public methods of the `Child` class. For example, you cannot print the child's name, from the `Main` method, using a statement like this:  
  
```  
Console.Write(child1.name);   // Error  
```  
  
 Accessing private members of `Child` from `Main` would only be possible if `Main` were a member of the class.  
  
 Types declared inside a class without an access modifier default to `private`, so the data members in this example would still be `private` if the keyword were removed.  
  
 Finally, notice that for the object created using the default constructor (`child3`), the age field was initialized to zero by default.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Reference Types](../keywords/reference-types--csharp-reference-.md)