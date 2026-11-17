---
title: MSTest migration from v3 to v4
description: Learn about migrating to MSTest v4.
author: Youssef1313
ms.author: ygerges
ms.date: 11/17/2026
ai-usage: ai-assisted
---

# Migrate from MSTest v3 to v4

The stable version MSTest v4 is now available. This migration guide explores what's changed in MSTest v4 and how you can migrate to this version.

> [!NOTE]
> Generally speaking, MSTest v4 isn't binary compatible with MSTest v3. Any library compiled against v3 must be recompiled against v4.

> [!TIP]
> Before you upgrade, fix the warnings from [MSTEST0006](./mstest-analyzers/mstest0006.md), [MSTEST0039](./mstest-analyzers/mstest0039.md), and [MSTEST0053](./mstest-analyzers/mstest0053.md) while you're still on v3. These analyzers flag APIs that v4 removes, and the analyzers themselves aren't available in v4. Similarly, [MSTEST0034](./mstest-analyzers/mstest0034.md) helps you adopt the end-of-class cleanup behavior that v4 always uses.

## Source breaking changes

These are breaking changes that might cause your test projects to fail to compile.

### TestMethodAttribute breaking changes

#### Change TestMethodAttribute.Execute to TestMethodAttribute.ExecuteAsync

If you implement your own `TestMethodAttribute`, you need to change the `Execute` override to be `ExecuteAsync`.
This change was made to fix long-standing deadlock bugs that are caused by the synchronous blocking nature of the API.

For example, if you previously had the following:

```csharp
public sealed class MyTestMethodAttribute : TestMethodAttribute
{
    public override TestResult[] Execute(ITestMethod testMethod)
    {
        // ...
        return result;
    }
}
```

You will need to change it to the following:

```csharp
public sealed class MyTestMethodAttribute : TestMethodAttribute
{
    public override Task<TestResult[]> ExecuteAsync(ITestMethod testMethod)
    {
        // ...
        return Task.FromResult(result);
    }
}
```

The same change applies to `UITestMethodAttribute`, which now overrides `ExecuteAsync` instead of `Execute`. If you derive from `UITestMethodAttribute`, update your override accordingly.

The MSTest analyzers include a code fix for the resulting CS0115 compiler error.

#### TestMethodAttribute now uses caller info attributes

The `TestMethodAttribute` constructor has changed to have parameters that provide caller info attributes.

- If you inherit from `TestMethodAttribute`, you should also provide such a constructor that propagates the information to the base class.

    ```csharp
    public class MyTestMethodAttribute : TestMethodAttribute
    {
        public MyTestMethodAttribute([CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = -1)
        : base(callerFilePath, callerLineNumber)
        {
        }
    }
    ```

- If you have attribute applications such as `[TestMethodAttribute("Custom display name")]`, switch them to `[TestMethodAttribute(DisplayName = "Custom display name")]`.

The `DataTestMethodAttribute`, `STATestMethodAttribute`, and `UITestMethodAttribute` constructors changed in the same way. Their constructors that accept a `displayName` argument are removed, so use the `DisplayName` property instead.

> [!WARNING]
> Code such as `[TestMethod("Custom display name")]` still compiles in v4 because the string binds to the `callerFilePath` parameter. As a result, the display name is silently ignored.

> [!TIP]
> To help you with this migration, MSTest v4 includes the following analyzers, each with a code fix:
>
> - [MSTEST0056](./mstest-analyzers/mstest0056.md) flags a string that's passed as a constructor argument to a test method attribute. Its code fix moves the string to the `DisplayName` property.
> - [MSTEST0057](./mstest-analyzers/mstest0057.md) flags custom test method attributes that don't propagate caller info to the base class.

### ClassCleanupBehavior enum is removed

