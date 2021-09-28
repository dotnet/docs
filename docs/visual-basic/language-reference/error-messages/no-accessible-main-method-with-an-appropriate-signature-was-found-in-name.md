---
description: "Learn more about: BC30737: No accessible 'Main' method with an appropriate signature was found in '<name>'"
title: "No accessible 'Main' method with an appropriate signature was found in '<name>'"
ms.date: 07/20/2015
f1_keywords:
  - "bc30737"
  - "vbc30737"
helpviewer_keywords:
  - "BC30737"
ms.assetid: 3f40bacd-3fac-4741-b204-852f693d4340
---
# BC30737: No accessible 'Main' method with an appropriate signature was found in '\<name>'

Command-line applications must have a `Sub Main` defined. `Main` must be declared as `Public Shared` if it is defined in a class, or as `Public` if defined in a module.

 **Error ID:** BC30737

## To correct this error

- Define a `Public Sub Main` procedure for your project. Declare it as `Shared` if and only if you define it inside a class.

## See also

- [Structure of a Visual Basic Program](../../programming-guide/program-structure/structure-of-a-visual-basic-program.md)
- [Procedures](../../programming-guide/language-features/procedures/index.md)
