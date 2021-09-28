---
description: "Learn more about: Protected (Visual Basic)"
title: "Protected"
ms.date: 07/20/2015
f1_keywords:
  - "vb.Protected"
helpviewer_keywords:
  - "Protected Friend keyword combination"
  - "Protected keyword [Visual Basic], and Friend"
  - "Protected keyword [Visual Basic], syntax"
  - "Protected access modifier"
  - "Protected keyword [Visual Basic]"
ms.assetid: 74ad3d56-309f-49d2-b60c-1d0157d010e8
---
# Protected (Visual Basic)

A member access modifier that specifies that one or more declared programming elements are accessible only from within their own class or from a derived class.

## Remarks

Sometimes a programming element declared in a class contains sensitive data or restricted code, and you want to limit access to the element. However, if the class is inheritable and you expect a hierarchy of derived classes, it might be necessary for these derived classes to access the data or code. In such a case, you want the element to be accessible both from the base class and from all derived classes. To limit access to an element in this manner, you can declare it with `Protected`.

> [!NOTE]
> The `Protected` access modifier can be combined with two other modifiers:
>
> - The [Protected Friend](protected-friend.md) modifier makes a class member accessible from within that class, from derived classes, and from the same assembly in which the class is defined.
> - The [Private Protected](private-protected.md) modifier makes a class member accessible by derived types, but only within its containing assembly.

## Rules

**Declaration Context.** You can use `Protected` only at the class level. This means the declaration context for a `Protected` element must be a class, and cannot be a source file, namespace, interface, module, structure, or procedure.

## Behavior

- **Access Level.** All code in a class can access its elements. Code in any class that derives from a base class can access all the `Protected` elements of the base class. This is true for all generations of derivation. This means that a class can access `Protected` elements of the base class of the base class, and so on.

     Protected access is not a superset or subset of friend access.

- **Access Modifiers.** The keywords that specify access level are called *access modifiers*. For a comparison of the access modifiers, see [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).

The `Protected` modifier can be used in these contexts:

- [Class Statement](../statements/class-statement.md)

- [Const Statement](../statements/const-statement.md)

- [Declare Statement](../statements/declare-statement.md)

- [Delegate Statement](../statements/delegate-statement.md)

- [Dim Statement](../statements/dim-statement.md)

- [Enum Statement](../statements/enum-statement.md)

- [Event Statement](../statements/event-statement.md)

- [Function Statement](../statements/function-statement.md)

- [Interface Statement](../statements/interface-statement.md)

- [Property Statement](../statements/property-statement.md)

- [Structure Statement](../statements/structure-statement.md)

- [Sub Statement](../statements/sub-statement.md)

## See also

- [Public](public.md)
- [Friend](friend.md)
- [Private](private.md)
- [Private Protected](private-protected.md)
- [Protected Friend](protected-friend.md)
- [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md)
- [Procedures](../../programming-guide/language-features/procedures/index.md)
- [Structures](../../programming-guide/language-features/data-types/structures.md)
- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
