---
title: "Partial Classes and Methods (C# Programming Guide)"
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
  - "partial methods [C#]"
  - "partial classes [C#]"
  - "C# language, partial classes and methods"
ms.assetid: 804cecb7-62db-4f97-a99f-60975bd59fa1
caps.latest.revision: 35
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
# Partial Classes and Methods (C# Programming Guide)
It is possible to split the definition of a [class](../keywords/class--csharp-reference-.md) or a [struct](../keywords/struct--csharp-reference-.md), an [interface](../keywords/interface--csharp-reference-.md) or a method over two or more source files. Each source file contains a section of the type or method definition, and all parts are combined when the application is compiled.  
  
## Partial Classes  
 There are several situations when splitting a class definition is desirable:  
  
-   When working on large projects, spreading a class over separate files enables multiple programmers to work on it at the same time.  
  
-   When working with automatically generated source, code can be added to the class without having to recreate the source file. Visual Studio uses this approach when it creates Windows Forms, Web service wrapper code, and so on. You can create code that uses these classes without having to modify the file created by Visual Studio.  
  
-   To split a class definition, use the [partial](../keywords/partial--type---csharp-reference-.md) keyword modifier, as shown here:  
  
 [!code[csProgGuideObjects#26](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_1.cs)]  
  
 The `partial` keyword indicates that other parts of the class, struct, or interface can be defined in the namespace. All the parts must use the `partial` keyword. All the parts must be available at compile time to form the final type. All the parts must have the same accessibility, such as `public`, `private`, and so on.  
  
 If any part is declared abstract, then the whole type is considered abstract. If any part is declared sealed, then the whole type is considered sealed. If any part declares a base type, then the whole type inherits that class.  
  
 All the parts that specify a base class must agree, but parts that omit a base class still inherit the base type. Parts can specify different base interfaces, and the final type implements all the interfaces listed by all the partial declarations. Any class, struct, or interface members declared in a partial definition are available to all the other parts. The final type is the combination of all the parts at compile time.  
  
> [!NOTE]
>  The `partial` modifier is not available on delegate or enumeration declarations.  
  
 The following example shows that nested types can be partial, even if the type they are nested within is not partial itself.  
  
 [!code[csProgGuideObjects#25](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_2.cs)]  
  
 At compile time, attributes of partial-type definitions are merged. For example, consider the following declarations:  
  
 [!code[csProgGuideObjects#23](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_3.cs)]  
  
 They are equivalent to the following declarations:  
  
 [!code[csProgGuideObjects#24](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_4.cs)]  
  
 The following are merged from all the partial-type definitions:  
  
-   XML comments  
  
-   interfaces  
  
-   generic-type parameter attributes  
  
-   class attributes  
  
-   members  
  
 For example, consider the following declarations:  
  
 [!code[csProgGuideObjects#21](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_5.cs)]  
  
 They are equivalent to the following declarations:  
  
 [!code[csProgGuideObjects#22](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_6.cs)]  
  
### Restrictions  
 There are several rules to follow when you are working with partial class definitions:  
  
-   All partial-type definitions meant to be parts of the same type must be modified with `partial`. For example, the following class declarations generate an error:  
  
     [!code[csProgGuideObjects#20](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_7.cs)]  
  
-   The `partial` modifier can only appear immediately before the keywords `class`, `struct`, or `interface`.  
  
-   Nested partial types are allowed in partial-type definitions as illustrated in the following example:  
  
     [!code[csProgGuideObjects#19](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_8.cs)]  
  
-   All partial-type definitions meant to be parts of the same type must be defined in the same assembly and the same module (.exe or .dll file). Partial definitions cannot span multiple modules.  
  
-   The class name and generic-type parameters must match on all partial-type definitions. Generic types can be partial. Each partial declaration must use the same parameter names in the same order.  
  
-   The following keywords on a partial-type definition are optional, but if present on one partial-type definition, cannot conflict with the keywords specified on another partial definition for the same type:  
  
    -   [public](../keywords/public--csharp-reference-.md)  
  
    -   [private](../keywords/private--csharp-reference-.md)  
  
    -   [protected](../keywords/protected--csharp-reference-.md)  
  
    -   [internal](../keywords/internal--csharp-reference-.md)  
  
    -   [abstract](../keywords/abstract--csharp-reference-.md)  
  
    -   [sealed](../keywords/sealed--csharp-reference-.md)  
  
    -   base class  
  
    -   [new](../keywords/new--csharp-reference-.md) modifier (nested parts)  
  
    -   generic constraints  
  
         For more information, see [Constraints on Type Parameters](../generics/constraints-on-type-parameters--csharp-programming-guide-.md).  
  
## Example 1  
  
### Description  
 In the following example, the fields and the constructor of the class, `CoOrds`, are declared in one partial class definition, and the member, `PrintCoOrds`, is declared in another partial class definition.  
  
### Code  
 [!code[csProgGuideObjects#17](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_9.cs)]  
  
## Example 2  
  
### Description  
 The following example shows that you can also develop partial structs and interfaces.  
  
### Code  
 [!code[csProgGuideObjects#18](../classes-and-structs/codesnippet/CSharp/partial-classes-and-methods--csharp-programming-guide-_10.cs)]  
  
## Partial Methods  
 A partial class or struct may contain a partial method. One part of the class contains the signature of the method. An optional implementation may be defined in the same part or another part. If the implementation is not supplied, then the method and all calls to the method are removed at compile time.  
  
 Partial methods enable the implementer of one part of a class to define a method, similar to an event. The implementer of the other part of the class can decide whether to implement the method or not. If the method is not implemented, then the compiler removes the method signature and all calls to the method. The calls to the method, including any results that would occur from evaluation of arguments in the calls, have no effect at run time. Therefore, any code in the partial class can freely use a partial method, even if the implementation is not supplied. No compile-time or run-time errors will result if the method is called but not implemented.  
  
 Partial methods are especially useful as a way to customize generated code. They allow for a method name and signature to be reserved, so that generated code can call the method but the developer can decide whether to implement the method. Much like partial classes, partial methods enable code created by a code generator and code created by a human developer to work together without run-time costs.  
  
 A partial method declaration consists of two parts: the definition, and the implementation. These may be in separate parts of a partial class, or in the same part. If there is no implementation declaration, then the compiler optimizes away both the defining declaration and all calls to the method.  
  
```  
// Definition in file1.cs  
partial void onNameChanged();  
  
// Implementation in file2.cs  
partial void onNameChanged()  
{  
  // method body  
}  
```  
  
-   Partial method declarations must begin with the contextual keyword [partial](../keywords/partial--type---csharp-reference-.md) and the method must return [void](../keywords/void--csharp-reference-.md).  
  
-   Partial methods can have [ref](../keywords/ref--csharp-reference-.md) but not [out](../keywords/out--csharp-reference-.md) parameters.  
  
-   Partial methods are implicitly [private](../keywords/private--csharp-reference-.md), and therefore they cannot be [virtual](../keywords/virtual--csharp-reference-.md).  
  
-   Partial methods cannot be [extern](../keywords/extern--csharp-reference-.md), because the presence of the body determines whether they are defining or implementing.  
  
-   Partial methods can have [static](../keywords/static--csharp-reference-.md) and [unsafe](../keywords/unsafe--csharp-reference-.md) modifiers.  
  
-   Partial methods can be generic. Constraints are put on the defining partial method declaration, and may optionally be repeated on the implementing one. Parameter and type parameter names do not have to be the same in the implementing declaration as in the defining one.  
  
-   You can make a [delegate](../keywords/delegate--csharp-reference-.md) to a partial method that has been defined and implemented, but not to a partial method that has only been defined.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes](../classes-and-structs/classes--csharp-programming-guide-.md)   
 [Structs](../classes-and-structs/structs--csharp-programming-guide-.md)   
 [Interfaces](../interfaces/interfaces--csharp-programming-guide-.md)   
 [partial (Type)](../keywords/partial--type---csharp-reference-.md)