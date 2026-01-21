---
description: "class keyword - C# Reference"
title: "class keyword"
ms.date: 01/21/2026
f1_keywords: 
  - "class_CSharpKeyword"
  - "class"
helpviewer_keywords: 
  - "class keyword [C#]"
---
# class (C# Reference)

Declare classes by using the `class` keyword, as shown in the following example:

```csharp
class TestClass
{
    // Methods, properties, fields, events, delegates
    // and nested classes go here.
}
```

C# supports only single inheritance. In other words, a class can inherit implementation from one base class only. However, a class can implement more than one interface.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The following table shows examples of class inheritance and interface implementation:

| Inheritance                      | Example                                          |
|----------------------------------|--------------------------------------------------|
| None                             | `class ClassA { }`                               |
| Single                           | `class DerivedClass : BaseClass { }`             |
| None, implements two interfaces  | `class ImplClass : IFace1, IFace2 { }`           |
| Single, implements one interface | `class ImplDerivedClass : BaseClass, IFace1 { }` |

You can declare classes directly within a namespace. Don't nest these classes within other classes. You can make these classes either [`public`](./public.md) or [`internal`](./internal.md). By default, classes are `internal`.

You can declare class members, including nested classes, as [`public`](public.md), [`protected internal`](protected-internal.md), [`protected`](protected.md), [`internal`](internal.md), [`private`](private.md), or [`private protected`](private-protected.md). By default, members are `private`.

For more information, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

You can declare generic classes that have type parameters. For more information, see [Generic Classes](../../programming-guide/generics/generic-classes.md).

A class can contain declarations of the following members:

- [Constructors](../../programming-guide/classes-and-structs/constructors.md)
- [Constants](../../programming-guide/classes-and-structs/constants.md)
- [Fields](../../programming-guide/classes-and-structs/fields.md)
- [Finalizers](../../programming-guide/classes-and-structs/finalizers.md)
- [Methods](../../programming-guide/classes-and-structs/methods.md)
- [Properties](../../programming-guide/classes-and-structs/properties.md)
- [Indexers](../../programming-guide/indexers/index.md)
- [Operators](../operators/index.md)
- [Events](../../programming-guide/events/index.md)
- [Delegates](../../programming-guide/delegates/index.md)
- [Classes](../../fundamentals/types/classes.md)
- [Interfaces](../../fundamentals/types/interfaces.md)
- [Structure types](../builtin-types/struct.md)
- [Enumeration types](../builtin-types/enum.md)

## Example

The following example demonstrates declaring class fields, constructors, and methods. It also demonstrates object instantiation and printing instance data. In this example, two classes are declared. The first class, `Child`, contains two private fields (`name` and `age`), two public constructors, and one public method. The second class, `StringTest`, contains `Main`.

:::code language="csharp" source="./snippets/keywordsTypes.cs" id="5":::

## Comments

You can only access the private fields (`name` and `age`) through the public method of the `Child` class. For example, you can't print the child's name from the `Main` method by using a statement like this:

```csharp
Console.Write(child1.name);   // Error
```

Accessing private members of `Child` from `Main` is only possible if `Main` is a member of the class. Types declared inside a class without an access modifier default to `private`, so the data members in this example are still `private` if the keyword is removed. Finally, for the object created by using the parameterless constructor (`child3`), the `age` field is initialized to zero by default.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](./index.md)
- [Reference Types](./reference-types.md)
