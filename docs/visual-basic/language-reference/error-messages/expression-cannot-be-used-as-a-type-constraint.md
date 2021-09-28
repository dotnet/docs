---
description: "Learn more about: BC32061: '<expression>' cannot be used as a type constraint"
title: "'<expression>' cannot be used as a type constraint"
ms.date: 07/20/2015
f1_keywords:
  - "bc32061"
  - "vbc32061"
helpviewer_keywords:
  - "BC32061"
ms.assetid: b17821b7-fa14-4397-a211-6e2a14079f09
---
# BC32061: '\<expression>' cannot be used as a type constraint

A constraint list includes an expression that does not represent a valid constraint on a type parameter.

 A constraint list imposes requirements on the type argument passed to the type parameter. You can specify the following requirements in any combination:

- The type argument must implement one or more interfaces

- The type argument must inherit from at most one class

- The type argument must expose a parameterless constructor that the creating code can access (include the `New` constraint)

 If you do not include any specific class or interface in the constraint list, you can impose a more general requirement by specifying one of the following:

- The type argument must be a value type (include the `Structure` constraint)

- The type argument must be a reference type (include the `Class` constraint)

 You cannot specify both `Structure` and `Class` for the same type parameter, and you cannot specify either one more than once.

 **Error ID:** BC32061

## To correct this error

- Verify that the expression and its elements are spelled correctly.

- If the expression does not qualify for the preceding list of requirements, remove it from the constraint list.

- If the expression refers to an interface or class, verify that the compiler has access to that interface or class. You might need to qualify its name, and you might need to add a reference to your project. For more information, see "References to Projects" in [References to Declared Elements](../../programming-guide/language-features/declared-elements/references-to-declared-elements.md).

## See also

- [Generic Types in Visual Basic](../../programming-guide/language-features/data-types/generic-types.md)
- [Value Types and Reference Types](../../programming-guide/language-features/data-types/value-types-and-reference-types.md)
- [References to Declared Elements](../../programming-guide/language-features/declared-elements/references-to-declared-elements.md)
