---
title: Maintainability rules (code analysis)
description: "Learn about code analysis maintainability rules."
ms.date: 11/04/2016
ms.topic: reference
f1_keywords:
- vs.codeanalysis.maintainabilityrules
helpviewer_keywords:
- rules, maintainability
- managed code analysis rules, maintainability rules
- maintainability rules
author: gewarren
ms.author: gewarren
---
# Maintainability rules

Maintainability rules support library and application maintenance.

## In this section

| Rule | Description |
|-----------|-----------------------------------|
| [CA1501: Avoid excessive inheritance](ca1501.md) | A type is more than four levels deep in its inheritance hierarchy. Deeply nested type hierarchies can be difficult to follow, understand, and maintain. |
| [CA1502: Avoid excessive complexity](ca1502.md) | This rule measures the number of linearly independent paths through the method, which is determined by the number and complexity of conditional branches. |
| [CA1505: Avoid unmaintainable code](ca1505.md) | A type or method has a low maintainability index value. A low maintainability index indicates that a type or method is probably difficult to maintain and would be a good candidate for redesign. |
| [CA1506: Avoid excessive class coupling](ca1506.md) | This rule measures class coupling by counting the number of unique type references that a type or method contains. |
| [CA1507: Use nameof in place of string](ca1507.md) | A string literal is used as an argument where a `nameof` expression could be used. |
| [CA1508: Avoid dead conditional code](ca1508.md) | A method has conditional code that always evaluates to `true` or `false` at run time. This leads to dead code in the `false` branch of the condition. |
| [CA1509: Invalid entry in code metrics configuration file](ca1509.md) | Code metrics rules, such as [CA1501](ca1501.md), [CA1502](ca1502.md), [CA1505](ca1505.md) and [CA1506](ca1506.md), supplied a configuration file named `CodeMetricsConfig.txt` that has an invalid entry. |

## See also

- [Measure Complexity and Maintainability of Managed Code](/visualstudio/code-quality/code-metrics-values)
