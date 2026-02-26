---
title: MSTest code analysis
description: Learn about the MSTest code analysis.
author: evangelink
ms.author: amauryleve
ms.date: 12/20/2023
---

# MSTest code analysis

*MSTest analysis* ("MSTESTxxxx") rules inspect your C# or Visual Basic code for security, performance, design and other issues.

> [!TIP]
> If you're using Visual Studio, many analyzer rules have associated *code fixes* that you can apply to correct the problem. Code fixes are shown in the light bulb icon menu.

The rules are organized into categories such as performance usage...

Starting with MSTest.TestFramework 3.7, the MSTest.Analyzers NuGet package is a dependency of the framework. For earlier versions, you need to use `MSTest` metapackage or add a package reference for `MSTest.Analyzers` explicitly.

## MSTestAnalysisMode

Starting with MSTest 3.8, an MSBuild property named `MSTestAnalysisMode` is available to determine which analyzers are enabled at which severity.

> [!TIP]
> To see which rules are enabled at which severity for each mode, you can navigate to the package of the version of interest in NuGet cache, locate the `globalconfigs` directory, and open the `.globalconfig` file corresponding to the analysis mode.
> For more information on finding the NuGet cache directory, see [Managing the global packages, cache, and temp folders](/nuget/consume-packages/managing-the-global-packages-and-cache-folders). From that directory, locate `mstest.analyzers` directory, then the version (3.8 and higher), then `globalconfigs`.
> Alternatively, you can download the NuGet package of the version of interest from `nuget.org` and view it in NuGet Package Explorer (Windows app), or view directly in the [web app version of NuGet Package Explorer](https://nuget.info/packages/MSTest.Analyzers/).

The available values for this property:

- [`None`](#none)
- [`Default`](#default)
- [`Recommended`](#recommended)
- [`All`](#all)

### `None`

This value sets all analyzers to `none` severity, disabling all of them. You can then enable individual analyzers using `.editorconfig` or `.globalconfig` files.

### `Default`

This setting follows the default documented behavior for each rule.

- Rules that are enabled by default will use their default severity.
- Rules that are disabled by default will use `none` severity.

> [!NOTE]
> Rules that are enabled by default as warnings are violations that are expected to cause issues at runtime.

### `Recommended`

This is the mode most developers are expected to use. Rules that are enabled by default with Info (`suggestion`) severity are escalated to warnings. The following rules are escalated to errors in both `Recommended` and `All` modes:

- [MSTEST0003: Test methods should have valid layout](mstest0003.md).
- [MSTEST0043: Use retry attribute on test method](mstest0043.md).

### `All`

This mode is more aggressive than `Recommended`. All rules are enabled as warnings. In addition, the following rules are escalated to errors:

- [MSTEST0003: Test methods should have valid layout](mstest0003.md).
- [MSTEST0043: Use retry attribute on test method](mstest0043.md).

> [!NOTE]
> The following rules are completely opt-in and are not enabled in `Default`, `Recommended`, or `All` modes:
>
> - [MSTEST0015: Test method should not be ignored](mstest0015.md)
> - [MSTEST0019: Prefer TestInitialize methods over constructors](mstest0019.md)
> - [MSTEST0020: Prefer constructors over TestInitialize methods](mstest0020.md)
> - [MSTEST0021: Prefer Dispose over TestCleanup methods](mstest0021.md)
> - [MSTEST0022: Prefer TestCleanup over Dispose methods](mstest0022.md)

## Rules by category

The analyzer rules are organized into the following categories:

### Design rules

[Design rules](design-rules.md) help you create and maintain test suites that adhere to proper design and good practices.

### Performance rules

[Performance rules](performance-rules.md) support high-performance testing.

### Suppression rules

[Suppression rules](suppression-rules.md) support suppressing diagnostics from other rules.

### Usage rules

[Usage rules](usage-rules.md) support proper usage of MSTest.

## Rules by concept

Find rules organized by common testing scenarios and concepts:

### Test structure & attributes

Rules that help ensure your test classes and methods are properly structured and decorated:

- [MSTEST0002](mstest0002.md) - Test class should be valid
- [MSTEST0003](mstest0003.md) - Test method should be valid
- [MSTEST0004](mstest0004.md) - Public types should be test classes
- [MSTEST0007](mstest0007.md) - Use attribute on test method
- [MSTEST0016](mstest0016.md) - Test class should have test method
- [MSTEST0029](mstest0029.md) - Public method should be test method
- [MSTEST0030](mstest0030.md) - Type containing test method should be a test class
- [MSTEST0036](mstest0036.md) - Do not use shadowing
- [MSTEST0041](mstest0041.md) - Use condition-based attributes with test class
- [MSTEST0044](mstest0044.md) - Prefer TestMethod over DataTestMethod
- [MSTEST0056](mstest0056.md) - TestMethodAttribute should set DisplayName correctly
- [MSTEST0057](mstest0057.md) - TestMethodAttribute should propagate source information
- [MSTEST0060](mstest0060.md) - Duplicate TestMethodAttribute
- [MSTEST0063](mstest0063.md) - Test class should have valid constructor

Related documentation: [Write tests with MSTest](../unit-testing-mstest-writing-tests.md)

### Async/await patterns

Rules for writing asynchronous test code correctly:

- [MSTEST0013](mstest0013.md) - AssemblyCleanup should be valid (includes async rules)
- [MSTEST0027](mstest0027.md) - Suppress async suffix for test methods
- [MSTEST0028](mstest0028.md) - Suppress async suffix for test fixture methods
- [MSTEST0039](mstest0039.md) - Use newer Assert.Throws methods (async variants)
- [MSTEST0040](mstest0040.md) - Avoid using asserts in async void context
- [MSTEST0045](mstest0045.md) - Use cooperative cancellation for timeout
- [MSTEST0049](mstest0049.md) - Flow TestContext CancellationToken
- [MSTEST0054](mstest0054.md) - Use CancellationToken property

Related documentation: [TestContext](../unit-testing-mstest-writing-tests-testcontext.md)

### Data-driven testing

Rules for working with data-driven test scenarios:

- [MSTEST0007](mstest0007.md) - Use attribute on test method
- [MSTEST0014](mstest0014.md) - DataRow should be valid
- [MSTEST0018](mstest0018.md) - DynamicData should be valid
- [MSTEST0042](mstest0042.md) - Duplicate DataRow
- [MSTEST0052](mstest0052.md) - Avoid explicit DynamicDataSourceType
- [MSTEST0062](mstest0062.md) - Avoid out/ref test method parameters

Related documentation: [Data-driven testing](../unit-testing-mstest-writing-tests-data-driven.md)

### Lifecycle & initialization

Rules for test initialization, cleanup, and lifecycle management:

- [MSTEST0008](mstest0008.md) - TestInitialize should be valid
- [MSTEST0009](mstest0009.md) - TestCleanup should be valid
- [MSTEST0010](mstest0010.md) - ClassInitialize should be valid
- [MSTEST0011](mstest0011.md) - ClassCleanup should be valid
- [MSTEST0012](mstest0012.md) - AssemblyInitialize should be valid
- [MSTEST0013](mstest0013.md) - AssemblyCleanup should be valid
- [MSTEST0019](mstest0019.md) - Prefer TestInitialize over constructors
- [MSTEST0020](mstest0020.md) - Prefer constructors over TestInitialize
- [MSTEST0021](mstest0021.md) - Prefer Dispose over TestCleanup
- [MSTEST0022](mstest0022.md) - Prefer TestCleanup over Dispose
- [MSTEST0034](mstest0034.md) - Use ClassCleanupBehavior.EndOfClass
- [MSTEST0050](mstest0050.md) - Global test fixture should be valid

Related documentation: [Lifecycle](../unit-testing-mstest-writing-tests-lifecycle.md)

### Assertions

Rules for using assertion methods correctly and effectively:

- [MSTEST0006](mstest0006.md) - Avoid ExpectedException attribute
- [MSTEST0014](mstest0014.md) - DataRow should be valid
- [MSTEST0017](mstest0017.md) - Assertion args should be passed in correct order
- [MSTEST0023](mstest0023.md) - Do not negate boolean assertion
- [MSTEST0025](mstest0025.md) - Prefer Assert.Fail over always-false conditions
- [MSTEST0026](mstest0026.md) - Assertion args should avoid conditional access
- [MSTEST0032](mstest0032.md) - Review always-true assert condition
- [MSTEST0037](mstest0037.md) - Use proper assert methods
- [MSTEST0038](mstest0038.md) - Avoid Assert.AreSame with value types
- [MSTEST0039](mstest0039.md) - Use newer Assert.Throws methods
- [MSTEST0046](mstest0046.md) - Use Assert instead of StringAssert
- [MSTEST0051](mstest0051.md) - Assert.Throws should contain single statement
- [MSTEST0053](mstest0053.md) - Avoid Assert format parameters
- [MSTEST0058](mstest0058.md) - Avoid asserts in catch blocks

Related documentation: [Assertions](../unit-testing-mstest-writing-tests-assertions.md)

### TestContext

Rules for properly using the TestContext object:

- [MSTEST0005](mstest0005.md) - TestContext should be valid
- [MSTEST0024](mstest0024.md) - Do not store static TestContext
- [MSTEST0033](mstest0033.md) - Suppress non-nullable reference not initialized warning
- [MSTEST0048](mstest0048.md) - TestContext property usage
- [MSTEST0049](mstest0049.md) - Flow TestContext CancellationToken
- [MSTEST0054](mstest0054.md) - Use CancellationToken property

Related documentation: [TestContext](../unit-testing-mstest-writing-tests-testcontext.md)

### Test configuration

Rules for configuring test execution, parallelization, and other test settings:

- [MSTEST0001](mstest0001.md) - Use Parallelize attribute
- [MSTEST0015](mstest0015.md) - Test method should not be ignored
- [MSTEST0031](mstest0031.md) - Do not use System.ComponentModel.DescriptionAttribute
- [MSTEST0035](mstest0035.md) - Use DeploymentItem with test method or test class
- [MSTEST0043](mstest0043.md) - Use retry attribute on test method
- [MSTEST0045](mstest0045.md) - Use cooperative cancellation for timeout
- [MSTEST0055](mstest0055.md) - Do not ignore string method return value
- [MSTEST0059](mstest0059.md) - Use Parallelize attribute correctly
- [MSTEST0061](mstest0061.md) - Use OSCondition attribute instead of runtime check

Related documentation: [Configure MSTest](../unit-testing-mstest-configure.md), [Running tests](../unit-testing-mstest-running-tests.md)

## All rules (quick reference)

| Rule ID | Category | Title | Default Severity |
|---------|----------|-------|------------------|
| [MSTEST0001](mstest0001.md) | Performance | Use Parallelize attribute | Info |
| [MSTEST0002](mstest0002.md) | Usage | Test class should be valid | Warning |
| [MSTEST0003](mstest0003.md) | Usage | Test method should be valid | Warning → Error* |
| [MSTEST0004](mstest0004.md) | Design | Public types should be test classes | Info |
| [MSTEST0005](mstest0005.md) | Usage | TestContext should be valid | Warning |
| [MSTEST0006](mstest0006.md) | Design | Avoid ExpectedException attribute | Info |
| [MSTEST0007](mstest0007.md) | Usage | Use attribute on test method | Warning |
| [MSTEST0008](mstest0008.md) | Usage | TestInitialize should be valid | Warning |
| [MSTEST0009](mstest0009.md) | Usage | TestCleanup should be valid | Warning |
| [MSTEST0010](mstest0010.md) | Usage | ClassInitialize should be valid | Warning |
| [MSTEST0011](mstest0011.md) | Usage | ClassCleanup should be valid | Warning |
| [MSTEST0012](mstest0012.md) | Usage | AssemblyInitialize should be valid | Warning |
| [MSTEST0013](mstest0013.md) | Usage | AssemblyCleanup should be valid | Warning |
| [MSTEST0014](mstest0014.md) | Usage | DataRow should be valid | Warning |
| [MSTEST0015](mstest0015.md) | Design | Test method should not be ignored | None (opt-in) |
| [MSTEST0016](mstest0016.md) | Design | Test class should have test method | Info |
| [MSTEST0017](mstest0017.md) | Usage | Assertion args should be passed in correct order | Info |
| [MSTEST0018](mstest0018.md) | Usage | DynamicData should be valid | Warning |
| [MSTEST0019](mstest0019.md) | Design | Prefer TestInitialize over constructors | None (opt-in) |
| [MSTEST0020](mstest0020.md) | Design | Prefer constructors over TestInitialize | None (opt-in) |
| [MSTEST0021](mstest0021.md) | Design | Prefer Dispose over TestCleanup | None (opt-in) |
| [MSTEST0022](mstest0022.md) | Design | Prefer TestCleanup over Dispose | None (opt-in) |
| [MSTEST0023](mstest0023.md) | Usage | Do not negate boolean assertion | Info |
| [MSTEST0024](mstest0024.md) | Usage | Do not store static TestContext | Warning |
| [MSTEST0025](mstest0025.md) | Design | Prefer Assert.Fail over always-false conditions | Info |
| [MSTEST0026](mstest0026.md) | Usage | Assertion args should avoid conditional access | Info |
| [MSTEST0027](mstest0027.md) | Suppression | Suppress async suffix for test methods | N/A |
| [MSTEST0028](mstest0028.md) | Suppression | Suppress async suffix for test fixture methods | N/A |
| [MSTEST0029](mstest0029.md) | Design | Public method should be test method | Info |
| [MSTEST0030](mstest0030.md) | Usage | Type containing test method should be a test class | Warning |
| [MSTEST0031](mstest0031.md) | Usage | Do not use System.ComponentModel.DescriptionAttribute | Info |
| [MSTEST0032](mstest0032.md) | Usage | Review always-true assert condition | Info |
| [MSTEST0033](mstest0033.md) | Suppression | Suppress non-nullable reference not initialized | N/A |
| [MSTEST0034](mstest0034.md) | Usage | Use ClassCleanupBehavior.EndOfClass | Info |
| [MSTEST0035](mstest0035.md) | Usage | Use DeploymentItem with test method or test class | Info |
| [MSTEST0036](mstest0036.md) | Design | Do not use shadowing | Warning |
| [MSTEST0037](mstest0037.md) | Usage | Use proper assert methods | Info |
| [MSTEST0038](mstest0038.md) | Usage | Avoid Assert.AreSame with value types | Info |
| [MSTEST0039](mstest0039.md) | Usage | Use newer Assert.Throws methods | Info |
| [MSTEST0040](mstest0040.md) | Usage | Avoid using asserts in async void context | Warning |
| [MSTEST0041](mstest0041.md) | Usage | Use condition-based attributes with test class | Warning |
| [MSTEST0042](mstest0042.md) | Usage | Duplicate DataRow | Warning |
| [MSTEST0043](mstest0043.md) | Usage | Use retry attribute on test method | Warning → Error* |
| [MSTEST0044](mstest0044.md) | Design | Prefer TestMethod over DataTestMethod | Info |
| [MSTEST0045](mstest0045.md) | Design | Use cooperative cancellation for timeout | Info |
| [MSTEST0046](mstest0046.md) | Usage | Use Assert instead of StringAssert | Info |
| [MSTEST0048](mstest0048.md) | Usage | TestContext property usage | Warning |
| [MSTEST0049](mstest0049.md) | Usage | Flow TestContext CancellationToken | Info |
| [MSTEST0050](mstest0050.md) | Usage | Global test fixture should be valid | Warning |
| [MSTEST0051](mstest0051.md) | Usage | Assert.Throws should contain single statement | Info |
| [MSTEST0052](mstest0052.md) | Usage | Avoid explicit DynamicDataSourceType | Info |
| [MSTEST0053](mstest0053.md) | Usage | Avoid Assert format parameters | Info |
| [MSTEST0054](mstest0054.md) | Usage | Use CancellationToken property | Info |
| [MSTEST0055](mstest0055.md) | Usage | Do not ignore string method return value | Warning |
| [MSTEST0056](mstest0056.md) | Usage | TestMethodAttribute should set DisplayName correctly | Info |
| [MSTEST0057](mstest0057.md) | Usage | TestMethodAttribute should propagate source information | Warning |
| [MSTEST0058](mstest0058.md) | Usage | Avoid asserts in catch blocks | Info |
| [MSTEST0059](mstest0059.md) | Usage | Use Parallelize attribute correctly | Warning |
| [MSTEST0060](mstest0060.md) | Usage | Duplicate TestMethodAttribute | Warning |
| [MSTEST0061](mstest0061.md) | Usage | Use OSCondition attribute instead of runtime check | Info |
| [MSTEST0062](mstest0062.md) | Usage | Avoid out/ref test method parameters | Warning |
| [MSTEST0063](mstest0063.md) | Usage | Test class should have valid constructor | Warning |

\* Escalated to Error in `Recommended` and `All` modes.

## MSTESTEXP

Several APIs of MSTest are decorated with the <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>. This attribute indicates that the API is experimental and may be removed or changed in future versions of MSTest. The attribute is used to identify APIs that aren't yet stable and may not be suitable for production use.

The MSTESTEXP diagnostic alerts you to use of an experimental API in your code. To suppress this diagnostic with the `SuppressMessageAttribute`, add the following code to your project:

```csharp
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("MSTESTEXP", "Justification")]
```

Alternatively, you can suppress this diagnostic with preprocessor directive by adding the following code to your project:

```csharp
#pragma warning disable MSTESTEXP
        // API that is causing the warning.
#pragma warning restore MSTESTEXP
```
