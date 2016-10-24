---
title: "Using Constructors (C# Programming Guide)"
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
  - "constructors [C#], about constructors"
ms.assetid: 464253b2-fd5d-469a-836d-df0fdf2a43f7
caps.latest.revision: 26
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
# Using Constructors (C# Programming Guide)
When a [class](../keywords/class--csharp-reference-.md) or [struct](../keywords/struct--csharp-reference-.md) is created, its constructor is called. Constructors have the same name as the class or struct, and they usually initialize the data members of the new object.  
  
 In the following example, a class named `Taxi` is defined by using a simple constructor. This class is then instantiated with the [new](../keywords/new--csharp-reference-.md) operator. The `Taxi` constructor is invoked by the `new` operator immediately after memory is allocated for the new object.  
  
 [!code[csProgGuideObjects#53](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_1.cs)]  
  
 A constructor that takes no parameters is called a *default constructor*. Default constructors are invoked whenever an object is instantiated by using the `new` operator and no arguments are provided to `new`. For more information, see [Instance Constructors](../classes-and-structs/instance-constructors--csharp-programming-guide-.md).  
  
 Unless the class is [static](../keywords/static--csharp-reference-.md), classes without constructors are given a public default constructor by the C# compiler in order to enable class instantiation. For more information, see [Static Classes and Static Class Members](../classes-and-structs/static-classes-and-static-class-members--csharp-programming-guide-.md).  
  
 You can prevent a class from being instantiated by making the constructor private, as follows:  
  
 [!code[csProgGuideObjects#11](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_2.cs)]  
  
 For more information, see [Private Constructors](../classes-and-structs/private-constructors--csharp-programming-guide-.md).  
  
 Constructors for [struct](../keywords/struct--csharp-reference-.md) types resemble class constructors, but `structs` cannot contain an explicit default constructor because one is provided automatically by the compiler. This constructor initializes each field in the `struct` to the default values. For more information, see [Default Values Table](../keywords/default-values-table--csharp-reference-.md). However, this default constructor is only invoked if the `struct` is instantiated with `new`. For example, this code uses the default constructor for <xref:System.Int32>, so that you are assured that the integer is initialized:  
  
```  
int i = new int();  
Console.WriteLine(i);  
```  
  
 The following code, however, causes a compiler error because it does not use `new`, and because it tries to use an object that has not been initialized:  
  
```  
int i;  
Console.WriteLine(i);  
```  
  
 Alternatively, objects based on `structs` (including all built-in numeric types) can be initialized or assigned and then used as in the following example:  
  
```  
int a = 44;  // Initialize the value type...  
int b;  
b = 33;      // Or assign it before using it.  
Console.WriteLine("{0}, {1}", a, b);  
```  
  
 So calling the default constructor for a value type is not required.  
  
 Both classes and `structs` can define constructors that take parameters. Constructors that take parameters must be called through a `new` statement or a [base](../keywords/base--csharp-reference-.md) statement. Classes and `structs` can also define multiple constructors, and neither is required to define a default constructor. For example:  
  
 [!code[csProgGuideObjects#54](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_3.cs)]  
  
 This class can be created by using either of the following statements:  
  
 [!code[csProgGuideObjects#55](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_4.cs)]  
  
 A constructor can use the `base` keyword to call the constructor of a base class. For example:  
  
 [!code[csProgGuideObjects#56](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_5.cs)]  
  
 In this example, the constructor for the base class is called before the block for the constructor is executed. The `base` keyword can be used with or without parameters. Any parameters to the constructor can be used as parameters to `base`, or as part of an expression. For more information, see [base](../keywords/base--csharp-reference-.md).  
  
 In a derived class, if a base-class constructor is not called explicitly by using the `base` keyword, the default constructor, if there is one, is called implicitly. This means that the following constructor declarations are effectively the same:  
  
 [!code[csProgGuideObjects#58](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_6.cs)]  
  
 [!code[csProgGuideObjects#57](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_7.cs)]  
  
 If a base class does not offer a default constructor, the derived class must make an explicit call to a base constructor by using `base`.  
  
 A constructor can invoke another constructor in the same object by using the [this](../keywords/this--csharp-reference-.md) keyword. Like `base`, `this` can be used with or without parameters, and any parameters in the constructor are available as parameters to `this`, or as part of an expression. For example, the second constructor in the previous example can be rewritten using `this`:  
  
 [!code[csProgGuideObjects#59](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_8.cs)]  
  
 The use of the `this` keyword in the previous example causes this constructor to be called:  
  
 [!code[csProgGuideObjects#60](../classes-and-structs/codesnippet/CSharp/using-constructors--csharp-programming-guide-_9.cs)]  
  
 Constructors can be marked as [public](../keywords/public--csharp-reference-.md), [private](../keywords/private--csharp-reference-.md), [protected](../keywords/protected--csharp-reference-.md), [internal](../keywords/internal--csharp-reference-.md), or `protected``internal`. These access modifiers define how users of the class can construct the class. For more information, see [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md).  
  
 A constructor can be declared static by using the [static](../keywords/static--csharp-reference-.md) keyword. Static constructors are called automatically, immediately before any static fields are accessed, and are generally used to initialize static class members. For more information, see [Static Constructors](../classes-and-structs/static-constructors--csharp-programming-guide-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Constructors](../classes-and-structs/constructors--csharp-programming-guide-.md)   
 [Destructors](../classes-and-structs/destructors--csharp-programming-guide-.md)