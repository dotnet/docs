---
description: "Learn more about: BC30910: '<typename>' cannot inherit from <type> '<basetypename>' because it expands the access of the base <type> outside the assembly"
title: "'<typename>' cannot inherit from <type> '<basetypename>' because it expands the access of the base <type> outside the assembly"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30910"
  - "bc30910"
helpviewer_keywords:
  - "BC30910"
ms.assetid: 68fc05c5-5d55-4742-9a3b-ea04312594f4
---
# BC30910: '\<typename>' cannot inherit from \<type> '\<basetypename>' because it expands the access of the base \<type> outside the assembly

A class or interface inherits from a base class or interface but has a less restrictive access level.

 For example, a `Public` interface inherits from a `Friend` interface, or a `Protected` class inherits from a `Private` class. This exposes the base class or interface to access beyond the intended level.

 **Error ID:** BC30910

## To correct this error

- Change the access level of the derived class or interface to be at least as restrictive as that of the base class or interface.

     -or-

- If you require the less restrictive access level, remove the `Inherits` statement. You cannot inherit from a more restricted base class or interface.

## See also

- [Class Statement](../statements/class-statement.md)
- [Interface Statement](../statements/interface-statement.md)
- [Inherits Statement](../statements/inherits-statement.md)
- [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md)
