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
[MSTEST0002](unit-testing-mstest-analyzers-MSTEST0002.md) | TestClassShouldBeValidAnalyzer | Test classes, classes marked with the `[TestClass]` attribute, should respect the following layout to be considered valid by MSTest: <br/>- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)<br/>- it should not be `static`<br/>- it should not be generic.
[MSTEST0003](unit-testing-mstest-analyzers-MSTEST0003.md) | TestMethodShouldBeValidAnalyzer | Test methods, methods marked with the `[TestMethod]` attribute, should respect the following layout to be considered valid by MSTest:<br/>- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)<br/>- it should not be `static`<br/>- it should not be generic<br/>- it should not be `abstract`<br/>- return type should be `void` or `Task`<br/>- it should not be `async void`<br/>- it should be a special method (finalizer, operator...).
[MSTEST0005](unit-testing-mstest-analyzers-MSTEST0005.md) | TestContextShouldBeValidAnalyzer | TestContext property should follow the following layout to be valid:<br/>- it should be a property<br/>- it should be `public` (or `internal` if `[assembly: DiscoverInternals]` attribute is set)<br/>- it should not be `static`<br/>- it should not be readonly.
