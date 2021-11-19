---
title: "Partial Classes and Methods - C# Programming Guide"
description: Partial classes and methods in C# split the definition of a class, a struct, an interface, or a method over two or more source files.
ms.date: 06/21/2021
helpviewer_keywords:
  - "partial methods [C#]"
  - "partial classes [C#]"
  - "C# language, partial classes and methods"
ms.assetid: 804cecb7-62db-4f97-a99f-60975bd59fa1
---
# Partial Classes and Methods (C# Programming Guide)

It is possible to split the definition of a [class](../../language-reference/keywords/class.md), a [struct](../../language-reference/builtin-types/struct.md), an [interface](../../language-reference/keywords/interface.md) or a method over two or more source files. Each source file contains a section of the type or method definition, and all parts are combined when the application is compiled.

## Partial Classes

There are several situations when splitting a class definition is desirable:

- When working on large projects, spreading a class over separate files enables multiple programmers to work on it at the same time.
- When working with automatically generated source, code can be added to the class without having to recreate the source file. Visual Studio uses this approach when it creates Windows Forms, Web service wrapper code, and so on. You can create code that uses these classes without having to modify the file created by Visual Studio.
- When using [source generators](../../roslyn-sdk/source-generators-overview.md) to generate additional functionality in a class.

To split a class definition, use the [partial](../../language-reference/keywords/partial-type.md) keyword modifier, as shown here:

  [!code-csharp[EmployeeExample#1](snippets/partial-classes-and-methods/Program.cs#1)]

The `partial` keyword indicates that other parts of the class, struct, or interface can be defined in the namespace. All the parts must use the `partial` keyword. All the parts must be available at compile time to form the final type. All the parts must have the same accessibility, such as `public`, `private`, and so on.

If any part is declared abstract, then the whole type is considered abstract. If any part is declared sealed, then the whole type is considered sealed. If any part declares a base type, then the whole type inherits that class.

All the parts that specify a base class must agree, but parts that omit a base class still inherit the base type. Parts can specify different base interfaces, and the final type implements all the interfaces listed by all the partial declarations. Any class, struct, or interface members declared in a partial definition are available to all the other parts. The final type is the combination of all the parts at compile time.

> [!NOTE]
> The `partial` modifier is not available on delegate or enumeration declarations.

The following example shows that nested types can be partial, even if the type they are nested within is not partial itself.

[!code-csharp[NestedPartialTypes#2](snippets/partial-classes-and-methods/Program.cs#2)]

At compile time, attributes of partial-type definitions are merged. For example, consider the following declarations:

[!code-csharp[PartialMoonDeclarations#3](snippets/partial-classes-and-methods/Program.cs#3)]

They are equivalent to the following declarations:

[!code-csharp[SingleMoonDeclaration#4](snippets/partial-classes-and-methods/Program.cs#4)]

The following are merged from all the partial-type definitions:

- XML comments
- interfaces
- generic-type parameter attributes
- class attributes
- members

For example, consider the following declarations:

[!code-csharp[PartialEarthDeclarations#5](snippets/partial-classes-and-methods/Program.cs#5)]

They are equivalent to the following declarations:

[!code-csharp[SingleEarthDeclaration#6](snippets/partial-classes-and-methods/Program.cs#6)]

### Restrictions

There are several rules to follow when you are working with partial class definitions:

- All partial-type definitions meant to be parts of the same type must be modified with `partial`. For example, the following class declarations generate an error:
  [!code-csharp[AllDefinitionsMustBePartials#7](snippets/partial-classes-and-methods/Program.cs#7)]
- The `partial` modifier can only appear immediately before the keywords `class`, `struct`, or `interface`.
- Nested partial types are allowed in partial-type definitions as illustrated in the following example:
  [!code-csharp[NestedPartialTypes#8](snippets/partial-classes-and-methods/Program.cs#8)]
- All partial-type definitions meant to be parts of the same type must be defined in the same assembly and the same module (.exe or .dll file). Partial definitions cannot span multiple modules.
- The class name and generic-type parameters must match on all partial-type definitions. Generic types can be partial. Each partial declaration must use the same parameter names in the same order.
- The following keywords on a partial-type definition are optional, but if present on one partial-type definition, cannot conflict with the keywords specified on another partial definition for the same type:
  - [public](../../language-reference/keywords/public.md)
  - [private](../../language-reference/keywords/private.md)
  - [protected](../../language-reference/keywords/protected.md)
  - [internal](../../language-reference/keywords/internal.md)
  - [abstract](../../language-reference/keywords/abstract.md)
  - [sealed](../../language-reference/keywords/sealed.md)
  - base class
  - [new](../../language-reference/keywords/new-modifier.md) modifier (nested parts)
  - generic constraints

For more information, see [Constraints on Type Parameters](../generics/constraints-on-type-parameters.md).

## Examples

In the following example, the fields and the constructor of the class, `Coords`, are declared in one partial class definition, and the member, `PrintCoords`, is declared in another partial class definition.

[!code-csharp[CoordsExample#9](snippets/partial-classes-and-methods/Program.cs#9)]

The following example shows that you can also develop partial structs and interfaces.

[!code-csharp[PartialStructsAndInterfaces#10](snippets/partial-classes-and-methods/Program.cs#10)]

## Partial Methods

A partial class or struct may contain a partial method. One part of the class contains the signature of the method. An implementation can be defined in the same part or another part. If the implementation is not supplied, then the method and all calls to the method are removed at compile time. Implementation may be required depending on method signature. A partial method isn't required to have an implementation in the following cases:

- It doesn't have any accessibility modifiers (including the default [private](../../language-reference/keywords/private.md)).
- It returns [void](../../language-reference/builtin-types/void.md).
- It doesn't have any [out](../../language-reference/keywords/out-parameter-modifier.md) parameters.
- It doesn't have any of the following modifiers [virtual](../../language-reference/keywords/virtual.md), [override](../../language-reference/keywords/override.md), [sealed](../../language-reference/keywords/sealed.md), [new](../../language-reference/keywords/new-modifier.md), or [extern](../../language-reference/keywords/extern.md).

Any method that doesn't conform to all those restrictions (for example, `public virtual partial void` method), must provide an implementation. That implementation may be supplied by a *source generator*.

Partial methods enable the implementer of one part of a class to declare a method. The implementer of another part of the class can define that method. There are two scenarios where this is useful: templates that generate boilerplate code, and source generators.

- **Template code**: The template reserves a method name and signature so that generated code can call the method. These methods follow the restrictions that enable a developer to decide whether to implement the method. If the method is not implemented, then the compiler removes the method signature and all calls to the method. The calls to the method, including any results that would occur from evaluation of arguments in the calls, have no effect at run time. Therefore, any code in the partial class can freely use a partial method, even if the implementation is not supplied. No compile-time or run-time errors will result if the method is called but not implemented.
- **Source generators**: Source generators provide an implementation for methods. The human developer can add the method declaration (often with attributes read by the source generator). The developer can write code that calls these methods. The source generator runs during compilation and provides the implementation. In this scenario, the restrictions for partial methods that may not be implemented often aren't followed.

```csharp
// Definition in file1.cs
partial void OnNameChanged();

// Implementation in file2.cs
partial void OnNameChanged()
{
  // method body
}
```

- Partial method declarations must begin with the contextual keyword [partial](../../language-reference/keywords/partial-type.md).
- Partial method signatures in both parts of the partial type must match.
- Partial methods can have [static](../../language-reference/keywords/static.md) and [unsafe](../../language-reference/keywords/unsafe.md) modifiers.
- Partial methods can be generic. Constraints are put on the defining partial method declaration, and may optionally be repeated on the implementing one. Parameter and type parameter names do not have to be the same in the implementing declaration as in the defining one.
- You can make a [delegate](../../language-reference/builtin-types/reference-types.md) to a partial method that has been defined and implemented, but not to a partial method that has only been defined.

## C# Language Specification

For more information, see [Partial types](~/_csharplang/spec/classes.md#partial-types) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Programming Guide](../index.md)
- [Classes](../../fundamentals/types/classes.md)
- [Structure types](../../language-reference/builtin-types/struct.md)
- [Interfaces](../../fundamentals/types/interfaces.md)
- [partial (Type)](../../language-reference/keywords/partial-type.md)