Now, the ClassCleanup methods run only at the end of the test class. Support for class cleanup to run at the end of assembly is removed.
If you must run end of assembly cleanup logic, do it in `AssemblyCleanup` rather than `ClassCleanup`.
The default behavior of class cleanup was previously "EndOfAssembly", which users considered to be a bug.

If you previously had the following code:

```csharp
[ClassCleanup(ClassCleanupBehavior.EndOfClass)]
public static void ClassCleanup(TestContext testContext)
{
}
```

You will need to change it to the following:

```csharp
[ClassCleanup]
public static void ClassCleanup(TestContext testContext)
{
}
```

The MSTest analyzers include a code fix that removes the `ClassCleanupBehavior` argument.

The following related APIs and settings are also removed:

- The `ClassCleanupAttribute` constructors that accept a `ClassCleanupBehavior` argument.
- The assembly-level `ClassCleanupExecutionAttribute`. Remove any `[assembly: ClassCleanupExecution(...)]` attribute from your code.
- The `ClassCleanupLifecycle` runsettings setting and the `classCleanupLifecycle` setting in the `mstest` section of *testconfig.json*. MSTest v4 no longer reads these settings, so they have no effect.

### TestContext.Properties is now IDictionary<string, object>

Previously, `TestContext.Properties` was an `IDictionary`. To provide better typing, it's now `IDictionary<string, object>`.

If you have calls to `TestContext.Properties.Contains`, update them to `TestContext.Properties.ContainsKey`. The MSTest analyzers include a code fix for the resulting CS1503 compiler error.

### TestTimeout enum is removed

This enum only had a single member, `Infinite`, whose value was `int.MaxValue`.
If you had usages of `[Timeout(TestTimeout.Infinite)]`, update them to `[Timeout(int.MaxValue)]`.

### Deprecated TestContext properties are removed

The following `TestContext` properties are removed. Update your code to use the replacement properties:

| Removed property | Replacement |
|------------------|-------------|
| `TestContext.TestDir` | `TestContext.TestRunDirectory` |
| `TestContext.TestDeploymentDir` | `TestContext.DeploymentDirectory` |
| `TestContext.TestLogsDir` | `TestContext.TestRunResultsDirectory` for test run result files, or `TestContext.TestResultsDirectory` for test-specific result files |
| `TestContext.ManagedType` | `TestContext.FullyQualifiedTestClassName` |
| `TestContext.ManagedMethod` | `TestContext.TestName` |

`TestContext.TestName` contains only the test method name. `TestContext.ManagedMethod` also included the generic arity and parameter types of the method.

