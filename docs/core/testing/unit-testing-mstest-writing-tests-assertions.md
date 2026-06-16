---
title: MSTest assertions
description: Learn about MSTest assertions including Assert, StringAssert, and CollectionAssert classes for validating test results.
author: Evangelink
ms.author: amauryleve
ms.date: 06/16/2026
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

### Soft assertions with `Assert.Scope()`

> [!IMPORTANT]
> `Assert.Scope()` is an experimental API. Using it produces the `MSTESTEXP` diagnostic, which you must suppress (for example, with `#pragma warning disable MSTESTEXP` or in your project's _.editorconfig_) to acknowledge that the shape and behavior of the API can change in future releases.

By default, every assertion throws an <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException> as soon as it fails, which ends the test immediately. <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Scope> introduces *soft assertions*: while a scope is active, assertion failures are collected instead of thrown, so execution continues and you can see every failure in the scope at once. When the scope is disposed, the collected failures are reported together:

```csharp
[TestMethod]
public void ValidatePerson()
{
    using (Assert.Scope())
    {
        Assert.AreEqual("Jane", person.FirstName); // failure collected, execution continues
        Assert.AreEqual("Doe", person.LastName);   // failure collected, execution continues
        Assert.IsTrue(person.IsActive);            // failure collected, execution continues
    }
    // On Dispose, all collected failures are reported together.
}
```

When the scope is disposed:

- If exactly one failure was collected, the original `AssertFailedException` is thrown.
- If multiple failures were collected, a single `AssertFailedException` is thrown that wraps all of them in an `AggregateException`.

#### Postconditions aren't enforced inside a scope

Because a failing assertion no longer throws inside a scope, code that runs after it can't rely on the assertion having succeeded. This applies to *every* postcondition, including nullability and type narrowing:

```csharp
using (Assert.Scope())
{
    Assert.IsNotNull(item);
    // 'item' might still be null here: the failure was collected, not thrown.
    Assert.AreEqual("expected", item.Value);
    // 'item.Value' might not equal "expected" either.
}
```

If a failed assertion would lead to a `NullReferenceException` (or any other exception) on a later line within the scope, that secondary exception is a symptom of the already-collected failure, not a separate bug. The original assertion failure is still reported when the scope is disposed.

#### Value-returning assertions return `null`/`default` on failure inside a scope

Some assertions return a value on success — for example, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Throws*> and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExactly*> return the caught exception, and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ContainsSingle*> returns the matched element. When one of these assertions *fails* inside a scope, the failure is collected and the method returns `null`/`default` instead of throwing:

```csharp
using (Assert.Scope())
{
    // No exception is thrown by the lambda, so the assertion fails. The failure is
    // collected and 'ex' is null. Accessing 'ex' below throws NullReferenceException.
    InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => { });
    _ = ex.Message; // NullReferenceException — don't use the return value in a scope
}
```

Don't rely on the value returned by a soft assertion inside a scope. If you need the returned value (such as the caught exception), call the assertion *outside* the scope, or restructure the test so nothing depends on the return value until after the scope is disposed.

#### `Assert.Fail` and `Assert.Inconclusive` always throw

<xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail*> and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive*> are never soft. They always throw immediately, even inside a scope, because they express an unconditional test outcome. Use one of them when a condition is critical and the rest of the test can't meaningfully continue without it.

#### Nested scopes aren't supported

You can't nest `Assert.Scope()` calls. Only one assertion scope can be active at a time.

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
