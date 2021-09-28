---
description: "Learn more about: BC30033: Identifier is too long"
title: "Identifier is too long"
ms.date: 07/20/2015
f1_keywords:
  - "bc30033"
  - "vbc30033"
helpviewer_keywords:
  - "BC30033"
ms.assetid: 3d07f6d0-9a2f-49ca-94e8-1e354932e855
---
# BC30033: Identifier is too long

The name, or identifier, of every programming element is limited to 1023 characters. In addition, a fully qualified name cannot exceed 1023 characters. This means that the entire identifier string (`<namespace>.<...>.<namespace>.<class>.<element>`) cannot be more than 1023 characters long, including the member-access operator (`.`) characters.

 **Error ID:** BC30033

## To correct this error

- Reduce the length of the identifier.

## See also

- [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md)
