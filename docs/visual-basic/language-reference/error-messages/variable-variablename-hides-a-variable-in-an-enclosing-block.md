---
description: "Learn more about: BC30616: Variable '<variablename>' hides a variable in an enclosing block"
title: "Variable '<variablename>' hides a variable in an enclosing block"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30616"
  - "bc30616"
helpviewer_keywords:
  - "BC30616"
ms.assetid: e7658ebc-da45-451b-a409-a0f8915f0beb
---
# BC30616: Variable '\<variablename>' hides a variable in an enclosing block

A variable enclosed in a block has the same name as another local variable.

 **Error ID:** BC30616

## To correct this error

- Rename the variable in the enclosed block so that it is not the same as any other local variables. For example:

    ```vb
    Dim a, b, x As Integer
    If a = b Then
       Dim y As Integer = 20 ' Uniquely named block variable.
    End If
    ```

- A common cause for this error is the use of `Catch e As Exception` inside an event handler. If this is the case, name the `Catch` block variable `ex` rather than `e`.

- Another common source of this error is an attempt to access a local variable declared within a `Try` block in a separate `Catch` block. To correct this, declare the variable outside the `Try...Catch...Finally` structure.

## See also

- [Try...Catch...Finally Statement](../statements/try-catch-finally-statement.md)
- [Variable Declaration](../../programming-guide/language-features/variables/variable-declaration.md)
