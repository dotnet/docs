---
title: MSTest Design rules (code analysis)
description: Learn about MSTest code analysis design rules.
author: evangelink
ms.author: amauryleve
ms.date: 01/03/2024
---

# MSTest design rules

Design rules will help you create and maintain test suites that adhere to proper design and good practices.

Identifier | Name | Description
-----------|------|------------
[MSTEST0004](mstest0004.md) | PublicTypeShouldBeTestClassAnalyzer | It's considered a good practice to have only test classes marked public in a test project.
[MSTEST0006](mstest0006.md) | AvoidExpectedExceptionAttributeAnalyzer | Prefer `Assert.ThrowsExactly` or `Assert.ThrowsExactlyAsync` over `[ExpectedException]` as it ensures that only the expected call throws the expected exception. The assert APIs also provide more flexibility and allow you to assert extra properties of the exception.
[MSTEST0015](mstest0015.md) | TestMethodShouldNotBeIgnored | Test methods should not be ignored (marked with `[Ignore]`).
[MSTEST0016](mstest0016.md) | TestClassShouldHaveTestMethod | Test class should have at least one test method or be 'static' with method(s) marked by `[AssemblyInitialization]` and/or `[AssemblyCleanup]`.
[MSTEST0019](mstest0019.md) | PreferTestInitializeOverConstructorAnalyzer | Prefer TestInitialize methods over constructors
[MSTEST0020](mstest0020.md) | PreferConstructorOverTestInitializeAnalyzer | Prefer constructors over TestInitialize methods
[MSTEST0021](mstest0021.md) | PreferDisposeOverTestCleanupAnalyzer | Prefer Dispose over TestCleanup methods
[MSTEST0022](mstest0022.md) | PreferTestCleanupOverDisposeAnalyzer | Prefer TestCleanup over Dispose methods
[MSTEST0025](mstest0025.md) | PreferAssertFailOverAlwaysFalseConditionsAnalyzer | Use 'Assert.Fail' instead of an always-failing assert
[MSTEST0029](mstest0029.md) | PublicMethodShouldBeTestMethod | A `public` method of a class marked with `[TestClass]` should be a test method (marked with `[TestMethod]`). The rule ignores methods that are marked with `[TestInitialize]`, or `[TestCleanup]` attributes.
[MSTEST0036](mstest0036.md) | DoNotUseShadowingAnalyzer | Shadowing test members could cause testing issues (such as NRE).
