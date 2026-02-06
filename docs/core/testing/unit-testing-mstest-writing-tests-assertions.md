---
title: MSTest assertions
description: Learn about MSTest assertions including Assert, StringAssert, and CollectionAssert classes for validating test results.
author: Evangelink
ms.author: amauryleve
ms.date: 07/15/2025
---

# MSTest assertions

Use the `Assert` classes of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace to verify specific functionality. A test method exercises the code in your application but reports correctness only when you include `Assert` statements.

## Overview

MSTest provides three assertion classes:

| Class | Purpose |
|-------|---------|
| `Assert` | General-purpose assertions for values, types, and exceptions |
| `StringAssert` | String-specific assertions for patterns, substrings, and comparisons |
| `CollectionAssert` | Collection assertions for comparing and validating collections |

> [!TIP]
> When functionality exists in both `Assert` and `StringAssert`/`CollectionAssert`, prefer the `Assert` class. The `Assert` class provides better discoverability and is the recommended choice for new code. `StringAssert` and `CollectionAssert` are maintained for backward compatibility.

All assertion methods accept an optional message parameter that displays when the assertion fails, helping you identify the cause:

```csharp
Assert.AreEqual(expected, actual, "Values should match after processing");
```

## The `Assert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> class to verify that the code under test behaves as expected.

### Common assertion methods

```csharp
[TestMethod]
public async Task AssertExamples()
{
    // Equality
    Assert.AreEqual(5, calculator.Add(2, 3));
    Assert.AreNotEqual(0, result);

    // Reference equality
    Assert.AreSame(expected, actual);
    Assert.AreNotSame(obj1, obj2);

    // Boolean conditions
    Assert.IsTrue(result > 0);
    Assert.IsFalse(string.IsNullOrEmpty(name));

    // Null checks
    Assert.IsNull(optionalValue);
    Assert.IsNotNull(requiredValue);

    // Type checks
    Assert.IsInstanceOfType<IDisposable>(obj);
    Assert.IsNotInstanceOfType<string>(obj);

    // Exception testing (MSTest v3.8+)
    Assert.ThrowsExactly<ArgumentNullException>(() => service.Process(null!));
    await Assert.ThrowsExactlyAsync<InvalidOperationException>(
        async () => await service.ProcessAsync());
}
```

### Available APIs

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotSame*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Contains*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ContainsSingle*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.DoesNotContain*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.DoesNotEndWith*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.DoesNotMatchRegex*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.DoesNotStartWith*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.HasCount*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsEmpty*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsGreaterThan*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsGreaterThanOrEqualTo*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInRange*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsLessThan*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsLessThanOrEqualTo*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNegative*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotEmpty*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotInstanceOfType*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsPositive*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.MatchesRegex*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.StartsWith*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Throws*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsAsync*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExactly*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExactlyAsync*?displayProperty=nameWithType>

## The `StringAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> class to compare and examine strings.

> [!NOTE]
> All `StringAssert` methods have equivalents in the `Assert` class. Prefer the `Assert` methods for better discoverability. The `StringAssert` class is maintained for backward compatibility.

Available APIs are:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Contains*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.DoesNotMatch*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.EndsWith*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Matches*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.StartsWith*?displayProperty=nameWithType>

## The `CollectionAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> class to compare collections of objects, or to verify the state of a collection.

> [!NOTE]
> When an equivalent method exists in the `Assert` class (such as `Assert.Contains`, `Assert.DoesNotContain`), prefer using `Assert` for better discoverability. The `CollectionAssert` class is maintained primarily for backward compatibility.

Available APIs are:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreInstancesOfType*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreNotNull*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreUnique*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEqual*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEquivalent*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreNotEqual*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreNotEquivalent*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.Contains*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.DoesNotContain*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.IsNotSubsetOf*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.IsSubsetOf*?displayProperty=nameWithType>

## Best practices

1. **Use specific assertions**: Prefer `AreEqual` over `IsTrue(a == b)` for better failure messages.

1. **Include descriptive messages**: Help identify failures quickly with clear assertion messages.

1. **Test one thing at a time**: Each test method should verify a single behavior.

1. **Use `Throws`/`ThrowsExactly` for exceptions**: In MSTest v3.8+, prefer `Assert.Throws`, `Assert.ThrowsExactly`, and their async counterparts (`ThrowsAsync`, `ThrowsExactlyAsync`) over the `ExpectedException` attribute.

1. **Prefer `Assert` over `StringAssert`/`CollectionAssert`**: When functionality exists in both classes, use the `Assert` class for better discoverability and consistency.

## See also

- [Write tests in MSTest](unit-testing-mstest-writing-tests.md)
- [Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md)
- [TestContext class](unit-testing-mstest-writing-tests-testcontext.md)
- [MSTest analyzers](mstest-analyzers/overview.md)
