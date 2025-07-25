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
[MSTEST0002](mstest0002.md) | TestClassShouldBeValidAnalyzer | A test class is not following one or multiple points of the required test class layout.
[MSTEST0003](mstest0003.md) | TestMethodShouldBeValidAnalyzer | A test method is not following single or multiple points of the required test method layout.
[MSTEST0005](mstest0005.md) | TestContextShouldBeValidAnalyzer | A test context property is not following single or multiple points of the required test context layout.
[MSTEST0007](mstest0007.md) | UseAttributeOnTestMethodAnalyzer | A method that's not marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> has one or more test attributes applied to it.
[MSTEST0008](mstest0008.md) | TestInitializeShouldBeValidAnalyzer | A method marked with `[TestInitialize]` should have valid layout.
[MSTEST0009](mstest0009.md) | TestCleanupShouldBeValidAnalyzer | A method marked with `[TestCleanup]` should have valid layout.
[MSTEST0010](mstest0010.md) | ClassInitializeShouldBeValidAnalyzer | A method marked with `[ClassInitialize]` should have valid layout.
[MSTEST0011](mstest0011.md) | ClassCleanupShouldBeValidAnalyzer | A method marked with `[ClassCleanup]` should have valid layout.
[MSTEST0012](mstest0012.md) | AssemblyInitializeShouldBeValidAnalyzer | A method marked with `[AssemblyInitialize]` should have valid layout.
[MSTEST0013](mstest0013.md) | AssemblyCleanupShouldBeValidAnalyzer | A method marked with `[AssemblyCleanup]` should have valid layout.
[MSTEST0014](mstest0014.md) | DataRowShouldBeValidAnalyzer | An instance of `[DataRow]` is not following one or multiple points of the required `DataRow` layout.
[MSTEST0017](mstest0017.md) | AssertionArgsShouldBePassedInCorrectOrder | This rule raises an issue when calls to `Assert.AreEqual`, `Assert.AreNotEqual`, `Assert.AreSame` or `Assert.AreNotSame` are following one or multiple of the patterns below:<br/><br/>- `actual` argument is a constant or literal value<br/>- `actual` argument variable starts with `expected`, `_expected` or `Expected`<br/>- `expected` or `notExpected` argument <br/>variable starts with `actual`<br/>- `actual` is not a local variable
[MSTEST0018](mstest0018.md) | DynamicDataShouldBeValidAnalyzer | A method marked with `[DynamicData]` should have valid layout.
[MSTEST0023](mstest0023.md) | DoNotNegateBooleanAssertionAnalyzer | This rule raises a diagnostic when a call to `Assert.IsTrue` or `Assert.IsFalse` contains a negated argument.
[MSTEST0024](mstest0024.md) | DoNotStoreStaticTestContextAnalyzer | This rule raises a diagnostic when an assignment to a `static` member of a `TestContext` parameter is done.
[MSTEST0026](mstest0026.md) | AssertionArgsShouldAvoidConditionalAccessRuleId | This rule raises a diagnostic when an argument containing a [null conditional operator](../../../csharp/language-reference/operators/member-access-operators.md#null-conditional-operators--and-) `(?.)` or `?[]` is passed to the assertion methods below:<br/><br/>- `Assert.IsTrue`<br/>- `Assert.IsFalse`<br/>- `Assert.AreEqual`<br/>- `Assert.AreNotEqual`<br/>- `Assert.AreSame`<br/>- `Assert.AreNotSame`<br/>- `CollectionAssert.AreEqual`<br/>- `CollectionAssert.AreNotEqual`<br/>- `CollectionAssert.AreEquivalent`<br/>- `CollectionAssert.AreNotEquivalent`<br/>- CollectionAssert.Contains`<br/>- `CollectionAssert.DoesNotContain`<br/>- `CollectionAssert.AllItemsAreNotNull`<br/>- `CollectionAssert.AllItemsAreUnique`<br/>- `CollectionAssert.AllItemsAreInstancesOfType`<br/>- `CollectionAssert.IsSubsetOf`<br/>- `CollectionAssert.IsNotSubsetOf`<br/>- `StringAssert.Contains`<br/>- `StringAssert.StartsWith`<br/>- `StringAssert.EndsWith`<br/>- `StringAssert.Matches`<br/>- `StringAssert.DoesNotMatch`
[MSTEST0030](mstest0030.md) | TypeContainingTestMethodShouldBeATestClass | Type containing `[TestMethod]` should be marked with `[TestClass]`, otherwise the test method will be silently ignored.
[MSTEST0031](mstest0031.md) | DoNotUseSystemDescriptionAttribute | 'System.ComponentModel.DescriptionAttribute' has no effect in the context of tests.
[MSTEST0032](mstest0032.md) | ReviewAlwaysTrueAssertConditionAnalyzer | This rule raises a diagnostic when a call to an assertion produces an always-true condition.
[MSTEST0034](mstest0034.md) | UseClassCleanupBehaviorEndOfClass | This rule raises a diagnostic when `ClassCleanupBehavior.EndOfClass` isn't set with the `[ClassCleanup]`.
[MSTEST0035](mstest0035.md) | UseDeploymentItemWithTestMethodOrTestClassTitle | This rule raises a diagnostic when `[DeploymentItem]` isn't set on test class or test method.
[MSTEST0037](mstest0037.md) | UseProperAssertMethodsAnalyzer | The use of <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods in a specific way when there is a better alternative.
[MSTEST0038](mstest0038.md) | AvoidAssertAreSameWithValueTypesAnalyzer | The use of <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame%2A?displayProperty=nameWithType> or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotSame*?displayProperty=nameWithType> with one or both arguments being a value type.
[MSTEST0039](mstest0039.md) | UseNewerAssertThrowsAnalyzer | The use of `Assert.ThrowsException` or `Assert.ThrowsExceptionAsync`, which are no longer recommended.
[MSTEST0040](mstest0040.md) | AvoidUsingAssertsInAsyncVoidContextAnalyzer | The use of any assertion method in an `async void` method, local function, or lambda.
[MSTEST0041](mstest0041.md) | UseConditionBaseWithTestClassAnalyzer | The use of an attribute that inherits from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionBaseAttribute> on a class that is not marked with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute>.
[MSTEST0042](mstest0042.md) | DuplicateDataRowAnalyzer | A test method has two or more [DataRow](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute) attributes that are equivalent.
[MSTEST0043](mstest0043.md) | UseRetryWithTestMethodAnalyzer | A method has an attribute that derives from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.RetryBaseAttribute> and does not have an attribute that derives from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute>.
[MSTEST0046](mstest0046.md) | StringAssertToAssertAnalyzer | A test method uses <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> methods instead of equivalent <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> methods.
[MSTEST0048](mstest0048.md) | TestContextPropertyUsageAnalyzer | A fixture method (methods with <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyCleanupAttribute>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute>, or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute>) accesses restricted <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> properties.
[MSTEST0049](mstest0049.md) | FlowTestContextCancellationTokenAnalyzer | A method call within a test context doesn't use the <xref:System.Threading.CancellationToken> available from <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> when the called method has a parameter or overload that accepts a <xref:System.Threading.CancellationToken>.
