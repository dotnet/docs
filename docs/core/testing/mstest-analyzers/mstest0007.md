---
title: "MSTEST0007: Use test attributes only on test methods"
description: "Learn about code analysis rule MSTEST0007: Ensure test attributes are set only on methods marked with the `TestMethod` attribute"
ms.date: 02/01/2024
f1_keywords:
- MSTEST0007
- UseAttributeOnTestMethodAnalyzer
helpviewer_keywords:
- UseAttributeOnTestMethodAnalyzer
- MSTEST0007
author: cvpoienaru
ms.author: copoiena
---
# MSTEST0007: Use test attributes only on test methods

| Property                            | Value                                    |
|-------------------------------------|------------------------------------------|
| **Rule ID**                         | MSTEST0007                               |
| **Title**                           | Use test attributes only on test methods |
| **Category**                        | Usage                                    |
| **Fix is breaking or non-breaking** | Non-breaking                             |
| **Enabled by default**              | Yes                                      |
| **Default severity**                | Info                                     |
| **Introduced in version**           | 3.3.0                                    |
| **Is there a code fix**             | Yes                                      |

## Cause

A method that's not marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> has one or more test attributes applied to it.

## Rule description

The following test attributes should only be applied on methods marked with the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CssIterationAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CssProjectStructureAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionBaseAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OwnerAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PriorityAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.WorkItemAttribute>

## How to fix violations

To fix a violation of this rule, either convert the method on which you applied the test attributes to a test method by setting the `[TestMethod]` attribute or remove the test attributes altogether.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, your attributes will be ignored since they are designed for use only in a test context.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0007
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0007
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0007.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
