---
title: "Partial Classes and Members"
description: Partial classes and members in C# split the definition of a class, a struct, an interface, or a member over two or more source files.
ms.date: 03/11/2025
helpviewer_keywords:
  - "partial methods [C#]"
  - "partial members [C#]"
  - "partial classes [C#]"
  - "C# language, partial classes and methods"
---
# Partial Classes and Members (C# Programming Guide)

It's possible to split the definition of a [class](../../language-reference/keywords/class.md), a [struct](../../language-reference/builtin-types/struct.md), an [interface](../../language-reference/keywords/interface.md), or a member over two or more source files. Each source file contains a section of the type or member definition, and all parts are combined when the application is compiled.

## Partial Classes

There are several situations when splitting a class definition is desirable:

- Declaring a class over separate files enables multiple programmers to work on it at the same time.
- You can add code to the class without having to recreate the source file that includes automatically generated source. Visual Studio uses this approach when it creates Windows Forms, Web service wrapper code, and so on. You can create code that uses these classes without having to modify the file created by Visual Studio.
- [Source generators](../../roslyn-sdk/index.md#source-generators) can generate extra functionality in a class.

To split a class definition, use the [partial](../../language-reference/keywords/partial-type.md) keyword modifier. In practice, each partial class is typically defined in a separate file, making it easier to manage and expand the class over time.

The following `Employee` example demonstrates how the class might be divided across two files: Employee_Part1.cs and Employee_Part2.cs.

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet1":::

The `partial` keyword indicates that other parts of the class, struct, or interface can be defined in the namespace. All the parts must use the `partial` keyword. All the parts must be available at compile time to form the final type. All the parts must have the same accessibility, such as `public`, `private`, and so on.

If any part is declared abstract, then the whole type is considered abstract. If any part is declared sealed, then the whole type is considered sealed. If any part declares a base type, then the whole type inherits that class.

All the parts that specify a base class must agree, but parts that omit a base class still inherit the base type. Parts can specify different base interfaces, and the final type implements all the interfaces listed by all the partial declarations. Any class, struct, or interface members declared in a partial definition are available to all the other parts. The final type is the combination of all the parts at compile time.

> [!NOTE]
> The `partial` modifier isn't available on delegate or enumeration declarations.

The following example shows that nested types can be partial, even if the type they're nested within isn't partial itself.

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet2":::

At compile time, attributes of partial-type definitions are merged. For example, consider the following declarations:

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet3":::

They're equivalent to the following declarations:

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet4":::

The following are merged from all the partial-type definitions:

- XML comments. However, if both declarations of a partial member include comments, only the comments from the implementing member are included.
- interfaces
- generic-type parameter attributes
- class attributes
- members

For example, consider the following declarations:

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet5":::

They're equivalent to the following declarations:

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet6":::

### Restrictions

There are several rules to follow when you're working with partial class definitions:

- All partial-type definitions meant to be parts of the same type must be modified with `partial`. For example, the following class declarations generate an error:
  :::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet7":::
- The `partial` modifier can only appear immediately before the keyword `class`, `struct`, or `interface`.
- Nested partial types are allowed in partial-type definitions as illustrated in the following example:
  :::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet8":::
- All partial-type definitions meant to be parts of the same type must be defined in the same assembly and the same module (.exe or .dll file). Partial definitions can't span multiple modules.
- The class name and generic-type parameters must match on all partial-type definitions. Generic types can be partial. Each partial declaration must use the same parameter names in the same order.
- The following keywords on a partial-type definition are optional, but if present on one partial-type definition, the same must be specified on other partial definition for the same type:
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

In the following example, the fields and constructor of the `Coords` class are declared in one partial class definition (`Coords_Part1.cs`), and the `PrintCoords` method is declared in another partial class definition (`Coords_Part2.cs`). This separation demonstrates how partial classes can be divided across multiple files for easier maintainability.

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet9":::

The following example shows that you can also develop partial structs and interfaces.

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="Snippet10":::

## Partial Members

A partial class or struct can contain a partial member. One part of the class contains the signature of the member. An implementation can be defined in the same part or another part.

An implementation isn't required for a partial method when the signature obeys the following rules:

- The declaration doesn't include any access modifiers. The method has [`private`](../../language-reference/keywords/private.md) access by default.
- The return type is [`void`](../../language-reference/builtin-types/void.md).
- None of the parameters have the [`out`](../../language-reference/keywords/method-parameters.md#out-parameter-modifier) modifier.
- The method declaration can't include any of the following modifiers:
  - [virtual](../../language-reference/keywords/virtual.md)
  - [override](../../language-reference/keywords/override.md)
  - [sealed](../../language-reference/keywords/sealed.md)
  - [new](../../language-reference/keywords/new-modifier.md)
  - [extern](../../language-reference/keywords/extern.md)

The method and all calls to the method are removed at compile time when there's no implementation.

Any member that doesn't conform to all those restrictions, including constructors, properties, indexers, and events, must provide an implementation. That implementation might be supplied by a *source generator*. [Partial properties](../../language-reference/keywords/partial-member.md) can't be implemented using automatically implemented properties. The compiler can't distinguish between an automatically implemented property, and the declaring declaration of a partial property.

Beginning with C# 13, the implementing declaration for a partial property can use [field backed properties](../../language-reference/keywords/field.md) to define the implementing declaration. A field backed property provides a concise syntax where the `field` keyword accesses the compiler synthesized backing field for the property. For example, you could write the following code:

:::code language="csharp" source="snippets/partial-classes-and-methods/Program.cs" id="FieldProperty":::

You can use `field` in either the `get` or `set` accessor, or both.

[!INCLUDE[field-preview](../../includes/field-preview.md)]

Partial members enable the implementer of one part of a class to declare a member. The implementer of another part of the class can define that member. There are two scenarios where this separation is useful: templates that generate boilerplate code, and source generators.

- **Template code**: The template reserves a method name and signature so that generated code can call the method. These methods follow the restrictions that enable a developer to decide whether to implement the method. If the method isn't implemented, then the compiler removes the method signature and all calls to the method. The calls to the method, including any results that would occur from evaluation of arguments in the calls, have no effect at run time. Therefore, any code in the partial class can freely use a partial method, even if the implementation isn't supplied. No compile-time or run-time errors result if the method is called but not implemented.
- **Source generators**: Source generators provide an implementation for members. The human developer can add the member declaration (often with attributes read by the source generator). The developer can write code that calls these members. The source generator runs during compilation and provides the implementation. In this scenario, the restrictions for partial members that might not be implemented often aren't followed.

```csharp
// Definition in file1.cs
partial void OnNameChanged();

// Implementation in file2.cs
partial void OnNameChanged()
{
  // method body
}
```

- Partial member declarations must begin with the contextual keyword [partial](../../language-reference/keywords/partial-type.md).
- Partial member signatures in both parts of the partial type must match.
- Partial member can have [static](../../language-reference/keywords/static.md) and [unsafe](../../language-reference/keywords/unsafe.md) modifiers.
- Partial member can be generic. Constraints must be the same on the defining and implementing member declaration. Parameter and type parameter names don't have to be the same in the implementing declaration as in the defining one.
- You can make a [delegate](../../language-reference/builtin-types/reference-types.md) to a partial method defined and implemented, but not to a partial method that doesn't have an implementation.

## C# Language Specification

For more information, see [Partial types](~/_csharpstandard/standard/classes.md#1527-partial-type-declarations) and [Partial methods](~/_csharpstandard/standard/classes.md#1569-partial-methods) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage. The new features for partial members are defined in the feature specifications for [extending partial methods](~/_csharplang/proposals/csharp-9.0/extending-partial-methods.md), [partial properties and indexers](~/csharplan/proposals/csharp-13.0/partial-properties.md), and [partial events and constructors](~/csharplang/proposals/partial-events-constructors.md).

## See also

- [Classes](../../fundamentals/types/classes.md)
- [Structure types](../../language-reference/builtin-types/struct.md)
- [Interfaces](../../fundamentals/types/interfaces.md)
- [partial (Type)](../../language-reference/keywords/partial-type.md)
