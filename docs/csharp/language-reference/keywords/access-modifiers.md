---
description: "Access Modifiers - C# Reference"
title: "Access Modifiers - C# Reference"
ms.date: 09/15/2022
helpviewer_keywords:
  - "access modifiers [C#]"
---
# Access Modifiers (C# Reference)

Access modifiers are keywords used to specify the declared accessibility of a member or a type. This section introduces the five access modifiers:

- `public`
- `protected`
- `internal`
- `private`
- `file`

 The following seven accessibility levels can be specified using the access modifiers:

- [`public`](public.md): Access isn't restricted.
- [`protected`](protected.md): Access is limited to the containing class or types derived from the containing class.
- [`internal`](internal.md): Access is limited to the current assembly.
- [`protected internal`](protected-internal.md): Access is limited to the current assembly or types derived from the containing class.
- [`private`](private.md): Access is limited to the containing type.
- [`private protected`](private-protected.md): Access is limited to the containing class or types derived from the containing class within the current assembly.
- [`file`](file.md): The declared type is only visible in the current source file. File scoped types are generally used for source generators.

 This section also introduces the following concepts:

- [Accessibility Levels](./accessibility-levels.md): Using the four access modifiers to declare six levels of accessibility.
- [Accessibility Domain](./accessibility-domain.md): Specifies where, in the program sections, a member can be referenced.
- [Restrictions on Using Accessibility Levels](./restrictions-on-using-accessibility-levels.md): A summary of the restrictions on using declared accessibility levels.

## See also

- [Add accessibility modifiers (style rule IDE0040)](../../../fundamentals/code-analysis/style-rules/ide0040.md)
- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md)
- [Access Keywords](base.md)
- [Modifiers](index.md)
