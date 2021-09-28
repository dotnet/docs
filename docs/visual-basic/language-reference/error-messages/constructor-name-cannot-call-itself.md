---
description: "Learn more about: BC30298: Constructor '<name>' cannot call itself"
title: "Constructor '<name>' cannot call itself"
ms.date: 07/20/2015
f1_keywords:
  - "bc30298"
  - "vbc30298"
helpviewer_keywords:
  - "BC30298"
ms.assetid: 2d77b7f4-0640-4f89-9c65-f101fd2847c0
---
# BC30298: Constructor '\<name>' cannot call itself

A `Sub New` procedure in a class or structure calls itself.

 The purpose of a constructor is to initialize an instance of a class or structure when it is first created. A class or structure can have several constructors, provided they all have different parameter lists. A constructor is permitted to call another constructor to perform its functionality in addition to its own. But it is meaningless for a constructor to call itself, and in fact it would result in infinite recursion if permitted.

 **Error ID:** BC30298

## To correct this error

1. Check the parameter list of the constructor being called. It should be different from that of the constructor making the call.

2. If you do not intend to call a different constructor, remove the `Sub New` call entirely.

## See also

- [Object Lifetime: How Objects Are Created and Destroyed](../../programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md)
