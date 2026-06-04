---
title: "MSTEST0068: Use Assert instead of CollectionAssert"
description: "Learn about code analysis rule MSTEST0068: Use Assert instead of CollectionAssert"
ms.date: 06/04/2026
f1_keywords:
- MSTEST0068
- CollectionAssertToAssertAnalyzer
helpviewer_keywords:
- CollectionAssertToAssertAnalyzer
- MSTEST0068
author: Evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0068: Use Assert instead of CollectionAssert

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0068                                         |
| **Title**                           | Use `Assert` instead of `CollectionAssert`         |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 4.3.0                                              |
| **Is there a code fix**             | Yes                                                |

> [!NOTE]
> This rule is available starting with MSTest 4.3.

## Cause

A test method uses <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> methods instead of equivalent <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods.

## Rule description

Most <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> methods have equivalent counterparts in <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> that provide the same functionality. Prefer the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods for consistency, better readability, improved discoverability, and alignment with behavior across all test frameworks.

The following <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> methods have equivalent <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods:

- `CollectionAssert.AreEqual(a, b)` → `Assert.AreSequenceEqual(a, b)`
- `CollectionAssert.AreNotEqual(a, b)` → `Assert.AreNotSequenceEqual(a, b)`
- `CollectionAssert.AreEquivalent(a, b)` → `Assert.AreSequenceEqual(a, b, SequenceOrder.InAnyOrder)`
- `CollectionAssert.AreNotEquivalent(a, b)` → `Assert.AreNotSequenceEqual(a, b, SequenceOrder.InAnyOrder)`
- `CollectionAssert.AllItemsAreNotNull(a)` → `Assert.AreAllNotNull(a)`
- `CollectionAssert.AllItemsAreUnique(a)` → `Assert.AreAllDistinct(a)`
- `CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(T))` → `Assert.AreAllOfType<T>(collection)`
- `CollectionAssert.Contains(collection, value)` → `Assert.Contains(value, collection)`
- `CollectionAssert.DoesNotContain(collection, value)` → `Assert.DoesNotContain(value, collection)`

> [!WARNING]
> When migrating from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> to <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert>, be careful about the change in parameter order for `Contains`, `DoesNotContain`, and `AllItemsAreInstancesOfType`. In <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert>, the expected value is always the first parameter.

Overloads of `AreEqual`/`AreNotEqual` that take an <xref:System.Collections.IComparer> are skipped because <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSequenceEqual*> expects an <xref:System.Collections.Generic.IEqualityComparer%601> (different semantics). Overloads of `AreEquivalent`/`AreNotEquivalent` that take an <xref:System.Collections.Generic.IEqualityComparer%601> are also skipped. `IsSubsetOf`/`IsNotSubsetOf` have no direct <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> equivalent today and are not handled.

## How to fix violations

Use the provided code fixer to automatically replace <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> method calls with their equivalent <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods. You can also manually replace the method calls if needed.

## When to suppress warnings

Don't suppress warnings from this rule. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods provide the same functionality with better consistency.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0068
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0068
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0068.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
