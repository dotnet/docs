---
title: "MSTEST0085: '[TestClass]' should not be applied to abstract classes"
description: "Learn about code analysis rule MSTEST0085: '[TestClass]' should not be applied to abstract classes"
ms.date: 10/01/2026
f1_keywords:
- MSTEST0085
- TestClassAttributeShouldNotBeAppliedToAbstractClassAnalyzer
helpviewer_keywords:
- TestClassAttributeShouldNotBeAppliedToAbstractClassAnalyzer
- MSTEST0085
author: evangelink
ms.author: amauryleve
ai-usage: ai-generated
dev_langs:
- CSharp
- VB
---
# MSTEST0085: '\[TestClass]' should not be applied to abstract classes

| Property | Value |
|---|---|
| **Rule ID** | MSTEST0085 |
| **Title** | `[TestClass]` should not be applied to abstract classes |
| **Category** | Usage |
| **Fix is breaking or non-breaking** | Non-breaking |
| **Enabled by default** | Yes |
| **Default severity** | Info |
| **Introduced in version** | 4.5.0 (preview) |
| **Is there a code fix** | No |

## Cause

An abstract class declares <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> or an attribute that derives from it.

## Rule description

MSTest can't instantiate or discover an abstract class as a test class, so `[TestClass]` has no effect on the abstract type. Test methods declared in an abstract base class are discovered through concrete derived classes. Each concrete class must declare its own `[TestClass]` attribute because test-class attributes aren't inherited.

```csharp
[TestClass] // Violation
public abstract class SharedTests
{
    [TestMethod] public void CommonTest() { }
}
```

## How to fix violations

Remove `[TestClass]` from the abstract base class, and apply it to each concrete derived test class.

```csharp
public abstract class SharedTests { }

[TestClass]
public sealed class ConcreteTests : SharedTests { }
```

## When to suppress warnings

Don't suppress this rule. The attribute on the abstract class doesn't make the class discoverable, and concrete derived classes still require `[TestClass]`.

## Suppress a warning

```csharp
#pragma warning disable MSTEST0085
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0085
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0085.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Write tests with MSTest](../unit-testing-mstest-writing-tests.md)
- [MSTEST0002: Test class should be valid](mstest0002.md)
- [MSTEST0069: Inherited TestClass is ignored by the MSTest source generator](mstest0069.md)
