---
description: "Learn more about: BC30202: 'Optional' expected"
title: "'Optional' expected"
ms.date: 07/20/2015
f1_keywords:
  - "bc30202"
  - "vbc30202"
helpviewer_keywords:
  - "BC30202"
ms.assetid: 6f75060c-2db4-4a79-b5d1-5780c09a74cd
---
# BC30202: 'Optional' expected

An optional argument in a procedure declaration is followed by a required argument. Every argument following an optional argument must also be optional.

 **Error ID:** BC30202

## To correct this error

- If the argument is intended to be required, move it to precede the first optional argument in the argument list.

- If the argument is intended to be optional, use the `Optional` keyword.

## See also

- [Optional Parameters](../../programming-guide/language-features/procedures/optional-parameters.md)
