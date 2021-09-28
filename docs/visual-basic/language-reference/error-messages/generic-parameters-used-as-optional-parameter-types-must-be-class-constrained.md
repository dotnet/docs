---
description: "Learn more about: BC32124: Generic parameters used as optional parameter types must be class constrained"
title: "Generic parameters used as optional parameter types must be class constrained"
ms.date: 07/20/2015
f1_keywords:
  - "vbc32124"
  - "bc32124"
helpviewer_keywords:
  - "BC32124"
ms.assetid: 55aa8b2a-9ce3-4620-a710-2f9b0feb6143
---
# BC32124: Generic parameters used as optional parameter types must be class constrained

A procedure is declared with an optional parameter that uses a type parameter that is not constrained to be a reference type.

 You must always supply a default value for each optional parameter. If the parameter is of a reference type, the optional value must be `Nothing`, which is a valid value for any reference type. However, if the parameter is of a value type, that type must be an elementary data type predefined by Visual Basic. This is because a composite value type, such as a user-defined structure, has no valid default value.

 When you use a type parameter for an optional parameter, you must guarantee that it is of a reference type to avoid the possibility of a value type with no valid default value. This means you must constrain the type parameter either with the `Class` keyword or with the name of a specific class.

 **Error ID:** BC32124

## To correct this error

- Constrain the type parameter to accept only a reference type, or do not use it for the optional parameter.

## See also

- [Generic Types in Visual Basic](../../programming-guide/language-features/data-types/generic-types.md)
- [Type List](../statements/type-list.md)
- [Class Statement](../statements/class-statement.md)
- [Optional Parameters](../../programming-guide/language-features/procedures/optional-parameters.md)
- [Structures](../../programming-guide/language-features/data-types/structures.md)
- [Nothing](../nothing.md)
