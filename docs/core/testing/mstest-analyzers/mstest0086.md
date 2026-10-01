---
title: "MSTEST0086: Remove redundant test method attribute"
description: "Learn about code analysis rule MSTEST0086: Remove redundant test method attribute"
ms.date: 10/01/2026
f1_keywords:
- MSTEST0086
- RedundantTestMethodAttributeAnalyzer
helpviewer_keywords:
- RedundantTestMethodAttributeAnalyzer
- MSTEST0086
author: evangelink
ms.author: amauryleve
ai-usage: ai-generated
dev_langs:
- CSharp
- VB
---
# MSTEST0086: Remove redundant test method attribute

| Property | Value |
|---|---|
| **Rule ID** | MSTEST0086 |
| **Title** | Remove redundant test method attribute |
| **Category** | Usage |
| **Fix is breaking or non-breaking** | Non-breaking |
| **Enabled by default** | Yes |
| **Default severity** | Info |
| **Introduced in version** | 4.5.0 (preview) |
| **Is there a code fix** | Yes, for C# only |

## Cause

A test method declares an MSTest attribute whose effective behavior is already supplied by its containing test class or a base test class.

## Rule description

Duplicate attributes make the effective test policy harder to understand and maintain. The rule reports method-level conditions, retry settings, isolation settings, metadata, deployment items, or dependencies only when the class-level configuration already provides equivalent or more restrictive behavior.

The rule covers `OSCondition`, `ArchitectureCondition`, `CICondition`, `DoNotParallelize`, `ResourceLock`, `Retry`, `Ignore`, `TestCategory`, `TestProperty`, `DeploymentItem`, and `DependsOn`.

```csharp
[TestClass, DoNotParallelize]
public class Tests
{
    [TestMethod, DoNotParallelize] // Violation
    public void Test() { }
}
```

## How to fix violations

Remove the redundant method-level attribute. Keep an attribute on the method when it changes or narrows the class-level behavior.

```csharp
[TestClass, DoNotParallelize]
public class Tests
{
    [TestMethod] public void Test() { }
}
```

A C# code fix removes the redundant attribute. Visual Basic reports the diagnostic but doesn't provide an automatic fix.

## When to suppress warnings

Suppress the rule when the duplicate attribute intentionally documents a local policy and that documentation value outweighs the maintenance cost.

## Suppress a warning

```csharp
#pragma warning disable MSTEST0086
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0086
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0086.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Write tests with MSTest](../unit-testing-mstest-writing-tests.md)
- [Test execution and control](../unit-testing-mstest-writing-tests-controlling-execution.md)
