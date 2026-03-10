---
title: MSTest test lifecycle
description: Learn about the creation and lifecycle of test classes and test methods in MSTest, including initialization and cleanup at assembly, class, and test levels.
author: marcelwgn
ms.author: marcelwagner
ms.date: 07/15/2025
---

# MSTest lifecycle

MSTest provides a well-defined lifecycle for test classes and test methods, allowing you to perform setup and teardown operations at various stages of test execution. Understanding the lifecycle helps you write efficient tests and avoid common pitfalls.

## Lifecycle overview

The lifecycle groups into four stages, executed from highest level (assembly) to lowest level (test method):

1. **Assembly-level**: Runs once when the test assembly loads and unloads
1. **Class-level**: Runs once per test class
1. **Global test-level**: Runs before and after every test method in the assembly
1. **Test-level**: Runs for each test method (including each data row in parameterized tests)

## Assembly-level lifecycle

Assembly lifecycle methods run once when the test assembly loads and unloads. Use these for expensive one-time setup like database initialization or service startup.

### `AssemblyInitialize` and `AssemblyCleanup`

```csharp
[TestClass]
public class AssemblyLifecycleExample
{
    private static IHost? _host;

    [AssemblyInitialize]
    public static async Task AssemblyInit(TestContext context)
    {
        // Runs once before any tests in the assembly
        _host = await StartTestServerAsync();
        context.WriteLine("Test server started");
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup(TestContext context)
    {
        // Runs once after all tests complete
        // TestContext parameter available in MSTest 3.8+
        if (_host != null)
        {
            await _host.StopAsync();
        }
    }

    private static Task<IHost> StartTestServerAsync()
    {
        // Server initialization
        return Task.FromResult<IHost>(null!);
    }
}
```

#### Requirements

- Methods must be `public static`
- Return type: `void`, `Task`, or `ValueTask` (MSTest v3.3+)
- `AssemblyInitialize` requires one `TestContext` parameter
- `AssemblyCleanup` accepts zero parameters, or one `TestContext` parameter (MSTest 3.8+)
- Only one of each attribute allowed per assembly
- Must be in a class marked with `[TestClass]`

> [!TIP]
> Related analyzers:
>
> - [MSTEST0012](mstest-analyzers/mstest0012.md) - validates `AssemblyInitialize` signature.
> - [MSTEST0013](mstest-analyzers/mstest0013.md) - validates `AssemblyCleanup` signature.

## Class-level lifecycle

Class lifecycle methods run once per test class, before and after all test methods in that class. Use these for setup shared across tests in a class.

### `ClassInitialize` and `ClassCleanup`

```csharp
[TestClass]
public class ClassLifecycleExample
{
    private static HttpClient? _client;

    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        // Runs once before any tests in this class
        _client = new HttpClient
        {
            BaseAddress = new Uri("https://api.example.com")
        };
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        // Runs after all tests in this class complete
        _client?.Dispose();
    }

    [TestMethod]
    public async Task GetUsers_ReturnsSuccess()
    {
        HttpResponseMessage response = await _client!.GetAsync("/users");
        Assert.IsTrue(response.IsSuccessStatusCode);
    }
}
```

#### Requirements

- Methods must be `public static`
- Return type: `void`, `Task`, or `ValueTask` (MSTest v3.3+)
- `ClassInitialize` requires one `TestContext` parameter
- `ClassCleanup` accepts zero parameters, or one `TestContext` parameter (MSTest 3.8+)
- Only one of each attribute allowed per class

### Inheritance behavior

Control whether `ClassInitialize` runs for derived classes using <xref:Microsoft.VisualStudio.TestTools.UnitTesting.InheritanceBehavior>:

```csharp
[TestClass]
public class BaseTestClass
{
    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static void BaseClassInit(TestContext context)
    {
        // Runs before each derived class's tests
    }
}

[TestClass]
public class DerivedTestClass : BaseTestClass
{
    [TestMethod]
    public void DerivedTest()
    {
        // BaseClassInit runs before this class's tests
    }
}
```

| InheritanceBehavior | Description |
|---------------------|-------------|
| `None` (default) | Initialize runs only for the declaring class |
| `BeforeEachDerivedClass` | Initialize runs before each derived class |

> [!TIP]
> Related analyzers:
>
> - [MSTEST0010](mstest-analyzers/mstest0010.md) - validates `ClassInitialize` signature.
> - [MSTEST0011](mstest-analyzers/mstest0011.md) - validates `ClassCleanup` signature.
> - [MSTEST0034](mstest-analyzers/mstest0034.md) - recommends using `ClassCleanupBehavior.EndOfClass`.

## Global test-level lifecycle

> [!NOTE]
> Global test lifecycle attributes were introduced in MSTest 3.10.0.

Global test lifecycle methods run before and after *every* test method across the entire assembly, without needing to add code to each test class.

### `GlobalTestInitialize` and `GlobalTestCleanup`

```csharp
[TestClass]
public class GlobalTestLifecycleExample
{
    [GlobalTestInitialize]
    public static void GlobalTestInit(TestContext context)
    {
        // Runs before every test method in the assembly
        context.WriteLine($"Starting test: {context.TestName}");
    }

    [GlobalTestCleanup]
    public static void GlobalTestCleanup(TestContext context)
    {
        // Runs after every test method in the assembly
        context.WriteLine($"Finished test: {context.TestName}");
    }
}
```

#### Requirements

- Methods must be `public static`
- Return type: `void`, `Task`, or `ValueTask`
- Must have exactly one `TestContext` parameter
- Must be in a class marked with `[TestClass]`
- Multiple methods with these attributes are allowed across the assembly

