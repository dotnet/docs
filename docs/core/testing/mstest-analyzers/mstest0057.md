---
title: "MSTEST0057: Propagate source information in custom test method attributes"
description: "Learn about code analysis rule MSTEST0057: Propagate source information in custom test method attributes"
ms.date: 12/29/2024
f1_keywords:
- MSTEST0057
- TestMethodAttributeShouldPropagateSourceInformationAnalyzer
helpviewer_keywords:
- TestMethodAttributeShouldPropagateSourceInformationAnalyzer
- MSTEST0057
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
- VB
---
# MSTEST0057: Propagate source information in custom test method attributes

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0057                                         |
| **Title**                           | Propagate source information in custom test method attributes |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.0.0                                              |
| **Is there a code fix**             | Yes                                                |

## Cause

A custom <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> class does not propagate caller information to the base class constructor.

## Rule description

When creating custom test method attributes that derive from `TestMethodAttribute`, you should propagate source information using caller information attributes. This allows MSTest to correctly track the source file and line number for test methods, improving diagnostics and test result reporting.

```csharp
public class MyTestMethodAttribute : TestMethodAttribute
{
    public MyTestMethodAttribute() // Violation
        : base()
    {
    }
}
```

## How to fix violations

Add `CallerFilePath` and `CallerLineNumber` parameters to the constructor and pass them to the base class.

```csharp
using System.Runtime.CompilerServices;

public class MyTestMethodAttribute : TestMethodAttribute
{
    public MyTestMethodAttribute(
        [CallerFilePath] string callerFilePath = "", 
        [CallerLineNumber] int callerLineNumber = -1)
        : base(callerFilePath, callerLineNumber)
    {
    }
}
```

## When to suppress warnings

Do not suppress warnings from this rule. Propagating source information is essential for proper test reporting and diagnostics.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0057
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0057
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0057.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
