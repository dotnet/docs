---
title: Access Control
description: Learn how to control access to programming elements, such as types, methods, and functions, in the F# programming language.
ms.date: 05/16/2016
---
# Access Control

*Access control* refers to declaring which clients can use certain program elements, such as types, methods, and functions.

## Basics of Access Control

In F#, the access control specifiers `public`, `internal`, and `private` can be applied to modules, types, methods, value definitions, functions, properties, and explicit fields.

- `public` indicates that the entity can be accessed by all callers.

- `internal` indicates that the entity can be accessed only from the same assembly.

- `private` indicates that the entity can be accessed only from the enclosing type or module.

> [!NOTE]
> The access specifier `protected` is not used in F#, although it is acceptable if you are using types authored in languages that do support `protected` access. Therefore, if you override a protected method, your method remains accessible only within the class and its descendents.

In general, the specifier is put in front of the name of the entity, except when a `mutable` or `inline` specifier is used, which appear after the access control specifier.

If no access specifier is used, the default is `public`, except for `let` bindings in a type, which are always `private` to the type.

Signatures in F# provide another mechanism for controlling access to F# program elements. Signatures are not required for access control. For more information, see [Signatures](signature-files.md).

## Rules for Access Control

Access control is subject to the following rules:

- Inheritance declarations (that is, the use of `inherit` to specify a base class for a class), interface declarations (that is, specifying that a class implements an interface), and abstract members always have the same accessibility as the enclosing type. Therefore, an access control specifier cannot be used on these constructs.

- Accessibility for individual cases in a discriminated union is determined by the accessibility of the discriminated union itself. That is, a particular union case is no less accessible than the union itself.

- Accessibility for individual fields of a record type is determined by the accessibility of the record itself. That is, a particular record label is no less accessible than the record itself.

## Example

The following code illustrates the use of access control specifiers. There are two files in the project, `Module1.fs` and `Module2.fs`. Each file is implicitly a module. Therefore, there are two modules, `Module1` and `Module2`. A private type and an internal type are defined in `Module1`. The private type cannot be accessed from `Module2`, but the internal type can.

[!code-fsharp[Main](~/samples/snippets/fsharp/access-control/snippet1.fs)]

The following code tests the accessibility of the types created in `Module1.fs`.

[!code-fsharp[Main](~/samples/snippets/fsharp/access-control/snippet2.fs)]

## See also

- [F# Language Reference](index.md)
- [Signatures](signature-files.md)
