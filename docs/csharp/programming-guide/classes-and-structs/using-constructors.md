---
title: "Using Constructors (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "constructors [C#], about constructors"
ms.assetid: 464253b2-fd5d-469a-836d-df0fdf2a43f7
caps.latest.revision: 26
author: "BillWagner"
ms.author: "wiwagn"
---
# Using Constructors (C# Programming Guide)
When a [class](../../../csharp/language-reference/keywords/class.md) or [struct](../../../csharp/language-reference/keywords/struct.md) is created, its constructor is called. Constructors have the same name as the class or struct, and they usually initialize the data members of the new object.  
  
 In the following example, a class named `Taxi` is defined by using a simple constructor. This class is then instantiated with the [new](../../../csharp/language-reference/keywords/new.md) operator. The `Taxi` constructor is invoked by the `new` operator immediately after memory is allocated for the new object.  
  
 [!code-csharp[csProgGuideObjects#53](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_1.cs)]  
  
 A constructor that takes no parameters is called a *default constructor*. Default constructors are invoked whenever an object is instantiated by using the `new` operator and no arguments are provided to `new`. For more information, see [Instance Constructors](../../../csharp/programming-guide/classes-and-structs/instance-constructors.md).  
  
 Unless the class is [static](../../../csharp/language-reference/keywords/static.md), classes without constructors are given a public default constructor by the C# compiler in order to enable class instantiation. For more information, see [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md).  
  
 You can prevent a class from being instantiated by making the constructor private, as follows:  
  
 [!code-csharp[csProgGuideObjects#11](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_2.cs)]  
  
 For more information, see [Private Constructors](../../../csharp/programming-guide/classes-and-structs/private-constructors.md).  
  
 Constructors for [struct](../../../csharp/language-reference/keywords/struct.md) types resemble class constructors, but `structs` cannot contain an explicit default constructor because one is provided automatically by the compiler. This constructor initializes each field in the `struct` to the default values. For more information, see [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md). However, this default constructor is only invoked if the `struct` is instantiated with `new`. For example, this code uses the default constructor for <xref:System.Int32>, so that you are assured that the integer is initialized:  
  
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
  
 Both classes and `structs` can define constructors that take parameters. Constructors that take parameters must be called through a `new` statement or a [base](../../../csharp/language-reference/keywords/base.md) statement. Classes and `structs` can also define multiple constructors, and neither is required to define a default constructor. For example:  
  
 [!code-csharp[csProgGuideObjects#54](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_3.cs)]  
  
 This class can be created by using either of the following statements:  
  
 [!code-csharp[csProgGuideObjects#55](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_4.cs)]  
  
 A constructor can use the `base` keyword to call the constructor of a base class. For example:  
  
 [!code-csharp[csProgGuideObjects#56](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_5.cs)]  
  
 In this example, the constructor for the base class is called before the block for the constructor is executed. The `base` keyword can be used with or without parameters. Any parameters to the constructor can be used as parameters to `base`, or as part of an expression. For more information, see [base](../../../csharp/language-reference/keywords/base.md).  
  
 In a derived class, if a base-class constructor is not called explicitly by using the `base` keyword, the default constructor, if there is one, is called implicitly. This means that the following constructor declarations are effectively the same:  
  
 [!code-csharp[csProgGuideObjects#58](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_6.cs)]  
  
 [!code-csharp[csProgGuideObjects#57](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_7.cs)]  
  
 If a base class does not offer a default constructor, the derived class must make an explicit call to a base constructor by using `base`.  
  
 A constructor can invoke another constructor in the same object by using the [this](../../../csharp/language-reference/keywords/this.md) keyword. Like `base`, `this` can be used with or without parameters, and any parameters in the constructor are available as parameters to `this`, or as part of an expression. For example, the second constructor in the previous example can be rewritten using `this`:  
  
 [!code-csharp[csProgGuideObjects#59](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_8.cs)]  
  
 The use of the `this` keyword in the previous example causes this constructor to be called:  
  
 [!code-csharp[csProgGuideObjects#60](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-constructors_9.cs)]  
  
 Constructors can be marked as [public](../../../csharp/language-reference/keywords/public.md), [private](../../../csharp/language-reference/keywords/private.md), [protected](../../../csharp/language-reference/keywords/protected.md), [internal](../../../csharp/language-reference/keywords/internal.md), [protected internal](../../../csharp/language-reference/keywords/protected-internal.md) or [private protected](../../../csharp/language-reference/keywords/private-protected.md). These access modifiers define how users of the class can construct the class. For more information, see [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md).  
  
 A constructor can be declared static by using the [static](../../../csharp/language-reference/keywords/static.md) keyword. Static constructors are called automatically, immediately before any static fields are accessed, and are generally used to initialize static class members. For more information, see [Static Constructors](../../../csharp/programming-guide/classes-and-structs/static-constructors.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)  
 [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)  
 [Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md)
