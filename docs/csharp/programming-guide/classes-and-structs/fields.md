---
title: Fields - C# Programming Guide
description: A field in C# is a variable of any type that is declared directly in a class or struct. Fields are members of their containing type.
ms.date: 07/20/2015
helpviewer_keywords:
  - "fields [C#]"
ms.assetid: 3cbb2f61-75f8-4cce-b4ef-f5d1b3de0db7
---
# Fields (C# Programming Guide)

A *field* is a variable of any type that is declared directly in a [class](../../language-reference/keywords/class.md) or [struct](../../language-reference/builtin-types/struct.md). Fields are *members* of their containing type.

A class or struct may have instance fields, static fields, or both. Instance fields are specific to an instance of a type. If you have a class T, with an instance field F, you can create two objects of type T, and modify the value of F in each object without affecting the value in the other object. By contrast, a static field belongs to the type itself, and is shared among all instances of that type. You can access the static field only by using the type name. If you access the static field by an instance name, you get [CS0176](../../misc/cs0176.md) compile-time error.

Generally, you should use fields only for variables that have private or protected accessibility. Data that your type exposes to client code should be provided through [methods](./methods.md), [properties](./properties.md), and [indexers](../indexers/index.md). By using these constructs for indirect access to internal fields, you can guard against invalid input values. A private field that stores the data exposed by a public property is called a *backing store* or *backing field*.

Fields typically store the data that must be accessible to more than one type method and must be stored for longer than the lifetime of any single method. For example, a type that represents a calendar date might have three integer fields: one for the month, one for the day, and one for the year. Variables that are not used outside the scope of a single method should be declared as *local variables* within the method body itself.

Fields are declared in the class or struct block by specifying the access level of the field, followed by the type of the field, followed by the name of the field. For example:

[!code-csharp[fields#1](snippets/fields/Program.cs#1)]

To access a field in an instance, add a period after the instance name, followed by the name of the field, as in `instancename._fieldName`. For example:

[!code-csharp[fields#2](snippets/fields/Program.cs#2)]

A field can be given an initial value by using the assignment operator when the field is declared. To automatically assign the `Day` field to `"Monday"`, for example, you would declare `Day` as in the following example:

[!code-csharp[fields#3](snippets/fields/Program.cs#3)]

Fields are initialized immediately before the constructor for the object instance is called. If the constructor assigns the value of a field, it will overwrite any value given during field declaration. For more information, see [Using Constructors](./using-constructors.md).

> [!NOTE]
> A field initializer cannot refer to other instance fields.

Fields can be marked as [public](../../language-reference/keywords/public.md), [private](../../language-reference/keywords/private.md), [protected](../../language-reference/keywords/protected.md), [internal](../../language-reference/keywords/internal.md), [protected internal](../../language-reference/keywords/protected-internal.md), or [private protected](../../language-reference/keywords/private-protected.md). These access modifiers define how users of the type can access the fields. For more information, see [Access Modifiers](./access-modifiers.md).

A field can optionally be declared [static](../../language-reference/keywords/static.md). This makes the field available to callers at any time, even if no instance of the type exists. For more information, see [Static Classes and Static Class Members](./static-classes-and-static-class-members.md).

A field can be declared [readonly](../../language-reference/keywords/readonly.md). A read-only field can only be assigned a value during initialization or in a constructor. A `static readonly` field is very similar to a constant, except that the C# compiler does not have access to the value of a static read-only field at compile time, only at run time. For more information, see [Constants](./constants.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Programming Guide](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
- [Using Constructors](./using-constructors.md)
- [Inheritance](../../fundamentals/object-oriented/inheritance.md)
- [Access Modifiers](./access-modifiers.md)
- [Abstract and Sealed Classes and Class Members](./abstract-and-sealed-classes-and-class-members.md)
