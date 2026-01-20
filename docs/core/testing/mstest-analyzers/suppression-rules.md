---
title: MSTest Suppression rules (code analysis)
description: Learn about MSTest code suppression rules.
author: evangelink
ms.author: amauryleve
ms.date: 12/20/2023
---

# MSTest suppression rules

Suppression rules automatically suppress diagnostics from other analyzers (like Roslyn or Visual Studio threading analyzers) that don't apply in the context of MSTest tests.

## Rules in this category

| Rule ID | Title | Suppresses | 
|---------|-------|------------|
| [MSTEST0027](mstest0027.md) | Suppress async suffix for test methods | VSTHRD200 |
| [MSTEST0028](mstest0028.md) | Suppress async suffix for test fixture methods | VSTHRD200 |
| [MSTEST0033](mstest0033.md) | Suppress non-nullable reference not initialized | CS8618 |

## How suppression rules work

These rules don't produce their own diagnostics. Instead, they suppress warnings from other analyzers that would otherwise trigger incorrectly in test code.

### VSTHRD200: Use Async suffix for async methods

**Suppressed by**: [MSTEST0027](mstest0027.md), [MSTEST0028](mstest0028.md)

**Why suppress**: Visual Studio threading analyzer (VSTHRD200) recommends that async methods should have an "Async" suffix. However, test methods and test fixture methods are discovered by MSTest through attributes, not naming conventions. Adding "Async" suffixes to test method names (for example, `TestLoginAsync`) provides no value and can make test names less readable.

**Example**:

```csharp
[TestMethod]
public async Task TestLogin() // VSTHRD200 would warn without suppression
{
    await LoginAsync();
    // ...
}
```

### CS8618: Non-nullable reference not initialized

**Suppressed by**: [MSTEST0033](mstest0033.md)

**Why suppress**: When using nullable reference types, the compiler warns about non-nullable properties that aren't initialized in constructors. However, MSTest automatically initializes the `TestContext` property before any test methods run, so the warning doesn't apply.

**Example**:

```csharp
[TestClass]
public class MyTests
{
    public TestContext TestContext { get; set; } = null!; // CS8618 would warn without suppression
    
    [TestMethod]
    public void TestSomething()
    {
        // TestContext is guaranteed to be non-null here
        TestContext.WriteLine("Test output");
    }
}
```

## Disabling suppression rules

If you prefer to see these warnings, you can disable the suppression rules in your `.editorconfig`:

```ini
[*.cs]
dotnet_diagnostic.MSTEST0027.severity = none
dotnet_diagnostic.MSTEST0028.severity = none
dotnet_diagnostic.MSTEST0033.severity = none
```

## Related documentation

- [TestContext](../unit-testing-mstest-writing-tests-testcontext.md)
- [Lifecycle](../unit-testing-mstest-writing-tests-lifecycle.md)
