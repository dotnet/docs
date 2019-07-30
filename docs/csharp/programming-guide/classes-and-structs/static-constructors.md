---
title: "Static Constructors - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "static constructors [C#]"
  - "constructors [C#], static"
ms.assetid: 151ec95e-3c4d-4ed7-885d-95b7a3be2e7d
---
# Static Constructors (C# Programming Guide)
A static constructor is used to initialize any [static](../../../csharp/language-reference/keywords/static.md) data, or to perform a particular action that needs to be performed once only. It is called automatically before the first instance is created or any static members are referenced.  
  
 [!code-csharp[csProgGuideObjects#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#14)]  
 
## Remarks
Static constructors have the following properties:  
  
- A static constructor does not take access modifiers or have parameters.  

- A class or struct can only have one static constructor.

- Static constructors cannot be inherited or overloaded.

- A static constructor cannot be called directly and is only meant to be called by the common language runtime (CLR). It is invoked automatically.

- The user has no control on when the static constructor is executed in the program.
  
- A static constructor is called automatically to initialize the [class](../../../csharp/language-reference/keywords/class.md) before the first instance is created or any static members are referenced. A static constructor will run before an instance constructor. Note that a type's static constructor is called when a static method assigned to an event or a delegate is invoked and not when it is assigned. If static field variable initializers are present in the class of the static constructor, they will be executed in the textual order in which they appear in the class declaration immediately prior to the execution of the static constructor.

- If you don't provide a static constructor to initialize static fields, all static fields are initialized to their default value as listed in the [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md). 
  
- If a static constructor throws an exception, the runtime will not invoke it a second time, and the type will remain uninitialized for the lifetime of the application domain in which your program is running. Most commonly, a <xref:System.TypeInitializationException> exception is thrown when a static constructor is unable to instantiate a type or for an unhandled exception occurring within a static constructor. For implicit static constructors that are not explicitly defined in source code, troubleshooting may require inspection of the intermediate language (IL) code.

- The presence of a static constructor prevents the addition of the <xref:System.Reflection.TypeAttributes.BeforeFieldInit> type attribute. This limits runtime optimization.

- A field declared as `static readonly` may only be assigned as part of its declaration or in a static constructor. When an explicit static constructor is not required, initialize static fields at declaration, rather than through a static constructor for better runtime optimization.

> [!Note]
> Though not directly accessible, the presence of an explicit static constructor should be documented to assist with troubleshooting initialization exceptions.

### Usage

- A typical use of static constructors is when the class is using a log file and the constructor is used to write entries to this file.  
- Static constructors are also useful when creating wrapper classes for unmanaged code, when the constructor can call the `LoadLibrary` method.  

- Static constructors are also a convenient place to enforce run-time checks on the type parameter that cannot be checked at compile-time via constraints (Type parameter constraints).

## Example
 In this example, class `Bus` has a static constructor. When the first instance of `Bus` is created (`bus1`), the static constructor is invoked to initialize the class. The sample output verifies that the static constructor runs only one time, even though two instances of `Bus` are created, and that it runs before the instance constructor runs.  
  
 [!code-csharp[csProgGuideObjects#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#15)]
 
## C# language specification
For more information, see the [Static constructors](~/_csharplang/spec/classes.md#static-constructors) section of the [C# language specification](~/_csharplang/spec/introduction.md).
  
## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)
- [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)
- [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md)
- [Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md)
- [Constructor Design Guidelines](../../../standard/design-guidelines/constructor.md#type-constructor-guidelines)
- [Security Warning - CA2121: Static constructors should be private](https://docs.microsoft.com/visualstudio/code-quality/ca2121-static-constructors-should-be-private)
