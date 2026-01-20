---
title: MSTest Usage rules (code analysis)
description: Learn about MSTest code analysis usage rules.
author: evangelink
ms.author: amauryleve
ms.date: 10/01/2025
---

# MSTest usage rules

Usage rules support proper usage of MSTest attributes, methods, and patterns. These rules catch common mistakes and ensure your tests follow the framework's requirements and conventions.

## Rules in this category

| Rule ID | Title | Severity | Fix Available |
|---------|-------|----------|---------------|
| [MSTEST0002](mstest0002.md) | Test class should be valid | Warning | Yes |
| [MSTEST0003](mstest0003.md) | Test method should be valid | Warning → Error* | Yes |
| [MSTEST0005](mstest0005.md) | TestContext should be valid | Warning | Yes |
| [MSTEST0007](mstest0007.md) | Use attribute on test method | Warning | No |
| [MSTEST0008](mstest0008.md) | TestInitialize should be valid | Warning | Yes |
| [MSTEST0009](mstest0009.md) | TestCleanup should be valid | Warning | Yes |
| [MSTEST0010](mstest0010.md) | ClassInitialize should be valid | Warning | Yes |
| [MSTEST0011](mstest0011.md) | ClassCleanup should be valid | Warning | Yes |
| [MSTEST0012](mstest0012.md) | AssemblyInitialize should be valid | Warning | Yes |
| [MSTEST0013](mstest0013.md) | AssemblyCleanup should be valid | Warning | Yes |
| [MSTEST0014](mstest0014.md) | DataRow should be valid | Warning | Yes |
| [MSTEST0017](mstest0017.md) | Assertion args should be passed in correct order | Info | Yes |
| [MSTEST0018](mstest0018.md) | DynamicData should be valid | Warning | Yes |
| [MSTEST0023](mstest0023.md) | Do not negate boolean assertion | Info | Yes |
| [MSTEST0024](mstest0024.md) | Do not store static TestContext | Warning | No |
| [MSTEST0026](mstest0026.md) | Assertion args should avoid conditional access | Info | No |
| [MSTEST0030](mstest0030.md) | Type containing test method should be a test class | Warning | Yes |
| [MSTEST0031](mstest0031.md) | Do not use System.ComponentModel.DescriptionAttribute | Info | Yes |
| [MSTEST0032](mstest0032.md) | Review always-true assert condition | Info | No |
| [MSTEST0034](mstest0034.md) | Use ClassCleanupBehavior.EndOfClass | Info | Yes |
| [MSTEST0035](mstest0035.md) | Use DeploymentItem with test method or test class | Info | No |
| [MSTEST0037](mstest0037.md) | Use proper assert methods | Info | Yes |
| [MSTEST0038](mstest0038.md) | Avoid Assert.AreSame with value types | Info | Yes |
| [MSTEST0039](mstest0039.md) | Use newer Assert.Throws methods | Info | Yes |
| [MSTEST0040](mstest0040.md) | Avoid using asserts in async void context | Warning | No |
| [MSTEST0041](mstest0041.md) | Use condition-based attributes with test class | Warning | No |
| [MSTEST0042](mstest0042.md) | Duplicate DataRow | Warning | No |
| [MSTEST0043](mstest0043.md) | Use retry attribute on test method | Warning → Error* | Yes |
| [MSTEST0046](mstest0046.md) | Use Assert instead of StringAssert | Info | Yes |
| [MSTEST0048](mstest0048.md) | TestContext property usage | Warning | No |
| [MSTEST0049](mstest0049.md) | Flow TestContext CancellationToken | Info | Yes |
| [MSTEST0050](mstest0050.md) | Global test fixture should be valid | Warning | Yes |
| [MSTEST0051](mstest0051.md) | Assert.Throws should contain single statement | Info | Yes |
| [MSTEST0052](mstest0052.md) | Avoid explicit DynamicDataSourceType | Info | Yes |
| [MSTEST0053](mstest0053.md) | Avoid Assert format parameters | Info | Yes |
| [MSTEST0054](mstest0054.md) | Use CancellationToken property | Info | Yes |
| [MSTEST0055](mstest0055.md) | Do not ignore string method return value | Warning | No |
| [MSTEST0056](mstest0056.md) | TestMethodAttribute should set DisplayName correctly | Info | Yes |
| [MSTEST0057](mstest0057.md) | TestMethodAttribute should propagate source information | Warning | No |
| [MSTEST0058](mstest0058.md) | Avoid asserts in catch blocks | Info | No |
| [MSTEST0059](mstest0059.md) | Use Parallelize attribute correctly | Warning | No |
| [MSTEST0060](mstest0060.md) | Duplicate TestMethodAttribute | Warning | Yes |
| [MSTEST0061](mstest0061.md) | Use OSCondition attribute instead of runtime check | Info | Yes |
| [MSTEST0062](mstest0062.md) | Avoid out/ref test method parameters | Warning | Yes |

