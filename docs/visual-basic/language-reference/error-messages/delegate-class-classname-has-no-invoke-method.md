---
description: "Learn more about: BC30220: Delegate class '<classname>' has no Invoke method, so an expression of this type cannot be the target of a method call"
title: "Delegate class '<classname>' has no Invoke method, so an expression of this type cannot be the target of a method call"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30220"
  - "bc30220"
helpviewer_keywords:
  - "BC30220"
ms.assetid: 6be0d61c-f2f9-4f9b-ab90-8871a0d7206d
---
# BC30220: Delegate class '\<classname>' has no Invoke method, so an expression of this type cannot be the target of a method call

A call to `Invoke` through a delegate has failed because `Invoke` is not implemented on the delegate class.

 **Error ID:** BC30220

## To correct this error

1. Ensure that an instance of the delegate class has been created with a `Dim` statement and that a procedure has been assigned to the delegate instance with the `AddressOf` operator.

2. Locate the code that implements the delegate class and make sure it implements the `Invoke` procedure.

## See also

- [Delegates](../../programming-guide/language-features/delegates/index.md)
- [Delegate Statement](../statements/delegate-statement.md)
- [AddressOf Operator](../operators/addressof-operator.md)
- [Dim Statement](../statements/dim-statement.md)
