---
title: MSTest test lifecycle
description: Learn about the creation and lifecycle of test classes and test methods in MSTest, including initialization and cleanup at assembly, class, and test levels.
author: marcelwgn
ms.author: marcelwagner
ms.date: 11/06/2026
ai-usage: ai-assisted
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

### Shared assembly fixtures with `AssemblyFixtureProvider`

> [!NOTE]
> The `AssemblyFixtureProviderAttribute` was introduced in MSTest 4.3.0.

By default, `[AssemblyInitialize]` and `[AssemblyCleanup]` methods must be declared in the test assembly that uses them. Use `AssemblyFixtureProviderAttribute` to expose those methods from a shared fixture type. MSTest runs the shared methods once per consuming test assembly, not once for the entire test run.

```csharp
// In a shared library.
public static class SharedAssemblyFixtures
{
    [AssemblyInitialize]
    public static void Init(TestContext context)
    {
        // Runs once per consuming test assembly.
    }

    [AssemblyCleanup]
    public static void Cleanup()
    {
    }
}
```

To expose `SharedAssemblyFixtures` to test assemblies that reference the shared library, add the following assembly-level attribute **in the shared library**:

```csharp
[assembly: AssemblyFixtureProvider(typeof(SharedAssemblyFixtures))]
```

Consuming test assemblies don't need to repeat the attribute when the shared library is reachable through their compiled assembly references. MSTest searches the non-framework assembly reference graph automatically, including transitive references. The marker identifies a fixture type that an assembly supplies; it doesn't opt a consuming test assembly into provider discovery.

Automatic discovery follows references emitted into compiled assembly metadata, not every `ProjectReference` or `PackageReference`. If a shared library contains only fixtures and the consumer doesn't otherwise reference its types, the compiler might omit that library from the assembly reference graph. A project or package reference alone doesn't guarantee discovery.

To register a fixture-only library explicitly, or if you can't modify the shared library, put `[assembly: AssemblyFixtureProvider(typeof(SharedAssemblyFixtures))]` in the consuming test assembly. The marker supplies both an explicit compiled reference and fixture registration. You don't need to call a library API at runtime to force a load. The referenced fixture type can reside in a library that doesn't declare a provider marker.

> [!WARNING]
> Starting with MSTest 4.4, MSTest skips `AssemblyFixtureProviderAttribute` discovery when dynamic code isn't supported, including Native AOT runs. Use fixture methods declared directly in the test assembly for Native AOT. The [MSTEST0072](mstest-analyzers/mstest0072.md) analyzer reports configurations that it can detect at build time.

#### Local methods and duplicate providers

Local assembly lifecycle methods take precedence independently:

- A local `[AssemblyInitialize]` method overrides shared initialization. Shared cleanup can still run.
- A local `[AssemblyCleanup]` method overrides shared cleanup. Shared initialization can still run.
- If the test assembly declares both local methods, MSTest skips the shared-provider search.

The attribute allows multiple provider declarations, but each consuming test assembly can use at most one initialization method and one cleanup method. If multiple eligible shared methods fill the same slot and no local method takes precedence, MSTest reports an error.

#### Assembly-load side effects in MSTest 4.3.0 through 4.5.2

In MSTest 4.3.0 through 4.5.2, reflection-based provider discovery loads referenced non-framework assemblies into the test process as it walks the transitive reference graph, before it checks for provider markers. The search can load otherwise-unused, unmarked assemblies even when no shared fixture providers exist.

These extra loads can change <xref:System.AppDomain.GetAssemblies> results and lock DLLs on Windows with .NET Framework.

> [!IMPORTANT]
> If your tests depend on an unused assembly remaining unloaded and don't use shared fixtures, a temporary workaround for these affected versions is to declare **both** a local `[AssemblyInitialize]` method and a local `[AssemblyCleanup]` method. With both local methods, MSTest skips this provider scan. Declaring only one local method doesn't stop the scan. The workaround bypasses shared-fixture behavior; it isn't required MSTest boilerplate and doesn't prevent other code from loading assemblies.

#### Metadata-first discovery (unreleased)

> [!IMPORTANT]
> Metadata-first provider discovery is under development. MSTest 4.5.2 still uses the reflection-based search described above. No fixed release version has been assigned, and a 4.5 servicing backport hasn't been accepted.

