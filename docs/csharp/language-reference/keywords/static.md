---
title: "static (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "static"
  - "static_CSharpKeyword"
helpviewer_keywords: 
  - "static keyword [C#]"
ms.assetid: 5509e215-2183-4da3-bab4-6b7e607a4fdf
caps.latest.revision: 26
author: "BillWagner"
ms.author: "wiwagn"
---
# static (C# Reference)
Use the `static` modifier to declare a static member, which belongs to the type itself rather than to a specific object. The `static` modifier can be used with classes, fields, methods, properties, operators, events, and constructors, but it cannot be used with indexers, finalizers, or types other than classes. For more information, see [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md).  
  
## Example  
 The following class is declared as `static` and contains only `static` methods:  
  
 [!code-csharp[csrefKeywordsModifiers#18](../../../csharp/language-reference/keywords/codesnippet/CSharp/static_1.cs)]  
  
 A constant or type declaration is implicitly a static member.  
  
 A static member cannot be referenced through an instance. Instead, it is referenced through the type name. For example, consider the following class:  
  
 [!code-csharp[csrefKeywordsModifiers#19](../../../csharp/language-reference/keywords/codesnippet/CSharp/static_2.cs)]  
  
 To refer to the static member `x`, use the fully qualified name, `MyBaseC.MyStruct.x`, unless the member is accessible from the same scope:  
  
```csharp  
Console.WriteLine(MyBaseC.MyStruct.x);  
```  
  
 While an instance of a class contains a separate copy of all instance fields of the class, there is only one copy of each static field.  
  
 It is not possible to use [this](../../../csharp/language-reference/keywords/this.md) to reference static methods or property accessors.  
  
 If the `static` keyword is applied to a class, all the members of the class must be static.  
  
 Classes and static classes may have static constructors. Static constructors are called at some point between when the program starts and the class is instantiated.  
  
> [!NOTE]
>  The `static` keyword has more limited uses than in C++. To compare with the C++ keyword, see [Storage classes (C++)](/cpp/cpp/storage-classes-cpp#static).
  
 To demonstrate static members, consider a class that represents a company employee. Assume that the class contains a method to count employees and a field to store the number of employees. Both the method and the field do not belong to any instance employee. Instead they belong to the company class. Therefore, they should be declared as static members of the class.  
  
## Example  
 This example reads the name and ID of a new employee, increments the employee counter by one, and displays the information for the new employee and the new number of employees. For simplicity, this program reads the current number of employees from the keyboard. In a real application, this information should be read from a file.  
  
 [!code-csharp[csrefKeywordsModifiers#20](../../../csharp/language-reference/keywords/codesnippet/CSharp/static_3.cs)]  
  
## Example  
 This example shows that although you can initialize a static field by using another static field not yet declared, the results will be undefined until you explicitly assign a value to the static field.  
  
 [!code-csharp[csrefKeywordsModifiers#21](../../../csharp/language-reference/keywords/codesnippet/CSharp/static_4.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)  
 [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md)
