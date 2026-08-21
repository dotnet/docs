---
title: "MSTEST0069: Inherited [TestClass] is ignored by the MSTest source generator"
description: "Learn about code analysis rule MSTEST0069: Inherited [TestClass] is ignored by the MSTest source generator"
ms.date: 06/30/2026
f1_keywords:
- MSTEST0069
- InheritedTestClassAttributeWithSourceGeneratorAnalyzer
helpviewer_keywords:
- InheritedTestClassAttributeWithSourceGeneratorAnalyzer
- MSTEST0069
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0069: Inherited \[TestClass] is ignored by the MSTest source generator

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0069                                          |
| **Title**                           | Inherited \[TestClass] is ignored by the MSTest source generator |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.3.0                                              |
| **Is there a code fix**             | No                                                 |

> [!NOTE]
> This analyzer ships in the `MSTest.SourceGeneration` package and is only loaded for projects that have opted into the [MSTest reflection source generator](../unit-testing-mstest-sdk.md), which is an experimental feature. It doesn't apply when the default reflection-based discovery is used.

## Cause

A class is intended as an MSTest test class through a `[TestClass]` attribute that it inherits from a base class, rather than declaring `[TestClass]` directly.

## Rule description

The MSTest source generator enumerates test classes using `ForAttributeWithMetadataName`, which doesn't follow inheritance. A class that relies on inheriting `[TestClass]` from a base type is silently skipped from source-generated discovery and won't be runnable when the source-generated provider is the active reflection backend.

```csharp
[TestClass]
public class BaseTests
{
}

// Violation: relies on the inherited [TestClass] attribute.
public class DerivedTests : BaseTests
{
    [TestMethod]
    public void Test()
    {
    }
}
```

## How to fix violations

Apply `[TestClass]` directly to the derived class so it's discovered when source-generated discovery is active.

```csharp
[TestClass]
public class BaseTests
{
}

[TestClass]
public class DerivedTests : BaseTests
{
    [TestMethod]
    public void Test()
    {
    }
}
```

## When to suppress warnings

Don't suppress warnings from this rule when source generation is enabled, because the affected test class won't be discovered or executed. You can suppress it if the class isn't actually meant to be a test class.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0069
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0069
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0069.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
