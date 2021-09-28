---
description: "Learn more about: BC31102: 'Set' accessor of property '<propertyname>' is not accessible"
title: "'Set' accessor of property '<propertyname>' is not accessible"
ms.date: 07/20/2015
f1_keywords:
  - "vbc31102"
  - "bc31102"
helpviewer_keywords:
  - "BC31102"
ms.assetid: 6f7b31b7-3656-4ae1-8851-90f5f4c6950a
---
# BC31102: 'Set' accessor of property '\<propertyname>' is not accessible

A statement attempts to store the value of a property when it does not have access to the property's `Set` procedure.

 If the [Set Statement](../statements/set-statement.md) is marked with a more restrictive access level than its [Property Statement](../statements/property-statement.md), an attempt to set the property value could fail in the following cases:

- The `Set` statement is marked [Private](../modifiers/private.md) and the calling code is outside the class or structure in which the property is defined.

- The `Set` statement is marked [Protected](../modifiers/protected.md) and the calling code is not in the class or structure in which the property is defined, nor in a derived class.

- The `Set` statement is marked [Friend](../modifiers/friend.md) and the calling code is not in the same assembly in which the property is defined.

 **Error ID:** BC31102

## To correct this error

- If you have control of the source code defining the property, consider declaring the `Set` procedure with the same access level as the property itself.

- If you do not have control of the source code defining the property, or you must restrict the `Set` procedure access level more than the property itself, try to move the statement that sets the property value to a region of code that has better access to the property.

## See also

- [Property Procedures](../../programming-guide/language-features/procedures/property-procedures.md)
- [How to: Declare a Property with Mixed Access Levels](../../programming-guide/language-features/procedures/how-to-declare-a-property-with-mixed-access-levels.md)