> [!NOTE]
> When multiple `GlobalTestInitialize` or `GlobalTestCleanup` methods exist, the execution order isn't guaranteed. The `TimeoutAttribute` isn't supported on `GlobalTestInitialize` methods.

> [!TIP]
> Related analyzer: [MSTEST0050](mstest-analyzers/mstest0050.md) - validates global test fixture methods.

## Test-level lifecycle

Test-level lifecycle runs for every test method. For parameterized tests, the lifecycle runs for each data row.

### Setup phase

Use `TestInitialize` or a constructor for per-test setup:

```csharp
[TestClass]
public class TestLevelSetupExample
{
    private Calculator? _calculator;

    public TestLevelSetupExample()
    {
        // Constructor runs before TestInitialize
        // Use for simple synchronous initialization
    }

    [TestInitialize]
    public async Task TestInit()
    {
        // Runs before each test method
        // Supports async, attributes like Timeout
        _calculator = new Calculator();
        await _calculator.InitializeAsync();
    }

    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        int result = _calculator!.Add(2, 3);
        Assert.AreEqual(5, result);
    }
}
```

**Constructor vs. TestInitialize:**

| Aspect | Constructor | TestInitialize |
|--------|-------------|----------------|
| Async support | No | Yes |
| Timeout support | No | Yes (with `[Timeout]` attribute) |
| Execution order | First | After constructor |
| Inheritance | Base then derived | Base then derived |
| Exception behavior | Cleanup and Dispose don't run (no instance exists) | Cleanup and Dispose still run |

> [!TIP]
> **Which approach should I use?** Constructors are generally preferred because they allow you to use `readonly` fields, which enforces immutability and makes your test class easier to reason about. Use `TestInitialize` when you need async initialization or timeout support.
>
> You can also combine both approaches: use the constructor for simple synchronous initialization of `readonly` fields, and `TestInitialize` for additional async setup that depends on those fields.
>
> You can optionally enable code analyzers to enforce a consistent approach:
>
> - [MSTEST0019](mstest-analyzers/mstest0019.md) - Prefer TestInitialize methods over constructors
> - [MSTEST0020](mstest-analyzers/mstest0020.md) - Prefer constructors over TestInitialize methods

### Execution phase

The test method executes after setup completes. For `async` test methods, MSTest awaits the returned `Task` or `ValueTask`.

> [!WARNING]
> Asynchronous test methods don't have a <xref:System.Threading.SynchronizationContext> by default. This doesn't apply to `UITestMethod` tests in UWP and WinUI, which run on the UI thread.

### Cleanup phase

Use `TestCleanup` or `IDisposable`/`IAsyncDisposable` for per-test cleanup:

```csharp
[TestClass]
public class TestLevelCleanupExample
{
    private HttpClient? _client;

    [TestInitialize]
    public void TestInit()
    {
        _client = new HttpClient();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        if (_client != null)
        {
            _client.Dispose();
        }
    }

    [TestMethod]
    public async Task GetData_ReturnsSuccess()
    {
        HttpResponseMessage response = await _client!.GetAsync("https://example.com");
        Assert.IsTrue(response.IsSuccessStatusCode);
    }
}
```

**Cleanup execution order (derived to base):**

1. `TestCleanup` (derived class)
1. `TestCleanup` (base class)
1. `DisposeAsync` (if implemented)
1. `Dispose` (if implemented)

> [!TIP]
> You can optionally enable code analyzers to enforce a consistent cleanup approach:
>
> - [MSTEST0021](mstest-analyzers/mstest0021.md) - Prefer Dispose over TestCleanup methods
> - [MSTEST0022](mstest-analyzers/mstest0022.md) - Prefer TestCleanup over Dispose methods
>
> If you have non-MSTest analyzers enabled, such as .NET code analysis rules, you might see [CA1001](../../fundamentals/code-analysis/quality-rules/ca1001.md) suggesting that you implement the dispose pattern when your test class owns disposable resources. This is expected behavior and you should follow the analyzer's guidance.

### Complete test-level order

1. Create instance of test class (constructor)
1. Set `TestContext` property (if present)
1. Run `GlobalTestInitialize` methods
1. Run `TestInitialize` methods (base to derived)
1. Execute test method
1. Update `TestContext` with results (for example, `Outcome` property)
1. Run `TestCleanup` methods (derived to base)
1. Run `GlobalTestCleanup` methods
1. Run `DisposeAsync` (if implemented)
1. Run `Dispose` (if implemented)

> [!TIP]
> Related analyzers:
>
> - [MSTEST0008](mstest-analyzers/mstest0008.md) - validates `TestInitialize` signature.
> - [MSTEST0009](mstest-analyzers/mstest0009.md) - validates `TestCleanup` signature.
> - [MSTEST0063](mstest-analyzers/mstest0063.md) - validates test class constructor.

## Best practices

1. **Use appropriate scope**: Put setup at the highest level that makes sense to avoid redundant work.

1. **Keep setup fast**: Long-running setup affects all tests. Consider lazy initialization for expensive resources.

1. **Clean up properly**: Always clean up resources to prevent test interference and memory leaks.

1. **Handle async correctly**: Use `async Task` return types, not `async void`, for async lifecycle methods.

1. **Consider test isolation**: Each test should be independent. Avoid shared mutable state between tests.

1. **Use GlobalTest sparingly**: Global lifecycle methods run for every test, so keep them lightweight.

## See also

- [Write tests in MSTest](unit-testing-mstest-writing-tests.md)
- [Test execution and control](unit-testing-mstest-writing-tests-controlling-execution.md)
- [TestContext class](unit-testing-mstest-writing-tests-testcontext.md)
