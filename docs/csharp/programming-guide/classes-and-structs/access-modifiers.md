---
title: "Access Modifiers - C# Programming Guide"
description: All types and type members in C# have an accessibility level which controls whether they can be used from other code. Review this list of access modifiers.
ms.date: 03/08/2020
helpviewer_keywords: 
  - "C# Language, access modifiers"
  - "access modifiers [C#], about"
ms.assetid: 6e81ee82-224f-4a12-9baf-a0dca2656c5b
---
# Access Modifiers (C# Programming Guide)

All types and type members have an accessibility level. The accessibility level controls whether they can be used from other code in your assembly or other assemblies. Use the following access modifiers to specify the accessibility of a type or member when you declare it:

- [public](../../language-reference/keywords/public.md): The type or member can be accessed by any other code in the same assembly or another assembly that references it. The accessibility level of public members of a type is controlled by the accessibility level of the type itself.
- [private](../../language-reference/keywords/private.md): The type or member can be accessed only by code in the same `class` or `struct`.
- [protected](../../language-reference/keywords/protected.md): The type or member can be accessed only by code in the same `class`, or in a `class` that is derived from that `class`.
- [internal](../../language-reference/keywords/internal.md): The type or member can be accessed by any code in the same assembly, but not from another assembly.
- [protected internal](../../language-reference/keywords/protected-internal.md): The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived `class` in another assembly.
- [private protected](../../language-reference/keywords/private-protected.md): The type or member can be accessed by types derived from the `class` that are declared within its containing assembly.

## Summary table

| Caller's location                      | `public` | `protected internal` | `protected` | `internal` | `private protected` | `private` |
| -------------------------------------- | :------: | :------------------: | :---------: | :--------: | :-----------------: | :-------: |
| Within the class                       |    ✔️️     |          ✔️           |      ✔️      |     ✔️      |          ✔️          |     ✔️     |
| Derived class (same assembly)          |    ✔️     |          ✔️           |      ✔️      |     ✔️      |          ✔️          |     ❌     |
| Non-derived class (same assembly)      |    ✔️     |          ✔️           |      ❌      |     ✔️      |          ❌          |     ❌     |
| Derived class (different assembly)     |    ✔️     |          ✔️           |      ✔️      |     ❌      |          ❌          |     ❌     |
| Non-derived class (different assembly) |    ✔️     |          ❌           |      ❌      |     ❌      |          ❌          |     ❌     |

The following examples demonstrate how to specify access modifiers on a type and member:

[!code-csharp[PublicAccess](~/samples/snippets/csharp/objectoriented/accessmodifiers.cs#PublicAccess)]

Not all access modifiers are valid for all types or members in all contexts. In some cases, the accessibility of a type member is constrained by the accessibility of its containing type.

## Class, record, and struct accessibility  

Classes, records, and structs declared directly within a namespace (in other words, that aren't nested within other classes or structs) can be either `public` or `internal`. `internal` is the default if no access modifier is specified.

Struct members, including nested classes and structs, can be declared `public`, `internal`, or `private`. Class members, including nested classes and structs, can be `public`, `protected internal`, `protected`, `internal`, `private protected`, or `private`. Class and struct members,  including nested classes and structs, have `private` access by default. Private nested types aren't accessible from outside the containing type.

Derived classes and derived records can't have greater accessibility than their base types. You can't declare a public class `B` that derives from an internal class `A`. If allowed, it would have the effect of making `A` public, because all `protected` or `internal` members of `A` are accessible from the derived class.

You can enable specific other assemblies to access your internal types by using the `InternalsVisibleToAttribute`. For more information, see [Friend Assemblies](../../../standard/assembly/friend.md).

## Class, record, and struct member accessibility  

Class and record members (including nested classes, records and structs) can be declared with any of the six types of access. Struct members can't be declared as `protected`, `protected internal`, or `private protected` because structs don't support inheritance.

Normally, the accessibility of a member isn't greater than the accessibility of the type that contains it. However, a `public` member of an internal class might be accessible from outside the assembly if the member implements interface methods or overrides virtual methods that are defined in a public base class.

The type of any member field, property, or event must be at least as accessible as the member itself. Similarly, the return type and the parameter types of any method, indexer, or delegate must be at least as accessible as the member itself. For example, you can't have a `public` method `M` that returns a class `C` unless `C` is also `public`. Likewise, you can't have a `protected` property of type `A` if `A` is declared as `private`.

User-defined operators must always be declared as `public` and `static`. For more information, see [Operator overloading](../../language-reference/operators/operator-overloading.md).

Finalizers can't have accessibility modifiers.

To set the access level for a `class`, `record`, or `struct` member, add the appropriate keyword to the member declaration, as shown in the following example.

[!code-csharp[MethodAccess](~/samples/snippets/csharp/objectoriented/accessmodifiers.cs#MethodAccess)]

## Other types

Interfaces declared directly within a namespace can be `public` or `internal` and, just like classes and structs, interfaces default to `internal` access. Interface members are `public` by default because the purpose of an interface is to enable other types to access a class or struct. Interface member declarations may include any access modifier. This is most useful for static methods to provide common implementations needed by all implementors of a class.

Enumeration members are always `public`, and no access modifiers can be applied.

Delegates behave like classes and structs. By default, they have `internal` access when declared directly within a namespace, and `private` access when nested.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  

## See also

- [C# Programming Guide](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
- [Interfaces](../../fundamentals/types/interfaces.md)
- [private](../../language-reference/keywords/private.md)
- [public](../../language-reference/keywords/public.md)
- [internal](../../language-reference/keywords/internal.md)
- [protected](../../language-reference/keywords/protected.md)
- [protected internal](../../language-reference/keywords/protected-internal.md)
- [private protected](../../language-reference/keywords/private-protected.md)
- [class](../../language-reference/keywords/class.md)
- [struct](../../language-reference/builtin-types/struct.md)
- [interface](../../language-reference/keywords/interface.md)
