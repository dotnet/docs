---
title: MSTest assertions
description: Learn about MSTest assertions including Assert, StringAssert, and CollectionAssert classes for validating test results.
author: Evangelink
ms.author: amauryleve
ms.date: 06/04/2026
ai-usage: ai-assisted
---

# MSTest assertions

Use the `Assert` classes of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace to verify specific functionality. A test method exercises the code in your application but reports correctness only when you include `Assert` statements.

## Overview

MSTest provides three assertion classes:

| Class | Purpose |
|-------|---------|
| `Assert` | General-purpose assertions for values, types, and exceptions. |
| `StringAssert` | String-specific assertions for patterns, substrings, and comparisons. |
| `CollectionAssert` | Collection assertions for comparing and validating collections. |

> [!IMPORTANT]
> For new code, always use the `Assert` class. The `StringAssert` and `CollectionAssert` classes are likely to be deprecated in a future release. They're maintained primarily for backward compatibility, but they're not recommended because splitting assertions across three types hurts discoverability—you can't see all available checks in a single IntelliSense list.

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

> [!WARNING]
> The `StringAssert` class is likely to be deprecated in a future release. It's maintained for backward compatibility only and isn't recommended for new code. All `StringAssert` methods have equivalents on the `Assert` class, which offers better discoverability. To migrate existing usages, see analyzer [MSTEST0046](mstest-analyzers/mstest0046.md).

Available APIs are:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Contains*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.DoesNotMatch*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.EndsWith*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Matches*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.StartsWith*?displayProperty=nameWithType>

## The `CollectionAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> class to compare collections of objects, or to verify the state of a collection.

> [!WARNING]
> The `CollectionAssert` class is likely to be deprecated in a future release. It's maintained primarily for backward compatibility and isn't recommended for new code. When an equivalent method exists on `Assert` (such as `Assert.Contains`, `Assert.DoesNotContain`, or `Assert.HasCount`), use `Assert` for better discoverability.

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

## Create custom assertions with `Assert.That`

The built-in assertion methods don't cover every scenario. To extend the assertion infrastructure with your own checks, MSTest exposes the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That?displayProperty=nameWithType> singleton property as an extensibility hook. You add custom assertions as C# extension methods on the `Assert` instance type, and callers invoke them with the familiar `Assert.That.MyAssertion(...)` syntax.

For better discoverability, organize project-wide assertions in a dedicated static class. Custom assertions reached through `Assert.That` show up alongside the built-in methods in IntelliSense, so consumers don't have to remember a separate helper type.

### Author a custom assertion

Add an extension method that targets the `Assert` type and throws <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException> when the condition fails:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

public static class CustomAssertExtensions
{
    public static void IsPrime(this Assert assert, int value)
    {
        if (value < 2 || Enumerable.Range(2, (int)Math.Sqrt(value) - 1).Any(i => value % i == 0))
        {
            throw new AssertFailedException($"Assert.That.IsPrime failed. Value <{value}> is not a prime number.");
        }
    }
}
```

### Use a custom assertion

After you import the namespace that contains your extension methods, call your custom assertion through `Assert.That`:

```csharp
[TestMethod]
public void Compute_ReturnsPrime()
{
    int result = _calculator.NextPrime(10);
    Assert.That.IsPrime(result);
}
```

### Extension hooks on `StringAssert` and `CollectionAssert`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.That?displayProperty=nameWithType> and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.That?displayProperty=nameWithType> properties expose the same singleton pattern for backward compatibility. For new custom assertions, always target `Assert.That`. Otherwise, your helpers inherit the same discoverability problems as the legacy classes, and they'll need migration if `StringAssert` and `CollectionAssert` are deprecated.

> [!NOTE]
> Don't confuse the `Assert.That` singleton *property*—used as an extensibility hook—with the `Assert.That(() => condition)` extension *method* added in MSTest 3.8. The latter accepts a boolean expression and produces detailed failure messages by analyzing the expression tree (for example, `Assert.That(() => order.Total > 0)`). The two APIs share a name but serve different purposes.

## Best practices

1. **Use specific assertions**: Prefer `AreEqual` over `IsTrue(a == b)` for better failure messages.

1. **Include descriptive messages**: Help identify failures quickly with clear assertion messages.

1. **Test one thing at a time**: Each test method should verify a single behavior.

1. **Use `Throws`/`ThrowsExactly` for exceptions**: In MSTest v3.8+, prefer `Assert.Throws`, `Assert.ThrowsExactly`, and their async counterparts (`ThrowsAsync`, `ThrowsExactlyAsync`) over the `ExpectedException` attribute.

1. **Prefer `Assert` over `StringAssert`/`CollectionAssert`**: For better discoverability and consistency, use the `Assert` class. The `StringAssert` and `CollectionAssert` classes are likely to be deprecated in a future release.

1. **Extend `Assert.That` for custom assertions**: For consistent discoverability, add custom assertions as extension methods on `Assert` and invoke them through `Assert.That`. Don't target `StringAssert.That` or `CollectionAssert.That` in new code.

## Related analyzers

The following analyzers help ensure proper usage of assertions:

- [MSTEST0006](mstest-analyzers/mstest0006.md) - Avoid `ExpectedException` attribute, use `Assert.Throws` methods instead.
- [MSTEST0017](mstest-analyzers/mstest0017.md) - Assertion arguments should be passed in the correct order.
- [MSTEST0023](mstest-analyzers/mstest0023.md) - Do not negate boolean assertions.
- [MSTEST0025](mstest-analyzers/mstest0025.md) - Prefer `Assert.Fail` over always-false conditions.
- [MSTEST0026](mstest-analyzers/mstest0026.md) - Assertion arguments should avoid conditional access.
- [MSTEST0032](mstest-analyzers/mstest0032.md) - Review always-true assert conditions.
- [MSTEST0037](mstest-analyzers/mstest0037.md) - Use proper assert methods.
- [MSTEST0038](mstest-analyzers/mstest0038.md) - Avoid `Assert.AreSame` with value types.
- [MSTEST0039](mstest-analyzers/mstest0039.md) - Use newer `Assert.Throws` methods.
- [MSTEST0040](mstest-analyzers/mstest0040.md) - Avoid using asserts in async void context.
- [MSTEST0046](mstest-analyzers/mstest0046.md) - Use `Assert` instead of `StringAssert`.
- [MSTEST0051](mstest-analyzers/mstest0051.md) - `Assert.Throws` should contain a single statement.
- [MSTEST0053](mstest-analyzers/mstest0053.md) - Avoid `Assert` format parameters.
- [MSTEST0058](mstest-analyzers/mstest0058.md) - Avoid asserts in catch blocks.

## See also

- [Write tests in MSTest](unit-testing-mstest-writing-tests.md)
- [Data-driven testing](unit-testing-mstest-writing-tests-data-driven.md)
- [TestContext class](unit-testing-mstest-writing-tests-testcontext.md)
- [MSTest analyzers](mstest-analyzers/overview.md)
