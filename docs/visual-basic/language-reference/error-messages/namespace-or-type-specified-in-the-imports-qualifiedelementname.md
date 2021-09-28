---
description: "Learn more about: BC40056: Namespace or type specified in the Imports '<qualifiedelementname>' doesn't contain any public member or cannot be found"
title: "Namespace or type specified in the Imports '<qualifiedelementname>' doesn't contain any public member or cannot be found"
ms.date: 07/20/2015
f1_keywords:
  - "bc40056"
  - "vbc40056"
helpviewer_keywords:
  - "BC40056"
ms.assetid: b59f5754-444f-4378-9272-9678b437e84a
---

# BC40056: Namespace or type specified in the Imports '\<qualifiedelementname>' doesn't contain any public member or cannot be found

Namespace or type specified in the Imports '\<qualifiedelementname>' doesn't contain any public member or cannot be found. Make sure the namespace or the type is defined and contains at least one public member. Make sure the alias name doesn't contain other aliases.

An `Imports` statement specifies a containing element that either cannot be found or does not define any `Public` members.

A *containing element* can be a namespace, class, structure, module, interface, or enumeration. The containing element contains members, such as variables, procedures, or other containing elements.

The purpose of importing is to allow your code to access namespace or type members without having to qualify them. Your project might also need to add a reference to the namespace or type. For more information, see "Importing Containing Elements" in [References to Declared Elements](../../programming-guide/language-features/declared-elements/references-to-declared-elements.md).

If the compiler cannot find the specified containing element, then it cannot resolve references that use it. If it finds the element but the element does not expose any `Public` members, then no reference can be successful. In either case it is meaningless to import the element.

Keep in mind that if you import a containing element and assign an import alias to it, then you cannot use that import alias to import another element. The following code generates a compiler error.

```vb
Imports winfrm = System.Windows.Forms

' The following statement is INVALID  because it reuses an import alias.

Imports behave = winfrm.Design.Behavior`
```

**Error ID:** BC40056

## To correct this error

1. Verify that the containing element is accessible from your project.

2. Verify that the specification of the containing element does not include any import alias from another import.

3. Verify that the containing element exposes at least one `Public` member.

## See also

- [Imports Statement (.NET Namespace and Type)](../statements/imports-statement-net-namespace-and-type.md)
- [Namespace Statement](../statements/namespace-statement.md)
- [Public](../modifiers/public.md)
- [Namespaces in Visual Basic](../../programming-guide/program-structure/namespaces.md)
- [References to Declared Elements](../../programming-guide/language-features/declared-elements/references-to-declared-elements.md)
