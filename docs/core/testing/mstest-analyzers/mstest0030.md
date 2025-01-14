---
title: "MSTEST0030: Type containing `[TestMethod]` should be marked with `[TestClass]`"
description: "Learn about code analysis rule MSTEST0030: Type containing `[TestMethod]` should be marked with `[TestClass]`, otherwise the test method will be silently ignored."
ms.date: 07/02/2024
f1_keywords:
- MSTEST0030
- TypeContainingTestMethodShouldBeATestClass
helpviewer_keywords:
- TypeContainingTestMethodShouldBeATestClass
- MSTEST0030
author: engyebrahim
ms.author: enjieid
---
# MSTEST0030: Type containing `[TestMethod]` should be marked with `[TestClass]`

| Property                            | Value                                                              |
|-------------------------------------|--------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0030                                                         |
| **Title**                           | Type containing `[TestMethod]` should be marked with `[TestClass]` |
| **Category**                        | Usage                                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                                       |
| **Enabled by default**              | Yes                                                                |
| **Default severity**                | Info                                                               |
| **Introduced in version**           | 3.5.0                                                              |
| **Is there a code fix**             | No                                                                 |

## Cause

Type containing `[TestMethod]` should be marked with `[TestClass]`, otherwise the test method will be silently ignored.

## Rule description

MSTest considers test methods only on the context of a test class container (a class marked with [TestClass] or derived attribute) which could lead to some tests being silently ignored. If your class is supposed to represent common test behavior to be executed by children classes, it's recommended to mark the type as abstract to clarify the intent for other developers reading the code.

## How to fix violations

A non-abstract class contains test methods should be marked with '[TestClass]'.

## When to suppress warnings

It's safe to suppress the diagnostic if you are sure that your class is being inherited and that the tests declared on this class should only be run in the context of subclasses. Nonetheless, we recommend marking the class as abstract.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0030
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0030
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0030.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
