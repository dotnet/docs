---
title: "Private Constructors - C# Programming Guide"
description: A private constructor is a special instance constructor in C# used to restrict how an object can be created. They may be used with factory methods or other construction idioms.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "C# language, private constructors"
  - "private constructors [C#]"
ms.assetid: 29eeaa7d-8d81-453c-94b9-0e2800172621
---
# Private Constructors (C# Programming Guide)

A private constructor is a special instance constructor. It is generally used in classes that contain static members only. If a class has one or more private constructors and no public constructors, other classes (except nested classes) cannot create instances of this class. For example:  
  
 [!code-csharp[ClassWithPrivateConstructorExample#1](snippets/private-constructors/Program.cs#1)]
  
 The declaration of the empty constructor prevents the automatic generation of a parameterless constructor. Note that if you do not use an access modifier with the constructor it will still be private by default. However, the [private](../../language-reference/keywords/private.md) modifier is usually used explicitly to make it clear that the class cannot be instantiated.  
  
 Private constructors are used to prevent creating instances of a class when there are no instance fields or methods, such as the <xref:System.Math> class, or when a method is called to obtain an instance of a class. If all the methods in the class are static, consider making the complete class static. For more information see [Static Classes and Static Class Members](./static-classes-and-static-class-members.md).  
  
## Example  

 The following is an example of a class using a private constructor.  
  
 [!code-csharp[CounterClassWithPrivateConstructor#2](snippets/private-constructors/Program.cs#2)]
  
 Notice that if you uncomment the following statement from the example, it will generate an error because the constructor is inaccessible because of its protection level:  
  
 [!code-csharp[ErrorInstantiatingUsingPrivateConstructor#13](snippets/private-constructors/Program.cs#3)]
  
## C# Language Specification  

For more information, see [Private constructors](~/_csharplang/spec/classes.md#private-constructors) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.
  
## See also

- [C# Programming Guide](../index.md)
- [Classes, structs, and records](/dotnet/csharp/fundamentals/object-oriented)
- [Constructors](./constructors.md)
- [Finalizers](./finalizers.md)
- [private](../../language-reference/keywords/private.md)
- [public](../../language-reference/keywords/public.md)
