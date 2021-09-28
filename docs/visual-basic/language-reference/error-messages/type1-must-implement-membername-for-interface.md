---
description: "Learn more about: BC30154: <type1>'<typename>' must implement '<membername>' for interface '<interfacename>'"
title: "<type1>'<typename>' must implement '<membername>' for interface '<interfacename>'"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30154"
  - "bc30154"
helpviewer_keywords:
  - "BC30154"
ms.assetid: 259afdfa-3608-4760-adcb-88ec0da5020d
---
# BC30154: \<type1>'\<typename>' must implement '\<membername>' for interface '\<interfacename>'

'\<typename>' must implement '\<membername>' for interface '\<interfacename>'. Implementing property must have matching 'ReadOnly'/'WriteOnly' specifiers.

 A class or structure claims to implement an interface but does not implement a procedure, property, or event defined by the interface. Every member of the interface must be implemented.

 **Error ID:** BC30154

## To correct this error

1. Declare a member with the same name and signature as defined in the interface. Be sure to include at least the `End Function`, `End Sub`, or `End Property` statement.

2. Add an `Implements` clause to the end of the `Function`, `Sub`, `Property`, or `Event` statement. For example:

    ```vb
    Public Event ItHappened() Implements IBaseInterface.ItHappened
    ```

3. When implementing a property, make sure that `ReadOnly` or `WriteOnly` is used in the same way as in the interface definition.

4. When implementing a property, declare `Get` and `Set` procedures, as appropriate.

## See also

- [Implements Statement](../statements/implements-statement.md)
- [Interfaces](../../programming-guide/language-features/interfaces/index.md)
