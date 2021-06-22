---
description: "Learn more about: Shadows (Visual Basic)"
title: "Shadows"
ms.date: 07/20/2015
f1_keywords:
  - "vb.Shadows"
  - "shadows"
helpviewer_keywords:
  - "shadowing"
  - "duplicate names [Visual Basic]"
  - "scope [Visual Basic], shadowing"
  - "Shadows keyword [Visual Basic]"
  - "names [Visual Basic], shadowing"
ms.assetid: 6bf687cd-0544-4797-b51b-911125ec57c6
---
# Shadows (Visual Basic)

Specifies that a declared programming element redeclares and hides an identically named element, or set of overloaded elements, in a base class.

## Remarks

The main purpose of shadowing (which is also known as *hiding by name*) is to preserve the definition of your class members. The base class might undergo a change that creates an element with the same name as one you have already defined. If this happens, the `Shadows` modifier forces references through your class to be resolved to the member you defined, instead of to the new base class element.

Both shadowing and overriding redefine an inherited element, but there are significant differences between the two approaches. For more information, see [Shadowing in Visual Basic](../../programming-guide/language-features/declared-elements/shadowing.md).

## Rules

- **Declaration Context.** You can use `Shadows` only at class level. This means the declaration context for a `Shadows` element must be a class, and cannot be a source file, namespace, interface, module, structure, or procedure.

  You can declare only one shadowing element in a single declaration statement.

- **Combined Modifiers.** You cannot specify `Shadows` together with `Overloads`, `Overrides`, or `Static` in the same declaration.

- **Element Types.** You can shadow any kind of declared element with any other kind. If you shadow a property or procedure with another property or procedure, the parameters and the return type do not have to match those in the base class property or procedure.

- **Accessing.** The shadowed element in the base class is normally unavailable from within the derived class that shadows it. However, the following considerations apply.

  - If the shadowing element is not accessible from the code referring to it, the reference is resolved to the shadowed element. For example, if a `Private` element shadows a base class element, code that does not have permission to access the `Private` element accesses the base class element instead.

  - If you shadow an element, you can still access the shadowed element through an object declared with the type of the base class. You can also access it through `MyBase`.

The `Shadows` modifier can be used in these contexts:

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

- [Shared](shared.md)
- [Static](static.md)
- [Private](private.md)
- [Me, My, MyBase, and MyClass](../../programming-guide/program-structure/me-my-mybase-and-myclass.md)
- [Inheritance Basics](../../programming-guide/language-features/objects-and-classes/inheritance-basics.md)
- [MustOverride](mustoverride.md)
- [NotOverridable](notoverridable.md)
- [Overloads](overloads.md)
- [Overridable](overridable.md)
- [Overrides](overrides.md)
- [Shadowing in Visual Basic](../../programming-guide/language-features/declared-elements/shadowing.md)
