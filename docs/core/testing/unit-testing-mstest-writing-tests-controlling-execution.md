---
title: Test execution and control in MSTest
description: Learn how to control test execution in MSTest with parallelization, threading, timeouts, retries, and conditional execution.
author: Evangelink
ms.author: amauryleve
ms.date: 07/15/2025
---

# Test execution and control in MSTest

MSTest provides attributes to control how tests execute, including parallelization, threading models, timeouts, retries, and conditional execution based on platform or environment.

## Threading attributes

Threading attributes control which thread model test methods use. These attributes are essential when testing COM components, UI elements, or code with specific threading requirements.

### `STATestClassAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.STATestClassAttribute> runs all test methods in a class (including `ClassInitialize` and `ClassCleanup`) in a single-threaded apartment (STA). Use this attribute when testing COM objects that require STA.

```csharp
[STATestClass]
public class ComInteropTests
{
    [TestMethod]
    public void TestComComponent()
    {
        // This test runs in an STA thread
        var comObject = new SomeComObject();
        // Test COM interactions
    }
}
```

> [!NOTE]
> This attribute is only supported on Windows in MSTest v3.6 and later.

### `STATestMethodAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.STATestMethodAttribute> runs a specific test method in a single-threaded apartment. Use this attribute for individual tests that need STA while other tests in the class don't.

```csharp
[TestClass]
public class MixedThreadingTests
{
    [STATestMethod]
    public void TestRequiringSTA()
    {
        // This test runs in an STA thread
    }

    [TestMethod]
    public void RegularTest()
    {
        // This test uses default threading
    }
}
```

> [!NOTE]
> This attribute is only supported on Windows in MSTest v3.6 and later.

#### Preserve STA context for async continuations

Starting with MSTest 4.1, the `STATestMethodAttribute` includes a `UseSTASynchronizationContext` property that ensures async continuations run on the same STA thread. When enabled, the attribute creates a custom `SynchronizationContext` that posts continuations back to the STA thread, which is essential for testing UI components that require STA threading throughout their async operations.

```csharp
[TestClass]
public class UIComponentTests
{
    [STATestMethod(UseSTASynchronizationContext = true)]
    public async Task TestAsyncUIOperation()
    {
        // Initial code runs on STA thread
        var control = new MyControl();
        
        await control.LoadDataAsync();
        
        // Continuation also runs on STA thread,
        // ensuring UI operations remain valid
        Assert.IsTrue(control.IsDataLoaded);
    }
}
```

> [!TIP]
> Use `UseSTASynchronizationContext = true` when testing Windows Forms or WPF components that perform async operations and expect their continuations to run on the same thread.

### `UITestMethodAttribute`

The `UITestMethod` attribute schedules test execution on the UI thread. This attribute is designed for testing UWP and WinUI applications that require UI thread access.

```csharp
[TestClass]
public class WinUITests
{
    [UITestMethod]
    public void TestUIComponent()
    {
        // This test runs on the UI thread
        var button = new Button();
        button.Content = "Click me";
        Assert.IsNotNull(button.Content);
    }
}
```

> [!NOTE]
> This attribute requires the appropriate MSTest adapter for UWP or WinUI platforms. For more information, see the [platform support](unit-testing-mstest-intro.md#supported-platforms) section.

## Parallelization attributes

Parallelization attributes control whether and how tests run concurrently, improving test execution time.

### `ParallelizeAttribute`

By default, MSTest runs tests sequentially. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ParallelizeAttribute> assembly-level attribute enables parallel test execution.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]
```

#### Parallelization scope

| Scope | Behavior |
|-------|----------|
| `ClassLevel` | Multiple test classes run in parallel, but tests within a class run sequentially |
| `MethodLevel` | Individual test methods can run in parallel, regardless of their class |

#### Worker threads

The `Workers` property specifies the maximum number of threads for parallel execution:

- `0` (default): Use the number of logical processors on the machine
- Any positive integer: Use that specific number of threads

```csharp
// Parallelize at class level with 2 worker threads
[assembly: Parallelize(Workers = 2, Scope = ExecutionScope.ClassLevel)]
```

> [!TIP]
> You can also configure parallelization through [runsettings](unit-testing-mstest-configure.md#mstest-element) or [testconfig.json](unit-testing-mstest-configure.md#testconfigjson) without modifying code.

> [!TIP]
> Enable parallelization at the assembly level by default, even if many tests currently require sequential execution. This approach encourages writing new tests that support parallel execution from the start. Use the [MSTEST0001](mstest-analyzers/mstest0001.md) analyzer to ensure that the assembly explicitly declares its parallelization intent with `[assembly: Parallelize]` or `[assembly: DoNotParallelize]`. Once parallelization is enabled, review each test class to determine whether it safely supports concurrent execution. Often, excluding just a few classes or methods with `DoNotParallelize` is sufficient, allowing the majority of your tests to run in parallel for significantly faster test execution.

### `DoNotParallelizeAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DoNotParallelizeAttribute> prevents parallel execution for specific assemblies, classes, or methods. Use this attribute when tests share state or resources that can't be safely accessed concurrently.

