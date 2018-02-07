---
title: "abstract (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "abstract"
  - "abstract_CSharpKeyword"
helpviewer_keywords: 
  - "abstract keyword [C#]"
ms.assetid: b0797770-c1f3-4b4d-9441-b9122602a6bb
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
---
# abstract (C# Reference)
The `abstract` modifier indicates that the thing being modified has a missing or incomplete implementation. The abstract modifier can be used with classes, methods, properties, indexers, and events. Use the `abstract` modifier in a class declaration to indicate that a class is intended only to be a base class of other classes. Members marked as abstract, or included in an abstract class, must be implemented by classes that derive from the abstract class.  
  
## Example  
 In this example, the class `Square` must provide an implementation of `Area` because it derives from `ShapesClass`:  
  
 [!code-csharp[csrefKeywordsModifiers#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/abstract_1.cs)]  
  
 Abstract classes have the following features:  
  
-   An abstract class cannot be instantiated.  
  
-   An abstract class may contain abstract methods and accessors.  
  
-   It is not possible to modify an abstract class with the [sealed](../../../csharp/language-reference/keywords/sealed.md) modifier because the two modifers have opposite meanings. The `sealed` modifier prevents a class from being inherited and the `abstract` modifier requires a class to be inherited.  
  
-   A non-abstract class derived from an abstract class must include actual implementations of all inherited abstract methods and accessors.  
  
 Use the `abstract` modifier in a method or property declaration to indicate that the method or property does not contain implementation.  
  
 Abstract methods have the following features:  
  
-   An abstract method is implicitly a virtual method.  
  
-   Abstract method declarations are only permitted in abstract classes.  
  
-   Because an abstract method declaration provides no actual implementation, there is no method body; the method declaration simply ends with a semicolon and there are no curly braces ({ }) following the signature. For example:  
  
    ```csharp  
    public abstract void MyMethod();  
    ```  
  
     The implementation is provided by an overriding method [override](../../../csharp/language-reference/keywords/override.md), which is a member of a non-abstract class.  
  
-   It is an error to use the [static](../../../csharp/language-reference/keywords/static.md) or [virtual](../../../csharp/language-reference/keywords/virtual.md) modifiers in an abstract method declaration.  
  
 Abstract properties behave like abstract methods, except for the differences in declaration and invocation syntax.  
  
-   It is an error to use the `abstract` modifier on a static property.  
  
-   An abstract inherited property can be overridden in a derived class by including a property declaration that uses the [override](../../../csharp/language-reference/keywords/override.md) modifier.  
  
 For more information about abstract classes, see [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
 An abstract class must provide implementation for all interface members.  
  
 An abstract class that implements an interface might map the interface methods onto abstract methods. For example:  
  
 [!code-csharp[csrefKeywordsModifiers#2](../../../csharp/language-reference/keywords/codesnippet/CSharp/abstract_2.cs)]  
  
## Example  
 In this example, the class `DerivedClass` is derived from an abstract class `BaseClass`. The abstract class contains an abstract method, `AbstractMethod`, and two abstract properties, `X` and `Y`.  
  
 [!code-csharp[csrefKeywordsModifiers#3](../../../csharp/language-reference/keywords/codesnippet/CSharp/abstract_3.cs)]  
  
 In the preceding example, if you attempt to instantiate the abstract class by using a statement like this:  
  
```csharp
BaseClass bc = new BaseClass();   // Error  
```  
  
You will get an error saying that the compiler cannot create an instance of the abstract class 'BaseClass'.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)  
 [virtual](../../../csharp/language-reference/keywords/virtual.md)  
 [override](../../../csharp/language-reference/keywords/override.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)
