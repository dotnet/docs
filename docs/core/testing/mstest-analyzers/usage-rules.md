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
[MSTEST0003](mstest0003.md) | TestMethodShouldBeValidAnalyzer | Test methods, methods marked with the `[TestMethod]` attribute, should respect the following layout to be considered valid by MSTest:<br/>- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)<br/>- it should not be `static`<br/>- it should not be generic<br/>- it should not be `abstract`<br/>- return type should be `void` or `Task`<br/>- it should not be `async void`<br/>- it should be a special method (finalizer, operator...).
[MSTEST0005](mstest0005.md) | TestContextShouldBeValidAnalyzer | TestContext property should follow the following layout to be valid:<br/>- it should be a property<br/>- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)<br/>- it should not be `static`<br/>- it should not be readonly.
[MSTEST0007](mstest0007.md) | UseAttributeOnTestMethodAnalyzer | The following test attributes should only be applied on methods marked with the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute:<br/>- `[CssIteration]`<br/>- `[CssProjectStructure]`<br/>- `[Description]`<br/>- `[ExpectedException]`<br/>- `[Owner]`<br/>- `[Priority]`<br/>- `[TestProperty]`<br/>- `[WorkItem]`
[MSTEST0008](mstest0008.md) | TestInitializeShouldBeValidAnalyzer | Methods marked with `[TestInitialize]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should not be `static`<br/>- it should not be generic<br/>- it should not be `abstract`<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0009](mstest0009.md) | TestCleanupShouldBeValidAnalyzer | Methods marked with `[TestCleanup]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should not be `static`<br/>- it should not be generic<br/>- it should not be `abstract`<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0010](mstest0010.md) | ClassInitializeShouldBeValidAnalyzer | Methods marked with `[ClassInitialize]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should be `static`<br/>- it should not be generic<br/>- it should take one parameter of type `TestContext`<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0011](mstest0011.md) | ClassCleanupShouldBeValidAnalyzer | Methods marked with `[ClassCleanup]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should be `static`<br/>- it should not be generic<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0012](mstest0012.md) | AssemblyInitializeShouldBeValidAnalyzer | Methods marked with `[AssemblyInitialize]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should be `static`<br/>- it should not be generic<br/>- it should take one parameter of type `TestContext`<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0013](mstest0013.md) | AssemblyCleanupShouldBeValidAnalyzer | Methods marked with `[AssemblyCleanup]` should follow the following layout to be valid:<br/>- it should be `public` <br/>- it should be `static`<br/>- it should not be generic<br/>- it should not take any parameter<br/>- return type should be `void`, `Task` or `ValueTask`<br/>- it should not be `async void`<br/>- it should not be a special method (finalizer, operator...).
[MSTEST0014](mstest0014.md) | DataRowShouldBeValidAnalyzer | `[DataRow]` instances should have the following layout to be valid:<br/>- they should only be set on a test method<br/>- argument count should match method parameters count<br/>- argument type should match method argument type
