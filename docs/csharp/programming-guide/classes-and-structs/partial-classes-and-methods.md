---
title: "Partial Classes and Methods - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords:
  - "partial methods [C#]"
  - "partial classes [C#]"
  - "C# language, partial classes and methods"
ms.assetid: 804cecb7-62db-4f97-a99f-60975bd59fa1
---
# Partial Classes and Methods (C# Programming Guide)

It is possible to split the definition of a [class](../../language-reference/keywords/class.md), a [struct](../../language-reference/keywords/struct.md), an [interface](../../language-reference/keywords/interface.md) or a method over two or more source files. Each source file contains a section of the type or method definition, and all parts are combined when the application is compiled.

## Partial Classes

There are several situations when splitting a class definition is desirable:

- When working on large projects, spreading a class over separate files enables multiple programmers to work on it at the same time.

- When working with automatically generated source, code can be added to the class without having to recreate the source file. Visual Studio uses this approach when it creates Windows Forms, Web service wrapper code, and so on. You can create code that uses these classes without having to modify the file created by Visual Studio.

- To split a class definition, use the [partial](../../language-reference/keywords/partial-type.md) keyword modifier, as shown here:

  [!code-csharp[csProgGuideObjects#26](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#26)]

The `partial` keyword indicates that other parts of the class, struct, or interface can be defined in the namespace. All the parts must use the `partial` keyword. All the parts must be available at compile time to form the final type. All the parts must have the same accessibility, such as `public`, `private`, and so on.

If any part is declared abstract, then the whole type is considered abstract. If any part is declared sealed, then the whole type is considered sealed. If any part declares a base type, then the whole type inherits that class.

All the parts that specify a base class must agree, but parts that omit a base class still inherit the base type. Parts can specify different base interfaces, and the final type implements all the interfaces listed by all the partial declarations. Any class, struct, or interface members declared in a partial definition are available to all the other parts. The final type is the combination of all the parts at compile time.

> [!NOTE]
> The `partial` modifier is not available on delegate or enumeration declarations.

The following example shows that nested types can be partial, even if the type they are nested within is not partial itself.

[!code-csharp[csProgGuideObjects#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#25)]

At compile time, attributes of partial-type definitions are merged. For example, consider the following declarations:

[!code-csharp[csProgGuideObjects#23](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#23)]

They are equivalent to the following declarations:

[!code-csharp[csProgGuideObjects#24](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#24)]

The following are merged from all the partial-type definitions:

- XML comments

- interfaces

- generic-type parameter attributes

- class attributes

- members

For example, consider the following declarations:

[!code-csharp[csProgGuideObjects#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#21)]

They are equivalent to the following declarations:

[!code-csharp[csProgGuideObjects#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#22)]

### Restrictions

There are several rules to follow when you are working with partial class definitions:

- All partial-type definitions meant to be parts of the same type must be modified with `partial`. For example, the following class declarations generate an error:

  [!code-csharp[csProgGuideObjects#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#20)]

- The `partial` modifier can only appear immediately before the keywords `class`, `struct`, or `interface`.

- Nested partial types are allowed in partial-type definitions as illustrated in the following example:

  [!code-csharp[csProgGuideObjects#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#19)]

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

## Example 1

### Description

In the following example, the fields and the constructor of the class, `Coords`, are declared in one partial class definition, and the member, `PrintCoords`, is declared in another partial class definition.

### Code

[!code-csharp[csProgGuideObjects#17](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#17)]

## Example 2

### Description

The following example shows that you can also develop partial structs and interfaces.

### Code

[!code-csharp[csProgGuideObjects#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#18)]

## Partial Methods

A partial class or struct may contain a partial method. One part of the class contains the signature of the method. An optional implementation may be defined in the same part or another part. If the implementation is not supplied, then the method and all calls to the method are removed at compile time.

Partial methods enable the implementer of one part of a class to define a method, similar to an event. The implementer of the other part of the class can decide whether to implement the method or not. If the method is not implemented, then the compiler removes the method signature and all calls to the method. The calls to the method, including any results that would occur from evaluation of arguments in the calls, have no effect at run time. Therefore, any code in the partial class can freely use a partial method, even if the implementation is not supplied. No compile-time or run-time errors will result if the method is called but not implemented.

Partial methods are especially useful as a way to customize generated code. They allow for a method name and signature to be reserved, so that generated code can call the method but the developer can decide whether to implement the method. Much like partial classes, partial methods enable code created by a code generator and code created by a human developer to work together without run-time costs.

A partial method declaration consists of two parts: the definition, and the implementation. These may be in separate parts of a partial class, or in the same part. If there is no implementation declaration, then the compiler optimizes away both the defining declaration and all calls to the method.

```csharp
// Definition in file1.cs
partial void onNameChanged();

// Implementation in file2.cs
partial void onNameChanged()
{
  // method body
}
```

- Partial method declarations must begin with the contextual keyword [partial](../../language-reference/keywords/partial-type.md) and the method must return [void](../../language-reference/keywords/void.md).

- Partial methods can have [in](../../language-reference/keywords/in-parameter-modifier.md) or [ref](../../language-reference/keywords/ref.md) but not [out](../../language-reference/keywords/out-parameter-modifier.md) parameters.

- Partial methods are implicitly [private](../../language-reference/keywords/private.md), and therefore they cannot be [virtual](../../language-reference/keywords/virtual.md).

- Partial methods cannot be [extern](../../language-reference/keywords/extern.md), because the presence of the body determines whether they are defining or implementing.

- Partial methods can have [static](../../language-reference/keywords/static.md) and [unsafe](../../language-reference/keywords/unsafe.md) modifiers.

- Partial methods can be generic. Constraints are put on the defining partial method declaration, and may optionally be repeated on the implementing one. Parameter and type parameter names do not have to be the same in the implementing declaration as in the defining one.

- You can make a [delegate](../../language-reference/keywords/delegate.md) to a partial method that has been defined and implemented, but not to a partial method that has only been defined.

## C# Language Specification

For more information, see [Partial types](~/_csharplang/spec/classes.md#partial-types) in the [C# Language Specification](../../language-reference/language-specification/index.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Programming Guide](../index.md)
- [Classes](./classes.md)
- [Structs](./structs.md)
- [Interfaces](../interfaces/index.md)
- [partial (Type)](../../language-reference/keywords/partial-type.md)
