---
title: "Fields (C# Programming Guide)"
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
  - "fields [C#]"
ms.assetid: 3cbb2f61-75f8-4cce-b4ef-f5d1b3de0db7
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
# Fields (C# Programming Guide)
A *field* is a variable of any type that is declared directly in a [class](../keywords/class--csharp-reference-.md) or [struct](../keywords/struct--csharp-reference-.md). Fields are *members* of their containing type.  
  
 A class or struct may have instance fields or static fields or both. Instance fields are specific to an instance of a type. If you have a class T, with an instance field F, you can create two objects of type T, and modify the value of F in each object without affecting the value in the other object. By contrast, a static field belongs to the class itself, and is shared among all instances of that class. Changes made from instance A will be visibly immediately to instances B and C if they access the field.  
  
 Generally, you should use fields only for variables that have private or protected accessibility. Data that your class exposes to client code should be provided through [methods](../classes-and-structs/methods--csharp-programming-guide-.md), [properties](../classes-and-structs/properties--csharp-programming-guide-.md) and [indexers](../indexers/indexers--csharp-programming-guide-.md). By using these constructs for indirect access to internal fields, you can guard against invalid input values. A private field that stores the data exposed by a public property is called a *backing store* or *backing field*.  
  
 Fields typically store the data that must be accessible to more than one class method and must be stored for longer than the lifetime of any single method. For example, a class that represents a calendar date might have three integer fields: one for the month, one for the day, and one for the year. Variables that are not used outside the scope of a single method should be declared as *local variables* within the method body itself.  
  
 Fields are declared in the class block by specifying the access level of the field, followed by the type of the field, followed by the name of the field. For example:  
  
 [!code[csProgGuideObjects#61](../classes-and-structs/codesnippet/CSharp/fields--csharp-programming-guide-_1.cs)]  
  
 To access a field in an object, add a period after the object name, followed by the name of the field, as in `objectname.fieldname`. For example:  
  
 [!code[csProgGuideObjects#62](../classes-and-structs/codesnippet/CSharp/fields--csharp-programming-guide-_2.cs)]  
  
 A field can be given an initial value by using the assignment operator when the field is declared. To automatically assign the `day` field to `"Monday"`, for example, you would declare `day` as in the following example:  
  
 [!code[csProgGuideObjects#63](../classes-and-structs/codesnippet/CSharp/fields--csharp-programming-guide-_3.cs)]  
  
 Fields are initialized immediately before the constructor for the object instance is called. If the constructor assigns the value of a field, it will overwrite any value given during field declaration. For more information, see [Using Constructors](../classes-and-structs/using-constructors--csharp-programming-guide-.md).  
  
> [!NOTE]
>  A field initializer cannot refer to other instance fields.  
  
 Fields can be marked as [public](../keywords/public--csharp-reference-.md), [private](../keywords/private--csharp-reference-.md), [protected](../keywords/protected--csharp-reference-.md), [internal](../keywords/internal--csharp-reference-.md), or `protected internal`. These access modifiers define how users of the class can access the fields. For more information, see [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md).  
  
 A field can optionally be declared [static](../keywords/static--csharp-reference-.md). This makes the field available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](../classes-and-structs/static-classes-and-static-class-members--csharp-programming-guide-.md).  
  
 A field can be declared [readonly](../keywords/readonly--csharp-reference-.md). A read-only field can only be assigned a value during initialization or in a constructor. A `static``readonly` field is very similar to a constant, except that the C# compiler does not have access to the value of a static read-only field at compile time, only at run time. For more information, see [Constants](../classes-and-structs/constants--csharp-programming-guide-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Using Constructors](../classes-and-structs/using-constructors--csharp-programming-guide-.md)   
 [Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md)   
 [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md)   
 [Abstract and Sealed Classes and Class Members](../classes-and-structs/abstract-and-sealed-classes-and-class-members--csharp-programming-guide-.md)