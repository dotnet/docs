---
description: "Learn more about: BC30157: Leading '.' or '!' can only appear inside a 'With' statement"
title: "Leading '.' or '!' can only appear inside a 'With' statement"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30157"
  - "bc30157"
helpviewer_keywords:
  - "BC30157"
ms.assetid: 70daaee1-14f9-45b7-9f30-53794310b95e
---
# BC30157: Leading '.' or '!' can only appear inside a 'With' statement

A period (.) or exclamation point (!) that is not inside a `With` block occurs without an expression on the left. Member access (`.`) and dictionary member access (`!`) require an expression specifying the element that contains the member. This must appear immediately to the left of the accessor or as the target of a `With` block containing the member access.

 **Error ID:** BC30157

## To correct this error

1. Ensure that the `With` block is correctly formatted.

2. If there is no `With` block, add an expression to the left of the accessor that evaluates to a defined element containing the member.

## See also

- [Special Characters in Code](../../programming-guide/program-structure/special-characters-in-code.md)
- [With...End With Statement](../statements/with-end-with-statement.md)
