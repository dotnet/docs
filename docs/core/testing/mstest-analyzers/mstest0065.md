---
title: "MSTEST0065: Avoid Assert.AreEqual on collection types"
description: "Learn about code analysis rule MSTEST0065: Avoid Assert.AreEqual on collection types"
ms.date: 06/04/2026
f1_keywords:
- MSTEST0065
- AvoidAssertAreEqualOnCollectionsAnalyzer
helpviewer_keywords:
- AvoidAssertAreEqualOnCollectionsAnalyzer
- MSTEST0065
author: Evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0065: Avoid `Assert.AreEqual` on collection types

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0065                                         |
| **Title**                           | Avoid `Assert.AreEqual` on collection types        |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.3.0                                              |
| **Is there a code fix**             | No                                                 |

> [!NOTE]
> This rule is available starting with MSTest 4.3.

## Cause

A call to <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual*?displayProperty=nameWithType> or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual*?displayProperty=nameWithType> is made on a value whose static type implements <xref:System.Collections.Generic.IEnumerable%601> (other than <xref:System.String>).

## Rule description

<xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual*> and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual*> use <xref:System.Collections.Generic.EqualityComparer%601.Default?displayProperty=nameWithType>. For most collection types — for example arrays, <xref:System.Collections.Generic.List%601>, or any user-defined type implementing <xref:System.Collections.Generic.IEnumerable%601> — this falls back to reference equality (or to whatever equality the type defines for itself), and not to element-wise comparison. As a result, the assertion almost never asserts what the test author intended.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public void Test()
    {
        var expected = new[] { 1, 2, 3 };
        var actual = new[] { 1, 2, 3 };

        // Violation: this compares references, not contents, and fails.
        Assert.AreEqual(expected, actual);
    }
}
```

## How to fix violations

Choose the assertion that matches your intent:

- Use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSequenceEqual*> for ordered element-wise comparison.
- Use `Assert.AreSequenceEqual(expected, actual, SequenceOrder.InAnyOrder)` for unordered element-wise comparison.
- Use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEquivalent*> for deep structural comparison.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public void Test()
    {
        var expected = new[] { 1, 2, 3 };
        var actual = new[] { 1, 2, 3 };

        Assert.AreSequenceEqual(expected, actual);
    }
}
```

## When to suppress warnings

Suppress this warning only if the type defines its own `Equals`/`GetHashCode` to compare contents and you intentionally rely on that.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0065
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0065
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0065.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
