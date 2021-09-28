---
description: "Learn more about: BC40007: Default property '<propertyname1>' conflicts with default property '<propertyname2>' in '<classname>' and so should be declared 'Shadows"
title: "Default property '<propertyname1>' conflicts with default property '<propertyname2>' in '<classname>' and so should be declared 'Shadows'"
ms.date: 07/20/2015
f1_keywords:
  - "vbc40007"
  - "bc40007"
helpviewer_keywords:
  - "BC40007"
ms.assetid: 692ccf76-5715-4f11-a972-84cf9de30bc1
---
# BC40007: Default property '\<propertyname1>' conflicts with default property '\<propertyname2>' in '\<classname>' and so should be declared 'Shadows'

A property is declared with the same name as a property defined in the base class. In this situation, the property in this class should shadow the base class property.

 This message is a warning. `Shadows` is assumed by default. For more information about hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC40007

## To correct this error

- Add the `Shadows` keyword to the declaration, or change the name of the property being declared.

## See also

- [Shadows](../modifiers/shadows.md)
- [Shadowing in Visual Basic](../../programming-guide/language-features/declared-elements/shadowing.md)
