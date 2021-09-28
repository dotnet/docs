---
description: "Learn more about: Overrides (Visual Basic)"
title: "Overrides"
ms.date: 07/20/2015
f1_keywords:
  - "Overrides"
  - "vb.Overrides"
helpviewer_keywords:
  - "properties [Visual Basic], redefining"
  - "procedures [Visual Basic], overriding"
  - "procedures [Visual Basic], redefining"
  - "overriding"
  - "Overrides keyword [Visual Basic]"
  - "overriding, Overrides keyword"
  - "properties [Visual Basic], overriding"
ms.assetid: 9f5e6144-ce10-465e-842b-1a8f8760af90
---
# Overrides (Visual Basic)

Specifies that a property or procedure overrides an identically named property or procedure inherited from a base class.

## Rules

- **Declaration Context.** You can use `Overrides` only in a property or procedure declaration statement.

- **Combined Modifiers.** You cannot specify `Overrides` together with `Shadows` or `Shared` in the same declaration. Because an overriding element is implicitly overridable, you cannot combine `Overridable` with `Overrides`.

- **Matching Signatures.** The signature of this declaration must exactly match the *signature* of the property or procedure that it overrides. This means the parameter lists must have the same number of parameters, in the same order, with the same data types.

  In addition to the signature, the overriding declaration must also exactly match the following:

  - The access level

  - The return type, if any

- **Generic Signatures.** For a generic procedure, the signature includes the number of type parameters. Therefore, the overriding declaration must match the base class version in that respect as well.

- **Additional Matching.** In addition to matching the signature of the base class version, this declaration must also match it in the following respects:

  - Access-level modifier (such as [Public](public.md))

  - Passing mechanism of each parameter ([ByVal](byval.md) or [ByRef](byref.md))

  - Constraint lists on each type parameter of a generic procedure

- **Shadowing and Overriding.** Both shadowing and overriding redefine an inherited element, but there are significant differences between the two approaches. For more information, see [Shadowing in Visual Basic](../../programming-guide/language-features/declared-elements/shadowing.md).

If you use `Overrides`, the compiler implicitly adds `Overloads` so that your library APIs work with C# more easily.

The `Overrides` modifier can be used in these contexts:

- [Function Statement](../statements/function-statement.md)

- [Property Statement](../statements/property-statement.md)

- [Sub Statement](../statements/sub-statement.md)

## See also

- [MustOverride](mustoverride.md)
- [NotOverridable](notoverridable.md)
- [Overridable](overridable.md)
- [Keywords](../keywords/index.md)
- [Shadowing in Visual Basic](../../programming-guide/language-features/declared-elements/shadowing.md)
- [Generic Types in Visual Basic](../../programming-guide/language-features/data-types/generic-types.md)
- [Type List](../statements/type-list.md)
