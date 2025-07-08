---
title: MSTest Suppression rules (code analysis)
description: Learn about MSTest code suppression rules.
author: evangelink
ms.author: amauryleve
ms.date: 12/20/2023
---

# MSTest suppression rules

Rules that support suppressing diagnostics from other rules.

Identifier | Name | Description
-----------|------|------------
[MSTEST0027](mstest0027.md) | UseAsyncSuffixTestMethodSuppressor | Suppress the [VSTHRD200: Use Async suffix for async methods](../../../csharp/language-reference/compiler-messages/nullable-warnings.md#nonnullable-reference-not-initialized) diagnostic for all test methods as they are not required to follow the naming convention.
[MSTEST0028](mstest0028.md) | UseAsyncSuffixTestFixtureMethodSuppressor | Suppress the [VSTHRD200: Use Async suffix for async methods](../../../csharp/language-reference/compiler-messages/nullable-warnings.md#nonnullable-reference-not-initialized) diagnostic for all test fixture methods as they are not required to follow the naming convention.
[MSTEST0033](mstest0033.md) | NonNullableReferenceNotInitializedSuppressor | Suppress the [CS8618: Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.](../../../csharp/language-reference/compiler-messages/nullable-warnings.md#nonnullable-reference-not-initialized) diagnostic for the `TestContext` property as its value is always initialized by the MSTest framework.
