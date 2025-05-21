---
description: "Learn more about: How to: Declare an Object Variable and Assign an Object to It in Visual Basic"
title: "How to: Declare an Object Variable and Assign an Object to It"
ms.date: 07/20/2015
helpviewer_keywords:
  - "object variables [Visual Basic], declaring"
  - "declaring object variables [Visual Basic]"
ms.assetid: 2fa77dde-1fb2-439a-80d4-3e9787649fad
ms.topic: how-to
---
# How to: Declare an Object Variable and Assign an Object to It in Visual Basic

You declare a variable of the [Object Data Type](../../../language-reference/data-types/object-data-type.md) by specifying `As Object` in a [Dim Statement](../../../language-reference/statements/dim-statement.md). You assign an object to such a variable by placing the object after the equal sign (`=`) in an assignment statement or initialization clause.

## Example

The following example declares an `Object` variable and assigns the current instance to it.

```vb
Dim thisObject As Object
thisObject = "This is an Object"
```

You can combine the declaration and assignment by initializing the variable as part of its declaration. The following example is equivalent to the preceding example.

```vb
Dim thisObject As Object= "This is an Object"
```

## Compile the code

This example requires:

- A reference to the <xref:System> namespace.

- A class, structure, or module in which to put the `Dim` statement.

- A procedure in which to put the assignment statement.

## See also

- [Variable Declaration](variable-declaration.md)
- [Object Variables](object-variables.md)
- [Object Variable Declaration](object-variable-declaration.md)
- [Object Data Type](../../../language-reference/data-types/object-data-type.md)
- [Dim Statement](../../../language-reference/statements/dim-statement.md)
- [Local Type Inference](local-type-inference.md)
- [Option Strict Statement](../../../language-reference/statements/option-strict-statement.md)
