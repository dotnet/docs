---
description: "Learn more about: BC42107: Property '<propertyname>' doesn't return a value on all code paths"
title: "Property '<propertyname>' doesn't return a value on all code paths"
ms.date: 07/20/2015
f1_keywords:
  - "bc42107"
  - "vbc42107"
helpviewer_keywords:
  - "BC42107"
ms.assetid: 06800966-9c3b-4844-9f13-83ac95607d32
---
# BC42107: Property '\<propertyname>' doesn't return a value on all code paths

Property '\<propertyname>' doesn't return a value on all code paths. A null reference exception could occur at run time when the result is used.

A property `Get` procedure has at least one possible path through its code that does not return a value.

 You can return a value from a property `Get` procedure in any of the following ways:

- Assign the value to the property name and then perform an `Exit Property` statement.

- Assign the value to the property name and then perform the `End Get` statement.

- Include the value in a [Return Statement](../statements/return-statement.md).

If control passes to `Exit Property` or `End Get` and you have not assigned any value to the property name, the `Get` procedure returns the default value of the property's data type. For more information, see "Behavior" in [Function Statement](../statements/function-statement.md).

By default, this message is a warning. For more information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

**Error ID:** BC42107

## To correct this error

- Check your control flow logic and make sure you assign a value before every statement that causes a return.

  It's easier to guarantee that every return from the procedure returns a value if you always use the `Return` statement. If you do this, the last statement before `End Get` should be a `Return` statement.

## See also

- [Property Procedures](../../programming-guide/language-features/procedures/property-procedures.md)
- [Property Statement](../statements/property-statement.md)
- [Get Statement](../statements/get-statement.md)
