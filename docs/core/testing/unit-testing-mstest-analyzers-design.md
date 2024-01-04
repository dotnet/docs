---
title: MSTest Design rules (code analysis)
description: Learn about MSTest code analysis design rules.
author: evangelink
ms.author: amauryleve
ms.date: 01/03/2024
---

# MSTest design rules

Design rules support adherence to proper design of test suites.

Identifier | Name | Description
-----------|------|------------
[MSTEST0004](unit-testing-mstest-analyzers-MSTEST0004.md) | PublicTypeShouldBeTestClassAnalyzer | It's considered a good practice to have only test classes marked public in a test project.
[MSTEST0006](unit-testing-mstest-analyzers-MSTEST0006.md) | AvoidExpectedExceptionAttributeAnalyzer | Prefer `Assert.ThrowsException` or `Assert.ThrowsExceptionAsync` over `[ExpectedException]` as it ensures that only the expected call throws the expected exception. The assert APIs also provide more flexibility and allow you to assert extra properties of the exception.
