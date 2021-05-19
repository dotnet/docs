---
title: "Unnecessary code rules"
description: "Learn about code analysis unnecessary code rules"
ms.date: 09/30/2020
ms.topic: reference
author: gewarren
ms.author: gewarren
dev_langs:
- CSharp
- VB
---
# Unnecessary code rules

Unnecessary code rules identify different parts of the code base that are unnecessary and can be refactored or removed. The presence of unnecessary code indicates one of more of the following problems:

- Readability: Code that is unnecessarily degrading readability. For example, [IDE0001](ide0001.md) flags unnecessary type-name qualifications.
- Maintainability: Code that is no longer used after refactoring and is unnecessarily being maintained. For example, [IDE0051](ide0051.md) flags unused private fields, properties, events, and methods.
- Performance: Unnecessary computation that has no side effects and leads to unnecessary performance overhead. For example, [IDE0059](ide0059.md) flags unused value assignments where the expression to compute a value has no side effects.
- Functionality: Functional issue in code leading to required code being rendered redundant. For example, [IDE0060](ide0060.md) flags unused parameters where the method accidentally ignores an input parameter.

The rules in this section concern the following unnecessary code rules:

- [Simplify name (IDE0001)](ide0001.md)
- [Simplify member access (IDE0002)](ide0002.md)
- [Remove unnecessary cast (IDE0004)](ide0004.md)
- [Remove unnecessary import (IDE0005)](ide0005.md)
- [Remove unreachable code (IDE0035)](ide0035.md)
- [Remove unused private member (IDE0051)](ide0051.md)
- [Remove unread private member (IDE0052)](ide0052.md)
- [Remove unused expression value (IDE0058)](ide0058.md)
- [Remove unnecessary value assignment (IDE0059)](ide0059.md)
- [Remove unused parameter (IDE0060)](ide0060.md)
- [Remove unnecessary suppression (IDE0079)](ide0079.md)
- [Remove unnecessary suppression operator (IDE0080)](ide0080.md) - C# only.
- [Remove 'ByVal' (IDE0081)](ide0081.md) - Visual Basic only.
- [Remove unnecessary equality operator (IDE0100)](ide0100.md)
- [Remove unnecessary discard (IDE0110)](ide0110.md) - C# only.
- [Simplify object creation (IDE0140)](ide0140.md) - Visual Basic only.

Some of these rules have options to configure the rule behavior:

- [csharp_style_unused_value_expression_statement_preference (IDE0058)](ide0058.md#csharp_style_unused_value_expression_statement_preference)
- [visual_basic_style_unused_value_expression_statement_preference (IDE0058)](ide0058.md#visual_basic_style_unused_value_expression_statement_preference)
- [csharp_style_unused_value_assignment_preference (IDE0059)](ide0059.md#csharp_style_unused_value_assignment_preference)
- [visual_basic_style_unused_value_assignment_preference (IDE0059)](ide0059.md#visual_basic_style_unused_value_assignment_preference)
- [dotnet_code_quality_unused_parameters (IDE0060)](ide0060.md#dotnet_code_quality_unused_parameters)
- [dotnet_remove_unnecessary_suppression_exclusions (IDE0079)](ide0079.md#dotnet_remove_unnecessary_suppression_exclusions)
- [visual_basic_style_prefer_simplified_object_creation (IDE0140)](ide0140.md#visual_basic_style_prefer_simplified_object_creation)

## See also

- [Code style language rules](language-rules.md)
- [Code style rules reference](index.md)