`TestContext.FullyQualifiedTestClassName` and `TestContext.TestName` are now non-nullable. For more information about when you can access them, see [TestContext throws when used incorrectly](#testcontext-throws-when-used-incorrectly).

### ITestMethod interface changes

The `Microsoft.VisualStudio.TestTools.UnitTesting.ITestMethod` interface in the TestFramework assembly, which custom `TestMethodAttribute` implementations receive, has the following changes:

- `ITestMethod.Invoke` is removed. Use `ITestMethod.InvokeAsync` instead.
- The `inherit` parameter is removed from `ITestMethod.GetAllAttributes` and `ITestMethod.GetAttributes<TAttributeType>`. MSTest always includes inherited attributes. For more information, see [MSTest always reads inherited attributes](#mstest-always-reads-inherited-attributes).

### Types not intended for public consumption are made internal or removed

- `Microsoft.VisualStudio.TestPlatform.MSTestAdapter.PlatformServices.Interface.ObjectModel.ITestMethod` is made internal.
  - This interface is different from the `ITestMethod` interface in the TestFramework assembly. For changes to that interface, see [ITestMethod interface changes](#itestmethod-interface-changes).
  - `Microsoft.VisualStudio.TestPlatform.MSTestAdapter.PlatformServices.Interface.ObjectModel.ITestMethod` doesn't have any valid usages for users, so it was made internal.
- Some of the already-obsolete types are made internal. This includes:
  - MSTestDiscoverer
  - MSTestExecutor
  - AssemblyResolver
  - LogMessageListener
  - TestExecutionManager
  - TestMethodInfo
  - TestResultExtensions
  - UnitTestOutcomeExtensions
  - GenericParameterHelper
  - Types in platform services assembly

### Assert APIs signature change

- Assert APIs that accept both `message` and `object[]` parameters now accept only `message`. Use string interpolation instead. This was a necessary change to support caller argument expression for assertion APIs.
- `Assert.AreEqual` APIs for `IEquatable<T>` are removed. There are very few users of this API, and the API is misleading. Most users aren't affected by this removal, as the API didn't initially exist in MSTest v3 and was introduced in 3.2.2.
  - This API causes issues for F# users as well. For example, see [fsharp/fslang-suggestions/issues/905](https://github.com/fsharp/fslang-suggestions/issues/905#issuecomment-2336831360).
  - If you're affected, you'll get a compile error about generic type inference. All you need to do is explicitly specify the type argument as `object`.
- The deprecated `Assert.ThrowsException` APIs are removed. An analyzer and codefix in MSTest 3.10 help migrate you to the newer APIs.
- Usages of `Assert.IsInstanceOfType<T>(x, out var t)` should now change to `var t = Assert.IsInstanceOfType<T>(x)`. The MSTest analyzers include a code fix for the resulting CS1615 compiler error.
  - Existing overloads that didn't have the `out` parameter changed to return the instance of type `T` instead of void. This is only a breaking change for F#.
- The `StringAssert.Contains`, `StringAssert.StartsWith`, and `StringAssert.EndsWith` overloads that accept both a message and a `StringComparison` now take the `StringComparison` argument before the message. For example, change `StringAssert.Contains(value, substring, "message", StringComparison.Ordinal)` to `StringAssert.Contains(value, substring, StringComparison.Ordinal, "message")`.
- `Assert.ReplaceNullChars` is removed.
- Some parameters are renamed. These renames affect only calls that use named arguments:
  - In `Assert.DoesNotContain` and `CollectionAssert.AreNotEquivalent`, `expected` is renamed to `notExpected`.
  - In `Assert.StartsWith` and `Assert.EndsWith`, `substring` is renamed to `expectedPrefix` and `expectedSuffix`, respectively.
  - In `Assert.DoesNotStartWith` and `Assert.DoesNotEndWith`, `substring` is renamed to `notExpectedPrefix` and `notExpectedSuffix`, respectively.

### ExpectedExceptionAttribute API is removed

The deprecated `ExpectedExceptionAttribute` API is removed. An analyzer (MSTEST0006) and codefix in MSTest 3.2 help migrate you to `Assert.Throws`.

For example, if you had the following code:

```csharp
[ExpectedException(typeof(SomeExceptionType))]
[TestMethod]
public void TestMethod()
{
    MyCall();
}
```

You (or the analyzer and codefix) need to change it to the following:

```csharp
[TestMethod]
public void TestMethod()
{
    Assert.ThrowsExactly<SomeExceptionType>(() => MyCall());
}
```

Its base class, `ExpectedExceptionBaseAttribute`, is also removed. If you derived custom attributes from `ExpectedExceptionBaseAttribute`, replace them with calls to `Assert.Throws`, `Assert.ThrowsExactly`, or their async counterparts.

### TestIdGenerationStrategy is removed

The `TestIdGenerationStrategy` enum, the `TestIdGenerationStrategyAttribute` attribute, and the `DataRowAttribute.TestIdGenerationStrategy` property are removed. You can no longer choose how MSTest generates test IDs, so remove any `[assembly: TestIdGenerationStrategy(...)]` attribute from your code. For more information, see [TestCase.Id is changing](#testcaseid-is-changing).

### CssIterationAttribute and CssProjectStructureAttribute are removed

The `CssIterationAttribute` and `CssProjectStructureAttribute` attributes are removed. Remove them from your tests.

### InternalTestFailureException is removed

The `InternalTestFailureException` type is removed. If your code throws or catches this exception, use a different exception type.

### MSTest assemblies are renamed

To match their package names, the MSTest assemblies are renamed. Their namespaces didn't change.

| v3 assembly | v4 assembly |
|-------------|-------------|
| `Microsoft.VisualStudio.TestPlatform.TestFramework.dll` | `MSTest.TestFramework.dll` |
| `Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions.dll` | `MSTest.TestFramework.Extensions.dll` |
| `Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter.dll` | `MSTest.TestAdapter.dll` |
| `Microsoft.VisualStudio.TestPlatform.MSTestAdapter.PlatformServices.dll` | `MSTestAdapter.PlatformServices.dll` |

Also, the assembly version of these assemblies is no longer fixed at `14.0.0.0`, and the VSTest executor URI changed from `executor://MSTestAdapter/v2` to `executor://MSTestAdapter/v4`.

If you reference MSTest assemblies by name or version, update those references. For example, update binding redirects, assembly-qualified type names, code coverage include or exclude filters, and tools that read the executor URI.

### Dropped unsupported target frameworks

Support for target frameworks .NET Core 3.1 to .NET 7 is dropped. The minimum supported .NET version is .NET 8.
This change doesn't affect .NET Framework. .NET Framework 4.6.2 continues to be the minimum supported .NET Framework target.

The MSTest.TestAdapter package also no longer includes a `netstandard2.0` build. MSTest.TestFramework still targets `netstandard2.0`.

### Unfolding strategy moved from individual data sources to TestMethodAttribute

Unfolding strategy is a recent feature introduced in MSTest 3.7 to work around known limitations.
The property was added on individual data sources like `DataRowAttribute` and `DynamicDataAttribute`. This property has been moved to `TestMethodAttribute`.

The `ITestDataSourceUnfoldingCapability` interface is also removed. If your custom data source implements this interface, remove the implementation and set the `UnfoldingStrategy` property on `TestMethodAttribute` instead.

### `ConditionBaseAttribute.ShouldRun` API change

The `ConditionBaseAttribute.ShouldRun` property was renamed to `IsConditionMet`. That makes it clearer that `ConditionMode` shouldn't be used in the implementation.

### `ConditionBaseAttribute.IgnoreMessage` is no longer virtual

The `ConditionBaseAttribute.IgnoreMessage` property is no longer virtual. If your custom condition attribute overrides `IgnoreMessage`, remove the override and set the property instead, for example, in your attribute's constructor.

### Multiple analyzers are updated to be warning by default

The default severity of the following analyzers changed from Info to Warning:

- [MSTEST0001](./mstest-analyzers/mstest0001.md)
- [MSTEST0007](./mstest-analyzers/mstest0007.md)
- [MSTEST0017](./mstest-analyzers/mstest0017.md)
- [MSTEST0023](./mstest-analyzers/mstest0023.md)
- [MSTEST0024](./mstest-analyzers/mstest0024.md)
- [MSTEST0025](./mstest-analyzers/mstest0025.md)
- [MSTEST0030](./mstest-analyzers/mstest0030.md)
- [MSTEST0031](./mstest-analyzers/mstest0031.md)
- [MSTEST0032](./mstest-analyzers/mstest0032.md)
- [MSTEST0035](./mstest-analyzers/mstest0035.md)
- [MSTEST0037](./mstest-analyzers/mstest0037.md)
- [MSTEST0045](./mstest-analyzers/mstest0045.md)

## Behavior breaking changes

These are breaking changes that might affect the behavior at runtime.

### DisableAppDomain now defaults to true when running under MTP

In v4, and when running with MTP, AppDomains are disabled by default (when not specified) as the custom isolation provided is useless in most of the cases and has an important impact on performances (up to 30% slower when running under isolation).

However, the feature remains available. If you have scenarios requiring it, set `DisableAppDomain` to `false` in runsettings:

```xml
<RunSettings>
  <RunConfiguration>
    <DisableAppDomain>false</DisableAppDomain>
  </RunConfiguration>
</RunSettings>
```

Or, set `disableAppDomain` to `false` in *testconfig.json*:

```json
{
  "mstest": {
    "execution": {
      "disableAppDomain": false
    }
  }
}
```

MSTest v4 reads the runsettings setting only from the `RunSettings/RunConfiguration/DisableAppDomain` element. MSTest v3 used the first `DisableAppDomain` element found anywhere in the runsettings file. If you placed this element elsewhere, move it under `RunConfiguration`.

> [!IMPORTANT]
> When AppDomain isolation is enabled, MSTest unloads the AppDomain after all tests finish, which aborts all the threads associated with the AppDomain, including foreground threads. As a result, if you had a foreground thread running forever in MSTest v3, the test run will complete successfully. The same scenario will hang in MSTest v4, which is ideal behavior because the process shouldn't exit when a foreground thread is still running.

### TestContext throws when used incorrectly

The `TestContext` type is passed to AssemblyInitialize, ClassInitialize, and to tests, but available information at each stage is different. Now, an exception is thrown when accessing a property related to a test run information as part of `AssemblyInitialize` or `ClassInitialize`.

- `TestContext.FullyQualifiedTestClassName` cannot be accessed in assembly initialize.
- `TestContext.TestName` cannot be accessed in assembly initialize or class initialize.

### TestCase.Id is changing

To address long outstanding bugs that many users filed, the generation of `TestCase.Id` has changed. This affects Azure DevOps features, for example, tracking test failures over time.

### TreatDiscoveryWarningsAsErrors now defaults to true

v4 uses stricter defaults. As such, the default value of `TreatDiscoveryWarningsAsErrors` is now `true`. This should be a transparent change for most users and should help other users to uncover hidden bugs.

### Discovery fails when types in the test assembly can't be loaded

In MSTest v3, if some types in a test assembly couldn't be loaded (a `ReflectionTypeLoadException`), MSTest reported a discovery warning and continued with the types that loaded. In MSTest v4, discovery of that assembly fails instead. When there's a single loader exception, MSTest reports that exception directly because it's usually more descriptive.

If you're affected, fix the underlying load failure, which is often a missing or mismatched dependency.

### MSTest always reads inherited attributes

In MSTest v3, MSTest ignored inherited attributes for some lookups, such as test data source attributes on test methods. In MSTest v4, MSTest always looks up attributes with inheritance. Built-in MSTest attributes that shouldn't be inherited, such as `TestMethodAttribute`, `DataRowAttribute`, `DynamicDataAttribute`, and `TimeoutAttribute`, declare `Inherited = false` in their `AttributeUsage`.

If you have custom attributes, such as custom `ITestDataSource` attributes, and a derived class overrides a method that uses them, MSTest now also applies them to the override. To prevent that behavior, set `Inherited = false` in the `AttributeUsage` of your custom attribute.

### Default display name for custom data sources

If the `ITestDataSource.GetDisplayName` implementation of a custom data source returns `null`, MSTest v4 computes a default display name that includes the data row's arguments. MSTest v3 used the test method's display name instead.

### MSTest.Sdk no longer adds `Microsoft.NET.Test.Sdk` reference when using MTP

By default, MSTest.Sdk uses MTP. If the `UseVSTest` MSBuild property is set to true, it will use VSTest instead. In MSTest 3.x, the SDK added a reference to Microsoft.NET.Test.Sdk (which brings VSTest support) even when using MTP. This package reference is unnecessary when running with MTP and has been removed in MSTest v4.

If you still want to have VSTest supported (for example, if you want to run with vstest.console), you need to manually add a package reference to `Microsoft.NET.Test.Sdk` NuGet package to your project.
