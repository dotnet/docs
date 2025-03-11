---
title: "MSTEST0004: Public types should be test classes"
description: "Learn about code analysis rule MSTEST0004: Public types should be test classes"
ms.date: 01/03/2024
f1_keywords:
- MSTEST0004
- PublicTypeShouldBeTestClassAnalyzer
helpviewer_keywords:
- PublicTypeShouldBeTestClassAnalyzer
- MSTEST0004
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0004: Public types should be test classes

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0004                                         |
| **Title**                           | Public types should be test classes                |
| **Category**                        | Design                                             |
| **Fix is breaking or non-breaking** | Breaking                                           |
| **Enabled by default**              | No                                                 |
| **Default severity**                | Disabled                                           |
| **Introduced in version**           | 3.2.0                                              |
| **Is there a code fix**             | Yes                                                |

## Cause

A public type is not a test class (class marked with the `[TestClass]` attribute).

## Rule description

It's considered a good practice to keep all helper and base classes `internal` and have only test classes marked `public` in a test project.

## How to fix violations

Change the accessibility of the type to not be `public`.

## When to suppress warnings

You can suppress instances of this diagnostic if the type should remain `public` for compatibility reason.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0004
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0004
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0004.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
