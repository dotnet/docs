---
title: Pattern matching warnings
description: There are several pattern matching warnings. Learn how to address these warnings.
f1_keywords:
  - "CS8509" # WRN_SwitchNotAllPossibleValues: The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.
helpviewer_keywords:
  - "CS8509"
ms.date: 11/10/2022
---
# Pattern matching warnings

There are several pattern matching warnings. Learn how to address these warnings.

- **CS8509** - *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*

The following code snippets generate CS8509:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="SwitchNotAllPossibleValues":::

To address this warning, add switch arms that cover all possible input values. For example:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="SwitchAllPossibleValues":::

The `_` pattern matches all remaining values. It's often used to match invalid values, as shown in the preceding example.

For more information, see [Switch](../statements/selection-statements.md#the-switch-statement).
