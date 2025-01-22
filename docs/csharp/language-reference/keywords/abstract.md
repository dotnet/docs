---
description: "abstract - C# Reference"
title: "abstract keyword"
ms.date: 07/20/2015
f1_keywords: 
  - "abstract"
  - "abstract_CSharpKeyword"
helpviewer_keywords: 
  - "abstract keyword [C#]"
ms.assetid: b0797770-c1f3-4b4d-9441-b9122602a6bb
---
# abstract (C# Reference)

The `abstract` modifier indicates that the thing being modified has a missing or incomplete implementation. The abstract modifier can be used with classes, methods, properties, indexers, and events. Use the `abstract` modifier in a class declaration to indicate that a class is intended only to be a base class of other classes, not instantiated on its own. Members marked as abstract must be implemented by non-abstract classes that derive from the abstract class.
  
## Example 1

 In this example, the class `Square` must provide an implementation of `GetArea` because it derives from `Shape`:  
  
 [!code-csharp[csrefKeywordsModifiers#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#1)]
  
 Abstract classes have the following features:  
  
- An abstract class cannot be instantiated.  
  
- An abstract class may contain abstract methods and accessors.  
  
- It is not possible to modify an abstract class with the [sealed](./sealed.md) modifier because the two modifiers have opposite meanings. The `sealed` modifier prevents a class from being inherited and the `abstract` modifier requires a class to be inherited.  
  
- A non-abstract class derived from an abstract class must include actual implementations of all inherited abstract methods and accessors.  
  
 Use the `abstract` modifier in a method or property declaration to indicate that the method or property does not contain implementation.  
  
 Abstract methods have the following features:  
  
- An abstract method is implicitly a virtual method.  
  
- Abstract method declarations are only permitted in abstract classes.  
  
- Because an abstract method declaration provides no actual implementation, there is no method body; the method declaration simply ends with a semicolon and there are no curly braces ({ }) following the signature. For example:  
  
    ```csharp  
    public abstract void MyMethod();  
    ```  
  
     The implementation is provided by a method [override](./override.md), which is a member of a non-abstract class.  
  
- It is an error to use the [static](./static.md) or [virtual](./virtual.md) modifiers in an abstract method declaration.  
  
 Abstract properties behave like abstract methods, except for the differences in declaration and invocation syntax.  
  
- It is an error to use the `abstract` modifier on a static property.  
  
- An abstract inherited property can be overridden in a derived class by including a property declaration that uses the [override](./override.md) modifier.  
  
 For more information about abstract classes, see [Abstract and Sealed Classes and Class Members](../../programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
 An abstract class must provide implementation for all interface members.  
  
 An abstract class that implements an interface might map the interface methods onto abstract methods. For example:  
  
[!code-csharp[csrefKeywordsModifiers#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#2)]
  
## Example 2

 In this example, the class `DerivedClass` is derived from an abstract class `BaseClass`. The abstract class contains an abstract method, `AbstractMethod`, and two abstract properties, `X` and `Y`.  
  
[!code-csharp[csrefKeywordsModifiers#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#3)]
  
 In the preceding example, if you attempt to instantiate the abstract class by using a statement like this:  
  
```csharp
BaseClass bc = new BaseClass();   // Error  
```  
  
You will get an error saying that the compiler cannot create an instance of the abstract class 'BaseClass'.  

Nonetheless, it is possible to use an abstract class constructor, as in the  example below

## Example 3

[!code-csharp[csrefKeywordsModifiers#27](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#27)]

The `Shape` class is declared `abstract`, which means it cannot be instantiated directly. Instead, it serves as a blueprint for other classes.

- Even though you can't create objects of an abstract class, it can still have a constructor.  This constructor is typically `protected`, meaning it can only be accessed from derived classes.
  In this case, the `Shape` constructor takes a `color` parameter and initializes the `Color` property. It also prints a message to the console.
  The `public Square(string color, double side) : base(color)` part calls the base class's constructor (`Shape`) and passes the `color` argument to it.
- In the Shape class, the defined constructor takes a color as a parameter `protected Shape(string color)`. This means there's no longer a default parameterless constructor automatically provided by C# thus derived classes must use the `: base(color)` expression to invoke the base constructor. Setting the default value to color `protected Shape(string color="green")` will allow to omit the
  `: base(color)` expression in derived classes, still such constructor `protected Shape(string color="green")` will be invoked, setting the color to green.

## C# Language Specification  

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [virtual](./virtual.md)
- [override](./override.md)
- [C# Keywords](./index.md)