```csharp
[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

[TestClass]
public class ParallelTests
{
    [TestMethod]
    public void CanRunInParallel()
    {
        // This test can run with others
    }
}

[TestClass]
[DoNotParallelize]
public class SequentialTests
{
    [TestMethod]
    public void MustRunSequentially()
    {
        // This class's tests run sequentially
    }
}

[TestClass]
public class MixedTests
{
    [TestMethod]
    public void CanRunInParallel()
    {
        // This test can run with others
    }

    [TestMethod]
    [DoNotParallelize]
    public void MustBeIsolated()
    {
        // This specific test doesn't run in parallel
    }
}
```

> [!NOTE]
> You only need `DoNotParallelize` when you've enabled parallel execution with the `Parallelize` attribute.

## Timeout attributes

Timeout attributes prevent tests from running indefinitely and help identify performance issues.

### `TimeoutAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute> specifies the maximum time (in milliseconds) a test or fixture method can run. If execution exceeds this time, the test fails.

```csharp
[TestClass]
public class TimeoutTests
{
    [TestMethod]
    [Timeout(5000)] // 5 seconds
    public void TestWithTimeout()
    {
        // Test must complete within 5 seconds
    }
}
```

> [!TIP]
> You can configure a global test timeout through [runsettings](unit-testing-mstest-configure.md#mstest-element) (`TestTimeout`) or [testconfig.json](unit-testing-mstest-configure.md#timeout-settings) (`timeout.test`) without modifying code.

#### Apply timeout to fixture methods

You can also apply timeouts to initialization and cleanup methods:

```csharp
[TestClass]
public class FixtureTimeoutTests
{
    [ClassInitialize]
    [Timeout(10000)]
    public static void ClassInit(TestContext context)
    {
        // Must complete within 10 seconds
    }

    [TestInitialize]
    [Timeout(2000)]
    public void TestInit()
    {
        // Must complete within 2 seconds
    }
}
```

> [!TIP]
> Every fixture method that accepts a `[Timeout]` attribute has an equivalent global configuration setting. Configure timeouts globally through [runsettings](unit-testing-mstest-configure.md#mstest-element) or [testconfig.json](unit-testing-mstest-configure.md#timeout-settings) using settings like `TestInitializeTimeout`, `ClassInitializeTimeout`, `AssemblyInitializeTimeout`, and their cleanup counterparts.

> [!NOTE]
> Timeouts aren't guaranteed to be precisely accurate. The test aborts after the specified time passes, but the actual cancellation might take slightly longer.

### Cooperative cancellation

By default, MSTest wraps each timed test method in a separate task or thread. When the timeout is reached, the framework stops observing the test, but the underlying task continues running in the background. This behavior can cause problems:

- The test method continues to access resources and mutate state even after timeout.
- Background execution can lead to race conditions affecting subsequent tests.
- Each timed method incurs additional overhead from the task/thread wrapper.

Starting with MSTest 3.6, use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TimeoutAttribute.CooperativeCancellation> property to avoid these issues. In cooperative mode, MSTest doesn't wrap your test in an extra task. Instead, when the timeout is reached, the framework signals the cancellation token. Your test code is responsible for checking the token regularly and terminating gracefully.

```csharp
[TestClass]
public class CooperativeTimeoutTests
{
    [TestMethod]
    [Timeout(5000, CooperativeCancellation = true)]
    public async Task TestWithCooperativeCancellation(CancellationToken cancellationToken)
    {
        // Check the token periodically
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(100, cancellationToken);
            // Do work
        }
    }

    [TestMethod]
    [Timeout(5000, CooperativeCancellation = true)]
    public void SyncTestWithCooperativeCancellation(CancellationToken cancellationToken)
    {
        // Works with sync methods too
        for (int i = 0; i < 1000; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            // Do work
        }
    }
}
```

Benefits of cooperative cancellation:

- Lower performance overhead (no extra task/thread wrapper per test).
- Cleaner resource cleanup since your code handles cancellation explicitly.
- Aligns with standard .NET cancellation patterns.
- Deterministic behavior by avoiding race conditions between test code and unobserved background execution.

> [!NOTE]
> Cooperative cancellation requires your test code to check the cancellation token regularly. If your code doesn't check the token, the test won't actually stop when timeout is reached.

> [!TIP]
> You can enable cooperative cancellation globally for all timeout attributes through [runsettings](unit-testing-mstest-configure.md#mstest-element) or [testconfig.json](unit-testing-mstest-configure.md#timeout-settings) instead of setting it on each attribute individually.

> [!TIP]
> Related analyzers:
>
> - [MSTEST0045](mstest-analyzers/mstest0045.md) - recommends using cooperative cancellation for timeout attributes.

## Retry attributes

Retry attributes help handle flaky tests by automatically re-running failed tests.

### `RetryAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryAttribute>, introduced in MSTest 3.8, automatically retries test methods that fail or time out. Configure the maximum retry attempts, delay between retries, and backoff strategy.

```csharp
[TestClass]
public class RetryTests
{
    [TestMethod]
    [Retry(3)] // Retry up to 3 times if the test fails
    public void FlakeyNetworkTest()
    {
        // Test that might occasionally fail due to network issues
    }

    [TestMethod]
    [Retry(3, MillisecondsDelayBetweenRetries = 1000, BackoffType = DelayBackoffType.Exponential)]
    public void TestWithExponentialBackoff()
    {
        // Retries with increasing delays: 1s, 2s, 4s
    }

    [TestMethod]
    [Retry(5, MillisecondsDelayBetweenRetries = 500, BackoffType = DelayBackoffType.Constant)]
    public void TestWithConstantDelay()
    {
        // Retries with constant 500ms delay between attempts
    }
}
```

#### Configuration options

| Property | Description | Default |
|----------|-------------|---------|
| `MaxRetryAttempts` | Maximum number of retry attempts (read-only, set via constructor) | Required |
| `MillisecondsDelayBetweenRetries` | Base delay between retries (in ms) | 0 |
| `BackoffType` | `Constant` or `Exponential` delay | `Constant` |

> [!NOTE]
> Only one `RetryAttribute` can be present on a test method. You can't use `RetryAttribute` on methods that aren't marked with `TestMethod`.

> [!TIP]
> Related analyzers:
>
> - [MSTEST0043](mstest-analyzers/mstest0043.md) - recommends using `RetryAttribute` on test methods.

### Custom retry implementations

Create custom retry logic by inheriting from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryBaseAttribute>:

```csharp
public class CustomRetryAttribute : RetryBaseAttribute
{
    private readonly int _maxRetries;

    public CustomRetryAttribute(int maxRetries)
    {
        _maxRetries = maxRetries;
    }

    // Implement abstract members
    // Add custom logic for retry conditions
}
```

## Conditional execution attributes

Conditional execution attributes control whether tests run based on specific conditions like operating system or CI environment.

### `ConditionBaseAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute> is the abstract base class for conditional execution. MSTest provides several built-in implementations.

> [!NOTE]
> By default, condition attributes aren't inherited. Applying them to a base class doesn't affect derived classes. Custom condition attributes can override this behavior by redefining `AttributeUsage`, but this isn't recommended to maintain consistency with the built-in condition attributes.

> [!TIP]
> Related analyzers:
>
> - [MSTEST0041](mstest-analyzers/mstest0041.md) - recommends using condition-based attributes with test classes.

### `OSConditionAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OSConditionAttribute> runs or skips tests based on the operating system. Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OperatingSystems> flags enum to specify which operating systems apply.

```csharp
[TestClass]
public class OSSpecificTests
{
    [TestMethod]
    [OSCondition(OperatingSystems.Windows)]
    public void WindowsOnlyTest()
    {
        // Runs only on Windows
    }

    [TestMethod]
    [OSCondition(OperatingSystems.Linux | OperatingSystems.OSX)]
    public void UnixLikeOnlyTest()
    {
        // Runs on Linux or macOS
    }

    [TestMethod]
    [OSCondition(ConditionMode.Exclude, OperatingSystems.Windows)]
    public void SkipOnWindowsTest()
    {
        // Runs on any OS except Windows
    }
}
```

#### Supported operating systems

| OS | Description |
|------|-------------|
| `Windows` | Microsoft Windows |
| `Linux` | Linux distributions |
| `OSX` | macOS |
| `FreeBSD` | FreeBSD |

Combine operating systems with the bitwise OR operator (`|`).

> [!TIP]
> Related analyzers:
>
> - [MSTEST0061](mstest-analyzers/mstest0061.md) - recommends using `OSCondition` attribute instead of runtime checks.

### `CIConditionAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CIConditionAttribute> runs or skips tests based on whether they're executing in a continuous integration environment.

```csharp
[TestClass]
public class CIAwareTests
{
    [TestMethod]
    [CICondition] // Default: runs only in CI
    public void CIOnlyTest()
    {
        // Runs only in CI environments
    }

    [TestMethod]
    [CICondition(ConditionMode.Include)]
    public void ExplicitCIOnlyTest()
    {
        // Same as above, explicitly stated
    }

    [TestMethod]
    [CICondition(ConditionMode.Exclude)]
    public void LocalDevelopmentOnlyTest()
    {
        // Skipped in CI, runs during local development
    }
}
```

### `IgnoreAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute> unconditionally skips a test class or method. Optionally provide a reason for ignoring.

> [!TIP]
> Related analyzer: [MSTEST0015](mstest-analyzers/mstest0015.md) - Test method should not be ignored. Enable this analyzer to detect tests that are permanently ignored.

```csharp
[TestClass]
public class IgnoreExamples
{
    [TestMethod]
    [Ignore]
    public void TemporarilyDisabled()
    {
        // This test is skipped
    }

    [TestMethod]
    [Ignore("Waiting for bug #123 to be fixed")]
    public void DisabledWithReason()
    {
        // This test is skipped with a documented reason
    }
}

[TestClass]
[Ignore("Entire class needs refactoring")]
public class IgnoredTestClass
{
    [TestMethod]
    public void Test1() { }  // Skipped

    [TestMethod]
    public void Test2() { }  // Skipped
}
```

#### Link to work items

When ignoring tests due to known issues, use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.WorkItemAttribute> or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.GitHubWorkItemAttribute> for traceability:

```csharp
[TestClass]
public class TrackedIgnoreExamples
{
    [TestMethod]
    [Ignore("Waiting for fix")]
    [WorkItem(12345)]
    public void TestWithWorkItem()
    {
        // Linked to work item 12345
    }

    [TestMethod]
    [Ignore("Known issue")]
    [GitHubWorkItem("https://github.com/owner/repo/issues/42")]
    public void TestWithGitHubIssue()
    {
        // Linked to GitHub issue #42
    }
}
```

## Best practices

1. **Use parallelization wisely**: Enable parallelization for independent tests, but use `DoNotParallelize` for tests that share state.

1. **Set appropriate timeouts**: Choose timeouts that allow normal execution but catch stuck tests. Consider slow CI environments.

1. **Prefer cooperative cancellation**: Use cooperative cancellation to avoid the overhead of extra task wrappers and prevent background execution of timed-out tests. Enable the [MSTEST0045](mstest-analyzers/mstest0045.md) analyzer to enforce this practice.

1. **Document ignored tests**: Always provide a reason and work item reference when ignoring tests.

1. **Use retries sparingly**: Address the root cause of flaky tests rather than relying on retries.

1. **Test OS-specific code appropriately**: Use `OSCondition` to run platform-specific tests only where they're applicable.

## See also

- [Configure MSTest](unit-testing-mstest-configure.md)
- [Test lifecycle](unit-testing-mstest-writing-tests-lifecycle.md)
- [Write tests in MSTest](unit-testing-mstest-writing-tests.md)
- [MSTEST0001: Use Parallelize attribute](mstest-analyzers/mstest0001.md)
- [MSTEST0041: Use condition-based attributes with test class](mstest-analyzers/mstest0041.md)
- [MSTEST0043: Use retry attribute on test method](mstest-analyzers/mstest0043.md)
- [MSTEST0045: Use cooperative cancellation for timeout](mstest-analyzers/mstest0045.md)
- [MSTEST0059: Use Parallelize attribute correctly](mstest-analyzers/mstest0059.md)
- [MSTEST0061: Use OSCondition attribute instead of runtime check](mstest-analyzers/mstest0061.md)
