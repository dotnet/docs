---
title: "MSTEST0066: '[Ignore]' should specify a justification"
description: "Learn about code analysis rule MSTEST0066: '[Ignore]' should specify a justification"
ms.date: 06/04/2026
f1_keywords:
- MSTEST0066
- IgnoreShouldHaveJustificationAnalyzer
helpviewer_keywords:
- IgnoreShouldHaveJustificationAnalyzer
- MSTEST0066
author: Evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0066: `[Ignore]` should specify a justification

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0066                                         |
| **Title**                           | `[Ignore]` should specify a justification          |
| **Category**                        | Design                                             |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.3.0                                              |
| **Is there a code fix**             | No                                                 |

> [!NOTE]
> This rule is available starting with MSTest 4.3.

## Cause

A test method or test class is marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute> but no justification message is provided.

## Rule description

To improve the discoverability and triage of skipped tests, an `[Ignore]` attribute applied to a test method or test class should include a non-empty message explaining why the test or class is ignored. A justification message helps reviewers understand the intent and prevents tests from being silently disabled forever.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [Ignore] // Violation - no justification provided.
    public void Test()
    {
    }
}
```

## How to fix violations

Pass a non-empty message to the `[Ignore]` attribute, either positionally or via the `IgnoreMessage` named property:

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [Ignore("Disabled until issue #1234 is fixed.")]
    public void Test()
    {
    }
}
```

```csharp
[TestClass]
[Ignore(IgnoreMessage = "Disabled until issue #1234 is fixed.")]
public class TestClass
{
    [TestMethod]
    public void Test()
    {
    }
}
```

## When to suppress warnings

Don't suppress warnings from this rule. Ignored tests without a justification are easy to forget.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0066
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0066
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0066.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
