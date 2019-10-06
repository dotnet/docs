---
title: "class keyword - C# Reference"
ms.custom: seodec18

ms.date: 07/18/2017
f1_keywords: 
  - "class_CSharpKeyword"
  - "class"
helpviewer_keywords: 
  - "class keyword [C#]"
ms.assetid: b95d8815-de18-4c3f-a8cc-a0a53bdf8690
---
# class (C# Reference)

Classes are declared using the keyword `class`, as shown in the following example:

```csharp
class TestClass
{
    // Methods, properties, fields, events, delegates
    // and nested classes go here.
}
```

## Remarks

Only single inheritance is allowed in C#. In other words, a class can inherit implementation from one base class only. However, a class can implement more than one interface. The following table shows examples of class inheritance and interface implementation:

|Inheritance|Example|
|-----------------|-------------|
|None|`class ClassA { }`|
|Single|`class DerivedClass: BaseClass { }`|
|None, implements two interfaces|`class ImplClass: IFace1, IFace2 { }`|
|Single, implements one interface|`class ImplDerivedClass: BaseClass, IFace1 { }`|

Classes that you declare directly within a namespace, not nested within other classes, can be either [public](./public.md) or [internal](./internal.md). Classes are `internal` by default.

Class members, including nested classes, can be [public](public.md), [protected internal](protected-internal.md), [protected](protected.md), [internal](internal.md), [private](private.md), or [private protected](private-protected.md). Members are `private` by default.

For more information, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

You can declare generic classes that have type parameters. For more information, see [Generic Classes](../../programming-guide/generics/generic-classes.md).

A class can contain declarations of the following members:

- [Constructors](../../programming-guide/classes-and-structs/constructors.md)

- [Constants](../../programming-guide/classes-and-structs/constants.md)

- [Fields](../../programming-guide/classes-and-structs/fields.md)

- [Finalizers](../../programming-guide/classes-and-structs/destructors.md)

- [Methods](../../programming-guide/classes-and-structs/methods.md)

- [Properties](../../programming-guide/classes-and-structs/properties.md)

- [Indexers](../../programming-guide/indexers/index.md)

- [Operators](../operators/index.md)

- [Events](../../programming-guide/events/index.md)

- [Delegates](../../programming-guide/delegates/index.md)

- [Classes](../../programming-guide/classes-and-structs/classes.md)

- [Interfaces](../../programming-guide/interfaces/index.md)

- [Structs](../../programming-guide/classes-and-structs/structs.md)

- [Enumerations](../../programming-guide/enumeration-types.md)

## Example

The following example demonstrates declaring class fields, constructors, and methods. It also demonstrates object instantiation and printing instance data. In this example, two classes are declared. The first class, `Child`, contains two private fields (`name` and `age`), two public constructors and one public method. The second class, `StringTest`, is used to contain `Main`.

[!code-csharp[csrefKeywordsTypes#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#5)]

## Comments

Notice that in the previous example the private fields (`name` and `age`) can only be accessed through the public method of the `Child` class. For example, you cannot print the child's name, from the `Main` method, using a statement like this:

```csharp
Console.Write(child1.name);   // Error
```

Accessing private members of `Child` from `Main` would only be possible if `Main` were a member of the class.

Types declared inside a class without an access modifier default to `private`, so the data members in this example would still be `private` if the keyword were removed.

Finally, notice that for the object created using the parameterless constructor (`child3`), the `age` field was initialized to zero by default.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [Reference Types](./reference-types.md)
