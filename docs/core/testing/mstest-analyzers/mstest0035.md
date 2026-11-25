---
title: "MSTEST0035: [DeploymentItem] can be specified only on test class or test method."
description: "Learn about code analysis rule MSTEST0035: `[DeploymentItem]` can be specified only on test class or test method."
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0035
- UseDeploymentItemWithTestMethodOrTestClassTitle
helpviewer_keywords:
- UseDeploymentItemWithTestMethodOrTestClassTitle
- MSTEST0035
author: engyebrahim
ms.author: enjieid
---
# MSTEST0035: `[DeploymentItem]` can be specified only on test class or test method

| Property                            | Value                                                                  |
|-------------------------------------|------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0035                                                             |
| **Title**                           | `[DeploymentItem]` can be specified only on test class or test method. |
| **Category**                        | Usage                                                                  |
| **Fix is breaking or non-breaking** | Non-breaking                                                           |
| **Enabled by default**              | Yes                                                                    |
| **Default severity**                | Warning starting with 4.0.0, Info before                               |
| **Introduced in version**           | 3.6.0                                                                  |
| **Is there a code fix**             | No                                                                     |

## Cause

This rule raises a diagnostic when `[DeploymentItem]` isn't set on test class or test method.

## Rule description

`[DeploymentItem]` describes files or directories that a test needs in its deployment location. MSTest reads deployment metadata from test classes and test methods so it can associate those assets with discovered tests.

An attribute on a helper or lifecycle method doesn't supply deployment metadata for those tests. The expected files can then be unavailable when the test runs, causing an environment failure instead of exercising the intended behavior.

## How to fix violations

Ensure the attribute `[DeploymentItem]` is specified on a test class or a test method, otherwise remove the attribute.

## When to suppress warnings

It's _not_ recommended to suppress warnings from this rule as the `[DeploymentItem]` will be ignored.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0035
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0035
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0035.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
