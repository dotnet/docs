---
description: "Learn more about: How to: Speed Up Access to an Object with a Long Qualification Path (Visual Basic)"
title: "How to: Speed Up Access to an Object with a Long Qualification Path"
ms.date: 07/20/2015
helpviewer_keywords:
  - "variables [Visual Basic], accessing"
  - "variables [Visual Basic], object"
  - "With statement [Visual Basic]"
  - "With block"
  - "object variables [Visual Basic], accessing"
ms.assetid: 3eb7657f-c9fe-4e05-8bc3-4bb14d5ae585
---
# How to: Speed Up Access to an Object with a Long Qualification Path (Visual Basic)

If you frequently access an object that requires a qualification path of several methods and properties, you can speed up your code by not repeating the qualification path.

There are two ways you can avoid repeating the qualification path. You can assign the object to a variable, or you can use it in a `With`...`End With` block.

### To speed up access to a heavily qualified object by assigning it to a variable

1. Declare a variable of the type of the object that you are accessing frequently. Specify the qualification path in the initialization part of the declaration.

    ```vb
    Dim ctrlActv As Control = someForm.ActiveForm.ActiveControl
    ```

2. Use the variable to access the object's members.

    ```vb
    ctrlActv.Text = "Test"
    ctrlActv.Location = New Point(100, 100)
    ctrlActv.Show()
    ```

### To speed up access to a heavily qualified object by using a With...End With block

1. Put the qualification path in a `With` statement.

    ```vb
    With someForm.ActiveForm.ActiveControl
    ```

2. Access the object's members inside the `With` block, before the `End With` statement.

    ```vb
        .Text = "Test"
        .Location = New Point(100, 100)
        .Show()
    End With
    ```

## See also

- [Object Variables](object-variables.md)
- [With...End With Statement](../../../language-reference/statements/with-end-with-statement.md)
