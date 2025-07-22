---
title: MSTest migration from v3 to v4
description: Learn about migrating to MSTest v4.
author: Youssef1313
ms.author: ygerges
ms.date: 07/22/2025
---

# Migrate from MSTest v3 to MSTest v4

The preview versions MSTest v4 are now available. This migration guide explores what's changed in MSTest v4 and how you can migrate to this version.

> [!NOTE]
> Generally speaking, MSTest v4 isn't binary compatible with MSTest v3. Any libraries compiled against v3 must be recompiled against v4.

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

> [!TIP]
> An analyzer with a codefix is forthcoming to help you with this migration. A single click in the IDE will fix all instances in your solution.


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

### TestContext.Properties is now IDictionary<string, object>

Previously, `TestContext.Properties` was an `IDictionary`. To provide better typing, it's now `IDictionary<string, object>`.

If you have calls to `TestContext.Properties.Contains`, update them to `TestContext.Properties.ContainsKey`.

### TestTimeout enum is removed

This enum only had a single member, `Infinite`, whose value was `int.MaxValue`.
If you had usages of `[Timeout(TestTimeout.Infinite)]`, update them to `[Timeout(int.MaxValue)]`.

### Types not intended for public consumption are made internal or removed

- `Microsoft.VisualStudio.TestPlatform.MSTestAdapter.PlatformServices.Interface.ObjectModel.ITestMethod` is made internal.
    - Note that this interface is different from ITestMethod in TestFramework assembly, which didn't change.
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
- Usages of `Assert.IsInstanceOfType<T>(x, out var t)` should now change to `var t = Assert.IsInstanceOfType<T>(x)`.
    - Existing overloads that didn't have the `out` parameter changed to return the instance of type `T` instead of void. This is only a breaking change for F#.

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

### Dropped unsupported target frameworks

Support for target frameworks .NET Core 3.1 to .NET 7.0 is dropped. The minimum supported .NET version is .NET 8.0.
This change doesn't affect .NET Framework. .NET Framework 4.6.2 continues to be the minimum supported .NET Framework target.

### Unfolding strategy moved from individual data sources to TestMethodAttribute

Unfolding strategy is a recent feature introduced in MSTest 3.7 to work around known limitations.
The property was added on individual data sources like `DataRowAttribute` and `DynamicDataAttribute`. This property has been moved to `TestMethodAttribute`.

### `ConditionBaseAttribute.ShouldRun` API change

We renamed `ConditionBaseAttribute.ShouldRun` property to `IsConditionMet`. That makes it more clear that `ConditionMode` shouldn't be used in the implementation.

## Behavior breaking changes

These are breaking changes that might affect the behavior at run time.

### DisableAppDomain now defaults to true when running under Microsoft.Testing.Platform

In v4, and when running with Microsoft.Testing.Platform, AppDomains are disabled by default (when not specified) as the custom isolation provided is useless in most of the cases and has an important impact on performances (up to 30% slower when running under isolation).

However, the feature remains available. If you have scenarios requiring it, add the `DisableAppDomain` setting in runsettings.

### TestContext throws when used incorrectly

The `TestContext` type is passed to AssemblyInitialize, ClassInitialize, and to tests, but available information at each stage is different. Now, an exception is thrown when accessing a property related to a test run information as part of `AssemblyInitialize` or `ClassInitialize`.

- `TestContext.FullyQualifiedTestClassName` cannot be accessed in assembly initialize.
- `TestContext.TestName` cannot be accessed in assembly initialize or class initialize. 

### TestCase.Id is changing

To address long outstanding bugs that many users filed, the generation of `TestCase.Id` has changed. This affects Azure DevOps features, for example, tracking test failures over time.

### TreatDiscoveryWarningsAsErrors now defaults to true

v4 uses stricter defaults. As such, the default value of `TreatDiscoveryWarningsAsErrors` is now `true`. This should be a transparent change for most users and should help other users to uncover hidden bugs.
