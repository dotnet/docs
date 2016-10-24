---
title: "Restrictions on Using Accessibility Levels (C# Reference)"
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
  - "access modifiers [C#], accessibility level restrictions"
ms.assetid: 987e2f22-46bf-4fea-80ee-270b9cd01045
caps.latest.revision: 21
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
# Restrictions on Using Accessibility Levels (C# Reference)
When you specify a type in a declaration, check whether the accessibility level of the type is dependent on the accessibility level of a member or of another type. For example, the direct base class must be at least as accessible as the derived class. The following declarations cause a compiler error because the base class `BaseClass` is less accessible than `MyClass`:  
  
```  
class BaseClass {...}  
public class MyClass: BaseClass {...} // Error  
```  
  
 The following table summarizes the restrictions on declared accessibility levels.  
  
|Context|Remarks|  
|-------------|-------------|  
|[Classes](../classes-and-structs/classes--csharp-programming-guide-.md)|The direct base class of a class type must be at least as accessible as the class type itself.|  
|[Interfaces](../interfaces/interfaces--csharp-programming-guide-.md)|The explicit base interfaces of an interface type must be at least as accessible as the interface type itself.|  
|[Delegates](../delegates/delegates--csharp-programming-guide-.md)|The return type and parameter types of a delegate type must be at least as accessible as the delegate type itself.|  
|[Constants](../classes-and-structs/constants--csharp-programming-guide-.md)|The type of a constant must be at least as accessible as the constant itself.|  
|[Fields](../classes-and-structs/fields--csharp-programming-guide-.md)|The type of a field must be at least as accessible as the field itself.|  
|[Methods](../classes-and-structs/methods--csharp-programming-guide-.md)|The return type and parameter types of a method must be at least as accessible as the method itself.|  
|[Properties](../classes-and-structs/properties--csharp-programming-guide-.md)|The type of a property must be at least as accessible as the property itself.|  
|[Events](../events/events--csharp-programming-guide-.md)|The type of an event must be at least as accessible as the event itself.|  
|[Indexers](../indexers/indexers--csharp-programming-guide-.md)|The type and parameter types of an indexer must be at least as accessible as the indexer itself.|  
|[Operators](../statements-expressions-operators/operators--csharp-programming-guide-.md)|The return type and parameter types of an operator must be at least as accessible as the operator itself.|  
|[Constructors](../classes-and-structs/constructors--csharp-programming-guide-.md)|The parameter types of a constructor must be at least as accessible as the constructor itself.|  
  
## Example  
 The following example contains erroneous declarations of different types. The comment following each declaration indicates the expected compiler error.  
  
```  
// Restrictions on Using Accessibility Levels  
// CS0052 expected as well as CS0053, CS0056, and CS0057  
// To make the program work, change access level of both class B  
// and MyPrivateMethod() to public.  
  
using System;  
  
// A delegate:  
delegate int MyDelegate();  
  
class B  
{  
    // A private method:  
    static int MyPrivateMethod()  
    {  
        return 0;  
    }  
}  
  
public class A  
{  
    // Error: The type B is less accessible than the field A.myField.  
    public B myField = new B();  
  
    // Error: The type B is less accessible  
    // than the constant A.myConst.  
    public readonly B myConst = new B();  
  
    public B MyMethod()  
    {  
        // Error: The type B is less accessible   
        // than the method A.MyMethod.  
        return new B();  
    }  
  
    // Error: The type B is less accessible than the property A.MyProp  
    public B MyProp  
    {  
        set  
        {  
        }  
    }  
  
    MyDelegate d = new MyDelegate(B.MyPrivateMethod);  
    // Even when B is declared public, you still get the error:   
    // "The parameter B.MyPrivateMethod is not accessible due to   
    // protection level."  
  
    public static B operator +(A m1, B m2)  
    {  
        // Error: The type B is less accessible  
        // than the operator A.operator +(A,B)  
        return new B();  
    }  
  
    static void Main()  
    {  
        Console.Write("Compiled successfully");  
    }  
}  
```  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Access Modifiers](../keywords/access-modifiers--csharp-reference-.md)   
 [Accessibility Domain](../keywords/accessibility-domain--csharp-reference-.md)   
 [Accessibility Levels](../keywords/accessibility-levels--csharp-reference-.md)   
 [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md)   
 [public](../keywords/public--csharp-reference-.md)   
 [private](../keywords/private--csharp-reference-.md)   
 [protected](../keywords/protected--csharp-reference-.md)   
 [internal](../keywords/internal--csharp-reference-.md)