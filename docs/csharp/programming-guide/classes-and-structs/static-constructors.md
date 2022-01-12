---
title: "Static Constructors - C# Programming Guide"
description: A static constructor in C# initializes static data or performs an action done only once. It runs before the first instance is created or static members are referenced.
ms.date: 12/21/2021
helpviewer_keywords: 
  - "static constructors [C#]"
  - "constructors [C#], static"
---
# Static Constructors (C# Programming Guide)

A static constructor is used to initialize any [static](../../language-reference/keywords/static.md) data, or to perform a particular action that needs to be performed only once. It is called automatically before the first instance is created or any static members are referenced.

[!code-csharp[SimpleClass#1](snippets/static-constructors/Program.cs#1)]

## Remarks

Static constructors have the following properties:

- A static constructor doesn't take access modifiers or have parameters.
- A class or struct can only have one static constructor.
- Static constructors cannot be inherited or overloaded.
- A static constructor cannot be called directly and is only meant to be called by the common language runtime (CLR). It is invoked automatically.
- The user has no control on when the static constructor is executed in the program.
- A static constructor is called automatically. It initializes the [class](../../language-reference/keywords/class.md) before the first instance is created or any static members declared in that class (not its base classes) are referenced. A static constructor runs before an instance constructor. A type's static constructor is called when a static method assigned to an event or a delegate is invoked and not when it is assigned. If static field variable initializers are present in the class of the static constructor, they're executed in the textual order in which they appear in the class declaration. The initializers run immediately prior to the execution of the static constructor.
- If you don't provide a static constructor to initialize static fields, all static fields are initialized to their default value as listed in [Default values of C# types](../../language-reference/builtin-types/default-values.md).
- If a static constructor throws an exception, the runtime doesn't invoke it a second time, and the type will remain uninitialized for the lifetime of the application domain. Most commonly, a <xref:System.TypeInitializationException> exception is thrown when a static constructor is unable to instantiate a type or for an unhandled exception occurring within a static constructor. For static constructors that aren't explicitly defined in source code, troubleshooting may require inspection of the intermediate language (IL) code.
- The presence of a static constructor prevents the addition of the <xref:System.Reflection.TypeAttributes.BeforeFieldInit> type attribute. This limits runtime optimization.
- A field declared as `static readonly` may only be assigned as part of its declaration or in a static constructor. When an explicit static constructor isn't required, initialize static fields at declaration rather than through a static constructor for better runtime optimization.
- The runtime calls a static constructor no more than once in a single application domain. That call is made in a locked region based on the specific type of the class. No additional locking mechanisms are needed in the body of a static constructor. To avoid the risk of deadlocks, don't block the current thread in static constructors and initializers. For example, don't wait on tasks, threads, wait handles or events, don't acquire locks, and don't execute blocking parallel operations such as parallel loops, `Parallel.Invoke` and Parallel LINQ queries.

> [!Note]
> Though not directly accessible, the presence of an explicit static constructor should be documented to assist with troubleshooting initialization exceptions.

### Usage

- A typical use of static constructors is when the class is using a log file and the constructor is used to write entries to this file.
- Static constructors are also useful when creating wrapper classes for unmanaged code, when the constructor can call the `LoadLibrary` method.
- Static constructors are also a convenient place to enforce run-time checks on the type parameter that cannot be checked at compile time via type-parameter constraints.

## Example

In this example, class `Bus` has a static constructor. When the first instance of `Bus` is created (`bus1`), the static constructor is invoked to initialize the class. The sample output verifies that the static constructor runs only one time, even though two instances of `Bus` are created, and that it runs before the instance constructor runs.

[!code-csharp[BusSample#2](snippets/static-constructors/Program.cs#2)]

## C# language specification

For more information, see the [Static constructors](~/_csharpstandard/standard/classes.md#1512-static-constructors) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# Programming Guide](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
- [Constructors](./constructors.md)
- [Static Classes and Static Class Members](./static-classes-and-static-class-members.md)
- [Finalizers](./finalizers.md)
- [Constructor Design Guidelines](../../../standard/design-guidelines/constructor.md#type-constructor-guidelines)
- [Security Warning - CA2121: Static constructors should be private](/visualstudio/code-quality/ca2121-static-constructors-should-be-private)
- [Module initializers](../../language-reference/attributes/general.md#moduleinitializer-attribute)
