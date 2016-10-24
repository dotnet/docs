---
title: "Using Structs (C# Programming Guide)"
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
  - "structs [C#], using"
ms.assetid: cea4a459-9eb9-442b-8d08-490e0797ba38
caps.latest.revision: 28
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
# Using Structs (C# Programming Guide)
The `struct` type is suitable for representing lightweight objects such as `Point`, `Rectangle`, and `Color`. Although it is just as convenient to represent a point as a [class](../keywords/class--csharp-reference-.md) with [Auto-Implemented Properties](../classes-and-structs/auto-implemented-properties--csharp-programming-guide-.md), a [struct](../keywords/struct--csharp-reference-.md) might be more efficient in some scenarios. For example, if you declare an array of 1000 `Point` objects, you will allocate additional memory for referencing each object; in this case, a struct would be less expensive. Because the [!INCLUDE[dnprdnshort](../classes-and-structs/includes/dnprdnshort_md.md)] contains an object called <xref:System.Drawing.Point>, the struct in this example is named "CoOrds" instead.  
  
 [!code[csProgGuideObjects#1](../classes-and-structs/codesnippet/CSharp/using-structs--csharp-programming-guide-_1.cs)]  
  
 It is an error to define a default (parameterless) constructor for a struct. It is also an error to initialize an instance field in a struct body. You can initialize struct members only by using a parameterized constructor or by accessing the members individually after the struct is declared. Any private or otherwise inaccessible members can be initialized only in a constructor.  
  
 When you create a struct object using the [new](../keywords/new--csharp-reference-.md) operator, it gets created and the appropriate constructor is called. Unlike classes, structs can be instantiated without using the `new` operator. In such a case, there is no constructor call, which makes the allocation more efficient. However, the fields will remain unassigned and the object cannot be used until all of the fields are initialized.  
  
 When a struct contains a reference type as a member, the default constructor of the member must be invoked explicitly, otherwise the member remains unassigned and the struct cannot be used. (This results in compiler error CS0171.)  
  
 There is no inheritance for structs as there is for classes. A struct cannot inherit from another struct or class, and it cannot be the base of a class. Structs, however, inherit from the base class <xref:System.Object>. A struct can implement interfaces, and it does that exactly as classes do.  
  
 You cannot declare a class using the keyword `struct`. In C#, classes and structs are semantically different. A struct is a value type, while a class is a reference type. For more information, see [Value Types](../keywords/value-types--csharp-reference-.md).  
  
 Unless you need reference-type semantics, a small class may be more efficiently handled by the system if you declare it as a struct instead.  
  
## Example 1  
  
### Description  
 This example demonstrates `struct` initialization using both default and parameterized constructors.  
  
### Code  
 [!code[csProgGuideObjects#1](../classes-and-structs/codesnippet/CSharp/using-structs--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuideObjects#2](../classes-and-structs/codesnippet/CSharp/using-structs--csharp-programming-guide-_2.cs)]  
  
## Example 2  
  
### Description  
 This example demonstrates a feature that is unique to structs. It creates a CoOrds object without using the `new` operator. If you replace the word `struct` with the word `class`, the program will not compile.  
  
### Code  
 [!code[csProgGuideObjects#1](../classes-and-structs/codesnippet/CSharp/using-structs--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuideObjects#3](../classes-and-structs/codesnippet/CSharp/using-structs--csharp-programming-guide-_3.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Structs](../classes-and-structs/structs--csharp-programming-guide-.md)