To avoid loads caused solely by the provider scan, the metadata-first implementation reads assembly references and provider markers from portable executable (PE) metadata.

Metadata-only decisions require a matching assembly identity and a path backed by runtime binding data. On modern .NET, MSTest uses the default load context's runtime-provided trusted platform assemblies (TPA) map. On .NET Framework, metadata-only decisions are limited to unsigned, culture-neutral references in the application's base directory without binding or host overrides. For unloaded references that meet these requirements, MSTest can traverse unmarked assemblies without loading them into the test process.

A nearby DLL or a path suggested by a component dependency resolver alone doesn't establish how the runtime binds the reference.

Actual providers, fixture types registered by consumer markers, and their runtime dependencies can still load normally. MSTest preserves existing assembly binding and load-context identity; the same context doesn't prevent a first-time assembly load.

To preserve existing runtime binding behavior, MSTest uses runtime resolution rather than a metadata-only decision in cases such as:

- A trusted metadata path is unavailable, or a metadata read or resolution attempt fails.
- The consumer uses a custom assembly load context.
- An assembly with the requested simple name is already loaded, even if its full identity matches the reference.
- On .NET Framework, the global assembly cache (GAC), strong-named binding, loaded assembly images, binding redirects, `codeBase` entries, or unknown binding or host policy can affect resolution.

Fallback diagnostics include `using runtime resolution for AssemblyFixtureProvider discovery`. Missing metadata paths produce an informational trace; metadata-read or resolution failures produce warnings. The fallback can load unmarked libraries and lock their DLLs on Windows with .NET Framework. Metadata-first discovery therefore doesn't guarantee that all referenced assemblies stay unloaded or deletable.

The existing marker-placement rules, local-method precedence, duplicate-provider diagnostics, and Native AOT restrictions still apply.

Neither `.runsettings` nor `testconfig.json` provides a switch to enable or disable shared-provider discovery. For the available configuration options, see [Configure MSTest](unit-testing-mstest-configure.md#shared-assembly-fixture-discovery).

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

> [!NOTE]
> Starting with MSTest 4.2, MSTest reports failures in `ClassCleanup` and `AssemblyCleanup` as a separate test result. The separate result makes cleanup failures easier to identify in Test Explorer and TRX reports.

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
> When multiple `GlobalTestInitialize` or `GlobalTestCleanup` methods exist, the execution order isn't guaranteed. Starting with MSTest 4.4, global fixture methods support `[Timeout]` and the dedicated [global fixture timeout settings](unit-testing-mstest-configure.md#timeout-settings).

> [!TIP]
> Related analyzer: [MSTEST0050](mstest-analyzers/mstest0050.md) - validates global test fixture methods.

## Test-level lifecycle

Test-level lifecycle runs for every test method. For parameterized tests, the lifecycle runs for each data row.

### Create test classes from host services

Starting with MSTest 4.5, the experimental [`MSTest.Extensions.Hosting`](https://github.com/microsoft/testfx/tree/main/src/Adapter/MSTest.Extensions.Hosting) package lets an application-owned `Microsoft.Extensions.Hosting` container create MSTest test classes.

Register the integration in the same host that runs MTP:

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<MyApplicationService>();
builder.Services.AddMSTestTestClassInjection();
```

A test class can request registered services and an optional exact `TestContext` parameter through a public constructor:

```csharp
[TestClass]
public sealed class MyTests(MyApplicationService service, TestContext testContext)
{
    [TestMethod]
    public void ServiceIsAvailable() => Assert.IsNotNull(service);
}
```

The integration creates one dependency-injection scope for each test invocation, including each data row and retry attempt. `TestInitialize`, the test method, and `TestCleanup` share the same test-class instance and scope. After cleanup, MSTest disposes the test-class instance and then the scope. The application still owns the host and root service provider.

This first reflection-based integration doesn't support Native AOT, browser WebAssembly, AOT compilation, or MSTest source generation. The `AddMSTestTestClassInjection` API uses the `MSTESTEXP` diagnostic ID and might change in a future release. For host setup, see [Microsoft.Extensions integration](microsoft-testing-platform-extensions-integration.md#host-integration).

> [!TIP]
> Related analyzers: [MSTEST0063](mstest-analyzers/mstest0063.md#host-owned-test-class-injection) validates constructors for host-owned injection, and [MSTEST0088](mstest-analyzers/mstest0088.md) reports unsupported build modes.

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
