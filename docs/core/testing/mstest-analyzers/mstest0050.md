---
title: "MSTEST0050: Global test fixture should be valid"
description: "Learn about code analysis rule MSTEST0050: Global test fixture should be valid"
ms.date: 11/05/2026
f1_keywords:
- MSTEST0050
- GlobalTestFixtureShouldBeValidAnalyzer
helpviewer_keywords:
- GlobalTestFixtureShouldBeValidAnalyzer
- MSTEST0050
author: Evangelink
ms.author: amauryleve
ai-usage: ai-assisted
---
# MSTEST0050: Global test fixture should be valid

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0050                                                                               |
| **Title**                           | Global test fixture should be valid                                                     |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning in MSTest 4.3 and later; error in earlier versions                               |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | No                                                                                       |

## Cause

A global test fixture method (marked with `GlobalTestInitializeAttribute` or `GlobalTestCleanupAttribute`) doesn't follow the required layout or has invalid configuration.

## Rule description

`GlobalTestInitialize` and `GlobalTestCleanup` run before and after each test across the assembly. They let you apply shared per-test setup or cleanup without adding a callback to every test class:

| Requirement | Reason |
|-------------|--------|
| The method is `public static`. | MSTest invokes a global callback without an instance of its declaring class. The callback can run for tests in other classes, so it can't depend on the declaring class's per-test fields. |
| The method is ordinary and isn't `abstract` or generic. | MSTest needs a callable method body without special invocation rules or method type arguments. |
| The method takes exactly one `TestContext` parameter. | The parameter identifies the current test execution, including when the test belongs to another class. |
| The return type is `void`, `Task`, or `ValueTask`, and the method isn't `async void`. | MSTest must wait for setup or cleanup and observe failures before it proceeds with the current test's lifecycle. |
| The declaring type is a public, non-generic class marked with `[TestClass]` or a derived attribute. | MSTest discovers global callbacks through a known test-class container. The class can be static, but doesn't have to be, because the callback itself doesn't require an instance. |

For the callback order, see [Global test-level lifecycle](../unit-testing-mstest-writing-tests-lifecycle.md#global-test-level-lifecycle).

## How to fix violations

Ensure that global test fixture methods follow the required layout.

## When to suppress warnings

Don't suppress warnings from this rule. Invalid global test fixture methods will not execute at runtime.
