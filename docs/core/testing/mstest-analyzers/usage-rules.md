---
title: MSTest Usage rules (code analysis)
description: Learn about MSTest code analysis usage rules.
author: evangelink
ms.author: amauryleve
ms.date: 01/03/2024
---

# MSTest usage rules

Rules that support proper usage of MSTest.

Identifier | Name | Description
-----------|------|------------
[MSTEST0002](mstest0002.md) | TestClassShouldBeValidAnalyzer | Test classes, classes marked with the `[TestClass]` attribute, should respect the following layout to be considered valid by MSTest: <br/>- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)<br/>- it should not be `static`<br/>- it should not be generic.
[MSTEST0003](mstest0003.md) | TestMethodShouldBeValidAnalyzer | Test methods, methods marked with the `[TestMethod]` attribute, should respect the following layout to be considered valid by MSTest:<br/>- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)<br/>- it should not be `static`<br/>- it should not be generic<br/>- it should not be `abstract`<br/>- return type should be `void` or `Task`<br/>- it should not be `async void`<br/>- it should not be a special method (for example, finalizer or operator).
[MSTEST0005](mstest0005.md) | TestContextShouldBeValidAnalyzer | TestContext property should follow the following layout to be valid:<br/>- it should be a property<br/>- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)<br/>- it should not be `static`<br/>- it should not be readonly.
[MSTEST0007](mstest0007.md) | UseAttributeOnTestMethodAnalyzer | The following test attributes should only be applied on methods marked with the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute:<br/>- `[CssIteration]`<br/>- `[CssProjectStructure]`<br/>- `[Description]`<br/>- `[ExpectedException]`<br/>- `[Owner]`<br/>- `[Priority]`<br/>- `[TestProperty]`<br/>- `[WorkItem]`
[MSTEST0008](mstest0008.md) | TestInitializeShouldBeValidAnalyzer | Methods marked with `[TestInitialize]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should not be `static`<br/>- it should not be generic<br/>- it should not be `abstract`<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0009](mstest0009.md) | TestCleanupShouldBeValidAnalyzer | Methods marked with `[TestCleanup]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should not be `static`<br/>- it should not be generic<br/>- it should not be `abstract`<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0010](mstest0010.md) | ClassInitializeShouldBeValidAnalyzer | Methods marked with `[ClassInitialize]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should be `static`<br/>- it should not be generic<br/>- it should take one parameter of type `TestContext`<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0011](mstest0011.md) | ClassCleanupShouldBeValidAnalyzer | Methods marked with `[ClassCleanup]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should be `static`<br/>- it should not be generic<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0012](mstest0012.md) | AssemblyInitializeShouldBeValidAnalyzer | Methods marked with `[AssemblyInitialize]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should be `static`<br/>- it should not be generic<br/>- it should take one parameter of type `TestContext`<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0013](mstest0013.md) | AssemblyCleanupShouldBeValidAnalyzer | Methods marked with `[AssemblyCleanup]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should be `static`<br/>- it should not be generic<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0014](mstest0014.md) | DataRowShouldBeValidAnalyzer | `[DataRow]` instances should have the following layout to be valid:<br/>- they should only be set on a test method<br/>- argument count should match method parameters count<br/>- argument type should match method argument type
[MSTEST0017](mstest0017.md) | AssertionArgsShouldBePassedInCorrectOrder | Assertion arguments should be passed in the correct order
[MSTEST0018](mstest0018.md) | DynamicDataShouldBeValidAnalyzer | Methods marked with `[DynamicData]` should also be marked with `[TestMethod]` (or a derived attribute)
[MSTEST0023](mstest0023.md) | DoNotNegateBooleanAssertionAnalyzer | Do not negate boolean assertions
[MSTEST0024](mstest0024.md) | DoNotStoreStaticTestContextAnalyzer | Do not store TestContext in a static member
[MSTEST0026](mstest0026.md) | AssertionArgsShouldAvoidConditionalAccessRuleId | Avoid conditional access in assertions
[MSTEST0030](mstest0030.md) | TypeContainingTestMethodShouldBeATestClass | Type containing `[TestMethod]` should be marked with `[TestClass]`
[MSTEST0031](mstest0031.md) | DoNotUseSystemDescriptionAttribute | 'System.ComponentModel.DescriptionAttribute' has no effect in the context of tests
[MSTEST0032](mstest0032.md) | ReviewAlwaysTrueAssertConditionAnalyzer | Review or remove the assertion as its condition is known to be always true
[MSTEST0034](mstest0034.md) | UseClassCleanupBehaviorEndOfClass | Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`
[MSTEST0035](mstest0035.md) | UseDeploymentItemWithTestMethodOrTestClassTitle | `[DeploymentItem]` can be specified only on test class or test method
[MSTEST0037](mstest0037.md) | UseProperAssertMethodsAnalyzer | Use proper `Assert` methods
[MSTEST0038](mstest0038.md) | AvoidAssertAreSameWithValueTypesAnalyzer | Don't use `Assert.AreSame` or `Assert.AreNotSame` with value types
[MSTEST0039](mstest0039.md) | UseNewerAssertThrowsAnalyzer | Use newer 'Assert.Throws' methods
[MSTEST0040](mstest0040.md) | AvoidUsingAssertsInAsyncVoidContextAnalyzer | Do not assert inside 'async void' contexts
[MSTEST0041](mstest0041.md) | UseConditionBaseWithTestClassAnalyzer | Use 'ConditionBaseAttribute' on test classes
[MSTEST0042](mstest0042.md) | DuplicateDataRowAnalyzer | Avoid duplicated 'DataRow' entries
[MSTEST0043](mstest0043.md) | UseRetryWithTestMethodAnalyzer | Use retry attribute on test method
