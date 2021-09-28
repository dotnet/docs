---
description: "Learn more about: BC31103: 'Get' accessor of property '<propertyname>' is not accessible"
title: "'Get' accessor of property '<propertyname>' is not accessible"
ms.date: 07/20/2015
f1_keywords:
  - "vbc31103"
  - "bc31103"
helpviewer_keywords:
  - "BC31103"
ms.assetid: 3c346c32-7669-4b04-841d-7a9df9cb703e
---
# BC31103: 'Get' accessor of property '\<propertyname>' is not accessible

A statement attempts to retrieve the value of a property when it does not have access to the property's `Get` procedure.

 If the [Get Statement](../statements/get-statement.md) is marked with a more restrictive access level than its [Property Statement](../statements/property-statement.md), an attempt to read the property value could fail in the following cases:

- The `Get` statement is marked [Private](../modifiers/private.md) and the calling code is outside the class or structure in which the property is defined.

- The `Get` statement is marked [Protected](../modifiers/protected.md) and the calling code is not in the class or structure in which the property is defined, nor in a derived class.

- The `Get` statement is marked [Friend](../modifiers/friend.md) and the calling code is not in the same assembly in which the property is defined.

 **Error ID:** BC31103

## To correct this error

- If you have control of the source code defining the property, consider declaring the `Get` procedure with the same access level as the property itself.

- If you do not have control of the source code defining the property, or you must restrict the `Get` procedure access level more than the property itself, try to move the statement that reads the property value to a region of code that has better access to the property.

## See also

- [Property Procedures](../../programming-guide/language-features/procedures/property-procedures.md)
- [How to: Declare a Property with Mixed Access Levels](../../programming-guide/language-features/procedures/how-to-declare-a-property-with-mixed-access-levels.md)
