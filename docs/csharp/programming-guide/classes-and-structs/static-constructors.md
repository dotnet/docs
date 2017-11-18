---
title: "Static Constructors (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "static constructors [C#]"
  - "constructors [C#], static"
ms.assetid: 151ec95e-3c4d-4ed7-885d-95b7a3be2e7d
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
---
# Static Constructors (C# Programming Guide)
A static constructor is used to initialize any [static](../../../csharp/language-reference/keywords/static.md) data, or to perform a particular action that needs to be performed once only. It is called automatically before the first instance is created or any static members are referenced.  
  
 [!code-csharp[csProgGuideObjects#14](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/static-constructors_1.cs)]  
  
 Static constructors have the following properties:  
  
-   A static constructor does not take access modifiers or have parameters.  
  
-   A static constructor is called automatically to initialize the [class](../../../csharp/language-reference/keywords/class.md) before the first instance is created or any static members are referenced.  
  
-   A static constructor cannot be called directly.  
  
-   The user has no control on when the static constructor is executed in the program.  
  
-   A typical use of static constructors is when the class is using a log file and the constructor is used to write entries to this file.  
  
-   Static constructors are also useful when creating wrapper classes for unmanaged code, when the constructor can call the `LoadLibrary` method.  
  
-   If a static constructor throws an exception, the runtime will not invoke it a second time, and the type will remain uninitialized for the lifetime of the application domain in which your program is running.  
  
## Example  
 In this example, class `Bus` has a static constructor. When the first instance of `Bus` is created (`bus1`), the static constructor is invoked to initialize the class. The sample output verifies that the static constructor runs only one time, even though two instances of `Bus` are created, and that it runs before the instance constructor runs.  
  
 [!code-csharp[csProgGuideObjects#15](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/static-constructors_2.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)  
 [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)  
 [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md)  
 [Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md)
