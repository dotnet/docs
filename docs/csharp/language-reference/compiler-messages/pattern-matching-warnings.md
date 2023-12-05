---
title: Pattern matching errors and warnings
description: There are several pattern matching warnings. Learn how to address these warnings.
f1_keywords:
  - "CS8509" # WRN_SwitchNotAllPossibleValues: The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.
  - "CS9134"
  - "CS9135"
helpviewer_keywords:
  - "CS8509"
  - "CS9134"
  - "CS9135"
ms.date: 11/02/2022
---
# Pattern matching errors and warnings

The compiler generates the following errors for invalid pattern match expressions:

- **CS9134**: *A switch expression arm does not begin with a 'case' keyword.*
- **CS9135**: *A constant value of type is expected*

The compiler generates the following warnings for incomplete pattern matching expressions:

- **CS8509**: *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*

The compiler generates CS9134 to help you convert a switch statement to a switch expression. The `case` keyword isn't used in a switch expression. If you have the `case` keyword in a switch expression, it must be removed:

```csharp
var answer = x switch
{
    // CS9134: remove the keyword "case" from each switch arm:
    case 0 => false,
    case 1 => true,
}
```

The compiler generates CS9135 when the pattern isn't a constant value. You can't create pattern matching expressions to match against a variable.

The following code snippets generate CS8509:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="SwitchNotAllPossibleValues":::

To address this warning, add switch arms that cover all possible input values. For example:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="SwitchAllPossibleValues":::

The `_` pattern matches all remaining values. One scenario for the `_` pattern is matching invalid values, as shown in the preceding example.

For more information, see [Switch](../statements/selection-statements.md#the-switch-statement).