\* Escalated to Error in `Recommended` and `All` modes.

## Common scenarios

### Test structure validation

Ensure your test classes, methods, and fixtures follow MSTest requirements:

- **[MSTEST0002](mstest0002.md)**: Test class layout requirements (for example, public, non-static)
- **[MSTEST0003](mstest0003.md)**: Test method layout requirements (⚠️ escalated to Error)
- **[MSTEST0030](mstest0030.md)**: Methods with [TestMethod] must be in a [TestClass]

### Lifecycle methods

Validate initialization and cleanup methods:

- **[MSTEST0008](mstest0008.md)**: TestInitialize validation
- **[MSTEST0009](mstest0009.md)**: TestCleanup validation
- **[MSTEST0010](mstest0010.md)**: ClassInitialize validation
- **[MSTEST0011](mstest0011.md)**: ClassCleanup validation
- **[MSTEST0012](mstest0012.md)**: AssemblyInitialize validation
- **[MSTEST0013](mstest0013.md)**: AssemblyCleanup validation
- **[MSTEST0034](mstest0034.md)**: Set ClassCleanupBehavior.EndOfClass
- **[MSTEST0050](mstest0050.md)**: Global test fixture validation

### Data-driven testing

Ensure data attributes are used correctly:

- **[MSTEST0007](mstest0007.md)**: Data attributes must be on test methods
- **[MSTEST0014](mstest0014.md)**: DataRow validation
- **[MSTEST0018](mstest0018.md)**: DynamicData validation
- **[MSTEST0042](mstest0042.md)**: Detect duplicate DataRows
- **[MSTEST0052](mstest0052.md)**: Use AutoDetect for DynamicDataSourceType
- **[MSTEST0062](mstest0062.md)**: Avoid out/ref parameters

### Writing better assertions

Rules for correct and effective assertion usage:

- **[MSTEST0017](mstest0017.md)**: Pass expected/actual in correct order
- **[MSTEST0023](mstest0023.md)**: Don't negate conditions (use Assert.IsFalse directly)
- **[MSTEST0026](mstest0026.md)**: Avoid null-conditional operators in assertions
- **[MSTEST0032](mstest0032.md)**: Review always-true conditions
- **[MSTEST0037](mstest0037.md)**: Use the most appropriate assert method
- **[MSTEST0038](mstest0038.md)**: Don't use AreSame with value types
- **[MSTEST0039](mstest0039.md)**: Use Assert.ThrowsExactly (newer API)
- **[MSTEST0046](mstest0046.md)**: Prefer Assert over StringAssert
- **[MSTEST0051](mstest0051.md)**: Assert.Throws should test single statement
- **[MSTEST0053](mstest0053.md)**: Use string interpolation instead of format parameters
- **[MSTEST0058](mstest0058.md)**: Don't put assertions in catch blocks

### TestContext usage

Proper usage of the TestContext object:

- **[MSTEST0005](mstest0005.md)**: TestContext property validation
- **[MSTEST0024](mstest0024.md)**: Don't store TestContext in static fields
- **[MSTEST0048](mstest0048.md)**: Restricted property access in fixtures
- **[MSTEST0049](mstest0049.md)**: Flow cancellation tokens from TestContext
- **[MSTEST0054](mstest0054.md)**: Use TestContext.CancellationToken property

### Async patterns

Rules for asynchronous test code:

- **[MSTEST0040](mstest0040.md)**: Avoid asserts in async void methods

### Test configuration

- **[MSTEST0031](mstest0031.md)**: Use proper attributes (not System.ComponentModel.Description)
- **[MSTEST0035](mstest0035.md)**: DeploymentItem usage
- **[MSTEST0041](mstest0041.md)**: Condition attributes must be on test classes
- **[MSTEST0043](mstest0043.md)**: Retry attributes must be on test methods (⚠️ escalated to Error)
- **[MSTEST0055](mstest0055.md)**: Don't ignore string method return values
- **[MSTEST0056](mstest0056.md)**: Set DisplayName properly on TestMethodAttribute
- **[MSTEST0057](mstest0057.md)**: Propagate source info in custom TestMethodAttribute
- **[MSTEST0059](mstest0059.md)**: Don't use both Parallelize and DoNotParallelize
- **[MSTEST0060](mstest0060.md)**: Avoid duplicate TestMethodAttribute
- **[MSTEST0061](mstest0061.md)**: Use OSCondition attribute for platform checks

## Related documentation

- [Write tests with MSTest](../unit-testing-mstest-writing-tests.md)
- [Attributes](../unit-testing-mstest-writing-tests-attributes.md)
- [Assertions](../unit-testing-mstest-writing-tests-assertions.md)
- [Lifecycle](../unit-testing-mstest-writing-tests-lifecycle.md)
- [TestContext](../unit-testing-mstest-writing-tests-testcontext.md)
