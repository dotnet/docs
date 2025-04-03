---
title: "MSTEST0010: ClassInitialize method should have valid layout"
description: "Learn about code analysis rule MSTEST0010: ClassInitialize method should have valid layout"
ms.date: 02/19/2024
f1_keywords:
- MSTEST0010
- ClassInitializeShouldBeValidAnalyzer
helpviewer_keywords:
- ClassInitializeShouldBeValidAnalyzer
- MSTEST0010
author: engyebrahim
ms.author: enjieid
---
# MSTEST0010: ClassInitialize method should have valid layout

| Property                            | Value                                            |
|-------------------------------------|--------------------------------------------------|
| **Rule ID**                         | MSTEST0010                                       |
| **Title**                           | ClassInitialize method should have valid layout  |
| **Category**                        | Usage                                            |
| **Fix is breaking or non-breaking** | Non-breaking                                     |
| **Enabled by default**              | Yes                                              |
| **Default severity**                | Warning                                          |
| **Introduced in version**           | 3.3.0                                            |
| **Is there a code fix**             | Yes                                              |

## Cause

A method marked with `[ClassInitialize]` should have valid layout.

## Rule description

Methods marked with `[ClassInitialize]` should follow the following layout to be valid:

- it can't be declared on a generic class without the `InheritanceBehavior` mode is set
- it should be `public`
- it should be `static`
- it should not be `async void`
- it should not be a special method (finalizer, operator...).
- it should not be generic
- it should take one parameter of type `TestContext`
- return type should be `void`, `Task` or `ValueTask`
- `InheritanceBehavior.BeforeEachDerivedClass` attribute parameter should be specified if the class is `abstract`.
- `InheritanceBehavior.BeforeEachDerivedClass` attribute parameter should not be specified if the class is `sealed`.

[!INCLUDE [test-class-rules](includes/test-class-rules.md)]

- the class should not be generic

## How to fix violations

Ensure that the method matches the layout described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0010
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0010
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0010.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
