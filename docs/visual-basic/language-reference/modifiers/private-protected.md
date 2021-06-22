---
description: "Learn more about: Private Protected (Visual Basic)"
title: "Private Protected"
ms.date: 05/10/2018
f1_keywords:
  - "vb.PrivateProtected"
helpviewer_keywords:
  - "Private Protected keyword [Visual Basic]"
  - "Private Protected keyword [Visual Basic], syntax"
---

# Private Protected (Visual Basic)

The `Private Protected` keyword combination is a member access modifier. A `Private Protected` member is accessible by all members in its containing class, as well as by types derived from the containing class, but only if they are found in its containing assembly.

You can specify `Private Protected` only on members of classes; you cannot apply `Private Protected` to members of a structure because structures cannot be inherited.

The `Private Protected` access modifier is supported by Visual Basic 15.5 and later. To use it, you can add the following element to your Visual Basic project (\*.vbproj) file. As long as Visual Basic 15.5 or later is installed on your system, it lets you take advantage of all the language features supported by the latest version of the Visual Basic compiler:

```xml
<PropertyGroup>
   <LangVersion>latest</LangVersion>
</PropertyGroup>
```

For more information see [setting the Visual Basic language version](../configure-language-version.md).

> [!NOTE]
> In Visual Studio, selecting F1 help on `private protected` provides help for either [private](private.md) or [protected](protected.md). The IDE picks the single token under the cursor rather than the compound word.

## Rules

- **Declaration Context.** You can use `Private Protected` only at the class level. This means the declaration context for a `Protected` element must be a class, and cannot be a source file, namespace, interface, module, structure, or procedure.

## Behavior

- **Access Level.** All code in a class can access its elements. Code in any class that derives from a base class and is contained in the same assembly can access all the `Private Protected` elements of the base class. However, code in any class that derives from a base class and is contained in a different assembly can't access the base class `Private Protected` elements.

- **Access Modifiers.** The keywords that specify access level are called *access modifiers*. For a comparison of the access modifiers, see [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).

The `Private Protected` modifier can be used in these contexts:

- [Class Statement](../statements/class-statement.md) of a nested class

- [Const Statement](../statements/const-statement.md)

- [Declare Statement](../statements/declare-statement.md)

- [Delegate Statement](../statements/delegate-statement.md) of a delegate nested in a class

- [Dim Statement](../statements/dim-statement.md)

- [Enum Statement](../statements/enum-statement.md) of an enumeration nested in a class

- [Event Statement](../statements/event-statement.md)

- [Function Statement](../statements/function-statement.md)

- [Interface Statement](../statements/interface-statement.md) of an interface nested in a class

- [Property Statement](../statements/property-statement.md)

- [Structure Statement](../statements/structure-statement.md) of a structure nested in a class

- [Sub Statement](../statements/sub-statement.md)

## See also

- [Public](public.md)
- [Protected](protected.md)
- [Friend](friend.md)
- [Private](private.md)
- [Protected Friend](./protected-friend.md)
- [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md)
- [Procedures](../../programming-guide/language-features/procedures/index.md)
- [Structures](../../programming-guide/language-features/data-types/structures.md)
- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
