---
description: "Learn more about: How to: Create a New Variable (Visual Basic)"
title: "How to: Create a New Variable"
ms.date: 07/20/2015
helpviewer_keywords:
  - "Dim statement [Visual Basic]"
  - "variables [Visual Basic], creating"
ms.assetid: 35300be3-77b0-4bef-a156-034d3cdedde0
ms.topic: how-to
---
# How to: Create a New Variable (Visual Basic)

You create a variable with a [Dim Statement](../../../language-reference/statements/dim-statement.md).

### To create a new variable

1. Declare the variable in a `Dim` statement.

    ```vb
    Dim newCustomer
    ```

2. Include specifications for the variable's characteristics, such as [Private](../../../language-reference/modifiers/private.md), [Static](../../../language-reference/modifiers/static.md), [Shadows](../../../language-reference/modifiers/shadows.md), or [WithEvents](../../../language-reference/modifiers/withevents.md). For more information, see [Declared Element Characteristics](../declared-elements/declared-element-characteristics.md).

    ```vb
    Public Static newCustomer
    ```

    You do not need the `Dim` keyword if you use other keywords in the declaration.

3. Follow the specifications with the variable's name, which must follow Visual Basic rules and conventions. For more information, see [Declared Element Names](../declared-elements/declared-element-names.md).

    ```vb
    Public Static newCustomer
    ```

4. Follow the name with the [As](../../../language-reference/statements/as-clause.md) clause to specify the variable's data type.

    ```vb
    Public Static newCustomer As Customer
    ```

    If you do not specify the data type, it uses the default: `Object`.

5. Follow the `As` clause with an equal sign (`=`) and follow the equal sign with the variable's initial value.

    Visual Basic assigns the specified value to the variable every time it runs the `Dim` statement. If you do not specify an initial value, Visual Basic assigns the default initial value for the variable's data type when it first enters the code that contains the `Dim` statement.

    If the variable is a reference type, you can create an instance of its class by including the [New Operator](../../../language-reference/operators/new-operator.md) keyword in the `As` clause. If you do not use `New`, the initial value of the variable is [Nothing](../../../language-reference/nothing.md).

    ```vb
    Public Static newCustomer As New Customer
    ```

## See also

- [Variables](index.md)
- [Variable Declaration](variable-declaration.md)
- [Declared Element Names](../declared-elements/declared-element-names.md)
- [Declared Element Characteristics](../declared-elements/declared-element-characteristics.md)
- [Value Types and Reference Types](../data-types/value-types-and-reference-types.md)
- [Statements](../../../language-reference/statements/index.md)
- [Local Type Inference](local-type-inference.md)
- [Option Infer Statement](../../../language-reference/statements/option-infer-statement.md)
