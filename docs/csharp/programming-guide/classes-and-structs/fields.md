---
title: "Fields (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "fields [C#]"
ms.assetid: 3cbb2f61-75f8-4cce-b4ef-f5d1b3de0db7
caps.latest.revision: 29
author: "BillWagner"
ms.author: "wiwagn"
---
# Fields (C# Programming Guide)
A *field* is a variable of any type that is declared directly in a [class](../../../csharp/language-reference/keywords/class.md) or [struct](../../../csharp/language-reference/keywords/struct.md). Fields are *members* of their containing type.  
  
 A class or struct may have instance fields or static fields or both. Instance fields are specific to an instance of a type. If you have a class T, with an instance field F, you can create two objects of type T, and modify the value of F in each object without affecting the value in the other object. By contrast, a static field belongs to the class itself, and is shared among all instances of that class. Changes made from instance A will be visibly immediately to instances B and C if they access the field.  
  
 Generally, you should use fields only for variables that have private or protected accessibility. Data that your class exposes to client code should be provided through [methods](../../../csharp/programming-guide/classes-and-structs/methods.md), [properties](../../../csharp/programming-guide/classes-and-structs/properties.md) and [indexers](../../../csharp/programming-guide/indexers/index.md). By using these constructs for indirect access to internal fields, you can guard against invalid input values. A private field that stores the data exposed by a public property is called a *backing store* or *backing field*.  
  
 Fields typically store the data that must be accessible to more than one class method and must be stored for longer than the lifetime of any single method. For example, a class that represents a calendar date might have three integer fields: one for the month, one for the day, and one for the year. Variables that are not used outside the scope of a single method should be declared as *local variables* within the method body itself.  
  
 Fields are declared in the class block by specifying the access level of the field, followed by the type of the field, followed by the name of the field. For example:  
  
 [!code-csharp[csProgGuideObjects#61](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/fields_1.cs)]  
  
 To access a field in an object, add a period after the object name, followed by the name of the field, as in `objectname.fieldname`. For example:  
  
 [!code-csharp[csProgGuideObjects#62](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/fields_2.cs)]  
  
 A field can be given an initial value by using the assignment operator when the field is declared. To automatically assign the `day` field to `"Monday"`, for example, you would declare `day` as in the following example:  
  
 [!code-csharp[csProgGuideObjects#63](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/fields_3.cs)]  
  
 Fields are initialized immediately before the constructor for the object instance is called. If the constructor assigns the value of a field, it will overwrite any value given during field declaration. For more information, see [Using Constructors](../../../csharp/programming-guide/classes-and-structs/using-constructors.md).  
  
> [!NOTE]
>  A field initializer cannot refer to other instance fields.  
  
 Fields can be marked as [public](../../../csharp/language-reference/keywords/public.md), [private](../../../csharp/language-reference/keywords/private.md), [protected](../../../csharp/language-reference/keywords/protected.md), [internal](../../../csharp/language-reference/keywords/internal.md), [protected internal](../../../csharp/language-reference/keywords/protected-internal.md) or [private protected](../../../csharp/language-reference/keywords/private-protected.md). These access modifiers define how users of the class can access the fields. For more information, see [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md).  
  
 A field can optionally be declared [static](../../../csharp/language-reference/keywords/static.md). This makes the field available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md).  
  
 A field can be declared [readonly](../../../csharp/language-reference/keywords/readonly.md). A read-only field can only be assigned a value during initialization or in a constructor. A `static``readonly` field is very similar to a constant, except that the C# compiler does not have access to the value of a static read-only field at compile time, only at run time. For more information, see [Constants](../../../csharp/programming-guide/classes-and-structs/constants.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)  
 [Using Constructors](../../../csharp/programming-guide/classes-and-structs/using-constructors.md)  
 [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md)  
 [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md)  
 [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md)
