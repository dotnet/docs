---
title: "MSTEST0061: Use OSCondition attribute instead of runtime checks"
description: "Learn about code analysis rule MSTEST0061: Use OSCondition attribute instead of runtime checks"
ms.date: 12/29/2025
f1_keywords:
- MSTEST0061
- UseOSConditionAttributeInsteadOfRuntimeCheckAnalyzer
helpviewer_keywords:
- UseOSConditionAttributeInsteadOfRuntimeCheckAnalyzer
- MSTEST0061
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0061: Use OSCondition attribute instead of runtime checks

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0061                                         |
| **Title**                           | Use OSCondition attribute instead of runtime checks |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.1.0                                              |
| **Is there a code fix**             | Yes                                                |

## Cause

A test method uses <xref:System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform)> checks with an early return instead of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OSConditionAttribute> attribute.

## Rule description

When you want to skip tests based on the operating system, use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OSConditionAttribute> attribute instead of manual runtime checks. The attribute approach provides better test discoverability and clearer test intent, and integrates properly with test frameworks to mark tests as skipped rather than passed.

```csharp
using System.Runtime.InteropServices;

[TestClass]
public class TestClass
{
    [TestMethod]
    public void TestMethod()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // Violation
        {
            return;
        }
        
        // Test code that requires Windows
    }
}
```

## How to fix violations

Replace the runtime check with the `[OSCondition]` attribute.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestClass
{
    [TestMethod]
    [OSCondition(OperatingSystems.Windows)]
    public void TestMethod()
    {
        // Test code that requires Windows
    }
}
```

The `[OSCondition]` attribute supports the following operating systems:

- `OperatingSystems.Linux`
- `OperatingSystems.OSX` (macOS)
- `OperatingSystems.Windows`
- `OperatingSystems.FreeBSD`

You can also combine multiple operating systems using bitwise `OR`:

```csharp
[TestMethod]
[OSCondition(OperatingSystems.Windows | OperatingSystems.Linux)]
public void TestMethod()
{
    // Test code that requires Windows or Linux
}
```

## When to suppress warnings

You might suppress this warning if your runtime check is more complex than a simple early return pattern, or if you need to perform conditional logic that cannot be expressed using the `[OSCondition]` attribute.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0061
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0061
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0061.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
